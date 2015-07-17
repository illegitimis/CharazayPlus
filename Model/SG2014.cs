

namespace AndreiPopescu.CharazayPlus
{


  /// <summary>
  /// shooting guard as of 2014 game changes
  /// </summary>
  //public class SG2014 : Player2014
  public class SG2014 : SG, IPlayer2014
  {
    public SG2014 ( ) : base() { }
    public SG2014 (Xsd2.charazayPlayer xsdPlayer) : base(xsdPlayer, true, false, false) { }
    public SG2014 (Xsd2.charazayPlayer xsdPlayer, bool ishw, bool isfatigue, bool isform) : base(xsdPlayer, ishw, isfatigue, isform) { }
    public SG2014 (Xsd2.charazayPlayerSkills xsdSkills) : base(xsdSkills) { }


    public override string ToString ( ) { return string.Format("SG2014: {0}", base.ToString()); }


    /*
    *********************************************************************************************
    * Defensive potential 2012                        Defensive potential 2014
    * PG : Defence>Speed>Footwork                     PG: Defense>Speed>Dribbling=Passing>Footwork
    * SG : Defence>Speed>Footwork                     SG: Defense>Speed>Footwork=Dribbling>Passing
    **********************************************************************************************
    */
    protected override double PercentageDefense_Defence { get { return 0.45; } }
    protected override double PercentageDefense_Speed { get { return 0.29; } }
    protected override double PercentageDefense_Footwork { get { return 0.1; } }

    public double PercentageDefense_Dribling { get { return 0.1; } }
    public double PercentageDefense_Passing { get { return 0.06; } }


    /*
    *********************************************************************************************
    * Offensive potential as of 2012                  Offensive potential as of 2014
    * *******************************************************************************************
    * PG : Passing=Dribbling>Speed>Footwork          PG : Passing=Dribbling>Speed>Footwork
    * SG : Dribbling=Speed>Passing>Footwork          SG : Dribbling, Speed>Passing>Footwork
    *********************************************************************************************
    * drib eq speed, lower pas a bit
    *********************************************************************************************
    */
    protected override double PercentageOffensiveAbility_Dribbling { get { return 0.37; } }
    protected override double PercentageOffensiveAbility_Speed { get { return 0.37; } }
    protected override double PercentageOffensiveAbility_Passing { get { return 0.2; } }
    protected override double PercentageOffensiveAbility_Footwork { get { return 0.06; } }

    /*
    *********************************************************************************************
    * Total score components
    ********************************************************************************************
    * bolster off not as much as before, reb ~ same 
    **********************************************************************************************
    */
    protected override double PercentageTotalScore_Defense { get { return 0.37; } }
    protected override double PercentageTotalScore_Offense { get { return 0.57; } }
    protected override double PercentageTotalScore_Rebounds { get { return 0.06; } }

    /*
    *********************************************************************************************
    * Offensive score componets
    ********************************************************************************************
    * shooting drop from 0.5 unrealistic with shooting skill game values
    **********************************************************************************************
    */
    protected override double PercentageOffense_OffensiveAbility { get { return 0.65; } }
    protected override double PercentageOffense_Shooting { get { return 0.35; } }

    public override double DefensiveScore
    {
      get
      {
        return Utils.Linear.DotVectorProduct_Normalized(
          new double[] { 
              PercentageDefense_Defence
            , PercentageDefense_Footwork
            , PercentageDefense_Speed
            , PercentageDefense_Dribling
            , PercentageDefense_Passing 
          }
          ,
          new double[] { m_dDefence, m_dFootwork, m_dSpeed, m_dDribling, m_dPassing });
      }
    }

    /// <summary>
    /// classic players use their own stored assessed values
    /// these are averages so that position total score variance is removed
    /// </summary>
    public override double ValueIndex { get { return TotalScore / Extensions.PlayerExtensions.StoredAssessedValues[TrainingWeekIndex]; } }

  }
}
