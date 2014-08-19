using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using AndreiPopescu.CharazayPlus.Objects;
using AndreiPopescu.CharazayPlus.Utils;

namespace AndreiPopescu.CharazayPlus.Data
{
  /// <summary>
  /// static data related to player training (weekly increase in skill & speed)
  /// </summary>
  class TrainingEnvironment
  {
    #region Singleton logic

    public static IList<SkillIncreaseItem> SkillIncreaseItems
    {
      get
      {
        return Nested.SkillIncreaseItems;
      }
    }

    public static IList<ScoreIncreaseItem> ScoreIncreaseItems
    {
      get
      {
        return Nested.ScoreIncreaseItems;
      }
    }

    class Nested
    {
      // Explicit static constructor to tell C# compiler
      // not to mark type as beforefieldinit
      static Nested ( )
      {
        SkillIncreaseItems=new List<SkillIncreaseItem>();
        ScoreIncreaseItems=new List<ScoreIncreaseItem>();

        foreach (Player P in PlayersEnvironment.OptimumPlayers)
      {
        SkillIncreaseItems.Add (new SkillIncreaseItem()
        {
          PlayerName = P.FullName
          ,
          Defense = P.SkillTrainingDelta(Skill.DEFENSE, PlayersEnvironment.MaxCoach)
          ,
          Dribbling = P.SkillTrainingDelta(Skill.DRIBLING, PlayersEnvironment.MaxCoach)
          ,
          Footwork = P.SkillTrainingDelta(Skill.FOOTWORK, PlayersEnvironment.MaxCoach)
          ,
          FreeThrows = P.SkillTrainingDelta(Skill.FREETHROWS, PlayersEnvironment.MaxCoach)
          ,
          Passing = P.SkillTrainingDelta(Skill.PASSING, PlayersEnvironment.MaxCoach)
          ,
          Rebounds = P.SkillTrainingDelta(Skill.REBOUNDS, PlayersEnvironment.MaxCoach)
          ,
          Speed = P.SkillTrainingDelta(Skill.SPEED, PlayersEnvironment.MaxCoach)
          ,
          ThreePoint = P.SkillTrainingDelta(Skill.THREEPOINT, PlayersEnvironment.MaxCoach)
          ,
          TwoPoint = P.SkillTrainingDelta(Skill.TWOPOINT, PlayersEnvironment.MaxCoach)
        });  
        //
        ScoreIncreaseItems.Add(new ScoreIncreaseItem()
        {
          PlayerName = P.FullName,
          Defense = P.GetScoreTrainingDelta(TrainingCategory.defense, PlayersEnvironment.MaxCoach),
          Dribbling = P.GetScoreTrainingDelta(TrainingCategory.dribling, PlayersEnvironment.MaxCoach),
          Footwork = P.GetScoreTrainingDelta(TrainingCategory.footwork, PlayersEnvironment.MaxCoach),
          Inside = P.GetScoreTrainingDelta(TrainingCategory.insideShooting, PlayersEnvironment.MaxCoach),
          Outside = P.GetScoreTrainingDelta(TrainingCategory.outsideShooting, PlayersEnvironment.MaxCoach),
          Passing = P.GetScoreTrainingDelta(TrainingCategory.passing, PlayersEnvironment.MaxCoach),
          Rebounds = P.GetScoreTrainingDelta(TrainingCategory.rebounds, PlayersEnvironment.MaxCoach),
          Speed = P.GetScoreTrainingDelta(TrainingCategory.speed, PlayersEnvironment.MaxCoach),
        });
      }
        SkillIncreaseItems.Add(new SkillIncreaseItem()
        {
          PlayerName = "TOTAL SKILL INCREASE"
          ,
          Defense = SkillIncreaseItems.Sum (x=>x.Defense)
          ,
          Dribbling = SkillIncreaseItems.Sum(x => x.Dribbling)
          ,
          Footwork = SkillIncreaseItems.Sum(x => x.Footwork)
          ,
          FreeThrows = SkillIncreaseItems.Sum(x=>x.FreeThrows)
          ,
          Passing = SkillIncreaseItems.Sum(x => x.Passing)
          ,
          Rebounds = SkillIncreaseItems.Sum(x => x.Rebounds)
          ,
          Speed = SkillIncreaseItems.Sum(x => x.Speed)
          ,
          ThreePoint = SkillIncreaseItems.Sum(x => x.ThreePoint)
          ,
          TwoPoint = SkillIncreaseItems.Sum(x => x.TwoPoint)
        });
        //
        ScoreIncreaseItems.Add(new ScoreIncreaseItem()
        {
          PlayerName = "TOTAL SCORE INCREASE",
          Defense = ScoreIncreaseItems.Sum (y=>y.Defense),
          Dribbling = ScoreIncreaseItems.Sum(y => y.Dribbling),
          Footwork = ScoreIncreaseItems.Sum(y => y.Footwork),
          Inside = ScoreIncreaseItems.Sum(y => y.Inside),
          Outside = ScoreIncreaseItems.Sum(y => y.Outside),
          Passing = ScoreIncreaseItems.Sum(y => y.Passing),
          Rebounds = ScoreIncreaseItems.Sum(y => y.Rebounds),
          Speed = ScoreIncreaseItems.Sum(y => y.Speed),
        });
    
      }

      internal static readonly IList<SkillIncreaseItem> SkillIncreaseItems;
      internal static readonly IList<ScoreIncreaseItem> ScoreIncreaseItems;
    }

    #endregion
  }
}
