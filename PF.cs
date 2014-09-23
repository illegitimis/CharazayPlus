using System;
using System.Collections.Generic;
using System.Text;
using AndreiPopescu.CharazayPlus.Utils;

namespace AndreiPopescu.CharazayPlus
{
  /// <summary>
  /// Power forward
  /// </summary>
  public class PF : Player
  {
    public PF ( ) : base() { }

    public PF (Xsd2.charazayPlayer xsdPlayer) : base(xsdPlayer) { }
    public PF (Xsd2.charazayPlayerSkills xsdSkills) : base(xsdSkills) { }


    public override string ToString ( ) { return string.Format("Pf: {0}", base.ToString()); }

    protected internal override byte MinimumBMI { get { return 25; } }
    protected internal override byte MaximumBMI { get { return 27; } }
    protected internal override byte MinimumHeight { get { return 205; } }
    protected internal override byte MaximumHeight { get { return 220; } }

    protected override double PercentageDefense_Defence { get { return 0.6; } }
    protected override double PercentageDefense_Speed { get { return 0.1; } }
    protected override double PercentageDefense_Footwork { get { return 0.3; } }

    protected override double PercentageOffensiveAbility_Dribbling { get { return 0.15; } }
    protected override double PercentageOffensiveAbility_Passing { get { return 0.1; } }
    protected override double PercentageOffensiveAbility_Speed { get { return 0.3; } }
    protected override double PercentageOffensiveAbility_Footwork { get { return 0.45; } }

    protected override double PercentageTotalScore_Defense { get { return 0.3; } }
    protected override double PercentageTotalScore_Offense { get { return 0.55; } }
    protected override double PercentageTotalScore_Rebounds { get { return 0.15; } }

    protected override double PercentageOffense_OffensiveAbility { get { return 0.7; } }
    protected override double PercentageOffense_Shooting { get { return 0.3; } }

    protected internal override byte[] TrainingPlan { get { return new byte[] { 3, 1, 1, 3, 4, 4, 1, 0 }; } }
    public override PlayerPosition PositionEnum { get { return PlayerPosition.PF; } }

