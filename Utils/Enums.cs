using System;
namespace AndreiPopescu.CharazayPlus.Utils
{
  internal enum TrainingCategories : byte
  {
    defense = 0,
    dribling = 1,
    passing = 2,
    speed = 3,
    footwork = 4,
    rebounds = 5,
    inside_sh = 6,
    outside_sh = 7
  }

  public enum Skills : byte
  {
    sDEFENSE = 1,
    sTWOPOINT = 2,
    sTHREEPOINT = 3,
    sFREETHROWS = 4,
    sDRIBLING = 5,
    sPASSING = 6,
    sSPEED = 7,
    sFOOTWORK = 8,
    sREBOUNDS = 9
  }

  public enum Fame : byte
  {
    UnknownPlayer = 0
    ,
    BarelyKnown = 1
      ,
    DecentNotoriety = 2
      ,
    TeamPlayer = 3
      ,
    LocalSpotlight = 4
      ,
    PraisedFutureStar = 5
      ,
    CharismaPlayer = 6
      ,
    FirstPageName = 7
      ,
    SuperStar = 8
      ,
    Idol = 9
      , HallofFame = 10
  }

  [Flags]
  internal enum TabType : byte
  {
    status = 1,
    skills = 2,
    position = 4
  }

  public enum PlayerPosition : byte { PG = 0, SG = 1, SF = 2, PF = 3, C = 4, Unknown };

  //Form
  //Form is a small factor that reflects hot/cold streaks that players have on a weekly/monthly basis.
  // Form is updated at week update, it's influenced by playing time and some random, 
  //it ranges between 1 and 8. 1 equals being in a bad shape 
  // and 8 equals that your player is feeling like he can do anything. 
  public enum Form : byte
  {
    WorstShape = 1
    ,
    BadShape = 2
      ,
    SubPar = 3
      ,
    Default = 4
      ,
    OverPar = 5
      ,
    Great = 6
      ,
    Splendid = 7
      , OnFire = 8
  }

  internal enum ShooterPosition : int 
  {
    MostInside = 0
    ,
    MoreInside = 1
      ,
    Normal = 2
      ,
    MoreOutside = 3
      ,
    MostOutside = 4
  }

  /// <summary>
  /// pass or shoot?
  /// </summary>
  internal enum OffensiveType
  {
    PassMost = 0
    ,
    PassMore = 1
      ,
    Normal = 2
      ,
    ShootMore = 3
      , 
    ShootMost = 4
  }

  /// <summary>
  /// style of play on offence and defence
  /// </summary>
  internal enum Attitude
  {
    Aggressive, Normal, Conservative
  }

  internal enum OffensiveFocus
  {
    Often, Frequently, Regularly, Sometime, Rarely
  }

  internal enum FanMood : byte
  {
    //1. The fans are embarrassed to be a fan of the club
    Embarassed = 1
      //2. The fans have lost all confidence in the team
    ,
    NoConfidence = 2
      //3. The fans are losing confidence in the team
      ,
    LosingConfidence = 3
      //4. The fans think the club isn'm performing well
      ,
    Bad = 4
      //5. The fans are optimistic about the future of the team
      ,
    Future = 5
      //6. The fans are pleased with the way things are going
      ,
    Pleased = 6
      //7. The fans think the club is performing very well
      ,
    VeryWell = 7
      //8. The fans think the club is performing great
      ,
    Great = 8
      //9. The fans are proud to be part of the fan club
      ,
    Proud = 9
      //10. The fans are celebrating a great season
      , Celebrate = 10
  }

  internal enum TrainingGroup : byte { First = 1, Second = 2 }

  internal enum PositionHeight { TooShort, Adequate, TooTall }

  /// <summary>
  /// todo: fatigue for each match type
  /// </summary>
  public enum MatchType : byte
  {

    Friendly = 1
    ,
    AllStars = 2
      ,
    League = 3
      ,
    PrivateCup = 4
      ,
    NationalCup = 5
      ,
    InternationalCup = 6
      ,
    U21AllStars = 7
      ,
    U18AllStars = 8
      ,
    Scrimmage = 9

      ,
    Nt = 10
      ,
    U18Nt = 13

      ,
    ChampionsLeague = 20
      ,
    CupWinersCup = 21
      ,
    HacheybeThrophy = 22
      ,
    Exhibition = 23
      ,
    Supercup = 25

      , Unknown

  }
}