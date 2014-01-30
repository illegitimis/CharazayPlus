/*
 * additional properties needed for serialized files
 */

namespace AndreiPopescu.CharazayPlus.XsdMerge
{
  using System.Collections.Generic;
  using AndreiPopescu.CharazayPlus.Utils;

  /// <summary>
  /// match 
  /// </summary>
  /*
  public partial class match
  {
      //[System.Xml.Serialization.XmlElementAttribute("bballs", typeof(bballs))]
      //[System.Xml.Serialization.XmlElementAttribute("lineup", typeof(lineup))]
      //[System.Xml.Serialization.XmlElementAttribute("stats", typeof(stats))]
      //[System.Xml.Serialization.XmlElementAttribute("teams", typeof(teams))]
      T OfType<T>() where T : class
      {
          foreach (var item in this.Items)
          {
              if (item is T)
                  return (T)item;
          }
          return default(T);
      }
      
      teams teams { get {
          if (Items != null)
          {
              var t = this.OfType<teams>();
              return t;   
          }
          return null;
      } }
      public string AwayTeamName { get { return teams == null ? string.Empty : teams.awayteamname; } }
      public string HomeTeamName { get { return teams == null ? string.Empty : teams.hometeamname; } }

      public uint HomeTeamId { get { return teams == null ? (ushort)0 : teams.hometeam; } }
      public uint AwayTeamId { get { return teams == null ? (ushort)0 : teams.awayteam; } }

      stats stats
      {
          get
          {
              if (Items != null)
              {
                  var t = this.OfType<stats>();
                  return t;
              }
              return null;
          }
      }
      public IEnumerable<rating> HomeRatings { get { return stats == null ? null : stats.home.Ratings; } }
      public IEnumerable<rating> AwayRatings { get { return stats == null ? null : stats.away.Ratings; } }

      bballs bballs
      {
          get
          {
              if (Items != null)
              {
                  var t = this.OfType<bballs>();
                  return t;
              }
              return null;
          }
      }
      public IEnumerable<bball> HomeBb { get { return bballs == null ? null : bballs.home.Bballs; } }
      public IEnumerable<bball> AwayBb { get { return bballs == null ? null : bballs.away.Bballs; } }

     public lineup Lineup
      {
          get
          {
              if (Items != null)
              {
                  var t = this.OfType<lineup>();
                  return t;
              }
              return null;
          }
      }

     

    public string MatchType 
    { 
      get { return System.Enum.GetName ( typeof(MatchType), (MatchType)typeField); } 
    }

    public bool Played { get { return playedField == "yes"; } }

    public System.DateTime Date_ { get { return Compute.EstimatedDateTime(dateField); } }

    public ushort MyTeamId { private get; set; }

    public bool Won { get { return (homescore > awayscore && HomeTeamId == MyTeamId) || (homescore < awayscore && AwayTeamId == MyTeamId); } }
  }
    */

  /// <summary>
  /// transfer
  /// </summary>
  public partial class transfer
  {
    public System.DateTime Date { get { return Compute.EstimatedDateTime(dateField); } }
    public string Seller { get { return CacheManager.Instance.TeamName(sellteam); } }
    public string Buyer { get { return CacheManager.Instance.TeamName(buyteam); } }
    public string Player { get { return CacheManager.Instance.PlayerName(playerid); } }

  }

  public partial class home
  {
      object Get(string name)
      {
        foreach (var item in this.Items)      
        {
            if (item.GetType().Name == name)
                return item;
        }
        return null;
      }

      public first first { get { return (first)Get("first");} }
      public second second { get { return (second)Get("second"); } }
      public third third { get { return (third)Get("third"); } }
      public forth forth { get { return (forth)Get("forth"); } }

      IEnumerable<T> OfType<T>() where T : class
      {
          foreach (var item in Items)
          {
              if (item is T)
                  yield return item as T;
          }          
      }

      public IEnumerable<rating> Ratings { get { return OfType<rating>(); } }
      public IEnumerable<bball> Bballs { get { return OfType<bball>(); } }
  }

  public partial class away
  {
      object Get(string name)
      {
          foreach (var item in this.Items)
          {
              if (item.GetType().Name == name)
                  return item;
          }
          return null;
      }

      public first first { get { return (first)Get("first"); } }
      public second second { get { return (second)Get("second"); } }
      public third third { get { return (third)Get("third"); } }
      public forth forth { get { return (forth)Get("forth"); } }

      IEnumerable<T> OfType<T>() where T : class
      {
          foreach (var item in Items)
          {
              if (item is T)
                  yield return item as T;
          }
      }

      public IEnumerable<rating> Ratings { get { return OfType<rating>(); } }
      public IEnumerable<bball> Bballs { get { return OfType<bball>(); } }
  }

  public partial class charazay
  {
      public T Get<T>() where T : class
      {
          foreach (var item in Items)
          {
              if (item is T)
                  return item as T;
          }
          return default(T);
      }

      public matches matches { get { return this.Get<matches>(); } }

      public division division { get { return this.Get<division>(); } }

      public schedule schedule { get { return this.Get<schedule>(); } }

      public match match { get { return this.Get<match>(); } }

      public team_transfers Transfers { get { return this.Get<team_transfers>(); } }

      public economy economy { get { return this.Get<economy>(); } }

      public player player { get { return this.Get<player>(); } }
      
      public user user { get { return this.Get<user>(); } }

      public team team { get { return this.Get<team>(); } }

      public arena arena { get { return this.Get<arena>(); } }

      public coaches coaches { get { return this.Get<coaches>(); } }

      public country Country { get { return this.Get<country>(); } }

      public players Players { get { return this.Get<players>(); } }
  }

  public partial class expences
  {
      public uint Total { get { return this.buys + this.facility + this.maintenance + this.other + this.salary + this.staff; } }      
  }

  public partial class income
  {
      public uint Total { get { return this.merchandise + this.other+ this.sales+ this.sponsor+ this.tickets; } }
  }
}