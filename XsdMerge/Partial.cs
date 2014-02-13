/*
 * additional properties needed for serialized files
 */

namespace AndreiPopescu.CharazayPlus.XsdMerge
{
    using System.Collections.Generic;
    using AndreiPopescu.CharazayPlus.Utils;

    /// <summary>
    /// top-level xml object
    /// </summary>
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

        public matches Matches { get { return this.Get<matches>(); } }

        public division Division { get { return this.Get<division>(); } }

        public schedule Schedule { get { return this.Get<schedule>(); } }

        public match Match { get { return this.Get<match>(); } }

        public team_transfers Transfers { get { return this.Get<team_transfers>(); } }

        public economy Economy { get { return this.Get<economy>(); } }

        public player Player { get { return this.Get<player>(); } }

        public user User { get { return this.Get<user>(); } }

        public team Team { get { return this.Get<team>(); } }

        public arena Arena { get { return this.Get<arena>(); } }

        public coaches Coaches { get { return this.Get<coaches>(); } }

        public country Country { get { return this.Get<country>(); } }

        public players Players { get { return this.Get<players>(); } }
    }

    /// <summary>
    /// match 
    /// </summary> 
    public partial class match
    {
        public string AwayTeamName { get { return teams == null ? string.Empty : teams.awayteamname; } }
        public string HomeTeamName { get { return teams == null ? string.Empty : teams.hometeamname; } }

        public uint HomeTeamId { get { return teams == null ? (ushort)0 : teams.hometeam; } }
        public uint AwayTeamId { get { return teams == null ? (ushort)0 : teams.awayteam; } }
      /*
        public IEnumerable<rating> HomeRatings { get { return stats == null ? null : stats.home.Ratings; } }
        public IEnumerable<rating> AwayRatings { get { return stats == null ? null : stats.away.Ratings; } }

        public IEnumerable<bball> HomeBb { get { return bballs == null ? null : bballs.home.Bballs; } }
        public IEnumerable<bball> AwayBb { get { return bballs == null ? null : bballs.away.Bballs; } }
      */
        public IEnumerable<rating> HomeRatings { get { return stats == null ? null : stats.home; } }
        public IEnumerable<rating> AwayRatings { get { return stats == null ? null : stats.away; } }

        public IEnumerable<bball> HomeBb { get { return bballs == null ? null : bballs.home; } }
        public IEnumerable<bball> AwayBb { get { return bballs == null ? null : bballs.away; } }

        public string MatchType
        {
            get { return System.Enum.GetName(typeof(MatchType), (MatchType)typeField); }
        }

        public bool Played { get { return playedField == "yes"; } }

        public System.DateTime Date_ { get { return Compute.EstimatedDateTime(dateField); } }

        public uint MyTeamId { private get; set; }

        public bool Won { get { return (homescore > awayscore && HomeTeamId == MyTeamId) || (homescore < awayscore && AwayTeamId == MyTeamId); } }
    }

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

  /*
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
  */

    public partial class expences
    {
        public uint Total { get { return this.buys + this.facility + this.maintenance + this.other + this.salary + this.staff; } }
    }

    public partial class income
    {
        public uint Total { get { return this.merchandise + this.other + this.sales + this.sponsor + this.tickets; } }
    }
}