namespace AndreiPopescu.CharazayPlus
{
  using System;
  using System.Linq;
  using BrightIdeasSoftware;
  using AndreiPopescu.CharazayPlus.Utils;
  using System.Collections.Generic;
  using AndreiPopescu.CharazayPlus.Model;

  /// <summary>
  /// The base model class for a Charazay player
  /// </summary>
  public abstract partial class Player
  {
    #region Constructors
    /// <summary>
    /// 
    /// </summary>
    protected Player ( ) { ZeroSkills(); }


    /// <summary>
    /// Explicit constructor
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="surname"></param>
    /// <param name="countryId"></param>
    /// <param name="age"></param>
    /// <param name="h"></param>
    /// <param name="w"></param>
    /// <param name="si"></param>
    /// <param name="salary"></param>
    /// <param name="form"></param>
    /// <param name="fatigue"></param>
    /// <param name="fame"></param>
    /// <param name="def"></param>
    /// <param name="ft"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="spe"></param>
    /// <param name="pas"></param>
    /// <param name="dri"></param>
    /// <param name="ftw"></param>
    /// <param name="reb"></param>
    /// <param name="exp"></param>
    protected Player
      (UInt64 id
      , string name
      , string surname
      , byte countryId
      , byte age
      , byte h
      , byte w
      , UInt64 si
      , UInt64 salary
      , byte form
      , byte fatigue
      , Fame fame
      , byte def
      , byte ft
      , byte p2
      , byte p3
      , byte spe
      , byte pas
      , byte dri
      , byte ftw
      , byte reb
      , byte exp
      )
      : this(new Xsd2.charazayPlayer()
      {
        skills = new Xsd2.charazayPlayerSkills()
        {
          defence = def,
          dribling = dri,
          experience = exp,
          footwork = ftw,
          freethrow = ft,
          passing = pas,
          rebounds = reb,
          speed = spe,
          threepoint = p3,
          twopoint = p2,
        }
        ,
        status = new Xsd2.charazayPlayerStatus()
        {
          fame = (byte)fame,
          fatigue = fatigue,
          form = form,
          salary = (uint)salary,
          si = (uint)si
        }
        ,
        basic = new Xsd2.charazayPlayerBasic()
        {
          age = age,
          height = h,
          weight = w,
          name = name,
          surname = surname,
        }
        ,
        countryid = countryId
        ,
        id = (uint)id
      }
      ) { }

    /// <summary>
    /// copy constructor
    /// </summary>
    /// <param name="p">reference player</param>
    protected Player (Player p) : this (p.BasePlayer) { }


    internal Xsd2.charazayPlayer BasePlayer { get { return m_player; } }


    /// <summary>
    /// universal constructor
    /// </summary>
    /// <param name="xsdPlayer"></param>
    protected Player (Xsd2.charazayPlayer xsdPlayer, bool isHW = false, bool isFatigue=false, bool isForm = false)
    {
      m_player = xsdPlayer;
      if (xsdPlayer.skills == null)
        return;
      //
      this.IsHW = isHW;
      this.IsFatigueFactor = isFatigue;
      this.IsFormFactor = isForm;
      //
      InitSkills();
      ActiveSkills();
    }

    /// <summary>
    /// skills only constructor
    /// </summary>
    /// <param name="xsdSkills">player skills</param>
    protected Player (Xsd2.charazayPlayerSkills xsdSkills) : this(new Xsd2.charazayPlayer() { skills = xsdSkills }) { }

    #endregion

    #region public read-only properties
    //basic
    public byte Age { get { return m_player.basic.age; } }
    /// <summary>
    /// height in cm
    /// </summary>
    public byte Height { get { return m_player.basic.height; } }
    /// <summary>
    /// weight in kg
    /// </summary>
    public double Weight { get { return (double)m_player.basic.weight; } }

    public string Name { get { return m_player.basic.name; } }
    public string Surname { get { return m_player.basic.surname; } }

    public byte Number { get { return m_player.basic.number.Value; } }
    //public bool ShowNumber {  get { return (m_player.basic.number.show == Xsd.numberShow.yes);}} 
    public bool ShowNumber { get { return (m_player.basic.number.show == "yes"); } }

