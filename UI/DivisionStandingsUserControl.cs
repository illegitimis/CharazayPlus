using System.Windows.Forms;
using BrightIdeasSoftware;
using System;
using AndreiPopescu.CharazayPlus.Utils;

namespace AndreiPopescu.CharazayPlus.UI
{
  public partial class DivisionStandingsUserControl : UserControl
  {
    public DivisionStandingsUserControl ( )
    {
      InitializeComponent();
    }

    private FlowLayoutPanel flp;
    private Label label1;
    private Label lblName;
    private Label label2;
    private Label lblId;
    private Label label3;
    private Label lblHardiness;
    private Label label4;
    private Label lblLevel;
    private Label label5;
    private Label lblUtc;
    private Label label6;
    private Label lblSeason;
    private Label label7;
    private Label lblWeek;
    private Label label8;
    private Label lblDay;

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
      this.flp = new System.Windows.Forms.FlowLayoutPanel();
      this.label1 = new System.Windows.Forms.Label();
      this.lblName = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.lblId = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.lblHardiness = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.lblLevel = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.lblUtc = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.lblSeason = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.lblWeek = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.lblDay = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.olv)).BeginInit();
      this.flp.SuspendLayout();
      this.SuspendLayout();
      // 
      // olv
      // 
      this.olv.AlternateRowBackColor = System.Drawing.Color.DimGray;
      this.olv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.olv.BackColor = System.Drawing.Color.Gray;
      this.olv.Cursor = System.Windows.Forms.Cursors.Default;
      this.olv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.olv.ForeColor = System.Drawing.Color.White;
      this.olv.FullRowSelect = true;
      this.olv.Location = new System.Drawing.Point(9, 53);
      this.olv.Name = "olv";
      this.olv.ShowGroups = false;
      this.olv.Size = new System.Drawing.Size(339, 270);
      this.olv.SortGroupItemsByPrimaryColumn = false;
      this.olv.TabIndex = 3;
      this.olv.UseAlternatingBackColors = true;
      this.olv.UseCompatibleStateImageBehavior = false;
      this.olv.UseHyperlinks = true;
      this.olv.View = System.Windows.Forms.View.Details;
      this.olv.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(this.olv_HyperlinkClicked);
      this.olv.IsHyperlink += new System.EventHandler<BrightIdeasSoftware.IsHyperlinkEventArgs>(this.olv_IsHyperlink);
      // 
      // flp
      // 
      this.flp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.flp.Controls.Add(this.label1);
      this.flp.Controls.Add(this.lblName);
      this.flp.Controls.Add(this.label2);
      this.flp.Controls.Add(this.lblId);
      this.flp.Controls.Add(this.label3);
      this.flp.Controls.Add(this.lblHardiness);
      this.flp.Controls.Add(this.label4);
      this.flp.Controls.Add(this.lblLevel);
      this.flp.Controls.Add(this.label5);
      this.flp.Controls.Add(this.lblUtc);
      this.flp.Controls.Add(this.label6);
      this.flp.Controls.Add(this.lblSeason);
      this.flp.Controls.Add(this.label7);
      this.flp.Controls.Add(this.lblWeek);
      this.flp.Controls.Add(this.label8);
      this.flp.Controls.Add(this.lblDay);
      this.flp.Location = new System.Drawing.Point(3, 3);
      this.flp.Name = "flp";
      this.flp.Size = new System.Drawing.Size(345, 44);
      this.flp.TabIndex = 7;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label1.Location = new System.Drawing.Point(3, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(39, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Name";
      // 
      // lblName
      // 
      this.lblName.AutoSize = true;
      this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblName.Location = new System.Drawing.Point(48, 0);
      this.lblName.Name = "lblName";
      this.lblName.Size = new System.Drawing.Size(16, 15);
      this.lblName.TabIndex = 1;
      this.lblName.Text = "...";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label2.Location = new System.Drawing.Point(70, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(20, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "ID";
      // 
      // lblId
      // 
      this.lblId.AutoSize = true;
      this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblId.Location = new System.Drawing.Point(96, 0);
      this.lblId.Name = "lblId";
      this.lblId.Size = new System.Drawing.Size(16, 15);
      this.lblId.TabIndex = 3;
      this.lblId.Text = "...";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label3.Location = new System.Drawing.Point(118, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(63, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Hardiness";
      // 
      // lblHardiness
      // 
      this.lblHardiness.AutoSize = true;
      this.lblHardiness.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblHardiness.Location = new System.Drawing.Point(187, 0);
      this.lblHardiness.Name = "lblHardiness";
      this.lblHardiness.Size = new System.Drawing.Size(16, 15);
      this.lblHardiness.TabIndex = 5;
      this.lblHardiness.Text = "...";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label4.Location = new System.Drawing.Point(209, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(38, 13);
      this.label4.TabIndex = 6;
      this.label4.Text = "Level";
      // 
      // lblLevel
      // 
      this.lblLevel.AutoSize = true;
      this.lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblLevel.Location = new System.Drawing.Point(253, 0);
      this.lblLevel.Name = "lblLevel";
      this.lblLevel.Size = new System.Drawing.Size(16, 15);
      this.lblLevel.TabIndex = 7;
      this.lblLevel.Text = "...";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label5.Location = new System.Drawing.Point(275, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(34, 13);
      this.label5.TabIndex = 8;
      this.label5.Text = "Deadline";
      // 
      // lblUtc
      // 
      this.lblUtc.AutoSize = true;
      this.lblUtc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblUtc.Location = new System.Drawing.Point(315, 0);
      this.lblUtc.Name = "lblUtc";
      this.lblUtc.Size = new System.Drawing.Size(16, 15);
      this.lblUtc.TabIndex = 9;
      this.lblUtc.Text = "...";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label6.Location = new System.Drawing.Point(3, 15);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(49, 13);
      this.label6.TabIndex = 10;
      this.label6.Text = "Season";
      // 
      // lblSeason
      // 
      this.lblSeason.AutoSize = true;
      this.lblSeason.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblSeason.Location = new System.Drawing.Point(58, 15);
      this.lblSeason.Name = "lblSeason";
      this.lblSeason.Size = new System.Drawing.Size(16, 15);
      this.lblSeason.TabIndex = 11;
      this.lblSeason.Text = "...";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label7.Location = new System.Drawing.Point(80, 15);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(40, 13);
      this.label7.TabIndex = 12;
      this.label7.Text = "Week";
      // 
      // lblWeek
      // 
      this.lblWeek.AutoSize = true;
      this.lblWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblWeek.Location = new System.Drawing.Point(126, 15);
      this.lblWeek.Name = "lblWeek";
      this.lblWeek.Size = new System.Drawing.Size(16, 15);
      this.lblWeek.TabIndex = 13;
      this.lblWeek.Text = "...";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label8.Location = new System.Drawing.Point(148, 15);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(29, 13);
      this.label8.TabIndex = 14;
      this.label8.Text = "Day";
      // 
      // lblDay
      // 
      this.lblDay.AutoSize = true;
      this.lblDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblDay.Location = new System.Drawing.Point(183, 15);
      this.lblDay.Name = "lblDay";
      this.lblDay.Size = new System.Drawing.Size(16, 15);
      this.lblDay.TabIndex = 15;
      this.lblDay.Text = "...";
      // 
      // DivisionStandingsUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.flp);
      this.Controls.Add(this.olv);
      this.Name = "DivisionStandingsUserControl";
      this.Size = new System.Drawing.Size(351, 326);
      ((System.ComponentModel.ISupportInitialize)(this.olv)).EndInit();
      this.flp.ResumeLayout(false);
      this.flp.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private BrightIdeasSoftware.ObjectListView olv;


    public void Init (Xsd2.charazayDivisionStanding[] standings)
    {
      Generator.GenerateColumns(this.olv, typeof(Xsd2.charazayDivisionStanding)/*, standings*/);
      //
      olv.HeaderUsesThemes = false;
      //
      foreach (OLVColumn col in olv.Columns)
      { 
        col.IsHeaderVertical = true;
        col.Hyperlink = (col.AspectName == "TeamID" || col.AspectName == "Owner");
      }
      //
      this.olv.SetObjects(standings);    
      //
      DateTime now = DateTime.UtcNow;
      lblUtc.Text = now.ToString("yyyy-MM-dd HH:mm");
      CharazayDate cd = now;
      lblSeason.Text = cd.Season.ToString();
      lblWeek.Text = cd.Week.ToString();
      lblDay.Text = cd.Day.ToString();
    }



    public string DivisionName {set { lblName.Text = value; } }

    public ushort Hardiness { set { lblHardiness.Text = value.ToString(); } }

    public uint DivisionId {set { lblId.Text = value.ToString(); } }

    public byte Level { set { lblLevel.Text = value.ToString(); } }

    
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
        case 8: 
          { // team
            Web.CharazayDownloadItem teamLink = new Web.CharazayDownloadItem("team", 0, s.TeamID);
            e.Url = teamLink.m_uri.AbsoluteUri;
          } break;
        case 9:
          { // user
            Web.CharazayDownloadItem teamLink = new Web.CharazayDownloadItem("user", 15, s.TeamID);
            e.Url = teamLink.m_uri.AbsoluteUri;
          } break;
        default: break;
      }
      
    }

    //public byte Country { get; set { ldCountry.Description = value.ToString(); } }
  }

}
