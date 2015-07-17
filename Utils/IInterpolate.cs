

namespace AndreiPopescu.CharazayPlus.Utils
{
  using System;

  /// <summary>
  /// exposes a base interface for transfer data interpolation
  /// </summary>
  internal interface IInterpolate
  {
    /// <summary>
    /// Returns the transfer market value 
    /// </summary>
    /// <param name="age">player age</param>
    /// <param name="pos">court position</param>
    /// <param name="x">value index</param>
    /// <returns>double value representing interpolated transfer market value</returns>
    double GetTMValue (byte age, char pos, double x);

    /// <summary>
    /// Gets parameters for an exponential fit
    /// </summary>
    /// <param name="age">player age</param>
    /// <param name="pos">court position</param>
    /// <param name="a">exponential base</param>
    /// <param name="b">exponent (lambda)</param>
    void GetAB (byte age, char pos, out double a, out double b);

    /// <summary>
    /// Gets input data values for specified position
    /// </summary>
    /// <param name="pos">court position</param>
    /// <returns>Court specific transfer data</returns>
    double[,] GetPositionData (char pos);
  }

  
}
