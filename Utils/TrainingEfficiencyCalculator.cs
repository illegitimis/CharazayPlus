using System;
using System.Collections.Generic;
using System.Text;
using BrightIdeasSoftware;
using AndreiPopescu.CharazayPlus.Objects;
#if DOTNET30
using System.Linq;
#endif

namespace AndreiPopescu.CharazayPlus.Utils
{
  /// <summary>
  /// computes the best training combination by maximizing score
  /// </summary>
  internal static class TrainingEfficiencyCalculator
  {
    /// <summary>
    /// best training for selected player pool
    /// </summary>
    /// <param name="playerPool">player collection on which computation should be done</param>
    /// <param name="coach">trainer</param>
    /// <param name="TrainingCombinationValues">player training group choices for m selected training category pair</param>
    /// <param name="TrainingEfficiencyScores">score increases for all training category pairs</param>
    internal static void Go (IEnumerable<Player> playerPool, Coach coach
      , ref IDictionary<TrainingCombination,List<TrainingCombinationItem>> TrainingCombinationValues
      , ref IList<TrainingEfficiencyScoreItem> TrainingEfficiencyScores)
    {
      TrainingCombinationValues.Clear();
      TrainingEfficiencyScores.Clear();
      //
      // do not allow duplicate pairs
      // the training combination should be tranzitive
      //
      foreach (var tc1 in (TrainingCategory[])Enum.GetValues(typeof(TrainingCategory)))
      {
        foreach (var tc2 in (TrainingCategory[])Enum.GetValues(typeof(TrainingCategory)))
        {
          if (tc2==tc1) continue;

          TrainingCombination crtTC = new TrainingCombination(tc1, tc2);
          if (TrainingCombinationValues.ContainsKey(crtTC))
            continue;
          //
          double currentSum = 0d;
          List<TrainingCombinationItem> tcis = new List<TrainingCombinationItem>();
          foreach (var p in playerPool)
          {
            double v1 = p.GetScoreTrainingDelta(tc1, coach);
            double v2 = p.GetScoreTrainingDelta(tc2, coach);
            currentSum += Math.Max(v1, v2);
            tcis.Add(new TrainingCombinationItem(p.FullName, v1, v2));
          }
          //
          TrainingCombinationValues.Add(crtTC, tcis);
          //
          //if (TrainingEfficiencyScoreItem)
          TrainingEfficiencyScores.Add( new TrainingEfficiencyScoreItem(tc1, tc2, currentSum));
        }
      }

    }

    internal static IEnumerable<Player> Under32 (IEnumerable<Player> players)
    {
#if DOTNET30
        return players.Where ( p => p.Age < 32);
#else
      foreach (var p in players)
        if (p.Age > 18)
          yield return p;
#endif
      
    }

    #if DOTNET30
    internal static IEnumerable<Player> TopN (IEnumerable<Player> players, int n)
    {
      return players.OrderByDescending(p => p.TotalScore).Take(n);      
    }
    #endif
      
    /// <summary>
    /// The QuickSelect_kth algorithm quickly finds the k-th smallest element of an unsorted array of n elements
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="A"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    static T QuickSelect_kth<T> (T[] A, int k) where T : IComparable, IComparable<T>
    {
      //let r be chosen uniformly at random in the range 1 to length(A)
      int r = A.Length / 2;
      //    let pivot = A[r]
      T pivot = A[r];
      //let A1, A2 be new arrays
      int pos1=0, pos2=0;
      T[] A1 = new T[A.Length], A2 = new T[A.Length];
      //# split into m pile A1 of small elements and A2 of big elements
      //  if A[i] < pivot then
      //    append A[i] to A1
      //  else if A[i] > pivot then
      //    append A[i] to A2
      //  else
      //    # do nothing
      //end for
      foreach (var a in A)
      { 
        if (a.CompareTo(pivot) < 0) { A1[pos1] = a; pos1++; }
        if (a.CompareTo(pivot) > 0) { A2[pos2] = a; pos2++; }        
      }
      Array.Resize(ref A1, pos1);
      Array.Resize(ref A2, pos2);
      if (k <= pos1)
      {//  # it'tlPlayer in the pile of small elements
        return QuickSelect_kth(A1, k);
      }
      else if (k > A.Length - pos2)
      {//  # it'tlPlayer in the pile of big elements
        return QuickSelect_kth(A2, k - (A.Length - pos2));
      }
      else
        //  # it'tlPlayer equal to the pivot
        return pivot;
      
    }

