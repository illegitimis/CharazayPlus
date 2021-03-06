﻿

namespace AndreiPopescu.CharazayPlus.UI
{
  using System;
  using System.Windows.Forms;
  using AndreiPopescu.CharazayPlus.Extensions;
  using MatchType = AndreiPopescu.CharazayPlus.Utils.MatchType;
  using MatchFilteredBindingList = AndreiPopescu.CharazayPlus.Utils.FilteredBindingList<Xsd2.match>;


  public partial class MyTeamScheduleUserControl : UserControl
  {
    public MyTeamScheduleUserControl ( )
    {
      InitializeComponent();
    }

      public Xsd2.charazayTeam Team { get; set; }
      public Xsd2.match[] MySchedule { get; set; }



    public void initDgMySchedule ( )
    {
#if DOTNET30
      // purge
      //dgMySchedule.CaptionText = "My Team Schedule";
      dgMySchedule.initGridPrologue();

      // home team (id+name).
      dgMySchedule.GenerateLinkColumn( "Home", "HomeTeamName");
      dgMySchedule.GenerateTextBoxColumn( string.Empty, "homescore");
      dgMySchedule.GenerateTextBoxColumn( string.Empty, "awayscore");
      // away team (id+name).
      dgMySchedule.GenerateLinkColumn( "Away", "AwayTeamName");
      dgMySchedule.GenerateTextBoxColumn( "Type", "MatchType");
      // date (match link)
      dgMySchedule.GenerateTextBoxColumn( "Deadline", "Date_");
      dgMySchedule.GenerateTextBoxColumn( "Rnd", "round");
      dgMySchedule.GenerateTextBoxColumn( "Season", "season");
      dgMySchedule.GenerateTextBoxColumn( "Spectators", "spectators");
      dgMySchedule.GenerateTextBoxColumn( "Vips", "vips");
#else
      DataGridExtensions.initGridPrologue(dgMySchedule);
      DataGridExtensions.GenerateLinkColumn   (dgMySchedule,"Home", "HomeTeamName");                                   
      DataGridExtensions.GenerateTextBoxColumn(dgMySchedule,string.Empty, "homescore");                                
      DataGridExtensions.GenerateTextBoxColumn(dgMySchedule,string.Empty, "awayscore");                                
      DataGridExtensions.GenerateLinkColumn   (dgMySchedule,"Away", "AwayTeamName");                                   
      DataGridExtensions.GenerateTextBoxColumn(dgMySchedule,"Type", "MatchType");                                      
      DataGridExtensions.GenerateTextBoxColumn(dgMySchedule,"Date", "Date_");                                          
      DataGridExtensions.GenerateTextBoxColumn(dgMySchedule,"Rnd", "round");                                           
      DataGridExtensions.GenerateTextBoxColumn(dgMySchedule,"Season", "season");                                       
      DataGridExtensions.GenerateTextBoxColumn(dgMySchedule,"Spectators", "spectators");                               
      DataGridExtensions.GenerateTextBoxColumn(dgMySchedule,"Vips", "vips");                                           
#endif


      //todo: abstractize
      DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
      column.DataPropertyName = "played";
      column.Name = "Played?";
      column.ValueType = typeof(string);
      column.TrueValue = "yes";
      column.FalseValue = "no";
      column.ThreeState = false;
      dgMySchedule.Columns.Add(column);
      //
      // bind
      //
      //initGridEpilogue<Xsd2.match>(dgMySchedule, _mySchedule);  
      var fbl = new AndreiPopescu.CharazayPlus.Utils.FilteredBindingList<Xsd2.match>();
      foreach (var m in MySchedule)
      {
        m.MyTeamId = Team.id;
        fbl.Add(m);
      }

      
      dgMySchedule.DataSource = fbl;
      dgMySchedule.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
    }

    public void initTeamScheduleFilter ( )
    {
      this.cbxMatchTypes.SelectedValueChanged -= new System.EventHandler(this.cbxMatchTypes_SelectedValueChanged);
      cbxMatchTypes.DataSource = Enum.GetValues(typeof(AndreiPopescu.CharazayPlus.Utils.MatchType));
      this.cbxMatchTypes.SelectedValueChanged += new System.EventHandler(this.cbxMatchTypes_SelectedValueChanged);
    }

    #region event handlers
    private void cbxMatchTypes_SelectedValueChanged (object sender, EventArgs e)
    {
      MatchType mt = (MatchType)cbxMatchTypes.SelectedValue;
      var fbl = (AndreiPopescu.CharazayPlus.Utils.FilteredBindingList<Xsd2.match>)dgMySchedule.DataSource;
      fbl.Filter = "MatchType=" + Enum.GetName(typeof(MatchType), mt);
      dgMySchedule.DataSource = fbl;
    }

