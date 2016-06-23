/*

namespace CharazayPlus.MSTest
{
    using AndreiPopescu.CharazayPlus.Utils;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    ///This is m test class for TransferMarket112Test and is intended
    ///to contain all TransferMarket112Test Unit Tests
    ///</summary>
    [TestClass()]
    public class TransferMarket112Test
    {
        [TestMethod()]
        public void AllTest()
        {
            char[] pos = new char[] { 'C', 'F', 'G' };
            for (byte age = 15; age <= 35; age++)
            {
                foreach (char c in pos)
                {
                    List<double[]> actual = TransferMarket112.Find(age, c).ToList();

                    LeastSquares.Fit opt = new LeastSquares.ExponentialOptimum(actual);
                    LeastSquares.Fit exp = new LeastSquares.Exponential(actual);
                    LeastSquares.Fit lin = new LeastSquares.Linear(actual);

                    LeastSquares.Fit fit = null;
                    char method = '-';
                    double r2 = 0d;
                    try
                    {
                        if (opt.R2 > r2)
                        {
                            method = 'O'; r2 = opt.R2; fit = opt;
                        }
                    }
                    catch { }
                    try
                    {
                        if (lin.R2 > r2)
                        {
                            method = 'L'; r2 = lin.R2; fit = lin;
                        }
                    }
                    catch { }
                    try
                    {
                        if (exp.R2 > r2)
                        {
                            method = 'E'; r2 = exp.R2; fit = exp;
                        }
                    }
                    catch { }
                    System.Diagnostics.Debug.WriteLine("{0,-5}{1,-5}{2,-5} R2:{3,-7:F02} {4}", age, c, method, r2, fit);
                }
            }



        }

        [TestMethod()]
        public void G35ExpTest()
        {
            List<double[]> actual = TransferMarket112.Find(35, 'G').ToList();

            LeastSquares.Fit opt = new LeastSquares.ExponentialOptimum(actual);
            LeastSquares.Fit exp = new LeastSquares.Exponential(actual);
            LeastSquares.Fit lin = new LeastSquares.Linear(actual);
        }
    }
}

*/