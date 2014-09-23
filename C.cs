using System;
using System.Collections.Generic;
using System.Text;
using AndreiPopescu.CharazayPlus.Utils;

namespace AndreiPopescu.CharazayPlus
{
  /// <summary>
  /// Center
  /// </summary>
  public class C : Player
  {
    public C ( ) : base() { }

    public C (Xsd2.charazayPlayer xsdPlayer) : base(xsdPlayer) { }
    public C (Xsd2.charazayPlayerSkills xsdSkills) : base(xsdSkills) { }


    public override string ToString ( ) { return string.Format("M : {0}", base.ToString()); }

    protected internal override byte MinimumBMI { get { return 26; } }
    protected internal override byte MaximumBMI { get { return 28; } }
    protected internal override byte MinimumHeight { get { return 210; } }
    protected internal override byte MaximumHeight { get { return 230; } }

    protected override double PercentageDefense_Defence { get { return 0.6; } }
    protected override double PercentageDefense_Speed { get { return 0.05; } }
    protected override double PercentageDefense_Footwork { get { return 0.35; } }

    protected override double PercentageOffensiveAbility_Dribbling { get { return 0.05; } }
    protected override double PercentageOffensiveAbility_Passing { get { return 0.25; } }
    protected override double PercentageOffensiveAbility_Speed { get { return 0.2; } }
    protected override double PercentageOffensiveAbility_Footwork { get { return 0.5; } }

    protected override double PercentageTotalScore_Defense { get { return 0.3; } }
    protected override double PercentageTotalScore_Offense { get { return 0.5; } }
    protected override double PercentageTotalScore_Rebounds { get { return 0.2; } }

    protected override double PercentageOffense_OffensiveAbility { get { return 0.75; } }
    protected override double PercentageOffense_Shooting { get { return 0.25; } }

    protected override internal byte[] TrainingPlan { get { return new byte[] { 3, 0, 2, 2, 4, 5, 1, 0 }; } }
    public override PlayerPosition PositionEnum { get { return PlayerPosition.C; } }

