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

    public Uri Uri { get; protected internal set; }
    public string FileName { get; protected internal set; }
    public int MinimumFileSize { get; protected set; }

    /// <summary>
    /// contains user sensitive information like player skills or training plan
    /// </summary>
    public bool IsUserSensitive { get; protected set; }

    internal DownloadItem (string s, string f)
    {
      Uri = new Uri(s);
      FileName = f;
      MinimumFileSize = 0;
      IsUserSensitive = false;
    }

    internal DownloadItem (Uri uri, string f)
    {
      Uri = uri;
      FileName = f;
      MinimumFileSize = 0;
      IsUserSensitive = false;
    }

    public bool FileExists { get { return File.Exists(this.FileName); } }

    public bool FileInvalid
    {
      get
      {
        FileInfo fi = new FileInfo(this.FileName);
        return FileExists && (fi.Length == 0 || fi.Length <= this.MinimumFileSize);
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
    /// <summary>
    /// only overload with nullable params ?
    /// </summary>
    /// <param name="category">xml type</param>
    /// <param name="id">resource id, default null</param>
    /// <param name="step">country step, default null</param>
    /// <param name="supressDate">include date in name, default false</param>
    /// <param name="userName">null means info is not user sensitive, not null means contains user sensitive info, default null</param>
    /// <returns></returns>
    private static string Category2FileName (Category category, ulong? id, byte? step, bool supressDate, string userName)
    {
      //
      AssemblyInfo asInfo = new AssemblyInfo();
      string pathCategory = Path.Combine(asInfo.ApplicationFolder, category.ToString());
      //isUserSensitive
      //if (!String.IsNullOrEmpty(userName))
        //pathCategory = Path.Combine(pathCategory, userName);
      if (!Directory.Exists(pathCategory))
        Directory.CreateDirectory(pathCategory);
      //
      StringBuilder sb = new StringBuilder();
      //
      if (!supressDate)
      {
        DateTime date = DateTime.Now;
        sb.AppendFormat("{0:D04}{1:D02}{2:D02}", date.Year, date.Month, date.Day);
      }
      //
      if (id != 0 && id != null)
        sb.AppendFormat("_{0}", id);
      if (step != null)
        sb.AppendFormat("_{0}", step);
      sb.Append(".xml");
      
      // extension only vs path in subfolder
      string path = (sb.Length == 4) 
        ? pathCategory + sb.ToString()
        : Path.Combine(pathCategory, sb.ToString());
      //
      
      if (!File.Exists(path))
        File.CreateText(path).Close();
      //
      return path;
    }

    public static string Category2FileName (Category category)
    {
      return Category2FileName(category, null, null, false, null);
    }
    public static string Category2FileName (Category category, string userName)
    {
      return Category2FileName(category, null, null, false, userName);
    }

    public static string NotDailyCategoryFileName (Category category)
    {
      return Category2FileName (category, null, null, true, null);
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

    protected internal virtual XmlSerializationType DeserializationType { get { return XmlSerializationType.Unknown; } }

   
    #region Constructor overloads / pairs
    
    internal XmlDownloadItem (string user, string pass, Category category)
      : base(ConstructUri(user, pass, category), Category2FileName(category, null, null, false, null)) { }
    internal XmlDownloadItem (CharazayUserData userData, Category category)
      : this(userData.User, userData.SecurityCode, category) { }

    internal XmlDownloadItem (string user, string pass, Category category, string usr)
      : base(ConstructUri(user, pass, category), Category2FileName(category, null, null, false, usr)) { }
    internal XmlDownloadItem (CharazayUserData userData, Category category, string usr)
      : this(userData.User, userData.SecurityCode, category, usr) { }

    internal XmlDownloadItem (string user, string pass, Category category, ulong id)
      : base(ConstructUri(user, pass, category, id), Category2FileName(category, id, null, false, null)) { }
    internal XmlDownloadItem (CharazayUserData userData, Category category, ulong id)
      : this(userData.User, userData.SecurityCode, category, id) { }

    internal XmlDownloadItem (string user, string pass, Category category, ulong id, string usr)
      : base(ConstructUri(user, pass, category, id), Category2FileName(category, id, null, false, usr)) { }
    internal XmlDownloadItem (CharazayUserData userData, Category category, ulong id, string usr)
      : this(userData.User, userData.SecurityCode, category, id, usr) { }

    internal XmlDownloadItem (string user, string pass, Category category, ulong id, byte step)
      : base(ConstructUri(user, pass, category, id, step), Category2FileName(category, id, step, false, null)) { }
    internal XmlDownloadItem (CharazayUserData userData, Category category, ulong id, byte step)
      : this(userData.User, userData.SecurityCode, category, id, step) { }

    internal XmlDownloadItem (string user, string pass, Category category, ulong id, byte step, string usr)
      : base(ConstructUri(user, pass, category, id, step), Category2FileName(category, id, step, false, usr)) { }
    internal XmlDownloadItem (CharazayUserData userData, Category category, ulong id, byte step, string usr)
      : this(userData.User, userData.SecurityCode, category, id, step, usr) { }

    internal XmlDownloadItem (string user, string pass, Category category, ulong id, byte step, bool supressDate)
      : base(ConstructUri(user, pass, category, id), Category2FileName(category, id, step, supressDate, null)) { }
    internal XmlDownloadItem (CharazayUserData userData, Category category, ulong id, byte step, bool supressDate)
      : this(userData.User, userData.SecurityCode, category, id, step, supressDate) { }

    internal XmlDownloadItem (string user, string pass, Category category, ulong id, byte step, bool supressDate, string usr)
      : base(ConstructUri(user, pass, category, id), Category2FileName(category, id, step, supressDate, usr)) { }
    internal XmlDownloadItem (CharazayUserData userData, Category category, ulong id, byte step, bool supressDate, string usr)
      : this(userData.User, userData.SecurityCode, category, id, step, supressDate, usr) { }

    internal XmlDownloadItem (string user, string pass, Category category, ulong id, bool supressDate, string usr)
      : base(ConstructUri(user, pass, category, id), Category2FileName(category, id, null, supressDate, usr)) { }
    internal XmlDownloadItem (CharazayUserData userData, Category category, ulong id, bool supressDate, string usr)
      : this(userData.User, userData.SecurityCode, category, id, supressDate, usr) { }

    #endregion
  }

  // MY team players ((basic & status & SKILLS))
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=0
  //parametru posibil alta echipa id: team ID (merge)
  //Parameters
  //code: 0
  //user-sensitive: YES
  internal class MyPlayersXml : XmlDownloadItem
  {
    internal MyPlayersXml (string user, string pass) : base(user, pass, Category.Players, user) { IsUserSensitive = true; }
    internal MyPlayersXml (CharazayUserData userData) : this(userData.User, userData.SecurityCode) { }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.MyPlayers; } }
  }

  // SOME team players (only basic & status)
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=0&id=TEAM_ID
  //parametru posibil alta echipa id: team ID (merge)
  //Parameters
  //code: 0
  //id: team ID
  //user-sensitive: NO
  internal class UserPlayersXml : XmlDownloadItem
  {
    internal UserPlayersXml (string user, string pass, ulong teamId) : base(user, pass, Category.Players, teamId) { }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.UserPlayers; } }
  }

  //match
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=1&id=MATCH_ID
  //Parameters
  //code: 1
  //id: match ID
  //user-sensitive: NO
  internal class MatchXml : XmlDownloadItem
  {
    internal MatchXml (string user, string pass, ulong matchId) 
      : base(user, pass, Category.Match, matchId, true, null) 
    { MinimumFileSize = 500; }
    
    internal MatchXml (CharazayUserData ud, ulong matchId) 
      : this(ud.User, ud.SecurityCode, matchId) { }
    
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.Match; } }
  }

  //schedule
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=2
  //Parameters
  //code: 2
  //user-sensitive: NO
  internal class MyScheduleXml : XmlDownloadItem
  {
    internal MyScheduleXml (string user, string pass) : base(user, pass, Category.Schedule) { }
    internal MyScheduleXml (CharazayUserData userData) : this(userData.User, userData.SecurityCode) { }
    
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.MySchedule; } }
  }

  //schedule
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=2&id=TEAM_ID
  //Parameters
  //code: 2
  //user-sensitive: NO
  internal class TeamScheduleXml : XmlDownloadItem
  {
    internal TeamScheduleXml (string user, string pass, ulong teamId) : base(user, pass, Category.Schedule, teamId) { }
    
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.TeamSchedule; } }
  }

  //MY teaminfo
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=3
  //Parameters
  //code: 3
  //user-sensitive: YES (training plan + fanclub name)
  internal class MyTeamInfoXml : XmlDownloadItem
  {
    internal MyTeamInfoXml (string user, string pass) : base(user, pass, Category.TeamInfo, user) { IsUserSensitive = true; }
    internal MyTeamInfoXml (CharazayUserData userData) : this(userData.User, userData.SecurityCode) { }
    
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.MyTeamInfo; } }
  }

  //SOME teaminfo
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=3&id=TEAM_ID
  //Parameters
  //code: 3
  //id: team ID
  //user-sensitive: NO
  internal class UserTeamInfoXml : XmlDownloadItem
  {
    internal UserTeamInfoXml (string user, string pass, ulong teamId) : base(user, pass, Category.TeamInfo, teamId) { }
    
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.UserTeamInfo; } }
  }

  //div
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=4&id=DIVISION_ID
  //Parameters
  //code: 4
  //id: division ID
  //user-sensitive: NO
  internal class DivisionStandingsXml : XmlDownloadItem
  {
    internal DivisionStandingsXml (string user, string pass, uint divisionId)
      : base(user, pass, Category.DivisionInfo, (ulong)divisionId) { }
    internal DivisionStandingsXml (CharazayUserData userData) : this(userData.User, userData.SecurityCode, userData.DivisionId) { }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.DivisionStandings; } }
  }

  //country
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=5&id=COUNTRY_ID&step=STEP
  //Parameters
  //code: 5
  //id: country ID
  //step: 0 (only country info) or 1 (country info + division list)
  //user-sensitive: NO
  internal class CountryInfoXml : XmlDownloadItem
  {
    internal CountryInfoXml (string user, string pass, ulong countryId) : base(user, pass, Category.CountryInfo, countryId) { }
    internal CountryInfoXml (CharazayUserData userData) : this(userData.User, userData.SecurityCode, userData.CountryId) { }
    
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.CountryInfo; } }
  }

  internal class CountryDivisionListXml : XmlDownloadItem
  {
    internal CountryDivisionListXml (string user, string pass, ulong countryId)
      : base(user, pass, Category.CountryInfo, countryId, 1) { }
    internal CountryDivisionListXml (CharazayUserData userData)
      : this(userData.User, userData.SecurityCode, userData.CountryId) { }
    
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.CountryDivisionList; } }
  }

  //player
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=6&id=PLAYER_ID
  //Parameters
  //code: 6
  //id: player ID
  //user-sensitive: NO
  internal class PlayerXml : XmlDownloadItem
  {
    internal PlayerXml (string user, string pass, ulong plyrId) : base(user, pass, Category.PlayerInfo, plyrId) { }
    internal PlayerXml (CharazayUserData userData, ulong plyrId) : base(userData, Category.PlayerInfo, plyrId) { }
    
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.Player; } }
  }


  //division schedule
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=7&id=DIVISION_ID
  //Parameters
  //code: 7
  //id: division ID
  //user-sensitive: NO
  internal class DivisionScheduleXml : XmlDownloadItem
  {
    internal DivisionScheduleXml (string user, string pass, ulong divId)
      : base(user, pass, Category.DivisionSchedule, divId) { }
    internal DivisionScheduleXml (CharazayUserData userData)
      : this(userData.User, userData.SecurityCode, (ulong)userData.DivisionId) { }
    
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.DivisionSchedule; } }
  }


  //SOME transfer history
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=8&id=TEAM_ID
  //Parameters
  //code: 8
  //id: team ID
  //user-sensitive: NO
  internal class UserTransfersXml : XmlDownloadItem
  {
    internal UserTransfersXml (string user, string pass, ulong teamId) : base(user, pass, Category.TeamTransfers, teamId) { }
    
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.UserTransfers; } }
  }

  //MY transfer history
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=8
  //Parameters
  //code: 8
  //user-sensitive: NO
  internal class MyTransfersXml : XmlDownloadItem
  {
    internal MyTransfersXml (string user, string pass) : base(user, pass, Category.TeamTransfers) { }
    internal MyTransfersXml (CharazayUserData userData) : this(userData.User, userData.SecurityCode) { }
    //protected internal override Type DeserializationReturnType { get { return typeof(Xsd.team_transfers); } }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.MyTransfers; } }
  }


  //user
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=9&id=USER_ID
  //Parameters
  //code: 9
  //id: user ID
  //user-sensitive: NO
  internal class UserInfoXml : XmlDownloadItem
  {
    internal UserInfoXml (string user, string pass, ulong userId) : base(user, pass, Category.UserInfo, userId) { }
    //protected internal override Type DeserializationReturnType { get { return typeof(Xsd.user); } }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.UserInfo; } }
  }


  internal class MyInfoXml : XmlDownloadItem
  {
    internal MyInfoXml (string user, string pass) : base(user, pass, Category.UserInfo) { }
    internal MyInfoXml (CharazayUserData userData) : this(userData.User, userData.SecurityCode) { }
    //protected internal override Type DeserializationReturnType { get { return typeof(Xsd.user); } }
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.MyInfo; } }
  }

  //arena
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=10&id=ARENA_ID
  //Parameters
  //code: 10
  //id: arena ID
  //user-sensitive: NO
  internal class ArenaXml : XmlDownloadItem
  {
    internal ArenaXml (string user, string pass, ulong arenaId)
      : base(user, pass, Category.ArenaInfo, arenaId) { }
    internal ArenaXml (CharazayUserData userData)
      : this(userData.User, userData.SecurityCode, (ulong)userData.ArenaId) { }
    
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.Arena; } }
  }


  //coaches
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=11
  //Parameters
  //code: 11
  //user-sensitive: YES
  internal class CoachesXml : XmlDownloadItem
  {
    internal CoachesXml (string user, string pass) 
      : base(user, pass, Category.Coaches, user) 
    { IsUserSensitive = true; }
    internal CoachesXml (CharazayUserData userData) 
      : this(userData.User, userData.SecurityCode) { }
    
    protected internal override XmlSerializationType DeserializationType { get { return XmlSerializationType.Coaches; } }
  }


  //economy
  //http://www.charazay.com/xml.php?username=USER&password=SECURITY_CODE&code=12
  //Parameters
  //code: 12 
  //user-sensitive: YES
  internal class EconomyXml : XmlDownloadItem
  {
    internal EconomyXml (string user, string pass) : base(user, pass, Category.Economy, user) { IsUserSensitive = true; }
    internal EconomyXml (CharazayUserData userData) : this(userData.User, userData.SecurityCode) { }
    
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