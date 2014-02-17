using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace AndreiPopescu.CharazayPlus.UI
{
  public partial class UserControl1 : UserControl
  {
    public UserControl1 ( )
    {
      InitializeComponent();
    }

    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose (bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent ( )
    {
      this.olv = new BrightIdeasSoftware.ObjectListView();
      this.ldLevel = new AndreiPopescu.CharazayPlus.UI.LabelDescriptionUserControl();
      this.ldHard = new AndreiPopescu.CharazayPlus.UI.LabelDescriptionUserControl();
      this.ldId = new AndreiPopescu.CharazayPlus.UI.LabelDescriptionUserControl();
      this.ldName = new AndreiPopescu.CharazayPlus.UI.LabelDescriptionUserControl();
      ((System.ComponentModel.ISupportInitialize)(this.olv)).BeginInit();
      this.SuspendLayout();
      // 
      // olv
      // 
      this.olv.AlternateRowBackColor = System.Drawing.Color.DimGray;
      this.olv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.olv.BackColor = System.Drawing.Color.Gray;
      this.olv.GridLines = true;
      this.olv.HeaderUsesThemes = false;
      this.olv.Location = new System.Drawing.Point(4, 108);
      this.olv.Name = "olv";
      this.olv.ShowGroups = false;
      this.olv.Size = new System.Drawing.Size(344, 215);
      this.olv.TabIndex = 3;
      this.olv.UseAlternatingBackColors = true;
      this.olv.UseCompatibleStateImageBehavior = false;
      this.olv.UseHyperlinks = true;
      this.olv.View = System.Windows.Forms.View.Details;
      this.olv.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(this.olv_HyperlinkClicked);
      this.olv.IsHyperlink += new System.EventHandler<BrightIdeasSoftware.IsHyperlinkEventArgs>(this.olv_IsHyperlink);
      // 
      // ldLevel
      // 
      this.ldLevel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ldLevel.Description = "name";
      this.ldLevel.IsMultiline = false;
      this.ldLevel.Label = "Level";
      this.ldLevel.Location = new System.Drawing.Point(4, 82);
      this.ldLevel.Name = "ldLevel";
      this.ldLevel.Size = new System.Drawing.Size(295, 20);
      this.ldLevel.TabIndex = 4;
      // 
      // ldHard
      // 
      this.ldHard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ldHard.Description = "name";
      this.ldHard.IsMultiline = false;
      this.ldHard.Label = "Hardiness";
      this.ldHard.Location = new System.Drawing.Point(4, 56);
      this.ldHard.Name = "ldHard";
      this.ldHard.Size = new System.Drawing.Size(295, 20);
      this.ldHard.TabIndex = 2;
      // 
      // ldId
      // 
      this.ldId.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ldId.Description = "name";
      this.ldId.IsMultiline = false;
      this.ldId.Label = "ID";
      this.ldId.Location = new System.Drawing.Point(4, 30);
      this.ldId.Name = "ldId";
      this.ldId.Size = new System.Drawing.Size(295, 20);
      this.ldId.TabIndex = 1;
      // 
      // ldName
      // 
      this.ldName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ldName.Description = "name";
      this.ldName.IsMultiline = false;
      this.ldName.Label = "Name";
      this.ldName.Location = new System.Drawing.Point(4, 4);
      this.ldName.Name = "ldName";
      this.ldName.Size = new System.Drawing.Size(295, 20);
      this.ldName.TabIndex = 0;
      // 
      // UserControl1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.ldLevel);
      this.Controls.Add(this.olv);
      this.Controls.Add(this.ldHard);
      this.Controls.Add(this.ldId);
      this.Controls.Add(this.ldName);
      this.Name = "UserControl1";
      this.Size = new System.Drawing.Size(351, 326);
      ((System.ComponentModel.ISupportInitialize)(this.olv)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private LabelDescriptionUserControl ldName;
    private LabelDescriptionUserControl ldId;
    private LabelDescriptionUserControl ldHard;
    private BrightIdeasSoftware.ObjectListView olv;
    private LabelDescriptionUserControl ldLevel;


    public void Init (Xsd2.charazayDivisionStanding[] standings)
    {
      Generator.GenerateColumns(this.olv, typeof(Xsd2.charazayDivisionStanding)/*, standings*/);
      foreach (OLVColumn col in olv.Columns)
      { 
        col.IsHeaderVertical = true;
        col.Hyperlink = (col.AspectName == "TeamID" || col.AspectName == "Owner");
      }
      //
      this.olv.SetObjects(standings);     
    }



    public string DivisionName {set { ldName.Description = value; } }

    public ushort Hardiness { set { ldHard.Description = value.ToString(); } }

    public uint DivisionId {set { ldId.Description = value.ToString(); } }

    public byte Level { set { ldLevel.Description = value.ToString(); } }

    private void olv_IsHyperlink (object sender, IsHyperlinkEventArgs e)
    {

    }

    private void olv_HyperlinkClicked (object sender, HyperlinkClickedEventArgs e)
    {
      Xsd2.charazayDivisionStanding s = (Xsd2.charazayDivisionStanding)e.Item.RowObject;
      if (s == null)
        return;
      //
      switch (e.ColumnIndex)
      {
        case 9: 
          {
            Web.CharazayDownoadItem teamLink = new Web.CharazayDownoadItem("team", 0, s.TeamID);
            e.Url = teamLink.m_uri.AbsoluteUri;
          } break;
        case 10:
          {
            Web.CharazayDownoadItem teamLink = new Web.CharazayDownoadItem("user", 15, s.TeamID);
            e.Url = teamLink.m_uri.AbsoluteUri;
          } break;
        default: break;
      }
      
    }

    //public byte Country { get; set { ldCountry.Description = value.ToString(); } }
  }

}
