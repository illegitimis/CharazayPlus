using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LeastSquares;
using System.Windows.Forms.DataVisualization.Charting;

namespace AndreiPopescu.CharazayPlus.UI
{
  public partial class ChartUserControl : UserControl
  {
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
      this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.rdC = new System.Windows.Forms.RadioButton();
      this.rdF = new System.Windows.Forms.RadioButton();
      this.rdG = new System.Windows.Forms.RadioButton();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.radioButton16 = new System.Windows.Forms.RadioButton();
      this.radioButton17 = new System.Windows.Forms.RadioButton();
      this.radioButton18 = new System.Windows.Forms.RadioButton();
      this.radioButton7 = new System.Windows.Forms.RadioButton();
      this.radioButton8 = new System.Windows.Forms.RadioButton();
      this.radioButton9 = new System.Windows.Forms.RadioButton();
      this.radioButton10 = new System.Windows.Forms.RadioButton();
      this.radioButton11 = new System.Windows.Forms.RadioButton();
      this.radioButton12 = new System.Windows.Forms.RadioButton();
      this.radioButton13 = new System.Windows.Forms.RadioButton();
      this.radioButton14 = new System.Windows.Forms.RadioButton();
      this.radioButton15 = new System.Windows.Forms.RadioButton();
      this.radioButton4 = new System.Windows.Forms.RadioButton();
      this.radioButton5 = new System.Windows.Forms.RadioButton();
      this.radioButton6 = new System.Windows.Forms.RadioButton();
      this.radioButton1 = new System.Windows.Forms.RadioButton();
      this.radioButton2 = new System.Windows.Forms.RadioButton();
      this.radioButton3 = new System.Windows.Forms.RadioButton();
      this.rd17 = new System.Windows.Forms.RadioButton();
      this.rd16 = new System.Windows.Forms.RadioButton();
      this.rd15 = new System.Windows.Forms.RadioButton();
      ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // chart
      // 
      this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.chart.BackColor = System.Drawing.Color.DimGray;
      this.chart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalLeft;
      chartArea1.Name = "ChartArea1";
      this.chart.ChartAreas.Add(chartArea1);
      legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
      legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
      legend1.Name = "Legend1";
      this.chart.Legends.Add(legend1);
      this.chart.Location = new System.Drawing.Point(0, 0);
      this.chart.Name = "chart";
      this.chart.Size = new System.Drawing.Size(617, 603);
      this.chart.TabIndex = 1;
      this.chart.Text = "chart1";
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.rdC);
      this.groupBox1.Controls.Add(this.rdF);
      this.groupBox1.Controls.Add(this.rdG);
      this.groupBox1.Location = new System.Drawing.Point(623, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(46, 90);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Court";
      // 
      // rdC
      // 
      this.rdC.AutoSize = true;
      this.rdC.Location = new System.Drawing.Point(6, 65);
      this.rdC.Name = "rdC";
      this.rdC.Size = new System.Drawing.Size(32, 17);
      this.rdC.TabIndex = 5;
      this.rdC.TabStop = true;
      this.rdC.Text = "C";
      this.rdC.UseVisualStyleBackColor = true;
      this.rdC.CheckedChanged += new System.EventHandler(this.rdG_CheckedChanged);
      // 
      // rdF
      // 
      this.rdF.AutoSize = true;
      this.rdF.Location = new System.Drawing.Point(6, 42);
      this.rdF.Name = "rdF";
      this.rdF.Size = new System.Drawing.Size(31, 17);
      this.rdF.TabIndex = 4;
      this.rdF.TabStop = true;
      this.rdF.Text = "F";
      this.rdF.UseVisualStyleBackColor = true;
      this.rdF.CheckedChanged += new System.EventHandler(this.rdG_CheckedChanged);
      // 
      // rdG
      // 
      this.rdG.AutoSize = true;
      this.rdG.Location = new System.Drawing.Point(6, 19);
      this.rdG.Name = "rdG";
      this.rdG.Size = new System.Drawing.Size(33, 17);
      this.rdG.TabIndex = 0;
      this.rdG.TabStop = true;
      this.rdG.Text = "G";
      this.rdG.UseVisualStyleBackColor = true;
      this.rdG.CheckedChanged += new System.EventHandler(this.rdG_CheckedChanged);
      // 
      // groupBox2
      // 
      this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox2.Controls.Add(this.radioButton16);
      this.groupBox2.Controls.Add(this.radioButton17);
      this.groupBox2.Controls.Add(this.radioButton18);
      this.groupBox2.Controls.Add(this.radioButton7);
      this.groupBox2.Controls.Add(this.radioButton8);
      this.groupBox2.Controls.Add(this.radioButton9);
      this.groupBox2.Controls.Add(this.radioButton10);
      this.groupBox2.Controls.Add(this.radioButton11);
      this.groupBox2.Controls.Add(this.radioButton12);
      this.groupBox2.Controls.Add(this.radioButton13);
      this.groupBox2.Controls.Add(this.radioButton14);
      this.groupBox2.Controls.Add(this.radioButton15);
      this.groupBox2.Controls.Add(this.radioButton4);
      this.groupBox2.Controls.Add(this.radioButton5);
      this.groupBox2.Controls.Add(this.radioButton6);
      this.groupBox2.Controls.Add(this.radioButton1);
      this.groupBox2.Controls.Add(this.radioButton2);
      this.groupBox2.Controls.Add(this.radioButton3);
      this.groupBox2.Controls.Add(this.rd17);
      this.groupBox2.Controls.Add(this.rd16);
      this.groupBox2.Controls.Add(this.rd15);
      this.groupBox2.Location = new System.Drawing.Point(623, 99);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(46, 504);
      this.groupBox2.TabIndex = 3;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Age";
      // 
      // radioButton16
      // 
      this.radioButton16.AutoSize = true;
      this.radioButton16.Location = new System.Drawing.Point(5, 479);
      this.radioButton16.Name = "radioButton16";
      this.radioButton16.Size = new System.Drawing.Size(37, 17);
      this.radioButton16.TabIndex = 21;
      this.radioButton16.TabStop = true;
      this.radioButton16.Text = "35";
      this.radioButton16.UseVisualStyleBackColor = true;
      this.radioButton16.CheckedChanged += new System.EventHandler(this.rd15_CheckedChanged);
      // 
      // radioButton17
      // 
      this.radioButton17.AutoSize = true;
      this.radioButton17.Location = new System.Drawing.Point(5, 456);
      this.radioButton17.Name = "radioButton17";
      this.radioButton17.Size = new System.Drawing.Size(37, 17);
      this.radioButton17.TabIndex = 20;
      this.radioButton17.TabStop = true;
      this.radioButton17.Text = "34";
      this.radioButton17.UseVisualStyleBackColor = true;
      this.radioButton17.CheckedChanged += new System.EventHandler(this.rd15_CheckedChanged);
      // 
      // radioButton18
      // 
      this.radioButton18.AutoSize = true;
      this.radioButton18.Location = new System.Drawing.Point(5, 433);
      this.radioButton18.Name = "radioButton18";
      this.radioButton18.Size = new System.Drawing.Size(37, 17);
      this.radioButton18.TabIndex = 19;
      this.radioButton18.TabStop = true;
      this.radioButton18.Text = "33";
      this.radioButton18.UseVisualStyleBackColor = true;
      this.radioButton18.CheckedChanged += new System.EventHandler(this.rd15_CheckedChanged);
      // 
      // radioButton7
      // 
      this.radioButton7.AutoSize = true;
      this.radioButton7.Location = new System.Drawing.Point(5, 410);
      this.radioButton7.Name = "radioButton7";
      this.radioButton7.Size = new System.Drawing.Size(37, 17);
      this.radioButton7.TabIndex = 18;
      this.radioButton7.TabStop = true;
      this.radioButton7.Text = "32";
      this.radioButton7.UseVisualStyleBackColor = true;
      this.radioButton7.CheckedChanged += new System.EventHandler(this.rd15_CheckedChanged);
      // 
      // radioButton8
      // 
      this.radioButton8.AutoSize = true;
      this.radioButton8.Location = new System.Drawing.Point(5, 387);
      this.radioButton8.Name = "radioButton8";
      this.radioButton8.Size = new System.Drawing.Size(37, 17);
      this.radioButton8.TabIndex = 17;
      this.radioButton8.TabStop = true;
      this.radioButton8.Text = "31";
      this.radioButton8.UseVisualStyleBackColor = true;
      this.radioButton8.CheckedChanged += new System.EventHandler(this.rd15_CheckedChanged);
      // 
      // radioButton9
      // 
      this.radioButton9.AutoSize = true;
      this.radioButton9.Location = new System.Drawing.Point(5, 364);
      this.radioButton9.Name = "radioButton9";
      this.radioButton9.Size = new System.Drawing.Size(37, 17);
      this.radioButton9.TabIndex = 16;
      this.radioButton9.TabStop = true;
      this.radioButton9.Text = "30";
      this.radioButton9.UseVisualStyleBackColor = true;
      this.radioButton9.CheckedChanged += new System.EventHandler(this.rd15_CheckedChanged);
      // 
      // radioButton10
      // 
      this.radioButton10.AutoSize = true;
      this.radioButton10.Location = new System.Drawing.Point(5, 341);
      this.radioButton10.Name = "radioButton10";
      this.radioButton10.Size = new System.Drawing.Size(37, 17);
      this.radioButton10.TabIndex = 15;
      this.radioButton10.TabStop = true;
      this.radioButton10.Text = "29";
      this.radioButton10.UseVisualStyleBackColor = true;
      this.radioButton10.CheckedChanged += new System.EventHandler(this.rd15_CheckedChanged);
      // 
      // radioButton11
      // 
      this.radioButton11.AutoSize = true;
      this.radioButton11.Location = new System.Drawing.Point(5, 318);
      this.radioButton11.Name = "radioButton11";
      this.radioButton11.Size = new System.Drawing.Size(37, 17);
      this.radioButton11.TabIndex = 14;
      this.radioButton11.TabStop = true;
      this.radioButton11.Text = "28";
      this.radioButton11.UseVisualStyleBackColor = true;
      this.radioButton11.CheckedChanged += new System.EventHandler(this.rd15_CheckedChanged);
      // 
      // radioButton12
      // 
      this.radioButton12.AutoSize = true;
      this.radioButton12.Location = new System.Drawing.Point(5, 295);
      this.radioButton12.Name = "radioButton12";
      this.radioButton12.Size = new System.Drawing.Size(37, 17);
      this.radioButton12.TabIndex = 13;
      this.radioButton12.TabStop = true;
      this.radioButton12.Text = "27";
      this.radioButton12.UseVisualStyleBackColor = true;
      this.radioButton12.CheckedChanged += new System.EventHandler(this.rd15_CheckedChanged);
      // 
      // radioButton13
      // 
      this.radioButton13.AutoSize = true;
      this.radioButton13.Location = new System.Drawing.Point(5, 272);
      this.radioButton13.Name = "radioButton13";
      this.radioButton13.Size = new System.Drawing.Size(37, 17);
      this.radioButton13.TabIndex = 12;
      this.radioButton13.TabStop = true;
      this.radioButton13.Text = "26";
      this.radioButton13.UseVisualStyleBackColor = true;
      this.radioButton13.CheckedChanged += new System.EventHandler(this.rd15_CheckedChanged);
      // 
      // radioButton14
      // 
      this.radioButton14.AutoSize = true;
      this.radioButton14.Location = new System.Drawing.Point(5, 249);
      this.radioButton14.Name = "radioButton14";
      this.radioButton14.Size = new System.Drawing.Size(37, 17);
      this.radioButton14.TabIndex = 11;
      this.radioButton14.TabStop = true;
      this.radioButton14.Text = "25";
      this.radioButton14.UseVisualStyleBackColor = true;
      this.radioButton14.CheckedChanged += new System.EventHandler(this.rd15_CheckedChanged);
      // 
      // radioButton15
      // 
      this.radioButton15.AutoSize = true;
      this.radioButton15.Location = new System.Drawing.Point(5, 226);
      this.radioButton15.Name = "radioButton15";
      this.radioButton15.Size = new System.Drawing.Size(37, 17);
      this.radioButton15.TabIndex = 10;
      this.radioButton15.TabStop = true;
      this.radioButton15.Text = "24";
      this.radioButton15.UseVisualStyleBackColor = true;
      this.radioButton15.CheckedChanged += new System.EventHandler(this.rd15_CheckedChanged);
      // 
      // radioButton4
      // 
      this.radioButton4.AutoSize = true;
      this.radioButton4.Location = new System.Drawing.Point(5, 203);
      this.radioButton4.Name = "radioButton4";
      this.radioButton4.Size = new System.Drawing.Size(37, 17);
      this.radioButton4.TabIndex = 9;
      this.radioButton4.TabStop = true;
      this.radioButton4.Text = "23";
      this.radioButton4.UseVisualStyleBackColor = true;
      this.radioButton4.CheckedChanged += new System.EventHandler(this.rd15_CheckedChanged);
      // 
      // radioButton5
      // 
      this.radioButton5.AutoSize = true;
      this.radioButton5.Location = new System.Drawing.Point(5, 180);
      this.radioButton5.Name = "radioButton5";
      this.radioButton5.Size = new System.Drawing.Size(37, 17);
      this.radioButton5.TabIndex = 8;
      this.radioButton5.TabStop = true;
      this.radioButton5.Text = "22";
      this.radioButton5.UseVisualStyleBackColor = true;
      this.radioButton5.CheckedChanged += new System.EventHandler(this.rd15_CheckedChanged);
      // 
      // radioButton6
      // 
      this.radioButton6.AutoSize = true;
      this.radioButton6.Location = new System.Drawing.Point(5, 157);
      this.radioButton6.Name = "radioButton6";
      this.radioButton6.Size = new System.Drawing.Size(37, 17);
      this.radioButton6.TabIndex = 7;
      this.radioButton6.TabStop = true;
      this.radioButton6.Text = "21";
      this.radioButton6.UseVisualStyleBackColor = true;
      this.radioButton6.CheckedChanged += new System.EventHandler(this.rd15_CheckedChanged);
      // 
      // radioButton1
      // 
      this.radioButton1.AutoSize = true;
      this.radioButton1.Location = new System.Drawing.Point(5, 134);
      this.radioButton1.Name = "radioButton1";
      this.radioButton1.Size = new System.Drawing.Size(37, 17);
      this.radioButton1.TabIndex = 6;
      this.radioButton1.TabStop = true;
      this.radioButton1.Text = "20";
      this.radioButton1.UseVisualStyleBackColor = true;
      this.radioButton1.CheckedChanged += new System.EventHandler(this.rd15_CheckedChanged);
      // 
      // radioButton2
      // 
      this.radioButton2.AutoSize = true;
      this.radioButton2.Location = new System.Drawing.Point(5, 111);
      this.radioButton2.Name = "radioButton2";
      this.radioButton2.Size = new System.Drawing.Size(37, 17);
      this.radioButton2.TabIndex = 5;
      this.radioButton2.TabStop = true;
      this.radioButton2.Text = "19";
      this.radioButton2.UseVisualStyleBackColor = true;
      this.radioButton2.CheckedChanged += new System.EventHandler(this.rd15_CheckedChanged);
      // 
      // radioButton3
      // 
      this.radioButton3.AutoSize = true;
      this.radioButton3.Location = new System.Drawing.Point(5, 88);
      this.radioButton3.Name = "radioButton3";
      this.radioButton3.Size = new System.Drawing.Size(37, 17);
      this.radioButton3.TabIndex = 4;
      this.radioButton3.TabStop = true;
      this.radioButton3.Text = "18";
      this.radioButton3.UseVisualStyleBackColor = true;
      this.radioButton3.CheckedChanged += new System.EventHandler(this.rd15_CheckedChanged);
      // 
      // rd17
      // 
      this.rd17.AutoSize = true;
      this.rd17.Location = new System.Drawing.Point(5, 65);
      this.rd17.Name = "rd17";
      this.rd17.Size = new System.Drawing.Size(37, 17);
      this.rd17.TabIndex = 3;
      this.rd17.TabStop = true;
      this.rd17.Text = "17";
      this.rd17.UseVisualStyleBackColor = true;
      this.rd17.CheckedChanged += new System.EventHandler(this.rd15_CheckedChanged);
      // 
      // rd16
      // 
      this.rd16.AutoSize = true;
      this.rd16.Location = new System.Drawing.Point(5, 42);
      this.rd16.Name = "rd16";
      this.rd16.Size = new System.Drawing.Size(37, 17);
      this.rd16.TabIndex = 2;
      this.rd16.TabStop = true;
      this.rd16.Text = "16";
      this.rd16.UseVisualStyleBackColor = true;
      this.rd16.CheckedChanged += new System.EventHandler(this.rd15_CheckedChanged);
      // 
      // rd15
      // 
      this.rd15.AutoSize = true;
      this.rd15.Location = new System.Drawing.Point(5, 19);
      this.rd15.Name = "rd15";
      this.rd15.Size = new System.Drawing.Size(37, 17);
      this.rd15.TabIndex = 1;
      this.rd15.TabStop = true;
      this.rd15.Text = "15";
      this.rd15.UseVisualStyleBackColor = true;
      this.rd15.CheckedChanged += new System.EventHandler(this.rd15_CheckedChanged);
      // 
      // ChartUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.chart);
      this.Name = "ChartUserControl";
      this.Size = new System.Drawing.Size(672, 607);
      this.Load += new System.EventHandler(this.ChartUserControl_Load);
      ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    #region generated members
    private GroupBox groupBox1;
    private RadioButton rdC;
    private RadioButton rdF;
    private RadioButton rdG;
    private GroupBox groupBox2;
    private RadioButton radioButton16;
    private RadioButton radioButton17;
    private RadioButton radioButton18;
    private RadioButton radioButton7;
    private RadioButton radioButton8;
    private RadioButton radioButton9;
    private RadioButton radioButton10;
    private RadioButton radioButton11;
    private RadioButton radioButton12;
    private RadioButton radioButton13;
    private RadioButton radioButton14;
    private RadioButton radioButton15;
    private RadioButton radioButton4;
    private RadioButton radioButton5;
    private RadioButton radioButton6;
    private RadioButton radioButton1;
    private RadioButton radioButton2;
    private RadioButton radioButton3;
    private RadioButton rd17;
    private RadioButton rd16;
    private RadioButton rd15;

    private System.Windows.Forms.DataVisualization.Charting.Chart chart; 
    #endregion

    #region fields
    byte _currentAge = byte.MinValue;
    char _pos = char.MinValue; 
    #endregion
    

    public ChartUserControl ( )
    {
      InitializeComponent();
      
    }

    #region utility
    private void AddData ( )
    {
      foreach (var s in this.chart.Series)
        s.Points.Clear();
      foreach (var l in this.chart.Legends)
        l.CustomItems.Clear();



#if DOTNET30

      var ths = Data.DbEnvironment.Instance.TransferHistoryDC.Histories.Where(x => x.Age == this._currentAge && x.PosId == this._pos).ToList();
      //
      // set axes ranges
      //
      double xmin = Math.Max(0.7d, (double)ths.Select(x => x.AgeValueIndex).Min());
      double xmax = Math.Min(1.4d, (double)ths.Select(x => x.AgeValueIndex).Max());
      double ymin = 0d;
      double ymax = (double)Math.Ceiling(ths.Select(y => y.Price).Max());
      var c1 = this.chart.ChartAreas["ChartArea1"];
      c1.AxisX.Minimum = xmin;
      c1.AxisY.Maximum = xmax;
      c1.AxisY.Minimum = ymin;
      c1.AxisY.Maximum = ymax;
      //
      // add scatter data
      //
      foreach (var th in ths)
      {
        this.chart.Series[0].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint()
        {
          ToolTip = string.Format("Value Index: {0:F02} Price:{1:F02} Day: {2:yyyy-MM-dd}", th.AgeValueIndex, th.Price, th.Day)
          ,
          XValue = (double)th.AgeValueIndex,
          YValues = new double[] { (double)th.Price }
        });
      }
      //
      // add (weighted) averages from db
      //
      var utcnow = DateTime.UtcNow;
      var maxDateDiff =  ths.Select(x => (utcnow - x.Day).Days).Max();
      var query = from th in ths
                  group th by th.AgeValueIndex into g
                  orderby g.Key ascending
                  select g;
      //
      foreach (var g in query)
      {
        double y = (double)g.Select(th => th.Price).Average();
        this.chart.Series[1].Points.AddXY((double)g.Key, y);
        //
        double yw = (double)g.Select(x => x.Price * (2 * maxDateDiff - (utcnow - x.Day).Days)).Sum()
        / (double)g.Select(x => 2 * maxDateDiff - (utcnow - x.Day).Days).Sum();
        this.chart.Series[2].Points.Add(new DataPoint()
        {
          Label = yw.ToString("F02"),
          XValue = (double)g.Key,
          YValues = new double[] { yw }
        });
      }
      //
      double a1,b1,a2,b2,a3,b3;
      var i1 = new Utils.MatlabInterpolant20140909 ();
      i1.GetAB(this._currentAge, this._pos, out a1, out b1);
      Utils.MatlabInterpolant20141124.Instance.GetAB(this._currentAge, this._pos, out a2, out b2);
      Utils.MatlabInterpolant20150504.Instance.GetAB(this._currentAge, this._pos, out a3, out b3);
      //
      for (double x = xmin; x < xmax + 0.01d; x = x + 0.01d)
      {
        this.chart.Series[3].Points.AddXY(x, a1 * Math.Exp(x * b1));
        this.chart.Series[4].Points.AddXY(x, a2 * Math.Exp(x * b2));
        this.chart.Series[5].Points.AddXY(x, a3 * Math.Exp(x * b3));
      }
      //AddRectangleAnnotation(f2);
      //AddEllipseAnnotation(f1);
      //this.chart.Legends[0].CustomItems.Add(Color.Black, f1.ToString());
      //this.chart.Legends[0].CustomItems.Add(Color.Black, f2.ToString());
      this.chart.Legends[0].CustomItems.Add(Color.Black, string.Format("Exponential fit (A*e^(B*x)) as of September 2014, A={0} B={1}", a1, b1));
      this.chart.Legends[0].CustomItems.Add(Color.Black, string.Format("Exponential fit (A*e^(B*x)) as of November 2014, A={0} B={1}", a2, b2));
      this.chart.Legends[0].CustomItems.Add(Color.Black, string.Format("Exponential fit (A*e^(B*x)) as of May 2015, A={0} B={1}", a3, b3));
      this.chart.Legends[0].CustomItems.Add(Color.Tan, string.Format("Series has: {0} data points", ths.Count));
      //

#else
      var ds = new Objects.TransferHistoryDataSet();
      var tam = new Objects.TransferHistoryDataSetTableAdapters.TableAdapterManager();
      tam.BackupDataSetBeforeUpdate = false;
      tam.HistoryTableAdapter = new Objects.TransferHistoryDataSetTableAdapters.HistoryTableAdapter();
      tam.HistoryTableAdapter.Fill(ds.History);
      //
      //tam.UpdateAll(ds);
      //
      foreach (AndreiPopescu.CharazayPlus.Objects.TransferHistoryDataSet.HistoryRow hr in ds.History.Rows)
      {
        //hr.Age

      }
#endif



    }

