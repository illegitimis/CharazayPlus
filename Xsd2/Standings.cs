﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
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
    
    
    public partial class charazay {
        
        private charazayDivision divisionField;
        
        /// <remarks/>
        public charazayDivision division {
            get {
                return this.divisionField;
            }
            set {
                this.divisionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class charazayDivision {
        
        private string nameField;
        
        private charazayDivisionStanding[] standingsField;
        
        private uint idField;
        
        private byte levelField;
        
        private ushort lhField;
        
        private byte countryidField;
        
        /// <remarks/>
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("standing", IsNullable=false)]
        public charazayDivisionStanding[] standings {
            get {
                return this.standingsField;
            }
            set {
                this.standingsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte level {
            get {
                return this.levelField;
            }
            set {
                this.levelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort lh {
            get {
                return this.lhField;
            }
            set {
                this.lhField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte countryid {
            get {
                return this.countryidField;
            }
            set {
                this.countryidField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class charazayDivisionStanding {
        
        private byte playedField;
        
        private ushort points_madeField;
        
        private ushort points_againstField;
        
        private byte pointsField;
        
        private byte winsField;
        
        private byte lossField;
        
        private byte positionField;
        
        private uint teamidField;
        
        private string nameField;
        
        private uint ownerField;
        
        /// <remarks/>
        public byte played {
            get {
                return this.playedField;
            }
            set {
                this.playedField = value;
            }
        }
        
        /// <remarks/>
        public ushort points_made {
            get {
                return this.points_madeField;
            }
            set {
                this.points_madeField = value;
            }
        }
        
        /// <remarks/>
        public ushort points_against {
            get {
                return this.points_againstField;
            }
            set {
                this.points_againstField = value;
            }
        }
        
        /// <remarks/>
        public byte points {
            get {
                return this.pointsField;
            }
            set {
                this.pointsField = value;
            }
        }
        
        /// <remarks/>
        public byte wins {
            get {
                return this.winsField;
            }
            set {
                this.winsField = value;
            }
        }
        
        /// <remarks/>
        public byte loss {
            get {
                return this.lossField;
            }
            set {
                this.lossField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte position {
            get {
                return this.positionField;
            }
            set {
                this.positionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint teamid {
            get {
                return this.teamidField;
            }
            set {
                this.teamidField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint owner {
            get {
                return this.ownerField;
            }
            set {
                this.ownerField = value;
            }
        }
    }
}
