using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AndreiPopescu.CharazayPlus.Web;
using System.Collections.Generic;
using AndreiPopescu.CharazayPlus.Objects;
using System.Collections;
using AndreiPopescu.CharazayPlus.Extensions;

namespace AndreiPopescu.CharazayPlus.Utils
{
  /// <summary>
  /// deserialize helper for charazay xml 
  /// </summary>
  public static class Deserializer
  {
    internal static object DeserializeXml (Web.XmlDownloadItem di)
    {
      return DeserializeXml(di.FileName, di.DeserializationType);
    }

    internal static object DeserializeXml (string fileName, Web.XmlSerializationType type)
    {
      using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
      {
        Xsd2.charazay obj = null;


        try
        {
          obj = (Xsd2.charazay)(new XmlSerializer(typeof(Xsd2.charazay)).Deserialize(fs));
        }
        catch (Exception ex)
        {
          if (type == XmlSerializationType.Player && ex is InvalidOperationException && ex.InnerException != null && ex.InnerException is FormatException)
          {
            string m = ex.Message.Replace("There is an error in XML document", "");
            string[] tokens = m.Split(new char[] { ' ', '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
            //System.InvalidOperationException was unhandled
            //Message=There is an error in XML document (3, 126).
            //InnerException: System.FormatException
            //Message=Input string was not in m correct format.
            long errPos = long.Parse(tokens[1]);
            fs.Seek(errPos + 8, SeekOrigin.Begin);
            fs.WriteByte(0);
            obj = (Xsd2.charazay)(new XmlSerializer(typeof(Xsd2.charazay)).Deserialize(fs));
          }
          else throw;
        }

        if (obj.error != null)
          return obj.error;

        switch (type)
        { //
          // InitMyPlayers(obj.players);
          //
          case Web.XmlSerializationType.MyPlayers: return obj.players;
          //
          // MyXmlTeam.Arena 
          //
          case Web.XmlSerializationType.Arena: return obj.arena;
          //
          // division id is m mandatory session variable
          // MyXmlTeam.TeamInfo
          //
          case Web.XmlSerializationType.MyTeamInfo:
            {
              if (obj.team == null || obj.team.team_info == null) throw new Exception("XmlSerializationType.MyTeamInfo");
              WebServiceUsers.Instance.MainUser.DivisionId = obj.team.team_info.divisionid;
              return obj.team;
            }
          // 
          // country and team id are mandatory session variables
          // arenaid == teamid
          // MyXmlTeam.UserInfo =
          //
          case Web.XmlSerializationType.MyInfo:
            {
              if (obj.user == null) throw new Exception("XmlSerializationType.MyInfo");
              WebServiceUsers.Instance.MainUser.CountryId = obj.user.countryid;
              WebServiceUsers.Instance.MainUser.ArenaId = obj.user.teamid;
              return obj.user;
            }
          //
          // MyXmlTeam.CountryInfo =
          //
          case Web.XmlSerializationType.CountryDivisionList: return obj.country;
          //
          // Coaches
          // InitCoachesData(todo)
          //
          case Web.XmlSerializationType.Coaches: return obj.coaches;
          // MyXmlTeam.Schedule = 
          case Web.XmlSerializationType.MySchedule: return obj.matches;
          //
          // MyXmlTeam.Standings
          //
          case Web.XmlSerializationType.DivisionStandings: return obj.division;
          //
          // MyXmlTeam.DivisionSchedule =
          //
          case Web.XmlSerializationType.DivisionSchedule: return obj.schedule;
          //
          //_selectedMatch =
          //
          case Web.XmlSerializationType.Match: return obj.match;
          //
          // MyXmlTeam.Transfers =
          //
          case Web.XmlSerializationType.MyTransfers: return obj.team_transfers;
          // 
          //MyXmlTeam.Economy = 
          //
          case Web.XmlSerializationType.Economy: return obj.economy;
          //
          case Web.XmlSerializationType.Player: return obj.player;
          //
          case Web.XmlSerializationType.Unknown:
          default:
            throw new Exception("Deserialization return type error!");
        }

      }
    }

    /// <summary>
    /// download xml and deserialize to objects
    /// </summary>
    /// <param name="xmls"><see cref="Web.XmlDownloadItem"/> array</param>
    /// <returns>collection of deserialized objects</returns>
    internal static IEnumerable<object> GoGetXml (Web.XmlDownloadItem[] xmls)
    {
      using (Web.Downloader crawler = new Web.Downloader())
      {
        foreach (var xml in xmls)
          crawler.Add(xml);
        // download items
        crawler.Get(true);

        //try
        //{
        foreach (Web.XmlDownloadItem di in crawler.Items)
          yield return Utils.Deserializer.DeserializeXml(di);
        //}
        //catch (Exception ex)
        //{
        //  System.Diagnostics.Debug.Write(ex.Message);
        //  throw;
        //}
      }
    }

    internal static object GoGetXml (Web.XmlDownloadItem xml)
    {
      return GoGetXml(new XmlDownloadItem[] { xml }).First();
    }

    static readonly TimeSpan ThreeDays = new TimeSpan(3, 0, 0, 0);

    /// <summary>
    /// Download player xml and deserialize to object model player
    /// cleanup old unnecessary data
    /// reassure player data is fresh
    /// </summary>
    /// <param name="pid"></param>
    /// <param name="err"></param>
    /// <returns></returns>
    internal static Xsd2.charazayPlayer GoGetPlayerXml (ulong pid, out Xsd2.error err) 
    {
       Xsd2.charazayPlayer xsdp = null;
       err = null;
      //
      // search local data
      //
      AssemblyInfo asInfo = new AssemblyInfo();
      string pathCategory = Path.Combine(asInfo.ApplicationFolder, Category.PlayerInfo.ToString());
      var files = Directory.GetFiles(pathCategory, string.Format("*{0}*", pid), SearchOption.TopDirectoryOnly);
      if (files.IsNullOrEmpty())
      { //
        // no previous info
        //
        xsdp = GoGetXml(new Web.PlayerXml(WebServiceUsers.Instance.MainUser, pid)) as Xsd2.charazayPlayer;        
      }
      else
      { // 
        // delete files for players with no skill info
        // delete files older than three days
        //
        var fis = files.Select(f => new FileInfo(f)).OrderByDescending(f=>f.LastWriteTime).ToList();
        Predicate<FileInfo> pred = fi => fi.Length < 700 || DateTime.Now - fi.LastWriteTime > ThreeDays;
        foreach (var fileInfo in fis.Where(fi=>pred(fi)))
        { 
          fileInfo.Delete(); 
        }
        fis.RemoveAll(pred);
        //
        if (CollectionExtensions.IsNullOrEmpty(fis))
        { //
          // if nothing left reget
          //          
          var xmlObject = GoGetXml(new Web.PlayerXml(WebServiceUsers.Instance.MainUser, pid));
          if (xmlObject is Xsd2.error)
          {
            err = xmlObject as Xsd2.error;
            return null; 
          }
          else
            xsdp = xmlObject as Xsd2.charazayPlayer;            
        }
        else
        { //
          // use what we got
          //
          xsdp = DeserializeXml(fis[0].FullName, XmlSerializationType.Player) as Xsd2.charazayPlayer;
        }
      }
      
      return xsdp;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    internal static IEnumerable<Tuple<DateTime,Xsd2.charazayEconomy>> GetEconomyHistory ( int days )
    { 
      //
      // search local data
      //
      AssemblyInfo asInfo = new AssemblyInfo();
      string pathCategory = Path.Combine(asInfo.ApplicationFolder, Category.Economy.ToString());
      var files = Directory.GetFiles(pathCategory, "*", SearchOption.TopDirectoryOnly);
      if (files.IsNullOrEmpty())
      { //
        // no previous info
        //
        yield break;
      }
      else
      {
        var fileInfos = files.Select(f => new FileInfo(f))
                             .OrderByDescending(fi => fi.LastWriteTimeUtc)
                             .Take(days);
      
      
        foreach (var fi in fileInfos)
        {
          Xsd2.charazayEconomy eco = null;
          try
          {
            eco = DeserializeXml(fi.FullName, XmlSerializationType.Economy) as Xsd2.charazayEconomy;            
          }
          catch { }
          if (eco != null)
            yield return new Tuple<DateTime, Xsd2.charazayEconomy>(
              new DateTime(fi.LastWriteTimeUtc.Year, fi.LastWriteTimeUtc.Month, fi.LastWriteTimeUtc.Day), eco);
        }
      }
    }

    internal static Xsd2.match GoGetMatchXml (ulong matchId) 
    { 
      return GoGetXml(new Web.MatchXml(WebServiceUsers.Instance.MainUser, matchId)) as Xsd2.match; 
    }
    
    /// <summary>
    /// serialize the transfer listed players that have been evaluated
    /// </summary>
    /// <param name="TLObjects">transfer listed assessed players from _olv</param>
    internal static void SerializePlayersTL ( IEnumerable TLObjects)
    {
      string tlFile = Web.XmlDownloadItem.Category2FileName(Web.Category.MyPlayersTL);
      FileStream fs = null;
      try
      {
        fs = new FileStream(tlFile, FileMode.Truncate, FileAccess.Write);
        //
        XmlSerializer serializer = new XmlSerializer(typeof(TLPlayers));
        TLPlayers tlps = new TLPlayers();
        //
        if (TLObjects is ArrayList)
        {
          object o = (TLObjects as ArrayList).ToArray(typeof(TLPlayer));
          tlps.TLPlayer = (TLPlayer[])o;
        }
        else if (TLObjects is TLPlayer[])
        {
          tlps.TLPlayer = (TLPlayer[])TLObjects;
        }
        else if (TLObjects is List<TLPlayer>)
        {
          tlps.TLPlayer = (TLObjects as List<TLPlayer>).ToArray();
        }
        //
        serializer.Serialize(fs, tlps);
      }
      finally
      {
        fs.Close();
      }

    }

    /// <summary>
    /// Builds a <see cref="Player"/> instance from a player id bound to a specific position
    /// </summary>
    /// <param name="pid">player id</param>
    /// <param name="pos">court position</param>
    /// <returns>a <see cref="Player"/></returns>
    internal static Player GetPlayerFromIdAndPosition (ulong pid, PlayerPosition pos, Evaluation evaluationType)
    {
      Xsd2.error err = null;
      var xp = Deserializer.GoGetPlayerXml(pid, out err);

      if (xp == null || xp.skills == null || err != null)
        return null;

      switch (evaluationType)
      {
        case Evaluation.old:
          switch (pos)
          {
            case PlayerPosition.PG: return new PG(xp);
            case PlayerPosition.SG: return new SG(xp);
            case PlayerPosition.SF: return new SF(xp);
            case PlayerPosition.PF: return new PF(xp);
            case PlayerPosition.C: return new C(xp);
            default: return null;
          } 
          

        case Evaluation.season30:
          switch (pos)
          {
            case PlayerPosition.PG: return new PG2014(xp, true, false, false);
            case PlayerPosition.SG: return new SG2014(xp, true, false, false);
            case PlayerPosition.SF: return new SF2014(xp, true, false, false);
            case PlayerPosition.PF: return new PF2014(xp, true, false, false);
            case PlayerPosition.C: return new C2014(xp, true, false, false);
            default: return null;
          }


        default: return null;

      }
      
    }
    
  }
}
