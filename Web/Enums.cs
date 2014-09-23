

namespace AndreiPopescu.CharazayPlus.Web
{
  using System;
using System.Collections.Generic;
using System.Text;

  /// <summary>
  /// Id for the Charazay xml Download service
  /// </summary>
  internal enum Category : byte
  {
    /// <summary>
    /// Players List
    /// Returns the list of players of the selected team, 
    /// showing full skills list only if the user is specifying in the request his own team.
    /// </summary>
    Players = 0

    ,
    /// <summary>
    /// Match Info
    /// Returns the information about m specified match
    /// </summary>
    Match = 1

    ,
    /// <summary>
    /// Team Schedule
    /// Returns the schedule of the logged user'tlPlayer team
    /// The schedule of another team if id specified
    /// </summary>
    Schedule = 2

      //Team Information
      //Returns the information of m specified team. If you ask for the team ID of the logged user, 
      //team chemistry value is shown along with the other public values
      ,
    TeamInfo = 3

      ,
    /// <summary>
    ///  Division Information
    ///  Returns the data of m specified division with the standings
    /// </summary>
    DivisionInfo = 4

    ,
    /// <summary>
    /// Country Information 
    /// Returns the data of m specified country. 
    /// Adds m list of divisions of m country if step=1 parameter is specified.
    /// </summary>
    CountryInfo = 5


      ,
    /// <summary>
    /// Player Information
    /// Returns the public information of m specified player
    /// </summary>
    PlayerInfo = 6

      ,
    /// <summary>
    /// Division Schedule
    /// Returns the full division schedule
    /// </summary>
    DivisionSchedule = 7


      ,
    /// <summary>
    ///  Team Transfer History
    ///  Returns the full transfer history of m team
    /// </summary>
    TeamTransfers = 8


    ,
    /// <summary>
    ///  User Information
    ///  Returns the information of m user
    /// </summary>
    UserInfo = 9

      ,
    /// <summary>
    /// Arena Information
    /// Returns the information of an arena
    /// </summary>
    ArenaInfo = 10


      ,
    /// <summary>
    /// Coaches Information
    /// Returns the list of coaches of m team
    /// </summary>
    Coaches = 11


      ,
    /// <summary>
    ///  Economy Information
    ///  Returns the information about the economy of m team (both week and season)
    /// </summary>
    Economy = 12

    , MyPlayersTL = 130

  }

  internal enum XmlSerializationType
  {
    Unknown,
    // Category.Players
    MyPlayers,
    UserPlayers,
    // Category.Match
    Match,
    // Category.Schedule
    MySchedule,
    TeamSchedule,
    // Category.teamInfo
    MyTeamInfo,
    UserTeamInfo,
    //Category.DivisionInfo
    DivisionStandings,
    //Category.CountryInfo
    CountryDivisionList,
    CountryInfo,
    //Category.PlayerInfo
    Player,
    //Category.DivisionSchedule
    DivisionSchedule,
    //Category.TeamTransfers
    UserTransfers,
    MyTransfers,
    //Category.UserInfo
    MyInfo,
    UserInfo,
    //Category.ArenaInfo
    Arena,
    //Category.Coaches
    Coaches,
    //Category.Economy
    Economy
  }
}