    //status
    public UInt64 SkillsIndex { get { return m_player.status.si; } }
    public UInt64 Salary { get { return m_player.status.salary; } }
    public byte InjuryDays { get { return m_player.status.injured; } }
    public byte Form { get { return m_player.status.form; } }
    public byte Fatigue { get { return m_player.status.fatigue < 0 ? (byte)0 : (byte)m_player.status.fatigue; } }
    public Fame Fame { get { return (Fame)m_player.status.fame; } }

    //attributes
    //public bool TransferListed { get {return (m_player.transfer == Xsd.playerTransfer.yes);}}
    public bool TransferListed { get { return (m_player.transfer == "yes"); } }
    public bool NT { get { return (m_player.nt == /*Xsd.playerNT.yes*/"yes"); } }
    public bool U21NT { get { return (m_player.u21nt == "yes"); } }
    public bool U18NT { get { return (m_player.u18nt == "yes"); } }

    public UInt64 Id { get { return m_player.id; } }
    public ulong TeamId { get { return m_player.Teamid; } }
    public byte CountryId { get { return m_player.countryid; } }

    public bool Dl { get { return (m_player.dl == /*Xsd.playerDL.*/"yes"); } }
    internal DateTime promotedOn { get { return Compute.EstimatedDateTime(m_player.promoted_on); } }
    //internal TrainingGroup TrainingGroup { get {return } }

    #endregion

    #region Main skills
    //skills [1-19]
    [OLVColumn(DisplayIndex = 1, Tag = "Skills")]
    public byte Defence_Display { get { return (m_player == null) ? (byte)0 : m_player.skills.defence; } }
    [OLVColumn(DisplayIndex = 2, Tag = "Skills")]
    public byte Freethrows_Display { get { return (m_player == null) ? (byte)0 : m_player.skills.freethrow; } }
    [OLVColumn(DisplayIndex = 3, Tag = "Skills")]
    public byte TwoPoint_Display { get { return (m_player == null) ? (byte)0 : m_player.skills.twopoint; } }
    [OLVColumn(DisplayIndex = 4, Tag = "Skills")]
    public byte ThreePoint_Display { get { return (m_player == null) ? (byte)0 : m_player.skills.threepoint; } }
    [OLVColumn(DisplayIndex = 5, Tag = "Skills")]
    public byte Dribling_Display { get { return (m_player == null) ? (byte)0 : m_player.skills.dribling; } }
    [OLVColumn(DisplayIndex = 6, Tag = "Skills")]
    public byte Passing_Display { get { return (m_player == null) ? (byte)0 : m_player.skills.passing; } }
    [OLVColumn(DisplayIndex = 7, Tag = "Skills")]
    public byte Speed_Display { get { return (m_player == null) ? (byte)0 : m_player.skills.speed; } }
    [OLVColumn(DisplayIndex = 8, Tag = "Skills")]
    public byte Footwork_Display { get { return (m_player == null) ? (byte)0 : m_player.skills.footwork; } }
    [OLVColumn(DisplayIndex = 9, Tag = "Skills")]
    public byte Rebounds_Display { get { return (m_player == null) ? (byte)0 : m_player.skills.rebounds; } }
    [OLVColumn(DisplayIndex = 10, Tag = "Skills", AspectToStringFormat = "{0:F02}")]
    public double Defence { get { return m_dDefence; } }
    [OLVColumn(DisplayIndex = 11, Tag = "Skills", AspectToStringFormat = "{0:F02}")]
    public double Freethrows { get { return m_dFreethrows; } }
    [OLVColumn(DisplayIndex = 12, Tag = "Skills", AspectToStringFormat = "{0:F02}")]
    public double TwoPoint { get { return m_dTwoPoint; } }
    [OLVColumn(DisplayIndex = 13, Tag = "Skills", AspectToStringFormat = "{0:F02}")]
    public double ThreePoint { get { return m_dThreePoint; } }
    [OLVColumn(DisplayIndex = 14, Tag = "Skills", AspectToStringFormat = "{0:F02}")]
    public double Dribling { get { return m_dDribling; } }
    [OLVColumn(DisplayIndex = 15, Width = 60, MinimumWidth = 50, MaximumWidth = 80, Tag = "Skills", AspectToStringFormat = "{0:F02}")]
    public double Passing { get { return m_dPassing; } }
    [OLVColumn(DisplayIndex = 16, Tag = "Skills", AspectToStringFormat = "{0:F02}")]
    public double Speed { get { return m_dSpeed; } }
    [OLVColumn(DisplayIndex = 17, Tag = "Skills", AspectToStringFormat = "{0:F02}")]
    public double Footwork { get { return m_dFootwork; } }
    [OLVColumn(DisplayIndex = 18, Tag = "Skills", AspectToStringFormat = "{0:F02}")]
    public double Rebounds { get { return m_dRebounds; } }
    [OLVColumn(DisplayIndex = 19, Tag = "Skills")]
    public byte Experience
    {
      get
      {
        return (m_player == null || m_player.skills == null)
          ? (byte)Math.Floor(m_dExperience)
          : m_player.skills.experience;
      }
    }
    #endregion

