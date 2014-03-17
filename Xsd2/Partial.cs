/*
 * additional properties needed for serialized files
 */
namespace AndreiPopescu.CharazayPlus.Xsd2
{
  using AndreiPopescu.CharazayPlus.Utils;
  using BrightIdeasSoftware;

  /// <summary>
  /// match 
  /// </summary>
  public partial class match
  {
    public string HomeTeamName { get { return teams.hometeamname; } }
    public string AwayTeamName { get { return teams.awayteamname; } }

    public uint HomeTeamId { get { return teams.hometeam; } }
    public uint AwayTeamId { get { return teams.awayteam; } }

    public string MatchType
    {
      get { return System.Enum.GetName(typeof(MatchType), (MatchType)typeField); }
    }

    public bool Played { get { return playedField == "yes"; } }

    public System.DateTime Date_ { get { return Compute.EstimatedDateTime(dateField); } }

    [System.Xml.Serialization.XmlIgnore]
    public uint MyTeamId { private get; set; }

    public bool Won { get { return (homescore > awayscore && HomeTeamId == MyTeamId) || (homescore < awayscore && AwayTeamId == MyTeamId); } }

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
    public System.DateTime Date { get { return Compute.EstimatedDateTime(dateField); } }
    public string Seller { get { return CacheManager.Instance.TeamName(sellteam); } }
    public string Buyer { get { return CacheManager.Instance.TeamName(buyteam); } }
    public string Player { get { return CacheManager.Instance.PlayerName(playerid); } }

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
        ushort.TryParse(this.teamidField, out result);
        return result;
      }
    }
  }

  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class charazay { }

  public partial class income
  {
    public uint Total { get { return sponsor + tickets + sales + other + merchandise; } }
  }

  public partial class expences { public uint Total { get { return salary + staff + buys + other + maintenance + facility; } } }

  public partial class charazayDivisionStanding
  {
    [OLVColumn(DisplayIndex = 8, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Title = "Games Played")]
    public byte GamesPlayed { get { return this.playedField; } }
    
    [OLVColumn(DisplayIndex = 4, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Title = "#Wins")]
    public byte Wins { get
      {
        return this.winsField;
      }
    }

    [OLVColumn(DisplayIndex = 5, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Title = "#Losses")]
    public byte Losses
    {
      get
      {
        return this.lossField;
      }
    }

   [OLVColumn(DisplayIndex = 1, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Title = "Position")]
    public byte Position
    {
      get
      {
        return this.positionField;
      }     
    }        

   [OLVColumn(DisplayIndex = 2, IsEditable = false, Width = 120, MinimumWidth = 80, MaximumWidth = 225, Title = "Name")]
    public string Name { get { return this.nameField; } }

   [OLVColumn(DisplayIndex = 6, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Title = "Points Made")]
   public ushort PointsMade { get { return this.points_madeField; } }

   [OLVColumn(DisplayIndex = 7, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Title = "Points Against")]
   public ushort PointsAgainst { get { return this.points_againstField; } }

   [OLVColumn(DisplayIndex = 3, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Title = "Points")]
   public byte Points
   {
     get
     {
       return this.pointsField;
     }
   }

   [OLVColumn(DisplayIndex = 11, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Title = "+/-")]
   public short PlusMinus { get { return (short)(PointsMade - PointsAgainst); } }

   [OLVColumn(DisplayIndex = 9, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Title = "TeamID")]
   public uint TeamID
   {
     get
     {
       return this.teamidField;
     }
   }


    [OLVColumn(DisplayIndex = 10, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Title = "Owner")]
    public uint Owner
    {
      get
      {
        return this.ownerField;
      }
    }
  }

}