namespace CharazayPlus.WebApi.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;


    public static class TaskExtensions
    {
        /// <summary>
        /// http://stackoverflow.com/questions/4238345/asynchronously-wait-for-taskt-to-complete-with-timeout
        /// blogs.msdn.com/b/pfxteam/archive/2011/11/10/10235834.aspx
        /// </summary>
        /// <returns></returns>
        public static async Task WaitUntilFinishedOrTimeout(CancellationToken cancellationToken)
        {
            int timeout = 1000;
            var task = SomeOperationAsync(cancellationToken);
            if (await Task.WhenAny(task, Task.Delay(timeout, cancellationToken)) == task)
            {
                // Task completed within timeout.
                // Consider that the task may have faulted or been canceled.
                // We re-await the task so that any exceptions/cancellation is rethrown.
                await task;
            }
            else
            {
                // timeout/cancellation logic
            }
        }

        private static Task SomeOperationAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        async static Task<TResult> WithTimeout<TResult>(this Task<TResult> task, TimeSpan timeout)
        {
            Task winner = await (Task.WhenAny(task, Task.Delay(timeout)));
            if (winner != task) throw new TimeoutException();
            return await task; // Unwrap result/re-throw
        }

        static Task<TResult> WithCancellation<TResult>(this Task<TResult> task, CancellationToken cancelToken)
        {
            var tcs = new TaskCompletionSource<TResult>();
            var reg = cancelToken.Register(() => tcs.TrySetCanceled());
            task.ContinueWith(ant =>
            {
                reg.Dispose();
                if (ant.IsCanceled)
                    tcs.TrySetCanceled();
                else if (ant.IsFaulted)
                    tcs.TrySetException(ant.Exception.InnerException);
                else
                    tcs.TrySetResult(ant.Result);
            });
            return tcs.Task;
        }

        public static async Task<TResult[]> WhenAllOrError<TResult>(params Task<TResult>[] tasks)
        {
            var killJoy = new TaskCompletionSource<TResult[]>();

            foreach (var task in tasks)
                //warning CS4014: Because this call is not awaited, execution of the current method continues before the call is completed. 
                //Consider applying the 'await' operator to the result of the call.
                await task.ContinueWith(ant =>
                {
                    if (ant.IsCanceled)
                        killJoy.TrySetCanceled();
                    else if (ant.IsFaulted)
                        killJoy.TrySetException(ant.Exception.InnerException);
                    else
                        return ant.Result;

                    return default(TResult);
                });

            return await await Task.WhenAny(killJoy.Task, Task.WhenAll(tasks));
        }

        public static async Task<int> Delay(int ms) { await Task.Delay(ms); return ms; }

#pragma warning disable 4014
        public async static Task<T[]> WhenAllOrError<T>(
            IProgress<T> progress,
            params Task<T>[] tasks)
        {
            var errorResult = new TaskCompletionSource<T[]>();
            foreach (var task in tasks)
            {
                //await 
                task.ContinueWith(t =>
                        {
                            if (t.IsCanceled)
                            {
                                errorResult.TrySetCanceled();
                            }
                            else if (t.IsFaulted)
                            {
                                errorResult.TrySetException(
                                    t.Exception.InnerException);
                            }
                            else
                            {
                                progress.Report(t.Result);
                                return t.Result;
                            }

                            return default(T);
                        });
            }

            return await await Task.WhenAny(errorResult.Task, Task.WhenAll(tasks));
        }
#pragma warning restore 4014

        // Work for 10 sec
        const int msWorkingTime = 7000;

        static readonly Random r = new Random(137);

        static void MainTestRecurringTask()
        {
            var cts = new CancellationTokenSource(msWorkingTime);

            Action action = () => { Console.WriteLine("Random: {0}", r.Next(100)); };

            try
            {
                RepeatDelayAsync(2000, 1000, cts.Token, action).Wait();
            }

            catch (AggregateException ae)
            {
                ae.Handle(e => e is TaskCanceledException);
            }

            Console.WriteLine("{0}: Done after {1} msec of recurring", DateTime.Now, msWorkingTime);

            Console.Read();
        }

        /// <summary>
        /// https://social.msdn.microsoft.com/Forums/en-US/d3f4f460-7d35-4406-b427-9c77bbbe6b55/repeating-tasks?forum=tpldataflow
        /// </summary>
        /// <param name="msDelay"></param>
        /// <param name="msRepeat"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        static async Task DelayAsync(int msDelay, int msRepeat, CancellationToken ct)
        {

            Console.WriteLine("{0}: Launching with {1} msec delay", DateTime.Now, msDelay);

            await Task.Delay(msDelay, ct);


            while (true)
            {
                Console.WriteLine("{0}: Repeating every {1} msec", DateTime.Now, msRepeat);

                await Task.Delay(msRepeat, ct);
            }
        }

        /// <example>
        /// 
        /// </example>
        /// <param name="msDelay"></param>
        /// <param name="msRepeat"></param>
        /// <param name="ct"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        static async Task RepeatDelayAsync(int msDelay, int msRepeat, CancellationToken ct, Action action)
        {
            //Console.WriteLine("{0}: Launching with {1} msec delay", DateTime.Now, msDelay);

            var t = Task.Delay(msDelay, ct);
            var continuationAction = t.ContinueWith(antecedent => action());
            await Task.WhenAll(t, continuationAction);

            while (true)
            {
                //Console.WriteLine("{0}: Repeating every {1} msec", DateTime.Now, msRepeat);

                t = Task.Delay(msRepeat, ct);
                continuationAction = t.ContinueWith(antecedent => action());
                await Task.WhenAll(t, continuationAction);
            }
        }

        public static async Task RepeatDelayAsync(TimeSpan msDelay, TimeSpan msRepeat, CancellationToken ct, Action action)
        {
            //Console.WriteLine("{0}: Launching with {1} delay", DateTime.Now, msDelay);
            //Console.WriteLine("{0}: Repeating every {1}", DateTime.Now, msRepeat);

            var t = Task.Delay(msDelay, ct);
            var continuationAction = t.ContinueWith(antecedent => action());
            await Task.WhenAll(t, continuationAction);

            while (true)
            {
                t = Task.Delay(msRepeat, ct);
                continuationAction = t.ContinueWith(antecedent => action());
                await Task.WhenAll(t, continuationAction);
            }
        }

    }

}
