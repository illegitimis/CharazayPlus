namespace AndreiPopescu.CharazayPlus
{
  using System;
  //using System.Linq;
  using BrightIdeasSoftware;
  using AndreiPopescu.CharazayPlus.Utils;



  /// <summary>
  /// 
  /// </summary>
  public class Players<T> where T : Player
  {
    #region Fields
    /// <summary>
    /// adapted container
    /// </summary>
    private System.Collections.ArrayList m_items = new System.Collections.ArrayList();
    #endregion

    #region public properties
    public System.Collections.ArrayList Items { get { return m_items; } }
    #endregion
  }

  public enum PlayerPosition { PG = 0, SG = 1, SF = 2, PF = 3, C = 4, Unknown };

  public abstract partial class Player
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pg"></param>
    /// <param name="sg"></param>
    /// <param name="sf"></param>
    /// <param name="pf"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    public static Player Decide (PG pg, SG sg, SF sf, PF pf, C c)
    {
      double maxTotalScore = pg.TotalScore;
      Player p = pg;

      if (sg.TotalScore > maxTotalScore)
      {
        p = sg;
        maxTotalScore = sg.TotalScore;
      }

      if (sf.TotalScore > maxTotalScore)
      {
        p = sf;
        maxTotalScore = sf.TotalScore;
      }

      if (pf.TotalScore > maxTotalScore)
      {
        p = pf;
        maxTotalScore = pf.TotalScore;
      }

      if (c.TotalScore > maxTotalScore)
      {
        p = c;
        maxTotalScore = c.TotalScore;
      }

      return p;
    }

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
    {
      // Name = name;
      //Surname = surname;
      //CountryId = countryId;
      //Age = age;
      //Height = h;
      //Weight = w;
      //SkillsIndex = si;
      //Salary = salary;
      //Form = form;
      //Fatigue = fatigue;
      //Fame = fame;
      //Defence = def;
      //Freethrows = ft;
      //TwoPoint = p2;
      //ThreePoint = p3;
      //Speed = spe;
      //Passing = pas;
      //Dribling = dri;
      //Footwork = ftw;
      //Rebounds = reb;
      //Experience = exp;

      InitSkills();
      ActiveSkills();
    }

    /// <summary>
    /// copy constructor
    /// </summary>
    /// <param name="p">reference player</param>
    protected Player (Player p) { throw new NotImplementedException(); }

#if XSD2
      internal Xsd2.charazayPlayer BasePlayer { get { return m_player; } }
#elif XSDMERGE
    internal XsdMerge.player BasePlayer { get { return m_player; } }
#else
#endif
    

#if XSD2
      protected Player (Xsd2.charazayPlayer xsdPlayer)      
#elif XSDMERGE
    protected Player (XsdMerge.player xsdPlayer)    
#else
#endif
    {
      m_player = xsdPlayer;
      InitSkills();
      ActiveSkills();
    }

    public Type PositionType { get; set; }
    public abstract PlayerPosition PositionEnum { get; }
     
    // 15 1  - 0
    // 15 17 - 16
    // 16 0  - 17
    protected int StoredAssessedIndex
    {
      get
      {
        CharazayDate cd = DateTime.Now;
        // last week of current season
        int week = 17 * (Age - 15) + cd.Week - 1;
        week = Math.Min(week, 288);
        return week;
      }
    }

    public Type PositionHeightBased
    {
      get
      {
        byte minHeightDifference = (byte)Math.Abs(Height - Defines.AverageHeightPg);
        Type t = typeof(PG);

        byte heightDelta = (byte)Math.Abs(Height - Defines.AverageHeightSg);
        if (heightDelta < minHeightDifference)
        {
          minHeightDifference = heightDelta;
          t = typeof(SG);
        }

        heightDelta = (byte)Math.Abs(Height - Defines.AverageHeightSf);
        if (heightDelta < minHeightDifference)
        {
          minHeightDifference = heightDelta;
          t = typeof(SF);
        }

        heightDelta = (byte)Math.Abs(Height - Defines.AverageHeightPf);
        if (heightDelta < minHeightDifference)
        {
          minHeightDifference = heightDelta;
          t = typeof(PF);
        }

        heightDelta = (byte)Math.Abs(Height - Defines.AverageHeightC);
        if (heightDelta < minHeightDifference)
        {
          minHeightDifference = heightDelta;
          t = typeof(C);
        }

        return t;
      }
    }

#if XSD2
      protected Player (Xsd2.charazayPlayerSkills xsdSkills)
      {
        m_player = new Xsd2.charazayPlayer();
#elif XSDMERGE
    protected Player(XsdMerge.skills xsdSkills)
    {
        m_player = new XsdMerge.player();
#else
#endif
        m_player.skills = xsdSkills;
        InitSkills();
        ActiveSkills();
    }

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
    public byte Fatigue { get { return m_player.status.fatigue; } }
    public Fame Fame { get { return (Fame)m_player.status.fame; } }

    //attributes
    //public bool TransferListed { get {return (m_player.transfer == Xsd.playerTransfer.yes);}}
    public bool TransferListed { get { return (m_player.transfer == "yes"); } }
    public bool NT { get { return (m_player.nt == /*Xsd.playerNT.yes*/"yes"); } }
    public bool U21NT { get { return (m_player.u21nt == "yes"); } }
    public bool U18NT { get { return (m_player.u18nt == "yes"); } }

    public UInt64 Id { get { return m_player.id; } }
    public ulong TeamId { get { return 
#if XSD2
    m_player.Teamid
#elif XSDMERGE
        m_player.teamid
#else
#endif        
        ; } }
    public byte CountryId { get { return m_player.countryid; } }

    public bool Dl { get { return (m_player.dl == /*Xsd.playerDL.*/"yes"); } }
    internal DateTime promotedOn { get { return Compute.EstimatedDateTime(m_player.promoted_on); } }
    //internal TrainingGroup TrainingGroup { get {return } }
    
    #endregion

    /// <summary>
    /// integer values diplayed on web page are internal values from Xsd.skills
    /// these will be active skills values
    /// </summary>
    #region Main skills
    //skills
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
    #endregion

    #region switches
    public bool IsFormFactor { get; set; }
    public bool IsFatigueFactor { get; set; }
    /// <summary>
    /// height impact on shooting score
    /// </summary>
    public bool IsPositionHeightAdequacy { get; set; }
    /// <summary>
    /// height & weight impact on active skills
    /// </summary>
    public bool IsHW { get; set; }
    #endregion

    //string m_strPosition;
    //string m_str2ndPosition;



    #region Implemented public properties

    #region Inferences
    /// <summary>
    /// Body Mass Index
    /// </summary>
    /// <remarks>
    ///  (BMI) is a relationship between weight and height that is associated with body fat.
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

    [OLVColumn(DisplayIndex = 0, IsEditable = false, Width = 130, MinimumWidth = 100, MaximumWidth = 200
      , Tag = "Position|Status|Skills")]
    public string FullName { get { return string.Format("{0} {1}", Name, Surname); } }

    public bool Injury { get { return InjuryDays != 0; } }
    #endregion

    #region User Interface Values
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
    /// 
    /// </summary>
    /// <returns></returns>
    [OLVColumn(DisplayIndex = 20, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Tag = "Position", AspectToStringFormat = "{0:F02}")]
    public double DefensiveScore
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

        return (IsPositionHeightAdequacy) ? shootingScore * HeightShootingInfluence()
            : shootingScore;
      }
    }
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

    public double ValueIndex
    {
      get
      {
        return TotalScore / StoredAssessedValues [StoredAssessedIndex];
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="price"></param>
    /// <returns></returns>
    public double Profitability (double price)
    {
      // price in millions
      price /= Math.Pow(10, 6);
      return 10 * Math.Pow(ValueIndex, 5) / price;
    }


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
#if XSD2
      protected Xsd2.charazayPlayer m_player;
#elif XSDMERGE
    protected XsdMerge.player m_player;
#else
#endif
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
    #endregion

    #region Methods
    /************************************************************
     * effect of height, bmi, fatigue, form, experience on skills
     *Active skills
     *In addition, height and BMI play a role in the effectiveness of players.
     * The difference between the players' heights can affect shooting accuracy 
     * (the taller player will have an easier time shooting and will give a shorter player problems when they shoot)
     * The skills used in the engine after the impact of height, weight, BMI and form on players are called active skills.     
*************************************************************/
    protected internal void ActiveSkills ( )
    {
      if (IsHW)
      {
        //Big Height increases footwork and rebound but decrease dribbling
        //Small Height increases dribbling but decreases footwork and rebound
        double heightDelta = (double)(Defines.ActiveHeight - Height);
        m_dDribling += heightDelta * Defines.HeightDribblingScaleFactor;
        m_dFootwork -= heightDelta * Defines.HeightFootworkScaleFactor;
        m_dRebounds -= heightDelta * Defines.HeightReboundsScaleFactor;

        //Big Weight lowers speed
        if (Weight > Defines.ActiveWeight)
        {
          double weightDelta = (double)(Weight - Defines.ActiveWeight);
          m_dSpeed -= weightDelta * Defines.WeightSpeedScaleFactor;
        }

        // Big BMI lowers speed and increases footwork
        // low bmi is a gamble
        if (BMI > MaximumBMI)
        {
          m_dFootwork += (BMI - MaximumBMI);
          m_dSpeed -= (BMI - MaximumBMI);
        }
        if (BMI < MinimumBMI)
        {
          m_dFootwork -= (MinimumBMI - BMI) * 0.5;
          m_dSpeed += (MinimumBMI - BMI) * 0.33;
        }
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
        // gets a percent of all skills
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

    }

    internal double GetScoreTrainingDelta (TrainingCategories eTC, Coach coach)
    {
      Skills skill = (Skills)eTC;
      double dSkillDelta = SkillTrainingDelta(skill, coach);
      double dFTDelta = SkillTrainingDelta(Skills.sFREETHROWS, coach);

      #region score increase using player total score formula
      //switch (eTC)
      //{
      //  case TrainingCategories.defense:
      //  return dSkillDelta * PercentageDefense_Defence * TotalScorePercentageDefense;
      //  case TrainingCategories.dribling:
      //  return dSkillDelta * PercentageOffensiveAbility_Dribbling * TotalScorePercentageOffense;
      //  case TrainingCategories.passing:
      //  return dSkillDelta * PercentageOffensiveAbility_Passing * TotalScorePercentageOffense;
      //  case TrainingCategories.speed:
      //  return dSkillDelta * (PercentageDefense_Speed * TotalScorePercentageDefense
      //                       + PercentageOffensiveAbility_Speed * TotalScorePercentageOffense);
      //  case TrainingCategories.footwork:
      //  return dSkillDelta * (PercentageDefense_Footwork * TotalScorePercentageDefense +
      //    PercentageOffensiveAbility_Footwork * TotalScorePercentageOffense);
      //  case TrainingCategories.rebounds:
      //  return dSkillDelta * TotalScorePercentageRebounds *
      //    (ReboundScore_DefensiveReboundsPercentage * DefensiveRebounds_ReboundsPercentage +
      //    ReboundScore_OffensiveReboundsPercentage * OffensiveRebounds_ReboundsPercentage);
      //  case TrainingCategories.inside_sh:
      //  {
      //    int index = (int)ShootingPosition;
      //    return Compute.DotVectorProduct(
      //      Defines.ShootingPositionPercentages[index]
      //      , new double[] { dFTDelta, dSkillDelta, 0d }) * TotalScorePercentageShooting;
      //  }
      //  case TrainingCategories.outside_sh:
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
      switch (PositionHeightBased.Name)
      {
        case "PG": increasePlayer = new PG(); break;
        case "SG": increasePlayer = new SG(); break;
        case "SF": increasePlayer = new SF(); break;
        case "PF": increasePlayer = new PF(); break;
        case "C": increasePlayer = new C(); break;
      }


      switch (eTC)
      {
        case TrainingCategories.defense:
          increasePlayer.m_dDefence = dSkillDelta; break;
        case TrainingCategories.dribling:
          increasePlayer.m_dDribling = dSkillDelta; break;
        case TrainingCategories.passing:
          increasePlayer.m_dPassing = dSkillDelta; break;
        case TrainingCategories.speed:
          increasePlayer.m_dSpeed = dSkillDelta; break;
        case TrainingCategories.footwork:
          increasePlayer.m_dFootwork = dSkillDelta; break;
        case TrainingCategories.rebounds:
          increasePlayer.m_dRebounds = dSkillDelta; break;
        case TrainingCategories.inside_sh:
          {
            increasePlayer.m_dTwoPoint = dSkillDelta;
            increasePlayer.m_dFreethrows = dFTDelta;
          } break;
        case TrainingCategories.outside_sh:
          {
            increasePlayer.m_dThreePoint = dSkillDelta;
            increasePlayer.m_dFreethrows = dFTDelta;
          } break;
        default: throw new NotSupportedException();
      }

      return increasePlayer.TotalScore;
    }

    public double SkillTrainingDelta (Skills skill, Coach coach)
    {
      switch (skill)
      {
        case Skills.sDEFENSE: return Compute.WeeklySkillRaise(coach.Defence, Defence, Age);
        case Skills.sDRIBLING: return Compute.WeeklySkillRaise(coach.Dribling, Dribling, Age);
        case Skills.sPASSING: return Compute.WeeklySkillRaise(coach.Passing, Passing, Age);
        case Skills.sSPEED: return Compute.WeeklySkillRaise(coach.Speed, Speed, Age);
        case Skills.sFOOTWORK: return Compute.WeeklySkillRaise(coach.Footwork, Footwork, Age);
        case Skills.sREBOUNDS: return Compute.WeeklySkillRaise(coach.Rebounds, Rebounds, Age);
        case Skills.sTWOPOINT: return Compute.WeeklySkillRaise(coach.TwoPoint, TwoPoint, Age);
        case Skills.sTHREEPOINT: return Compute.WeeklySkillRaise(coach.ThreePoint, ThreePoint, Age);
        case Skills.sFREETHROWS: return Compute.WeeklySkillRaise(coach.Freethrows, Freethrows, Age);
        default: return 0;
      }
    }

    // partition the time per training categories
    //              pg	sg	sf	pf	c
    //defense     	4	  4	  3	  3	  3
    //dribling	    3	  3	  3	  1	  0
    //passing	      4	  2	  1	  1	  2
    //speed	        4	  4	  4	  3	  2
    //footwork	    0	  0	  2	  4	  4
    //rebounds	    0	  0	  1	  4	  5
    //inside_sh	    1	  2	  2	  1	  1
    //outside_sh	  1	  2	  1	  0	  0
    //              17	17	17	17	17
    protected internal abstract byte[] TrainingPlan { get; }

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


    // height influences shooting accuracy
    private double HeightShootingInfluence ( )
    {
      byte averageHeight = (byte)((MaximumHeight + MinimumHeight) / 2);
      return (Height > averageHeight) ? 1.0
        : 1.0 - (averageHeight - Height) / 100.0;
    }

    #endregion

    #region Abstract protected properties

    #region Skills percentages

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

    /// <summary>
    /// stored values of player development from age 15 to 32
    /// each week with training contribution
    /// </summary>
    protected abstract double[] StoredAssessedValues { get; }
    #endregion

    #region Suggested body mass index and height
    protected internal abstract byte MinimumBMI { get; }
    protected internal abstract byte MaximumBMI { get; }
    protected internal abstract byte MinimumHeight { get; }
    protected internal abstract byte MaximumHeight { get; }
    protected byte AverageHeight { get { return (byte)((decimal)(MinimumHeight + MaximumHeight) / 2m); } }
    #endregion

    #endregion

  }



}