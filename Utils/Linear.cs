using System;
using System.Collections.Generic;
using System.Text;

namespace AndreiPopescu.CharazayPlus.Utils
{
  internal static class Linear
  {
    public static double ArraySum (double[] in1)
    {
      if (in1 == null)
        return 0d;

      double sum = 0.0;
      foreach (double d in in1)
        sum += d;
      return sum;
    }

    public static double DotVectorProduct_Normalized (double[] in1, double[] in2)
    {
      double sum1 = ArraySum(in1);
      if (Math.Abs(sum1 - 1.0) > 0.001)
        throw new ArgumentException("Normalized vector 1");
      
      return DotVectorProduct(in1, in2);
    }

    public static double DotVectorProduct (double[] in1, double[] in2)
    {
      if (in1 == null || in2 == null)
        throw new ArgumentNullException("DotVectorProduct");
      if (in1.Length == 0 || in2.Length == 0)
        throw new ArgumentException("DotVectorProduct: 0");
      if (in1.Length != in2.Length)
        throw new ArgumentException("DotVectorProduct: lengths");

      double sum = 0.0;
      for (int i = 0; i < in1.Length; i++)
        sum += in1[i] * in2[i];
      return sum;
    }


#if DOTNET30
    public static System.Collections.IEnumerable Combine(
    this System.Collections.IEnumerable first
    , System.Collections.IEnumerable second
    , Func<double,double,double> func)
    {
      System.Collections.IEnumerator e1 = first.GetEnumerator(), e2 = second.GetEnumerator();

        while (e1.MoveNext() && e2.MoveNext())
        {
          yield return func((double)e1.Current, (double)e2.Current);
        }

    }

    public static double DotVectorProduct_Linq(double[] in1, double[] in2)
    {
      ExceptionsDotVectorProduct(in1, in2);

      //return in1.Combine(in2, (a, b) => a * b).Sum();

      return in1.Combine(in2, (a, b) => a * b).Sum();
    }
#endif


  }
}
