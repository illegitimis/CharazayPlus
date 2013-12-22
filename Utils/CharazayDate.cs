
namespace AndreiPopescu.CharazayPlus.Utils
{
  using System;
  using System.Collections.Generic;
  using System.Text;

  public class CharazayDate
  {
    byte _season;
    public byte Season { get { return _season; } }
    /// <summary>
    /// [1,17]
    /// </summary>
    byte _week;
    public byte Week { get { return _week; } }
    /// <summary>
    /// [1,7]
    /// </summary>
    byte _day;
    public byte Day { get { return _day; } }
    /// <summary>
    /// august 9th, first friday, season start
    /// </summary>
    static readonly DateTime s_start28 = new DateTime(2013, 8, 9);

    public static implicit operator CharazayDate(DateTime dt)
    {
      CharazayDate cd = new CharazayDate();
      if (dt < s_start28)
        cd._season = 0;
      else
      {
        cd._season = 28;
        var x = dt - s_start28;
        cd._day = (byte)(1 + x.Days % 7);
        cd._week = (byte)(1+ x.Days / 7);
      }
      return cd;
    }
  }
}
