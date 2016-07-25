using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using AndreiPopescu.CharazayPlus.Utils;
using AndreiPopescu.CharazayPlus.Model;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;


namespace AndreiPopescu.CharazayPlus.UI
{
  public partial class DevelopmentHistoryUserControl : UserControl
  {
    const string LegendName = "_legend";
    private CheckBox chkActiveOnly;

    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
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
    private void InitializeComponent()
    {
      this.flp = new System.Windows.Forms.FlowLayoutPanel();
      this.lblPlayer = new System.Windows.Forms.Label();
      this.cmbPlayer = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.lblSelectedPlayer = new System.Windows.Forms.Label();
      this.lnkSelectedPlayer = new System.Windows.Forms.LinkLabel();
      this.label2 = new System.Windows.Forms.Label();
      this.cmbCategory = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.lblSelectedCategory = new System.Windows.Forms.Label();
      this._chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.chkActiveOnly = new System.Windows.Forms.CheckBox();
      this.flp.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this._chart)).BeginInit();
      this.SuspendLayout();
      // 
      // flp
      // 
      this.flp.Controls.Add(this.chkActiveOnly);
      this.flp.Controls.Add(this.lblPlayer);
      this.flp.Controls.Add(this.cmbPlayer);
      this.flp.Controls.Add(this.label1);
      this.flp.Controls.Add(this.lblSelectedPlayer);
      this.flp.Controls.Add(this.lnkSelectedPlayer);
      this.flp.Controls.Add(this.label2);
      this.flp.Controls.Add(this.cmbCategory);
      this.flp.Controls.Add(this.label4);
      this.flp.Controls.Add(this.lblSelectedCategory);
      this.flp.Dock = System.Windows.Forms.DockStyle.Left;
      this.flp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.flp.Location = new System.Drawing.Point(0, 0);
      this.flp.Name = "flp";
      this.flp.Size = new System.Drawing.Size(195, 320);
      this.flp.TabIndex = 0;
      // 
      // lblPlayer
      // 
      this.lblPlayer.AutoSize = true;
      this.lblPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblPlayer.Location = new System.Drawing.Point(3, 28);
      this.lblPlayer.Name = "lblPlayer";
      this.lblPlayer.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
      this.lblPlayer.Size = new System.Drawing.Size(41, 25);
      this.lblPlayer.TabIndex = 0;
      this.lblPlayer.Text = "Player";
      // 
      // cmbPlayer
      // 
      this.cmbPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.cmbPlayer.FormattingEnabled = true;
      this.cmbPlayer.Location = new System.Drawing.Point(3, 56);
      this.cmbPlayer.Name = "cmbPlayer";
      this.cmbPlayer.Size = new System.Drawing.Size(192, 24);
      this.cmbPlayer.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label1.Location = new System.Drawing.Point(3, 83);
      this.label1.Name = "label1";
      this.label1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
      this.label1.Size = new System.Drawing.Size(95, 25);
      this.label1.TabIndex = 4;
      this.label1.Text = "Selected Player:";
      // 
      // lblSelectedPlayer
      // 
      this.lblSelectedPlayer.AutoSize = true;
      this.lblSelectedPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblSelectedPlayer.Location = new System.Drawing.Point(3, 108);
      this.lblSelectedPlayer.Name = "lblSelectedPlayer";
      this.lblSelectedPlayer.Size = new System.Drawing.Size(14, 18);
      this.lblSelectedPlayer.TabIndex = 5;
      this.lblSelectedPlayer.Text = "-";
      // 
      // lnkSelectedPlayer
      // 
      this.lnkSelectedPlayer.ActiveLinkColor = System.Drawing.Color.LimeGreen;
      this.lnkSelectedPlayer.AutoSize = true;
      this.lnkSelectedPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lnkSelectedPlayer.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.lnkSelectedPlayer.Location = new System.Drawing.Point(3, 126);
      this.lnkSelectedPlayer.Name = "lnkSelectedPlayer";
      this.lnkSelectedPlayer.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
      this.lnkSelectedPlayer.Size = new System.Drawing.Size(14, 28);
      this.lnkSelectedPlayer.TabIndex = 8;
      this.lnkSelectedPlayer.TabStop = true;
      this.lnkSelectedPlayer.Text = "-";
      this.lnkSelectedPlayer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSelectedPlayer_LinkClicked);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label2.Location = new System.Drawing.Point(3, 154);
      this.label2.Name = "label2";
      this.label2.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
      this.label2.Size = new System.Drawing.Size(55, 35);
      this.label2.TabIndex = 2;
      this.label2.Text = "Category";
      // 
      // cmbCategory
      // 
      this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.cmbCategory.FormattingEnabled = true;
      this.cmbCategory.Location = new System.Drawing.Point(3, 192);
      this.cmbCategory.Name = "cmbCategory";
      this.cmbCategory.Size = new System.Drawing.Size(192, 24);
      this.cmbCategory.TabIndex = 3;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label4.Location = new System.Drawing.Point(3, 219);
      this.label4.Name = "label4";
      this.label4.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
      this.label4.Size = new System.Drawing.Size(109, 25);
      this.label4.TabIndex = 6;
      this.label4.Text = "Selected Category:";
      // 
      // lblSelectedCategory
      // 
      this.lblSelectedCategory.AutoSize = true;
      this.lblSelectedCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblSelectedCategory.Location = new System.Drawing.Point(3, 244);
      this.lblSelectedCategory.Name = "lblSelectedCategory";
      this.lblSelectedCategory.Size = new System.Drawing.Size(14, 18);
      this.lblSelectedCategory.TabIndex = 7;
      this.lblSelectedCategory.Text = "-";
      // 
      // _chart
      // 
      this._chart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(223)))), ((int)(((byte)(193)))));
      this._chart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
      this._chart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(64)))), ((int)(((byte)(1)))));
      this._chart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
      this._chart.BorderlineWidth = 2;
      this._chart.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
      this._chart.Dock = System.Windows.Forms.DockStyle.Fill;
      this._chart.Location = new System.Drawing.Point(195, 0);
      this._chart.Name = "_chart";
      this._chart.Size = new System.Drawing.Size(480, 320);
      this._chart.TabIndex = 1;
      this._chart.Text = "chart1";
      // 
      // chkActiveOnly
      // 
      this.chkActiveOnly.AutoSize = true;
      this.chkActiveOnly.Location = new System.Drawing.Point(3, 3);
      this.chkActiveOnly.Name = "chkActiveOnly";
      this.chkActiveOnly.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
      this.chkActiveOnly.Size = new System.Drawing.Size(141, 22);
      this.chkActiveOnly.TabIndex = 9;
      this.chkActiveOnly.Text = "Keep only active players";
      this.chkActiveOnly.UseVisualStyleBackColor = true;
      this.chkActiveOnly.CheckedChanged += new System.EventHandler(this.chkActiveOnly_CheckedChanged);
      // 
      // DevelopmentHistoryUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this._chart);
      this.Controls.Add(this.flp);
      this.Name = "DevelopmentHistoryUserControl";
      this.Size = new System.Drawing.Size(675, 320);
      this.Load += new System.EventHandler(this.DevelopmentHistoryUserControl_Load);
      this.flp.ResumeLayout(false);
      this.flp.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this._chart)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private FlowLayoutPanel flp;
    private Label lblPlayer;
    private ComboBox cmbPlayer;
    private Label label2;
    private Label label1;
    private Label lblSelectedPlayer;
    private Label label4;
    private Label lblSelectedCategory;
    private LinkLabel lnkSelectedPlayer;
    private Chart _chart;
    private ComboBox cmbCategory;
    ChartArea _chartArea;
    Series _series;

    public DevelopmentHistoryUserControl()
    {
      InitializeComponent();
    }

    static readonly DateTime[] years = new DateTime[]{
      new DateTime(2012,1,1),
      new DateTime(2013,1,1),
      new DateTime(2014,1,1),
      new DateTime(2015,1,1),
      new DateTime(2016,1,1),
    };

    #region utility
    private void SetCustomLabels()
    {
      //      
      // set second row of labels
      //
      //for (int i = 0; i < CharazayDate.Seasons.Length; i++)
      //foreach (var pair in CharazayDate.Seasons.Zip(CharazayDate.Seasons.Skip(1), (current, next) => new { current, next }))
      CharazaySeason currentSeason = default(CharazaySeason);
      CharazaySeason nextSeason = default(CharazaySeason);
      using (var enumSeasons = CharazayDate.Seasons.GetEnumerator())
      {
        //_chartArea.AxisX.CustomLabels.Add(
        //  CharazayDate.Seasons[i].StartDate.ToOADate()
        //  , CharazayDate.Seasons[i + 1].StartDate.ToOADate()
        //  , "Season " + CharazayDate.Seasons[i].Number.ToString()
        //  , 1, LabelMarkStyle.LineSideMark);
        enumSeasons.MoveNext();
        nextSeason = enumSeasons.Current;
        //http://stackoverflow.com/questions/6508060/linq-lookahead-iteration
        while (enumSeasons.MoveNext())
        {
          currentSeason = nextSeason;
          nextSeason = enumSeasons.Current;

          _chartArea.AxisX.CustomLabels.Add(
             fromPosition: currentSeason.StartDate.ToOADate(),
             toPosition: (currentSeason.EndDate.ToOADate() + nextSeason.StartDate.ToOADate()) / 2,
             text: "S " + currentSeason.Number.ToString(),
             rowIndex: 1,
             markStyle: LabelMarkStyle.LineSideMark
          );
        }
      }
      
      _chartArea.AxisX.CustomLabels.Add(
          nextSeason.StartDate.ToOADate(),
          nextSeason.EndDate.ToOADate(),
          "S " + nextSeason.Number.ToString(), 
          1, 
          LabelMarkStyle.LineSideMark
      );

      //
      // One more row of labels
      //
      for (int i = 0; i < years.Length - 1; i++)
        _chartArea.AxisX.CustomLabels.Add(years[i].ToOADate(), years[i + 1].ToOADate(), years[i].Year.ToString(), 2, LabelMarkStyle.LineSideMark);
    }

    private void UpdateChart(PlayerDevelopment pd, ST_VALUE_TYPE valueType)
    {
      foreach (var s in this._chart.Series)
        s.Points.Clear();
      foreach (var l in this._chart.Legends)
        l.CustomItems.Clear();
      //
      //DevelopmentHistory.Instance.Development.PlayerItems
      //
      var sourceValues = pd.ItemValues.Where(ct => ct.Type == valueType).ToList();
      //
      SetAxesProperties(valueType, sourceValues);
      //
      double oldy = 0;
      foreach (var v in sourceValues)
      {
        this._series.Points.Add(new DataPoint()
        {
          ToolTip = string.Format("Value: {0:F02} Day: {1:yyyy-MM-dd}", v.Value, v.When),
          XValue = v.When.ToOADate(),
          YValues = new double[] { v.GenericValue },
          //MarkerSize = 12,
          IsValueShownAsLabel = v.GenericValue != oldy
        });
        oldy = v.GenericValue;
      }
    }

    private void SetAxesProperties(ST_VALUE_TYPE valueType, List<CT_VALUE_AT_DATE> sourceValues)
    {
      var min = sourceValues.Min(ct => ct.When);
      var max = sourceValues.Max(ct => ct.When);
      //
      this._chartArea.AxisX.Minimum = new DateTime(min.Year, 1, 1).ToOADate();
      this._chartArea.AxisX.Maximum = new DateTime(max.Year, 12, 31).ToOADate();
      //
      if (valueType == ST_VALUE_TYPE.w)
      {
        this._chartArea.AxisY.Minimum = Math.Floor(sourceValues.Min(ct => ct.GenericValue) / 10) * 10;
        this._chartArea.AxisY.Maximum = Math.Ceiling(sourceValues.Max(ct => ct.GenericValue) / 10) * 10;
        _chartArea.AxisY.LabelStyle.Interval = 5D;
        _chartArea.AxisY.MajorGrid.Interval = 10D;
        _chartArea.AxisY.MajorTickMark.Interval = 5D;
      }
      else if (valueType == ST_VALUE_TYPE.si || valueType == ST_VALUE_TYPE.sal)
      {
        this._chartArea.AxisY.Minimum = Math.Floor(sourceValues.Min(ct => ct.GenericValue) / 1000) * 1000;
        this._chartArea.AxisY.Maximum = Math.Ceiling(sourceValues.Max(ct => ct.GenericValue) / 1000) * 1000;
        _chartArea.AxisY.LabelStyle.Interval = 10000D;
        _chartArea.AxisY.MajorGrid.Interval = 50000D;
        _chartArea.AxisY.MajorTickMark.Interval = 50000D;
      }
      else
      {
        this._chartArea.AxisY.Minimum = sourceValues.Min(ct => ct.GenericValue) - 1;
        this._chartArea.AxisY.Maximum = sourceValues.Max(ct => ct.GenericValue) + 1;
        _chartArea.AxisY.LabelStyle.Interval = 1D;
        _chartArea.AxisY.MajorGrid.Interval = 5D;
        _chartArea.AxisY.MajorTickMark.Interval = 5D;
      }
    }

    void InitChartArea()
    {
      _chartArea = new ChartArea();
      _chartArea.AxisX.LabelStyle.Interval = 28D;
      _chartArea.AxisX.LabelStyle.IntervalOffsetType = DateTimeIntervalType.Days;
      _chartArea.AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Days;
      _chartArea.AxisX.MajorGrid.Interval = 28D;
      _chartArea.AxisX.MajorTickMark.Interval = 14D;
      _chartArea.AxisX.IsLabelAutoFit = true;
      //_chartArea.AxisX2.IsLabelAutoFit = false;
      //
      _chartArea.BackColor = Color.WhiteSmoke;
      _chartArea.Name = "_chartArea";
      _chartArea.ShadowColor = Color.Gainsboro;
      //
      _chartArea.Area3DStyle.Inclination = 15;
      _chartArea.Area3DStyle.IsClustered = true;
      _chartArea.Area3DStyle.IsRightAngleAxes = false;
      _chartArea.Area3DStyle.Perspective = 10;
      _chartArea.Area3DStyle.Rotation = 10;
      _chartArea.Area3DStyle.WallWidth = 0;
      //
      this._chartArea.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
      this._chartArea.AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
      this._chartArea.AxisX2.Enabled = AxisEnabled.False;
      this._chartArea.AxisY2.Enabled = AxisEnabled.False;
      //
      this._chart.ChartAreas.Add(_chartArea);
    }

    void InitLegend()
    {
      var _legend = new Legend();
      _legend.Name = LegendName;
      _legend.Position.Auto = false;
      _legend.Position.Height = 6F;
      _legend.Position.Width = 25F;
      _legend.Position.X = 12F;
      _legend.Position.Y = 6F;
      this._chart.Legends.Add(_legend);
    }

    void InitSeries()
    {
      _series = new Series()
      {
        ChartArea = "_chartArea",
        ChartType = SeriesChartType.Line,
        Legend = LegendName,
        Name = "Skill Variation with time",
        MarkerSize = 10,
        MarkerColor = Color.Salmon,
        MarkerStyle = MarkerStyle.Circle,
        MarkerBorderColor = Color.Red,
        MarkerBorderWidth = 3
      };
      this._chart.Series.Add(_series);
    }
    #endregion

    #region events 
    private void DevelopmentHistoryUserControl_Load(object sender, EventArgs e)
    {
      //
      //this.cmbPlayer.DataBindings.Add(new Binding("Items", DevelopmentHistory.Instance.Development.PlayerItems, "FullName", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty));
      //
      this.cmbPlayer.SelectedIndexChanged -= new System.EventHandler(this.cmbPlayer_SelectedIndexChanged);
      this.cmbPlayer.DataSource = DevelopmentHistory.Instance.Development.PlayerItems;
      this.cmbPlayer.DisplayMember = "FullName";
      this.cmbPlayer.SelectedIndexChanged += new System.EventHandler(this.cmbPlayer_SelectedIndexChanged);

      //
      //this.cmbCategory.DataBindings.Add(new Binding("Items", Properties.Settings.Default, "SecurityCode", false, DataSourceUpdateMode.OnPropertyChanged));
      //
      this.cmbCategory.SelectedIndexChanged -= new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
      this.cmbCategory.DataSource = (ST_VALUE_TYPE[])Enum.GetValues(typeof(ST_VALUE_TYPE));
      this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);

      // 
      // _chart
      // 
      InitChartArea();
      InitLegend();
      InitSeries();

      //
      SetCustomLabels();
    }

    private void lnkSelectedPlayer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      // Determine which link was clicked within the LinkLabel.
      this.lnkSelectedPlayer.Links[lnkSelectedPlayer.Links.IndexOf(e.Link)].Visited = true;

      // Display the appropriate link based on the value of the 
      // LinkData property of the Link object.
      string target = e.Link.LinkData as string;

      // If the value looks like a URL, navigate to it.
      // Otherwise, display it in a message box.
      if (null != target && target.StartsWith("www"))
      {
        System.Diagnostics.Process.Start(target);
      }
    }

    private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
      lblSelectedCategory.Text = cmbCategory.SelectedItem.ToString();
      //
      UpdateChart(this.cmbPlayer.SelectedItem as PlayerDevelopment, (ST_VALUE_TYPE)this.cmbCategory.SelectedItem);
    }

    private void cmbPlayer_SelectedIndexChanged(object sender, EventArgs e)
    {
      PlayerDevelopment pd = (cmbPlayer.SelectedItem as PlayerDevelopment);
      lblSelectedPlayer.Text = pd.ToString();
      //
      this.lnkSelectedPlayer.Text = pd.FullName;
      this.lnkSelectedPlayer.Links.Clear();
      this.lnkSelectedPlayer.Links.Add(0, 1000, string.Format("www.charazay.com/?act=player&code=1&id={0}", pd.id));
      //
      UpdateChart(this.cmbPlayer.SelectedItem as PlayerDevelopment, (ST_VALUE_TYPE)this.cmbCategory.SelectedItem);
    }
    #endregion

    private void chkActiveOnly_CheckedChanged(object sender, EventArgs e)
    {
      this.cmbPlayer.SelectedIndexChanged -= new System.EventHandler(this.cmbPlayer_SelectedIndexChanged);
      this.cmbPlayer.DataSource = ((CheckBox)sender).Checked
        ? DevelopmentHistory.Instance.Development.PlayerItems.Where (x=>x.active==true).ToList()
        : DevelopmentHistory.Instance.Development.PlayerItems;
      this.cmbPlayer.DisplayMember = "FullName";
      this.cmbPlayer.SelectedIndexChanged += new System.EventHandler(this.cmbPlayer_SelectedIndexChanged);
    }
  }
}
