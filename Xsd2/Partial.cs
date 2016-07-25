/*
 * additional properties needed for serialized files
 */

namespace AndreiPopescu.CharazayPlus.Xsd2
{
  using AndreiPopescu.CharazayPlus.Utils;
  using BrightIdeasSoftware;
  using System;
  using System.ComponentModel;
  using System.Xml;
  using System.CodeDom.Compiler;
  using System.Diagnostics;
  using System.Xml.Serialization;

  /// <summary>
  /// match 
  /// </summary>
  public partial class match
  {
    [OLVColumn(DisplayIndex = 0, IsEditable = false, Width = 75, MinimumWidth = 60, MaximumWidth = 90, Title = "Id", Hyperlink = true)]
    public uint Id { get { return this.id; } }

    public uint HomeTeamId { get { return teams.hometeam; } }
    [OLVColumn(DisplayIndex = 1, IsEditable = false, Width = 130, MinimumWidth = 80, MaximumWidth = 180, Title = "Home", Hyperlink = true)]
    public string HomeTeamName { get { return XmlConvert.DecodeName(teams.hometeamname); } }

    [OLVColumn(DisplayIndex = 2, IsEditable = false, Width = 50, MinimumWidth = 40, MaximumWidth = 60, Title = "", Hyperlink = false)]
    public byte HomeTeamScore { get { return this.homescore; } }

    [OLVColumn(DisplayIndex = 3, IsEditable = false, Width = 50, MinimumWidth = 40, MaximumWidth = 60, Title = "", Hyperlink = false)]
    public byte AwayTeamScore { get { return this.awayscore; } }

    public uint AwayTeamId { get { return teams.awayteam; } }
    [OLVColumn(DisplayIndex = 4, IsEditable = false, Width = 130, MinimumWidth = 80, MaximumWidth = 180, Title = "Away", Hyperlink = true)]
    public string AwayTeamName { get { return XmlConvert.DecodeName(teams.awayteamname); } }

    [OLVColumn(DisplayIndex = 5, IsEditable = false, Width = 85, MinimumWidth = 65, MaximumWidth = 105, Title = "Type")]
    public MatchType MatchType { get { return (MatchType)type; } }

    [OLVColumn(DisplayIndex = 6, IsEditable = false, Width = 30, MinimumWidth = 20, MaximumWidth = 40, Title = "Played", CheckBoxes = true)]
    public bool Played { get { return played == "yes"; } }

    [System.Xml.Serialization.XmlIgnore]
    public uint MyTeamId { private get; set; }

    [OLVColumn(DisplayIndex = 7, IsEditable = false, Width = 30, MinimumWidth = 20, MaximumWidth = 40, Title = "Won", CheckBoxes = true)]
    public bool Won { get { return Played && ((homescore > awayscore && HomeTeamId == MyTeamId) || (homescore < awayscore && AwayTeamId == MyTeamId)); } }

    [OLVColumn(DisplayIndex = 8, IsEditable = false, Width = 95, MinimumWidth = 60, MaximumWidth = 125, Title = "Deadline")]
    public System.DateTime Date_ { get { return Compute.EstimatedDateTime(date); } }

    CharazayDate CharazayDate { get { return Date_; } }

    [OLVColumn(DisplayIndex = 9, IsEditable = false, Width = 35, MinimumWidth = 20, MaximumWidth = 40, Title = "Season")]
    public byte Season { get { return this.CharazayDate.Season; } }

    [OLVColumn(DisplayIndex = 10, IsEditable = false, Width = 35, MinimumWidth = 20, MaximumWidth = 40, Title = "Week")]
    public byte Week { get { return this.CharazayDate.Week; } }

    [OLVColumn(DisplayIndex = 11, IsEditable = false, Width = 35, MinimumWidth = 20, MaximumWidth = 40, Title = "Round")]
    public byte Round { get { return this.round; } }

    [OLVColumn(DisplayIndex = 12, IsEditable = false, Width = 35, MinimumWidth = 20, MaximumWidth = 40, Title = "+/-")]
    public int PlusMinus
    {
      get
      {
        if (Played)
        {
          if (HomeTeamId == MyTeamId)
            return homescore - awayscore;
          else if (AwayTeamId == MyTeamId)
            return awayscore - homescore;
          else return 0;
        }
        else
          return 0;
      }
    }

