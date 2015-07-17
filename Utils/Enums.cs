using System;
namespace AndreiPopescu.CharazayPlus.Utils
{
  /// <summary>
  /// category which m staff member can manage
  /// </summary>
  internal enum TrainingCategory : byte
  {
    defense = 1,
    dribling = 2,
    passing = 3,
    speed = 4,
    footwork = 5,
    rebounds = 6,
    insideShooting = 7,
    outsideShooting = 8
  }

  /// <summary>
  /// skill that can be used in the sum of skills combos for the transfer market
  /// </summary>
  public enum TransferListSkill : byte
  {
    noSkill = 0,
    defense = 1,
    freethrows = 2,
    twopoint = 3,
    threepoint = 4,
    dribling = 5,
    passing = 6,
    speed = 7,
    footwork = 8,
    rebounds = 9,
    experience=10
  }

  
  /// <summary>
  /// player skill that can be trained
  /// </summary>
  public enum Skill : byte
  {
    DEFENSE = 1,
    TWOPOINT = 2,
    THREEPOINT = 3,
    FREETHROWS = 4,
    DRIBLING = 5,
    PASSING = 6,
    SPEED = 7,
    FOOTWORK = 8,
    REBOUNDS = 9
  }

  /// <summary>
  /// 
  /// </summary>
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
      , 
    HallofFame = 10
  }

  /// <summary>
  /// 
  /// </summary>
  [Flags]
  internal enum TabType : byte
  {
    status = 1,
    skills = 2,
    position = 4
  }

  /// <summary>
  /// 
  /// </summary>
  public enum PlayerPosition : byte { PG = 0, SG = 1, SF = 2, PF = 3, C = 4, Unknown };

  /// <summary>
  /// Form is m small factor that reflects hot/cold streaks that players have on a weekly/monthly basis. 
  /// Form is updated at week update, influenced by playing time and some random, 
  /// ranges between 1 and 8. 1 equals being in a bad shape 
  /// and 8 equals that your player is feeling like he can do anything. 
  /// </summary>
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
      , 
    OnFire = 8
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
    //1. The fans are embarrassed to be m fan of the club
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
      //10. The fans are celebrating m great season
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

  /// <summary>
  /// player instance evaluation type
  /// </summary>
  internal enum Evaluation
  {
    /// <summary>
    /// before season 30, only 3 skills compose defense score
    /// </summary>
    old
      , 
    /// <summary>
    /// from 2014, 5 skills compose defense score,
    /// equal importance to offense and defense
    /// </summary>
    season30
  };
}