

namespace AndreiPopescu.CharazayPlus
{

  public class PG2014 : PG, IPlayer2014
  {
    //Player2014 _p;

    public PG2014 ( ) : base() { }
    public PG2014 (Xsd2.charazayPlayer xsdPlayer) : base(xsdPlayer, true, false, false) { }
    public PG2014 (Xsd2.charazayPlayer xsdPlayer, bool ishw, bool isfatigue, bool isform) : base(xsdPlayer, ishw, isfatigue, isform) { }
    public PG2014 (Xsd2.charazayPlayerSkills xsdSkills) : base(xsdSkills) { 
      //_p = new Player2014()
    }

    public override string ToString ( ) { return string.Format("PG2014: {0}", base.ToString()); }

    /*
    *********************************************************************************************
    * Offensive potential as of 2012                   Offensive potential as of 2014
    * *******************************************************************************************
    * PG : Passing=Dribbling>Speed>Footwork           PG : Passing=Dribbling>Speed>Footwork
    * SG : Dribbling, Speed>Passing>Footwork          SG : Dribbling, Speed>Passing>Footwork    
    *********************************************************************************************
    */
    protected override double PercentageOffensiveAbility_Dribbling { get { return 0.39; } }
    protected override double PercentageOffensiveAbility_Passing { get { return 0.39; } }
    protected override double PercentageOffensiveAbility_Speed { get { return 0.18; } }
    protected override double PercentageOffensiveAbility_Footwork { get { return 0.04; } }

    /*
    *********************************************************************************************
    * Defensive potential 2012                        Defensive potential 2014
    * PG : Defence>Speed>Footwork                     PG: Defense>Speed>Dribbling=Passing>Footwork
    **********************************************************************************************
    * same as SG, ftw <-> pas switch
    **********************************************************************************************
    */
    protected override double PercentageDefense_Defence { get { return 0.45; } }
    protected override double PercentageDefense_Speed { get { return 0.29; } }
    protected override double PercentageDefense_Footwork { get { return 0.06; } }

    public double PercentageDefense_Dribling { get { return 0.1; } }
    public double PercentageDefense_Passing { get { return 0.1; } }


    /*
    *********************************************************************************************
    * Total score components
    ********************************************************************************************
    * should be the most defensive
    * bolster def, not as much off as before, reb ~ same 
    **********************************************************************************************
    */
    protected override double PercentageTotalScore_Defense { get { return 0.5; } }
    protected override double PercentageTotalScore_Offense { get { return 0.47; } }
    protected override double PercentageTotalScore_Rebounds { get { return 0.03; } }

    protected override double PercentageOffense_OffensiveAbility { get { return 0.75; } }
    protected override double PercentageOffense_Shooting { get { return 0.25; } }

    /// <summary>
    /// 
    /// </summary>
    public override double DefensiveScore
    {
      get
      {
        // return _p.DefensiveScore;
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
    public override double ValueIndex
    {
      get
      {
        // return _p.ValueIndex;
        return TotalScore / Extensions.PlayerExtensions.StoredAssessedValues[TrainingWeekIndex];
      }
    }

  }
}
