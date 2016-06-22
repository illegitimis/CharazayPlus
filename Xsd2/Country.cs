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
namespace AndreiPopescu.CharazayPlus.Xsd2 
{
  using System.Xml.Serialization;
  using System.CodeDom.Compiler;
  using System;
  using System.Diagnostics;
  using System.ComponentModel;
    
    public partial class charazay {
        
        /// <remarks/>
        public charazayCountry country {
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
    public partial class charazayCountry {
        
        /// <remarks/>
        public string name {
          get;
          set;
        }
        
        /// <remarks/>
        public string flag {
          get;
          set;
        }
        
        /// <remarks/>
        [XmlElement("division")]
        public charazayCountryDivision[] division {
          get;
          set;
        }
        
        /// <remarks/>
        public charazayCountryCountry_info country_info {
          get;
          set;
        }
        
        /// <remarks/>
        [XmlAttribute]
        public byte id {
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
    public partial class charazayCountryDivision {
        
        
        
        /// <remarks/>
        public string name {
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
    public partial class charazayCountryCountry_info {
        
        /// <remarks/>
        public charazayCountryCountry_infoNtcoach ntcoach {
          get;
          set;
        }
        
        /// <remarks/>
        public charazayCountryCountry_infoU21ntcoach u21ntcoach {
          get;
          set;
        }
        
        /// <remarks/>
        public charazayCountryCountry_infoU18ntcoach u18ntcoach {
          get;
          set;
        }
        
        /// <remarks/>
        [XmlAttribute]
        public string active {
          get;
          set;
        }
        
        /// <remarks/>
        [XmlAttribute]
        public uint users {
          get;
          set;
        }
        
        /// <remarks/>
        [XmlAttribute]
        public uint teams {
          get;
          set;
        }
        
        /// <remarks/>
        [XmlAttribute]
        public uint waiting {
          get;
          set;
        }
        
        /// <remarks/>
        [XmlAttribute]
        public uint supporters {
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
    public partial class charazayCountryCountry_infoNtcoach {
        
        /// <remarks/>
        public user user {
          get;
          set;
        }
        
        /// <remarks/>
        [XmlAttribute]
        public string bot {
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
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class user {
        
        /// <remarks/>
        public string name {
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
        public string supporter {
          get;
          set;
        }
        
        /// <remarks/>
        [XmlAttribute]
        public uint registered {
          get;
          set;
        }
        
        /// <remarks/>
        [XmlAttribute]
        public uint last_active {
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
    public partial class charazayCountryCountry_infoU21ntcoach {
        
        /// <remarks/>
        public user user {
          get;
          set;
        }
        
        /// <remarks/>
        [XmlAttribute]
        public string bot {
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
    public partial class charazayCountryCountry_infoU18ntcoach {
        
       /// <remarks/>
        public user user {
          get;
          set;
        }
        
        /// <remarks/>
        [XmlAttribute]
        public string bot {
          get;
          set;
        }
    }
}
