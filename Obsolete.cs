#pragma warning disable 0612, 0618

namespace AndreiPopescu.CharazayPlus
{
  using System;
  using AndreiPopescu.CharazayPlus.Utils;
  //using System.Linq;

  public abstract partial class Player
  {
    // coach own raise
    //The coach will train 0,06 every week for the skills he's training (coach own raise is 0,06)
    [Obsolete("replaced by public double SkillTrainingDelta (Skills skill, Coach coach)")]
    public double GetSkillTrainingDelta (Skills skill, Coach coach)
    {
      // difference between coach skill and player skill
      int delta = 0;

      switch (skill)
      {
        case Skills.sDEFENSE: delta = coach.Defence - Defence_Display; break;
        case Skills.sDRIBLING: delta = delta = coach.Dribling - Dribling_Display; break;
        case Skills.sPASSING: delta = coach.Passing - Passing_Display; break;
        case Skills.sSPEED: delta = coach.Speed - Speed_Display; break;
        case Skills.sFOOTWORK: delta = coach.Footwork - Footwork_Display; break;
        case Skills.sREBOUNDS: delta = coach.Rebounds - Rebounds_Display; break;
        case Skills.sTWOPOINT: delta = coach.TwoPoint - TwoPoint_Display; break;
        case Skills.sTHREEPOINT: delta = coach.ThreePoint - ThreePoint_Display; break;
        case Skills.sFREETHROWS: delta = coach.Freethrows - Freethrows_Display; break;
      }

      double weeklySkillRaiseMultiplier = Compute.s_weeklySkillTrainAgeMultiplier[Age - 15];
      return Compute.WeeklySkillRaise((double)delta, weeklySkillRaiseMultiplier);
    }

    [Obsolete]
    public double predictValue (byte age)
    {
      if (age < 15 || age > 70)
        throw new ArgumentException("age");

      Player pvp = PlayerFactory.GetWorthy15YearOld(PositionEnum);
      age -= 15;
      pvp.m_dExperience += age * 1.5d;

      while (age > 0)
      {
        double weeklySkillRaiseMultiplier = Compute.s_weeklySkillTrainAgeMultiplier[age];

        foreach (TrainingCategories eTc in Enum.GetValues(typeof(TrainingCategories)))
        {
          byte noWeeksSkillTraining = TrainingPlan[(int)eTc];
          while (noWeeksSkillTraining > 0)
          {
            switch (eTc)
            {
              case TrainingCategories.defense:
                Compute.WeeklySkillAddition(ref pvp.m_dDefence, weeklySkillRaiseMultiplier);
                break;
              case TrainingCategories.dribling:
                Compute.WeeklySkillAddition(ref pvp.m_dDribling, weeklySkillRaiseMultiplier);
                break;
              case TrainingCategories.passing:
                Compute.WeeklySkillAddition(ref pvp.m_dPassing, weeklySkillRaiseMultiplier);
                break;
              case TrainingCategories.speed:
                Compute.WeeklySkillAddition(ref pvp.m_dSpeed, weeklySkillRaiseMultiplier);
                break;
              case TrainingCategories.footwork:
                Compute.WeeklySkillAddition(ref pvp.m_dFootwork, weeklySkillRaiseMultiplier);
                break;
              case TrainingCategories.rebounds:
                Compute.WeeklySkillAddition(ref pvp.m_dRebounds, weeklySkillRaiseMultiplier);
                break;
              case TrainingCategories.inside_sh:
                {
                  Compute.WeeklySkillAddition(ref pvp.m_dTwoPoint, weeklySkillRaiseMultiplier);
                  Compute.WeeklySkillAddition(ref pvp.m_dFreethrows, weeklySkillRaiseMultiplier);
                } break;
              case TrainingCategories.outside_sh:
                {
                  Compute.WeeklySkillAddition(ref pvp.m_dThreePoint, weeklySkillRaiseMultiplier);
                  Compute.WeeklySkillAddition(ref pvp.m_dFreethrows, weeklySkillRaiseMultiplier);
                } break;
              default: throw new NotSupportedException();
            }

            noWeeksSkillTraining--;
          }
        }

        age--;
      }

      pvp.ActiveSkills();

      return pvp.TotalScore;
    }

  }
}

namespace AndreiPopescu.CharazayPlus.Utils
{
  using System;

