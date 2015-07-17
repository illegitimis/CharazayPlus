

namespace AndreiPopescu.CharazayPlus
{

  /// <summary>
  /// Power Forward as of 2014
  /// //public class PF2 : Player2014
  /// </summary>  
  public class PF2014 : PF, IPlayer2014
  {
    public PF2014 ( ) : base() { }
    public PF2014 (Xsd2.charazayPlayer xsdPlayer) : base(xsdPlayer, true, false, false) { }
    public PF2014 (Xsd2.charazayPlayer xsdPlayer, bool ishw, bool isfatigue, bool isform) : base(xsdPlayer, ishw, isfatigue, isform) { }
    public PF2014 (Xsd2.charazayPlayerSkills xsdSkills) : base(xsdSkills) { }


    public override string ToString ( ) { return string.Format("PF2014: {0}", base.ToString()); }

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

    public override double ValueIndex { get { return TotalScore / Extensions.PlayerExtensions.StoredAssessedValues[TrainingWeekIndex]; } }

    /*
    *********************************************************************************************
    * Defensive potential 2012                       Defensive potential 2014
    * PF: Defence>Footwork>Speed                     PF: Defense>Footwork>Speed>Passing=Dribbling
    * C : Defence>Footwork>Speed                      C: Defense>Footwork>Speed>Passing>Dribbling
    **********************************************************************************************
    * almost same as centers
    **********************************************************************************************
    */
    protected override double PercentageDefense_Defence { get { return 0.44; } }
    protected override double PercentageDefense_Footwork { get { return 0.25; } }
    protected override double PercentageDefense_Speed { get { return 0.15; } }
    public double PercentageDefense_Passing { get { return 0.08; } }
    public double PercentageDefense_Dribling { get { return 0.08; } }

    /*
    *********************************************************************************************
    * Offensive potential as of 2012                   Offensive potential as of 2014
    ********************************************************************************************
    * PF : Footwork>Speed>Dribbling>Passing            PF : Footwork>Speed>Dribbling>Passing
    *********************************************************************************************
    * say my name i remain the same
    **********************************************************************************************
    */
    protected override double PercentageOffensiveAbility_Footwork { get { return 0.45; } }
    protected override double PercentageOffensiveAbility_Speed { get { return 0.3; } }
    protected override double PercentageOffensiveAbility_Dribbling { get { return 0.15; } }
    protected override double PercentageOffensiveAbility_Passing { get { return 0.1; } }

    /*
    *********************************************************************************************
    * Total score components
    ********************************************************************************************
    * a bit less defensive oriented as centers
    * def from 0.3 to 0.4, off from 0.55 to 0.45, reb same 
    **********************************************************************************************
    */
    protected override double PercentageTotalScore_Defense { get { return 0.4; } }
    protected override double PercentageTotalScore_Offense { get { return 0.45; } }
    protected override double PercentageTotalScore_Rebounds { get { return 0.15; } }

    protected override double PercentageOffense_OffensiveAbility { get { return 0.7; } }
    protected override double PercentageOffense_Shooting { get { return 0.3; } }

  }
}
