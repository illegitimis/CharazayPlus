using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using AndreiPopescu.CharazayPlus.Utils;

namespace AndreiPopescu.CharazayPlus.Objects
{
  /// <summary>
  /// property class for a transfer listed player
  /// as of 1.1.4 not used anymore
  /// </summary>
  [Obsolete]
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

    //M
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
}
