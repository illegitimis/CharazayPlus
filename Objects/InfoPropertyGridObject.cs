using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using AndreiPopescu.CharazayPlus.Utils;

namespace AndreiPopescu.CharazayPlus.Objects
{
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



    [Browsable(true), Description("arena"), Category("arena"), ReadOnly(true)]
    public uint ArenaId { get { return _arena.id; } }
    [Browsable(true), Description("arena"), Category("arena"), ReadOnly(true)]
    public string ArenaName { get { return _arena.name; } }
    [Browsable(true), Description("arena"), Category("arena"), ReadOnly(true)]
    public uint Spectators { get { return _arena.spectators; } }
    [Browsable(true), Description("arena"), Category("arena"), ReadOnly(true)]
    public uint Vips { get { return _arena.vips; } }

   [Browsable(true), Description("Currently logged on user"), Category("User"), ReadOnly(true), TypeConverter(typeof(ICharazayUserTypeConverter))]
    public CharazayUserModel CurrentUser { get { return new CharazayUserModel(this._user); } }

    [Browsable(true), Description(""), Category("Team"), ReadOnly(true)]
    public uint TeamId { get { return _team.id; } }
    //[Browsable(true), Description(""), Category("Team"), ReadOnly(true)]
    //public string CupRank { get { return team.cuprank; } }
    
    [Browsable(true), Description(""), Category("Team"), ReadOnly(true)]
    public string TeamName { get { return  System.Xml.XmlConvert.DecodeName(_team.name); } }

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

    #region NT coaches xsd2.user type converted

    [Browsable(true), Description(""), Category("NT Coaches"), ReadOnly(true), TypeConverter(typeof(ICharazayUserTypeConverter))]
    public CharazayUserModel U18Coach { get { return new CharazayUserModel(_country.country_info.u18ntcoach.user); } }

    [Browsable(true), Description(""), Category("NT Coaches"), ReadOnly(true), TypeConverter(typeof(ICharazayUserTypeConverter))]
    public CharazayUserModel U21Coach { get { return new CharazayUserModel(_country.country_info.u21ntcoach.user); } }
    
    [Browsable(true), Description(""), Category("NT Coaches"), ReadOnly(true), TypeConverter(typeof(ICharazayUserTypeConverter))]
    public CharazayUserModel UNtCoach { get { return new CharazayUserModel(_country.country_info.ntcoach.user); } }
    
    #endregion

  }

  /// <summary>
  /// for nt country coaches xsd2.user type converter
  /// </summary>
  public class ICharazayUserTypeConverter : ExpandableObjectConverter
  {
    public override bool CanConvertTo (ITypeDescriptorContext context, System.Type destinationType)
    {
      if (destinationType == typeof(Xsd2.user) ||
        destinationType == typeof(Xsd2.charazayUser) ||
        destinationType == typeof(CharazayUserModel) )
        return true;

      return base.CanConvertTo(context, destinationType);
    }

    public override object ConvertTo (ITypeDescriptorContext context,
                                   CultureInfo culture,
                                   object value,
                                   System.Type destinationType)
    {
      if (destinationType == typeof(System.String))            
      {
        if(value is CharazayUserModel)  
          return (value as CharazayUserModel).ToString();
        else if (value is Xsd2.user)
          return (value as Xsd2.user).ToString();
        else if(value is Xsd2.charazayUser)
          return (value as Xsd2.charazayUser).ToString();

      }
      return base.ConvertTo(context, culture, value, destinationType);
    }

    public override bool CanConvertFrom (ITypeDescriptorContext context, System.Type sourceType)
    {
      if (sourceType == typeof(string)) return true;
      return base.CanConvertFrom(context, sourceType);
    }

    public override object ConvertFrom (ITypeDescriptorContext context, CultureInfo culture, object value)
    {

      try
      {
        if (value is string)
        {
          return (CharazayUserModel)value;
        }
        return base.ConvertFrom(context, culture, value);
      }
      catch
      {
        throw new ArgumentException("Can not convert '" + (string)value + "' to type Xsd2.user");
      }
    }

  }

  internal class CharazayUserModel
  {
    readonly string nameField;

    readonly uint idField;

    readonly string supporterField;

    readonly uint registeredField;

    readonly uint last_activeField;

    readonly uint teamidField;

    readonly byte countryidField;

    public CharazayUserModel (Xsd2.user usr)
    {
      if (usr == null)
        return;

      this.nameField = usr.name;
      this.idField = usr.id;
      this.supporterField = usr.supporter;
      this.registeredField = usr.registered;
      this.last_activeField = usr.last_active;
      this.teamidField = usr.teamid;
      this.countryidField = usr.countryid;
    }

    public CharazayUserModel (Xsd2.charazayUser usr)
    {
      this.nameField = usr.name;
      this.idField = usr.id;
      this.supporterField = usr.supporter;
      this.registeredField = usr.registered;
      this.last_activeField = usr.last_active;
      this.teamidField = usr.teamid;
      this.countryidField = usr.countryid;
    }

    [Browsable(true), Description(""), Category("user"), ReadOnly(true)]
    public uint UserId { get { return this.idField; } }

    [Browsable(true), Description(""), Category("user"), ReadOnly(true)]
    public DateTime LastActive { get { return Compute.EstimatedDateTime(this.last_activeField); } }

    [Browsable(true), Description(""), Category("user"), ReadOnly(true)]
    public string UserName { get { return this.nameField; } }

    [Browsable(true), Description(""), Category("user"), ReadOnly(true)]
    public DateTime Registered { get { return Compute.EstimatedDateTime(this.registeredField); } }

    [Browsable(true), Description(""), Category("user"), ReadOnly(true)]
    public bool Supporter { get { return this.supporterField == "yes"; } }

    [Browsable(true), Description(""), Category("user"), ReadOnly(true)]
    public string Country
    {
      get
      {
        return Utils.Defines.Countries[this.countryidField].Name;
      }
    }

    public override string ToString ( )
    {
      return String.Format("{0},{1}", nameField,idField);
    }
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
  //        string tlPlayer = (string)value;
  //        string[] tokens = tlPlayer.Split(new char[] { ':', '|' });

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
  //      sb.AppendFormat("CountryId: {0} | Id: {1} | LastActive: {2} | Name: {3} | Registered: {4} | Supporter: {5} | LastBidByTeamId: {6}"
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
  //        string tlPlayer = (string)value;
  //        string[] tokens = tlPlayer.Split(new char[] { ':', '|' });

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
  //        string tlPlayer = (string)value;
  //        string[] tokens = tlPlayer.Split(new char[] { ':', '|' });

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
