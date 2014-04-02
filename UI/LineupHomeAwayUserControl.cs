

namespace AndreiPopescu.CharazayPlus.UI
{
  using System.Windows.Forms;
  using AndreiPopescu.CharazayPlus.Utils;
  using System.Drawing;
  using System.ComponentModel;

  public partial class LineupHomeAwayUserControl : UserControl
  {
    #region control members
    private TableLayoutPanel tableLayoutPanelLineup;
    private Label lblQ2;
    private Label lblQ3;
    private Label lblQ1;
    private Label labelPG;
    private Label labelSG;
    private Label labelSF;
    private Label labelPF;
    private Label labelC;
    private Label pgh1;
    private Label pgh2;
    private Label pgh3;
    private Label pgh4;
    private Label pga1;
    private Label pga2;
    private Label pga3;
    private Label pga4;
    private Label sgh1;
    private Label sgh2;
    private Label sgh3;
    private Label sgh4;
    private Label sga1;
    private Label sga2;
    private Label sga3;
    private Label sga4;
    private Label sfh1;
    private Label sfh2;
    private Label sfh3;
    private Label sfh4;
    private Label sfa1;
    private Label sfa2;
    private Label sfa3;
    private Label sfa4;
    private Label pfh1;
    private Label pfh2;
    private Label pfh3;
    private Label pfh4;
    private Label pfa1;
    private Label pfa2;
    private Label pfa3;
    private Label pfa4;
    private Label ch1;
    private Label ch2;
    private Label ch3;
    private Label ch4;
    private Label ca1;
    private Label ca2;
    private Label ca3;
    private Label ca4;
    private Label lblQ4; 
    #endregion
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
      this.tableLayoutPanelLineup = new System.Windows.Forms.TableLayoutPanel();
      this.lblQ2 = new System.Windows.Forms.Label();
      this.lblQ3 = new System.Windows.Forms.Label();
      this.lblQ1 = new System.Windows.Forms.Label();
      this.labelPG = new System.Windows.Forms.Label();
      this.labelSG = new System.Windows.Forms.Label();
      this.labelSF = new System.Windows.Forms.Label();
      this.labelPF = new System.Windows.Forms.Label();
      this.labelC = new System.Windows.Forms.Label();
      this.pgh1 = new System.Windows.Forms.Label();
      this.pgh2 = new System.Windows.Forms.Label();
      this.pgh3 = new System.Windows.Forms.Label();
      this.pgh4 = new System.Windows.Forms.Label();
      this.pga1 = new System.Windows.Forms.Label();
      this.pga2 = new System.Windows.Forms.Label();
      this.pga3 = new System.Windows.Forms.Label();
      this.pga4 = new System.Windows.Forms.Label();
      this.sgh1 = new System.Windows.Forms.Label();
      this.sgh2 = new System.Windows.Forms.Label();
      this.sgh3 = new System.Windows.Forms.Label();
      this.sgh4 = new System.Windows.Forms.Label();
      this.sga1 = new System.Windows.Forms.Label();
      this.sga2 = new System.Windows.Forms.Label();
      this.sga3 = new System.Windows.Forms.Label();
      this.sga4 = new System.Windows.Forms.Label();
      this.sfh1 = new System.Windows.Forms.Label();
      this.sfh2 = new System.Windows.Forms.Label();
      this.sfh3 = new System.Windows.Forms.Label();
      this.sfh4 = new System.Windows.Forms.Label();
      this.sfa1 = new System.Windows.Forms.Label();
      this.sfa2 = new System.Windows.Forms.Label();
      this.sfa3 = new System.Windows.Forms.Label();
      this.sfa4 = new System.Windows.Forms.Label();
      this.pfh1 = new System.Windows.Forms.Label();
      this.pfh2 = new System.Windows.Forms.Label();
      this.pfh3 = new System.Windows.Forms.Label();
      this.pfh4 = new System.Windows.Forms.Label();
      this.pfa1 = new System.Windows.Forms.Label();
      this.pfa2 = new System.Windows.Forms.Label();
      this.pfa3 = new System.Windows.Forms.Label();
      this.pfa4 = new System.Windows.Forms.Label();
      this.ch1 = new System.Windows.Forms.Label();
      this.ch2 = new System.Windows.Forms.Label();
      this.ch3 = new System.Windows.Forms.Label();
      this.ch4 = new System.Windows.Forms.Label();
      this.ca1 = new System.Windows.Forms.Label();
      this.ca2 = new System.Windows.Forms.Label();
      this.ca3 = new System.Windows.Forms.Label();
      this.ca4 = new System.Windows.Forms.Label();
      this.lblQ4 = new System.Windows.Forms.Label();
      this.tableLayoutPanelLineup.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanelLineup
      // 
      this.tableLayoutPanelLineup.AutoSize = true;
      this.tableLayoutPanelLineup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tableLayoutPanelLineup.ColumnCount = 5;
      this.tableLayoutPanelLineup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
      this.tableLayoutPanelLineup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanelLineup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanelLineup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanelLineup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanelLineup.Controls.Add(this.lblQ2, 2, 10);
      this.tableLayoutPanelLineup.Controls.Add(this.lblQ3, 3, 10);
      this.tableLayoutPanelLineup.Controls.Add(this.lblQ1, 1, 10);
      this.tableLayoutPanelLineup.Controls.Add(this.labelPG, 0, 0);
      this.tableLayoutPanelLineup.Controls.Add(this.labelSG, 0, 2);
      this.tableLayoutPanelLineup.Controls.Add(this.labelSF, 0, 4);
      this.tableLayoutPanelLineup.Controls.Add(this.labelPF, 0, 6);
      this.tableLayoutPanelLineup.Controls.Add(this.labelC, 0, 8);
      this.tableLayoutPanelLineup.Controls.Add(this.pgh1, 1, 0);
      this.tableLayoutPanelLineup.Controls.Add(this.pgh2, 2, 0);
      this.tableLayoutPanelLineup.Controls.Add(this.pgh3, 3, 0);
      this.tableLayoutPanelLineup.Controls.Add(this.pgh4, 4, 0);
      this.tableLayoutPanelLineup.Controls.Add(this.pga1, 1, 1);
      this.tableLayoutPanelLineup.Controls.Add(this.pga2, 2, 1);
      this.tableLayoutPanelLineup.Controls.Add(this.pga3, 3, 1);
      this.tableLayoutPanelLineup.Controls.Add(this.pga4, 4, 1);
      this.tableLayoutPanelLineup.Controls.Add(this.sgh1, 1, 2);
      this.tableLayoutPanelLineup.Controls.Add(this.sgh2, 2, 2);
      this.tableLayoutPanelLineup.Controls.Add(this.sgh3, 3, 2);
      this.tableLayoutPanelLineup.Controls.Add(this.sgh4, 4, 2);
      this.tableLayoutPanelLineup.Controls.Add(this.sga1, 1, 3);
      this.tableLayoutPanelLineup.Controls.Add(this.sga2, 2, 3);
      this.tableLayoutPanelLineup.Controls.Add(this.sga3, 3, 3);
      this.tableLayoutPanelLineup.Controls.Add(this.sga4, 4, 3);
      this.tableLayoutPanelLineup.Controls.Add(this.sfh1, 1, 4);
      this.tableLayoutPanelLineup.Controls.Add(this.sfh2, 2, 4);
      this.tableLayoutPanelLineup.Controls.Add(this.sfh3, 3, 4);
      this.tableLayoutPanelLineup.Controls.Add(this.sfh4, 4, 4);
      this.tableLayoutPanelLineup.Controls.Add(this.sfa1, 1, 5);
      this.tableLayoutPanelLineup.Controls.Add(this.sfa2, 2, 5);
      this.tableLayoutPanelLineup.Controls.Add(this.sfa3, 3, 5);
      this.tableLayoutPanelLineup.Controls.Add(this.sfa4, 4, 5);
      this.tableLayoutPanelLineup.Controls.Add(this.pfh1, 1, 6);
      this.tableLayoutPanelLineup.Controls.Add(this.pfh2, 2, 6);
      this.tableLayoutPanelLineup.Controls.Add(this.pfh3, 3, 6);
      this.tableLayoutPanelLineup.Controls.Add(this.pfh4, 4, 6);
      this.tableLayoutPanelLineup.Controls.Add(this.pfa1, 1, 7);
      this.tableLayoutPanelLineup.Controls.Add(this.pfa2, 2, 7);
      this.tableLayoutPanelLineup.Controls.Add(this.pfa3, 3, 7);
      this.tableLayoutPanelLineup.Controls.Add(this.pfa4, 4, 7);
      this.tableLayoutPanelLineup.Controls.Add(this.ch1, 1, 8);
      this.tableLayoutPanelLineup.Controls.Add(this.ch2, 2, 8);
      this.tableLayoutPanelLineup.Controls.Add(this.ch3, 3, 8);
      this.tableLayoutPanelLineup.Controls.Add(this.ch4, 4, 8);
      this.tableLayoutPanelLineup.Controls.Add(this.ca1, 1, 9);
      this.tableLayoutPanelLineup.Controls.Add(this.ca2, 2, 9);
      this.tableLayoutPanelLineup.Controls.Add(this.ca3, 3, 9);
      this.tableLayoutPanelLineup.Controls.Add(this.ca4, 4, 9);
      this.tableLayoutPanelLineup.Controls.Add(this.lblQ4, 4, 10);
      this.tableLayoutPanelLineup.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanelLineup.Name = "tableLayoutPanelLineup";
      this.tableLayoutPanelLineup.RowCount = 11;
      this.tableLayoutPanelLineup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tableLayoutPanelLineup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tableLayoutPanelLineup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tableLayoutPanelLineup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tableLayoutPanelLineup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tableLayoutPanelLineup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tableLayoutPanelLineup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tableLayoutPanelLineup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tableLayoutPanelLineup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tableLayoutPanelLineup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tableLayoutPanelLineup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanelLineup.Size = new System.Drawing.Size(455, 250);
      this.tableLayoutPanelLineup.TabIndex = 5;
      // 
      // lblQ2
      // 
      this.lblQ2.AutoSize = true;
      this.lblQ2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblQ2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblQ2.Location = new System.Drawing.Point(140, 230);
      this.lblQ2.Name = "lblQ2";
      this.lblQ2.Size = new System.Drawing.Size(100, 20);
      this.lblQ2.TabIndex = 1;
      this.lblQ2.Text = "2nd quarter";
      // 
      // lblQ3
      // 
      this.lblQ3.AutoSize = true;
      this.lblQ3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblQ3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblQ3.Location = new System.Drawing.Point(246, 230);
      this.lblQ3.Name = "lblQ3";
      this.lblQ3.Size = new System.Drawing.Size(100, 20);
      this.lblQ3.TabIndex = 2;
      this.lblQ3.Text = "3rd Quarter";
      // 
      // lblQ1
      // 
      this.lblQ1.AutoSize = true;
      this.lblQ1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblQ1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblQ1.Location = new System.Drawing.Point(34, 230);
      this.lblQ1.Name = "lblQ1";
      this.lblQ1.Size = new System.Drawing.Size(100, 20);
      this.lblQ1.TabIndex = 0;
      this.lblQ1.Text = "1st Quarter";
      // 
      // labelPG
      // 
      this.labelPG.AutoSize = true;
      this.labelPG.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelPG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelPG.Location = new System.Drawing.Point(3, 0);
      this.labelPG.Name = "labelPG";
      this.tableLayoutPanelLineup.SetRowSpan(this.labelPG, 2);
      this.labelPG.Size = new System.Drawing.Size(25, 46);
      this.labelPG.TabIndex = 4;
      this.labelPG.Text = "PG";
      this.labelPG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // labelSG
      // 
      this.labelSG.AutoSize = true;
      this.labelSG.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelSG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelSG.Location = new System.Drawing.Point(3, 46);
      this.labelSG.Name = "labelSG";
      this.tableLayoutPanelLineup.SetRowSpan(this.labelSG, 2);
      this.labelSG.Size = new System.Drawing.Size(25, 46);
      this.labelSG.TabIndex = 5;
      this.labelSG.Text = "SG";
      this.labelSG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // labelSF
      // 
      this.labelSF.AutoSize = true;
      this.labelSF.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelSF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelSF.Location = new System.Drawing.Point(3, 92);
      this.labelSF.Name = "labelSF";
      this.tableLayoutPanelLineup.SetRowSpan(this.labelSF, 2);
      this.labelSF.Size = new System.Drawing.Size(25, 46);
      this.labelSF.TabIndex = 6;
      this.labelSF.Text = "SF";
      this.labelSF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // labelPF
      // 
      this.labelPF.AutoSize = true;
      this.labelPF.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelPF.Location = new System.Drawing.Point(3, 138);
      this.labelPF.Name = "labelPF";
      this.tableLayoutPanelLineup.SetRowSpan(this.labelPF, 2);
      this.labelPF.Size = new System.Drawing.Size(25, 46);
      this.labelPF.TabIndex = 7;
      this.labelPF.Text = "PF";
      this.labelPF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // labelC
      // 
      this.labelC.AutoSize = true;
      this.labelC.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelC.Location = new System.Drawing.Point(3, 184);
      this.labelC.Name = "labelC";
      this.tableLayoutPanelLineup.SetRowSpan(this.labelC, 2);
      this.labelC.Size = new System.Drawing.Size(25, 46);
      this.labelC.TabIndex = 8;
      this.labelC.Text = "C";
      this.labelC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // pgh1
      // 
      this.pgh1.Location = new System.Drawing.Point(34, 0);
      this.pgh1.Name = "pgh1";
      this.pgh1.Size = new System.Drawing.Size(100, 23);
      this.pgh1.TabIndex = 9;
      // 
      // pgh2
      // 
      this.pgh2.Location = new System.Drawing.Point(140, 0);
      this.pgh2.Name = "pgh2";
      this.pgh2.Size = new System.Drawing.Size(100, 23);
      this.pgh2.TabIndex = 10;
      // 
      // pgh3
      // 
      this.pgh3.Location = new System.Drawing.Point(246, 0);
      this.pgh3.Name = "pgh3";
      this.pgh3.Size = new System.Drawing.Size(100, 23);
      this.pgh3.TabIndex = 11;
      // 
      // pgh4
      // 
      this.pgh4.Location = new System.Drawing.Point(352, 0);
      this.pgh4.Name = "pgh4";
      this.pgh4.Size = new System.Drawing.Size(100, 23);
      this.pgh4.TabIndex = 12;
      // 
      // pga1
      // 
      this.pga1.Location = new System.Drawing.Point(34, 23);
      this.pga1.Name = "pga1";
      this.pga1.Size = new System.Drawing.Size(100, 23);
      this.pga1.TabIndex = 13;
      // 
      // pga2
      // 
      this.pga2.Location = new System.Drawing.Point(140, 23);
      this.pga2.Name = "pga2";
      this.pga2.Size = new System.Drawing.Size(100, 23);
      this.pga2.TabIndex = 14;
      // 
      // pga3
      // 
      this.pga3.Location = new System.Drawing.Point(246, 23);
      this.pga3.Name = "pga3";
      this.pga3.Size = new System.Drawing.Size(100, 23);
      this.pga3.TabIndex = 15;
      // 
      // pga4
      // 
      this.pga4.Location = new System.Drawing.Point(352, 23);
      this.pga4.Name = "pga4";
      this.pga4.Size = new System.Drawing.Size(100, 23);
      this.pga4.TabIndex = 16;
      // 
      // sgh1
      // 
      this.sgh1.Location = new System.Drawing.Point(34, 46);
      this.sgh1.Name = "sgh1";
      this.sgh1.Size = new System.Drawing.Size(100, 23);
      this.sgh1.TabIndex = 17;
      // 
      // sgh2
      // 
      this.sgh2.Location = new System.Drawing.Point(140, 46);
      this.sgh2.Name = "sgh2";
      this.sgh2.Size = new System.Drawing.Size(100, 23);
      this.sgh2.TabIndex = 18;
      // 
      // sgh3
      // 
      this.sgh3.Location = new System.Drawing.Point(246, 46);
      this.sgh3.Name = "sgh3";
      this.sgh3.Size = new System.Drawing.Size(100, 23);
      this.sgh3.TabIndex = 19;
      // 
      // sgh4
      // 
      this.sgh4.Location = new System.Drawing.Point(352, 46);
      this.sgh4.Name = "sgh4";
      this.sgh4.Size = new System.Drawing.Size(100, 23);
      this.sgh4.TabIndex = 20;
      // 
      // sga1
      // 
      this.sga1.Location = new System.Drawing.Point(34, 69);
      this.sga1.Name = "sga1";
      this.sga1.Size = new System.Drawing.Size(100, 23);
      this.sga1.TabIndex = 21;
      // 
      // sga2
      // 
      this.sga2.Location = new System.Drawing.Point(140, 69);
      this.sga2.Name = "sga2";
      this.sga2.Size = new System.Drawing.Size(100, 23);
      this.sga2.TabIndex = 22;
      // 
      // sga3
      // 
      this.sga3.Location = new System.Drawing.Point(246, 69);
      this.sga3.Name = "sga3";
      this.sga3.Size = new System.Drawing.Size(100, 23);
      this.sga3.TabIndex = 23;
      // 
      // sga4
      // 
      this.sga4.Location = new System.Drawing.Point(352, 69);
      this.sga4.Name = "sga4";
      this.sga4.Size = new System.Drawing.Size(100, 23);
      this.sga4.TabIndex = 24;
      // 
      // sfh1
      // 
      this.sfh1.Location = new System.Drawing.Point(34, 92);
      this.sfh1.Name = "sfh1";
      this.sfh1.Size = new System.Drawing.Size(100, 23);
      this.sfh1.TabIndex = 25;
      // 
      // sfh2
      // 
      this.sfh2.Location = new System.Drawing.Point(140, 92);
      this.sfh2.Name = "sfh2";
      this.sfh2.Size = new System.Drawing.Size(100, 23);
      this.sfh2.TabIndex = 26;
      // 
      // sfh3
      // 
      this.sfh3.Location = new System.Drawing.Point(246, 92);
      this.sfh3.Name = "sfh3";
      this.sfh3.Size = new System.Drawing.Size(100, 23);
      this.sfh3.TabIndex = 27;
      // 
      // sfh4
      // 
      this.sfh4.Location = new System.Drawing.Point(352, 92);
      this.sfh4.Name = "sfh4";
      this.sfh4.Size = new System.Drawing.Size(100, 23);
      this.sfh4.TabIndex = 28;
      // 
      // sfa1
      // 
      this.sfa1.Location = new System.Drawing.Point(34, 115);
      this.sfa1.Name = "sfa1";
      this.sfa1.Size = new System.Drawing.Size(100, 23);
      this.sfa1.TabIndex = 29;
      // 
      // sfa2
      // 
      this.sfa2.Location = new System.Drawing.Point(140, 115);
      this.sfa2.Name = "sfa2";
      this.sfa2.Size = new System.Drawing.Size(100, 23);
      this.sfa2.TabIndex = 30;
      // 
      // sfa3
      // 
      this.sfa3.Location = new System.Drawing.Point(246, 115);
      this.sfa3.Name = "sfa3";
      this.sfa3.Size = new System.Drawing.Size(100, 23);
      this.sfa3.TabIndex = 31;
      // 
      // sfa4
      // 
      this.sfa4.Location = new System.Drawing.Point(352, 115);
      this.sfa4.Name = "sfa4";
      this.sfa4.Size = new System.Drawing.Size(100, 23);
      this.sfa4.TabIndex = 32;
      // 
      // pfh1
      // 
      this.pfh1.Location = new System.Drawing.Point(34, 138);
      this.pfh1.Name = "pfh1";
      this.pfh1.Size = new System.Drawing.Size(100, 23);
      this.pfh1.TabIndex = 33;
      // 
      // pfh2
      // 
      this.pfh2.Location = new System.Drawing.Point(140, 138);
      this.pfh2.Name = "pfh2";
      this.pfh2.Size = new System.Drawing.Size(100, 23);
      this.pfh2.TabIndex = 34;
      // 
      // pfh3
      // 
      this.pfh3.Location = new System.Drawing.Point(246, 138);
      this.pfh3.Name = "pfh3";
      this.pfh3.Size = new System.Drawing.Size(100, 23);
      this.pfh3.TabIndex = 35;
      // 
      // pfh4
      // 
      this.pfh4.Location = new System.Drawing.Point(352, 138);
      this.pfh4.Name = "pfh4";
      this.pfh4.Size = new System.Drawing.Size(100, 23);
      this.pfh4.TabIndex = 36;
      // 
      // pfa1
      // 
      this.pfa1.Location = new System.Drawing.Point(34, 161);
      this.pfa1.Name = "pfa1";
      this.pfa1.Size = new System.Drawing.Size(100, 23);
      this.pfa1.TabIndex = 37;
      // 
      // pfa2
      // 
      this.pfa2.Location = new System.Drawing.Point(140, 161);
      this.pfa2.Name = "pfa2";
      this.pfa2.Size = new System.Drawing.Size(100, 23);
      this.pfa2.TabIndex = 38;
      // 
      // pfa3
      // 
      this.pfa3.Location = new System.Drawing.Point(246, 161);
      this.pfa3.Name = "pfa3";
      this.pfa3.Size = new System.Drawing.Size(100, 23);
      this.pfa3.TabIndex = 39;
      // 
      // pfa4
      // 
      this.pfa4.Location = new System.Drawing.Point(352, 161);
      this.pfa4.Name = "pfa4";
      this.pfa4.Size = new System.Drawing.Size(100, 23);
      this.pfa4.TabIndex = 40;
      // 
      // ch1
      // 
      this.ch1.Location = new System.Drawing.Point(34, 184);
      this.ch1.Name = "ch1";
      this.ch1.Size = new System.Drawing.Size(100, 23);
      this.ch1.TabIndex = 41;
      // 
      // ch2
      // 
      this.ch2.Location = new System.Drawing.Point(140, 184);
      this.ch2.Name = "ch2";
      this.ch2.Size = new System.Drawing.Size(100, 23);
      this.ch2.TabIndex = 42;
      // 
      // ch3
      // 
      this.ch3.Location = new System.Drawing.Point(246, 184);
      this.ch3.Name = "ch3";
      this.ch3.Size = new System.Drawing.Size(100, 23);
      this.ch3.TabIndex = 43;
      // 
      // ch4
      // 
      this.ch4.Location = new System.Drawing.Point(352, 184);
      this.ch4.Name = "ch4";
      this.ch4.Size = new System.Drawing.Size(100, 23);
      this.ch4.TabIndex = 44;
      // 
      // ca1
      // 
      this.ca1.Location = new System.Drawing.Point(34, 207);
      this.ca1.Name = "ca1";
      this.ca1.Size = new System.Drawing.Size(100, 23);
      this.ca1.TabIndex = 45;
      // 
      // ca2
      // 
      this.ca2.Location = new System.Drawing.Point(140, 207);
      this.ca2.Name = "ca2";
      this.ca2.Size = new System.Drawing.Size(100, 23);
      this.ca2.TabIndex = 46;
      // 
      // ca3
      // 
      this.ca3.Location = new System.Drawing.Point(246, 207);
      this.ca3.Name = "ca3";
      this.ca3.Size = new System.Drawing.Size(100, 23);
      this.ca3.TabIndex = 47;
      // 
      // ca4
      // 
      this.ca4.Location = new System.Drawing.Point(352, 207);
      this.ca4.Name = "ca4";
      this.ca4.Size = new System.Drawing.Size(100, 23);
      this.ca4.TabIndex = 48;
      // 
      // lblQ4
      // 
      this.lblQ4.AutoSize = true;
      this.lblQ4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblQ4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblQ4.Location = new System.Drawing.Point(352, 230);
      this.lblQ4.Name = "lblQ4";
      this.lblQ4.Size = new System.Drawing.Size(100, 20);
      this.lblQ4.TabIndex = 3;
      this.lblQ4.Text = "4th quarter";
      // 
      // LineupHomeAwayUserControl
      // 
      this.AutoSize = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Controls.Add(this.tableLayoutPanelLineup);
      this.Name = "LineupHomeAwayUserControl";
      this.Size = new System.Drawing.Size(458, 253);
      this.tableLayoutPanelLineup.ResumeLayout(false);
      this.tableLayoutPanelLineup.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion


