﻿
namespace AndreiPopescu.CharazayPlus
{
  using System;
  using System.ComponentModel;
  using System.Drawing;
  using System.Globalization;
  using System.Windows.Forms;
  using AndreiPopescu.CharazayPlus.Utils;

  /// <summary>
  /// training advice
  /// </summary>
  class TrainingAdvicePropertyGridObject
  {
    public TrainingAdvicePropertyGridObject (
      double skIncDef,
      double skIncDri,
      double skIncFtw,
      double skIncFt,
      double skIncPas,
      double skIncReb,
      double skIncSpe,
      double skInc3p,
      double skInc2p,
      double trnIncDef,
      double trnIncDri,
      double trnIncFtw,
      double trnIncIn,
      double trnIncOut,
      double trnIncPas,
      double trnIncReb,
      double trnIncSpe
      )
    {
      SkIncDefence = skIncDef;
      SkIncFreethrows = skIncFt;
      SkIncTwoPoint = skInc2p;
      SkIncThreePoint = skInc3p;
      SkIncDribling = skIncDri;
      SkIncPassing = skIncPas;
      SkIncSpeed = skIncSpe;
      SkIncFootwork = skIncFtw;
      SkIncRebounds = skIncReb;


      TrnDefence = trnIncDef;
      TrnInside = trnIncIn;
      TrnOutside = trnIncOut;
      TrnDribling = trnIncDri;
      TrnPassing = trnIncPas;
      TrnSpeed = trnIncSpe;
      TrnFootwork = trnIncFtw;
      TrnRebounds = trnIncReb;
    }


    [CategoryAttribute("Team Weekly Skill Increase"), ReadOnlyAttribute(true)]
    public double SkIncDefence { get; private set; }
    [CategoryAttribute("Team Weekly Skill Increase"),
    ReadOnlyAttribute(true)]
    public double SkIncFreethrows { get; private set; }
    [CategoryAttribute("Team Weekly Skill Increase"),
    ReadOnlyAttribute(true)]
    public double SkIncTwoPoint { get; private set; }
    [CategoryAttribute("Team Weekly Skill Increase"),
    ReadOnlyAttribute(true)]
    public double SkIncThreePoint { get; private set; }
    [CategoryAttribute("Team Weekly Skill Increase"),
    ReadOnlyAttribute(true)]
    public double SkIncDribling { get; private set; }
    [CategoryAttribute("Team Weekly Skill Increase"),
    ReadOnlyAttribute(true)]
    public double SkIncPassing { get; private set; }
    [CategoryAttribute("Team Weekly Skill Increase"),
    ReadOnlyAttribute(true)]
    public double SkIncSpeed { get; private set; }
    [CategoryAttribute("Team Weekly Skill Increase"),
    ReadOnlyAttribute(true)]
    public double SkIncFootwork { get; private set; }
    [CategoryAttribute("Team Weekly Skill Increase"),
    ReadOnlyAttribute(true)]
    public double SkIncRebounds { get; private set; }

    [CategoryAttribute("Training Score Increase "),
   ReadOnlyAttribute(true)]
    public double TrnDefence { get; private set; }
    [CategoryAttribute("Training Score Increase "),
    ReadOnlyAttribute(true)]
    public double TrnInside { get; private set; }
    [CategoryAttribute("Training Score Increase "),
    ReadOnlyAttribute(true)]
    public double TrnOutside { get; private set; }
    [CategoryAttribute("Training Score Increase "),
    ReadOnlyAttribute(true)]
    public double TrnDribling { get; private set; }
    [CategoryAttribute("Training Score Increase "),
    ReadOnlyAttribute(true)]
    public double TrnPassing { get; private set; }
    [CategoryAttribute("Training Score Increase "),
    ReadOnlyAttribute(true)]
    public double TrnSpeed { get; private set; }
    [CategoryAttribute("Training Score Increase "),
    ReadOnlyAttribute(true)]
    public double TrnFootwork { get; private set; }
    [CategoryAttribute("Training Score Increase "),
    ReadOnlyAttribute(true)]
    public double TrnRebounds { get; private set; }
  }

