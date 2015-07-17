
namespace AndreiPopescu.CharazayPlus
{
  /// <summary>
  /// Center as of 2014 
  //public sealed class C2014 : Player2014
  /// </summary>

  public sealed class C2014 : C, IPlayer2014
  {
    public C2014 ( ) : base() { }
    public C2014 (Xsd2.charazayPlayer xsdPlayer) : base(xsdPlayer, true, false, false) { }
    public C2014 (Xsd2.charazayPlayer xsdPlayer, bool ishw, bool isfatigue, bool isform) : base(xsdPlayer, ishw, isfatigue, isform) { }
    public C2014 (Xsd2.charazayPlayerSkills xsdSkills) : base(xsdSkills) { }


    public override string ToString ( ) { return string.Format("C2014: {0}", base.ToString()); }

    /********************************************************************************************/
    public override double DefensiveScore
    {
      get
      {
        return Utils.Linear.DotVectorProduct_Normalized(new double[] 
        { PercentageDefense_Defence, PercentageDefense_Footwork, PercentageDefense_Speed, PercentageDefense_Dribling, PercentageDefense_Passing }
          , new double[] { m_dDefence, m_dFootwork, m_dSpeed, m_dDribling, m_dPassing });
      }
    }

    public override double ValueIndex { get { 
      return TotalScore / Extensions.PlayerExtensions.StoredAssessedValues[TrainingWeekIndex]; 
    } }

    /*
    *********************************************************************************************
    * Offensive potential as of 2012                  Offensive potential as of 2014
    * *******************************************************************************************
    * C  : Footwork>Speed>Passing>Dribbling           C : Footwork>Speed>Passing>Dribbling
    **********************************************************************************************
    * footwork remain at 0.5
    * speed raise from 0.2 to 0.25
    * passing from 0.25 to 0.2, dribling constant at 0.05      
    *********************************************************************************************
    */
    protected override double PercentageOffensiveAbility_Footwork { get { return 0.5; } }
    protected override double PercentageOffensiveAbility_Speed { get { return 0.25; } }
    protected override double PercentageOffensiveAbility_Passing { get { return 0.2; } }
    protected override double PercentageOffensiveAbility_Dribbling { get { return 0.05; } }



    /* 
    *********************************************************************************************
    * Defensive potential 2012                        Defensive potential 2014
    **********************************************************************************************
    * C : Defence>Footwork>Speeds                     C: Defense>Footwork>Speed>Passing>Dribbling
    **********************************************************************************************
    * Defense from 0.6 to 0.45 > Footwork from 0.35 to 0.25 > Speed from 0.05 to 0.15
    * >Passing (new) 0.1 > Dribbling (new) 0.05
    **********************************************************************************************
    */
    protected override double PercentageDefense_Defence { get { return 0.45; } }
    protected override double PercentageDefense_Footwork { get { return 0.25; } }
    protected override double PercentageDefense_Speed { get { return 0.15; } }
    public double PercentageDefense_Passing { get { return 0.1; } }
    public double PercentageDefense_Dribling { get { return 0.05; } }



    /* 
    ********************************************************************************************* 
    * Components of total score
    *********************************************************************************************
    * defense in total from 0.3 to 0.4, eq to offense, rebs stay at 0.2
    **********************************************************************************************
    */
    protected override double PercentageTotalScore_Defense { get { return 0.4; } }
    protected override double PercentageTotalScore_Offense { get { return 0.4; } }
    protected override double PercentageTotalScore_Rebounds { get { return 0.2; } }

    protected override double PercentageOffense_OffensiveAbility { get { return 0.75; } }
    protected override double PercentageOffense_Shooting { get { return 0.25; } }

  }
}