    public LineupHomeAwayUserControl()
    {
      InitializeComponent();
      InitLabels();
    }

    private void InitLabels ( )
    {
      // 
      // pgh1
      // 
      this.pgh1.AutoSize = true;
      this.pgh1.BackColor = this.backColorHome;
      this.pgh1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pgh1.Location = new System.Drawing.Point(34, 0);
      this.pgh1.Name = "pgh1";
      this.pgh1.Size = new System.Drawing.Size(72, 13);
      this.pgh1.TabIndex = 9;
      this.pgh1.Text = "pgh1";
      // 
      // pgh2
      // 
      this.pgh2.AutoSize = true;
      this.pgh2.BackColor = this.backColorHome;
      this.pgh2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pgh2.Location = new System.Drawing.Point(112, 0);
      this.pgh2.Name = "pgh2";
      this.pgh2.Size = new System.Drawing.Size(72, 13);
      this.pgh2.TabIndex = 10;
      this.pgh2.Text = "pgh2";
      // 
      // pgh3
      // 
      this.pgh3.AutoSize = true;
      this.pgh3.BackColor = this.backColorHome;
      this.pgh3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pgh3.Location = new System.Drawing.Point(190, 0);
      this.pgh3.Name = "pgh3";
      this.pgh3.Size = new System.Drawing.Size(72, 13);
      this.pgh3.TabIndex = 11;
      this.pgh3.Text = "pgh3";
      // 
      // pgh4
      // 
      this.pgh4.AutoSize = true;
      this.pgh4.BackColor = this.backColorHome;
      this.pgh4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pgh4.Location = new System.Drawing.Point(268, 0);
      this.pgh4.Name = "pgh4";
      this.pgh4.Size = new System.Drawing.Size(72, 13);
      this.pgh4.TabIndex = 12;
      this.pgh4.Text = "pgh4";
      // 
      // pga1
      // 
      this.pga1.AutoSize = true;
      this.pga1.BackColor = this.backColorAway;
      this.pga1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pga1.Location = new System.Drawing.Point(34, 13);
      this.pga1.Name = "pga1";
      this.pga1.Size = new System.Drawing.Size(72, 13);
      this.pga1.TabIndex = 13;
      this.pga1.Text = "pga1";
      // 
      // pga2
      // 
      this.pga2.AutoSize = true;
      this.pga2.BackColor = this.backColorAway;
      this.pga2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pga2.Location = new System.Drawing.Point(112, 13);
      this.pga2.Name = "pga2";
      this.pga2.Size = new System.Drawing.Size(72, 13);
      this.pga2.TabIndex = 14;
      this.pga2.Text = "pga2";
      // 
      // pga3
      // 
      this.pga3.AutoSize = true;
      this.pga3.BackColor = this.backColorAway;
      this.pga3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pga3.Location = new System.Drawing.Point(190, 13);
      this.pga3.Name = "pga3";
      this.pga3.Size = new System.Drawing.Size(72, 13);
      this.pga3.TabIndex = 15;
      this.pga3.Text = "pga3";
      // 
      // pga4
      // 
      this.pga4.AutoSize = true;
      this.pga4.BackColor = this.backColorAway;
      this.pga4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pga4.Location = new System.Drawing.Point(268, 13);
      this.pga4.Name = "pga4";
      this.pga4.Size = new System.Drawing.Size(72, 13);
      this.pga4.TabIndex = 16;
      this.pga4.Text = "pga4";
      // 
      // sgh1
      // 
      this.sgh1.AutoSize = true;
      this.sgh1.BackColor = this.backColorHome;
      this.sgh1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.sgh1.Location = new System.Drawing.Point(34, 26);
      this.sgh1.Name = "sgh1";
      this.sgh1.Size = new System.Drawing.Size(72, 13);
      this.sgh1.TabIndex = 17;
      this.sgh1.Text = "sgh1";
      // 
      // sgh2
      // 
      this.sgh2.AutoSize = true;
      this.sgh2.BackColor = this.backColorHome;
      this.sgh2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.sgh2.Location = new System.Drawing.Point(112, 26);
      this.sgh2.Name = "sgh2";
      this.sgh2.Size = new System.Drawing.Size(72, 13);
      this.sgh2.TabIndex = 18;
      this.sgh2.Text = "sgh2";
      // 
      // sgh3
      // 
      this.sgh3.AutoSize = true;
      this.sgh3.BackColor = this.backColorHome;
      this.sgh3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.sgh3.Location = new System.Drawing.Point(190, 26);
      this.sgh3.Name = "sgh3";
      this.sgh3.Size = new System.Drawing.Size(72, 13);
      this.sgh3.TabIndex = 19;
      this.sgh3.Text = "sgh3";
      // 
      // sgh4
      // 
      this.sgh4.AutoSize = true;
      this.sgh4.BackColor = this.backColorHome;
      this.sgh4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.sgh4.Location = new System.Drawing.Point(268, 26);
      this.sgh4.Name = "sgh4";
      this.sgh4.Size = new System.Drawing.Size(72, 13);
      this.sgh4.TabIndex = 20;
      this.sgh4.Text = "sgh4";
      // 
      // sga1
      // 
      this.sga1.AutoSize = true;
      this.sga1.BackColor = this.backColorAway;
      this.sga1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.sga1.Location = new System.Drawing.Point(34, 39);
      this.sga1.Name = "sga1";
      this.sga1.Size = new System.Drawing.Size(72, 13);
      this.sga1.TabIndex = 21;
      this.sga1.Text = "sga1";
      // 
      // sga2
      // 
      this.sga2.AutoSize = true;
      this.sga2.BackColor = this.backColorAway;
      this.sga2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.sga2.Location = new System.Drawing.Point(112, 39);
      this.sga2.Name = "sga2";
      this.sga2.Size = new System.Drawing.Size(72, 13);
      this.sga2.TabIndex = 22;
      this.sga2.Text = "sga2";
      // 
      // sga3
      // 
      this.sga3.AutoSize = true;
      this.sga3.BackColor = this.backColorAway;
      this.sga3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.sga3.Location = new System.Drawing.Point(190, 39);
      this.sga3.Name = "sga3";
      this.sga3.Size = new System.Drawing.Size(72, 13);
      this.sga3.TabIndex = 23;
      this.sga3.Text = "sga3";
      // 
      // sga4
      // 
      this.sga4.AutoSize = true;
      this.sga4.BackColor = this.backColorAway;
      this.sga4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.sga4.Location = new System.Drawing.Point(268, 39);
      this.sga4.Name = "sga4";
      this.sga4.Size = new System.Drawing.Size(72, 13);
      this.sga4.TabIndex = 24;
      this.sga4.Text = "sga4";
      // 
      // sfh1
      // 
      this.sfh1.AutoSize = true;
      this.sfh1.BackColor = this.backColorHome;
      this.sfh1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.sfh1.Location = new System.Drawing.Point(34, 52);
      this.sfh1.Name = "sfh1";
      this.sfh1.Size = new System.Drawing.Size(72, 13);
      this.sfh1.TabIndex = 25;
      this.sfh1.Text = "sfh1";
      // 
      // sfh2
      // 
      this.sfh2.AutoSize = true;
      this.sfh2.BackColor = this.backColorHome;
      this.sfh2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.sfh2.Location = new System.Drawing.Point(112, 52);
      this.sfh2.Name = "sfh2";
      this.sfh2.Size = new System.Drawing.Size(72, 13);
      this.sfh2.TabIndex = 26;
      this.sfh2.Text = "sfh2";
      // 
      // sfh3
      // 
      this.sfh3.AutoSize = true;
      this.sfh3.BackColor = this.backColorHome;
      this.sfh3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.sfh3.Location = new System.Drawing.Point(190, 52);
      this.sfh3.Name = "sfh3";
      this.sfh3.Size = new System.Drawing.Size(72, 13);
      this.sfh3.TabIndex = 27;
      this.sfh3.Text = "sfh3";
      // 
      // sfh4
      // 
      this.sfh4.AutoSize = true;
      this.sfh4.BackColor = this.backColorHome;
      this.sfh4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.sfh4.Location = new System.Drawing.Point(268, 52);
      this.sfh4.Name = "sfh4";
      this.sfh4.Size = new System.Drawing.Size(72, 13);
      this.sfh4.TabIndex = 28;
      this.sfh4.Text = "sfh4";
      // 
      // sfa1
      // 
      this.sfa1.AutoSize = true;
      this.sfa1.BackColor = this.backColorAway;
      this.sfa1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.sfa1.Location = new System.Drawing.Point(34, 65);
      this.sfa1.Name = "sfa1";
      this.sfa1.Size = new System.Drawing.Size(72, 13);
      this.sfa1.TabIndex = 29;
      this.sfa1.Text = "sfa1";
      // 
      // sfa2
      // 
      this.sfa2.AutoSize = true;
      this.sfa2.BackColor = this.backColorAway;
      this.sfa2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.sfa2.Location = new System.Drawing.Point(112, 65);
      this.sfa2.Name = "sfa2";
      this.sfa2.Size = new System.Drawing.Size(72, 13);
      this.sfa2.TabIndex = 30;
      this.sfa2.Text = "sfa2";
      // 
      // sfa3
      // 
      this.sfa3.AutoSize = true;
      this.sfa3.BackColor = this.backColorAway;
      this.sfa3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.sfa3.Location = new System.Drawing.Point(190, 65);
      this.sfa3.Name = "sfa3";
      this.sfa3.Size = new System.Drawing.Size(72, 13);
      this.sfa3.TabIndex = 31;
      this.sfa3.Text = "sfa3";
      // 
      // sfa4
      // 
      this.sfa4.AutoSize = true;
      this.sfa4.BackColor = this.backColorAway;
      this.sfa4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.sfa4.Location = new System.Drawing.Point(268, 65);
      this.sfa4.Name = "sfa4";
      this.sfa4.Size = new System.Drawing.Size(72, 13);
      this.sfa4.TabIndex = 32;
      this.sfa4.Text = "sfa4";
      // 
      // pfh1
      // 
      this.pfh1.AutoSize = true;
      this.pfh1.BackColor = this.backColorHome;
      this.pfh1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pfh1.Location = new System.Drawing.Point(34, 78);
      this.pfh1.Name = "pfh1";
      this.pfh1.Size = new System.Drawing.Size(72, 13);
      this.pfh1.TabIndex = 33;
      this.pfh1.Text = "pfh1";
      // 
      // pfh2
      // 
      this.pfh2.AutoSize = true;
      this.pfh2.BackColor = this.backColorHome;
      this.pfh2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pfh2.Location = new System.Drawing.Point(112, 78);
      this.pfh2.Name = "pfh2";
      this.pfh2.Size = new System.Drawing.Size(72, 13);
      this.pfh2.TabIndex = 34;
      this.pfh2.Text = "pfh2";
      // 
      // pfh3
      // 
      this.pfh3.AutoSize = true;
      this.pfh3.BackColor = this.backColorHome;
      this.pfh3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pfh3.Location = new System.Drawing.Point(190, 78);
      this.pfh3.Name = "pfh3";
      this.pfh3.Size = new System.Drawing.Size(72, 13);
      this.pfh3.TabIndex = 35;
      this.pfh3.Text = "pfh3";
      // 
      // pfh4
      // 
      this.pfh4.AutoSize = true;
      this.pfh4.BackColor = this.backColorHome;
      this.pfh4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pfh4.Location = new System.Drawing.Point(268, 78);
      this.pfh4.Name = "pfh4";
      this.pfh4.Size = new System.Drawing.Size(72, 13);
      this.pfh4.TabIndex = 36;
      this.pfh4.Text = "pfh4";
      // 
      // pfa1
      // 
      this.pfa1.AutoSize = true;
      this.pfa1.BackColor = this.backColorAway;
      this.pfa1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pfa1.Location = new System.Drawing.Point(34, 91);
      this.pfa1.Name = "pfa1";
      this.pfa1.Size = new System.Drawing.Size(72, 13);
      this.pfa1.TabIndex = 37;
      this.pfa1.Text = "pfa1";
      // 
      // pfa2
      // 
      this.pfa2.AutoSize = true;
      this.pfa2.BackColor = this.backColorAway;
      this.pfa2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pfa2.Location = new System.Drawing.Point(112, 91);
      this.pfa2.Name = "pfa2";
      this.pfa2.Size = new System.Drawing.Size(72, 13);
      this.pfa2.TabIndex = 38;
      this.pfa2.Text = "pfa2";
      // 
      // pfa3
      // 
      this.pfa3.AutoSize = true;
      this.pfa3.BackColor = this.backColorAway;
      this.pfa3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pfa3.Location = new System.Drawing.Point(190, 91);
      this.pfa3.Name = "pfa3";
      this.pfa3.Size = new System.Drawing.Size(72, 13);
      this.pfa3.TabIndex = 39;
      this.pfa3.Text = "pfa3";
      // 
      // pfa4
      // 
      this.pfa4.AutoSize = true;
      this.pfa4.BackColor = this.backColorAway;
      this.pfa4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pfa4.Location = new System.Drawing.Point(268, 91);
      this.pfa4.Name = "pfa4";
      this.pfa4.Size = new System.Drawing.Size(72, 13);
      this.pfa4.TabIndex = 40;
      this.pfa4.Text = "pfa4";
      // 
      // ch1
      // 
      this.ch1.AutoSize = true;
      this.ch1.BackColor = this.backColorHome;
      this.ch1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ch1.Location = new System.Drawing.Point(34, 104);
      this.ch1.Name = "ch1";
      this.ch1.Size = new System.Drawing.Size(72, 13);
      this.ch1.TabIndex = 41;
      this.ch1.Text = "ch1";
      // 
      // ch2
      // 
      this.ch2.AutoSize = true;
      this.ch2.BackColor = this.backColorHome;
      this.ch2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ch2.Location = new System.Drawing.Point(112, 104);
      this.ch2.Name = "ch2";
      this.ch2.Size = new System.Drawing.Size(72, 13);
      this.ch2.TabIndex = 42;
      this.ch2.Text = "ch2";
      // 
      // ch3
      // 
      this.ch3.AutoSize = true;
      this.ch3.BackColor = this.backColorHome;
      this.ch3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ch3.Location = new System.Drawing.Point(190, 104);
      this.ch3.Name = "ch3";
      this.ch3.Size = new System.Drawing.Size(72, 13);
      this.ch3.TabIndex = 43;
      this.ch3.Text = "ch3";
      // 
      // ch4
      // 
      this.ch4.AutoSize = true;
      this.ch4.BackColor = this.backColorHome;
      this.ch4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ch4.Location = new System.Drawing.Point(268, 104);
      this.ch4.Name = "ch4";
      this.ch4.Size = new System.Drawing.Size(72, 13);
      this.ch4.TabIndex = 44;
      this.ch4.Text = "ch4";
      // 
      // ca1
      // 
      this.ca1.AutoSize = true;
      this.ca1.BackColor = this.backColorAway;
      this.ca1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ca1.Location = new System.Drawing.Point(34, 117);
      this.ca1.Name = "ca1";
      this.ca1.Size = new System.Drawing.Size(72, 13);
      this.ca1.TabIndex = 45;
      this.ca1.Text = "ca1";
      // 
      // ca2
      // 
      this.ca2.AutoSize = true;
      this.ca2.BackColor = this.backColorAway;
      this.ca2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ca2.Location = new System.Drawing.Point(112, 117);
      this.ca2.Name = "ca2";
      this.ca2.Size = new System.Drawing.Size(72, 13);
      this.ca2.TabIndex = 46;
      this.ca2.Text = "ca2";
      // 
      // ca3
      // 
      this.ca3.AutoSize = true;
      this.ca3.BackColor = this.backColorAway;
      this.ca3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ca3.Location = new System.Drawing.Point(190, 117);
      this.ca3.Name = "ca3";
      this.ca3.Size = new System.Drawing.Size(72, 13);
      this.ca3.TabIndex = 47;
      this.ca3.Text = "ca3";
      // 
      // ca4
      // 
      this.ca4.AutoSize = true;
      this.ca4.BackColor = this.backColorAway;
      this.ca4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ca4.Location = new System.Drawing.Point(268, 117);
      this.ca4.Name = "ca4";
      this.ca4.Size = new System.Drawing.Size(72, 13);
      this.ca4.TabIndex = 48;
      this.ca4.Text = "ca4";
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
      base.OnPaint(pe);
    }

