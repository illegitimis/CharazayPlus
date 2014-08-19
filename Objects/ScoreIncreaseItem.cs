using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightIdeasSoftware;

namespace AndreiPopescu.CharazayPlus.Objects
{
  /// <summary>
  /// object bound to the weekly training score increase list 
  /// bijective relation to <see cref="TrainingCategory"/>
  /// </summary>
  
  class ScoreIncreaseItem
  {
    [OLVColumn(DisplayIndex = 0, IsEditable = false, Width = 100, MinimumWidth = 80, MaximumWidth = 200, Title = "Player Name")]
    public string PlayerName { get; internal set; }
    //
    //DEFENSE = 1,
    //
    [OLVColumn(DisplayIndex = 1, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80
      , AspectToStringFormat = "{0:F05}", Title = "Defense", ToolTipText = "Weekly defense score increase")]
    public double Defense { get; internal set; }
    //
    //DRIBLING = 2,
    //
    [OLVColumn(DisplayIndex = 2, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80
      , AspectToStringFormat = "{0:F05}", Title = "Dribbling", ToolTipText = "Weekly dribbling score increase")]
    public double Dribbling { get; internal set; }
    //
    //PASSING = 3,
    //
    [OLVColumn(DisplayIndex = 3, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80
      , AspectToStringFormat = "{0:F05}", Title = "Passing", ToolTipText = "Weekly passing score increase")]
    public double Passing { get; internal set; }
    //
    //SPEED = 4,
    //
    [OLVColumn(DisplayIndex = 4, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80
      , AspectToStringFormat = "{0:F05}", Title = "Speed", ToolTipText = "Weekly Speed score increase")]
    public double Speed { get; internal set; }
    //
    //FOOTWORK = 5,
    //
    [OLVColumn(DisplayIndex = 5, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80
      , AspectToStringFormat = "{0:F05}", Title = "Footwork", ToolTipText = "Weekly Footwork score increase")]
    public double Footwork { get; internal set; }
    //
    //REBOUNDS = 6
    //
    [OLVColumn(DisplayIndex = 6, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80
      , AspectToStringFormat = "{0:F05}", Title = "Rebounds", ToolTipText = "Weekly Rebounds score increase")]
    public double Rebounds { get; internal set; }
    //
    //insideShooting = 7
    //
    [OLVColumn(DisplayIndex = 7, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80
      , AspectToStringFormat = "{0:F05}", Title = "Inside shooting", ToolTipText = "Weekly Inside shooting score increase")]
    public double Inside { get; internal set; }
    //
    //outsideShooting = 8
    //
    [OLVColumn(DisplayIndex = 8, IsEditable = false, Width = 65, MinimumWidth = 40, MaximumWidth = 80
      , AspectToStringFormat = "{0:F05}", Title = "Outside shooting", ToolTipText = "Weekly Outside shooting score increase")]
    public double Outside { get; internal set; }  
    
  }
}
