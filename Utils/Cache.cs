﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by m tool.
//     Runtime Version:4.0.30319.1008
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace AndreiPopescu.CharazayPlus.Utils
{
  using System.Xml.Serialization;
  using System.CodeDom.Compiler;
  using System;
  using System.ComponentModel;
  using System.Diagnostics;

  // 
  // This source code was auto-generated by xsd, Version=4.0.30319.1.
  // 


  /// <remarks/>
  [GeneratedCode("xsd", "4.0.30319.1")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public partial class cache
  {

    /// <remarks/>
    [XmlArray(IsNullable = true)]
    [XmlArrayItem("player")]
    public player[] players { get; set; }

    /// <remarks/>
    [XmlArray(IsNullable = true)]
    [XmlArrayItem("team")]
    public team[] teams { get; set; }

    /// <remarks/>
    [XmlArray(IsNullable = true)]
    [XmlArrayItem("match")]
    public match[] matches { get; set; }
  }

  /// <remarks/>
  [GeneratedCode("xsd", "4.0.30319.1")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = true)]
  public partial class player
  {

    /// <remarks/>
    [XmlAttribute]
    public ulong id { get; set; }

    /// <remarks/>
    [XmlAttribute]
    public string name { get; set; }
  }

  /// <remarks/>
  [GeneratedCode("xsd", "4.0.30319.1")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = true)]
  public partial class team
  {
    /// <remarks/>
    [XmlAttribute]
    public uint id { get; set; }

    /// <remarks/>
    [XmlAttribute]
    public string name { get; set; }
  }

  /// <remarks/>
  [GeneratedCode("xsd", "4.0.30319.1")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = true)]
  public partial class match
  {

    /// <remarks/>
    [XmlAttribute]
    public uint id { get; set; }

    /// <remarks/>
    [XmlAttribute]
    public string name { get; set; }
  }

  /// <remarks/>
  [GeneratedCode("xsd", "4.0.30319.1")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = true)]
  public partial class players
  {

    /// <remarks/>
    [XmlElement("player", IsNullable = true)]
    public player[] player { get; set; }
  }

  /// <remarks/>
  [GeneratedCode("xsd", "4.0.30319.1")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = true)]
  public partial class teams
  {

    /// <remarks/>
    [XmlElement("team", IsNullable = true)]
    public team[] team { get; set; }
  }

  /// <remarks/>
  [GeneratedCode("xsd", "4.0.30319.1")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = true)]
  public partial class matches
  {
    /// <remarks/>
    [XmlElement("match", IsNullable = true)]
    public match[] match { get; set; }
  }
}