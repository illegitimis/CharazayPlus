/*
 * additional properties needed for serialized files
 */
namespace AndreiPopescu.CharazayPlus.Xsd2
{
  using AndreiPopescu.CharazayPlus.Utils;

  /// <summary>
  /// match 
  /// </summary>
  public partial class match
  {
    public string HomeTeamName { get { return teams.hometeamname; } }
    public string AwayTeamName { get { return teams.awayteamname; } }

    public ushort HomeTeamId { get { return teams.hometeam; } }
    public ushort AwayTeamId { get { return teams.awayteam; } }

    public string MatchType 
    { 
      get { return System.Enum.GetName ( typeof(MatchType) , (MatchType)typeField); } 
    }

    public bool Played { get { return playedField == "yes"; } }

    public System.DateTime Date_ { get { return Compute.EstimatedDateTime(dateField); } }

    [System.Xml.Serialization.XmlIgnore]    
    public ushort MyTeamId { private get; set; }

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
        ushort.TryParse( this.teamidField, out result);
        return result;
      }      
    }
  }

}