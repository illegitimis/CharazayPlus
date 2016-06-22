

namespace AndreiPopescu.CharazayPlus.Interpolate
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;

  public static class SimpleStats
  {
    //the square root of the average value of (X − μ)2.
    public static double Variance (this IEnumerable<double> x)
    {
      if (x == null)
        throw new ArgumentNullException();

      switch (x.Count())
      {
        case 0: return 0;
        case 1: return 0;
        default:
          double meanX = x.Average();
          var temp = x.Select(a => a - meanX);
          var sumSquares = temp.DotProduct(temp);
          return sumSquares / x.Count();
      }
    }

    public static double StandardDeviation(this IEnumerable<double> x)
     {
       return Math.Sqrt(x.Variance());
     }

     /// <summary>
   /// dot vector product
   /// </summary>
   /// <param name="a">input</param>
   /// <param name="b">input</param>
   /// <returns>dot product of 2 inputs</returns>
   public static double DotProduct(this IEnumerable<double> a, IEnumerable<double> b)
   {
       return a.Zip(b, (d1, d2) => d1 * d2).Sum();
   }
  }
}
