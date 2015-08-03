using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AndreiPopescu.CharazayPlus.Web;



namespace AndreiPopescu.CharazayPlus.Data
{
  /// <summary>
  /// own team related data as received from the Charazay XML API
  /// </summary>
  public static class MyXmlTeam
  {

    //private NestedSingleton() { }

    //public static NestedSingleton Instance
    //{
    //    get { return SingletonCreator.PrivateInstance; }
    //}

    #region Behavior fields from main window

    public static Xsd2.charazayArena Arena { get { return NestedInfo._arena; } }
    public static Xsd2.charazayCountry CountryInfo { get { return NestedInfo._country; } }

    public static Xsd2.charazayTeam TeamInfo { get { return NestedMandatory._team; } }
    public static Xsd2.charazayUser UserInfo { get { return NestedMandatory._user; } }


    public static Xsd2.charazayDivision Standings { get { return NestedStandings._myDivisionStandings; } }

    public static Xsd2.match[] Schedule { get { return NestedSchedule._mySchedule; } }
    public static Xsd2.charazayRound[] DivisionSchedule { get { return NestedSchedule._myDivisionFullSchedule; } }

    public static Xsd2.charazayEconomy Economy { get { return NestedMoney._economy; } }
    public static Xsd2.charazayTransfer[] Transfers { get { return NestedMoney._myTransfers; } }

    #endregion

    // info tab
    private static class NestedInfo
    {
      static NestedInfo ( )
      {
        var objects = Utils.Deserializer.GoGetXml(new Web.XmlDownloadItem[] {
          new Web.ArenaXml(WebServiceUsers.Instance.MainUser)
          ,
          new Web.CountryDivisionListXml(WebServiceUsers.Instance.MainUser) 
        }).ToArray();
        //
        _arena = objects[0] as Xsd2.charazayArena;
        _country = objects[1] as Xsd2.charazayCountry;
      }

      internal static readonly Xsd2.charazayArena _arena;
      internal static readonly Xsd2.charazayCountry _country;
    }

    // user and team info
    private static class NestedMandatory
    {
      //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
      //static SingletonCreator() { }

      //internal static readonly NestedSingleton PrivateInstance = new NestedSingleton();

      static NestedMandatory ( )
      { //
        // mandatory first
        //
        //var downloadList = XmlDownloadItemGenerator.ProduceDownloadList(new[] { XmlSerializationType.MyInfo, XmlSerializationType.MyTeamInfo });
        //var downloadItems = downloadList.Select(x => x.DownloadItem);
        var objects =   
          //Utils.Deserializer.GoGetXml(downloadItems.ToArray())
          Utils.Deserializer.GoGetXml(
            new Web.XmlDownloadItem[] {
              new Web.MyInfoXml(WebServiceUsers.Instance.MainUser)
            , new Web.MyTeamInfoXml(WebServiceUsers.Instance.MainUser) 
        //  ,new Web.MyInfoXml(WebServiceUsers.Instance.AlternateUser)
        //  , new Web.MyTeamInfoXml(WebServiceUsers.Instance.AlternateUser) 
        //  ,new Web.MyInfoXml(WebServiceUsers.Instance.SecondTeamUser)
        //  , new Web.MyTeamInfoXml(WebServiceUsers.Instance.SecondTeamUser) 
        })
        .ToArray();
        //
        
        //
        _user = objects[0] as Xsd2.charazayUser;
        _team = (Xsd2.charazayTeam)objects[1];
      }


      internal static readonly Xsd2.charazayTeam _team;
      internal static readonly Xsd2.charazayUser _user;

    }

    // my division standings
    private static class NestedStandings
    {

      static NestedStandings ( )
      {
        var objects = Utils.Deserializer.GoGetXml(new Web.XmlDownloadItem[] {
           new Web.DivisionStandingsXml(WebServiceUsers.Instance.MainUser)
        }).ToArray();
        //
        _myDivisionStandings = (Xsd2.charazayDivision)objects[0];
      }

      internal static readonly Xsd2.charazayDivision _myDivisionStandings;
    }

    // my Schedule tab (comes from Schedule)
    // my Division tab (comes from DivisionSchedule)
    private static class NestedSchedule
    {
      internal static readonly Xsd2.match[] _mySchedule;
      internal static readonly Xsd2.charazayRound[] _myDivisionFullSchedule;

      static NestedSchedule ( )
      {
        var objects = Utils.Deserializer.GoGetXml(new Web.XmlDownloadItem[] 
        {
          new Web.MyScheduleXml(WebServiceUsers.Instance.MainUser)
          ,
          new Web.DivisionScheduleXml(WebServiceUsers.Instance.MainUser)
        }).ToArray();
        //
        _mySchedule = (Xsd2.match[])objects[0];
        _myDivisionFullSchedule = (Xsd2.charazayRound[])objects[1];
      }
    }


    // money
    private static class NestedMoney
    {
      internal static readonly Xsd2.charazayEconomy _economy;
      internal static readonly Xsd2.charazayTransfer[] _myTransfers;

      static NestedMoney ( )
      {
        var objects = Utils.Deserializer.GoGetXml(new Web.XmlDownloadItem[] {
          new Web.EconomyXml(WebServiceUsers.Instance.MainUser)
        ,new Web.MyTransfersXml(WebServiceUsers.Instance.MainUser)
        }).ToArray();
        //
        _economy = objects[0] as Xsd2.charazayEconomy;
        _myTransfers = objects[1] as Xsd2.charazayTransfer[];

      }
    }

  }
}
