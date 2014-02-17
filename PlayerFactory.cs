
namespace AndreiPopescu.CharazayPlus
{
  using System;
  using System.Collections.Generic;
  using System.Text;
  using AndreiPopescu.CharazayPlus.Utils;

  public static class PlayerFactory
  {
    static readonly Xsd2.charazayPlayerSkills s_sk15 = new Xsd2.charazayPlayerSkills()
    {
      defence = 5
      ,
      freethrow = 4
      ,
      twopoint = 4
      ,
      threepoint = 3
      ,
      dribling = 5
      ,
      passing = 5
      ,
      speed = 5
      ,
      footwork = 5
      ,
      rebounds = 5
    };

static readonly Xsd2.charazayPlayerBasic s_basic15 = new Xsd2.charazayPlayerBasic() { age = 15 };
    static readonly Xsd2.charazayPlayer s_15 = new Xsd2.charazayPlayer() { basic = s_basic15, skills = s_sk15 };





      public static Player GetPlayerByPosition (PlayerPosition pos)
    {
      switch (pos)
      {
        case PlayerPosition.PG: return new PG();
        case PlayerPosition.SG: return new SG();
        case PlayerPosition.SF: return new SF();
        case PlayerPosition.PF: return new PF();
        case PlayerPosition.C: return new C();
        default: throw new NotSupportedException("GetPlayerByPosition");
      }
    }

    /// <summary>
    /// assign active skills and age
    /// </summary>
    /// <returns>valiant 15 yo player, no matter the position</returns>
    public static Player GetWorthy15YearOld (PlayerPosition pos)
    {
      Player p = null;
      switch (pos)
      {
        case PlayerPosition.PG: p = new PG(s_15); break;
        case PlayerPosition.SG: p= new SG(s_15); break;
        case PlayerPosition.SF: p= new SF(s_15); break;
        case PlayerPosition.PF: p= new PF(s_15); break;
        case PlayerPosition.C: p= new C(s_15); break;
        default: throw new NotSupportedException("GetPlayerByPosition");
      }
      p.IsHW = false;
      p.IsPositionHeightAdequacy = false;
      p.IsFatigueFactor = false;
      p.IsFormFactor = false;
      return p;
    }


    /// <summary>
    /// predict player value considered balanced training plan
    /// equal amount each year
    /// </summary>
    /// <param name="week">desired assessment week</param>
    /// <param name="pos">player type</param>
    /// <returns></returns>
    public static double PredictValue (ushort week, PlayerPosition pos)
    {
      if (week < 0 || week > 17 * 17)
        throw new ArgumentException("week");

      Player predictValuePlayer = PlayerFactory.GetWorthy15YearOld(pos);
      //season has 15 weeks (leaague), 2 offseason
      //Experience raise = 1.5
      //predictValuePlayer.m_dExperience += 1.5d;
      predictValuePlayer.m_dExperience = 0.1 * week;
      //
      ushort currentWeek = 0;
      while (currentWeek < week)
      {
        foreach (TrainingCategories eTc in Enum.GetValues(typeof(TrainingCategories)))
        {
          if (currentWeek == week)
            break;
          byte noWeeksSkillTraining = predictValuePlayer.TrainingPlan[(byte)eTc];
          while (noWeeksSkillTraining > 0)
          {
            if (currentWeek == week)
              break;
            byte age = (byte)((byte)15 + (byte)(currentWeek / 17));
            switch (eTc)
            {
              case TrainingCategories.defense:
                Compute.WeeklySkillAddition(ref predictValuePlayer.m_dDefence, age);
                break;
              case TrainingCategories.dribling:
                Compute.WeeklySkillAddition(ref predictValuePlayer.m_dDribling, age);
                break;
              case TrainingCategories.passing:
                Compute.WeeklySkillAddition(ref predictValuePlayer.m_dPassing, age);
                break;
              case TrainingCategories.speed:
                Compute.WeeklySkillAddition(ref predictValuePlayer.m_dSpeed, age);
                break;
              case TrainingCategories.footwork:
                Compute.WeeklySkillAddition(ref predictValuePlayer.m_dFootwork, age);
                break;
              case TrainingCategories.rebounds:
                Compute.WeeklySkillAddition(ref predictValuePlayer.m_dRebounds, age);
                break;
              case TrainingCategories.inside_sh:
                {
                  Compute.WeeklySkillAddition(ref predictValuePlayer.m_dTwoPoint, age);
                  Compute.WeeklySkillAddition(ref predictValuePlayer.m_dFreethrows, age);
                } break;
              case TrainingCategories.outside_sh:
                {
                  Compute.WeeklySkillAddition(ref predictValuePlayer.m_dThreePoint, age);
                  Compute.WeeklySkillAddition(ref predictValuePlayer.m_dFreethrows, age);
                } break;
              default: throw new NotSupportedException();
            }

            noWeeksSkillTraining--;
            currentWeek++;
          }
        }
      }
      predictValuePlayer.IsHW = false;
      predictValuePlayer.IsFatigueFactor = false;
      predictValuePlayer.IsFormFactor = false;
      // compute active skills at the end
      predictValuePlayer.ActiveSkills();
#if DEBUG
      System.Diagnostics.Debug.WriteLine(string.Format("{0,-10}{1,-10}", week, predictValuePlayer));
#endif

      return predictValuePlayer.TotalScore;
    }
  }
}