  /// <summary>
  /// property grid class for the info tab
  /// </summary>
  class InfoPropertyGridObject
  {
    private Xsd2.charazayArena _arena;
    private Xsd2.charazayUser _user;
    private Xsd2.charazayTeam _team;
    private Xsd2.charazayCountry _country;
    private ImageList _countriesImageList;
  
   

    /// <summary>
    /// Public properties will get posted to the grid
    /// so no need for automatic properties
    /// </summary>
    //public Xsd2.charazayArena Arena { get; private set; }
    //public Xsd2.charazayUser User { get; private set; }
    //public Xsd2.charazayTeam Team { get; private set; }
    //public Xsd2.charazayCountry Country { get; private set; }

    //public InfoPropertyGridObject(Xsd.arena arena, Xsd.user user, Xsd.team team)
    public InfoPropertyGridObject (
      Xsd2.charazayArena arena
      , Xsd2.charazayUser user
      , Xsd2.charazayTeam team
      , Xsd2.charazayCountry country
      , ImageList countries
      )
    {
      _arena = arena;
      _user = user;
      _team = team;
      _country = country;
      _countriesImageList = countries;
    }

    // HAD I USED TYPECONVERTERS
    //[ReadOnly(true)]
    //public Xsd.arena Arena { get { return _arena; } }
    //[ReadOnly(true)]
    //public Xsd.user User { get { return _user; } }
    //[ReadOnly(true)]
    //public Xsd.team Team { get { return _team; } }   

    [Browsable(true), Description("arena"), Category("arena"), ReadOnly(true)]
    public uint ArenaId { get { return _arena.id; } }
    [Browsable(true), Description("arena"), Category("arena"), ReadOnly(true)]
    public string ArenaName { get { return _arena.name; } }
    [Browsable(true), Description("arena"), Category("arena"), ReadOnly(true)]
    public uint Spectators { get { return _arena.spectators; } }
    [Browsable(true), Description("arena"), Category("arena"), ReadOnly(true)]
    public uint Vips { get { return _arena.vips; } }

    [Browsable(true), Description(""), Category("user"), ReadOnly(true)]
    public uint UserId { get { return _user.id; } }
    [Browsable(true), Description(""), Category("user"), ReadOnly(true)]
    public DateTime LastActive { get { return Compute.EstimatedDateTime(_user.last_active); } }
    [Browsable(true), Description(""), Category("user"), ReadOnly(true)]
    public string UserName { get { return _user.name; } }
    [Browsable(true), Description(""), Category("user"), ReadOnly(true)]
    public DateTime Registered { get { return Compute.EstimatedDateTime(_user.registered); } }
    [Browsable(true), Description(""), Category("user"), ReadOnly(true)]
    //public bool Supporter { get { return User.supporter == Xsd.userSupporter.yes; } }
    public bool Supporter { get { return _user.supporter == "yes"; } }

    [Browsable(true), Description(""), Category("Team"), ReadOnly(true)]
    public uint TeamId { get { return _team.id; } }
    //[Browsable(true), Description(""), Category("Team"), ReadOnly(true)]
    //public string CupRank { get { return team.cuprank; } }
    [Browsable(true), Description(""), Category("Team"), ReadOnly(true)]
    public string TeamName { get { return _team.name; } }
    [Browsable(true), Description(""), Category("Team"), ReadOnly(true)]
    public byte TeamChemistry { get { return _team.team_info.chemistry; } }
    [Browsable(true), Description(""), Category("Team"), ReadOnly(true)]
    public uint DivisionId { get { return _team.team_info.divisionid; } }
    [Browsable(true), Description(""), Category("Team"), ReadOnly(true)]
    public uint Rival { get { return _team.team_info.rival; } }

    [Browsable(true), Description(""), Category("FanClub"), ReadOnly(true)]
    public uint Fans { get { return _team.team_info.fanclub.fans; } }
    [Browsable(true), Description(""), Category("FanClub"), ReadOnly(true)]
    //public string Level { get { return Enum.GetName (typeof(Xsd.fanclubLevel), team.team_info.fanclub.level); } }
    public byte Level { get { return _team.team_info.fanclub.level; } }
    [Browsable(true), Description(""), Category("FanClub"), ReadOnly(true)]
    public string FanClubName { get { return _team.team_info.fanclub.name; } }
    [Browsable(true), Description(""), Category("FanClub"), ReadOnly(true)]
    //public string Mood { get { return Enum.GetName(typeof(Xsd.fanclubMood), team.team_info.fanclub.mood); } }
    public byte Mood { get { return _team.team_info.fanclub.mood; } }