    private void rdPlayedAll_CheckedChanged (object sender, EventArgs e)
    {
      var fbl = (MatchFilteredBindingList)dgMySchedule.DataSource;

      if (rdPlayedYes.Checked)
        fbl.Filter = string.Format("played='{0}'", "yes");
      else if (rdPlayedNo.Checked)
        fbl.Filter = string.Format("played='{0}'", "no");
      else
        fbl.RemoveFilter();

      dgMySchedule.DataSource = fbl;
    }

    private void rdWLAll_CheckedChanged (object sender, EventArgs e)
    {
      var fbl = (MatchFilteredBindingList)dgMySchedule.DataSource;

      if (rdWLWin.Checked)
        fbl.Filter = string.Format("Won='{0}'", "true");
      else if (rdWLLost.Checked)
        fbl.Filter = string.Format("Won='{0}'", "false");
      else
        fbl.RemoveFilter();

      dgMySchedule.DataSource = fbl;
    }

    private void dg_DataError (object sender, DataGridViewDataErrorEventArgs e)
    {
    }

    
    #endregion

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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.dgMySchedule = new System.Windows.Forms.DataGridView();
      this.gbxWL = new System.Windows.Forms.GroupBox();
      this.rdWLLost = new System.Windows.Forms.RadioButton();
      this.rdWLAll = new System.Windows.Forms.RadioButton();
      this.rdWLWin = new System.Windows.Forms.RadioButton();
      this.gbxTeamSchedulePlayed = new System.Windows.Forms.GroupBox();
      this.rdPlayedNo = new System.Windows.Forms.RadioButton();
      this.rdPlayedYes = new System.Windows.Forms.RadioButton();
      this.rdPlayedAll = new System.Windows.Forms.RadioButton();
      this.cbxMatchTypes = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgMySchedule)).BeginInit();
      this.gbxWL.SuspendLayout();
      this.gbxTeamSchedulePlayed.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.AutoSize = true;
      this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tableLayoutPanel1.ColumnCount = 4;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
      this.tableLayoutPanel1.Controls.Add(this.dgMySchedule, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.gbxWL, 3, 0);
      this.tableLayoutPanel1.Controls.Add(this.gbxTeamSchedulePlayed, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.cbxMatchTypes, 2, 0);
      this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(1367, 604);
      this.tableLayoutPanel1.TabIndex = 6;
      // 
      // dgMySchedule
      // 
      this.dgMySchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.dgMySchedule.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
      this.dgMySchedule.CausesValidation = false;
      this.tableLayoutPanel1.SetColumnSpan(this.dgMySchedule, 4);
      this.dgMySchedule.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgMySchedule.Location = new System.Drawing.Point(3, 53);
      this.dgMySchedule.Name = "dgMySchedule";
      this.dgMySchedule.ReadOnly = true;
      this.dgMySchedule.Size = new System.Drawing.Size(1361, 548);
      this.dgMySchedule.TabIndex = 4;
      this.dgMySchedule.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dg_DataError);
      // 
      // gbxWL
      // 
      this.gbxWL.Controls.Add(this.rdWLLost);
      this.gbxWL.Controls.Add(this.rdWLAll);
      this.gbxWL.Controls.Add(this.rdWLWin);
      this.gbxWL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gbxWL.Location = new System.Drawing.Point(959, 3);
      this.gbxWL.Name = "gbxWL";
      this.gbxWL.Size = new System.Drawing.Size(405, 44);
      this.gbxWL.TabIndex = 3;
      this.gbxWL.TabStop = false;
      this.gbxWL.Text = "Won/Lost";
      // 
      // rdWLLost
      // 
      this.rdWLLost.AutoSize = true;
      this.rdWLLost.Location = new System.Drawing.Point(104, 20);
      this.rdWLLost.Name = "rdWLLost";
      this.rdWLLost.Size = new System.Drawing.Size(45, 17);
      this.rdWLLost.TabIndex = 2;
      this.rdWLLost.Text = "Lost";
      this.rdWLLost.UseVisualStyleBackColor = true;
      this.rdWLLost.CheckedChanged += new System.EventHandler(this.rdWLAll_CheckedChanged);
      // 
      // rdWLAll
      // 
      this.rdWLAll.AutoSize = true;
      this.rdWLAll.Checked = true;
      this.rdWLAll.Location = new System.Drawing.Point(7, 20);
      this.rdWLAll.Name = "rdWLAll";
      this.rdWLAll.Size = new System.Drawing.Size(36, 17);
      this.rdWLAll.TabIndex = 1;
      this.rdWLAll.TabStop = true;
      this.rdWLAll.Text = "All";
      this.rdWLAll.UseVisualStyleBackColor = true;
      this.rdWLAll.CheckedChanged += new System.EventHandler(this.rdWLAll_CheckedChanged);
      // 
      // rdWLWin
      // 
      this.rdWLWin.AutoSize = true;
      this.rdWLWin.Location = new System.Drawing.Point(49, 20);
      this.rdWLWin.Name = "rdWLWin";
      this.rdWLWin.Size = new System.Drawing.Size(48, 17);
      this.rdWLWin.TabIndex = 0;
      this.rdWLWin.Text = "Won";
      this.rdWLWin.UseVisualStyleBackColor = true;
      this.rdWLWin.CheckedChanged += new System.EventHandler(this.rdWLAll_CheckedChanged);
      // 
      // gbxTeamSchedulePlayed
      // 
      this.gbxTeamSchedulePlayed.Controls.Add(this.rdPlayedNo);
      this.gbxTeamSchedulePlayed.Controls.Add(this.rdPlayedYes);
      this.gbxTeamSchedulePlayed.Controls.Add(this.rdPlayedAll);
      this.gbxTeamSchedulePlayed.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gbxTeamSchedulePlayed.Location = new System.Drawing.Point(3, 3);
      this.gbxTeamSchedulePlayed.Name = "gbxTeamSchedulePlayed";
      this.gbxTeamSchedulePlayed.Size = new System.Drawing.Size(404, 44);
      this.gbxTeamSchedulePlayed.TabIndex = 0;
      this.gbxTeamSchedulePlayed.TabStop = false;
      this.gbxTeamSchedulePlayed.Text = "Played";
      // 
      // rdPlayedNo
      // 
      this.rdPlayedNo.AutoSize = true;
      this.rdPlayedNo.Location = new System.Drawing.Point(98, 20);
      this.rdPlayedNo.Name = "rdPlayedNo";
      this.rdPlayedNo.Size = new System.Drawing.Size(39, 17);
      this.rdPlayedNo.TabIndex = 2;
      this.rdPlayedNo.Text = "No";
      this.rdPlayedNo.UseVisualStyleBackColor = true;
      this.rdPlayedNo.CheckedChanged += new System.EventHandler(this.rdPlayedAll_CheckedChanged);
      // 
      // rdPlayedYes
      // 
      this.rdPlayedYes.AutoSize = true;
      this.rdPlayedYes.Location = new System.Drawing.Point(49, 20);
      this.rdPlayedYes.Name = "rdPlayedYes";
      this.rdPlayedYes.Size = new System.Drawing.Size(43, 17);
      this.rdPlayedYes.TabIndex = 1;
      this.rdPlayedYes.Text = "Yes";
      this.rdPlayedYes.UseVisualStyleBackColor = true;
      this.rdPlayedYes.CheckedChanged += new System.EventHandler(this.rdPlayedAll_CheckedChanged);
      // 
      // rdPlayedAll
      // 
      this.rdPlayedAll.AutoSize = true;
      this.rdPlayedAll.Checked = true;
      this.rdPlayedAll.Location = new System.Drawing.Point(7, 20);
      this.rdPlayedAll.Name = "rdPlayedAll";
      this.rdPlayedAll.Size = new System.Drawing.Size(36, 17);
      this.rdPlayedAll.TabIndex = 0;
      this.rdPlayedAll.TabStop = true;
      this.rdPlayedAll.Text = "All";
      this.rdPlayedAll.UseVisualStyleBackColor = true;
      this.rdPlayedAll.CheckedChanged += new System.EventHandler(this.rdPlayedAll_CheckedChanged);
      // 
      // cbxMatchTypes
      // 
      this.cbxMatchTypes.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cbxMatchTypes.FormattingEnabled = true;
      this.cbxMatchTypes.Location = new System.Drawing.Point(549, 3);
      this.cbxMatchTypes.Name = "cbxMatchTypes";
      this.cbxMatchTypes.Size = new System.Drawing.Size(404, 21);
      this.cbxMatchTypes.TabIndex = 2;
      this.cbxMatchTypes.SelectedValueChanged += new System.EventHandler(this.cbxMatchTypes_SelectedValueChanged);
      // 
      // _lblTitle
      // 
      this.label1.AutoSize = true;
      this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label1.Location = new System.Drawing.Point(413, 0);
      this.label1.Name = "_lblTitle";
      this.label1.Size = new System.Drawing.Size(130, 50);
      this.label1.TabIndex = 1;
      this.label1.Text = "Match type:";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // MyTeamScheduleUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "MyTeamScheduleUserControl";
      this.Size = new System.Drawing.Size(1367, 604);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgMySchedule)).EndInit();
      this.gbxWL.ResumeLayout(false);
      this.gbxWL.PerformLayout();
      this.gbxTeamSchedulePlayed.ResumeLayout(false);
      this.gbxTeamSchedulePlayed.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.DataGridView dgMySchedule;
    private System.Windows.Forms.GroupBox gbxWL;
    private System.Windows.Forms.RadioButton rdWLLost;
    private System.Windows.Forms.RadioButton rdWLAll;
    private System.Windows.Forms.RadioButton rdWLWin;
    private System.Windows.Forms.GroupBox gbxTeamSchedulePlayed;
    private System.Windows.Forms.RadioButton rdPlayedNo;
    private System.Windows.Forms.RadioButton rdPlayedYes;
    private System.Windows.Forms.RadioButton rdPlayedAll;
    private System.Windows.Forms.ComboBox cbxMatchTypes;
    private System.Windows.Forms.Label label1;
  }
}