    public override string ToString ( )
    {
      return string.Format("{0} {1} - {2} {3}", HomeTeamName, this.homescore, this.awayscore, AwayTeamName);
    }
  }

  /// <summary>
  /// transfer
  /// </summary>
  public partial class charazayTransfer
  {
    [OLVColumn(DisplayIndex = 0, IsEditable = false, Width = 105, MinimumWidth = 80, MaximumWidth = 140, Title = "Seller", Hyperlink = true)]
    public string Seller { get { return CacheManager.Instance.TeamName(sellteam); } }
    [OLVColumn(DisplayIndex = 1, IsEditable = false, Width = 105, MinimumWidth = 80, MaximumWidth = 140, Title = "Buyer", Hyperlink = true)]
    public string Buyer { get { return CacheManager.Instance.TeamName(buyteam); } }
    [OLVColumn(DisplayIndex = 2, IsEditable = false, Width = 80, MinimumWidth = 70, MaximumWidth = 100, Title = "Deadline", AspectToStringFormat = "{0:yyyy-MM-dd}")]
    public System.DateTime Date { get { return Compute.EstimatedDateTime(date); } }
    [OLVColumn(DisplayIndex = 3, IsEditable = false, Width = 120, MinimumWidth = 90, MaximumWidth = 160, Title = "Player", Hyperlink = true)]
    public string Player { get { return CacheManager.Instance.PlayerName(playerid); } }
    [OLVColumn(DisplayIndex = 4, IsEditable = false, Width = 80, MinimumWidth = 70, MaximumWidth = 100, Title = "StartingPrice", AspectToStringFormat = "{0:N0}")]
    public uint Price { get { return this.price; } }
    [OLVColumn(DisplayIndex = 5, IsEditable = false, Width = 80, MinimumWidth = 70, MaximumWidth = 100, Title = "Skills Index", AspectToStringFormat = "{0:N0}")]
    public uint SkillsIndex { get { return this.si; } }
  }

  public partial class charazayRoundMatch
  {
    public override string ToString ( )
    {
      return CacheManager.Instance.MatchName(this.id);
    }
  }

  public partial class charazayPlayer
  {
    public ushort Teamid
    {
      get
      {
        ushort result = 0;
        ushort.TryParse(this.teamid, out result);
        return result;
      }
    }
  }

  [GeneratedCode("xsd", "4.0.30319.1")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public partial class charazay { }

  public partial class income
  {
    public uint Total { get { return sponsor + tickets + sales + other + merchandise; } }
    public float TotalMillions { get { return Total / 1000000f; } }
  }

  public partial class expences
  {
    public uint Total { get { return salary + staff + buys + other + maintenance + facility; } }
    public float TotalMillions { get { return Total / 1000000f; } }
  }

  public partial class charazayDivisionStanding
  {
    [OLVColumn(DisplayIndex = 8, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Title = "Games Played")]
    public byte GamesPlayed { get { return this.played; } }

    [OLVColumn(DisplayIndex = 4, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Title = "#Wins")]
    public byte Wins
    {
      get
      {
        return this.wins;
      }
    }

    [OLVColumn(DisplayIndex = 5, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Title = "#Losses")]
    public byte Losses
    {
      get
      {
        return this.loss;
      }
    }

    [OLVColumn(DisplayIndex = 1, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Title = "Position")]
    public byte Position
    {
      get
      {
        return this.position;
      }
    }

    [OLVColumn(DisplayIndex = 2, IsEditable = false, Width = 160, MinimumWidth = 100, MaximumWidth = 225, Title = "Name")]
    public string Name { get { return System.Net.WebUtility.HtmlDecode(this.name); } }

    [OLVColumn(DisplayIndex = 6, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Title = "Points Made")]
    public ushort PointsMade { get { return this.points_made; } }

    [OLVColumn(DisplayIndex = 7, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Title = "Points Against")]
    public ushort PointsAgainst { get { return this.points_against; } }

    [OLVColumn(DisplayIndex = 3, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Title = "Points")]
    public byte Points
    {
      get
      {
        return this.points;
      }
    }

    [OLVColumn(DisplayIndex = 11, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Title = "+/-")]
    public short PlusMinus { get { return (short)(PointsMade - PointsAgainst); } }

    [OLVColumn(DisplayIndex = 9, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Title = "TeamID")]
    public uint TeamID
    {
      get
      {
        return this.teamid;
      }
    }


    [OLVColumn(DisplayIndex = 10, IsEditable = false, Width = 85, MinimumWidth = 60, MaximumWidth = 100, Title = "Owner")]
    public uint Owner
    {
      get
      {
        return this.owner;
      }
    }
  }

}


namespace AndreiPopescu.CharazayPlus.Model
{
  using System;
  using System.Linq;
  using System.Collections.Generic;
  using AndreiPopescu.CharazayPlus.Utils;
  using API = AndreiPopescu.CharazayPlus.Xsd2.charazay;
  using ApiPlayer = AndreiPopescu.CharazayPlus.Xsd2.charazayPlayer;