    [Browsable(true), Description(""), Category("Training"), ReadOnly(true)]
    public string FirstGroup { get { return _team.team_info.training.group1; } }
    [Browsable(true), Description(""), Category("Training"), ReadOnly(true)]
    public string SecondGroup { get { return _team.team_info.training.group2; } }

    [Browsable(false), Description(""), Category("Country"), ReadOnly(true)]
    public string Flag { get { return _country.flag; } }
    [Browsable(true), Description(""), Category("Country"), ReadOnly(true)]
    public Image FlagImage { get { return _countriesImageList.Images[(int)_country.id - 1]; } }
    [Browsable(true), Description(""), Category("Country"), ReadOnly(true)]
    public byte CountryId { get { return _user.countryid; } }
    [Browsable(true), Description(""), Category("Country"), ReadOnly(true)]
    public string CountryName { get { return _country.name; } }
    [Browsable(true), Description(""), Category("Country"), ReadOnly(true)]
    public string IsActive { get { return _country.country_info.active; } }
    [Browsable(true), Description(""), Category("Country"), ReadOnly(true)]
    public uint NoSupporters { get { return _country.country_info.supporters; } }
    [Browsable(true), Description(""), Category("Country"), ReadOnly(true)]
    public uint NoTeams { get { return _country.country_info.teams; } }
    [Browsable(true), Description(""), Category("Country"), ReadOnly(true)]
    public uint NoUsers { get { return _country.country_info.users; } }
    [Browsable(true), Description(""), Category("Country"), ReadOnly(true)]
    public uint NoWaiting { get { return _country.country_info.waiting; } }

    /// <summary>
    /// xsd2.user type converted
    /// </summary>
    #region NT coaches
    [Browsable(true), Description(""), Category("NT Coaches"), ReadOnly(true)]
    public Xsd2.user U18Coach { get { return _country.country_info.u18ntcoach.user; } }
    [Browsable(true), Description(""), Category("NT Coaches"), ReadOnly(true)]
    public Xsd2.user U21Coach { get { return _country.country_info.u21ntcoach.user; } }
    [Browsable(true), Description(""), Category("NT Coaches"), ReadOnly(true)]
    public Xsd2.user UNtCoach { get { return _country.country_info.ntcoach.user; } }

    //[Browsable(true), Description(""), Category("U18"), ReadOnly(true)]
    //public byte U18CoachCountryId { get { return _country.country_info.u18ntcoach.user.countryid; } }
    //[Browsable(true), Description(""), Category("U18"), ReadOnly(true)]
    //public uint U18CoachId { get { return _country.country_info.u18ntcoach.user.id; } }
    //[Browsable(true), Description(""), Category("U18"), ReadOnly(true)]
    //public uint U18CoachLastActive { get { return _country.country_info.u18ntcoach.user.last_active; } }
    //[Browsable(true), Description(""), Category("U18"), ReadOnly(true)]
    //public string U18CoachName { get { return _country.country_info.u18ntcoach.user.name; } }
    //[Browsable(true), Description(""), Category("U18"), ReadOnly(true)]
    //public uint U18CoachRegistered { get { return _country.country_info.u18ntcoach.user.registered; } }
    //[Browsable(true), Description(""), Category("U18"), ReadOnly(true)]
    //public string U18CoachSupporter { get { return _country.country_info.u18ntcoach.user.supporter; } }
    //[Browsable(true), Description(""), Category("U18"), ReadOnly(true)]
    //public ushort U18CoachTeamId { get { return _country.country_info.u18ntcoach.user.teamid; } }

