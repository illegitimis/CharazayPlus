﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by m tool.
//     Runtime Version:4.0.30319.1008
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.0.30319.1.
// 
namespace AndreiPopescu.CharazayPlus.Xsd2 {
    using System.Xml.Serialization;
  using System.Diagnostics;
  using System.ComponentModel;
  using System.CodeDom.Compiler;
  using System;
    
    
    public partial class charazay {
        
        
        public charazayDivision division {
          get;
          set;
        }
    }
    
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType=true)]
    public partial class charazayDivision {
        
        
        public string name {
          get;
          set;
        }
        
        /// <remarks/>
        [XmlArrayItem("standing", IsNullable=false)]
        public charazayDivisionStanding[] standings {
          get;
          set;
        }
        
        /// <remarks/>
        [XmlAttribute]
        public uint id {
          get;
          set;
        }
        
        /// <remarks/>
        [XmlAttribute]
        public byte level {
          get;
          set;
        }
        
        /// <remarks/>
        [XmlAttribute]
        public ushort lh {
          get;
          set;
        }
        
        /// <remarks/>
        [XmlAttribute]
        public byte countryid {
          get;
          set;
        }
    }
    
    /// <remarks/>
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType=true)]
    public partial class charazayDivisionStanding {
        
        
        public byte played {
          get;
          set;
        }
        
        /// <remarks/>
        public ushort points_made {
          get;
          set;
        }
        
        /// <remarks/>
        public ushort points_against {
          get;
          set;
        }
        
        /// <remarks/>
        public byte points {
          get;
          set;
        }
        
        /// <remarks/>
        public byte wins {
          get;
          set;
        }
        
        /// <remarks/>
        public byte loss {
          get;
          set;
        }
        
        /// <remarks/>
        [XmlAttribute]
        public byte position {
          get;
          set;
        }
        
        /// <remarks/>
        [XmlAttribute]
        public uint teamid {
          get;
          set;
        }
        
        /// <remarks/>
        [XmlAttribute]
        public string name {
          get;
          set;
        }
        
        /// <remarks/>
        [XmlAttribute]
        public uint owner {
          get;
          set;
        }
    }
}