  public partial class PlayerDevelopment
  {
    //List<Tuple<DateTime,byte>> ByteValues(ST_VALUE_TYPE valueType)
    //{
    //  this.v.Where(x => x.t == valueType).Select(x => new Tuple<DateTime, byte>(x.When,x.ByteValue.HasValue ? x.ByteValue.Value : Byte.MaxValue)).ToList();
    //}
    public void DecorateFromPlayer (string sdate, ApiPlayer p)
    {
      this.ItemValues.Add(new CT_VALUE_AT_DATE() { Type = ST_VALUE_TYPE.age, DateString = sdate, Value = p.basic.age.ToString() });
      //
      this.ItemValues.Add(new CT_VALUE_AT_DATE() { Type = ST_VALUE_TYPE.def, DateString = sdate, Value = p.skills.defence.ToString() });
      this.ItemValues.Add(new CT_VALUE_AT_DATE() { Type = ST_VALUE_TYPE.dri, DateString = sdate, Value = p.skills.dribling.ToString() });
      this.ItemValues.Add(new CT_VALUE_AT_DATE() { Type = ST_VALUE_TYPE.exp, DateString = sdate, Value = p.skills.experience.ToString() });
      this.ItemValues.Add(new CT_VALUE_AT_DATE() { Type = ST_VALUE_TYPE.fame, DateString = sdate, Value = p.status.fame.ToString() });

      this.ItemValues.Add(new CT_VALUE_AT_DATE() { Type = ST_VALUE_TYPE.fatg, DateString = sdate, Value = p.status.fatigue.ToString() });

      this.ItemValues.Add(new CT_VALUE_AT_DATE() { Type = ST_VALUE_TYPE.form, DateString = sdate, Value = p.status.form.ToString() });
      this.ItemValues.Add(new CT_VALUE_AT_DATE() { Type = ST_VALUE_TYPE.ftw, DateString = sdate, Value = p.skills.footwork.ToString() });
      this.ItemValues.Add(new CT_VALUE_AT_DATE() { Type = ST_VALUE_TYPE.h, DateString = sdate, Value = p.basic.height.ToString() });

      this.ItemValues.Add(new CT_VALUE_AT_DATE() { Type = ST_VALUE_TYPE.w, DateString = sdate, Value = p.basic.weight.ToString() });

      this.ItemValues.Add(new CT_VALUE_AT_DATE() { Type = ST_VALUE_TYPE.inj, DateString = sdate, Value = p.status.injured.ToString() });
      this.ItemValues.Add(new CT_VALUE_AT_DATE() { Type = ST_VALUE_TYPE.p1, DateString = sdate, Value = p.skills.freethrow.ToString() });
      this.ItemValues.Add(new CT_VALUE_AT_DATE() { Type = ST_VALUE_TYPE.p2, DateString = sdate, Value = p.skills.twopoint.ToString() });
      this.ItemValues.Add(new CT_VALUE_AT_DATE() { Type = ST_VALUE_TYPE.p3, DateString = sdate, Value = p.skills.threepoint.ToString() });
      this.ItemValues.Add(new CT_VALUE_AT_DATE() { Type = ST_VALUE_TYPE.pas, DateString = sdate, Value = p.skills.passing.ToString() });
      this.ItemValues.Add(new CT_VALUE_AT_DATE() { Type = ST_VALUE_TYPE.reb, DateString = sdate, Value = p.skills.rebounds.ToString() });

      this.ItemValues.Add(new CT_VALUE_AT_DATE() { Type = ST_VALUE_TYPE.sal, DateString = sdate, Value = p.status.salary.ToString() });

      this.ItemValues.Add(new CT_VALUE_AT_DATE() { Type = ST_VALUE_TYPE.si, DateString = sdate, Value = p.status.si.ToString() });

      this.ItemValues.Add(new CT_VALUE_AT_DATE() { Type = ST_VALUE_TYPE.spe, DateString = sdate, Value = p.skills.speed.ToString() });
    }

