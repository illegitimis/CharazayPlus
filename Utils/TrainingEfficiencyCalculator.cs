using System;
using System.Collections.Generic;
using System.Text;
using BrightIdeasSoftware;
#if DOTNET30
using System.Linq;
#endif

namespace AndreiPopescu.CharazayPlus.Utils
{
  internal static class TrainingEfficiencyCalculator
  {
    internal static IEnumerable<TrainingEfficiencyScoreItem> Go(IEnumerable<Player> optimumPlayers, Coach maxCoach)
    {
      byte minTc = (byte)TrainingCategories.defense;
      byte maxTc = (byte)TrainingCategories.outside_sh;

      for (byte b1 = minTc; b1<maxTc-1; b1++)
      {
        TrainingCategories tc1 = (TrainingCategories)b1;
        for (byte b2 = (byte)(1+b1); b2<maxTc; b2++)
      {
          TrainingCategories tc2 = (TrainingCategories)b2;
#if DOTNET30
          optimumPlayers.Sum(p => Math.Max(p.GetScoreTrainingDelta(tc1, maxCoach), p.GetScoreTrainingDelta(tc2, maxCoach)))
#endif
          double currentSum = 0d;
          foreach (var p in optimumPlayers)
            currentSum += Math.Max(p.GetScoreTrainingDelta(tc1, maxCoach), p.GetScoreTrainingDelta(tc2, maxCoach));
          yield return new TrainingEfficiencyScoreItem(tc1, tc2, currentSum);
      }
      }
      
    }

    internal static IEnumerable<Player> Over18 (IEnumerable<Player> players)
    {
      #if DOTNET30
      return players.Where ( p => p.Age < = 18);
#endif
      foreach (var p in players)
        if (p.Age > 18)
          yield return p;
    }

    #if DOTNET30
    internal static IEnumerable<Player> TopN (IEnumerable<Player> players, int n)
    {
      return players.OrderByDescending(grade => grade).Take(n);      
    }
    #endif
      
    //The QuickSelect_kth algorithm quickly finds the k-th smallest element of an unsorted array of n elements

    internal static T QuickSelect_kth<T> (T[] A, int k) where T : IComparable, IComparable<T>
    {
      //let r be chosen uniformly at random in the range 1 to length(A)
      int r = A.Length / 2;
      //    let pivot = A[r]
      T pivot = A[r];
      //let A1, A2 be new arrays
      int pos1=0, pos2=0;
      T[] A1 = new T[A.Length], A2 = new T[A.Length];
      //# split into a pile A1 of small elements and A2 of big elements
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
      {//  # it's in the pile of small elements
        return QuickSelect_kth(A1, k);
      }
      else if (k > A.Length - pos2)
      {//  # it's in the pile of big elements
        return QuickSelect_kth(A2, k - (A.Length - pos2));
      }
      else
        //  # it's equal to the pivot
        return pivot;
      
    }

    internal static Player[] TopN (Player[] players, int n)
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
  
  internal class TrainingEfficiencyScoreItem 
  {
    private readonly TrainingCategories tc1;
    private readonly TrainingCategories tc2;
    private readonly double value;
    
    public TrainingEfficiencyScoreItem (TrainingCategories tc1_2, TrainingCategories tc2_2, double currentSum)
    {
      // TODO: Complete member initialization
      this.tc1 = tc1_2;
      this.tc2 = tc2_2;
      this.value = currentSum;
    }
    [OLVColumn(DisplayIndex = 0, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Title="Training group 1")] 
    public TrainingCategories TC1 { get { return tc1; } }
    [OLVColumn(DisplayIndex = 1, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Title = "Training group 2")] 
    public TrainingCategories TC2 { get { return tc2; } }
    [OLVColumn(DisplayIndex = 2, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, AspectToStringFormat = "{0:F04}", Title="Total score increase")] 
    public double Value { get { return value; } }

  }
}