    //[Browsable(true), Description(""), Category("U21"), ReadOnly(true)]
    //public byte U21CoachCountryId { get { return _country.country_info.u21ntcoach.user.countryid; } }
    //[Browsable(true), Description(""), Category("U21"), ReadOnly(true)]
    //public uint U21CoachId { get { return _country.country_info.u21ntcoach.user.id; } }
    //[Browsable(true), Description(""), Category("U21"), ReadOnly(true)]
    //public uint U21CoachLastActive { get { return _country.country_info.u21ntcoach.user.last_active; } }
    //[Browsable(true), Description(""), Category("U21"), ReadOnly(true)]
    //public string U21CoachName { get { return _country.country_info.u21ntcoach.user.name; } }
    //[Browsable(true), Description(""), Category("U21"), ReadOnly(true)]
    //public uint U21CoachRegistered { get { return _country.country_info.u21ntcoach.user.registered; } }
    //[Browsable(true), Description(""), Category("U21"), ReadOnly(true)]
    //public string U21CoachSupporter { get { return _country.country_info.u21ntcoach.user.supporter; } }
    //[Browsable(true), Description(""), Category("U21"), ReadOnly(true)]
    //public ushort U21CoachTeamId { get { return _country.country_info.u21ntcoach.user.teamid; } }

    //[Browsable(true), Description(""), Category("NT"), ReadOnly(true)]
    //public byte NTCoachCountryId { get { return _country.country_info.ntcoach.user.countryid; } }
    //[Browsable(true), Description(""), Category("NT"), ReadOnly(true)]
    //public uint NTCoachId { get { return _country.country_info.ntcoach.user.id; } }
    //[Browsable(true), Description(""), Category("NT"), ReadOnly(true)]
    //public uint NTCoachLastActive { get { return _country.country_info.ntcoach.user.last_active; } }
    //[Browsable(true), Description(""), Category("NT"), ReadOnly(true)]
    //public string NTCoachName { get { return _country.country_info.ntcoach.user.name; } }
    //[Browsable(true), Description(""), Category("NT"), ReadOnly(true)]
    //public uint NTCoachRegistered { get { return _country.country_info.ntcoach.user.registered; } }
    //[Browsable(true), Description(""), Category("NT"), ReadOnly(true)]
    //public string NTCoachSupporter { get { return _country.country_info.ntcoach.user.supporter; } }
    //[Browsable(true), Description(""), Category("NT"), ReadOnly(true)]
    //public ushort NTCoachTeamId { get { return _country.country_info.ntcoach.user.teamid; } }
    #endregion

  }

  /// <summary>
  /// for nt country coaches xsd2.user type converter
  /// </summary>
  public class Xsd2CountryUserTypeConverter : ExpandableObjectConverter
  {
    public override bool CanConvertTo (ITypeDescriptorContext context, System.Type destinationType)
    {
      if (destinationType == typeof(Xsd2.user))
        return true;

      return base.CanConvertTo(context, destinationType);
    }

    public override object ConvertTo (ITypeDescriptorContext context,
                                   CultureInfo culture,
                                   object value,
                                   System.Type destinationType)
    {
      if (destinationType == typeof(System.String) && value is Xsd2.user)
      {

        Xsd2.user user = (Xsd2.user)value;
        return user.ToString();
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }

    public override bool CanConvertFrom (ITypeDescriptorContext context,
                                  System.Type sourceType)
    {
      if (sourceType == typeof(string))
        return true;

      return base.CanConvertFrom(context, sourceType);
    }

    public override object ConvertFrom (ITypeDescriptorContext context,
                                  CultureInfo culture, object value)
    {

      try
      {
        if (value is string)
        {
          return (Xsd2.user)value;
        }
        return base.ConvertFrom(context, culture, value);
      }
      catch
      {
        throw new ArgumentException("Can not convert '" + (string)value + "' to type Xsd2.user");
      }
    }

  }

  /// <summary>
  /// property class for a transfer listed player
  /// </summary>
  class TransferListedPlayerPropertyGridObject
  {
    Xsd2.charazayPlayer _plyr;


    PG _pg = null;
    SG _sg = null;
    SF _sf = null;
    PF _pf = null;
    C _c = null;

    public Player GetPlayer (PlayerPosition pos)
    {
      switch (pos)
      {
        case PlayerPosition.C: return _c;
        case PlayerPosition.PF: return _pf;
        case PlayerPosition.SF: return _sf;
        case PlayerPosition.SG: return _sg;
        case PlayerPosition.PG: return _pg;
      }

      return null;
    }