    static double[] StoredAssessedValues
    {
      get { return new double[] { 
    4.82      
   ,4.96      
   ,5.05      
   ,5.14      
   ,5.18      
   ,5.22      
   ,5.29      
   ,5.35      
   ,5.41      
   ,5.51      
   ,5.61      
   ,5.71      
   ,5.80      
   ,5.85      
   ,5.91      
   ,5.96      
   ,6.01      
   ,6.07      
   ,6.13      
   ,6.20      
   ,6.27      
   ,6.30      
   ,6.32      
   ,6.38      
   ,6.43      
   ,6.48      
   ,6.57      
   ,6.66      
   ,6.75      
   ,6.84      
   ,6.89      
   ,6.93      
   ,6.98      
   ,7.02      
   ,7.08      
   ,7.14      
   ,7.20      
   ,7.27      
   ,7.29      
   ,7.32      
   ,7.37      
   ,7.42      
   ,7.47      
   ,7.55      
   ,7.64      
   ,7.72      
   ,7.80      
   ,7.85      
   ,7.89      
   ,7.94      
   ,7.98      
   ,8.03      
   ,8.09      
   ,8.14      
   ,8.20      
   ,8.22      
   ,8.24      
   ,8.28      
   ,8.33      
   ,8.37      
   ,8.45      
   ,8.52      
   ,8.60      
   ,8.67      
   ,8.71      
   ,8.72      
   ,8.76      
   ,8.80      
   ,8.84      
   ,8.89      
   ,8.94      
   ,9.00      
   ,9.02      
   ,9.04      
   ,9.08      
   ,9.12      
   ,9.17      
   ,9.24      
   ,9.31      
   ,9.38      
   ,9.45      
   ,9.49      
   ,9.53      
   ,9.56      
   ,9.60      
   ,9.64      
   ,9.69      
   ,9.74      
   ,9.79      
   ,9.81      
   ,9.83      
   ,9.87      
   ,9.91      
   ,9.95      
   ,10.02     
   ,10.08     
   ,10.15     
   ,10.22     
   ,10.25     
   ,10.29     
   ,10.32     
   ,10.36     
   ,10.40     
   ,10.44     
   ,10.49     
   ,10.54     
   ,10.56     
   ,10.58     
   ,10.61     
   ,10.65     
   ,10.69     
   ,10.76     
   ,10.82     
   ,10.89     
   ,10.95     
   ,10.98     
   ,11.02     
   ,11.05     
   ,11.08     
   ,11.12     
   ,11.16     
   ,11.21     
   ,11.25     
   ,11.27     
   ,11.28     
   ,11.32     
   ,11.35     
   ,11.38     
   ,11.44     
   ,11.50     
   ,11.56     
   ,11.61     
   ,11.64     
   ,11.67     
   ,11.70     
   ,11.73     
   ,11.77     
   ,11.81     
   ,11.85     
   ,11.89     
   ,11.91     
   ,11.92     
   ,11.95     
   ,11.99     
   ,12.02     
   ,12.08     
   ,12.13     
   ,12.19     
   ,12.24     
   ,12.27     
   ,12.30     
   ,12.33     
   ,12.35     
   ,12.39     
   ,12.42     
   ,12.46     
   ,12.49     
   ,12.51     
   ,12.52     
   ,12.55     
   ,12.58     
   ,12.61     
   ,12.66     
   ,12.71     
   ,12.75     
   ,12.80     
   ,12.83     
   ,12.85     
   ,12.88     
   ,12.90     
   ,12.93     
   ,12.96     
   ,12.99     
   ,13.03     
   ,13.04     
   ,13.05     
   ,13.08     
   ,13.11     
   ,13.13     
   ,13.18     
   ,13.22     
   ,13.26     
   ,13.30     
   ,13.33     
   ,13.35     
   ,13.37     
   ,13.39     
   ,13.42     
   ,13.45     
   ,13.48     
   ,13.51     
   ,13.53     
   ,13.54     
   ,13.56     
   ,13.59     
   ,13.61     
   ,13.66     
   ,13.70     
   ,13.74     
   ,13.78     
   ,13.80     
   ,13.82     
   ,13.84     
   ,13.86     
   ,13.89     
   ,13.92     
   ,13.95     
   ,13.98     
   ,13.99     
   ,14.00     
   ,14.03     
   ,14.05     
   ,14.07     
   ,14.11     
   ,14.15     
   ,14.19     
   ,14.23     
   ,14.25     
   ,14.27     
   ,14.29     
   ,14.31     
   ,14.34     
   ,14.36     
   ,14.39     
   ,14.41     
   ,14.42     
   ,14.43     
   ,14.46     
   ,14.48     
   ,14.50     
   ,14.53     
   ,14.56     
   ,14.60     
   ,14.63     
   ,14.65     
   ,14.67     
   ,14.68     
   ,14.70     
   ,14.72     
   ,14.75     
   ,14.77     
   ,14.79     
   ,14.81     
   ,14.82     
   ,14.84     
   ,14.86     
   ,14.88     
   ,14.91     
   ,14.94     
   ,14.97     
   ,15.00     
   ,15.02     
   ,15.03     
   ,15.05     
   ,15.07     
   ,15.09     
   ,15.11     
   ,15.13     
   ,15.15     
   ,15.16     
   ,15.16     
   ,15.18     
   ,15.20     
   ,15.21     
   ,15.24     
   ,15.26     
   ,15.29     
   ,15.31     
   ,15.32     
   ,15.34     
   ,15.35     
   ,15.37     
   ,15.38     
   ,15.40     
   ,15.42     
   ,15.44     
   ,15.45     
   ,15.45     
   ,15.47     
   ,15.48     
   ,15.50     
   ,15.52     
   ,15.54     
   ,15.57     
   ,15.59     
   ,15.60     
   ,15.61     
   ,15.63     
   ,15.64     
      }; }
    }

    public override double ValueIndex { get { return TotalScore / PF.StoredAssessedValues[TrainingWeekIndex]; } }
    public override double TransferMarketValue
    {
      //get { return Interpolation112.GetTMValue(this.Age, 'C', this.ValueIndex); }
      get { return MatlabInterpolant.GetTMValue(this.Age, 'C', this.ValueIndex); }
    }
  }
}
