
namespace AndreiPopescu.CharazayPlus.Utils
{
  using System;
  using System.Collections.Generic;
  using System.Text;

  /// <summary>
  /// class that manages the Charazay game date,
  /// giving season, week and day of week information
  /// like the one found in the Charazay website toolbox div
  /// </summary>
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
    //W1.D1 (06/12)
    static readonly DateTime s_start29 = new DateTime(2013, 12, 6);

    public static implicit operator CharazayDate(DateTime dt)
    {
      CharazayDate cd = new CharazayDate();
      if (dt < s_start28)
        cd._season = 0;
      else if (dt < s_start29)
      {
        cd._season = 28;
        var x = dt - s_start28;
        cd._day = (byte)(1 + x.Days % 7);
        cd._week = (byte)(1+ x.Days / 7);
      }
      else
      {
        cd._season = 29;
        var x = dt - s_start29;
        cd._day = (byte)(1 + x.Days % 7);
        cd._week = (byte)(1 + x.Days / 7);
      }
      return cd;
    }
  }
}
