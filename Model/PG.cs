using System;
using System.Collections.Generic;
using System.Text;
using AndreiPopescu.CharazayPlus.Utils;

namespace AndreiPopescu.CharazayPlus
{

  /// <summary>
  /// Point guard
  /// </summary>  
  public class PG : Player
  {
    public PG ( ) : base()  { }

    //public PG(UInt64 id, string name, string surname, byte countryId
    //  , byte age, byte h, byte w, UInt64 si, UInt64 salary
    //  , byte form, byte fatigue, Common.Fame fame
    //  , byte def, byte ft, byte p2, byte p3
    //  , byte spe, byte pas, byte dri, byte ftw, byte reb, byte exp)
    //  : base(id, name, surname, countryId, age, h, w, si, salary, form, fatigue, fame,
    //          def, ft, p2, p3, spe, pas, dri, ftw, reb, exp) { }

    public PG (Xsd2.charazayPlayer xsdPlayer) : base(xsdPlayer) { }
    public PG (Xsd2.charazayPlayer xsdPlayer, bool ishw, bool isfatigue, bool isform) : base(xsdPlayer, ishw, isfatigue, isform) { }
    public PG (Xsd2.charazayPlayerSkills xsdSkills) : base(xsdSkills) { }

    
    public override string ToString ( ) { return string.Format("PG: {0}", base.ToString()); }

    protected internal override byte MinimumBMI { get { return 21; } }
    protected internal override byte MaximumBMI { get { return 23; } }
    protected internal override byte MinimumHeight { get { return 180; } }
    protected internal override byte MaximumHeight { get { return 195; } }

    protected override double PercentageDefense_Defence { get { return 0.6; } }
    protected override double PercentageDefense_Speed { get { return 0.35; } }
    protected override double PercentageDefense_Footwork { get { return 0.05; } }

    protected override double PercentageOffensiveAbility_Dribbling { get { return 0.4; } }
    protected override double PercentageOffensiveAbility_Passing { get { return 0.4; } }
    protected override double PercentageOffensiveAbility_Speed { get { return 0.2; } }
    protected override double PercentageOffensiveAbility_Footwork { get { return 0.0; } }

    protected override double PercentageTotalScore_Defense { get { return 0.4; } }
    protected override double PercentageTotalScore_Offense { get { return 0.58; } }
    protected override double PercentageTotalScore_Rebounds { get { return 0.02; } }

    protected override double PercentageOffense_OffensiveAbility { get { return 0.7; } }
    protected override double PercentageOffense_Shooting { get { return 0.3; } }

    /// <summary>
    /// 
    /// </summary>
    protected override internal byte[] TrainingPlan { get { return new byte[] { 4, 3, 4, 4, 0, 0, 1, 1 }; } }

    public override PlayerPosition PositionEnum { get { return PlayerPosition.PG; } }

    internal static double[] StoredAssessedValues
    {
      get
      {
        return new double[] { 
4.81,
4.96,
5.07,
5.17,
5.27,
5.34,
5.41,
5.48,
5.55,
5.61,
5.68,
5.74,
5.82,
5.9 ,
5.98,
6.06,
6.12,
6.15,
6.23,
6.32,
6.4 ,
6.48,
6.53,
6.59,
6.65,
6.71,
6.77,
6.82,
6.88,
6.95,
7.03,
7.1 ,
7.17,
7.23,
7.24,
7.32,
7.39,
7.47,
7.54,
7.6 ,
7.65,
7.71,
7.76,
7.82,
7.87,
7.92,
7.99,
8.06,
8.13,
8.2 ,
8.25,
8.28,
8.35,
8.42,
8.48,
8.55,
8.6 ,
8.65,
8.69,
8.74,
8.79,
8.84,
8.89,
8.95,
9.01,
9.07,
9.13,
9.17,
9.2 ,
9.27,
9.33,
9.4 ,
9.46,
9.51,
9.55,
9.6 ,
9.64,
9.69,
9.73,
9.78,
9.84,
9.9 ,
9.96,
10.01,
10.06,
10.09,
10.15,
10.21,
10.27,
10.32,
10.37,
10.41,
10.46,
10.5 ,
10.54,
10.58,
10.63,
10.68,
10.74,
10.79,
10.85,
10.89,
10.92,
10.97,
11.03,
11.09,
11.14,
11.19,
11.23,
11.27,
11.31,
11.35,
11.39,
11.43,
11.49,
11.54,
11.59,
11.65,
11.68,
11.71,
11.76,
11.81,
11.86,
11.91,
11.95,
11.99,
12.03,
12.06,
12.1 ,
12.14,
12.17,
12.22,
12.27,
12.31,
12.36,
12.4 ,
12.42,
12.47,
12.52,
12.57,
12.61,
12.65,
12.69,
12.72,
12.76,
12.79,
12.83,
12.86,
12.91,
12.95,
13,
13.04,
13.08,
13.1 ,
13.14,
13.18,
13.23,
13.27,
13.3 ,
13.33,
13.36,
13.39,
13.42,
13.45,
13.47,
13.51,
13.55,
13.59,
13.62,
13.65,
13.68,
13.71,
13.75,
13.79,
13.83,
13.86,
13.89,
13.91,
13.94,
13.97,
14,
14.02,
14.06,
14.1 ,
14.13,
14.17,
14.19,
14.21,
14.25,
14.28,
14.32,
14.36,
14.38,
14.41,
14.44,
14.46,
14.49,
14.52,
14.54,
14.58,
14.61,
14.64,
14.68,
14.7 ,
14.72,
14.76,
14.79,
14.82,
14.86,
14.88,
14.91,
14.94,
14.96,
14.99,
15.01,
15.04,
15.07,
15.1 ,
15.13,
15.16,
15.19,
15.21,
15.24,
15.27,
15.3 ,
15.33,
15.35,
15.37,
15.39,
15.42,
15.44,
15.46,
15.48,
15.51,
15.54,
15.56,
15.59,
15.61,
15.63,
15.66,
15.68,
15.71,
15.74,
15.76,
15.78,
15.8 ,
15.82,
15.84,
15.86,
15.88,
15.91,
15.94,
15.96,
15.99,
16.01,
16.02,
16.05,
16.07,
16.09,
16.11,
16.13,
16.15,
16.16,
16.18,
16.2 ,
16.21,
16.23,
16.25,
16.27,
16.29,
16.31,
16.33,
16.34,
16.36,
16.38,
16.4 ,
16.42,
16.44,
16.45,
16.47,
16.48,
16.5 ,
16.52,
16.53,
16.55,
16.57,
16.59,
16.61,
16.62,
    };
      }
    }

    public override double ValueIndex { get { return TotalScore / PG.StoredAssessedValues[TrainingWeekIndex]; } }

    public override double TransferMarketValue
    {
      //get { return Interpolation112.GetTMValue(this.Age, 'G', this.ValueIndex); }
      get { return MatlabInterpolant201507.Instance.GetTMValue(this.Age, 'G', this.ValueIndex); }
    }
  }

  
 

}
