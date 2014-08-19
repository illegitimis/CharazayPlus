using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AndreiPopescu.CharazayPlus.Utils;
using BrightIdeasSoftware;

namespace AndreiPopescu.CharazayPlus.Objects
{
  /// <summary>
  /// binding type for the training efficiency list view of the <see cref="TrainingTabUserControl"/>, top right
  /// </summary>
  internal class TrainingEfficiencyScoreItem
  {
    private readonly TrainingCategory tc1;
    private readonly TrainingCategory tc2;
    private readonly double value;

    public TrainingEfficiencyScoreItem (TrainingCategory tc1_2, TrainingCategory tc2_2, double currentSum)
    {
      this.tc1 = tc1_2;
      this.tc2 = tc2_2;
      this.value = currentSum;
    }
    [OLVColumn(DisplayIndex = 0, IsEditable = false, Width = 75, MinimumWidth = 40, MaximumWidth = 100, Title = "Training group 1")]
    public TrainingCategory TC1 { get { return tc1; } }
    [OLVColumn(DisplayIndex = 1, IsEditable = false, Width = 75, MinimumWidth = 40, MaximumWidth = 100, Title = "Training group 2")]
    public TrainingCategory TC2 { get { return tc2; } }
    [OLVColumn(DisplayIndex = 2, IsEditable = false, Width = 75, MinimumWidth = 40, MaximumWidth = 100, AspectToStringFormat = "{0:F05}", Title = "Total score increase")]
    public double Value { get { return value; } }

    public override string ToString ( )
    {
      return string.Format("{0},{1},{2:F04}", tc1, tc2, value);
    }
  }

  /// <summary>
  /// binding type for the training combination details list view of the <see cref="TrainingTabUserControl"/>, bottom right
  /// </summary>
  internal class TrainingCombinationItem
  {
    //private readonly TrainingCategory tc1;
    private readonly double d1;
    //private readonly TrainingCategory tc2;
    private readonly double d2;
    private readonly string fullName;

    public TrainingCombinationItem (string fn, double d1, double d2)
    {
      this.d1 = d1;
      this.d2 = d2;
      this.fullName = fn;
    }

    /// <summary>
    /// TrainingCategory 1 total score increase
    /// </summary>
    [OLVColumn(DisplayIndex = 1, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Title = "Increase in 1st training category", AspectToStringFormat = "{0:F05}")]
    public double Category1Increase { get { return this.d1; } }
    [OLVColumn(DisplayIndex = 2, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80, Title = "Increase in 2nd training category", AspectToStringFormat = "{0:F05}")]
    public double Category2Increase { get { return this.d2; } }
    [OLVColumn(DisplayIndex = 0, IsEditable = false, Width = 130, MinimumWidth = 100, MaximumWidth = 160, Title = "Player")]
    public string FullName { get { return this.fullName; } }

    public override string ToString ( ) { return string.Format("{0},{1},{2}", fullName, d1, d2); }
  }
}