    static Player[] TopN (Player[] players, int n)
    {
      if (players.Length > n)
      {
        Player[] topn = (Player[])players.Clone();
        Comparison<Player> compDesc = delegate(Player x, Player y) { return (x.TotalScore > y.TotalScore) ? -1 : ((x.TotalScore == y.TotalScore) ? 0 : 1); };
        Array.Sort(topn, compDesc);
        //Array.Reverse(topn);
        Array.Resize(ref topn, n);
        return topn;
      }
      else return players;
    }

    /// <summary>
    /// best <paramref name="n"/> players by score
    /// </summary>
    /// <param name="players">list of players</param>
    /// <param name="n">number of players</param>
    /// <returns>best <paramref name="n"/> players by score</returns>
    internal static List<Player> TopN (List<Player> players, int n)
    {
      if (players.Count > n)
      {
        List<Player> topn = players;
        Comparison<Player> compDesc = delegate(Player x, Player y) { return (x.TotalScore > y.TotalScore) ? -1 : ((x.TotalScore == y.TotalScore) ? 0 : 1); };
        topn.Sort(compDesc);
        return topn.GetRange(0, n); 
      }
      else return players;
    }

  }
  
 

  /// <summary>
  /// m pair of training categories
  /// </summary>
  internal class TrainingCombination : 
    IComparable
    ,
    IComparable<TrainingCombination>
    ,
    IEquatable<TrainingCombination>
    , 
    IEqualityComparer<TrainingCombination>
  {
    private readonly TrainingCategory tc1;
    private readonly TrainingCategory tc2;

    public TrainingCategory FirstCategory { get { return (byte)tc1 < (byte)tc2 ? tc1 : tc2; ;} }
    public TrainingCategory SecondCategory { get { return (byte)tc1 > (byte)tc2 ? tc1 : tc2; ;} }
    
    public TrainingCombination (TrainingCategory tc1, TrainingCategory tc2)
    {
      this.tc1 = tc1;
      this.tc2 = tc2;      
    }

    

    public static bool operator == (TrainingCombination x, TrainingCombination y)
    {
      return (x.FirstCategory == y.FirstCategory && x.SecondCategory == y.SecondCategory);
    }
    public static bool operator != (TrainingCombination x, TrainingCombination y)
    {
      return !(x == y);
    }

    public bool Equals (TrainingCombination other)
    {
      return this == other;
    }

    public bool Equals (TrainingCombination x, TrainingCombination y)
    {
      return x == y;
    }
    public override bool Equals (object obj)
    {
      return this == (TrainingCombination)obj;
    }

    public int GetHashCode (TrainingCombination obj)
    {
      return obj.GetHashCode();
    }
    public override int GetHashCode ( )
    {
      return  (int)this.FirstCategory * 10 + (int)this.SecondCategory;
    }

    public int CompareTo (object obj)
    {
      return this.CompareTo(obj as TrainingCombination);
    }

    public int CompareTo (TrainingCombination other)
    {
      return this > other ? 1 : (this == other ? 0 : -1);
    }

    public static bool operator> (TrainingCombination x, TrainingCombination y) 
    {
      return x.GetHashCode()>y.GetHashCode();
    }
    public static bool operator < (TrainingCombination x, TrainingCombination y)
    {
      return x.GetHashCode() < y.GetHashCode();
    }
    public static bool operator >= (TrainingCombination x, TrainingCombination y)
    {
      return x.GetHashCode() >= y.GetHashCode();
    }
    public static bool operator <= (TrainingCombination x, TrainingCombination y)
    {
      return x.GetHashCode() <= y.GetHashCode();
    }
    public override string ToString ( )
    {
      return string.Format("{0},{1}", tc1, tc2);
    }
    
  }


}