    public TransferListedPlayerPropertyGridObject (Xsd2.charazayPlayer plyr)    
    {
      _plyr = plyr;
      _pg = new PG(_plyr);
      _sg = new SG(_plyr);
      _sf = new SF(_plyr);
      _pf = new PF(_plyr);
      _c = new C(_plyr);
    }

    [Browsable(true), Description("Name"), Category("Attributes")]
    public string Name { get { return _pg.FullName; } }
    [Browsable(true), Description("Promoted On"), Category("Attributes"), ReadOnly(true)]
    public DateTime promoted { get { return _pg.promotedOn; } }
    [Browsable(true), Description("U18 National Team"), Category("Attributes"), ReadOnly(true)]
    public bool u18 { get { return _pg.U18NT; } }
    [Browsable(true), Description("U21 National Team"), Category("Attributes"), ReadOnly(true)]
    public bool u21 { get { return _pg.U21NT; } }
    [Browsable(true), Description("National Team"), Category("Attributes"), ReadOnly(true)]
    public bool nt { get { return _pg.NT; } }
    [Browsable(true), Description("Country"), Category("Attributes"), ReadOnly(true)]
    public string country { get { return Defines.Countries[_plyr.countryid].Name; } }
    [Browsable(true), Description("Age"), Category("Attributes"), ReadOnly(true)]
    public byte age { get { return _plyr.basic.age; } }
    [Browsable(true), Description("Height"), Category("Attributes"), ReadOnly(true)]
    public byte height { get { return _plyr.basic.height; } }
    [Browsable(true), Description("Weight"), Category("Attributes"), ReadOnly(true)]
    public decimal weight { get { return _plyr.basic.weight; } }
    [Browsable(true), Description("Body mass index"), Category("Attributes"), ReadOnly(true)]
    public double bmi { get { return _pg.BMI; } }

    [Browsable(true), Description("Defense"), Category("Skills"), ReadOnly(true)]
    public byte defence { get { return _plyr.skills.defence; } }
    [Browsable(true), Description("Dribbling"), Category("Skills"), ReadOnly(true)]
    public byte dribbling { get { return _plyr.skills.dribling; } }
    [Browsable(true), Description("Experience"), Category("Skills"), ReadOnly(true)]
    public byte experience { get { return _plyr.skills.experience; } }
    [Browsable(true), Description("Footwork"), Category("Skills"), ReadOnly(true)]
    public byte footwork { get { return _plyr.skills.footwork; } }
    [Browsable(true), Description("Freethrow"), Category("Skills"), ReadOnly(true)]
    public byte freethrow { get { return _plyr.skills.freethrow; } }
    [Browsable(true), Description("Passing"), Category("Skills"), ReadOnly(true)]
    public byte passing { get { return _plyr.skills.passing; } }
    [Browsable(true), Description("Defense"), Category("Skills"), ReadOnly(true)]
    public byte rebounds { get { return _plyr.skills.rebounds; } }
    [Browsable(true), Description("speed"), Category("Skills"), ReadOnly(true)]
    public byte speed { get { return _plyr.skills.speed; } }
    [Browsable(true), Description("3point"), Category("Skills"), ReadOnly(true)]
    public byte Point3 { get { return _plyr.skills.threepoint; } }
    [Browsable(true), Description("2point"), Category("Skills"), ReadOnly(true)]
    public byte Point2 { get { return _plyr.skills.twopoint; } }

    //pg
    [Browsable(true), Description("Total"), Category("Point Guard"), ReadOnly(true)]
    public double pgTotalScore { get { return _pg.TotalScore; } }
    [Browsable(true), Description("Defensive"), Category("Point Guard"), ReadOnly(true)]
    public double pgDefScore { get { return _pg.DefensiveScore; } }
    [Browsable(true), Description("Offensive"), Category("Point Guard"), ReadOnly(true)]
    public double pgOffScore { get { return _pg.OffensiveScore; } }
    [Browsable(true), Description("Offensive Ability"), Category("Point Guard"), ReadOnly(true)]
    public double pgOfAbScore { get { return _pg.OffensiveAbilityScore; } }
    [Browsable(true), Description("Shooting"), Category("Point Guard"), ReadOnly(true)]
    public double pgShScore { get { return _pg.ShootingScore; } }

