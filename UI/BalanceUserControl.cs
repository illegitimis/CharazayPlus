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
  /// <summary>
  /// used by <see cref="MyEconomyUserControl"/>
  /// </summary>
  public class BalanceUserControl : UserControl
  {
    public BalanceUserControl()
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
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label15 = new System.Windows.Forms.Label();
      this.label16 = new System.Windows.Forms.Label();
      this.label18 = new System.Windows.Forms.Label();
      this.label19 = new System.Windows.Forms.Label();
      this.label20 = new System.Windows.Forms.Label();
      this.label21 = new System.Windows.Forms.Label();
      this.label22 = new System.Windows.Forms.Label();
      this.label30 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.label17 = new System.Windows.Forms.Label();
      this.label23 = new System.Windows.Forms.Label();
      this.label24 = new System.Windows.Forms.Label();
      this.label25 = new System.Windows.Forms.Label();
      this.label26 = new System.Windows.Forms.Label();
      this.label27 = new System.Windows.Forms.Label();
      this.label28 = new System.Windows.Forms.Label();
      this.label29 = new System.Windows.Forms.Label();
      this.label31 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.BackColor = System.Drawing.Color.DarkGray;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label1.Location = new System.Drawing.Point(3, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(256, 15);
      this.label1.TabIndex = 5;
      this.label1.Text = "Week / season";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.BackColor = System.Drawing.Color.DimGray;
      this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
      this.label2.Location = new System.Drawing.Point(3, 15);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(256, 15);
      this.label2.TabIndex = 6;
      this.label2.Text = "Income";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.BackColor = System.Drawing.Color.DimGray;
      this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
      this.label3.Location = new System.Drawing.Point(3, 134);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(256, 15);
      this.label3.TabIndex = 7;
      this.label3.Text = "Expenses";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label4
      // 
      this.label4.BackColor = System.Drawing.Color.Gainsboro;
      this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label4.Location = new System.Drawing.Point(3, 32);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(86, 17);
      this.label4.TabIndex = 16;
      this.label4.Text = "Sponsor";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label5
      // 
      this.label5.BackColor = System.Drawing.Color.Gainsboro;
      this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label5.Location = new System.Drawing.Point(3, 49);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(86, 17);
      this.label5.TabIndex = 17;
      this.label5.Text = "Tickets";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label6
      // 
      this.label6.BackColor = System.Drawing.Color.Gainsboro;
      this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label6.Location = new System.Drawing.Point(3, 66);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(86, 17);
      this.label6.TabIndex = 18;
      this.label6.Text = "Sales";
      this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label7
      // 
      this.label7.BackColor = System.Drawing.Color.Gainsboro;
      this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label7.Location = new System.Drawing.Point(3, 236);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(86, 17);
      this.label7.TabIndex = 19;
      this.label7.Text = "Other";
      this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label8
      // 
      this.label8.BackColor = System.Drawing.Color.Gainsboro;
      this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label8.Location = new System.Drawing.Point(3, 100);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(86, 17);
      this.label8.TabIndex = 20;
      this.label8.Text = "Merchandise";
      this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label15
      // 
      this.label15.BackColor = System.Drawing.Color.Gainsboro;
      this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label15.Location = new System.Drawing.Point(3, 270);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(86, 17);
      this.label15.TabIndex = 21;
      this.label15.Text = "Balance";
      this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label16
      // 
      this.label16.BackColor = System.Drawing.Color.Gainsboro;
      this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label16.Location = new System.Drawing.Point(3, 117);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(86, 17);
      this.label16.TabIndex = 22;
      this.label16.Text = "Total";
      this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label18
      // 
      this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label18.BackColor = System.Drawing.Color.Gray;
      this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label18.ForeColor = System.Drawing.Color.White;
      this.label18.Location = new System.Drawing.Point(92, 32);
      this.label18.Name = "label18";
      this.label18.Size = new System.Drawing.Size(167, 17);
      this.label18.TabIndex = 30;
      this.label18.Text = "label18";
      this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label19
      // 
      this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label19.BackColor = System.Drawing.Color.Gray;
      this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label19.ForeColor = System.Drawing.Color.White;
      this.label19.Location = new System.Drawing.Point(92, 49);
      this.label19.Name = "label19";
      this.label19.Size = new System.Drawing.Size(167, 17);
      this.label19.TabIndex = 31;
      this.label19.Text = "label19";
      this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label20
      // 
      this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label20.BackColor = System.Drawing.Color.Gray;
      this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label20.ForeColor = System.Drawing.Color.White;
      this.label20.Location = new System.Drawing.Point(92, 66);
      this.label20.Name = "label20";
      this.label20.Size = new System.Drawing.Size(167, 17);
      this.label20.TabIndex = 32;
      this.label20.Text = "label20";
      this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label21
      // 
      this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label21.BackColor = System.Drawing.Color.Gray;
      this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label21.ForeColor = System.Drawing.Color.White;
      this.label21.Location = new System.Drawing.Point(92, 83);
      this.label21.Name = "label21";
      this.label21.Size = new System.Drawing.Size(167, 17);
      this.label21.TabIndex = 33;
      this.label21.Text = "label21";
      this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label22
      // 
      this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label22.BackColor = System.Drawing.Color.Gray;
      this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label22.ForeColor = System.Drawing.Color.White;
      this.label22.Location = new System.Drawing.Point(92, 100);
      this.label22.Name = "label22";
      this.label22.Size = new System.Drawing.Size(167, 17);
      this.label22.TabIndex = 34;
      this.label22.Text = "label22";
      this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label30
      // 
      this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label30.BackColor = System.Drawing.Color.LightGray;
      this.label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label30.ForeColor = System.Drawing.Color.OrangeRed;
      this.label30.Location = new System.Drawing.Point(92, 117);
      this.label30.Name = "label30";
      this.label30.Size = new System.Drawing.Size(167, 17);
      this.label30.TabIndex = 35;
      this.label30.Text = "label30";
      this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label9
      // 
      this.label9.BackColor = System.Drawing.Color.Gainsboro;
      this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label9.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label9.Location = new System.Drawing.Point(3, 151);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(86, 17);
      this.label9.TabIndex = 36;
      this.label9.Text = "Salary";
      this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label10
      // 
      this.label10.BackColor = System.Drawing.Color.Gainsboro;
      this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label10.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label10.Location = new System.Drawing.Point(3, 168);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(86, 17);
      this.label10.TabIndex = 37;
      this.label10.Text = "Staff";
      this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label11
      // 
      this.label11.BackColor = System.Drawing.Color.Gainsboro;
      this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label11.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label11.Location = new System.Drawing.Point(3, 185);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(86, 17);
      this.label11.TabIndex = 38;
      this.label11.Text = "Buys";
      this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label12
      // 
      this.label12.BackColor = System.Drawing.Color.Gainsboro;
      this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label12.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label12.Location = new System.Drawing.Point(3, 202);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(86, 17);
      this.label12.TabIndex = 39;
      this.label12.Text = "Maintenance";
      this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label13
      // 
      this.label13.BackColor = System.Drawing.Color.Gainsboro;
      this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label13.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label13.Location = new System.Drawing.Point(3, 219);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(86, 17);
      this.label13.TabIndex = 40;
      this.label13.Text = "Facility";
      this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label14
      // 
      this.label14.BackColor = System.Drawing.Color.Gainsboro;
      this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label14.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label14.Location = new System.Drawing.Point(3, 83);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(86, 17);
      this.label14.TabIndex = 41;
      this.label14.Text = "Other";
      this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label17
      // 
      this.label17.BackColor = System.Drawing.Color.Gainsboro;
      this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label17.Location = new System.Drawing.Point(3, 253);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(86, 17);
      this.label17.TabIndex = 42;
      this.label17.Text = "Total";
      this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label23
      // 
      this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label23.BackColor = System.Drawing.Color.Gray;
      this.label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label23.ForeColor = System.Drawing.Color.White;
      this.label23.Location = new System.Drawing.Point(92, 151);
      this.label23.Name = "label23";
      this.label23.Size = new System.Drawing.Size(167, 17);
      this.label23.TabIndex = 43;
      this.label23.Text = "label23";
      this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label24
      // 
      this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label24.BackColor = System.Drawing.Color.Gray;
      this.label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label24.ForeColor = System.Drawing.Color.White;
      this.label24.Location = new System.Drawing.Point(92, 168);
      this.label24.Name = "label24";
      this.label24.Size = new System.Drawing.Size(167, 17);
      this.label24.TabIndex = 44;
      this.label24.Text = "label24";
      this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label25
      // 
      this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label25.BackColor = System.Drawing.Color.Gray;
      this.label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label25.ForeColor = System.Drawing.Color.White;
      this.label25.Location = new System.Drawing.Point(92, 185);
      this.label25.Name = "label25";
      this.label25.Size = new System.Drawing.Size(167, 17);
      this.label25.TabIndex = 45;
      this.label25.Text = "label25";
      this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label26
      // 
      this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label26.BackColor = System.Drawing.Color.Gray;
      this.label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label26.ForeColor = System.Drawing.Color.White;
      this.label26.Location = new System.Drawing.Point(92, 202);
      this.label26.Name = "label26";
      this.label26.Size = new System.Drawing.Size(167, 17);
      this.label26.TabIndex = 46;
      this.label26.Text = "label26";
      this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label27
      // 
      this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label27.BackColor = System.Drawing.Color.Gray;
      this.label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label27.ForeColor = System.Drawing.Color.White;
      this.label27.Location = new System.Drawing.Point(92, 219);
      this.label27.Name = "label27";
      this.label27.Size = new System.Drawing.Size(167, 17);
      this.label27.TabIndex = 47;
      this.label27.Text = "label27";
      this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label28
      // 
      this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label28.BackColor = System.Drawing.Color.Gray;
      this.label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label28.ForeColor = System.Drawing.Color.White;
      this.label28.Location = new System.Drawing.Point(92, 236);
      this.label28.Name = "label28";
      this.label28.Size = new System.Drawing.Size(167, 17);
      this.label28.TabIndex = 48;
      this.label28.Text = "label28";
      this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label29
      // 
      this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label29.BackColor = System.Drawing.Color.LightGray;
      this.label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label29.ForeColor = System.Drawing.Color.OrangeRed;
      this.label29.Location = new System.Drawing.Point(92, 253);
      this.label29.Name = "label29";
      this.label29.Size = new System.Drawing.Size(167, 17);
      this.label29.TabIndex = 49;
      this.label29.Text = "label29";
      this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label31
      // 
      this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label31.BackColor = System.Drawing.Color.LightGray;
      this.label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label31.ForeColor = System.Drawing.Color.Red;
      this.label31.Location = new System.Drawing.Point(92, 270);
      this.label31.Name = "label31";
      this.label31.Size = new System.Drawing.Size(167, 17);
      this.label31.TabIndex = 50;
      this.label31.Text = "label31";
      this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // BalanceUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.Controls.Add(this.label9);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.label13);
      this.Controls.Add(this.label14);
      this.Controls.Add(this.label17);
      this.Controls.Add(this.label23);
      this.Controls.Add(this.label24);
      this.Controls.Add(this.label25);
      this.Controls.Add(this.label26);
      this.Controls.Add(this.label27);
      this.Controls.Add(this.label28);
      this.Controls.Add(this.label29);
      this.Controls.Add(this.label31);
      this.Controls.Add(this.label18);
      this.Controls.Add(this.label19);
      this.Controls.Add(this.label20);
      this.Controls.Add(this.label21);
      this.Controls.Add(this.label22);
      this.Controls.Add(this.label30);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label15);
      this.Controls.Add(this.label16);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.DoubleBuffered = true;
      this.Name = "BalanceUserControl";
      this.Size = new System.Drawing.Size(263, 291);
      this.Load += new System.EventHandler(this.EconomyUserControl_Load);
      this.ResumeLayout(false);

    }

    #endregion

    #region Fields
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label15;
    private Label label16;
    private Label label18;
    private Label label19;
    private Label label20;
    private Label label21;
    private Label label22;
    private Label label30;
    private Label label9;
    private Label label10;
    private Label label11;
    private Label label12;
    private Label label13;
    private Label label14;
    private Label label17;
    private Label label23;
    private Label label24;
    private Label label25;
    private Label label26;
    private Label label27;
    private Label label28;
    private Label label29;
    private Label label31;
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
      Utils.CharazayDate cd = DateTime.UtcNow;
      label1.Text = IsWeek ? "Week " + cd.Week + " Day " + cd.Day : "Season " + cd.Season;
    }

    private void Localize()
    {
 
    }

    private void EconomyUserControl_Load (object sender, EventArgs e)
    {

    }

  }
}