    public override string ToString ( )
    {
      return String.Format("{0} {1} {2}", name, surname, id);
    }

    public string FullName    { get {return String.Format("{0} {1}", name, surname); } }
  }

  public partial class CT_VALUE_AT_DATE
  {
    public DateTime When
    {
      get
      {
        return new DateTime(
          2000 + int.Parse(
            DateString.Substring(0, 2)),
            int.Parse(DateString.Substring(2, 2)),
            int.Parse(DateString.Substring(4, 2))
        );
      }
    }

    public byte? ByteValue
    {
      get
      {
        byte result;
        if (Byte.TryParse(Value, out result)) return result; else return null;
        ;
      }
    }

    public int? IntValue
    {
      get
      {
        int result;
        if (Int32.TryParse(Value, out result)) return result; else return null;
        ;
      }
    }

    public double? DoubleValue
    {
      get
      {
        double result;
        if (Double.TryParse(Value, out result)) return result; else return null;
        ;
      }
    }

    public double GenericValue
    {
      get
      {
        switch (Type)
        {
          //byte
          case ST_VALUE_TYPE.age:
          case ST_VALUE_TYPE.h:
          case ST_VALUE_TYPE.def:
          case ST_VALUE_TYPE.exp:
          case ST_VALUE_TYPE.p1:
          case ST_VALUE_TYPE.p2:
          case ST_VALUE_TYPE.p3:
          case ST_VALUE_TYPE.dri:
          case ST_VALUE_TYPE.spe:
          case ST_VALUE_TYPE.ftw:
          case ST_VALUE_TYPE.reb:
          case ST_VALUE_TYPE.pas:
          case ST_VALUE_TYPE.inj:
          case ST_VALUE_TYPE.form:
          case ST_VALUE_TYPE.fame:
          default:
            return ByteValue.HasValue ? ByteValue.Value : 0d;

          case ST_VALUE_TYPE.fatg:
          case ST_VALUE_TYPE.si:
          case ST_VALUE_TYPE.sal:
            return IntValue.HasValue ? IntValue.Value : 0d;

            //double
          case ST_VALUE_TYPE.w:
            return DoubleValue.HasValue ? DoubleValue.Value : 0d;
        }

      }
    }
  }
  
  /// <summary>
  /// wrapper for a list of player developments
  /// </summary>
  public partial class Development
  {
    public void DecorateFromPlayers (ApiPlayer[] players, string sdate)
    {
      // set all as inactive
      this.PlayerItems.ForEach(pd => pd.active = false);

      // loop current API players
      foreach (var p in players)
      {
        // development player lookup
        var playerDevelopment = this.PlayerItems.FirstOrDefault(x => x.id == p.id);
        if (playerDevelopment == null)
        {
          playerDevelopment = new PlayerDevelopment()
          {
            id = p.id,
            name = p.basic.name,
            surname = p.basic.surname,
            active = true,
            ItemValues = new List<CT_VALUE_AT_DATE>()
          };
          playerDevelopment.DecorateFromPlayer(sdate, p);
          //
          this.PlayerItems.Add(playerDevelopment);
        }
        else
        {
          playerDevelopment.active = true;
          if (!playerDevelopment.ItemValues.Any(x => x.DateString == sdate))
          {
            playerDevelopment.DecorateFromPlayer(sdate, p);
          }
        }
      }
    }

    public void DecorateFromPlayers (API api, string sdate)
    {
      DecorateFromPlayers(api.players, sdate);
    }

    public IEnumerable<string> GetNames ()
    {
      return this.PlayerItems.Select(p => p.FullName);
    }
  }

}