    //sg
    [Browsable(true), Description("Total"), Category("Shooting Guard"), ReadOnly(true)]
    public double sgTotalScore { get { return _sg.TotalScore; } }
    [Browsable(true), Description("Defensive"), Category("Shooting Guard"), ReadOnly(true)]
    public double sgDefScore { get { return _sg.DefensiveScore; } }
    [Browsable(true), Description("Offensive"), Category("Shooting Guard"), ReadOnly(true)]
    public double sgOffScore { get { return _sg.OffensiveScore; } }
    [Browsable(true), Description("Offensive Ability"), Category("Shooting Guard"), ReadOnly(true)]
    public double sgOfAbScore { get { return _sg.OffensiveAbilityScore; } }
    [Browsable(true), Description("Shooting"), Category("Shooting Guard"), ReadOnly(true)]
    public double sgShScore { get { return _sg.ShootingScore; } }

    //sf
    [Browsable(true), Description("Total"), Category("Small Forward"), ReadOnly(true)]
    public double sfTotalScore { get { return _sf.TotalScore; } }
    [Browsable(true), Description("Defensive"), Category("Small Forward"), ReadOnly(true)]
    public double sfDefScore { get { return _sf.DefensiveScore; } }
    [Browsable(true), Description("Offensive"), Category("Small Forward"), ReadOnly(true)]
    public double sfOffScore { get { return _sf.OffensiveScore; } }
    [Browsable(true), Description("Offensive Ability"), Category("Small Forward"), ReadOnly(true)]
    public double sfOfAbScore { get { return _sf.OffensiveAbilityScore; } }
    [Browsable(true), Description("Shooting"), Category("Small Forward"), ReadOnly(true)]
    public double sfShScore { get { return _sf.ShootingScore; } }

    //pf
    [Browsable(true), Description("Total"), Category("Power Forward"), ReadOnly(true)]
    public double pfTotalScore { get { return _pf.TotalScore; } }
    [Browsable(true), Description("Defensive"), Category("Power Forward"), ReadOnly(true)]
    public double pfDefScore { get { return _pf.DefensiveScore; } }
    [Browsable(true), Description("Offensive"), Category("Power Forward"), ReadOnly(true)]
    public double pfOffScore { get { return _pf.OffensiveScore; } }
    [Browsable(true), Description("Offensive Ability"), Category("Power Forward"), ReadOnly(true)]
    public double pfOfAbScore { get { return _pf.OffensiveAbilityScore; } }
    [Browsable(true), Description("Shooting"), Category("Power Forward"), ReadOnly(true)]
    public double pfShScore { get { return _pf.ShootingScore; } }

    //c
    [Browsable(true), Description("Total"), Category("Center"), ReadOnly(true)]
    public double cTotalScore { get { return _c.TotalScore; } }
    [Browsable(true), Description("Defensive"), Category("Center"), ReadOnly(true)]
    public double cDefScore { get { return _c.DefensiveScore; } }
    [Browsable(true), Description("Offensive"), Category("Center"), ReadOnly(true)]
    public double cOffScore { get { return _c.OffensiveScore; } }
    [Browsable(true), Description("Offensive Ability"), Category("Center"), ReadOnly(true)]
    public double cOfAbScore { get { return _c.OffensiveAbilityScore; } }
    [Browsable(true), Description("Shooting"), Category("Center"), ReadOnly(true)]
    public double cShScore { get { return _c.ShootingScore; } }
  }

  #region //-- TypeConverter aborted
  ///// <summary>
  ///// 
  ///// </summary>
  //public class XsdArenaTypeConverter : ExpandableObjectConverter
  //{
  //  public override bool CanConvertTo(ITypeDescriptorContext context,
  //                                    System.Type destinationType)
  //  {
  //    if (destinationType == typeof(Xsd.arena))
  //      return true;

  //    return base.CanConvertTo(context, destinationType);
  //  }

  //  public override object ConvertTo(ITypeDescriptorContext context,
  //                                 CultureInfo culture,
  //                                 object value,
  //                                 System.Type destinationType)
  //  {
  //    if (destinationType == typeof(System.String) &&
  //         value is Xsd.arena)
  //    {

