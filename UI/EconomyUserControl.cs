using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;

namespace AndreiPopescu.CharazayPlus
{
  public partial class EconomyUserControl : UserControl
  {
    //public EconomyUserControl(Xsd2.income i, Xsd2.expences e, bool b)
    //{
    //  InitializeComponent();

    //  Income = i;
    //  Expences = e;
    //  IsWeek = b;
    //}

    public EconomyUserControl()
    {
      InitializeComponent();      
    }

    #region IDisposable
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
    #endregion

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
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
      this.label11 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.label15 = new System.Windows.Forms.Label();
      this.label16 = new System.Windows.Forms.Label();
      this.label17 = new System.Windows.Forms.Label();
      this.label18 = new System.Windows.Forms.Label();
      this.label19 = new System.Windows.Forms.Label();
      this.label20 = new System.Windows.Forms.Label();
      this.label21 = new System.Windows.Forms.Label();
      this.label22 = new System.Windows.Forms.Label();
      this.label23 = new System.Windows.Forms.Label();
      this.label24 = new System.Windows.Forms.Label();
      this.label25 = new System.Windows.Forms.Label();
      this.label26 = new System.Windows.Forms.Label();
      this.label27 = new System.Windows.Forms.Label();
      this.label28 = new System.Windows.Forms.Label();
      this.label29 = new System.Windows.Forms.Label();
      this.label30 = new System.Windows.Forms.Label();
      this.label31 = new System.Windows.Forms.Label();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.AutoSize = true;
      this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tableLayoutPanel1.ColumnCount = 4;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
      this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
      this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
      this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
      this.tableLayoutPanel1.Controls.Add(this.label8, 0, 6);
      this.tableLayoutPanel1.Controls.Add(this.label9, 2, 2);
      this.tableLayoutPanel1.Controls.Add(this.label10, 2, 3);
      this.tableLayoutPanel1.Controls.Add(this.label11, 2, 4);
      this.tableLayoutPanel1.Controls.Add(this.label12, 2, 5);
      this.tableLayoutPanel1.Controls.Add(this.label13, 2, 6);
      this.tableLayoutPanel1.Controls.Add(this.label14, 2, 7);
      this.tableLayoutPanel1.Controls.Add(this.label15, 0, 9);
      this.tableLayoutPanel1.Controls.Add(this.label16, 0, 8);
      this.tableLayoutPanel1.Controls.Add(this.label17, 2, 8);
      this.tableLayoutPanel1.Controls.Add(this.label18, 1, 2);
      this.tableLayoutPanel1.Controls.Add(this.label19, 1, 3);
      this.tableLayoutPanel1.Controls.Add(this.label20, 1, 4);
      this.tableLayoutPanel1.Controls.Add(this.label21, 1, 5);
      this.tableLayoutPanel1.Controls.Add(this.label22, 1, 6);
      this.tableLayoutPanel1.Controls.Add(this.label23, 3, 2);
      this.tableLayoutPanel1.Controls.Add(this.label24, 3, 3);
      this.tableLayoutPanel1.Controls.Add(this.label25, 3, 4);
      this.tableLayoutPanel1.Controls.Add(this.label26, 3, 5);
      this.tableLayoutPanel1.Controls.Add(this.label27, 3, 6);
      this.tableLayoutPanel1.Controls.Add(this.label28, 3, 7);
      this.tableLayoutPanel1.Controls.Add(this.label29, 3, 8);
      this.tableLayoutPanel1.Controls.Add(this.label30, 1, 8);
      this.tableLayoutPanel1.Controls.Add(this.label31, 1, 9);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 10;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(387, 220);
      this.tableLayoutPanel1.TabIndex = 3;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.tableLayoutPanel1.SetColumnSpan(this.label1, 4);
      this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(3, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(381, 22);
      this.label1.TabIndex = 0;
      this.label1.Text = "Week / season";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.tableLayoutPanel1.SetColumnSpan(this.label2, 2);
      this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(3, 22);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(186, 22);
      this.label2.TabIndex = 1;
      this.label2.Text = "Income";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.tableLayoutPanel1.SetColumnSpan(this.label3, 2);
      this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(195, 22);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(189, 22);
      this.label3.TabIndex = 2;
      this.label3.Text = "Expenses";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label4.Location = new System.Drawing.Point(3, 44);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(90, 22);
      this.label4.TabIndex = 3;
      this.label4.Text = "Sponsor";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label5.Location = new System.Drawing.Point(3, 66);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(90, 22);
      this.label5.TabIndex = 4;
      this.label5.Text = "Tickets";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label6.Location = new System.Drawing.Point(3, 88);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(90, 22);
      this.label6.TabIndex = 5;
      this.label6.Text = "Sales";
      this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label7.Location = new System.Drawing.Point(3, 110);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(90, 22);
      this.label7.TabIndex = 6;
      this.label7.Text = "Other";
      this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label8.Location = new System.Drawing.Point(3, 132);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(90, 22);
      this.label8.TabIndex = 7;
      this.label8.Text = "Merchandise";
      this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label9.Location = new System.Drawing.Point(195, 44);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(90, 22);
      this.label9.TabIndex = 8;
      this.label9.Text = "Salary";
      this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label10.Location = new System.Drawing.Point(195, 66);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(90, 22);
      this.label10.TabIndex = 9;
      this.label10.Text = "Staff";
      this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label11.Location = new System.Drawing.Point(195, 88);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(90, 22);
      this.label11.TabIndex = 10;
      this.label11.Text = "Buys";
      this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label12.Location = new System.Drawing.Point(195, 110);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(90, 22);
      this.label12.TabIndex = 11;
      this.label12.Text = "Maintenance";
      this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label13.Location = new System.Drawing.Point(195, 132);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(90, 22);
      this.label13.TabIndex = 12;
      this.label13.Text = "Facility";
      this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label14.Location = new System.Drawing.Point(195, 154);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(90, 22);
      this.label14.TabIndex = 13;
      this.label14.Text = "Other";
      this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label15
      // 
      this.label15.AutoSize = true;
      this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label15.Location = new System.Drawing.Point(3, 198);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(90, 22);
      this.label15.TabIndex = 14;
      this.label15.Text = "Balance";
      this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label16
      // 
      this.label16.AutoSize = true;
      this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label16.Location = new System.Drawing.Point(3, 176);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(90, 22);
      this.label16.TabIndex = 15;
      this.label16.Text = "Total";
      this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label17
      // 
      this.label17.AutoSize = true;
      this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label17.Location = new System.Drawing.Point(195, 176);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(90, 22);
      this.label17.TabIndex = 16;
      this.label17.Text = "Total";
      this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label18
      // 
      this.label18.AutoSize = true;
      this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label18.Location = new System.Drawing.Point(99, 44);
      this.label18.Name = "label18";
      this.label18.Size = new System.Drawing.Size(90, 22);
      this.label18.TabIndex = 17;
      this.label18.Text = "label18";
      this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label19
      // 
      this.label19.AutoSize = true;
      this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label19.Location = new System.Drawing.Point(99, 66);
      this.label19.Name = "label19";
      this.label19.Size = new System.Drawing.Size(90, 22);
      this.label19.TabIndex = 18;
      this.label19.Text = "label19";
      this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label20
      // 
      this.label20.AutoSize = true;
      this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label20.Location = new System.Drawing.Point(99, 88);
      this.label20.Name = "label20";
      this.label20.Size = new System.Drawing.Size(90, 22);
      this.label20.TabIndex = 19;
      this.label20.Text = "label20";
      this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label21
      // 
      this.label21.AutoSize = true;
      this.label21.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label21.Location = new System.Drawing.Point(99, 110);
      this.label21.Name = "label21";
      this.label21.Size = new System.Drawing.Size(90, 22);
      this.label21.TabIndex = 20;
      this.label21.Text = "label21";
      this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label22
      // 
      this.label22.AutoSize = true;
      this.label22.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label22.Location = new System.Drawing.Point(99, 132);
      this.label22.Name = "label22";
      this.label22.Size = new System.Drawing.Size(90, 22);
      this.label22.TabIndex = 21;
      this.label22.Text = "label22";
      this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label23
      // 
      this.label23.AutoSize = true;
      this.label23.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label23.Location = new System.Drawing.Point(291, 44);
      this.label23.Name = "label23";
      this.label23.Size = new System.Drawing.Size(93, 22);
      this.label23.TabIndex = 22;
      this.label23.Text = "label23";
      this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label24
      // 
      this.label24.AutoSize = true;
      this.label24.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label24.Location = new System.Drawing.Point(291, 66);
      this.label24.Name = "label24";
      this.label24.Size = new System.Drawing.Size(93, 22);
      this.label24.TabIndex = 23;
      this.label24.Text = "label24";
      this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label25
      // 
      this.label25.AutoSize = true;
      this.label25.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label25.Location = new System.Drawing.Point(291, 88);
      this.label25.Name = "label25";
      this.label25.Size = new System.Drawing.Size(93, 22);
      this.label25.TabIndex = 24;
      this.label25.Text = "label25";
      this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label26
      // 
      this.label26.AutoSize = true;
      this.label26.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label26.Location = new System.Drawing.Point(291, 110);
      this.label26.Name = "label26";
      this.label26.Size = new System.Drawing.Size(93, 22);
      this.label26.TabIndex = 25;
      this.label26.Text = "label26";
      this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label27
      // 
      this.label27.AutoSize = true;
      this.label27.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label27.Location = new System.Drawing.Point(291, 132);
      this.label27.Name = "label27";
      this.label27.Size = new System.Drawing.Size(93, 22);
      this.label27.TabIndex = 26;
      this.label27.Text = "label27";
      this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label28
      // 
      this.label28.AutoSize = true;
      this.label28.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label28.Location = new System.Drawing.Point(291, 154);
      this.label28.Name = "label28";
      this.label28.Size = new System.Drawing.Size(93, 22);
      this.label28.TabIndex = 27;
      this.label28.Text = "label28";
      this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label29
      // 
      this.label29.AutoSize = true;
      this.label29.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label29.Location = new System.Drawing.Point(291, 176);
      this.label29.Name = "label29";
      this.label29.Size = new System.Drawing.Size(93, 22);
      this.label29.TabIndex = 28;
      this.label29.Text = "label29";
      this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label30
      // 
      this.label30.AutoSize = true;
      this.label30.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label30.Location = new System.Drawing.Point(99, 176);
      this.label30.Name = "label30";
      this.label30.Size = new System.Drawing.Size(90, 22);
      this.label30.TabIndex = 29;
      this.label30.Text = "label30";
      this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label31
      // 
      this.label31.AutoSize = true;
      this.tableLayoutPanel1.SetColumnSpan(this.label31, 3);
      this.label31.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label31.ForeColor = System.Drawing.Color.Red;
      this.label31.Location = new System.Drawing.Point(99, 198);
      this.label31.Name = "label31";
      this.label31.Size = new System.Drawing.Size(285, 22);
      this.label31.TabIndex = 30;
      this.label31.Text = "label31";
      this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // EconomyUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "EconomyUserControl";
      this.Size = new System.Drawing.Size(387, 220);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    #region Fields
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
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
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.Label label18;
    private System.Windows.Forms.Label label19;
    private System.Windows.Forms.Label label20;
    private System.Windows.Forms.Label label21;
    private System.Windows.Forms.Label label22;
    private System.Windows.Forms.Label label23;
    private System.Windows.Forms.Label label24;
    private System.Windows.Forms.Label label25;
    private System.Windows.Forms.Label label26;
    private System.Windows.Forms.Label label27;
    private System.Windows.Forms.Label label28;
    private System.Windows.Forms.Label label29;
    private System.Windows.Forms.Label label30;
    private System.Windows.Forms.Label label31;
    #endregion

    //public Xsd2.income Income { get;  set; }
    //public Xsd2.expences Expences { get; set; }
    //public bool IsWeek { get; set; }

    //[Conditional ("RELEASE")]
    public void LabelsInit(Xsd2.income Income, Xsd2.expences Expences, bool IsWeek)
    { //
      // income
      //
      if (Income != null)
      {
        label18.Text = Income.sponsor.ToString("#,#", CultureInfo.InvariantCulture);
        label19.Text = Income.tickets.ToString("#,#", CultureInfo.InvariantCulture);
        label20.Text = Income.sales.ToString("#,#", CultureInfo.InvariantCulture);
        label21.Text = Income.other.ToString("#,#", CultureInfo.InvariantCulture);
        label22.Text = Income.merchandise.ToString("#,#", CultureInfo.InvariantCulture); 
      }
      //
      // expenses
      //
      if (Expences != null)
      {
        label23.Text = Expences.staff.ToString("#,#", CultureInfo.InvariantCulture);
        label24.Text = Expences.salary.ToString("#,#", CultureInfo.InvariantCulture);
        label25.Text = Expences.buys.ToString("#,#", CultureInfo.InvariantCulture);
        label26.Text = Expences.maintenance.ToString("#,#", CultureInfo.InvariantCulture);
        label27.Text = Expences.facility.ToString("#,#", CultureInfo.InvariantCulture);
        label28.Text = Expences.other.ToString("#,#", CultureInfo.InvariantCulture); 
      }
      //
      // totals/balance
      //
      label29.Text = Expences.Total.ToString("#,#", CultureInfo.InvariantCulture);
      label30.Text = Income.Total.ToString("#,#", CultureInfo.InvariantCulture);
      label31.Text = ((int)(Income.Total - Expences.Total)).ToString("#,#", CultureInfo.InvariantCulture);
      label1.Text = IsWeek ? "Week" : "Season";
    }

    private void Localize()
    {
 
    }

//    private void EconomyUserControl_Load(object sender, EventArgs e)
//    {
//#if (!DEBUG)
//      //LabelsInit();
//#endif
//      //Localize();
//    }

//    private void EconomyUserControl_Layout(object sender, LayoutEventArgs e)
//    {
//      //LabelsInit();
//    }
  }
}
