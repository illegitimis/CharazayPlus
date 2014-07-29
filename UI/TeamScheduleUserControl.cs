using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace AndreiPopescu.CharazayPlus.UI
{
  public class TeamScheduleUserControl : UserControl
  {
    public TeamScheduleUserControl ( )
    {
      InitializeComponent();
    }

    public void Init (Xsd2.match[] schedule, uint uid)
    {
      foreach(var m in schedule)
        m.MyTeamId = uid;
      //
      Generator.GenerateColumns(this.fdlv, typeof(Xsd2.match));
      //
      fdlv.HeaderUsesThemes = false;
      //
      foreach (OLVColumn col in fdlv.Columns)
      {
        switch (col.Index)
        {
          case 0: //id
            col.Groupable = false;col.IsHeaderVertical = false; break;
          case 1: //home team
            col.Groupable = false;col.IsHeaderVertical = false; break;
          case 4: //away team
            col.Groupable = false;col.IsHeaderVertical = false; break;
          case 5: //type
            col.Groupable = true; col.IsHeaderVertical = false; break;
          case 6:
            col.Groupable = true; col.IsHeaderVertical = true; break;
          case 7:
            col.Groupable = true; col.IsHeaderVertical = true; break;
          case 8: //date
            col.IsHeaderVertical = false; col.Groupable=false; break;

          default:
        col.IsHeaderVertical = true;
        break;
        }
        
      }
      //
      this.fdlv.SetObjects(schedule);
     //
      this.fdlv.RebuildColumns();
    }

    private void fdlv_HyperlinkClicked (object sender, HyperlinkClickedEventArgs e)
    {
      Xsd2.match s = (Xsd2.match)e.Item.RowObject;
      if (s == null)
        return;
      //
      switch (e.ColumnIndex)
      {
        case 1:
          { // team
            Web.CharazayDownloadItem teamLink = new Web.CharazayDownloadItem("team", 0, s.HomeTeamId);
            e.Url = teamLink.m_uri.AbsoluteUri;
          } break;
        case 4:
          { // team
            Web.CharazayDownloadItem teamLink = new Web.CharazayDownloadItem("team", 0, s.AwayTeamId);
            e.Url = teamLink.m_uri.AbsoluteUri;
          } break;
        case 0:
          { // user
            Web.CharazayDownloadItem matchLink = new Web.CharazayDownloadItem("match", 0, s.Id);
            e.Url = matchLink.m_uri.AbsoluteUri;
          } break;

      default: break;
      }

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
      this.fdlv = new BrightIdeasSoftware.ObjectListView();
      ((System.ComponentModel.ISupportInitialize)(this.fdlv)).BeginInit();
      this.SuspendLayout();
      // 
      // fdlv
      // 
      this.fdlv.AlternateRowBackColor = System.Drawing.Color.LightGray;
      this.fdlv.BackColor = System.Drawing.Color.Silver;
      this.fdlv.CausesValidation = false;
      this.fdlv.Dock = System.Windows.Forms.DockStyle.Fill;
      this.fdlv.Location = new System.Drawing.Point(0, 0);
      this.fdlv.Name = "fdlv";
      this.fdlv.Size = new System.Drawing.Size(150, 150);
      this.fdlv.SortGroupItemsByPrimaryColumn = false;
      this.fdlv.Sorting = System.Windows.Forms.SortOrder.Ascending;
      this.fdlv.TabIndex = 0;
      this.fdlv.UseAlternatingBackColors = true;
      this.fdlv.UseCompatibleStateImageBehavior = false;
      this.fdlv.UseHyperlinks = true;
      this.fdlv.View = System.Windows.Forms.View.Details;
      this.fdlv.ShowGroups = true;
      this.fdlv.VirtualMode = true;
      this.fdlv.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(this.fdlv_HyperlinkClicked);
      // 
      // TeamScheduleUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.fdlv);
      this.Name = "TeamScheduleUserControl";
      ((System.ComponentModel.ISupportInitialize)(this.fdlv)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private BrightIdeasSoftware.ObjectListView fdlv;
  }
}
