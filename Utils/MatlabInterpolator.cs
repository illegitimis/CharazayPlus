

namespace AndreiPopescu.CharazayPlus.Utils
{
  using System;

  internal abstract class MatlabInterpolator : IInterpolate
  {
    public double GetTMValue (byte age, char pos, double x)
    {
      double[,] data = GetPositionData(pos);
      //
      double dage = Math.Min(35d, (double)age);
      dage = Math.Max(15d, dage);
      //
      for (int i = 0; i < 21; i++)
      {
        if (data[i, 0] == dage)
        {
          return data[i, 1] * Math.Exp(data[i, 2] * x);
        }
      }
      return double.NaN;
    }

    public void GetAB (byte age, char pos, out double a, out double b)
    {
      double[,] data = GetPositionData(pos);
      a = b = Double.NaN;
      //
      double dage = Math.Min(35d, (double)age);
      dage = Math.Max(15d, dage);
      //
      for (int i = 0; i < 21; i++)
      {
        if (data[i, 0] == dage)
        {
          a = data[i, 1];
          b = data[i, 2];
          return;
        }
      }
    }

    public abstract double[,] GetPositionData (char pos);
  }
}