    #region switches
    /// <summary>
    /// take form into consideration when computing active skills ?
    /// </summary>
    public bool IsFormFactor { get; set; }

    /// <summary>
    /// take fatigue into consideration when computing active skills ?
    /// </summary>
    public bool IsFatigueFactor { get; set; }
   
    /// <summary>
    /// height impact on shooting score, default true
    /// </summary>
    public bool IsPositionHeightAdequacy { get; set; }

    /// <summary>
    /// height and weight impact on active skills
    /// </summary>
    public bool IsHW { get; set; }
    #endregion

    #region Implemented public properties

    #region Inferences
    /// <summary>
    /// Body Mass Index
    /// </summary>
    /// <remarks>
    ///  (BMI) is m relationship between weight and height that is associated with body fat.
    /// The equation is BMI = body weight in kilograms / height in meters squared.
    /// </remarks>
    public double BMI { get { return (double)Weight / (Math.Pow((double)Height / 100d, 2d)); } }
    /// <summary>
    /// 
    /// </summary>
    public bool IsInsideShooter { get { return (TwoPoint >= ThreePoint); } }

    internal PositionHeight HeightForPosition
    {
      get
      {
        return (Height > MaximumHeight) ? PositionHeight.TooTall
          : ((Height < MinimumHeight) ? PositionHeight.TooShort
          : PositionHeight.Adequate);
      }
    }

    internal ShooterPosition ShootingPosition
    {
      get
      {
        if (TwoPoint == ThreePoint)
          return ShooterPosition.Normal;
        else
        {
          //double delta = Math.Abs(TwoPoint - ThreePoint);
          //double max = Math.Max(TwoPoint, ThreePoint);
          double min = Math.Min(TwoPoint, ThreePoint);

          if (min < 4)
          {
            return IsInsideShooter ? ShooterPosition.MostInside : ShooterPosition.MostOutside;
          }
          else if (min >= 4 && min < 7)
          {
            return IsInsideShooter ? ShooterPosition.MoreInside : ShooterPosition.MoreOutside;
          }
          else
          {
            //(TwoPoint >= 7 && ThreePoint >= 7)
            return ShooterPosition.Normal;
          }
        }

      }
    }

    public /*PlayerPosition*/ ST_PlayerPositionEnum PositionHeightBased
    {
      get
      {
        return Extensions.PlayerExtensions.MostAdequatePositionForHeight(this.Height);
      }
    }

    /// <summary>
    /// Method returns an enumerable of future court positions suitable for the player
    /// considering his height and yearly juniors height raise
    /// </summary>
    public ST_PlayerPositionEnum[] FuturePositionsHeightBased
    {
      get
      {
        return Extensions.PlayerExtensions.PotentialPositionsForAgeAndHeight (this.Age, this.Height).ToArray();
      }
    }


    public bool Injury { get { return InjuryDays != 0; } }
       
    #endregion

