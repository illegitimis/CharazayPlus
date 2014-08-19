using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightIdeasSoftware;

namespace AndreiPopescu.CharazayPlus.Objects
{
  /// <summary>
  /// bijective relation to <see cref="Skill"/> enum
  /// column indices must be same with enum values
  /// </summary>
  class SkillIncreaseItem
  {
    [OLVColumn(DisplayIndex = 0, IsEditable = false, Width = 100, MinimumWidth = 80, MaximumWidth = 200, Title = "Player Name")]
    public string PlayerName { get; internal set; }
    //
    //DEFENSE = 1,
    //
    [OLVColumn(DisplayIndex = 1, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80
      , AspectToStringFormat = "{0:F04}" ,Title = "Defense", ToolTipText="Weekly defense increase")]
    public double Defense { get; internal set; }
    //
    //TWOPOINT = 2,
    //
    [OLVColumn(DisplayIndex = 2, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80
      , AspectToStringFormat = "{0:F04}" ,Title = "Two point", ToolTipText="Weekly 2 point increase")]
    public double TwoPoint { get; internal set; }
    //
    //THREEPOINT = 3,
    //
    [OLVColumn(DisplayIndex = 3, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80
      , AspectToStringFormat = "{0:F04}" ,Title = "Three Point", ToolTipText="Weekly 3 point increase")]
    public double ThreePoint { get; internal set; }
    //
    //FREETHROWS = 4,
    //
    [OLVColumn(DisplayIndex = 4, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80
      , AspectToStringFormat = "{0:F04}", Title = "Free throws", ToolTipText = "Weekly free throws increase")]
    public double FreeThrows { get; internal set; }
    //
    //DRIBLING = 5,
    //
    [OLVColumn(DisplayIndex = 5, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80
      , AspectToStringFormat = "{0:F04}", Title = "Dribbling", ToolTipText = "Weekly dribbling increase")]
    public double Dribbling { get; internal set; }
    //
    //PASSING = 6,
    //
    [OLVColumn(DisplayIndex = 6, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80
      , AspectToStringFormat = "{0:F04}", Title = "Passing", ToolTipText = "Weekly passing increase")]
    public double Passing { get; internal set; }
    //
    //SPEED = 7,
    //
    [OLVColumn(DisplayIndex = 7, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80
      , AspectToStringFormat = "{0:F04}", Title = "Speed", ToolTipText = "Weekly Speed increase")]
    public double Speed { get; internal set; }
    //
    //FOOTWORK = 8,
    //
    [OLVColumn(DisplayIndex = 8, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80
      , AspectToStringFormat = "{0:F04}", Title = "Footwork", ToolTipText = "Weekly Footwork increase")]
    public double Footwork { get; internal set; }
    //
    //REBOUNDS = 9
    //
    [OLVColumn(DisplayIndex = 9, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80
      , AspectToStringFormat = "{0:F04}", Title = "Rebounds", ToolTipText = "Weekly Rebounds increase")]
    public double Rebounds { get; internal set; }
    

    //public override string ToString ( )
    //{
    //  return string.Format("{0},{1},{2:F04}", tc1, tc2, value);
    //}

    
    
    
    
   
  }
}
