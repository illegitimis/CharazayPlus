using System;
using System.Collections.Generic;
using System.Text;

namespace AndreiPopescu.CharazayPlus
{
  /// <summary>
  /// Shooting guard
  /// </summary>
  public class SG : Player
  {
    public SG ( ) : base() { }
    public SG (Xsd2.charazayPlayer xsdPlayer) : base(xsdPlayer) { }
    public SG (Xsd2.charazayPlayerSkills xsdSkills) : base(xsdSkills) { }

    public override string ToString ( ) { return string.Format("SG: {0}", base.ToString()); }

    protected internal override byte MinimumBMI { get { return 22; } }
    protected internal override byte MaximumBMI { get { return 24; } }
    protected internal override byte MinimumHeight { get { return 190; } }
    protected internal override byte MaximumHeight { get { return 200; } }

    protected override double PercentageDefense_Defence { get { return 0.6; } }
    protected override double PercentageDefense_Speed { get { return 0.35; } }
    protected override double PercentageDefense_Footwork { get { return 0.05; } }

    protected override double PercentageOffensiveAbility_Dribbling { get { return 0.4; } }
    protected override double PercentageOffensiveAbility_Passing { get { return 0.25; } }
    protected override double PercentageOffensiveAbility_Speed { get { return 0.3; } }
    protected override double PercentageOffensiveAbility_Footwork { get { return 0.05; } }

    protected override double PercentageTotalScore_Defense { get { return 0.3; } }
    protected override double PercentageTotalScore_Offense { get { return 0.67; } }
    protected override double PercentageTotalScore_Rebounds { get { return 0.03; } }

    protected override double PercentageOffense_OffensiveAbility { get { return 0.5; } }
    protected override double PercentageOffense_Shooting { get { return 0.5; } }

    protected internal override byte[] TrainingPlan { get { return new byte[] { 4, 3, 2, 4, 0, 0, 2, 2 }; } }

    public override PlayerPosition PositionEnum { get { return PlayerPosition.SG; } }

    protected override double[] StoredAssessedValues
    {
      get { return new double[] { 
 4.63      
,4.77      
,4.86      
,4.94      
,5.02      
,5.09      
,5.15      
,5.21      
,5.26      
,5.30      
,5.38      
,5.45      
,5.53      
,5.60      
,5.71      
,5.81      
,5.86      
,5.89      
,5.95      
,6.02      
,6.08      
,6.14      
,6.19      
,6.24      
,6.30      
,6.33      
,6.37      
,6.44      
,6.51      
,6.57      
,6.64      
,6.73      
,6.82      
,6.88      
,6.93      
,7.00      
,7.06      
,7.11      
,7.17      
,7.22      
,7.27      
,7.32      
,7.35      
,7.38      
,7.45      
,7.51      
,7.58      
,7.64      
,7.73      
,7.81      
,7.87      
,7.92      
,7.98      
,8.03      
,8.08      
,8.13      
,8.18      
,8.22      
,8.26      
,8.29      
,8.32      
,8.38      
,8.44      
,8.49      
,8.55      
,8.63      
,8.70      
,8.75      
,8.80      
,8.85      
,8.90      
,8.95      
,9.00      
,9.04      
,9.08      
,9.12      
,9.15      
,9.18      
,9.23      
,9.29      
,9.34      
,9.40      
,9.47      
,9.54      
,9.59      
,9.64      
,9.68      
,9.73      
,9.78      
,9.82      
,9.86      
,9.90      
,9.94      
,9.96      
,9.99      
,10.04     
,10.10     
,10.15     
,10.20     
,10.23     
,10.29     
,10.34     
,10.39     
,10.44     
,10.48     
,10.53     
,10.57     
,10.61     
,10.65     
,10.68     
,10.71     
,10.73     
,10.78     
,10.83     
,10.88     
,10.93     
,10.99     
,11.05     
,11.10     
,11.15     
,11.19     
,11.23     
,11.27     
,11.31     
,11.34     
,11.38     
,11.41     
,11.43     
,11.45     
,11.50     
,11.54     
,11.59     
,11.63     
,11.68     
,11.73     
,11.78     
,11.83     
,11.86     
,11.90     
,11.94     
,11.98     
,12.01     
,12.04     
,12.07     
,12.09     
,12.12     
,12.16     
,12.20     
,12.24     
,12.29     
,12.34     
,12.39     
,12.43     
,12.47     
,12.51     
,12.54     
,12.57     
,12.61     
,12.64     
,12.66     
,12.69     
,12.71     
,12.73     
,12.77     
,12.80     
,12.84     
,12.88     
,12.92     
,12.96     
,13.00     
,13.04     
,13.07     
,13.10     
,13.13     
,13.16     
,13.19     
,13.21     
,13.24     
,13.25     
,13.27     
,13.31     
,13.34     
,13.37     
,13.41     
,13.44     
,13.48     
,13.52     
,13.55     
,13.58     
,13.61     
,13.64     
,13.67     
,13.69     
,13.72     
,13.74     
,13.76     
,13.77     
,13.80     
,13.84     
,13.87     
,13.90     
,13.94     
,13.97     
,14.01     
,14.04     
,14.07     
,14.10     
,14.12     
,14.15     
,14.17     
,14.19     
,14.22     
,14.23     
,14.25     
,14.28     
,14.31     
,14.34     
,14.37     
,14.41     
,14.44     
,14.47     
,14.51     
,14.53     
,14.55     
,14.58     
,14.60     
,14.62     
,14.64     
,14.66     
,14.67     
,14.69     
,14.72     
,14.74     
,14.77     
,14.79     
,14.82     
,14.85     
,14.88     
,14.91     
,14.93     
,14.95     
,14.98     
,15.00     
,15.02     
,15.04     
,15.05     
,15.07     
,15.08     
,15.11     
,15.13     
,15.16     
,15.18     
,15.21     
,15.24     
,15.26     
,15.29     
,15.31     
,15.33     
,15.34     
,15.36     
,15.38     
,15.39     
,15.41     
,15.42     
,15.43     
,15.45     
,15.47     
,15.49     
,15.51     
,15.53     
,15.55     
,15.57     
,15.60     
,15.61     
,15.63     
,15.64     
,15.66     
,15.68     
,15.69     
,15.70     
,15.71     
,15.73     
,15.74     
,15.76     
,15.78     
,15.80     
,15.82     
,15.84     
,15.86     

      }; }
    }
  }
}
