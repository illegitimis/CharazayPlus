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
      return DeserializeXml(di.m_fileName, di.DeserializationType);
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
            string [] tokens = m.Split(new char[] { ' ', '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
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
              WebServiceUser.Instance.divisionId = obj.team.team_info.divisionid;
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
              WebServiceUser.Instance.countryId = obj.user.countryid;
              WebServiceUser.Instance.arenaId = obj.user.teamid;
              return obj.user;
            } 
            //
            // MyXmlTeam.CountryInfo =
            //
            case Web.XmlSerializationType.CountryDivisionList: return obj.country; 
            //
            // Coaches
            // initCoachesData(todo)
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

    internal static Xsd2.charazayPlayer GoGetPlayerXml (ulong pid) 
    {
       Xsd2.charazayPlayer xsdp = null;
      //
      // search local data
      //
      AssemblyInfo asInfo = new AssemblyInfo();
      string pathCategory = Path.Combine(asInfo.ApplicationFolder, Category.PlayerInfo.ToString());
      var files = Directory.GetFiles(pathCategory, string.Format("*{0}*", pid), SearchOption.TopDirectoryOnly);
      if (files.IsNullOrEmpty())
      {
        xsdp = GoGetXml(new Web.PlayerXml(WebServiceUser.Instance, pid)) as Xsd2.charazayPlayer;        
      }
      else
      {
        var fis = files.Select(f => new FileInfo(f)).ToList();
        long maxl = fis.Max(fi => fi.Length);
        var maxfi = fis.FirstOrDefault(fi => fi.Length == maxl);
        xsdp = DeserializeXml(maxfi.FullName, XmlSerializationType.Player) as Xsd2.charazayPlayer;
      }
      if (xsdp.skills == null)
      {
        throw new Exception("player has no skills");
      }
      else return xsdp;
    }

    internal static Xsd2.match GoGetMatchXml (ulong matchId) { return GoGetXml(new Web.MatchXml(WebServiceUser.Instance, matchId)) as Xsd2.match; }
    
    /// <summary>
    /// serialize the transfer listed players that have been evaluated
    /// </summary>
    /// <param name="TLObjects">transfer listed assessed players from olv</param>
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
    internal static Player GetPlayerFromIdAndPosition (ulong pid, PlayerPosition pos)
    {
      var xp = Deserializer.GoGetPlayerXml(pid);
      switch (pos)
      {
        case PlayerPosition.PG: return new PG(xp);
        case PlayerPosition.SG: return new SG(xp);
        case PlayerPosition.SF: return new SF(xp);
        case PlayerPosition.PF: return new PF(xp);
        case PlayerPosition.C: return new C(xp);
        default: return null;
      }
    }
    
  }
}
