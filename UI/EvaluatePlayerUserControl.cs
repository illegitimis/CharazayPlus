namespace AndreiPopescu.CharazayPlus.UI
{
  using System;
  using System.Windows.Forms;
  using AndreiPopescu.CharazayPlus.Utils;

  public partial class EvaluatePlayerUserControl : UserControl
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
      this.tlp = new System.Windows.Forms.TableLayoutPanel();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.hli1 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli2 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli3 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli4 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli5 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli6 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli7 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli8 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli9 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli10 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli11 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli12 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli13 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli14 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli15 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli16 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli17 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli18 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli19 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli20 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli21 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli22 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli23 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli24 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli25 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.label11 = new System.Windows.Forms.Label();
      this.hli26 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli27 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli28 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli29 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hli30 = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.tlp.SuspendLayout();
      this.SuspendLayout();
      // 
      // tlp
      // 
      this.tlp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tlp.BackColor = System.Drawing.Color.DimGray;
      this.tlp.CausesValidation = false;
      this.tlp.ColumnCount = 7;
      this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
      this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
      this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
      this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
      this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
      this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
      this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
      this.tlp.Controls.Add(this.label1, 0, 1);
      this.tlp.Controls.Add(this.label2, 0, 2);
      this.tlp.Controls.Add(this.label3, 0, 3);
      this.tlp.Controls.Add(this.label4, 0, 4);
      this.tlp.Controls.Add(this.label5, 0, 5);
      this.tlp.Controls.Add(this.label6, 1, 0);
      this.tlp.Controls.Add(this.label7, 2, 0);
      this.tlp.Controls.Add(this.label8, 3, 0);
      this.tlp.Controls.Add(this.label9, 4, 0);
      this.tlp.Controls.Add(this.label10, 5, 0);
      this.tlp.Controls.Add(this.hli1, 1, 1);
      this.tlp.Controls.Add(this.hli2, 1, 2);
      this.tlp.Controls.Add(this.hli3, 1, 3);
      this.tlp.Controls.Add(this.hli4, 1, 4);
      this.tlp.Controls.Add(this.hli5, 1, 5);
      this.tlp.Controls.Add(this.hli6, 2, 1);
      this.tlp.Controls.Add(this.hli7, 2, 2);
      this.tlp.Controls.Add(this.hli8, 2, 3);
      this.tlp.Controls.Add(this.hli9, 2, 4);
      this.tlp.Controls.Add(this.hli10, 2, 5);
      this.tlp.Controls.Add(this.hli11, 3, 1);
      this.tlp.Controls.Add(this.hli12, 3, 2);
      this.tlp.Controls.Add(this.hli13, 3, 3);
      this.tlp.Controls.Add(this.hli14, 3, 4);
      this.tlp.Controls.Add(this.hli15, 3, 5);
      this.tlp.Controls.Add(this.hli16, 4, 1);
      this.tlp.Controls.Add(this.hli17, 4, 2);
      this.tlp.Controls.Add(this.hli18, 4, 3);
      this.tlp.Controls.Add(this.hli19, 4, 4);
      this.tlp.Controls.Add(this.hli20, 4, 5);
      this.tlp.Controls.Add(this.hli21, 5, 1);
      this.tlp.Controls.Add(this.hli22, 5, 2);
      this.tlp.Controls.Add(this.hli23, 5, 3);
      this.tlp.Controls.Add(this.hli24, 5, 4);
      this.tlp.Controls.Add(this.hli25, 5, 5);
      this.tlp.Controls.Add(this.label11, 6, 0);
      this.tlp.Controls.Add(this.hli26, 6, 1);
      this.tlp.Controls.Add(this.hli27, 6, 2);
      this.tlp.Controls.Add(this.hli28, 6, 3);
      this.tlp.Controls.Add(this.hli29, 6, 4);
      this.tlp.Controls.Add(this.hli30, 6, 5);
      this.tlp.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tlp.ForeColor = System.Drawing.Color.White;
      this.tlp.Location = new System.Drawing.Point(0, 0);
      this.tlp.Name = "tlp";
      this.tlp.RowCount = 6;
      this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tlp.Size = new System.Drawing.Size(681, 135);
      this.tlp.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new System.Drawing.Point(3, 20);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(33, 23);
      this.label1.TabIndex = 0;
      this.label1.Text = "PG";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label2.ForeColor = System.Drawing.Color.White;
      this.label2.Location = new System.Drawing.Point(3, 43);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(33, 23);
      this.label2.TabIndex = 1;
      this.label2.Text = "SG";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label3.ForeColor = System.Drawing.Color.White;
      this.label3.Location = new System.Drawing.Point(3, 66);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(33, 23);
      this.label3.TabIndex = 2;
      this.label3.Text = "SF";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label4.ForeColor = System.Drawing.Color.White;
      this.label4.Location = new System.Drawing.Point(3, 89);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(33, 23);
      this.label4.TabIndex = 3;
      this.label4.Text = "PF";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label5.ForeColor = System.Drawing.Color.White;
      this.label5.Location = new System.Drawing.Point(3, 112);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(33, 23);
      this.label5.TabIndex = 4;
      this.label5.Text = "C";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label6.ForeColor = System.Drawing.Color.White;
      this.label6.Location = new System.Drawing.Point(42, 0);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(64, 20);
      this.label6.TabIndex = 5;
      this.label6.Text = "Defensive Score";
      this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label7.ForeColor = System.Drawing.Color.White;
      this.label7.Location = new System.Drawing.Point(148, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(99, 13);
      this.label7.TabIndex = 6;
      this.label7.Text = "Offensive Ability";
      this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label8.ForeColor = System.Drawing.Color.White;
      this.label8.Location = new System.Drawing.Point(254, 0);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(94, 13);
      this.label8.TabIndex = 7;
      this.label8.Text = "Shooting Score";
      this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label9.ForeColor = System.Drawing.Color.White;
      this.label9.Location = new System.Drawing.Point(360, 0);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(98, 13);
      this.label9.TabIndex = 8;
      this.label9.Text = "Offensive Score";
      this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label10.ForeColor = System.Drawing.Color.White;
      this.label10.Location = new System.Drawing.Point(466, 0);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(73, 13);
      this.label10.TabIndex = 9;
      this.label10.Text = "Total Score";
      this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // hli1
      // 
      this.hli1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.hli1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli1.Level = 30F;
      this.hli1.Location = new System.Drawing.Point(42, 20);
      this.hli1.MaximumLevel = 30F;
      this.hli1.Name = "hli1";
      this.hli1.Size = new System.Drawing.Size(100, 23);
      this.hli1.TabIndex = 10;
      this.hli1.Text = "30";
      this.hli1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli2
      // 
      this.hli2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli2.Level = 30F;
      this.hli2.Location = new System.Drawing.Point(42, 43);
      this.hli2.MaximumLevel = 30F;
      this.hli2.Name = "hli2";
      this.hli2.Size = new System.Drawing.Size(100, 23);
      this.hli2.TabIndex = 11;
      this.hli2.Text = "30";
      this.hli2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli3
      // 
      this.hli3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli3.Level = 30F;
      this.hli3.Location = new System.Drawing.Point(42, 66);
      this.hli3.MaximumLevel = 30F;
      this.hli3.Name = "hli3";
      this.hli3.Size = new System.Drawing.Size(100, 23);
      this.hli3.TabIndex = 12;
      this.hli3.Text = "30";
      this.hli3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli4
      // 
      this.hli4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli4.Level = 30F;
      this.hli4.Location = new System.Drawing.Point(42, 89);
      this.hli4.MaximumLevel = 30F;
      this.hli4.Name = "hli4";
      this.hli4.Size = new System.Drawing.Size(100, 23);
      this.hli4.TabIndex = 13;
      this.hli4.Text = "30";
      this.hli4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli5
      // 
      this.hli5.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli5.Level = 30F;
      this.hli5.Location = new System.Drawing.Point(42, 112);
      this.hli5.MaximumLevel = 30F;
      this.hli5.Name = "hli5";
      this.hli5.Size = new System.Drawing.Size(100, 23);
      this.hli5.TabIndex = 14;
      this.hli5.Text = "30";
      this.hli5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli6
      // 
      this.hli6.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli6.Level = 30F;
      this.hli6.Location = new System.Drawing.Point(148, 20);
      this.hli6.MaximumLevel = 30F;
      this.hli6.Name = "hli6";
      this.hli6.Size = new System.Drawing.Size(100, 23);
      this.hli6.TabIndex = 15;
      this.hli6.Text = "30";
      this.hli6.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli7
      // 
      this.hli7.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli7.Level = 30F;
      this.hli7.Location = new System.Drawing.Point(148, 43);
      this.hli7.MaximumLevel = 30F;
      this.hli7.Name = "hli7";
      this.hli7.Size = new System.Drawing.Size(100, 23);
      this.hli7.TabIndex = 16;
      this.hli7.Text = "30";
      this.hli7.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli8
      // 
      this.hli8.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli8.Level = 30F;
      this.hli8.Location = new System.Drawing.Point(148, 66);
      this.hli8.MaximumLevel = 30F;
      this.hli8.Name = "hli8";
      this.hli8.Size = new System.Drawing.Size(100, 23);
      this.hli8.TabIndex = 17;
      this.hli8.Text = "30";
      this.hli8.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli9
      // 
      this.hli9.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli9.Level = 30F;
      this.hli9.Location = new System.Drawing.Point(148, 89);
      this.hli9.MaximumLevel = 30F;
      this.hli9.Name = "hli9";
      this.hli9.Size = new System.Drawing.Size(100, 23);
      this.hli9.TabIndex = 18;
      this.hli9.Text = "30";
      this.hli9.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli10
      // 
      this.hli10.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli10.Level = 30F;
      this.hli10.Location = new System.Drawing.Point(148, 112);
      this.hli10.MaximumLevel = 30F;
      this.hli10.Name = "hli10";
      this.hli10.Size = new System.Drawing.Size(100, 23);
      this.hli10.TabIndex = 19;
      this.hli10.Text = "30";
      this.hli10.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli11
      // 
      this.hli11.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli11.Level = 30F;
      this.hli11.Location = new System.Drawing.Point(254, 20);
      this.hli11.MaximumLevel = 30F;
      this.hli11.Name = "hli11";
      this.hli11.Size = new System.Drawing.Size(100, 23);
      this.hli11.TabIndex = 20;
      this.hli11.Text = "30";
      this.hli11.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli12
      // 
      this.hli12.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli12.Level = 30F;
      this.hli12.Location = new System.Drawing.Point(254, 43);
      this.hli12.MaximumLevel = 30F;
      this.hli12.Name = "hli12";
      this.hli12.Size = new System.Drawing.Size(100, 23);
      this.hli12.TabIndex = 21;
      this.hli12.Text = "30";
      this.hli12.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli13
      // 
      this.hli13.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli13.Level = 30F;
      this.hli13.Location = new System.Drawing.Point(254, 66);
      this.hli13.MaximumLevel = 30F;
      this.hli13.Name = "hli13";
      this.hli13.Size = new System.Drawing.Size(100, 23);
      this.hli13.TabIndex = 22;
      this.hli13.Text = "30";
      this.hli13.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli14
      // 
      this.hli14.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli14.Level = 30F;
      this.hli14.Location = new System.Drawing.Point(254, 89);
      this.hli14.MaximumLevel = 30F;
      this.hli14.Name = "hli14";
      this.hli14.Size = new System.Drawing.Size(100, 23);
      this.hli14.TabIndex = 23;
      this.hli14.Text = "30";
      this.hli14.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli15
      // 
      this.hli15.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli15.Level = 30F;
      this.hli15.Location = new System.Drawing.Point(254, 112);
      this.hli15.MaximumLevel = 30F;
      this.hli15.Name = "hli15";
      this.hli15.Size = new System.Drawing.Size(100, 23);
      this.hli15.TabIndex = 24;
      this.hli15.Text = "30";
      this.hli15.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli16
      // 
      this.hli16.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli16.Level = 30F;
      this.hli16.Location = new System.Drawing.Point(360, 20);
      this.hli16.MaximumLevel = 30F;
      this.hli16.Name = "hli16";
      this.hli16.Size = new System.Drawing.Size(100, 23);
      this.hli16.TabIndex = 25;
      this.hli16.Text = "30";
      this.hli16.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli17
      // 
      this.hli17.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli17.Level = 30F;
      this.hli17.Location = new System.Drawing.Point(360, 43);
      this.hli17.MaximumLevel = 30F;
      this.hli17.Name = "hli17";
      this.hli17.Size = new System.Drawing.Size(100, 23);
      this.hli17.TabIndex = 26;
      this.hli17.Text = "30";
      this.hli17.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli18
      // 
      this.hli18.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli18.Level = 30F;
      this.hli18.Location = new System.Drawing.Point(360, 66);
      this.hli18.MaximumLevel = 30F;
      this.hli18.Name = "hli18";
      this.hli18.Size = new System.Drawing.Size(100, 23);
      this.hli18.TabIndex = 27;
      this.hli18.Text = "30";
      this.hli18.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli19
      // 
      this.hli19.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli19.Level = 30F;
      this.hli19.Location = new System.Drawing.Point(360, 89);
      this.hli19.MaximumLevel = 30F;
      this.hli19.Name = "hli19";
      this.hli19.Size = new System.Drawing.Size(100, 23);
      this.hli19.TabIndex = 28;
      this.hli19.Text = "30";
      this.hli19.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli20
      // 
      this.hli20.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli20.Level = 30F;
      this.hli20.Location = new System.Drawing.Point(360, 112);
      this.hli20.MaximumLevel = 30F;
      this.hli20.Name = "hli20";
      this.hli20.Size = new System.Drawing.Size(100, 23);
      this.hli20.TabIndex = 29;
      this.hli20.Text = "30";
      this.hli20.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli21
      // 
      this.hli21.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli21.Level = 30F;
      this.hli21.Location = new System.Drawing.Point(466, 20);
      this.hli21.MaximumLevel = 30F;
      this.hli21.Name = "hli21";
      this.hli21.Size = new System.Drawing.Size(100, 23);
      this.hli21.TabIndex = 30;
      this.hli21.Text = "30";
      this.hli21.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli22
      // 
      this.hli22.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli22.Level = 30F;
      this.hli22.Location = new System.Drawing.Point(466, 43);
      this.hli22.MaximumLevel = 30F;
      this.hli22.Name = "hli22";
      this.hli22.Size = new System.Drawing.Size(100, 23);
      this.hli22.TabIndex = 31;
      this.hli22.Text = "30";
      this.hli22.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli23
      // 
      this.hli23.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli23.Level = 30F;
      this.hli23.Location = new System.Drawing.Point(466, 66);
      this.hli23.MaximumLevel = 30F;
      this.hli23.Name = "hli23";
      this.hli23.Size = new System.Drawing.Size(100, 23);
      this.hli23.TabIndex = 32;
      this.hli23.Text = "30";
      this.hli23.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli24
      // 
      this.hli24.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli24.Level = 30F;
      this.hli24.Location = new System.Drawing.Point(466, 89);
      this.hli24.MaximumLevel = 30F;
      this.hli24.Name = "hli24";
      this.hli24.Size = new System.Drawing.Size(100, 23);
      this.hli24.TabIndex = 33;
      this.hli24.Text = "30";
      this.hli24.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli25
      // 
      this.hli25.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli25.Level = 30F;
      this.hli25.Location = new System.Drawing.Point(466, 112);
      this.hli25.MaximumLevel = 30F;
      this.hli25.Name = "hli25";
      this.hli25.Size = new System.Drawing.Size(100, 23);
      this.hli25.TabIndex = 34;
      this.hli25.Text = "30";
      this.hli25.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label11.ForeColor = System.Drawing.Color.White;
      this.label11.Location = new System.Drawing.Point(572, 0);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(75, 13);
      this.label11.TabIndex = 35;
      this.label11.Text = "Age / Value";
      this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // hli26
      // 
      this.hli26.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli26.Level = 1F;
      this.hli26.Location = new System.Drawing.Point(572, 20);
      this.hli26.MaximumLevel = 2F;
      this.hli26.Name = "hli26";
      this.hli26.Size = new System.Drawing.Size(106, 23);
      this.hli26.TabIndex = 36;
      this.hli26.Text = " 1";
      this.hli26.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli27
      // 
      this.hli27.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli27.Level = 1F;
      this.hli27.Location = new System.Drawing.Point(572, 43);
      this.hli27.MaximumLevel = 2F;
      this.hli27.Name = "hli27";
      this.hli27.Size = new System.Drawing.Size(106, 23);
      this.hli27.TabIndex = 37;
      this.hli27.Text = " 1";
      this.hli27.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli28
      // 
      this.hli28.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli28.Level = 1F;
      this.hli28.Location = new System.Drawing.Point(572, 66);
      this.hli28.MaximumLevel = 2F;
      this.hli28.Name = "hli28";
      this.hli28.Size = new System.Drawing.Size(106, 23);
      this.hli28.TabIndex = 38;
      this.hli28.Text = " 1";
      this.hli28.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli29
      // 
      this.hli29.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli29.Level = 1F;
      this.hli29.Location = new System.Drawing.Point(572, 89);
      this.hli29.MaximumLevel = 2F;
      this.hli29.Name = "hli29";
      this.hli29.Size = new System.Drawing.Size(106, 23);
      this.hli29.TabIndex = 39;
      this.hli29.Text = " 1";
      this.hli29.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hli30
      // 
      this.hli30.Dock = System.Windows.Forms.DockStyle.Fill;
      this.hli30.Level = 1F;
      this.hli30.Location = new System.Drawing.Point(572, 112);
      this.hli30.MaximumLevel = 2F;
      this.hli30.Name = "hli30";
      this.hli30.Size = new System.Drawing.Size(106, 23);
      this.hli30.TabIndex = 40;
      this.hli30.Text = " 1";
      this.hli30.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // EvaluatePlayerUserControl
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.BackColor = System.Drawing.Color.DimGray;
      this.CausesValidation = false;
      this.Controls.Add(this.tlp);
      this.DoubleBuffered = true;
      this.ForeColor = System.Drawing.Color.White;
      this.Name = "EvaluatePlayerUserControl";
      this.Size = new System.Drawing.Size(681, 135);
      this.Load += new System.EventHandler(this.EvaluatePlayerUserControl_Load);
      this.tlp.ResumeLayout(false);
      this.tlp.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    #region controls
    private System.Windows.Forms.TableLayoutPanel tlp;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label10;
    private HorizontalLevelIndicatorLabel hli1;
    private HorizontalLevelIndicatorLabel hli2;
    private HorizontalLevelIndicatorLabel hli3;
    private HorizontalLevelIndicatorLabel hli4;
    private HorizontalLevelIndicatorLabel hli5;
    private HorizontalLevelIndicatorLabel hli6;
    private HorizontalLevelIndicatorLabel hli7;
    private HorizontalLevelIndicatorLabel hli8;
    private HorizontalLevelIndicatorLabel hli9;
    private HorizontalLevelIndicatorLabel hli10;
    private HorizontalLevelIndicatorLabel hli11;
    private HorizontalLevelIndicatorLabel hli12;
    private HorizontalLevelIndicatorLabel hli13;
    private HorizontalLevelIndicatorLabel hli14;
    private HorizontalLevelIndicatorLabel hli15;
    private HorizontalLevelIndicatorLabel hli16;
    private HorizontalLevelIndicatorLabel hli17;
    private HorizontalLevelIndicatorLabel hli18;
    private HorizontalLevelIndicatorLabel hli19;
    private HorizontalLevelIndicatorLabel hli20;
    private HorizontalLevelIndicatorLabel hli21;
    private HorizontalLevelIndicatorLabel hli22;
    private HorizontalLevelIndicatorLabel hli23;
    private HorizontalLevelIndicatorLabel hli24;
    private HorizontalLevelIndicatorLabel hli25;
    private System.Windows.Forms.Label label11;
    private HorizontalLevelIndicatorLabel hli26;
    private HorizontalLevelIndicatorLabel hli27;
    private HorizontalLevelIndicatorLabel hli28;
    private HorizontalLevelIndicatorLabel hli29;
    private HorizontalLevelIndicatorLabel hli30; 
    #endregion
  
    public EvaluatePlayerUserControl ( )
    {
      InitializeComponent();
    }

    private void EvaluatePlayerUserControl_Load (object sender, EventArgs e)
    {
      foreach (var child in this.tlp.Controls)
      {
        var hli = child as HorizontalLevelIndicatorLabel;
        if (hli != null)
        {
          hli.Level = 0;
          hli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }
      }
      this.tlp.Enabled = false;
      //this.tlp.Visible = false;
    }

    PG _pg = null;
    SG _sg = null;
    SF _sf = null;
    PF _pf = null;
    C _c = null;


     Xsd2.charazayPlayer _p = null;
    public Xsd2.charazayPlayer SelectedObject 
   
    { 
      get { return _p; } 
      set 
      {
        if (value == null || value.skills == null) return;
        _p = value; 
        if (_p == null) return;
        _pg = new PG(_p);
        _sg = new SG(_p);
        _sf = new SF(_p);
        _pf = new PF(_p);
        _c = new C(_p);
        //
        if (!this.tlp.Enabled) this.tlp.Enabled = true;
        this.SuspendLayout();
        //
        assignLabelValues();
        //
        this.ResumeLayout();
      } 
    }

    private void assignLabelValues ( )
    {
      //
      assignValue(hli1, _pg.DefensiveScore);
      assignValue(hli2, _sg.DefensiveScore);
      assignValue(hli3, _sf.DefensiveScore);
      assignValue(hli4, _pf.DefensiveScore);
      assignValue(hli5, _c.DefensiveScore);
      //
      assignValue(hli6, _pg.OffensiveAbilityScore);
      assignValue(hli7, _sg.OffensiveAbilityScore);
      assignValue(hli8, _sf.OffensiveAbilityScore);
      assignValue(hli9, _pf.OffensiveAbilityScore);
      assignValue(hli10, _c.OffensiveAbilityScore);
      //
      assignValue(hli11, _pg.ShootingScore);
      assignValue(hli12, _sg.ShootingScore);
      assignValue(hli13, _sf.ShootingScore);
      assignValue(hli14, _pf.ShootingScore);
      assignValue(hli15, _c.ShootingScore);
      //
      assignValue(hli16, _pg.OffensiveScore);
      assignValue(hli17, _sg.OffensiveScore);
      assignValue(hli18, _sf.OffensiveScore);
      assignValue(hli19, _pf.OffensiveScore);
      assignValue(hli20, _c.OffensiveScore);
      //
      assignValue(hli21, _pg.TotalScore);
      assignValue(hli22, _sg.TotalScore);
      assignValue(hli23, _sf.TotalScore);
      assignValue(hli24, _pf.TotalScore);
      assignValue(hli25, _c.TotalScore);
      //
      assignValueIndex(hli26, _pg);
      assignValueIndex(hli27, _sg);
      assignValueIndex(hli28, _sf);
      assignValueIndex(hli29, _pf);
      assignValueIndex(hli30, _c);
    }

    private void assignValueIndex (HorizontalLevelIndicatorLabel hli, Player p)
    {
      hli.MaximumLevel = 2f;
      hli.Level = (float)Math.Round(p.ValueIndex, 2);      
    }

    void assignValue (HorizontalLevelIndicatorLabel hli, double val)
    {
      hli.Level = (float)Math.Round(val, 2);
    }

    internal Player GetPlayer (PlayerPosition pos)
    {
      switch (pos)
      {
        case PlayerPosition.C: return _c;
        case PlayerPosition.PF: return _pf;
        case PlayerPosition.SF: return _sf;
        case PlayerPosition.SG: return _sg;
        case PlayerPosition.PG: return _pg;
        default: return null;
      }
    }
  }
}
