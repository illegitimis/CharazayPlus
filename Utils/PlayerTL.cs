﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.0.30319.1.
// 
namespace AndreiPopescu.CharazayPlus.Utils
{
  using System.Xml.Serialization;
  using System;
  using BrightIdeasSoftware;


  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class TLPlayers
  {

    private TLPlayer[] tLPlayerField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TLPlayer")]
    public TLPlayer[] TLPlayer
    {
      get
      {
        return this.tLPlayerField;
      }
      set
      {
        this.tLPlayerField = value;
      }
    }
  }

  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class TLPlayer
  {

    #region specific difference
    private string positionField;
    [OLVColumn(DisplayIndex = 0, IsEditable = false, Width = 35, MinimumWidth = 25, MaximumWidth = 45, Title = "Position")]
    public PlayerPosition Pos
    {
      get { return (PlayerPosition)System.Enum.Parse(typeof(PlayerPosition), positionField); }
    }
    /// <remarks/>
    public string Position
    {
      get
      {
        return this.positionField;
      }
      set
      {
        this.positionField = value;
      }
    }
    //
    private ulong pidField;
    /// <remarks/>
    public ulong PlayerId
    {
      get
      {
        return this.pidField;
      }
      set
      {
        this.pidField = value;
      }
    }
    //
    private string nameField;
    /// <remarks/>
    [OLVColumn(DisplayIndex = 1, IsEditable = false, Width = 130, MinimumWidth = 100, MaximumWidth = 190, Title = "Player")]
    public string Name
    {
      get
      {
        return this.nameField;
      }
      set
      {
        this.nameField = value;
      }
    }
    /// <remarks/>
    [OLVColumn(DisplayIndex = 3, IsEditable = true, Width = 70, MinimumWidth = 50, MaximumWidth = 100, Title = "Price", AspectToStringFormat="{0:N0}")]
    public uint Price
    {
      get { return this.priceField; }
      set { this.priceField = value; }
    }
    private uint priceField;

    private string deadlineField;
    [OLVColumn(DisplayIndex = 5, IsEditable = true, Width = 100, MinimumWidth = 75, MaximumWidth = 150, Title = "Deadline", AspectToStringFormat="{0:yyyy.MM.dd HH:mm}")]
    public System.DateTime DeadLine { get { return System.DateTime.Parse(deadlineField); } }
    /// <remarks/>
    public string Deadline
    {
      get {  return this.deadlineField;  }
      set { this.deadlineField = value; }
    }

    //
    private double profitabilityField;
    /// <remarks/>
    [OLVColumn(DisplayIndex = 4, IsEditable = false, Width = 50, MinimumWidth = 35, MaximumWidth = 70, Title = "Profitability", AspectToStringFormat = "{0:F02}")]
    public double Profitability
    {
      get
      {
        return this.profitabilityField;
      }
      set
      {
        this.profitabilityField = value;
      }
    } 


    #endregion

    Player _p;
    [XmlIgnore()]
    public Player Player { get { return _p; } set { _p = value; nameField = _p.FullName; pidField = _p.Id; } }

    /// <remarks/>
     [XmlIgnore()]
     [OLVColumn(DisplayIndex = 2, IsEditable = false, Width = 45, MinimumWidth = 35, MaximumWidth = 60, Title = "Age/Value Index", AspectToStringFormat = "{0:F02}")]
    public double? ValueIndex
    {
      get
      {
        if (Player == null) return null; 
        else return Player.ValueIndex;
      }      
    }

    /// <remarks/>
     [XmlIgnore()]
     [OLVColumn(DisplayIndex = 6, IsEditable = false, Width = 45, MinimumWidth = 35, MaximumWidth = 60, Title = "Total score", AspectToStringFormat = "{0:F02}")]
    public double? Total
    {
      get
      {
        if (Player == null) return null;
        else return Player.TotalScore;
      }     
    }

    /// <remarks/>
     [XmlIgnore()]
     [OLVColumn(DisplayIndex = 7, IsEditable = false, Width = 45, MinimumWidth = 35, MaximumWidth = 60, Title = "Defensive score", AspectToStringFormat = "{0:F02}")]
    public double? Def
    {
      get
      {
        if (Player == null) return null;
        else return Player.DefensiveScore;
      }      
    }

    /// <remarks/>
     [XmlIgnore()]
     [OLVColumn(DisplayIndex = 8, IsEditable = false, Width = 45, MinimumWidth = 35, MaximumWidth = 60, Title = "Offensive score", AspectToStringFormat = "{0:F02}")]
    public double? Off
    {
      get
      {
        if (Player == null) return null;
        else return Player.OffensiveScore;
      }      
    }

    /// <remarks/>
     [XmlIgnore()]
     [OLVColumn(DisplayIndex = 9, IsEditable = false, Width = 45, MinimumWidth = 35, MaximumWidth = 60, Title = "Offensive ability", AspectToStringFormat = "{0:F02}")]
    public double? OfAb
    {
      get
      {
        if (Player == null) return null;
        else return Player.OffensiveAbilityScore;
      }      
    }

    /// <remarks/>
     [XmlIgnore()]
     [OLVColumn(DisplayIndex = 10, IsEditable = false, Width = 45, MinimumWidth = 35, MaximumWidth = 60, Title = "Shooting score", AspectToStringFormat = "{0:F02}")]
    public double? Shoot
    {
      get
      {
        if (Player == null) return null;
        else return Player.ShootingScore;
      }
     }

    /// <remarks/>
     [XmlIgnore()]
     [OLVColumn(DisplayIndex = 11, IsEditable = false, Width = 45, MinimumWidth = 35, MaximumWidth = 60, Title = "Rebounds score", AspectToStringFormat = "{0:F02}")]
    public double? Reb
    {
      get
      {
        if (Player == null) return null;
        else return Player.ReboundScore;
      }      
    }

    /// <remarks/>
     [XmlIgnore()]
     [OLVColumn(DisplayIndex = 12, IsEditable = false, Width = 45, MinimumWidth = 35, MaximumWidth = 60, Title = "Offensive Rebounds score", AspectToStringFormat = "{0:F02}")]
    public double? RebO
    {
      get
      {
        if (Player == null) return null;
        else return Player.OffensiveReboundsScore;
      }      
    }

    /// <remarks/>
     [XmlIgnore()]
     [OLVColumn(DisplayIndex = 13, IsEditable = false, Width = 45, MinimumWidth = 35, MaximumWidth = 60, Title = "Defensive Rebounds score", AspectToStringFormat = "{0:F02}")]
    public double? RebD
    {
      get
      {
        if (Player == null) return null;
        else return Player.DefensiveReboundsScore;
      }      
    }
  }
}