    //public void Lineup(Xsd2.charazayMatchLineup l)
    public void SetData(Xsd2.lineup l)
    {
      //
      // home 1st
      //
      pgh1.Text = CacheManager.Instance.PlayerName (l.home.first.pg);
      sgh1.Text = CacheManager.Instance.PlayerName (l.home.first.sg);
      sfh1.Text = CacheManager.Instance.PlayerName (l.home.first.sf);
      pfh1.Text = CacheManager.Instance.PlayerName (l.home.first.pf);
      ch1.Text = CacheManager.Instance.PlayerName(l.home.first.c);
      //
      // home 2nd
      //
      pgh2.Text = CacheManager.Instance.PlayerName(l.home.second.pg);
      sgh2.Text = CacheManager.Instance.PlayerName(l.home.second.sg);
      sfh2.Text = CacheManager.Instance.PlayerName(l.home.second.sf);
      pfh2.Text = CacheManager.Instance.PlayerName(l.home.second.pf);
      ch2.Text = CacheManager.Instance.PlayerName(l.home.second.c);
      //
      // home 3rd
      //
      pgh3.Text = CacheManager.Instance.PlayerName(l.home.third.pg);
      sgh3.Text = CacheManager.Instance.PlayerName(l.home.third.sg);
      sfh3.Text = CacheManager.Instance.PlayerName(l.home.third.sf);
      pfh3.Text = CacheManager.Instance.PlayerName(l.home.third.pf);
      ch3.Text = CacheManager.Instance.PlayerName(l.home.third.c);
      //
      // home 4th
      //
      pgh4.Text = CacheManager.Instance.PlayerName(l.home.forth.pg);
      sgh4.Text = CacheManager.Instance.PlayerName(l.home.forth.sg);
      sfh4.Text = CacheManager.Instance.PlayerName(l.home.forth.sf);
      pfh4.Text = CacheManager.Instance.PlayerName(l.home.forth.pf);
      ch4.Text = CacheManager.Instance.PlayerName(l.home.forth.c);
      //
      // away 1st
      //
      pga1.Text = CacheManager.Instance.PlayerName(l.away.first.pg);
      sga1.Text = CacheManager.Instance.PlayerName(l.away.first.sg);
      sfa1.Text = CacheManager.Instance.PlayerName(l.away.first.sf);
      pfa1.Text = CacheManager.Instance.PlayerName(l.away.first.pf);
      ca1.Text = CacheManager.Instance.PlayerName(l.away.first.c);
      //
      // away 2nd
      //
      pga2.Text = CacheManager.Instance.PlayerName(l.away.second.pg);
      sga2.Text = CacheManager.Instance.PlayerName(l.away.second.sg);
      sfa2.Text = CacheManager.Instance.PlayerName(l.away.second.sf);
      pfa2.Text = CacheManager.Instance.PlayerName(l.away.second.pf);
      ca2.Text = CacheManager.Instance.PlayerName(l.away.second.c);
      //
      // away 3rd
      //
      pga3.Text = CacheManager.Instance.PlayerName(l.away.third.pg);
      sga3.Text = CacheManager.Instance.PlayerName(l.away.third.sg);
      sfa3.Text = CacheManager.Instance.PlayerName(l.away.third.sf);
      pfa3.Text = CacheManager.Instance.PlayerName(l.away.third.pf);
      ca3.Text = CacheManager.Instance.PlayerName(l.away.third.c);
      //
      // away 4th
      //
      pga4.Text = CacheManager.Instance.PlayerName(l.away.forth.pg);
      sga4.Text = CacheManager.Instance.PlayerName(l.away.forth.sg);
      sfa4.Text = CacheManager.Instance.PlayerName(l.away.forth.sf);
      pfa4.Text = CacheManager.Instance.PlayerName(l.away.forth.pf);
      ca4.Text = CacheManager.Instance.PlayerName(l.away.forth.c);
    }

    [Browsable(true)]
    [Category("Appearance")]
    [Description("Gets and sets the background color of all home labels")]
    [DefaultValue(typeof(Color), "Red")]
    public Color BackColorHome { get { return backColorHome; } set { backColorHome = value; } }
    Color backColorHome = Color.LightCoral;


    [Browsable(true)]
    [Category("Appearance")]
    [Description("Gets and sets the background color of all away labels")]
    [DefaultValue(typeof(Color), "Green")]
    public Color BackColorAway { get { return backColorAway; } set { backColorAway = value; } }
    Color backColorAway = Color.LightGreen;
  }
}