    #region assessed total player values for 289 weeks of training
    /// <summary>
    /// stored values of player development from age 15 to 32
    /// each week with training contribution
    /// </summary>
    static double[] StoredAssessedValues
    {
      get
      {
        return new double[]{
   4.86      
  ,5.00      
  ,5.10      
  ,5.18      
  ,5.24      
  ,5.29      
  ,5.34      
  ,5.39      
  ,5.50      
  ,5.61      
  ,5.72      
  ,5.82      
  ,5.89      
  ,5.95      
  ,6.01      
  ,6.08      
  ,6.14      
  ,6.19      
  ,6.26      
  ,6.32      
  ,6.39      
  ,6.43      
  ,6.47      
  ,6.51      
  ,6.55      
  ,6.65      
  ,6.75      
  ,6.84      
  ,6.94      
  ,7.00      
  ,7.06      
  ,7.12      
  ,7.17      
  ,7.23      
  ,7.27      
  ,7.34      
  ,7.40      
  ,7.46      
  ,7.50      
  ,7.54      
  ,7.57      
  ,7.61      
  ,7.70      
  ,7.80      
  ,7.89      
  ,7.98      
  ,8.04      
  ,8.09      
  ,8.15      
  ,8.20      
  ,8.25      
  ,8.30      
  ,8.35      
  ,8.41      
  ,8.46      
  ,8.50      
  ,8.53      
  ,8.56      
  ,8.59      
  ,8.68      
  ,8.76      
  ,8.84      
  ,8.92      
  ,8.97      
  ,9.02      
  ,9.05      
  ,9.09      
  ,9.14      
  ,9.17      
  ,9.23      
  ,9.28      
  ,9.33      
  ,9.37      
  ,9.40      
  ,9.43      
  ,9.46      
  ,9.54      
  ,9.62      
  ,9.70      
  ,9.77      
  ,9.82      
  ,9.87      
  ,9.91      
  ,9.96      
  ,10.00     
  ,10.03     
  ,10.09     
  ,10.14     
  ,10.19     
  ,10.22     
  ,10.25     
  ,10.27     
  ,10.30     
  ,10.38     
  ,10.45     
  ,10.53     
  ,10.60     
  ,10.64     
  ,10.69     
  ,10.73     
  ,10.77     
  ,10.82     
  ,10.85     
  ,10.90     
  ,10.94     
  ,10.99     
  ,11.02     
  ,11.05     
  ,11.08     
  ,11.10     
  ,11.17     
  ,11.25     
  ,11.32     
  ,11.39     
  ,11.43     
  ,11.47     
  ,11.51     
  ,11.55     
  ,11.59     
  ,11.62     
  ,11.67     
  ,11.71     
  ,11.75     
  ,11.78     
  ,11.80     
  ,11.83     
  ,11.85     
  ,11.92     
  ,11.98     
  ,12.04     
  ,12.11     
  ,12.14     
  ,12.18     
  ,12.22     
  ,12.25     
  ,12.29     
  ,12.31     
  ,12.36     
  ,12.40     
  ,12.44     
  ,12.46     
  ,12.49     
  ,12.51     
  ,12.54     
  ,12.60     
  ,12.66     
  ,12.72     
  ,12.78     
  ,12.81     
  ,12.85     
  ,12.88     
  ,12.92     
  ,12.95     
  ,12.98     
  ,13.01     
  ,13.05     
  ,13.09     
  ,13.11     
  ,13.13     
  ,13.15     
  ,13.17     
  ,13.23     
  ,13.28     
  ,13.33     
  ,13.38     
  ,13.41     
  ,13.44     
  ,13.47     
  ,13.50     
  ,13.53     
  ,13.56     
  ,13.59     
  ,13.62     
  ,13.66     
  ,13.68     
  ,13.70     
  ,13.72     
  ,13.73     
  ,13.78     
  ,13.83     
  ,13.88     
  ,13.92     
  ,13.95     
  ,13.98     
  ,14.01     
  ,14.03     
  ,14.06     
  ,14.08     
  ,14.11     
  ,14.14     
  ,14.17     
  ,14.19     
  ,14.21     
  ,14.23     
  ,14.25     
  ,14.29     
  ,14.34     
  ,14.38     
  ,14.43     
  ,14.45     
  ,14.48     
  ,14.51     
  ,14.53     
  ,14.56     
  ,14.58     
  ,14.61     
  ,14.64     
  ,14.67     
  ,14.69     
  ,14.70     
  ,14.72     
  ,14.74     
  ,14.78     
  ,14.83     
  ,14.87     
  ,14.91     
  ,14.94     
  ,14.96     
  ,14.98     
  ,15.01     
  ,15.03     
  ,15.05     
  ,15.08     
  ,15.11     
  ,15.13     
  ,15.15     
  ,15.16     
  ,15.18     
  ,15.19     
  ,15.23     
  ,15.27     
  ,15.30     
  ,15.34     
  ,15.36     
  ,15.38     
  ,15.40     
  ,15.43     
  ,15.45     
  ,15.46     
  ,15.49     
  ,15.51     
  ,15.54     
  ,15.55     
  ,15.57     
  ,15.58     
  ,15.60     
  ,15.63     
  ,15.67     
  ,15.70     
  ,15.73     
  ,15.75     
  ,15.77     
  ,15.79     
  ,15.81     
  ,15.83     
  ,15.85     
  ,15.87     
  ,15.89     
  ,15.91     
  ,15.92     
  ,15.93     
  ,15.95     
  ,15.96     
  ,15.99     
  ,16.01     
  ,16.04     
  ,16.07     
  ,16.08     
  ,16.10     
  ,16.12     
  ,16.13     
  ,16.15     
  ,16.16     
  ,16.18     
  ,16.20     
  ,16.22     
  ,16.23     
  ,16.24     
  ,16.25     
  ,16.26     
  ,16.29     
  ,16.31     
  ,16.34     
  ,16.36     
  ,16.38     
  ,16.39     
  ,16.41     
  ,16.42     
  ,16.43
      };
      }
    } 
    #endregion

    public override double ValueIndex { get { return TotalScore / C.StoredAssessedValues[TrainingWeekIndex]; } }

    public override double TransferMarketValue
    {
      //get { return Interpolation112.GetTMValue(this.Age, 'C', this.ValueIndex); }
      get { return MatlabInterpolant.GetTMValue(this.Age, 'C', this.ValueIndex); }
    }
  }
}