  //      Xsd.arena arena = (Xsd.arena)value;
  //      StringBuilder sb = new StringBuilder();
  //      sb.AppendFormat("Id: {0} | Name: {1} | Spectators: {2} | Vips: {3}"
  //        , arena.id, arena.name, arena.spectators, arena.vips);

  //      return sb.ToString();          
  //    }
  //    return base.ConvertTo(context, culture, value, destinationType);
  //  }

  //  public override bool CanConvertFrom(ITypeDescriptorContext context,
  //                                System.Type sourceType)
  //  {
  //    if (sourceType == typeof(string))
  //      return true;

  //    return base.CanConvertFrom(context, sourceType);
  //  }

  //  public override object ConvertFrom(ITypeDescriptorContext context,
  //                                CultureInfo culture, object value)
  //  {

  //    try
  //    {
  //      if (value is string)
  //      {
  //        string s = (string)value;
  //        string[] tokens = s.Split(new char[] { ':', '|' });

  //        Xsd.arena arena = new Xsd.arena();
  //        arena.id = uint.Parse(tokens[1].Trim());
  //        arena.name = tokens[3].Trim();
  //        arena.spectators = uint.Parse(tokens[5].Trim());
  //        arena.vips = uint.Parse(tokens[7].Trim());


  //        return arena;
  //      }
  //      return base.ConvertFrom(context, culture, value);
  //    }
  //    catch
  //    {
  //      throw new ArgumentException(
  //          "Can not convert '" + (string)value +
  //                             "' to type SpellingOptions");
  //    }
  //  }

  //}

  ///// <summary>
  ///// 
  ///// </summary>
  //public class XsdUserTypeConverter : ExpandableObjectConverter
  //{
  //  public override bool CanConvertTo(ITypeDescriptorContext context,
  //                                    System.Type destinationType)
  //  {
  //    if (destinationType == typeof(Xsd.user))
  //      return true;

  //    return base.CanConvertTo(context, destinationType);
  //  }

  //  public override object ConvertTo(ITypeDescriptorContext context,
  //                                 CultureInfo culture,
  //                                 object value,
  //                                 System.Type destinationType)
  //  {
  //    if (destinationType == typeof(System.String) &&
  //         value is Xsd.user)
  //    {

  //      Xsd.user user = (Xsd.user)value;

  //      StringBuilder sb = new StringBuilder();
  //      sb.AppendFormat("CountryId: {0} | Id: {1} | LastActive: {2} | Name: {3} | Registered: {4} | Supporter: {5} | TeamId: {6}"
  //      ,user.countryid 
  //      ,user.id
  //      ,user.last_active
  //      ,user.name
  //      ,user.registered
  //      ,user.supporter
  //      ,user.teamid 
  //      );

  //      return sb.ToString();
  //    }
  //    return base.ConvertTo(context, culture, value, destinationType);
  //  }

  //  public override bool CanConvertFrom(ITypeDescriptorContext context,
  //                                System.Type sourceType)
  //  {
  //    if (sourceType == typeof(string))
  //      return true;

  //    return base.CanConvertFrom(context, sourceType);
  //  }

  //  public override object ConvertFrom(ITypeDescriptorContext context,
  //                                CultureInfo culture, object value)
  //  {

  //    try
  //    {
  //      if (value is string)
  //      {
  //        string s = (string)value;
  //        string[] tokens = s.Split(new char[] { ':', '|' });

  //        Xsd.user user = new Xsd.user();
  //        user.countryid = byte.Parse(tokens[1].Trim());
  //        user.id = byte.Parse(tokens[3].Trim());
  //        user.last_active = tokens[5].Trim();
  //        user.name = tokens[7].Trim();
  //        user.registered = tokens[9].Trim();
  //        user.supporter = (Xsd.userSupporter)Enum.Parse(typeof(Xsd.userSupporter), tokens[11].Trim());
  //        user.teamid = uint.Parse(tokens[13]);

  //        return user;
  //      }
  //      return base.ConvertFrom(context, culture, value);
  //    }
  //    catch
  //    {
  //      throw new ArgumentException(
  //          "Can not convert '" + (string)value +
  //                             "' to type SpellingOptions");
  //    }
  //  }