    private void AddRectangleAnnotation (ExponentialOptimum eo)
    {
      var annotation = new System.Windows.Forms.DataVisualization.Charting.RectangleAnnotation();
      annotation.AnchorDataPoint = new System.Windows.Forms.DataVisualization.Charting.DataPoint(200, 200);
      annotation.Text = eo.ToString();
      annotation.ForeColor = Color.Black;
      annotation.Font = new Font("Arial", 12);
      annotation.LineWidth = 2;
      annotation.BackColor = Color.PaleGoldenrod;
      annotation.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;

      this.chart.Annotations.Add(annotation);
    }

    private void AddEllipseAnnotation (Exponential e)
    {
      var annotation = new System.Windows.Forms.DataVisualization.Charting.EllipseAnnotation();
      annotation.AnchorDataPoint = new System.Windows.Forms.DataVisualization.Charting.DataPoint(200, 400);
      annotation.Text = e.ToString();
      annotation.ForeColor = Color.Black;
      annotation.Font = new Font("Arial", 12);
      annotation.LineWidth = 2;
      annotation.Height = 35;
      annotation.Width = 60;
      annotation.BackColor = Color.PaleTurquoise;
      annotation.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;

      this.chart.Annotations.Add(annotation);
    } 
    #endregion

    #region event handlers
    private void rdG_CheckedChanged (object sender, EventArgs e)
    {
      RadioButton rb = sender as RadioButton;
      _pos = rb.Text[0];
      if (this._currentAge != byte.MinValue)
        AddData();
    }

