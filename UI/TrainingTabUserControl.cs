namespace AndreiPopescu.CharazayPlus.UI
{
  using System;
  using System.Collections.Generic;
  using System.Windows.Forms;
  using AndreiPopescu.CharazayPlus.Utils;
  using BrightIdeasSoftware;
  using AndreiPopescu.CharazayPlus.Objects;
 using AndreiPopescu.CharazayPlus.Data;

#if DOTNET30
  using System.Linq; 
#endif

  public partial class TrainingTabUserControl : UserControl
  {
    public TrainingTabUserControl ( )
    {
      InitializeComponent();
    }

    #region local data holders for efficiency/training combination    
    
    IDictionary<TrainingCombination,List<TrainingCombinationItem>> TrainingCombinationValues = new Dictionary<TrainingCombination,List<TrainingCombinationItem>>();
    IList<TrainingEfficiencyScoreItem> TrainingEfficiencyScores = new List<TrainingEfficiencyScoreItem>();

    #endregion


    #region public exposure
    public void initCoachesList ( )
    {
      this.olvCoaches.HeaderUsesThemes = false;
      this.olvCoaches.HeaderWordWrap = false;
      //coaches list
      Generator.GenerateColumns(olvCoaches, PlayersEnvironment.Coaches);
      foreach (OLVColumn col in olvCoaches.Columns)
      {
        if (col.Index != 0)
          col.IsHeaderVertical = true;
      }
      olvCoaches.SetObjects(PlayersEnvironment.Coaches);
    }

    public void initTrainingSkillIncrease ( )
    {
      Generator.GenerateColumns(this.olvSkillIncrease, TrainingEnvironment.SkillIncreaseItems);
      this.olvSkillIncrease.SetObjects(TrainingEnvironment.SkillIncreaseItems);
    }

    /// <summary>
    /// 
    /// </summary>
    public void initTrainingScoreIncrease ( )
    {
      Generator.GenerateColumns(this.olvTraining, TrainingEnvironment.ScoreIncreaseItems);
      this.olvTraining.SetObjects(TrainingEnvironment.ScoreIncreaseItems);
    }

    public void initTrainingEfficiency ( )
    {
      Generator.GenerateColumns(olvTrainingEfficiency, typeof(TrainingEfficiencyScoreItem));
      //
      Generator.GenerateColumns(this.folvTrainComb, typeof(TrainingCombinationItem));
      foreach (OLVColumn col in this.folvTrainComb.Columns)
      {
        if (col.Index != 0)
          //col.IsHeaderVertical = true;
          col.WordWrap = true;
      }
      //
      TrainingEfficiencyCalculator.Go(PlayersEnvironment.OptimumPlayers
        , PlayersEnvironment.MaxCoach
        , ref TrainingCombinationValues
        , ref TrainingEfficiencyScores);
      olvTrainingEfficiency.SetObjects(TrainingEfficiencyScores);
    } 
    #endregion

    #region OLV event handlers
    private void olvCoaches_FormatCell (object sender, FormatCellEventArgs e)
    {
      //e.RowIndex == _coaches.Count - 1 &&
      if (e.Item.Text == "Active Coach")
        e.SubItem.Font = new System.Drawing.Font(e.SubItem.Font, System.Drawing.FontStyle.Bold);
    }
          
    private void olvSkillIncrease_FormatCell (object sender, FormatCellEventArgs e)
    {
      if (e.Item.Text.StartsWith("TOTAL"))
        e.SubItem.Font = new System.Drawing.Font(e.SubItem.Font, System.Drawing.FontStyle.Bold);
      else
      {
        if (e.ColumnIndex > 0)
        {
          if ((double)e.CellValue > 0.25d)
            e.SubItem.ForeColor = System.Drawing.Color.Red;
          else if ((double)e.CellValue > 0.1d)
            e.SubItem.ForeColor = System.Drawing.Color.DarkGreen;
        }
        
      }

    }

    private void olvTraining_FormatCell (object sender, FormatCellEventArgs e)
    {
      if (e.Item.Text.StartsWith("TOTAL"))
        e.SubItem.Font = new System.Drawing.Font(e.SubItem.Font, System.Drawing.FontStyle.Bold);
      else
      {
        if (e.ColumnIndex > 0)
        {
          if ((double)e.CellValue > 0.04d)
            e.SubItem.ForeColor = System.Drawing.Color.Red;
          else if ((double)e.CellValue > 0.01d)
            e.SubItem.ForeColor = System.Drawing.Color.DarkGreen;
        }

      }
    }

    private void olvTrainingEfficiency_SelectedIndexChanged (object sender, EventArgs e)
    {
      TrainingEfficiencyScoreItem tefsi = (TrainingEfficiencyScoreItem)this.olvTrainingEfficiency.SelectedObject;
      if (tefsi == null)
        return;
      TrainingCombination tc = new TrainingCombination(tefsi.TC1, tefsi.TC2);
      var tcis = TrainingCombinationValues[tc];
      this.folvTrainComb.SetObjects(tcis);      
    }

    private void folvTrainComb_FormatRow (object sender, FormatRowEventArgs e)
    {
      var tci = (TrainingCombinationItem)e.Model;
      if (tci.Category1Increase > tci.Category2Increase)
        e.Item.SubItems[1].Font = new System.Drawing.Font(e.Item.SubItems[1].Font, System.Drawing.FontStyle.Bold);
      else
        e.Item.SubItems[2].Font = new System.Drawing.Font(e.Item.SubItems[2].Font, System.Drawing.FontStyle.Bold);
    }

    private void chkTEu18_CheckedChanged (object sender, EventArgs e)
    {
      var players = this.chkTEu18.Checked
        ? TrainingEfficiencyCalculator.TopN(PlayersEnvironment.OptimumPlayers, 8)
        : PlayersEnvironment.OptimumPlayers;
      TrainingEfficiencyCalculator.Go(players
        , PlayersEnvironment.MaxCoach
        , ref this.TrainingCombinationValues
        , ref this.TrainingEfficiencyScores);
      olvTrainingEfficiency.SetObjects(TrainingEfficiencyScores);
    }

    private void chkRemove32_CheckedChanged (object sender, EventArgs e)
    {
      var players = this.chkRemove32.Checked
        ? TrainingEfficiencyCalculator.Under32(PlayersEnvironment.OptimumPlayers)
        : PlayersEnvironment.OptimumPlayers;
      TrainingEfficiencyCalculator.Go(players
        , PlayersEnvironment.MaxCoach
        , ref this.TrainingCombinationValues
        , ref this.TrainingEfficiencyScores);
      olvTrainingEfficiency.SetObjects(TrainingEfficiencyScores);
    }
    #endregion


    #region Component Designer generated code
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



    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent ( )
    {
      this.splitLR = new System.Windows.Forms.SplitContainer();
      this.splitTBCoachesSkillsIncrease = new System.Windows.Forms.SplitContainer();
      this.lblCoachesList = new System.Windows.Forms.Label();
      this.olvCoaches = new BrightIdeasSoftware.ObjectListView();
      this.splitTBIncrease = new System.Windows.Forms.SplitContainer();
      this.lblSkillIncrease = new System.Windows.Forms.Label();
      this.olvSkillIncrease = new BrightIdeasSoftware.ObjectListView();
      this.lblScoreIncrease = new System.Windows.Forms.Label();
      this.olvTraining = new BrightIdeasSoftware.ObjectListView();
      this.splitTrnRight = new System.Windows.Forms.SplitContainer();
      this.chkRemove32 = new System.Windows.Forms.CheckBox();
      this.chkTEu18 = new System.Windows.Forms.CheckBox();
      this.olvTrainingEfficiency = new BrightIdeasSoftware.ObjectListView();
      this.folvTrainComb = new BrightIdeasSoftware.FastObjectListView();
      ((System.ComponentModel.ISupportInitialize)(this.splitLR)).BeginInit();
      this.splitLR.Panel1.SuspendLayout();
      this.splitLR.Panel2.SuspendLayout();
      this.splitLR.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitTBCoachesSkillsIncrease)).BeginInit();
      this.splitTBCoachesSkillsIncrease.Panel1.SuspendLayout();
      this.splitTBCoachesSkillsIncrease.Panel2.SuspendLayout();
      this.splitTBCoachesSkillsIncrease.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvCoaches)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitTBIncrease)).BeginInit();
      this.splitTBIncrease.Panel1.SuspendLayout();
      this.splitTBIncrease.Panel2.SuspendLayout();
      this.splitTBIncrease.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvSkillIncrease)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.olvTraining)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitTrnRight)).BeginInit();
      this.splitTrnRight.Panel1.SuspendLayout();
      this.splitTrnRight.Panel2.SuspendLayout();
      this.splitTrnRight.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvTrainingEfficiency)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.folvTrainComb)).BeginInit();
      this.SuspendLayout();
      // 
      // splitLR
      // 
      this.splitLR.BackColor = System.Drawing.Color.Black;
      this.splitLR.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitLR.Location = new System.Drawing.Point(0, 0);
      this.splitLR.Name = "splitLR";
      // 
      // splitLR.Panel1
      // 
      this.splitLR.Panel1.Controls.Add(this.splitTBCoachesSkillsIncrease);
      this.splitLR.Panel1MinSize = 225;
      // 
      // splitLR.Panel2
      // 
      this.splitLR.Panel2.Controls.Add(this.splitTrnRight);
      this.splitLR.Size = new System.Drawing.Size(840, 485);
      this.splitLR.SplitterDistance = 622;
      this.splitLR.SplitterWidth = 2;
      this.splitLR.TabIndex = 2;
      // 
      // splitTBCoachesSkillsIncrease
      // 
      this.splitTBCoachesSkillsIncrease.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitTBCoachesSkillsIncrease.Location = new System.Drawing.Point(0, 0);
      this.splitTBCoachesSkillsIncrease.Name = "splitTBCoachesSkillsIncrease";
      this.splitTBCoachesSkillsIncrease.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitTBCoachesSkillsIncrease.Panel1
      // 
      this.splitTBCoachesSkillsIncrease.Panel1.Controls.Add(this.lblCoachesList);
      this.splitTBCoachesSkillsIncrease.Panel1.Controls.Add(this.olvCoaches);
      // 
      // splitTBCoachesSkillsIncrease.Panel2
      // 
      this.splitTBCoachesSkillsIncrease.Panel2.Controls.Add(this.splitTBIncrease);
      this.splitTBCoachesSkillsIncrease.Size = new System.Drawing.Size(622, 485);
      this.splitTBCoachesSkillsIncrease.SplitterDistance = 49;
      this.splitTBCoachesSkillsIncrease.SplitterWidth = 2;
      this.splitTBCoachesSkillsIncrease.TabIndex = 2;
      // 
      // lblCoachesList
      // 
      this.lblCoachesList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.lblCoachesList.AutoSize = true;
      this.lblCoachesList.BackColor = System.Drawing.Color.Black;
      this.lblCoachesList.ForeColor = System.Drawing.Color.White;
      this.lblCoachesList.Location = new System.Drawing.Point(551, 36);
      this.lblCoachesList.Name = "lblCoachesList";
      this.lblCoachesList.Size = new System.Drawing.Size(68, 13);
      this.lblCoachesList.TabIndex = 1;
      this.lblCoachesList.Text = "Coaches List";
      // 
      // olvCoaches
      // 
      this.olvCoaches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.olvCoaches.BackColor = System.Drawing.Color.Cornsilk;
      this.olvCoaches.FullRowSelect = true;
      this.olvCoaches.HeaderUsesThemes = false;
      this.olvCoaches.Location = new System.Drawing.Point(0, 0);
      this.olvCoaches.Name = "olvCoaches";
      this.olvCoaches.ShowGroups = false;
      this.olvCoaches.Size = new System.Drawing.Size(619, 49);
      this.olvCoaches.TabIndex = 0;
      this.olvCoaches.UseAlternatingBackColors = true;
      this.olvCoaches.UseCellFormatEvents = true;
      this.olvCoaches.UseCompatibleStateImageBehavior = false;
      this.olvCoaches.View = System.Windows.Forms.View.Details;
      this.olvCoaches.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.olvCoaches_FormatCell);
      // 
      // splitTBIncrease
      // 
      this.splitTBIncrease.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitTBIncrease.Location = new System.Drawing.Point(0, 0);
      this.splitTBIncrease.Name = "splitTBIncrease";
      this.splitTBIncrease.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitTBIncrease.Panel1
      // 
      this.splitTBIncrease.Panel1.Controls.Add(this.lblSkillIncrease);
      this.splitTBIncrease.Panel1.Controls.Add(this.olvSkillIncrease);
      // 
      // splitTBIncrease.Panel2
      // 
      this.splitTBIncrease.Panel2.Controls.Add(this.lblScoreIncrease);
      this.splitTBIncrease.Panel2.Controls.Add(this.olvTraining);
      this.splitTBIncrease.Size = new System.Drawing.Size(622, 434);
      this.splitTBIncrease.SplitterDistance = 175;
      this.splitTBIncrease.SplitterWidth = 2;
      this.splitTBIncrease.TabIndex = 3;
      // 
      // lblSkillIncrease
      // 
      this.lblSkillIncrease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.lblSkillIncrease.AutoSize = true;
      this.lblSkillIncrease.ForeColor = System.Drawing.Color.White;
      this.lblSkillIncrease.Location = new System.Drawing.Point(513, 162);
      this.lblSkillIncrease.Name = "lblSkillIncrease";
      this.lblSkillIncrease.Size = new System.Drawing.Size(106, 13);
      this.lblSkillIncrease.TabIndex = 2;
      this.lblSkillIncrease.Text = "Weekly skill increase";
      // 
      // olvSkillIncrease
      // 
      this.olvSkillIncrease.Activation = System.Windows.Forms.ItemActivation.OneClick;
      this.olvSkillIncrease.AlternateRowBackColor = System.Drawing.Color.Gainsboro;
      this.olvSkillIncrease.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.olvSkillIncrease.BackColor = System.Drawing.Color.WhiteSmoke;
      this.olvSkillIncrease.Cursor = System.Windows.Forms.Cursors.Default;
      this.olvSkillIncrease.FullRowSelect = true;
      this.olvSkillIncrease.HeaderUsesThemes = false;
      this.olvSkillIncrease.HeaderWordWrap = true;
      this.olvSkillIncrease.HighlightBackgroundColor = System.Drawing.Color.IndianRed;
      this.olvSkillIncrease.HighlightForegroundColor = System.Drawing.Color.Teal;
      this.olvSkillIncrease.HotTracking = true;
      this.olvSkillIncrease.HoverSelection = true;
      this.olvSkillIncrease.Location = new System.Drawing.Point(0, 0);
      this.olvSkillIncrease.Name = "olvSkillIncrease";
      this.olvSkillIncrease.ShowGroups = false;
      this.olvSkillIncrease.ShowItemToolTips = true;
      this.olvSkillIncrease.Size = new System.Drawing.Size(622, 175);
      this.olvSkillIncrease.SortGroupItemsByPrimaryColumn = false;
      this.olvSkillIncrease.TabIndex = 1;
      this.olvSkillIncrease.UseAlternatingBackColors = true;
      this.olvSkillIncrease.UseCellFormatEvents = true;
      this.olvSkillIncrease.UseCompatibleStateImageBehavior = false;
      this.olvSkillIncrease.UseHotItem = true;
      this.olvSkillIncrease.UseTranslucentHotItem = true;
      this.olvSkillIncrease.UseTranslucentSelection = true;
      this.olvSkillIncrease.View = System.Windows.Forms.View.Details;
      this.olvSkillIncrease.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.olvSkillIncrease_FormatCell);
      // 
      // lblScoreIncrease
      // 
      this.lblScoreIncrease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.lblScoreIncrease.AutoSize = true;
      this.lblScoreIncrease.ForeColor = System.Drawing.Color.White;
      this.lblScoreIncrease.Location = new System.Drawing.Point(539, 241);
      this.lblScoreIncrease.Name = "lblScoreIncrease";
      this.lblScoreIncrease.Size = new System.Drawing.Size(79, 13);
      this.lblScoreIncrease.TabIndex = 3;
      this.lblScoreIncrease.Text = "Score Increase";
      // 
      // olvTraining
      // 
      this.olvTraining.Activation = System.Windows.Forms.ItemActivation.OneClick;
      this.olvTraining.AlternateRowBackColor = System.Drawing.Color.WhiteSmoke;
      this.olvTraining.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.olvTraining.BackColor = System.Drawing.Color.Gainsboro;
      this.olvTraining.Cursor = System.Windows.Forms.Cursors.Default;
      this.olvTraining.FullRowSelect = true;
      this.olvTraining.HeaderUsesThemes = false;
      this.olvTraining.HeaderWordWrap = true;
      this.olvTraining.HighlightBackgroundColor = System.Drawing.Color.IndianRed;
      this.olvTraining.HighlightForegroundColor = System.Drawing.Color.Teal;
      this.olvTraining.HotTracking = true;
      this.olvTraining.HoverSelection = true;
      this.olvTraining.Location = new System.Drawing.Point(1, 3);
      this.olvTraining.Name = "olvTraining";
      this.olvTraining.ShowGroups = false;
      this.olvTraining.ShowItemToolTips = true;
      this.olvTraining.Size = new System.Drawing.Size(618, 253);
      this.olvTraining.TabIndex = 2;
      this.olvTraining.UseAlternatingBackColors = true;
      this.olvTraining.UseCellFormatEvents = true;
      this.olvTraining.UseCompatibleStateImageBehavior = false;
      this.olvTraining.UseHotItem = true;
      this.olvTraining.UseTranslucentHotItem = true;
      this.olvTraining.View = System.Windows.Forms.View.Details;
      this.olvTraining.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.olvTraining_FormatCell);
      // 
      // splitTrnRight
      // 
      this.splitTrnRight.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitTrnRight.Location = new System.Drawing.Point(0, 0);
      this.splitTrnRight.Name = "splitTrnRight";
      this.splitTrnRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitTrnRight.Panel1
      // 
      this.splitTrnRight.Panel1.BackColor = System.Drawing.Color.DimGray;
      this.splitTrnRight.Panel1.Controls.Add(this.chkRemove32);
      this.splitTrnRight.Panel1.Controls.Add(this.chkTEu18);
      this.splitTrnRight.Panel1.Controls.Add(this.olvTrainingEfficiency);
      // 
      // splitTrnRight.Panel2
      // 
      this.splitTrnRight.Panel2.Controls.Add(this.folvTrainComb);
      this.splitTrnRight.Size = new System.Drawing.Size(216, 485);
      this.splitTrnRight.SplitterDistance = 295;
      this.splitTrnRight.TabIndex = 1;
      // 
      // chkRemove32
      // 
      this.chkRemove32.AutoSize = true;
      this.chkRemove32.ForeColor = System.Drawing.Color.White;
      this.chkRemove32.Location = new System.Drawing.Point(0, 16);
      this.chkRemove32.Name = "chkRemove32";
      this.chkRemove32.Size = new System.Drawing.Size(128, 17);
      this.chkRemove32.TabIndex = 4;
      this.chkRemove32.Text = "Remove 32 and older";
      this.chkRemove32.UseVisualStyleBackColor = true;
      this.chkRemove32.CheckedChanged += new System.EventHandler(this.chkRemove32_CheckedChanged);
      // 
      // chkTEu18
      // 
      this.chkTEu18.AutoSize = true;
      this.chkTEu18.ForeColor = System.Drawing.Color.White;
      this.chkTEu18.Location = new System.Drawing.Point(0, 0);
      this.chkTEu18.Name = "chkTEu18";
      this.chkTEu18.Size = new System.Drawing.Size(78, 17);
      this.chkTEu18.TabIndex = 3;
      this.chkTEu18.Text = "Keep top 8";
      this.chkTEu18.UseVisualStyleBackColor = true;
      this.chkTEu18.CheckedChanged += new System.EventHandler(this.chkTEu18_CheckedChanged);
      // 
      // olvTrainingEfficiency
      // 
      this.olvTrainingEfficiency.Activation = System.Windows.Forms.ItemActivation.OneClick;
      this.olvTrainingEfficiency.AlternateRowBackColor = System.Drawing.Color.Gray;
      this.olvTrainingEfficiency.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.olvTrainingEfficiency.BackColor = System.Drawing.Color.DimGray;
      this.olvTrainingEfficiency.Cursor = System.Windows.Forms.Cursors.Default;
      this.olvTrainingEfficiency.ForeColor = System.Drawing.SystemColors.Info;
      this.olvTrainingEfficiency.FullRowSelect = true;
      this.olvTrainingEfficiency.HeaderUsesThemes = false;
      this.olvTrainingEfficiency.HeaderWordWrap = true;
      this.olvTrainingEfficiency.HighlightBackgroundColor = System.Drawing.Color.DeepSkyBlue;
      this.olvTrainingEfficiency.HighlightForegroundColor = System.Drawing.Color.RoyalBlue;
      this.olvTrainingEfficiency.HotTracking = true;
      this.olvTrainingEfficiency.HoverSelection = true;
      this.olvTrainingEfficiency.Location = new System.Drawing.Point(0, 39);
      this.olvTrainingEfficiency.MultiSelect = false;
      this.olvTrainingEfficiency.Name = "olvTrainingEfficiency";
      this.olvTrainingEfficiency.ShowGroups = false;
      this.olvTrainingEfficiency.ShowItemToolTips = true;
      this.olvTrainingEfficiency.Size = new System.Drawing.Size(213, 253);
      this.olvTrainingEfficiency.TabIndex = 2;
      this.olvTrainingEfficiency.UseAlternatingBackColors = true;
      this.olvTrainingEfficiency.UseCompatibleStateImageBehavior = false;
      this.olvTrainingEfficiency.UseHotItem = true;
      this.olvTrainingEfficiency.UseTranslucentHotItem = true;
      this.olvTrainingEfficiency.UseTranslucentSelection = true;
      this.olvTrainingEfficiency.View = System.Windows.Forms.View.Details;
      this.olvTrainingEfficiency.SelectedIndexChanged += new System.EventHandler(this.olvTrainingEfficiency_SelectedIndexChanged);
      // 
      // folvTrainComb
      // 
      this.folvTrainComb.AlternateRowBackColor = System.Drawing.Color.Silver;
      this.folvTrainComb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.folvTrainComb.BackColor = System.Drawing.Color.LightGray;
      this.folvTrainComb.FullRowSelect = true;
      this.folvTrainComb.HeaderUsesThemes = false;
      this.folvTrainComb.HeaderWordWrap = true;
      this.folvTrainComb.Location = new System.Drawing.Point(4, 3);
      this.folvTrainComb.Name = "folvTrainComb";
      this.folvTrainComb.ShowGroups = false;
      this.folvTrainComb.Size = new System.Drawing.Size(209, 178);
      this.folvTrainComb.SortGroupItemsByPrimaryColumn = false;
      this.folvTrainComb.TabIndex = 0;
      this.folvTrainComb.UseAlternatingBackColors = true;
      this.folvTrainComb.UseCellFormatEvents = true;
      this.folvTrainComb.UseCompatibleStateImageBehavior = false;
      this.folvTrainComb.View = System.Windows.Forms.View.Details;
      this.folvTrainComb.VirtualMode = true;
      this.folvTrainComb.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.folvTrainComb_FormatRow);
      // 
      // TrainingTabUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitLR);
      this.DoubleBuffered = true;
      this.Name = "TrainingTabUserControl";
      this.Size = new System.Drawing.Size(840, 485);
      this.splitLR.Panel1.ResumeLayout(false);
      this.splitLR.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitLR)).EndInit();
      this.splitLR.ResumeLayout(false);
      this.splitTBCoachesSkillsIncrease.Panel1.ResumeLayout(false);
      this.splitTBCoachesSkillsIncrease.Panel1.PerformLayout();
      this.splitTBCoachesSkillsIncrease.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitTBCoachesSkillsIncrease)).EndInit();
      this.splitTBCoachesSkillsIncrease.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.olvCoaches)).EndInit();
      this.splitTBIncrease.Panel1.ResumeLayout(false);
      this.splitTBIncrease.Panel1.PerformLayout();
      this.splitTBIncrease.Panel2.ResumeLayout(false);
      this.splitTBIncrease.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitTBIncrease)).EndInit();
      this.splitTBIncrease.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.olvSkillIncrease)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.olvTraining)).EndInit();
      this.splitTrnRight.Panel1.ResumeLayout(false);
      this.splitTrnRight.Panel1.PerformLayout();
      this.splitTrnRight.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitTrnRight)).EndInit();
      this.splitTrnRight.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.olvTrainingEfficiency)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.folvTrainComb)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitLR;
    private System.Windows.Forms.SplitContainer splitTBCoachesSkillsIncrease;
    private System.Windows.Forms.Label lblCoachesList;
    private BrightIdeasSoftware.ObjectListView olvCoaches;
    private System.Windows.Forms.SplitContainer splitTBIncrease;
    private System.Windows.Forms.Label lblSkillIncrease;
    private BrightIdeasSoftware.ObjectListView olvSkillIncrease;
    private System.Windows.Forms.Label lblScoreIncrease;
    private BrightIdeasSoftware.ObjectListView olvTraining;
    private System.Windows.Forms.SplitContainer splitTrnRight;
    private System.Windows.Forms.CheckBox chkTEu18;
    private BrightIdeasSoftware.ObjectListView olvTrainingEfficiency;
    private System.Windows.Forms.CheckBox chkRemove32;
    private BrightIdeasSoftware.FastObjectListView folvTrainComb;
   
    
  }
}