  public static partial class Compute
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="delta">difference between coach skill and actual player skill</param>
    /// <param name="weeklySkillRaiseMultiplier">age based multiplier</param>
    /// <returns>weekly skill raise</returns>
    [Obsolete("use the version with 3 parameters")]
    public static double WeeklySkillRaise (double delta, double weeklySkillRaiseMultiplier)
    {
      // coach impact?
      //return (1 + Math.Max(0d, (double)delta) * 0.03) * weeklySkillRaiseMultiplier;
      //The coach will train 0,06 every week for the skills he's training.
      return (1 + Math.Max(0d, (double)delta) * 0.06) * weeklySkillRaiseMultiplier;
    }

    [Obsolete]
    public static void WeeklySkillAddition (ref double skillValue, double weeklySkillRaiseMultiplier)
    {
      double delta = s_properCoachSkillReference - skillValue;
      skillValue += WeeklySkillRaise(delta, weeklySkillRaiseMultiplier);
    }

    //15	0,16
    //16	0,1525
    //17	0,145
    //18	0,1375
    //19	0,13
    //20	0,1225
    //21	0,115
    //22	0,1075
    //23	0,1
    //24	0,0925
    //25	0,085
    //26	0,0775
    //27	0,07
    //28	0,0625
    //29	0,055
    //30	0,0475
    //31	0,04
    //32	0,0325
    [Obsolete("weeklySkillTrainAgeMultiplier")]
    public static double AgeWeeklySkillRaise (byte age)
    {
      return 0.2725 - 0.0075 * (double)age;
    }

    // no increase age > 34s
    public static readonly double[] s_weeklySkillTrainAgeMultiplier_Older = new double[] 
    {
      0.158    //15yo      
    , 0.1548   //16yo      
    , 0.1516   //17yo      
    , 0.1485   //18yo      
    , 0.1453   //19yo      
    , 0.1421   //20yo      
    , 0.139    //21yo      
    , 0.135    //22yo      
    , 0.131    //23yo      
    , 0.127    //24yo      
    , 0.1211   //25yo      
    , 0.117    //26yo      
    , 0.111    //27yo      
    , 0.106    //28yo      
    , 0.099    //29yo      
    , 0.0875   //30yo      
    , 0.08125  //31yo      
    , 0.075    //32yo     //  
    , 0.06666  //33yo     // 
    , 0.05833  //34yo     //     
    };

    #region old form code
    //[Obsolete()]
    //private void DownloadXml()
    //{
    //  string user = "stergein";
    //  string pass = "security_code";

    //  Web.XmlDownloadItem[] xmls = new Web.XmlDownloadItem[] {
    //    new Web.MyPlayersXml (user, pass)
    //    , new Web.UserPlayersXml (user, pass, 23152)
    //    , new Web.UserPlayersXml (user, pass, 230611)
    //    , new Web.ArenaXml (user, pass, 23152)
    //    , new Web.CoachesXml (user, pass)
    //    , new Web.CountryDivisionListXml (user, pass, 5)
    //    , new Web.CountryDivisionListXml (user, pass, 46)
    //    , new Web.CountryInfoXml (user, pass, 5)
    //    , new Web.CountryInfoXml (user, pass, 46)
    //    , new Web.DivisionScheduleXml (user, pass, 1014)
    //    , new Web.DivisionScheduleXml (user, pass, 4194)
    //    , new Web.DivisionStandingsXml (user, pass, 1014)
    //    , new Web.DivisionStandingsXml (user, pass, 4194)
    //    , new Web.EconomyXml (user, pass)
    //    , new Web.MatchXml (user, pass, 16052251)
    //    , new Web.MyInfoXml (user, pass)
    //    , new Web.MyScheduleXml (user, pass)
    //    , new Web.MyTeamInfoXml  (user, pass)
    //    , new Web.MyTransfersXml (user, pass)
    //    , new Web.PlayerXml (user, pass, 22620384)
    //    , new Web.PlayerXml (user, pass, 20804073)
    //    , new Web.UserInfoXml (user, pass, 230611)
    //    //, new Web.UserScheduleXml (user, pass, 23152)
    //    , new Web.UserTeamInfoXml (user, pass, 23152)
    //    , new Web.UserTransfersXml (user, pass, 23152)
    //};

    //  using (Web.Downloader crawler = new Web.Downloader())
    //  {
    //    foreach (Web.XmlDownloadItem xml in xmls)
    //      crawler.Add(xml);

    //    crawler.Get(true);
    //  }


    //} 
    #endregion

  }

}

#pragma warning restore 0612, 0618