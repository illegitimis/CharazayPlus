namespace AndreiPopescu.CharazayPlus.Web
{
  using System;
  using System.Net;
  using System.Text;
  using System.Collections.Generic;
  using System.IO;
  using AndreiPopescu.CharazayPlus.Utils;

  /// <summary>
  /// 
  /// </summary>
  internal class DownloadItem
  {
    internal Uri m_uri = null;
    internal string m_fileName = null;
    //internal bool m_offline = true;

    protected internal int _MinimumFileSize = 0;

    internal DownloadItem (string s, string f)
    {
      m_uri = new Uri(s);
      m_fileName = f;
    }

    internal DownloadItem (Uri uri, string f)
    {
      m_uri = uri;
      m_fileName = f;
    }

    public bool FileExists { get { return File.Exists(this.m_fileName); } }

    public bool FileInvalid
    {
      get
      {
        FileInfo fi = new FileInfo(this.m_fileName);
        return FileExists && (fi.Length == 0 || fi.Length <= this._MinimumFileSize);
      }
    }
  }

    
  /// <summary>
  /// base class for xml pieces returned by the Charazay XML API
  /// </summary>
  internal class XmlDownloadItem : DownloadItem
  {
    private const string baseWebServiceUri = "http://www.charazay.com/xml.php?";

    #region Construct file name from category
    private static string Category2FileName (Category category, ulong? id, byte? step, bool supressDate)
    {
      AssemblyInfo asInfo = new AssemblyInfo();
      string pathCategory = Path.Combine(asInfo.ApplicationFolder, category.ToString());
      if (!Directory.Exists(pathCategory))
        Directory.CreateDirectory(pathCategory);

      StringBuilder sb = new StringBuilder();
      if (supressDate)
      {
        sb.AppendFormat("{0}", id);
        if (step != null)
          sb.AppendFormat("_{0}", step);
        sb.Append(".xml");
      }
      else
      {
        DateTime date = DateTime.Now;
        sb.AppendFormat("{0:D04}{1:D02}{2:D02}", date.Year, date.Month, date.Day);
        if (id != 0 && id != null)
          sb.AppendFormat("_{0}", id);
        if (step != null)
          sb.AppendFormat("_{0}", step);
        sb.Append(".xml");
      }

      string path = Path.Combine(pathCategory, sb.ToString());
      if (!File.Exists(path))
        File.CreateText(path).Close();

      return path;
    }

    private static string Category2FileName (Category category, ulong? id, byte? step)
    {
      return Category2FileName(category, id, step, false);
    }

    private static string Category2FileName (Category category, ulong id)
    {
      return Category2FileName(category, id, null);
    }

    public static string Category2FileName (Category category)
    {
      return Category2FileName(category, null, null);
    }
    #endregion

    #region Construct uri
    private static string ConstructUri (string user, string pass, Category category)
    {
      return string.Format("{0}username={1}&password={2}&code={3}", baseWebServiceUri, user, pass, (byte)category);
    }

    private static string ConstructUri (string user, string pass, Category category, ulong id)
    {
      return string.Format("{0}username={1}&password={2}&code={3}&id={4}", baseWebServiceUri, user, pass, (byte)category, id);
    }

    private static string ConstructUri (string user, string pass, Category category, ulong id, byte step)
    {
      return string.Format("{0}username={1}&password={2}&code={3}&id={4}&step={5}", baseWebServiceUri, user, pass, (byte)category, id, step);
    }
    #endregion

    //protected internal virtual Type DeserializationReturnType { get { return typeof(Xsd.charazay); } }
    protected internal virtual XmlSerializationType DeserializationType { get { return XmlSerializationType.Unknown; } }
    
    internal XmlDownloadItem (WebServiceUser wsu, Category category)
      : this(wsu.user, wsu.securityCode, category) { }

    internal XmlDownloadItem (string user, string pass, Category category)
      : base(ConstructUri(user, pass, category), Category2FileName(category)) { }

    internal XmlDownloadItem (string user, string pass, Category category, ulong id)
      : base(ConstructUri(user, pass, category, id), Category2FileName(category, id)) { }

    internal XmlDownloadItem (WebServiceUser wsu, Category category, ulong id)
      : this(wsu.user, wsu.securityCode, category, id) { }

    internal XmlDownloadItem (string user, string pass, Category category, ulong id, byte step)
      : base(ConstructUri(user, pass, category, id, step), Category2FileName(category, id, step)) { }

    internal XmlDownloadItem (WebServiceUser wsu, Category category, ulong id, byte step)
      : this(wsu.user, wsu.securityCode, category, id, step) { }

    internal XmlDownloadItem (string user, string pass, Category category, ulong id, bool supressDate)
      : base(ConstructUri(user, pass, category, id), Category2FileName(category, id, null, supressDate)) { }

    internal XmlDownloadItem (WebServiceUser wsu, Category category, ulong id, bool supressDate)
      : this(wsu.user, wsu.securityCode, category, id, supressDate) { }
  }

  //    team
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=0&id=TEAM_ID
  //parametru posibil alta echipa id: team ID (merge)
  //Parameters
  //code: 0
  //id: team ID
  internal class MyPlayersXml : XmlDownloadItem
  {
    internal MyPlayersXml (string user, string pass) : base(user, pass, Category.Players) { }
    internal MyPlayersXml (WebServiceUser wsu) : this(wsu.user, wsu.securityCode) { }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.MyPlayers; } }
  }

  internal class UserPlayersXml : XmlDownloadItem
  {
    internal UserPlayersXml (string user, string pass, ulong teamId) : base(user, pass, Category.Players, teamId) { }
    //protected internal override Type DeserializationReturnType { get { return typeof(Xsd.players); } }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.UserPlayers; } }
  }

  //match
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=1&id=MATCH_ID
  //Parameters
  //code: 1
  //id: match ID
  internal class MatchXml : XmlDownloadItem
  {
    internal MatchXml (string user, string pass, ulong matchId) : base(user, pass, Category.Match, matchId, true) { _MinimumFileSize = 500; }
    internal MatchXml (WebServiceUser user, ulong matchId) : base(user, Category.Match, matchId, true) { _MinimumFileSize = 500; }
    //protected internal override Type DeserializationReturnType { get { return typeof(Xsd.players); } }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.Match; } }
  }

  //schedule
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=2&id=TEAM_ID
  //Parameters
  //code: 2
  internal class MyScheduleXml : XmlDownloadItem
  {
    internal MyScheduleXml (string user, string pass) : base(user, pass, Category.Schedule) { }
    internal MyScheduleXml (WebServiceUser wsu) : this(wsu.user, wsu.securityCode) { }
    //protected internal override Type DeserializationReturnType { get { return typeof(Xsd.matches); } }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.MySchedule; } }
  }

  internal class TeamScheduleXml : XmlDownloadItem
  {
    internal TeamScheduleXml (string user, string pass, ulong teamId) : base(user, pass, Category.Schedule, teamId) { }
    //protected internal override Type DeserializationReturnType { get { return typeof(Xsd.schedule); } }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.TeamSchedule; } }
  }

  //teaminfo
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=3&id=TEAM_ID
  //Parameters
  //code: 3
  //id: team ID
  internal class MyTeamInfoXml : XmlDownloadItem
  {
    internal MyTeamInfoXml (string user, string pass) : base(user, pass, Category.TeamInfo) { }
    internal MyTeamInfoXml (WebServiceUser wsu) : this(wsu.user, wsu.securityCode) { }
    //protected internal override Type DeserializationReturnType { get { return typeof(Xsd.team); } }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.MyTeamInfo; } }
  }

  internal class UserTeamInfoXml : XmlDownloadItem
  {
    internal UserTeamInfoXml (string user, string pass, ulong teamId) : base(user, pass, Category.TeamInfo, teamId) { }
    //protected internal override Type DeserializationReturnType { get { return typeof(Xsd.team_info); } }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.UserTeamInfo; } }
  }

  //div
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=4&id=DIVISION_ID
  //Parameters
  //code: 4
  //id: division ID
  internal class DivisionStandingsXml : XmlDownloadItem
  {
    internal DivisionStandingsXml (string user, string pass, uint divisionId)
      : base(user, pass, Category.DivisionInfo, (ulong)divisionId) { }
    internal DivisionStandingsXml (WebServiceUser wsu) : this(wsu.user, wsu.securityCode, wsu.divisionId) { }
    //protected internal override Type DeserializationReturnType { get { return typeof(Xsd.division); } }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.DivisionStandings; } }
  }

  //country
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=5&id=COUNTRY_ID&step=STEP
  //Parameters
  //code: 5
  //id: country ID
  //step: 0 or 1
  internal class CountryInfoXml : XmlDownloadItem
  {
    internal CountryInfoXml (string user, string pass, ulong countryId) : base(user, pass, Category.CountryInfo, countryId) { }
    internal CountryInfoXml (WebServiceUser wsu) : this(wsu.user, wsu.securityCode, wsu.countryId) { }
    //protected internal override Type DeserializationReturnType { get { return typeof(Xsd.country); } }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.CountryInfo; } }
  }

  internal class CountryDivisionListXml : XmlDownloadItem
  {
    internal CountryDivisionListXml (string user, string pass, ulong countryId)
      : base(user, pass, Category.CountryInfo, countryId, 1) { }
    internal CountryDivisionListXml (WebServiceUser wsu)
      : this(wsu.user, wsu.securityCode, wsu.countryId) { }
    //protected internal override Type DeserializationReturnType { get { return typeof(Xsd.country); } }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.CountryDivisionList; } }
  }

  //player
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=6&id=PLAYER_ID
  //Parameters
  //code: 6
  //id: player ID
  internal class PlayerXml : XmlDownloadItem
  {
    internal PlayerXml (string user, string pass, ulong plyrId) : base(user, pass, Category.PlayerInfo, plyrId) { }
    internal PlayerXml (WebServiceUser wsu, ulong plyrId) : base(wsu, Category.PlayerInfo, plyrId) { }
    //protected internal override Type DeserializationReturnType { get { return typeof(Xsd.player); } }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.Player; } }
  }


  //division schedule
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=7&id=DIVISION_ID
  //Parameters
  //code: 7
  //id: division ID
  internal class DivisionScheduleXml : XmlDownloadItem
  {
    internal DivisionScheduleXml (string user, string pass, ulong divId)
      : base(user, pass, Category.DivisionSchedule, divId) { }
    internal DivisionScheduleXml (WebServiceUser wsu)
      : this(wsu.user, wsu.securityCode, (ulong)wsu.divisionId) { }
    //protected internal override Type DeserializationReturnType { get { return typeof(Xsd.schedule); } }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.DivisionSchedule; } }
  }


  //team transfer history
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=8&id=TEAM_ID
  //Parameters
  //code: 8
  //id: team ID
  internal class UserTransfersXml : XmlDownloadItem
  {
    internal UserTransfersXml (string user, string pass, ulong teamId) : base(user, pass, Category.TeamTransfers, teamId) { }
    //protected internal override Type DeserializationReturnType { get { return typeof(Xsd.team_transfers); } }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.UserTransfers; } }
  }

  internal class MyTransfersXml : XmlDownloadItem
  {
    internal MyTransfersXml (string user, string pass) : base(user, pass, Category.TeamTransfers) { }
    internal MyTransfersXml (WebServiceUser wsu) : this(wsu.user, wsu.securityCode) { }
    //protected internal override Type DeserializationReturnType { get { return typeof(Xsd.team_transfers); } }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.MyTransfers; } }
  }


  //user
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=9&id=USER_ID
  //Parameters
  //code: 9
  //id: user ID
  internal class UserInfoXml : XmlDownloadItem
  {
    internal UserInfoXml (string user, string pass, ulong userId) : base(user, pass, Category.UserInfo, userId) { }
    //protected internal override Type DeserializationReturnType { get { return typeof(Xsd.user); } }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.UserInfo; } }
  }


  internal class MyInfoXml : XmlDownloadItem
  {
    internal MyInfoXml (string user, string pass) : base(user, pass, Category.UserInfo) { }
    internal MyInfoXml (WebServiceUser wsu) : this(wsu.user, wsu.securityCode) { }
    //protected internal override Type DeserializationReturnType { get { return typeof(Xsd.user); } }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.MyInfo; } }
  }

  //arena
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=10&id=ARENA_ID
  //Parameters
  //code: 10
  //id: arena ID
  internal class ArenaXml : XmlDownloadItem
  {
    internal ArenaXml (string user, string pass, ulong arenaId)
      : base(user, pass, Category.ArenaInfo, arenaId) { }
    internal ArenaXml (WebServiceUser wsu)
      : this(wsu.user, wsu.securityCode, (ulong)wsu.arenaId) { }
    //protected internal override Type DeserializationReturnType { get { return typeof(Xsd.arena); } }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.Arena; } }
  }


  //coaches
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=11
  //Parameters
  //code: 11
  internal class CoachesXml : XmlDownloadItem
  {
    internal CoachesXml (string user, string pass) : base(user, pass, Category.Coaches) { }
    internal CoachesXml (WebServiceUser wsu) : base(wsu, Category.Coaches) { }
    //protected internal override Type DeserializationReturnType { get { return typeof(Xsd.coaches); } }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.Coaches; } }
  }


  //economy
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=12
  //Parameters
  //code: 12 
  internal class EconomyXml : XmlDownloadItem
  {
    internal EconomyXml (string user, string pass) : base(user, pass, Category.Economy) { }
    internal EconomyXml (WebServiceUser wsu) : this(wsu.user, wsu.securityCode) { }
    //protected internal override Type DeserializationReturnType { get { return typeof(Xsd.economy); } }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.Economy; } }
  }


  //http://www.charazay.com/images/language/it.png
  internal class PngDownloadItem : DownloadItem
  {
    private const string basePngUri = "http://www.charazay.com/images/language/";

    internal PngDownloadItem (ulong countryId)
      : base(ConstructUri(countryId), ConstructFileName(countryId)) { }

    private static string ConstructUri (ulong countryId)
    {
      return string.Format("{0}{1}.png", basePngUri
        , Defines.Countries[(int)countryId].ShortName);
    }

    private static string ConstructFileName (ulong countryId)
    {
      AssemblyInfo asInfo = new AssemblyInfo();
      string flagPath = Path.Combine(asInfo.ApplicationFolder, "Flags");
      if (!Directory.Exists(flagPath))
        Directory.CreateDirectory(flagPath);

      return Path.Combine(flagPath, string.Format("{0}.png"
        , Defines.Countries[(int)countryId].ShortName));
    }
  }



}