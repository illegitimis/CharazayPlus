

namespace AndreiPopescu.CharazayPlus
{

  /// <summary>
  /// Small Forward with game changes from 2014
  /// //public class SF2014 : Player2014
  /// </summary>
  public class SF2014 : SF, IPlayer2014
  {
    public SF2014 ( ) : base() { }
    public SF2014 (Xsd2.charazayPlayer xsdPlayer) : base(xsdPlayer, true, false, false) { }
    public SF2014 (Xsd2.charazayPlayer xsdPlayer, bool ishw, bool isfatigue, bool isform) : base(xsdPlayer, ishw, isfatigue, isform) { }
    public SF2014 (Xsd2.charazayPlayerSkills xsdSkills) : base(xsdSkills) { }


    public override string ToString ( ) { return string.Format("SF2014: {0}", base.ToString()); }

    protected internal override byte MinimumBMI { get { return 24; } }
    protected internal override byte MaximumBMI { get { return 26; } }
    protected internal override byte MinimumHeight { get { return 200; } }
    protected internal override byte MaximumHeight { get { return 210; } }

    /*
    *********************************************************************************************
    * Defensive potential 2012                    Defensive potential 2014
    ** *******************************************************************************************
    * SF : Defence>Speed,Footwork                 SF: Defense>Speed>Footwork>Passing=Dribbling
    **********************************************************************************************
    * same as PF but switch ftw and speed
    **********************************************************************************************
    */
    protected override double PercentageDefense_Defence { get { return 0.44; } }
    protected override double PercentageDefense_Speed { get { return 0.25; } }
    protected override double PercentageDefense_Footwork { get { return 0.15; } }
    public double PercentageDefense_Passing { get { return 0.08; } }
    public double PercentageDefense_Dribling { get { return 0.08; } }

    /*
    *********************************************************************************************
    * Offensive potential as of 2012                   Offensive potential as of 2014
    * *******************************************************************************************
    * SF : Speed>Dribbling>Footwork>Passing            SF : Speed>Dribbling>Footwork>Passing
    *********************************************************************************************
    * no changes !
    **********************************************************************************************
    */
    protected override double PercentageOffensiveAbility_Speed { get { return 0.45; } }
    protected override double PercentageOffensiveAbility_Dribbling { get { return 0.3; } }
    protected override double PercentageOffensiveAbility_Footwork { get { return 0.17; } }
    protected override double PercentageOffensiveAbility_Passing { get { return 0.08; } }


    /*
    *********************************************************************************************
    * Total score components
    ********************************************************************************************
    * same proportion of def vs off
    * def from 0.3 to 0.45, off from 0.6 to 0.45, reb same 
    **********************************************************************************************
    */
    protected override double PercentageTotalScore_Offense { get { return 0.45; } }
    protected override double PercentageTotalScore_Defense { get { return 0.45; } }
    protected override double PercentageTotalScore_Rebounds { get { return 0.1; } }

    /*
   *********************************************************************************************
   * Offensive score componets
   ********************************************************************************************
   * shooting drop from 0.3 to 0.25
   **********************************************************************************************
   */
    protected override double PercentageOffense_OffensiveAbility { get { return 0.75; } }
    protected override double PercentageOffense_Shooting { get { return 0.25; } }

    /********************************************************************************************/
    public override double DefensiveScore
    {
      get
      {
        return Utils.Linear.DotVectorProduct_Normalized( new double[] 
          { PercentageDefense_Defence, PercentageDefense_Footwork, PercentageDefense_Speed, PercentageDefense_Dribling, PercentageDefense_Passing }
          , new double[] { m_dDefence, m_dFootwork, m_dSpeed, m_dDribling, m_dPassing });
      }
    }

    public override double ValueIndex { get { 
      return TotalScore / Extensions.PlayerExtensions.StoredAssessedValues[TrainingWeekIndex]; 
    } }


  }
}
