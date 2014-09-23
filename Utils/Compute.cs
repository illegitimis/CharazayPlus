

namespace AndreiPopescu.CharazayPlus.Utils
{

  using System;
  using System.Collections.Generic;
  using System.Text;


  public static partial class Compute
  {
    const double s_properCoachSkillReference = 28.0d;

    //Formula to calculate weekly skill raise
    //To calculate, how fast our player raises his skills you can use the following formula:
    //X*(1+(coach skill - player skill)*3%)= weekly skill raise
    //where X=factor, which depends on player'tlPlayer age:
    //NOTICE: These numbers probably aren’m used by the engine, but they are very close and you can count on them.
    //When you don’m have coach at all (even Community Coach) you use only the X factors (not the whole formula)
    public static readonly double[] s_weeklySkillTrainAgeMultiplier = new double[] 
    {
        0.1580   //15yo      0.158    
      , 0.1578   //16yo      0.1548   
      , 0.1575   //17yo      0.1516   
      , 0.1425   //18yo      0.1485   
      , 0.1400   //19yo      0.1453   
      , 0.1350   //20yo      0.1421   
      , 0.1320   //21yo      0.139    
      , 0.1180   //22yo      0.135    
      , 0.1150   //23yo      0.131    
      , 0.1000   //24yo      0.127    
      , 0.0900   //25yo      0.1211   
      , 0.0860   //26yo      0.117    
      , 0.0830   //27yo      0.111    
      , 0.0700   //28yo      0.106    
      , 0.0660   //29yo      0.099    
      , 0.0500   //30yo      0.0875   
      , 0.0450   //31yo      0.08125  
      , 0.0300   //32yo      0.075    
      , 0.0250   //33yo      0.06666  
      , 0.0220   //34yo      0.05833  
    ,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0 // no increase age > 34
    };

    // BT * (1 + (CS - PS)/30)
    public static double WeeklySkillRaise (double coachSkill, double playerSkill, byte age)
    {
      return s_weeklySkillTrainAgeMultiplier[age-15] * (1d + (coachSkill - playerSkill) / 30d);
    }

    public static void WeeklySkillAddition (ref double skillValue, byte age)
    {
      double delta = s_properCoachSkillReference - skillValue;
      skillValue += WeeklySkillRaise(s_properCoachSkillReference, skillValue, age);
    }

    const double experienceGain30 = 2.5d;
    const double experienceGain10 = 1.3d;

    /// <summary>
    /// Experience influnces active skills. each experience point adds an ammount to each skill
    /// This ammount is f(x)=alpha*x^beta, where beta less than 1
    /// formula designed so as function is convex meaning
    /// m raise in experience from 0 to 10 is much more significant than from 10 to 20
    /// </summary>
    /// <param name="experience">actual player experience</param>
    /// <returns>Experience gain per each skill</returns>
    public static double ExperienceGain (double experience)
    {
      double beta = Math.Log(experienceGain30 / experienceGain10, 3);
      double alpha = experienceGain10 / Math.Pow(10, beta);

      return alpha * Math.Pow(experience, beta);
    }

    /// <summary>
    /// penalty scale factor for bmi not in the given interval    
    /// </summary>
    /// <example>
    /// interval: [23,25] 
    /// given bmi: 22,  penalty 1* scale factor
    /// given bmi: 27,  penalty 2* scale factor
    /// </example>
    const double BMIPenaltyScaleFactor = 0.6d;

    public static double BMIPenalty (double BMI, int iLowLimit, int iHighLimit)
    {
      if (iLowLimit >= iHighLimit)
        throw new ArgumentException("BMIPenalty: improper interval");

      if (BMI > iHighLimit)
      {
        return (BMI - iHighLimit) * BMIPenaltyScaleFactor;
      }
      else if (BMI < iLowLimit)
      {
        return (iLowLimit - BMI) * BMIPenaltyScaleFactor;
      }
      else
      {
        // (BMI >= iLowLimit && BMI <= iHighLimit)
        return 0.0;
      }
    }

    public static double WeeklyArenaCost (int totalCapacity)
    {
      return Math.Pow(((double)totalCapacity) / 10.0, 2.0) / 10.0;
    }



    public static readonly int[] doublerookiePromotionCosts = new int[] {
 50000   //€ 6th league 
,80000   //€ 5th league 
,110000  //€ 4th league 
,140000  //€ 3rd league 
,170000  //€ 2nd league 
,200000  //€ 1st league 
,230000  //€ Top        
    };

    /// <summary>
    /// 
    /// </summary>
    /// <param name="age"></param>
    /// <param name="match"></param>
    /// <returns></returns>
    public static double QuarterFatigueIncrease (int age, MatchType match)
    {
      double defaultQuarterFatigue = 0.0;
      switch (match)
      {
        case MatchType.League: defaultQuarterFatigue = 0.06; break;
        case MatchType.Friendly: defaultQuarterFatigue = 0.02; break;
        case MatchType.Nt: defaultQuarterFatigue = 0.012; break;
        default: defaultQuarterFatigue = 0.0; break;
      }

      return (age > 27)
        ? defaultQuarterFatigue + 0.0025 * ((double)age - 27.0)
        : defaultQuarterFatigue;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="doctors"></param>
    /// <returns></returns>
    public static double QuarterFatigueDrop (int doctors)
    {
      return 0.05 + doctors * 0.005;
    }

    /// <summary>
    /// age at which skills start dropping
    /// </summary>
    public const int SkillDegradingAge = 32;

    /// <summary>
    /// estimate date from charazay web service (interpolation)
    /// </summary>
    /// <param name="charazayDate"></param>
    /// <returns></returns>
    public static DateTime CharazayLong2Date (long charazayDate)
    {
      double oaTime = 1.15741E-5 * charazayDate + 2556904098E-5;
      return DateTime.FromOADate(oaTime);
    }

    //1/1/1970 1:59 (201/275)
    static readonly DateTime ref1 = new DateTime(1970, 1, 1, 1, 59, 0);
    //1/1/1970 0:59 (73/275)
    static readonly DateTime ref2 = new DateTime(1970, 1, 1, 0, 59, 0);

    public static DateTime EstimatedDateTime (double charazayDate)
    {
      return ref1.AddSeconds(charazayDate);
    }

    /// <summary>
    /// better estimate date from charazay web service (good mapping)
    /// </summary>
    /// <param name="charazayDate"></param>
    /// <returns></returns>
    public static DateTime EstimatedDateTime (uint charazayDate)
    {
      return EstimatedDateTime((double)charazayDate);
    }

  }
}
