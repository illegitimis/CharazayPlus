using System;
using System.IO;
using System.Xml.Serialization;
using AndreiPopescu.CharazayPlus.Web;
using System.Collections.Generic;


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
      using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
      {
        Xsd2.charazay obj = null;

       
          obj = (Xsd2.charazay)(new XmlSerializer(typeof(Xsd2.charazay)).Deserialize(fs));
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
            // division id is a mandatory session variable
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
            //case Web.XmlSerializationType.Player:
            //  _player = obj.player;
            //  break;
            //
            case Web.XmlSerializationType.Unknown:
            default:
              throw new Exception("Deserialization return type error!");
          }

        }
     }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="xmls"></param>
    /// <returns></returns>
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
    
  }
}
