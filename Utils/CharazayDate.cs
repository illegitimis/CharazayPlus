
namespace AndreiPopescu.CharazayPlus.Utils
{
  using System;
  using System.Collections.Generic;
  using System.Text;
  using System.Diagnostics;

  /// <summary>
  /// class that manages the Charazay game date,
  /// giving season, week and day of week information
  /// like the one found in the Charazay website toolbox div
  /// </summary>
  [DebuggerDisplay("S{_season} W{_week} D{_day}")]
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

    #region runtime defines

    static readonly CharazaySeason season23 = new CharazaySeason(new DateTime(2011, 12, 16), 23);
    static readonly CharazaySeason season24 = new CharazaySeason(new DateTime(2012,  4, 13), 24);
    static readonly CharazaySeason season25 = new CharazaySeason(new DateTime(2012,  8, 10), 25);
    static readonly CharazaySeason season26 = new CharazaySeason(new DateTime(2012, 12, 7 ), 26);
    static readonly CharazaySeason season27 = new CharazaySeason(new DateTime(2013,  4, 5 ), 27);

    /// <summary>
    /// august 9th, first friday, season start
    /// </summary>
     static readonly CharazaySeason season28 = new CharazaySeason(new DateTime(2013,  8, 9), 28, new DateTime(2013, 12, 5));

    //W1.D1 (06/12)
     static readonly CharazaySeason season29 = new CharazaySeason(new DateTime(2013, 12, 6),29);

    //season30.W1.D1 (2014/04/04)
    static readonly CharazaySeason season30 = new CharazaySeason(new DateTime(2014, 4, 4), 30);

    //W1.D1 (01/08): LH calculated, fatigue reset, fan club mood reset. 
    //Candidates to be the National Team coaches can set their candidature.
     static readonly CharazaySeason season31 = new CharazaySeason(new DateTime(2014, 8, 1), 31);

    // 
     static readonly CharazaySeason season32 = new CharazaySeason(new DateTime(2014, 11, 28),32);

    //W1.D1 (27/03): LH calculated, fatigue reset, fan club mood reset. Candidates to be the National Team coaches can set their candidature.
    //S33.W17.D7 (23/07): Players ageing. Last day to choose your sponsor for next season
     static readonly CharazaySeason season33 = new CharazaySeason(new DateTime(2015, 03, 27),33,new DateTime(2015, 07, 23));
     
     static readonly CharazaySeason season34 = new CharazaySeason(new DateTime(2015, 07, 24), 34, new DateTime(2015,11,20));

     static readonly DateTime S35W16D1 = new DateTime(2016, 3, 11);

    //S35 W17 D7
     static readonly DateTime S35W17D17 = new DateTime(2016, 3, 24);

    //S36.W1.D1 (25/03)
     static readonly CharazaySeason season36 = new CharazaySeason(new DateTime(2016, 03, 25), 36);

    #endregion

     internal static readonly LinkedList<CharazaySeason> Seasons = 
       new LinkedList<CharazaySeason>(new[] { season23, season24, season25, season26, season27, season28, season29, season30, season31, season32, season33, season34 });

     static readonly IDictionary<DateTime, CharazayDate> DatesCache = new Dictionary<DateTime, CharazayDate>();
    
    public static implicit operator CharazayDate(DateTime dt)
    {
      DateTime marker = new DateTime(dt.Year, dt.Month, dt.Day);
      if (!DatesCache.ContainsKey(marker))
      {
        var cd = ConvertDateTimeToCharazayDate(dt);
        DatesCache.Add(marker, cd);
        return cd;
      }
      else
      {
        return DatesCache[marker];
      }
      
    }

    static CharazayDate ConvertDateTimeToCharazayDate (DateTime dt)
    {
      CharazayDate cd = new CharazayDate();
      TimeSpan x = new TimeSpan();

      // before 23
      if (dt < season23.StartDate)
      {
        cd._season = 0;
        cd._day = 0;
        cd._week = 0;
      }

      // 32 AND UP to season 35 crash
      else if (dt > season32.StartDate && dt < S35W16D1)
      {
        int noSeasons = (int)((dt - season32.StartDate).TotalDays) / Defines.DaysInSeason;
        cd._season = (byte)(32 + noSeasons);
        DateTime seasonStart = season32.StartDate + TimeSpan.FromDays(Defines.DaysInSeason * noSeasons);
        x = dt - seasonStart;
        //
        cd._day = (byte)(1 + x.Days % 7);
        cd._week = (byte)(1 + x.Days / 7);
      }

      // with the exception of fucking S35 crash
      else if (dt >= S35W16D1 && dt < season36.StartDate)
      {
        cd._season = 35;
        x = dt - S35W16D1;
        //
        cd._day = (byte)(1 + x.Days % 7);
        cd._week = (byte)(16 + x.Days / 7);
      }

      // HOPING seasons should be well alligned from now on (s36+)
      else if (dt >= season36.StartDate)
      {
        int noSeasons = (int)((dt - season36.StartDate).TotalDays) / Defines.DaysInSeason;
        cd._season = (byte)(36 + noSeasons);
        DateTime seasonStart = season36.StartDate + TimeSpan.FromDays(Defines.DaysInSeason * noSeasons);
        x = dt - seasonStart;
        //
        cd._day = (byte)(1 + x.Days % 7);
        cd._week = (byte)(1 + x.Days / 7);
      }


      //[23-32]
      else
      {
        var enumSeasons = Seasons.GetEnumerator();
        while (enumSeasons.MoveNext())
        {
          if (dt > enumSeasons.Current.StartDate)
          {
            cd._season = enumSeasons.Current.Number;
            x = dt - enumSeasons.Current.StartDate;
            //
            cd._day = (byte)(1 + x.Days % 7);
            cd._week = (byte)(1 + x.Days / 7);
            //
            break;
          }
          else
            continue;
        }
      }

      //
      return cd;
    }

    public static CharazayDate Parse (string s)
    {
      //S25 W4 D5
      var tokens = s.Split(new char[] { ' ', 'S', 'W', 'D' }, StringSplitOptions.RemoveEmptyEntries);
      return new CharazayDate() { _season = byte.Parse(tokens[0]), _week = byte.Parse(tokens[1]), _day = byte.Parse(tokens[2]) };
    }

    /// <summary>
    /// on last day of the season players age
    /// their value index is computed as if they aged, yet season remains current
    /// fixes <see cref="Player.TrainingWeekIndex"/> issue 
    /// </summary>
    public bool IsLastSeasonDay { get { return Day == Defines.DaysInWeek && Week == Defines.WeeksInSeason; } }
  }

  public class ServerTimeInfo
  {
    public ServerTimeInfo (DateTime local, DateTime charazay) { CharazayDate = charazay; LocalDate = local; }
    public DateTime CharazayDate { get; private set; }
    public DateTime LocalDate { get; private set; }
    public TimeSpan Offset { get { return LocalDate - CharazayDate; } }
  }

  public class CharazaySeason
  {
    public CharazaySeason (DateTime s, byte no, DateTime? e=null) { StartDate = s; Number = no; EndDate=e;}
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public byte Number { get; private set; }



  }

}