  //}

  ///// <summary>
  ///// 
  ///// </summary>
  //public class XsdTeamTypeConverter : ExpandableObjectConverter
  //{
  //  public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType)
  //  {
  //    return (destinationType == typeof(Xsd.team)) ? true : base.CanConvertTo(context, destinationType);      
  //  }

  //  public override object ConvertTo(ITypeDescriptorContext context,
  //                                 CultureInfo culture,
  //                                 object value,
  //                                 System.Type destinationType)
  //  {
  //    if (destinationType == typeof(System.String) && value is Xsd.team)
  //    {
  //      Xsd.team team = (Xsd.team)value;

  //      StringBuilder sb = new StringBuilder();
  //      sb.AppendFormat("CountryId: {0} | Id: {1} | CupRank: {2} | Name: {3} | TeamInfo: {4} | UserId: {5} | UserIdSpecified: {6}"
  //        ,team.countryid
  //        ,team.id
  //        ,team.cuprank
  //        ,team.name
  //        ,team.team_info
  //        ,team.userid
  //        ,team.useridSpecified        
  //      );

  //      return sb.ToString();
  //    }
  //    return base.ConvertTo(context, culture, value, destinationType);
  //  }

  //  public override bool CanConvertFrom(ITypeDescriptorContext context, System.Type sourceType)
  //  {
  //    if (sourceType == typeof(string))
  //      return true;

  //    return base.CanConvertFrom(context, sourceType);
  //  }

  //  public override object ConvertFrom(ITypeDescriptorContext context,
  //                                CultureInfo culture, object value)
  //  {

  //    try
  //    {
  //      if (value is string)
  //      {
  //        string s = (string)value;
  //        string[] tokens = s.Split(new char[] { ':', '|' });

  //        Xsd.team team = new Xsd.team();
  //        team.countryid = byte.Parse(tokens[1].Trim());
  //        team.id = byte.Parse(tokens[3].Trim());
  //        team.cuprank = tokens[5].Trim();
  //        team.name = tokens[7].Trim();
  //        //team.team_info = (Xsd.team_info)tokens[9].Trim();
  //        team.userid = uint.Parse(tokens[11].Trim());
  //        team.useridSpecified = bool.Parse(tokens[13]);

  //        return team;
  //      }
  //      return base.ConvertFrom(context, culture, value);
  //    }
  //    catch
  //    {
  //      throw new ArgumentException(
  //          "Can not convert '" + (string)value +
  //                             "' to type SpellingOptions");
  //    }
  //  }

  //}

  ///// <summary>
  ///// 
  ///// </summary>
  //public class XsdCommonTypeConverter<T> : ExpandableObjectConverter
  //{
  //  public override bool CanConvertTo(ITypeDescriptorContext context,
  //                                    System.Type destinationType)
  //  {
  //    if (destinationType == typeof(T))
  //      return true;

  //    return base.CanConvertTo(context, destinationType);
  //  }

  //  public override object ConvertTo(ITypeDescriptorContext context,
  //                                 CultureInfo culture,
  //                                 object value,
  //                                 System.Type destinationType)
  //  {
  //    if (destinationType == typeof(int) && value is T)
  //    {
  //      T tValue = (T)value;
  //      return tValue.GetHashCode();
  //    }
  //    return base.ConvertTo(context, culture, value, destinationType);
  //  }

  //  public override bool CanConvertFrom(ITypeDescriptorContext context,
  //                                System.Type sourceType)
  //  {
  //    if (sourceType == typeof(int))
  //      return true;

  //    return base.CanConvertFrom(context, sourceType);
  //  }

  //  public override object ConvertFrom(ITypeDescriptorContext context,
  //                                CultureInfo culture, object value)
  //  {

  //    try
  //    {
  //      if (value is int)
  //      {
  //        return (T)value;
  //      }
  //      return base.ConvertFrom(context, culture, value);
  //    }
  //    catch
  //    {
  //      throw new ArgumentException(
  //          "Can not convert '" + (string)value +
  //                             "' to type SpellingOptions");
  //    }
  //  }

  //}
  #endregion
}