    #region User Interface ItemValues
    [OLVColumn(DisplayIndex = 0, IsEditable = false, Width = 130, MinimumWidth = 100, MaximumWidth = 200, Tag = "Position|Status|Skills")]
    public string FullName { get { return string.Format("{0} {1}", Name, Surname); } }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [OLVColumn(DisplayIndex = 20, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Tag = "Position", AspectToStringFormat = "{0:F02}")]
    public virtual double DefensiveScore
    {
      get
      {
        return Linear.DotVectorProduct_Normalized(
          new double[] { PercentageDefense_Defence, PercentageDefense_Footwork, PercentageDefense_Speed }
        , new double[] { m_dDefence, m_dFootwork, m_dSpeed });
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [OLVColumn(DisplayIndex = 21, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Tag = "Position", AspectToStringFormat = "{0:F02}")]
    public double OffensiveAbilityScore
    {
      get
      {
        return Linear.DotVectorProduct_Normalized(
          new double[] { PercentageOffensiveAbility_Dribbling, PercentageOffensiveAbility_Passing, PercentageOffensiveAbility_Footwork, PercentageOffensiveAbility_Speed }
          , new double[] { m_dDribling, m_dPassing, m_dFootwork, m_dSpeed });
      }
    }

    /// <summary>
    /// 
    /// </summary>
    [OLVColumn(DisplayIndex = 22, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Tag = "Position", AspectToStringFormat = "{0:F02}")]
    public double ShootingScore
    {
      get
      {
        int index = (int)ShootingPosition;
        double shootingScore = Linear.DotVectorProduct_Normalized(
          Defines.ShootingPositionPercentages[index]
          , new double[] { m_dFreethrows, m_dTwoPoint, m_dThreePoint });

        return (IsPositionHeightAdequacy) 
          ? shootingScore * HeightShootingInfluence()
          : shootingScore;
      }
    }

    [OLVColumn(DisplayIndex = 23, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Tag = "Position", AspectToStringFormat = "{0:F02}")]
    public double OffensiveScore
    {
      get
      {
        return Linear.DotVectorProduct_Normalized(
          new double[] { PercentageOffense_OffensiveAbility, PercentageOffense_Shooting }
          , new double[] { OffensiveAbilityScore, ShootingScore });
      }
    }

    /// <summary>
    /// Rebound + Defence : helps taking defensive rebounds.
    /// </summary>
    [OLVColumn(DisplayIndex = 24, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Tag = "Position", AspectToStringFormat = "{0:F02}")]
    public double DefensiveReboundsScore
    {
      get
      {
        return Linear.DotVectorProduct_Normalized(
          new double[] { DefensiveRebounds_ReboundsPercentage, DefensiveRebounds_DefensePercentage }
        , new double[] { m_dRebounds, m_dDefence });
      }
    }
    /// <summary>
    /// Rebound + Footwork : helps taking offensive rebounds.
    /// </summary>
    [OLVColumn(DisplayIndex = 25, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Tag = "Position", AspectToStringFormat = "{0:F02}")]
    public double OffensiveReboundsScore
    {
      get
      {
        return Linear.DotVectorProduct_Normalized(
          new double[] { OffensiveRebounds_ReboundsPercentage, OffensiveRebounds_FootworkPercentage }
        , new double[] { m_dRebounds, m_dFootwork });
      }
    }

    /// <summary>
    /// 
    /// </summary>
    [OLVColumn(DisplayIndex = 26, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Tag = "Position", AspectToStringFormat = "{0:F02}")]
    public double ReboundScore
    {
      get
      {
        return Linear.DotVectorProduct_Normalized(
          new double[] { ReboundScore_OffensiveReboundsPercentage, ReboundScore_DefensiveReboundsPercentage }
          , new double[] { OffensiveReboundsScore, DefensiveReboundsScore });
      }
    }

    /// <summary>
    /// General measure for the modeled player value
    /// </summary>
    [OLVColumn(DisplayIndex = 27, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Tag = "Position", AspectToStringFormat = "{0:F02}")]
    public double TotalScore
    {
      get
      {
        return Linear.DotVectorProduct_Normalized(
          new double[] { PercentageTotalScore_Defense, PercentageTotalScore_Offense, PercentageTotalScore_Rebounds }
          , new double[] { DefensiveScore, OffensiveScore, ReboundScore });
      }
    }
    
    /// <summary>
    /// age/value factor or value index
    /// overridden for position classes, identical for 2014 classes
    /// </summary>
    [OLVColumn(DisplayIndex = 28, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Tag = "Position", AspectToStringFormat = "{0:F02}")]
    public abstract double ValueIndex { get; }
        
    /// <summary>
    /// 
    /// </summary>
    [OLVColumn(DisplayIndex = 29, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Tag = "Position", AspectToStringFormat = "{0:F02}")]
    public abstract double TransferMarketValue { get; }

    public override string ToString ( )
    {
      return string.Format("{6,20} D:{0,-10:F02}Oa:{1,-10:F02}Sh:{2,-10:F02}O:{3,-10:F02}R:{4,-10:F02}T:{5,-10:F02}"
      , DefensiveScore, OffensiveAbilityScore, ShootingScore, OffensiveScore, ReboundScore, TotalScore, Surname);
    }
    #endregion
    #endregion

    #region Fields

    #region Active skills
    /// <summary>
    /// real values to be displayed
    /// an estimation of the real values taken into account by game simulator
    /// </summary>
    internal double m_dDefence;
    internal double m_dFreethrows;
    internal double m_dTwoPoint;
    internal double m_dThreePoint;
    internal double m_dDribling;
    internal double m_dPassing;
    internal double m_dSpeed;
    internal double m_dFootwork;
    internal double m_dRebounds;
    internal double m_dExperience;

    #endregion
    /// <summary>
    /// deserialized xsd object
    /// </summary>
    protected Xsd2.charazayPlayer m_player;

    #endregion

    #region Implemented protected properties
    // have been not declared as Defines const since might be considered as 
    // position dependent in the future
    protected double OffensiveRebounds_ReboundsPercentage { get { return 0.75; } }
    protected double OffensiveRebounds_FootworkPercentage { get { return 0.25; } }
    protected double DefensiveRebounds_ReboundsPercentage { get { return 0.9; } }
    protected double DefensiveRebounds_DefensePercentage { get { return 0.1; } }

    protected double ReboundScore_DefensiveReboundsPercentage { get { return 0.6; } }
    protected double ReboundScore_OffensiveReboundsPercentage { get { return 0.4; } }

    /// <summary>
    /// gets training week index [0-288] from player age and from charazay date (season, week)
    /// <example> age: 15 week:1 => index:0, age: 15 w:17 - index:16, age: 16 w:0  - idx:17</example>
    /// </summary>
    protected int TrainingWeekIndex
    {
      get
      {
        CharazayDate cd = DateTime.Now;
        // ON last day of last week of season players age, yet season remains current
        int week = (cd.IsLastSeasonDay) 
          ? Defines.WeeksInSeason * ((Age - 1) - Defines.RookieAge) + cd.Week - 1
          : Defines.WeeksInSeason * (Age - Defines.RookieAge) + cd.Week - 1;

        return Math.Min(week, Defines.MaxArrayWeekIndex);        
      }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Active skills measures the effect of height, bmi, fatigue, form, experience on skills
    /// </summary>
    /// <remarks>
    /// In addition, height and BMI play m role in the effectiveness of players.
    /// The difference between the players' heights can affect shooting accuracy 
    /// (the taller player will have an easier time shooting and will give m shorter player problems when they shoot)
    /// The skills used in the engine after the impact of height, weight, BMI and form on players are called active skills.
    /// </remarks>
    protected internal void ActiveSkills ( )
    {
      if (IsHW)
      {
        // 1) Big Height increases footwork and rebound but decrease dribbling
        // 2) Small Height increases dribbling but decreases footwork and rebound
        //double heightDelta = (double)(Defines.ActiveHeight - Height);
        double heightDelta = (double)(this.AverageHeight - this.Height);
        m_dDribling += heightDelta * Defines.HeightDribblingScaleFactor;
        m_dFootwork -= heightDelta * Defines.HeightFootworkScaleFactor;
        m_dRebounds -= heightDelta * Defines.HeightReboundsScaleFactor;

        // 3) Big Weight lowers speed
        //if (Weight > Defines.ActiveWeight)
        if (this.Weight > this.AverageWeight)
        {
          double weightDelta = (double)(this.Weight - this.AverageWeight);
          m_dSpeed -= weightDelta * Defines.WeightSpeedScaleFactor;
        }

        // 4) Big BMI lowers speed and increases footwork
        if (this.BMI > this.AverageBMI)
        {
          m_dFootwork += (this.BMI - this.AverageBMI);
          m_dSpeed -= (this.BMI - this.AverageBMI);
        }
        // low bmi is a gamble
        //if (BMI < MinimumBMI)
        //{
        //  m_dFootwork -= (MinimumBMI - BMI) * 0.5;
        //  m_dSpeed += (MinimumBMI - BMI) * 0.33;
        //}
      }

      //experience gain
      double exp = Math.Max(m_dExperience, Experience);
      if (exp > 0.000001d)
      {
        double dGain = Compute.ExperienceGain(exp);
        m_dDefence += dGain;
        m_dFreethrows += dGain;
        m_dTwoPoint += dGain;
        m_dThreePoint += dGain;
        m_dDribling += dGain;
        m_dPassing += dGain;
        m_dSpeed += dGain;
        m_dFootwork += dGain;
        m_dRebounds += dGain;
      }

      if (IsFormFactor && Form != Defines.DefaultForm)
      {
        //form influences all
        //Form determines how your player is feeling himself at that time.
        double dForm = (double)(Form - Defines.DefaultForm) / Defines.FormScaleFactor;
        m_dDefence += dForm * (double)Defence;
        m_dFreethrows += dForm * (double)Freethrows;
        m_dTwoPoint += dForm * (double)TwoPoint;
        m_dThreePoint += dForm * (double)ThreePoint;
        m_dDribling += dForm * (double)Dribling;
        m_dPassing += dForm * (double)Passing;
        m_dSpeed += dForm * (double)Speed;
        m_dFootwork += dForm * (double)Footwork;
        m_dRebounds += dForm * (double)Rebounds;
      }

      if (IsFatigueFactor && Fatigue != 0)
      {
        // fatigue downsides all
        // gets m percent of all skills
        // should always be appied last
        double fatigueScaleFactor = 100d - (double)Fatigue / 100d;
        m_dDefence *= fatigueScaleFactor;
        m_dFreethrows *= fatigueScaleFactor;
        m_dTwoPoint *= fatigueScaleFactor;
        m_dThreePoint *= fatigueScaleFactor;
        m_dDribling *= fatigueScaleFactor;
        m_dPassing *= fatigueScaleFactor;
        m_dSpeed *= fatigueScaleFactor;
        m_dFootwork *= fatigueScaleFactor;
        m_dRebounds *= fatigueScaleFactor;
      }

      Compute.FitSkill(ref m_dDefence);
      Compute.FitSkill(ref m_dDribling);
      Compute.FitSkill(ref m_dFootwork);
      Compute.FitSkill(ref m_dFreethrows);
      Compute.FitSkill(ref m_dPassing);
      Compute.FitSkill(ref m_dRebounds);
      Compute.FitSkill(ref m_dSpeed);
      Compute.FitSkill(ref m_dThreePoint);
      Compute.FitSkill(ref m_dTwoPoint);

    }

    internal double GetScoreTrainingDelta (TrainingCategory eTC, Coach coach)
    {
      Skill skill = (Skill)eTC;
      double dSkillDelta = SkillTrainingDelta(skill, coach);
      double dFTDelta = SkillTrainingDelta(Skill.FREETHROWS, coach);

      #region score increase using player total score formula
      //switch (eTC)
      //{
      //  case TrainingCategory.defense:
      //  return dSkillDelta * PercentageDefense_Defence * TotalScorePercentageDefense;
      //  case TrainingCategory.dribling:
      //  return dSkillDelta * PercentageOffensiveAbility_Dribbling * TotalScorePercentageOffense;
      //  case TrainingCategory.passing:
      //  return dSkillDelta * PercentageOffensiveAbility_Passing * TotalScorePercentageOffense;
      //  case TrainingCategory.speed:
      //  return dSkillDelta * (PercentageDefense_Speed * TotalScorePercentageDefense
      //                       + PercentageOffensiveAbility_Speed * TotalScorePercentageOffense);
      //  case TrainingCategory.footwork:
      //  return dSkillDelta * (PercentageDefense_Footwork * TotalScorePercentageDefense +
      //    PercentageOffensiveAbility_Footwork * TotalScorePercentageOffense);
      //  case TrainingCategory.rebounds:
      //  return dSkillDelta * TotalScorePercentageRebounds *
      //    (ReboundScore_DefensiveReboundsPercentage * DefensiveRebounds_ReboundsPercentage +
      //    ReboundScore_OffensiveReboundsPercentage * OffensiveRebounds_ReboundsPercentage);
      //  case TrainingCategory.insideShooting:
      //  {
      //    int index = (int)ShootingPosition;
      //    return Compute.DotVectorProduct(
      //      Defines.ShootingPositionPercentages[index]
      //      , new double[] { dFTDelta, dSkillDelta, 0d }) * TotalScorePercentageShooting;
      //  }
      //  case TrainingCategory.outsideShooting:
      //  {
      //    int index = (int)ShootingPosition;
      //    return Compute.DotVectorProduct(
      //      Defines.ShootingPositionPercentages[index]
      //      , new double[] { dFTDelta, 0d, dSkillDelta }) * TotalScorePercentageShooting;
      //  }
      //  default:
      //  throw new NotSupportedException();
      //}  	 
      #endregion


      //Player increasePlayer = (Player)Activator.CreateInstance (this.GetType());
      //Player increasePlayer = (Player)Activator.CreateInstance (Position);
      Player increasePlayer = null;
      switch (PositionHeightBased)
      {
        case ST_PlayerPositionEnum.PG: increasePlayer = new PG(); break;
        case ST_PlayerPositionEnum.SG: increasePlayer = new SG(); break;
        case ST_PlayerPositionEnum.SF: increasePlayer = new SF(); break;
        case ST_PlayerPositionEnum.PF: increasePlayer = new PF(); break;
        case ST_PlayerPositionEnum.C: increasePlayer = new C(); break;
      }


      switch (eTC)
      {
        case TrainingCategory.defense:
          increasePlayer.m_dDefence = dSkillDelta; break;
        case TrainingCategory.dribling:
          increasePlayer.m_dDribling = dSkillDelta; break;
        case TrainingCategory.passing:
          increasePlayer.m_dPassing = dSkillDelta; break;
        case TrainingCategory.speed:
          increasePlayer.m_dSpeed = dSkillDelta; break;
        case TrainingCategory.footwork:
          increasePlayer.m_dFootwork = dSkillDelta; break;
        case TrainingCategory.rebounds:
          increasePlayer.m_dRebounds = dSkillDelta; break;
        case TrainingCategory.insideShooting:
          {
            increasePlayer.m_dTwoPoint = dSkillDelta;
            increasePlayer.m_dFreethrows = dFTDelta;
          } break;
        case TrainingCategory.outsideShooting:
          {
            increasePlayer.m_dThreePoint = dSkillDelta;
            increasePlayer.m_dFreethrows = dFTDelta;
          } break;
        default: throw new NotSupportedException();
      }

      return increasePlayer.TotalScore;
    }

    public double SkillTrainingDelta (Skill skill, Coach coach)
    {
      switch (skill)
      {
        case Skill.DEFENSE: return Compute.WeeklySkillRaise(coach.Defence, Defence, Age);
        case Skill.DRIBLING: return Compute.WeeklySkillRaise(coach.Dribling, Dribling, Age);
        case Skill.PASSING: return Compute.WeeklySkillRaise(coach.Passing, Passing, Age);
        case Skill.SPEED: return Compute.WeeklySkillRaise(coach.Speed, Speed, Age);
        case Skill.FOOTWORK: return Compute.WeeklySkillRaise(coach.Footwork, Footwork, Age);
        case Skill.REBOUNDS: return Compute.WeeklySkillRaise(coach.Rebounds, Rebounds, Age);
        case Skill.TWOPOINT: return Compute.WeeklySkillRaise(coach.TwoPoint, TwoPoint, Age);
        case Skill.THREEPOINT: return Compute.WeeklySkillRaise(coach.ThreePoint, ThreePoint, Age);
        case Skill.FREETHROWS: return Compute.WeeklySkillRaise(coach.Freethrows, Freethrows, Age);
        default: return 0;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private void InitSkills ( )
    {
      m_dDefence = Defence_Display;
      m_dFreethrows = Freethrows_Display;
      m_dTwoPoint = TwoPoint_Display;
      m_dThreePoint = ThreePoint_Display;
      m_dDribling = Dribling_Display;
      m_dPassing = Passing_Display;
      m_dSpeed = Speed_Display;
      m_dFootwork = Footwork_Display;
      m_dRebounds = Rebounds_Display;

      IsPositionHeightAdequacy = true;
    }

    private void ZeroSkills ( )
    {
      m_dDefence = 0.0;
      m_dFreethrows = 0.0;
      m_dTwoPoint = 0.0;
      m_dThreePoint = 0.0;
      m_dDribling = 0.0;
      m_dPassing = 0.0;
      m_dSpeed = 0.0;
      m_dFootwork = 0.0;
      m_dRebounds = 0.0;
    }


    /// <summary>
    /// small height influences shooting accuracy
    /// if taller than respective position, no influence
    /// otherwise weigh down, e.g. a PG played as a SF will shoot worse
    /// </summary>
    /// <returns>weight of height corresponding to position on shooting</returns>
    private double HeightShootingInfluence ( )
    {
      byte averageHeight = (byte)((MaximumHeight + MinimumHeight) / 2);
      return (Height > averageHeight) ? 1.0
        : 1.0 - (averageHeight - Height) / 100.0;
    }

    #endregion

    #region Abstract properties
    ///////////////////////////////////////////////////////////////////////////
    // partition the time (no weeks of skill training) per training categories
    //////////////////////////////////////////////////////////////////////////
    //POSITION            PG	SG	SF	PF	C
    //////////////////////////////////////////////////////////////////////////
    //defense     	      4	  4	  3	  3	  3
    //dribling	          3	  3	  3	  1	  0
    //passing	            4	  2	  1	  1	  2
    //speed	              4	  4	  4	  3	  2
    //footwork	          0	  0	  2	  4	  4
    //rebounds	          0	  0	  1	  4	  5
    //insideShooting	    1	  2	  2	  1	  1
    //outsideShooting	    1	  2	  1	  0	  0
    //////////////////////////////////////////////////////////////////////////
    //TOTAL               17	17	17	17	17
    //////////////////////////////////////////////////////////////////////////
    protected internal abstract byte[] TrainingPlan { get; }

    #region Skill percentages

    /// <summary>
    /// defensive ability: defense (avg 60) ftw (avg 20) spe (avg 20)
    /// </summary>
    #region Defensive
    protected abstract double PercentageDefense_Defence { get; }
    protected abstract double PercentageDefense_Speed { get; }
    protected abstract double PercentageDefense_Footwork { get; }
    #endregion

    /// <summary>
    /// capacity to get into shooting position
    /// </summary>
    #region OffensiveAbility
    protected abstract double PercentageOffensiveAbility_Dribbling { get; }
    protected abstract double PercentageOffensiveAbility_Passing { get; }
    protected abstract double PercentageOffensiveAbility_Speed { get; }
    protected abstract double PercentageOffensiveAbility_Footwork { get; }
    #endregion

    /// <summary>
    /// combination between offensive ability(avg 0.67) and shooting capacity (avg 0.33)
    /// </summary>
    #region Offense
    protected abstract double PercentageOffense_OffensiveAbility { get; }
    protected abstract double PercentageOffense_Shooting { get; }
    #endregion

    /// <summary>
    /// combination of offense(avg 60), defense(avg 30) and rebounding (10)
    /// </summary>
    #region TotalScore
    protected abstract double PercentageTotalScore_Defense { get; }
    protected abstract double PercentageTotalScore_Offense { get; }
    protected abstract double PercentageTotalScore_Rebounds { get; }
    #endregion
   
    #endregion

    /// <summary>
   /// COURT POSITION as defined by enumeration, overridden in each specialized class
   /// Works as a type discriminator
   /// </summary>
    public abstract /*PlayerPosition*/ ST_PlayerPositionEnum PositionEnum { get; }

    #region Suggested body mass index and height
    protected internal abstract byte MinimumBMI { get; }
    protected internal abstract byte MaximumBMI { get; }
    protected byte AverageBMI { get { return (byte)((UInt16)(MinimumBMI + MaximumBMI) / 2); } }
    //
    protected internal abstract byte MinimumHeight { get; }
    protected internal abstract byte MaximumHeight { get; }
    protected byte AverageHeight { get { return (byte)((UInt16)(MinimumHeight + MaximumHeight) / 2); } }
    //
    protected byte AverageWeight { get { double ah = AverageHeight / 100d; return (byte)(Math.Pow(ah, 2) * AverageBMI); } }

    #endregion

    #endregion

  }


}