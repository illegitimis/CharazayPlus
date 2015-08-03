﻿namespace AndreiPopescu.CharazayPlus.UI
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Drawing;
  using System.Data;
  using System.Text;
  using System.Windows.Forms;
  using BrightIdeasSoftware;
  using AndreiPopescu.CharazayPlus.Utils;
  using AndreiPopescu.CharazayPlus.Extensions;
  using System.Linq;
  using System.Windows.Forms.DataVisualization.Charting;

  public partial class MyEconomyUserControl : UserControl
  {
    public enum RunMode {Unknown, Week, Season};

    const double YScale = 10000000d;

    
    public static readonly string[] seriesNamesIncome = new string[] { "Merchandise", "Other Income", "Sales", "Sponsor", "Tickets" };
    public static readonly string[] seriesNamesExpences = new string[] { "Buys", "Facility", "Maintenance", "Other Expences", "Salary", "Staff" };
    private GroupBox gbxBalanceMode;
    private RadioButton rdWeek;
    private RadioButton rdSeason;
    private TextBox txtDays;
    private Label label1;

    RunMode _runMode = RunMode.Unknown;
    int _days = 10;

    public MyEconomyUserControl ( )
    {
      InitializeComponent();
    }

    #region public
    /// <summary>
    /// my team transfer history
    /// ta/*B:*/ , My Economy
    /// </summary>
    [Obsolete("OLV instead of grid")]
    public void InitDgMyTransfers (Xsd2.charazayTransfer[] _myTransfers)
    {
#if DOTNET30
      //dgTeamTransfers.initGridPrologue ();            
      //dgTeamTransfers.GenerateTextBoxColumn( "Seller", "Seller");
      //dgTeamTransfers.GenerateTextBoxColumn( "Buyer", "Buyer");
      //dgTeamTransfers.GenerateTextBoxColumn( "Deadline", "Deadline");
      //dgTeamTransfers.GenerateTextBoxColumn( "Player", "Player");
      //dgTeamTransfers.GenerateTextBoxColumn( "Skill Index", "si");
      //dgTeamTransfers.GenerateTextBoxColumn( "StartingPrice", "price");
      //dgTeamTransfers.initGridEpilogue<Xsd2.charazayTransfer> (_myTransfers);      
#else
      DataGridExtensions.initGridPrologue(dgTeamTransfers);
      DataGridExtensions.GenerateTextBoxColumn(dgTeamTransfers, "Seller", "Seller");
      DataGridExtensions.GenerateTextBoxColumn(dgTeamTransfers, "Buyer", "Buyer");
      DataGridExtensions.GenerateTextBoxColumn(dgTeamTransfers, "Date", "Date");
      DataGridExtensions.GenerateTextBoxColumn(dgTeamTransfers, "Player", "Player");
      DataGridExtensions.GenerateTextBoxColumn(dgTeamTransfers, "Skill Index", "si");
      DataGridExtensions.GenerateTextBoxColumn(dgTeamTransfers, "Price", "price");
      DataGridExtensions.initGridEpilogue<Xsd2.charazayTransfer>(dgTeamTransfers, _myTransfers);
#endif
    }

    public void InitOLV (Xsd2.charazayTransfer[] transfers)
    {
      Generator.GenerateColumns(this.olv, typeof(Xsd2.charazayTransfer));
      foreach (OLVColumn col in this.olv.Columns)
      {
        switch (col.DisplayIndex)
        {
          // seller
          case 0:
            col.GroupKeyGetter = delegate(object row) { return ((Xsd2.charazayTransfer)row).sellteam == _myTeamId; };
            col.GroupKeyToTitleConverter = delegate(object groupKey) { string s = (bool)groupKey ? "by me" : "to me"; return "Sold " + s; };
            break;
          //buyer
          case 1:
            col.GroupKeyGetter = delegate(object row) { return ((Xsd2.charazayTransfer)row).buyteam == _myTeamId; };
            col.GroupKeyToTitleConverter = delegate(object groupKey) { string s = (bool)groupKey ? "by me" : "from me"; return "Bought " + s; };
            break;
          //date
          case 2:
            col.GroupKeyGetter = delegate(object row) { CharazayDate cd = ((Xsd2.charazayTransfer)row).Date; return cd.Season; };
            col.GroupKeyToTitleConverter = delegate(object groupKey) { return string.Format("Season {0}", (byte)groupKey); };
            break;
          //player
          case 3:
            col.Groupable = false;
            break;
          //price
          case 4:
            {
              uint k = 100000u;
              uint m = 10u * k;
              uint[] priceMarkers = new uint[] { k, 3u * k, m, 2u * m, 3u * m, 5u * m, 7u * m, 10u * m, 15u * m, 20u * m, 25u * m, 30u * m, 40u * m, 50u * m, 75u * m, 100u * m };
              col.MakeGroupies(priceMarkers, ObjectListViewExtensions.BuildCustomGroupies<uint>(priceMarkers));
            }
            break;
          //si
          case 5:
            {
              uint k = 1000u; uint m = 10000u; uint n = 100000u;
              uint[] siMarkers = new uint[] { m, 15u * k, 2 * m, 3u * m, 5 * m, 7 * m, n, 12 * m, 15 * m, 175 * k, 2 * n, 25 * m, 3 * n, 35 * m, 4 * n, 5 * n, 6 * n, 7 * n, 8 * n };
              col.MakeGroupies(siMarkers, ObjectListViewExtensions.BuildCustomGroupies<uint>(siMarkers));
            }
            break;
        }
      }
      this.olv.SetObjects(transfers);

    }

    public void InitEconomyUserControls (Xsd2.charazayEconomy _economy)
    {
      ucEconomyWeek.LabelsInit(_economy.economy_week.income, _economy.economy_week.expences, true);
      ucEconomySeason.LabelsInit(_economy.economy_season.income, _economy.economy_season.expences, false);
    }

    private SplitContainer split;
    private Chart chart;

    public uint MyTeamId { get { return _myTeamId; } set { _myTeamId = value; } } 
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
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      this.olv = new BrightIdeasSoftware.ObjectListView();
      this.ucEconomyWeek = new AndreiPopescu.CharazayPlus.BalanceUserControl();
      this.ucEconomySeason = new AndreiPopescu.CharazayPlus.BalanceUserControl();
      this.split = new System.Windows.Forms.SplitContainer();
      this.gbxBalanceMode = new System.Windows.Forms.GroupBox();
      this.rdSeason = new System.Windows.Forms.RadioButton();
      this.rdWeek = new System.Windows.Forms.RadioButton();
      this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.label1 = new System.Windows.Forms.Label();
      this.txtDays = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.olv)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
      this.split.Panel1.SuspendLayout();
      this.split.Panel2.SuspendLayout();
      this.split.SuspendLayout();
      this.gbxBalanceMode.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
      this.SuspendLayout();
      // 
      // _olv
      // 
      this.olv.AlternateRowBackColor = System.Drawing.Color.Silver;
      this.olv.BackColor = System.Drawing.Color.LightGray;
      this.olv.Cursor = System.Windows.Forms.Cursors.Default;
      this.olv.Dock = System.Windows.Forms.DockStyle.Fill;
      this.olv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.olv.ForeColor = System.Drawing.Color.White;
      this.olv.FullRowSelect = true;
      this.olv.Location = new System.Drawing.Point(0, 0);
      this.olv.Name = "_olv";
      this.olv.Size = new System.Drawing.Size(330, 674);
      this.olv.SortGroupItemsByPrimaryColumn = false;
      this.olv.TabIndex = 4;
      this.olv.UseAlternatingBackColors = true;
      this.olv.UseCompatibleStateImageBehavior = false;
      this.olv.UseHyperlinks = true;
      this.olv.View = System.Windows.Forms.View.Details;
      this.olv.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(this.olv_HyperlinkClicked);
      // 
      // ucEconomyWeek
      // 
      this.ucEconomyWeek.AutoSize = true;
      this.ucEconomyWeek.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucEconomyWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.ucEconomyWeek.Location = new System.Drawing.Point(8, 3);
      this.ucEconomyWeek.Name = "ucEconomyWeek";
      this.ucEconomyWeek.Size = new System.Drawing.Size(237, 331);
      this.ucEconomyWeek.TabIndex = 0;
      // 
      // ucEconomySeason
      // 
      this.ucEconomySeason.AutoSize = true;
      this.ucEconomySeason.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucEconomySeason.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.ucEconomySeason.Location = new System.Drawing.Point(251, 3);
      this.ucEconomySeason.Name = "ucEconomySeason";
      this.ucEconomySeason.Size = new System.Drawing.Size(237, 331);
      this.ucEconomySeason.TabIndex = 0;
      // 
      // split
      // 
      this.split.Dock = System.Windows.Forms.DockStyle.Fill;
      this.split.Location = new System.Drawing.Point(0, 0);
      this.split.Name = "split";
      // 
      // split.Panel1
      // 
      this.split.Panel1.Controls.Add(this.olv);
      // 
      // split.Panel2
      // 
      this.split.Panel2.Controls.Add(this.txtDays);
      this.split.Panel2.Controls.Add(this.label1);
      this.split.Panel2.Controls.Add(this.gbxBalanceMode);
      this.split.Panel2.Controls.Add(this.chart);
      this.split.Panel2.Controls.Add(this.ucEconomyWeek);
      this.split.Panel2.Controls.Add(this.ucEconomySeason);
      this.split.Size = new System.Drawing.Size(972, 674);
      this.split.SplitterDistance = 330;
      this.split.TabIndex = 5;
      // 
      // gbxBalanceMode
      // 
      this.gbxBalanceMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.gbxBalanceMode.Controls.Add(this.rdSeason);
      this.gbxBalanceMode.Controls.Add(this.rdWeek);
      this.gbxBalanceMode.Location = new System.Drawing.Point(542, 8);
      this.gbxBalanceMode.Name = "gbxBalanceMode";
      this.gbxBalanceMode.Size = new System.Drawing.Size(91, 100);
      this.gbxBalanceMode.TabIndex = 1;
      this.gbxBalanceMode.TabStop = false;
      this.gbxBalanceMode.Text = "Balance Type";
      // 
      // rdSeason
      // 
      this.rdSeason.AutoSize = true;
      this.rdSeason.Location = new System.Drawing.Point(7, 44);
      this.rdSeason.Name = "rdSeason";
      this.rdSeason.Size = new System.Drawing.Size(61, 17);
      this.rdSeason.TabIndex = 1;
      this.rdSeason.TabStop = true;
      this.rdSeason.Text = "Season";
      this.rdSeason.UseVisualStyleBackColor = true;
      // 
      // rdWeek
      // 
      this.rdWeek.AutoSize = true;
      this.rdWeek.Location = new System.Drawing.Point(7, 20);
      this.rdWeek.Name = "rdWeek";
      this.rdWeek.Size = new System.Drawing.Size(54, 17);
      this.rdWeek.TabIndex = 0;
      this.rdWeek.TabStop = true;
      this.rdWeek.Text = "Week";
      this.rdWeek.UseVisualStyleBackColor = true;
      this.rdWeek.CheckedChanged += new System.EventHandler(this.rdWeekly_CheckedChanged);
      // 
      // chart
      // 
      this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      chartArea1.Name = "ChartArea1";
      this.chart.ChartAreas.Add(chartArea1);
      legend1.Name = "Legend1";
      this.chart.Legends.Add(legend1);
      this.chart.Location = new System.Drawing.Point(8, 340);
      this.chart.Name = "chart";
      this.chart.Size = new System.Drawing.Size(627, 323);
      this.chart.TabIndex = 0;
      this.chart.Text = "chart1";
      // 
      // _lblTitle
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(542, 115);
      this.label1.Name = "_lblTitle";
      this.label1.Size = new System.Drawing.Size(73, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Interval (days)";
      // 
      // txtDays
      // 
      this.txtDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.txtDays.Location = new System.Drawing.Point(545, 132);
      this.txtDays.Name = "txtDays";
      this.txtDays.Size = new System.Drawing.Size(88, 20);
      this.txtDays.TabIndex = 3;
      this.txtDays.TextChanged += new System.EventHandler(this.txtDays_TextChanged);
      // 
      // MyEconomyUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.split);
      this.DoubleBuffered = true;
      this.Name = "MyEconomyUserControl";
      this.Size = new System.Drawing.Size(972, 674);
      this.Load += new System.EventHandler(this.MyEconomyUserControl_Load);
      ((System.ComponentModel.ISupportInitialize)(this.olv)).EndInit();
      this.split.Panel1.ResumeLayout(false);
      this.split.Panel2.ResumeLayout(false);
      this.split.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
      this.split.ResumeLayout(false);
      this.gbxBalanceMode.ResumeLayout(false);
      this.gbxBalanceMode.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    #region fields

    //private System.Windows.Forms.DataGridView dgTeamTransfers;
    private BalanceUserControl ucEconomyWeek;
    private BalanceUserControl ucEconomySeason;
    private  uint _myTeamId;
    private ObjectListView olv;
    #endregion

    #region events

    private void olv_HyperlinkClicked (object sender, HyperlinkClickedEventArgs e)
    {
      Xsd2.charazayTransfer transfer = (Xsd2.charazayTransfer)e.Item.RowObject;
      if (transfer == null)
        return;
      //
      switch (e.ColumnIndex)
      {
        case 0:
          { //seller
            Web.CharazayDownloadItem teamLink = new Web.CharazayDownloadItem("team", 0, transfer.sellteam);
            e.Url = teamLink.Uri.AbsoluteUri;
          } break;
        case 1:
          { //buyer
            Web.CharazayDownloadItem teamLink = new Web.CharazayDownloadItem("team", 0, transfer.buyteam);
            e.Url = teamLink.Uri.AbsoluteUri;
          } break;
        case 3:
          { //player
            Web.CharazayDownloadItem teamLink = new Web.CharazayDownloadItem("player", 1, transfer.playerid);
            e.Url = teamLink.Uri.AbsoluteUri;
          } break;
        default: break;
      }

    } 

    private void MyEconomyUserControl_Load (object sender, EventArgs e)
    {
      var srs = this.chart.Series;

      //foreach (string s in seriesNamesIncome)
      //{
      //  srs.Add(new Series(s) { ChartArea = "ChartArea1", ChartType = SeriesChartType.StackedColumn100 });
      //}
      //foreach (string s in seriesNamesExpences)
      //{
      //  srs.Add(new Series(s) { ChartArea = "ChartArea1", ChartType = SeriesChartType.StackedColumn100 });
      //}
      
      //srs.Add(new Series("Balance") { ChartArea = "ChartArea1", ChartType = SeriesChartType.Line, MarkerSize=7, MarkerStyle=MarkerStyle.Circle });
      
      //
      // chart area
      //
      var c1 = this.chart.ChartAreas["ChartArea1"];
      c1.AxisX.Title = "Date";
      c1.AxisX.TitleFont = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
      c1.AxisX.IsMarginVisible = true;
      c1.AxisX.IsLabelAutoFit = true;
      c1.AxisX.Interval = 1;
      c1.AxisX.IntervalOffset = 1;
      c1.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
      c1.AxisX.IntervalType = DateTimeIntervalType.Days;

      c1.AxisX2.Enabled = AxisEnabled.True;
      c1.AxisX2.Title = "Charazay Date";

     
      c1.AxisY.Title = "Income/Expences";
      c1.AxisY.TitleFont = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
      c1.AxisY.IsMarginVisible = true;
      c1.AxisY.IsLabelAutoFit = true;
      c1.AxisY2.Enabled = AxisEnabled.False;
      c1.AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
      c1.AxisY.Interval = 10000000;
      c1.AxisY.IntervalOffset = 1000000;


      this.chart.Titles.Add(new Title("Balance History"
        , Docking.Top
        , new Font(FontFamily.GenericSansSerif, 14, FontStyle.Bold)
        , Color.Azure
        ));
      //            
    }

    private void AddDataPoints ()
    {
      if (this._runMode == RunMode.Unknown)
        return;
      //
      SeriesCollection srs = this.chart.Series;
      foreach (var s in srs) { s.Points.Clear(); }
      srs.Clear();
      //
      foreach (var l in this.chart.Legends)
        l.CustomItems.Clear();
      //
      if (this._runMode == RunMode.Week)
      {
        srs.Add(new Series("W+") { ChartArea = "ChartArea1", ChartType = SeriesChartType.Bar, IsValueShownAsLabel = true });
        srs["W+"]["PointWidth"] = "1.0";
        srs.Add(new Series("W-") { ChartArea = "ChartArea1", ChartType = SeriesChartType.Bar, IsValueShownAsLabel = true });
        srs["W-"]["BarLabelStyle"] = "Center";
      }
      else if (this._runMode == RunMode.Season)
      {
        srs.Add(new Series("S+") { ChartArea = "ChartArea1", ChartType = SeriesChartType.Bar, IsValueShownAsLabel = true });
        srs.Add(new Series("S-") { ChartArea = "ChartArea1", ChartType = SeriesChartType.Bar, IsValueShownAsLabel = true });
      }
      //
      //
      //
      if (this._runMode == RunMode.Week)
      {
        this.chart.Titles[0].Text = "Weekly Balance History";
        var history = Deserializer.GetEconomyHistory(this._days).ToList();
        var ca = this.chart.ChartAreas["ChartArea1"];
        ca.AxisY.Minimum = -history.Select(tuple => tuple.Item2.economy_week.expences.Total).Max();
        ca.AxisY.Maximum = history.Select(tuple => tuple.Item2.economy_week.income.Total).Max();
        foreach (var h in history)
        {
          srs["W+"].Points.AddXY(h.Item1, h.Item2.economy_week.income.Total);
          srs["W-"].Points.AddXY(h.Item1, -h.Item2.economy_week.expences.Total);
        }
        
        
      }
      else if (this._runMode == RunMode.Season)
      {
        this.chart.Titles[0].Text = "Season Balance History";
        var history = Deserializer.GetEconomyHistory(this._days).ToList();
        var ca = this.chart.ChartAreas["ChartArea1"];
        
        double maxExpences = history.Select(tuple => tuple.Item2.economy_season.expences.Total).Max();
        ca.AxisY.Minimum = -Math.Ceiling(maxExpences / YScale) * YScale;
        
        double maxIncome = history.Select(tuple => tuple.Item2.economy_season.income.Total).Max();
        ca.AxisY.Maximum = Math.Ceiling(maxIncome / YScale) * YScale;

        foreach (var h in history)
        {
          srs["S+"].Points.AddXY(h.Item1, h.Item2.economy_season.income.Total);
          srs["S-"].Points.AddXY(h.Item1, -h.Item2.economy_season.expences.Total);
        }  
        
      }
      
        //srs[0].Points.AddXY(h.Item1, h.Item2.economy_week.income.merchandise);
        //srs[1].Points.AddXY(h.Item1, h.Item2.economy_week.income.other);
        //srs[2].Points.AddXY(h.Item1, h.Item2.economy_week.income.sales);
        //srs[3].Points.AddXY(h.Item1, h.Item2.economy_week.income.sponsor);
        //srs[4].Points.AddXY(h.Item1, h.Item2.economy_week.income.tickets);
        ////
        //srs[5].Points.AddXY(h.Item1, -h.Item2.economy_week.expences.buys);
        //srs[6].Points.AddXY(h.Item1, -h.Item2.economy_week.expences.facility);
        //srs[7].Points.AddXY(h.Item1, -h.Item2.economy_week.expences.maintenance);
        //srs[8].Points.AddXY(h.Item1, -h.Item2.economy_week.expences.other);
        //srs[9].Points.AddXY(h.Item1, -h.Item2.economy_week.expences.salary);
        //srs[10].Points.AddXY(h.Item1, -h.Item2.economy_week.expences.staff);
        //
        //srs["Balance"].Points.AddXY(h.Item1, h.Item2.economy_week.income.Total - h.Item2.economy_week.expences.Total);

        
        
      
    }

    #endregion

    private void rdWeekly_CheckedChanged (object sender, EventArgs e)
    {
      if (rdSeason.Checked)
        this._runMode = RunMode.Season;
      else if (rdWeek.Checked)
        this._runMode = RunMode.Week;
      else
        this._runMode = RunMode.Unknown;
      AddDataPoints();
    }

    private void txtDays_TextChanged (object sender, EventArgs e)
    {
      Int32.TryParse(this.txtDays.Text, out this._days);
      AddDataPoints();
    }

    

   
  }
}
