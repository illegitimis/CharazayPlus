
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
    //season30.W1.D1 (2014/04/04)
    static readonly DateTime s_start30 = new DateTime(2014, 4, 4);
    //W1.D1 (01/08): LH calculated, fatigue reset, fan club mood reset. 
    //Candidates to be the National Team coaches can set their candidature.
    static readonly DateTime s_start31 = new DateTime(2014, 8, 1);
    // 
    static readonly DateTime s_start32 = new DateTime(2014, 11, 28);
    //W1.D1 (27/03): LH calculated, fatigue reset, fan club mood reset. Candidates to be the National Team coaches can set their candidature.
    static readonly DateTime s_start33 = new DateTime(2015, 03, 27);
    //
    // season is 17 weeks = 119 days
    //
    static readonly int daysInSeason = 119;

    public static implicit operator CharazayDate(DateTime dt)
    {
      CharazayDate cd = new CharazayDate();
      TimeSpan x = new TimeSpan();
      //
      if (dt < s_start28)
        cd._season = 0;
      else if (dt < s_start29)
      {
        cd._season = 28;
        x = dt - s_start28;        
      }
      else if (dt < s_start30)
      {
        cd._season = 29;
        x = dt - s_start29;
      }
      else if (dt < s_start31)
      {
        cd._season = 30;
        x = dt - s_start30;
      }
      else if (dt < s_start32)
      {
        cd._season = 31;
        x = dt - s_start31;
      }
      else
      { //
        // seasons should be well alligned from now on
        //
        int noSeasons = (int) ((dt - s_start32).TotalDays) / daysInSeason;
        cd._season = (byte)(32 + noSeasons);
        DateTime seasonStart = s_start32 + TimeSpan.FromDays(daysInSeason * noSeasons);
        x = dt - seasonStart;
      }
      //
      cd._day = (byte)(1 + x.Days % 7);
      cd._week = (byte)(1 + x.Days / 7);
      //
      return cd;
    }

    public static CharazayDate Parse (string s)
    {
      //S25 W4 D5
      var tokens = s.Split(new char[] { ' ', 'S', 'W', 'D' }, StringSplitOptions.RemoveEmptyEntries);
      return new CharazayDate() { _season = byte.Parse(tokens[0]), _week = byte.Parse(tokens[1]), _day = byte.Parse(tokens[2]) };
    }
  }
}