    private void rd15_CheckedChanged (object sender, EventArgs e)
    {
      RadioButton rb = sender as RadioButton;
      _currentAge = byte.Parse(rb.Text);
      if (this._pos != char.MinValue)
        AddData();
    }

    private void ChartUserControl_Load (object sender, EventArgs e)
    { // 0
      this.chart.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series("Scatter data")
      {
        ChartArea = "ChartArea1",
        ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point,
        MarkerSize = 7,
        MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
      });
      // 1
      this.chart.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series("Average price")
      {
        ChartArea = "ChartArea1",
        ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point,
        MarkerSize = 11,
        MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Triangle
      });
      // 2
      this.chart.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series("Weighted average price")
      {
        ChartArea = "ChartArea1",
        ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point,
        MarkerSize = 11,
        MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Cross
      });
      // 3
      this.chart.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series("Sep 2014")
      {
        ChartArea = "ChartArea1",
        ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline,
        MarkerSize = 10,
        MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10
      });
      //
      this.chart.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series("Nov 2014")
      {
        ChartArea = "ChartArea1",
        ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline,
        MarkerSize = 10,
        MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Diamond
      });
      //5
      this.chart.Series.Add(new Series("May 2015")
      {
        ChartArea = "ChartArea1",
        ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline,
        MarkerSize = 10,
        MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square
      });
      //
      // Set auto minimum and maximum values.
      var c1 = this.chart.ChartAreas["ChartArea1"];
      // Enable all elements
      c1.AxisX.MinorGrid.Enabled = true;
      c1.AxisX.MinorTickMark.Enabled = false;
      c1.AxisY.MinorGrid.Enabled = true;
      c1.AxisY.MinorTickMark.Enabled = false;
      // Set Grid lines and tick marks interval
      c1.AxisX.MajorGrid.Interval = 0.05;
      c1.AxisX.MajorTickMark.Interval = 0.05;
      c1.AxisX.MinorGrid.Interval = 0.01;
      c1.AxisX.MinorTickMark.Interval = 0.01;
      c1.AxisY.MajorGrid.Interval = 5;
      c1.AxisY.MajorTickMark.Interval = 5;
      c1.AxisY.MinorGrid.Interval = 1;
      c1.AxisY.MinorTickMark.Interval = 1;
      // Set Line Color
      c1.AxisY.MinorGrid.LineColor = Color.DimGray;
      c1.AxisX.MinorGrid.LineColor = Color.DimGray;
      // Set Line Style
      c1.AxisX.MajorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
      c1.AxisY.MajorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
      c1.AxisY.MinorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
      //
      // Set Line Width
      c1.AxisX.MajorGrid.LineWidth = c1.AxisY.MajorGrid.LineWidth = 1;

      // title
      c1.AxisX.Title = "Age Value Index";
      c1.AxisY.Title = "Estimated Price";
      //
      c1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
      c1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
      //
      this.chart.Titles.Add("Transfer Compare");

    }
    #endregion


       
  }

  public class PlotHelper
  {
    public double[] X = { 1, 2, 3, 4, 5, 6 };
    public double[] Y = { 1, 2, 3, 4, 5, 6 };

    // declare chart as chart type
    public Chart chart;
    // no use having this since accessible 
    public Series dataSeries;



    private delegate int PlotXYDelegate (double x, double y);

    //private int PlotXYAppend (Chart chart, double x, double y)
    private object PlotXYAppend (Chart chart, Series dataSeries, double x, double y)
    {
      return chart.Invoke(new PlotXYDelegate(dataSeries.Points.AddXY), new Object[] { x, y });
      
      //return chart.Series[0].Points.AddXY(x, y);
    }// this line invokes a Delegate which pass in the addXY method defined in Points, so that it can plot a new point on a chart.


    public IEnumerable<object> PlotXYPass (double[] X, double[] Y)
    {
      return X.Zip<double, double, object>(Y, (x, y) => this.PlotXYAppend(this.chart, this.dataSeries, x, y));
    }

    // trying to pass in x,y points by extracting pairs of points from list []X and []Y into the function above which only takes a pair of x,y points
  }
}
