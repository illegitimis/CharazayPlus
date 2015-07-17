
namespace AndreiPopescu.CharazayPlus
{
  using AndreiPopescu.CharazayPlus.Utils;
  using System;
  
  
  /// <summary>
  /// game engine changes
  /// </summary>
  public interface IPlayer2014
  {
    double DefensiveScore { get; }
    double ValueIndex { get; }

    double PercentageDefense_Dribling { get; }
    double PercentageDefense_Passing { get; }
  }

  /// <summary>
  /// This class was a first trial for defensive game changes of 2014
  /// However, using this together with inheriting from actual PG caused multiple inheritance
  /// I had this 
  /// <remarks>public class PG2014 : Player2014</remarks>
  /// situation, which shortcircuited the actual position classes. 
  /// that code needed duplication.
  /// In the end I chose 
  /// <remarks>public class PG2014 : PG, IPlayer2014</remarks>
  /// where I do not circumvent position classes, yet I duplicate 
  /// <see cref="Player2014"/> code, which becomes unused.
  /// </summary>
  [Obsolete]
  public abstract class Player2014 : Player, IPlayer2014
  {
    public Player2014 ( ) : base() { }
    public Player2014 (Xsd2.charazayPlayer xsdPlayer, bool ishw, bool isfatigue, bool isform)
      : base(xsdPlayer, ishw, isfatigue, isform) { }
    public Player2014 (Xsd2.charazayPlayerSkills xsdSkills) : base(xsdSkills) { }

    public abstract double PercentageDefense_Dribling { get; }
    public abstract double PercentageDefense_Passing { get; }

    /// <summary>
    /// 
    /// </summary>
    public override double DefensiveScore
    {
      get
      {
        return Linear.DotVectorProduct_Normalized(
          new double[] { 
              PercentageDefense_Defence
            , PercentageDefense_Footwork
            , PercentageDefense_Speed
            , PercentageDefense_Dribling
            , PercentageDefense_Passing 
          }
          ,
          new double[] { m_dDefence, m_dFootwork, m_dSpeed, m_dDribling, m_dPassing });
      }
    }

    /// <summary>
    /// classic players use their own stored assessed values
    /// these are averages so that position total score variance is removed
    /// </summary>
    public override double ValueIndex
    {
      get
      {
        return TotalScore / Extensions.PlayerExtensions.StoredAssessedValues[TrainingWeekIndex];
      }
    }
  }

 
}
