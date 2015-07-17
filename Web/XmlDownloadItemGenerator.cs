

namespace AndreiPopescu.CharazayPlus.Web
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;

  /*
   * 

  internal class UserDownloadItemTuple
  {
    public string User { get; private set; }
    public XmlDownloadItem DownloadItem { get; private set; }

    public UserDownloadItemTuple (string u, XmlDownloadItem xdi)
    {
      this.User = u;
      this.DownloadItem = xdi;
    }
  }

  /// <summary>
  /// 
  /// </summary>
  internal static class XmlDownloadItemGenerator
  {
    /// <summary>
    /// produces a list of download items per user
    /// </summary>
    /// <param name="xmlItemTypes">xml download item type enumerable</param>
    /// <param name="usr">user to authenticate on</param>
    /// <returns></returns>
    internal static IEnumerable<UserDownloadItemTuple> ProduceUserDownloadList (IEnumerable<XmlSerializationType> xmlItemTypes, CharazayUserData usr)
    {
      foreach (var xmlItemType in xmlItemTypes)
      {


        switch (xmlItemType)
        {
          case XmlSerializationType.Arena:
            yield return new UserDownloadItemTuple(usr.User, new Web.ArenaXml(usr));
            break;

          case XmlSerializationType.Coaches:
            yield return new UserDownloadItemTuple(usr.User, new Web.CoachesXml(usr));
            break;

          case XmlSerializationType.CountryDivisionList:
            yield return new UserDownloadItemTuple(usr.User, new Web.CountryDivisionListXml(usr));
            break;

          case XmlSerializationType.CountryInfo:
            yield return new UserDownloadItemTuple(usr.User, new Web.CountryInfoXml(usr));
            break;
          case XmlSerializationType.DivisionSchedule:
            yield return new UserDownloadItemTuple(usr.User, new Web.DivisionScheduleXml(usr));
            break;
          case XmlSerializationType.DivisionStandings:
            yield return new UserDownloadItemTuple(usr.User, new Web.DivisionStandingsXml(usr));
            break;
          case XmlSerializationType.Economy:
            yield return new UserDownloadItemTuple(usr.User, new Web.EconomyXml(usr));
            break;
          case XmlSerializationType.Match:
            //yield return new UserDownloadItemTuple(usr.User, new Web.MatchXml (usr));
            break;
          case XmlSerializationType.MyInfo:
            yield return new UserDownloadItemTuple(usr.User, new Web.MyInfoXml(usr));
            break;
          case XmlSerializationType.MyPlayers:
            yield return new UserDownloadItemTuple(usr.User, new Web.MyPlayersXml(usr));
            break;
          case XmlSerializationType.MySchedule:
            yield return new UserDownloadItemTuple(usr.User, new Web.MyScheduleXml(usr));
            break;
          case XmlSerializationType.MyTeamInfo:
            yield return new UserDownloadItemTuple(usr.User, new Web.MyTeamInfoXml(usr));
            break;
          case XmlSerializationType.MyTransfers:
            yield return new UserDownloadItemTuple(usr.User, new Web.MyTransfersXml(usr));
            break;
          case XmlSerializationType.Player:
            //yield return new UserDownloadItemTuple(usr.User, new Web.PlayerXml (usr));
            break;
          case XmlSerializationType.TeamSchedule:
            //yield return new UserDownloadItemTuple(usr.User, new Web.TeamScheduleXml (usr));
            break;
          case XmlSerializationType.UserInfo:
            //yield return new UserDownloadItemTuple(usr.User, new Web.UserInfoXml (usr));
            break;
          case XmlSerializationType.UserPlayers:
            //yield return new UserDownloadItemTuple(usr.User, new Web.UserPlayersXml(usr));
            break;
          case XmlSerializationType.UserTeamInfo:
            //yield return new UserDownloadItemTuple(usr.User, new Web.UserTeamInfoXml (usr));
            break;
          case XmlSerializationType.UserTransfers:
            //yield return new UserDownloadItemTuple(usr.User, new Web.UserTransfersXml (usr));
            break;
          default: break;
        }
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="xmlItemTypes">xml download item type enumerable</param>
    /// <returns></returns>
    internal static IEnumerable<UserDownloadItemTuple> ProduceDownloadList (IEnumerable<XmlSerializationType> xmlItemTypes) 
    {
      
      if (WebServiceUsers.Instance.HasMainUser)
      {
        var x = ProduceUserDownloadList(xmlItemTypes, WebServiceUsers.Instance.MainUser);
        if (WebServiceUsers.Instance.HasAlternateUser) 
        {
          x = x.Union(ProduceUserDownloadList(xmlItemTypes, WebServiceUsers.Instance.AlternateUser));
          if (WebServiceUsers.Instance.HasSecondTeamUser) 
          {
            x = x.Union(ProduceUserDownloadList(xmlItemTypes, WebServiceUsers.Instance.SecondTeamUser));
          }
        }
        return x;
      }
      return null;    
    }

  }
   * 
   */
}
