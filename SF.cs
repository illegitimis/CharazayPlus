namespace AndreiPopescu.CharazayPlus
{
  using System;
  using System.Xml.Serialization;
  using BrightIdeasSoftware;
  using AndreiPopescu.CharazayPlus.Utils;

  /// <summary>
  /// Small forward
  /// </summary>
  public class SF : Player
  {
    public SF() : base() { }

    public SF (Xsd2.charazayPlayer xsdPlayer) : base(xsdPlayer) { }
    public SF (Xsd2.charazayPlayerSkills xsdSkills) : base(xsdSkills) { }


    public override string ToString() { return string.Format("sf: {0}", base.ToString()); }

    protected internal override byte MinimumBMI { get { return 24; } }
    protected internal override byte MaximumBMI { get { return 26; } }
    protected internal override byte MinimumHeight { get { return 200; } }
    protected internal override byte MaximumHeight { get { return 210; } }

    protected override double PercentageDefense_Defence { get { return 0.6; } }
    protected override double PercentageDefense_Speed { get { return 0.2; } }
    protected override double PercentageDefense_Footwork { get { return 0.2; } }

    protected override double PercentageOffensiveAbility_Dribbling { get { return 0.3; } }
    protected override double PercentageOffensiveAbility_Passing { get { return 0.1; } }
    protected override double PercentageOffensiveAbility_Speed { get { return 0.4; } }
    protected override double PercentageOffensiveAbility_Footwork { get { return 0.2; } }

    protected override double PercentageTotalScore_Defense { get { return 0.3; } }
    protected override double PercentageTotalScore_Offense { get { return 0.6; } }
    protected override double PercentageTotalScore_Rebounds { get { return 0.1; } }

    protected override double PercentageOffense_OffensiveAbility { get { return 0.7; } }
    protected override double PercentageOffense_Shooting { get{ return 0.3; } }

    protected internal override byte[] TrainingPlan { get { return new byte[] { 3,3,1,4,2,1,2,1 }; } }
    public override PlayerPosition PositionEnum { get { return PlayerPosition.SF; } }

    static double[] StoredAssessedValues
    {
      get
      {
        return new double[] {
           4.80   // 0               
          ,4.94   // 1               
          ,5.03   // 2               
          ,5.12   // 3               
          ,5.18   // 4               
          ,5.25   // 5               
          ,5.31   // 6               
          ,5.34   // 7               
          ,5.43   // 8               
          ,5.51   // 9               
          ,5.59   // 10              
          ,5.68   // 11              
          ,5.74   // 12              
          ,5.80   // 13              
          ,5.84   // 14              
          ,5.90   // 15              
          ,5.96   // 16              
          ,6.00   // 17              
          ,6.07   // 18              
          ,6.13   // 19              
          ,6.20   // 20              
          ,6.25   // 21              
          ,6.30   // 22              
          ,6.35   // 23              
          ,6.37   // 24              
          ,6.45   // 25              
          ,6.52   // 26              
          ,6.60   // 27              
          ,6.67   // 28              
          ,6.73   // 29              
          ,6.78   // 30              
          ,6.82   // 31              
          ,6.88   // 32              
          ,6.93   // 33              
          ,6.94   // 34              
          ,7.00   // 35              
          ,7.06   // 36              
          ,7.12   // 37              
          ,7.17   // 38              
          ,7.21   // 39              
          ,7.26   // 40              
          ,7.28   // 41              
          ,7.35   // 42              
          ,7.42   // 43              
          ,7.49   // 44              
          ,7.56   // 45              
          ,7.62   // 46              
          ,7.67   // 47              
          ,7.70   // 48              
          ,7.75   // 49              
          ,7.80   // 50              
          ,7.84   // 51              
          ,7.89   // 52              
          ,7.95   // 53              
          ,8.00   // 54              
          ,8.04   // 55              
          ,8.08   // 56              
          ,8.12   // 57              
          ,8.14   // 58              
          ,8.21   // 59              
          ,8.27   // 60              
          ,8.33   // 61              
          ,8.39   // 62              
          ,8.44   // 63              
          ,8.49   // 64              
          ,8.52   // 65              
          ,8.56   // 66              
          ,8.61   // 67              
          ,8.64   // 68              
          ,8.69   // 69              
          ,8.74   // 70              
          ,8.79   // 71              
          ,8.83   // 72              
          ,8.87   // 73              
          ,8.91   // 74              
          ,8.93   // 75              
          ,8.99   // 76              
          ,9.05   // 77              
          ,9.11   // 78              
          ,9.17   // 79              
          ,9.21   // 80              
          ,9.26   // 81              
          ,9.29   // 82              
          ,9.33   // 83              
          ,9.37   // 84              
          ,9.40   // 85              
          ,9.45   // 86              
          ,9.50   // 87              
          ,9.55   // 88              
          ,9.59   // 89              
          ,9.62   // 90              
          ,9.66   // 91              
          ,9.67   // 92              
          ,9.73   // 93              
          ,9.79   // 94              
          ,9.85   // 95              
          ,9.90   // 96              
          ,9.94   // 97              
          ,9.99   // 98              
          ,10.01  // 99              
          ,10.06  // 100             
          ,10.10  // 101             
          ,10.12  // 102             
          ,10.17  // 103             
          ,10.22  // 104             
          ,10.27  // 105             
          ,10.30  // 106             
          ,10.33  // 107             
          ,10.37  // 108             
          ,10.39  // 109             
          ,10.44  // 110             
          ,10.49  // 111             
          ,10.55  // 112             
          ,10.60  // 113             
          ,10.64  // 114             
          ,10.68  // 115             
          ,10.71  // 116             
          ,10.75  // 117             
          ,10.79  // 118             
          ,10.82  // 119             
          ,10.86  // 120             
          ,10.90  // 121             
          ,10.94  // 122             
          ,10.97  // 123             
          ,11.00  // 124             
          ,11.03  // 125             
          ,11.05  // 126             
          ,11.10  // 127             
          ,11.15  // 128             
          ,11.20  // 129             
          ,11.24  // 130             
          ,11.28  // 131             
          ,11.32  // 132             
          ,11.34  // 133             
          ,11.38  // 134             
          ,11.41  // 135             
          ,11.44  // 136             
          ,11.48  // 137             
          ,11.52  // 138             
          ,11.56  // 139             
          ,11.59  // 140             
          ,11.62  // 141             
          ,11.65  // 142             
          ,11.66  // 143             
          ,11.71  // 144             
          ,11.75  // 145             
          ,11.80  // 146             
          ,11.84  // 147             
          ,11.88  // 148             
          ,11.92  // 149             
          ,11.94  // 150             
          ,11.97  // 151             
          ,12.01  // 152             
          ,12.03  // 153             
          ,12.07  // 154             
          ,12.10  // 155             
          ,12.14  // 156             
          ,12.16  // 157             
          ,12.19  // 158             
          ,12.21  // 159             
          ,12.23  // 160             
          ,12.27  // 161             
          ,12.31  // 162             
          ,12.35  // 163             
          ,12.33  // 164             
          ,12.36  // 165             
          ,12.40  // 166             
          ,12.42  // 167             
          ,12.44  // 168             
          ,12.47  // 169             
          ,12.49  // 170             
          ,12.53  // 171             
          ,12.56  // 172             
          ,12.59  // 173             
          ,12.61  // 174             
          ,12.64  // 175             
          ,12.66  // 176             
          ,12.67  // 177             
          ,12.71  // 178             
          ,12.75  // 179             
          ,12.78  // 180             
          ,12.82  // 181             
          ,12.85  // 182             
          ,12.88  // 183             
          ,12.89  // 184             
          ,12.92  // 185             
          ,12.94  // 186             
          ,12.96  // 187             
          ,12.99  // 188             
          ,13.03  // 189             
          ,13.06  // 190             
          ,13.08  // 191             
          ,13.10  // 192             
          ,13.12  // 193             
          ,13.14  // 194             
          ,13.17  // 195             
          ,13.20  // 196             
          ,13.24  // 197             
          ,13.27  // 198             
          ,13.30  // 199             
          ,13.33  // 200             
          ,13.34  // 201             
          ,13.37  // 202             
          ,13.39  // 203             
          ,13.41  // 204             
          ,13.44  // 205             
          ,13.47  // 206             
          ,13.50  // 207             
          ,13.52  // 208             
          ,13.54  // 209             
          ,13.56  // 210             
          ,13.58  // 211             
          ,13.61  // 212             
          ,13.64  // 213             
          ,13.67  // 214             
          ,13.71  // 215             
          ,13.73  // 216             
          ,13.76  // 217             
          ,13.78  // 218             
          ,13.80  // 219             
          ,13.82  // 220             
          ,13.84  // 221             
          ,13.87  // 222             
          ,13.89  // 223             
          ,13.92  // 224             
          ,13.94  // 225             
          ,13.95  // 226             
          ,13.97  // 227             
          ,13.98  // 228             
          ,14.01  // 229             
          ,14.04  // 230             
          ,14.07  // 231             
          ,14.10  // 232             
          ,14.12  // 233             
          ,14.14  // 234             
          ,14.16  // 235             
          ,14.18  // 236             
          ,14.20  // 237             
          ,14.21  // 238             
          ,14.24  // 239             
          ,14.26  // 240             
          ,14.28  // 241             
          ,14.30  // 242             
          ,14.32  // 243             
          ,14.34  // 244             
          ,14.35  // 245             
          ,14.37  // 246             
          ,14.40  // 247             
          ,14.43  // 248             
          ,14.45  // 249             
          ,14.47  // 250             
          ,14.50  // 251             
          ,14.51  // 252             
          ,14.53  // 253             
          ,14.55  // 254             
          ,14.56  // 255             
          ,14.58  // 256             
          ,14.60  // 257             
          ,14.62  // 258             
          ,14.64  // 259             
          ,14.65  // 260             
          ,14.67  // 261             
          ,14.67  // 262             
          ,14.70  // 263             
          ,14.72  // 264             
          ,14.74  // 265             
          ,14.76  // 266             
          ,14.78  // 267             
          ,14.79  // 268             
          ,14.81  // 269             
          ,14.82  // 270             
          ,14.84  // 271             
          ,14.85  // 272             
          ,14.87  // 273             
          ,14.88  // 274             
          ,14.90  // 275             
          ,14.92  // 276             
          ,14.93  // 277             
          ,14.94  // 278             
          ,14.95  // 279             
          ,14.97  // 280             
          ,14.99  // 281             
          ,15.01  // 282             
          ,15.03  // 283             
          ,15.04  // 284             
          ,15.06  // 285             
          ,15.07  // 286             
          ,15.08  // 287             
          ,15.10// 288          
      };
      }
    }

    public override double ValueIndex { get { return TotalScore / SF.StoredAssessedValues[TrainingWeekIndex]; } }
    public override double TransferMarketValue
    {
      get { return Interpolation112.GetTMValue(this.Age, 'F', this.ValueIndex); }
    }
  }

  

} // namespace