using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace AndreiPopescu.CharazayPlus.UI
{
  public partial class BasicPlayerUserControl : UserControl
  {
    #region const
    const char HeavyCheckMark = '\u2714';
    private Label label22;
    private Label lblSI;
    private Label label21;
    private Label lblU18Caps;
    private Label lblU21Caps;
    private Label lblNtCaps;
    const char HeavyX = '\u2716'; 
    #endregion

    public BasicPlayerUserControl ( )
    {
      InitializeComponent();
    }

    private void BasicPlayerUserControl_Load (object sender, EventArgs e)
    {
      this.lnkLblPlayer.LinkClicked += (sndr, ev) =>
      {// Determine which link was clicked within the LinkLabel.
        this.lnkLblPlayer.Links[lnkLblPlayer.Links.IndexOf(ev.Link)].Visited = true;

        // Display the appropriate link based on the value of the 
        // LinkData property of the Link object.
        string target = ev.Link.LinkData as string;

        // If the value looks like a URL, navigate to it.
        // Otherwise, display it in a message box.
        if (null != target && target.StartsWith("www"))
        {
          System.Diagnostics.Process.Start(target);
        }
      };
    }

    #region public interface
    internal uint? CurrentPrice { get; set; }

    //internal void Init (Player p = null, Player q=null, ImageList il=null)
    internal void Init (Player p = null, ImageList il = null)
    {
      PlayerByScore = p;
      //PlayerByValueIndex = q;
      if (il != null) this.pictbx.Image = il.Images[PlayerByScore.CountryId - 1];
      //
      //if (p == null && q == null)
      if (p == null)
        FailsafeInit();
      else
        ProperInit();
    } 
    #endregion

    #region utility
    private Player PlayerByScore { get; set; }

    private void FailsafeInit ( )
    {
      foreach (var child in this.Controls)
      {
        if (child is HorizontalLevelIndicatorLabel)
        {
          var hlvl = (child as HorizontalLevelIndicatorLabel);
          hlvl.Level = hlvl.MinimumLevel;
        }

        else if (child is LinkLabel)
        {
          (child as LinkLabel).Text = "Not found";
        }

        else if (child is Label)
        {
          var lbl = (child as Label);
          if (lbl.Name.StartsWith("lbl"))
            lbl.Text = String.Empty;
        }


      }

      //foreach (var hlvl in new[] { this.hlvlDef   ,
      //this.hlvlDri   ,
      //this.hlvlPas   ,
      //this.hlvlSpe   ,
      //this.hlvlFtw   ,
      //this.hlvlReb   ,
      //this.hlvlExp   ,
      //this.hlvlFT   ,
      //this.hlvl2p   ,
      //this.hlvl3p   ,this.hlvlAge, this.hlvlHeight, this.hlvlWeight, this.hlvlBmi})
      //  hlvl.Level = 0f;


    }

    private void ProperInit ( )
    {
      this.lnkLblPlayer.Text = PlayerByScore.FullName;
      this.lnkLblPlayer.Links.Clear();
      this.lnkLblPlayer.Links.Add(0, 1000, string.Format("www.charazay.com/?act=player&code=1&id={0}", PlayerByScore.Id));
      lblSI.Text = PlayerByScore.SkillsIndex.ToString("N0");
      //
      this.lblNt.Text = PlayerByScore.NT ? HeavyCheckMark.ToString() : HeavyX.ToString();
      this.lblU18.Text = PlayerByScore.U18NT ? HeavyCheckMark.ToString() : HeavyX.ToString();
      this.lblU21.Text = PlayerByScore.U21NT ? HeavyCheckMark.ToString() : HeavyX.ToString();
      this.lblU18Caps.Text = PlayerByScore.BasePlayer.u19capSpecified ? PlayerByScore.BasePlayer.u19cap.ToString() + " caps" : HeavyX.ToString();
      this.lblU21Caps.Text = PlayerByScore.BasePlayer.u21capSpecified ? PlayerByScore.BasePlayer.u21cap.ToString() + " caps" : HeavyX.ToString();
      this.lblNtCaps.Text = PlayerByScore.BasePlayer.ntcapSpecified ? PlayerByScore.BasePlayer.ntcap.ToString() + " caps" : HeavyX.ToString();
      //
      this.hlvlAge.Level = PlayerByScore.Age;
      this.hlvlHeight.Level = PlayerByScore.Height;
      this.hlvlWeight.Level = (float)PlayerByScore.Weight;
      this.hlvlBmi.Level = (float)PlayerByScore.BMI;
      //
      this.hlvlDef.Level = PlayerByScore.Defence_Display;
      this.hlvlDri.Level = PlayerByScore.Dribling_Display;
      this.hlvlPas.Level = PlayerByScore.Passing_Display;
      this.hlvlSpe.Level = PlayerByScore.Speed_Display;
      this.hlvlFtw.Level = PlayerByScore.Footwork_Display;
      this.hlvlReb.Level = PlayerByScore.Rebounds_Display;
      this.hlvlExp.Level = PlayerByScore.Experience;
      this.hlvlFT.Level = PlayerByScore.Freethrows_Display;
      this.hlvl2p.Level = PlayerByScore.TwoPoint_Display;
      this.hlvl3p.Level = PlayerByScore.ThreePoint_Display;
      //
      //this.lblAgeValIdx.Text = (PlayerByValueIndex == null)
      //  ? PlayerByScore.ValueIndex.ToString("F02")
      //  : PlayerByValueIndex.ValueIndex.ToString("F02");
      this.lblAgeValIdx.Text = PlayerByScore.ValueIndex.ToString("F02");
      //if (PlayerByValueIndex == null)
      //{
      this.lblTMVal.Text = PlayerByScore.TransferMarketValue.ToString("F02");
      this.lblTmCompare.Text = "-";
      //}
      //else
      //{
      //  this.lblTMVal.Text = "( " + PlayerByScore.TransferMarketValue.ToString("F02");
      //  this.lblTmCompare.Text = PlayerByValueIndex.TransferMarketValue.ToString("F02") + " )";
      //}

      //this.lblProfitability.Text = (Math.Pow(10d, 6d) *
      // ((PlayerByValueIndex == null) ? PlayerByScore.TransferMarketValue : PlayerByValueIndex.TransferMarketValue)
      //  / (double)CurrentPrice).ToString("F02");
      this.lblProfitability.Text = (Math.Pow(10d, 6d) * PlayerByScore.TransferMarketValue / (double)CurrentPrice).ToString("F02");
      this.lblPosH.Text = PlayerByScore.PositionHeightBased.ToString();
      this.lblPosScore.Text = PlayerByScore.PositionEnum.ToString();
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
      this.lnkLblPlayer = new System.Windows.Forms.LinkLabel();
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
      this.pictbx = new System.Windows.Forms.PictureBox();
      this.label15 = new System.Windows.Forms.Label();
      this.lblNt = new System.Windows.Forms.Label();
      this.lblU21 = new System.Windows.Forms.Label();
      this.label17 = new System.Windows.Forms.Label();
      this.lblU18 = new System.Windows.Forms.Label();
      this.label19 = new System.Windows.Forms.Label();
      this.label16 = new System.Windows.Forms.Label();
      this.label18 = new System.Windows.Forms.Label();
      this.lblPosScore = new System.Windows.Forms.Label();
      this.lblPosH = new System.Windows.Forms.Label();
      this.lblAgeValIdx = new System.Windows.Forms.Label();
      this.label20 = new System.Windows.Forms.Label();
      this.lblProfitability = new System.Windows.Forms.Label();
      this.label23 = new System.Windows.Forms.Label();
      this.lblTmCompare = new System.Windows.Forms.Label();
      this.lblTMVal = new System.Windows.Forms.Label();
      this.label22 = new System.Windows.Forms.Label();
      this.lblSI = new System.Windows.Forms.Label();
      this.label21 = new System.Windows.Forms.Label();
      this.lblU18Caps = new System.Windows.Forms.Label();
      this.lblU21Caps = new System.Windows.Forms.Label();
      this.lblNtCaps = new System.Windows.Forms.Label();
      this.hlvlBmi = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hlvlHeight = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hlvlWeight = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hlvlAge = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hlvl3p = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hlvlFT = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hlvl2p = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hlvlExp = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hlvlFtw = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hlvlReb = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hlvlSpe = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hlvlDri = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hlvlPas = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      this.hlvlDef = new AndreiPopescu.CharazayPlus.UI.HorizontalLevelIndicatorLabel();
      ((System.ComponentModel.ISupportInitialize)(this.pictbx)).BeginInit();
      this.SuspendLayout();
      // 
      // lnkLblPlayer
      // 
      this.lnkLblPlayer.AutoSize = true;
      this.lnkLblPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lnkLblPlayer.Location = new System.Drawing.Point(7, 3);
      this.lnkLblPlayer.Name = "lnkLblPlayer";
      this.lnkLblPlayer.Size = new System.Drawing.Size(78, 15);
      this.lnkLblPlayer.TabIndex = 1;
      this.lnkLblPlayer.TabStop = true;
      this.lnkLblPlayer.Text = "Player Name";
      this.lnkLblPlayer.VisitedLinkColor = System.Drawing.Color.ForestGreen;
      // 
      // _lblTitle
      // 
      this.label1.BackColor = System.Drawing.Color.DimGray;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new System.Drawing.Point(3, 234);
      this.label1.Name = "_lblTitle";
      this.label1.Size = new System.Drawing.Size(68, 23);
      this.label1.TabIndex = 2;
      this.label1.Text = "Defense";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label2
      // 
      this.label2.BackColor = System.Drawing.Color.DimGray;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label2.ForeColor = System.Drawing.Color.White;
      this.label2.Location = new System.Drawing.Point(3, 280);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(68, 23);
      this.label2.TabIndex = 4;
      this.label2.Text = "Passing";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label3
      // 
      this.label3.BackColor = System.Drawing.Color.DimGray;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label3.ForeColor = System.Drawing.Color.White;
      this.label3.Location = new System.Drawing.Point(3, 257);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(68, 23);
      this.label3.TabIndex = 6;
      this.label3.Text = "Dribbling";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label4
      // 
      this.label4.BackColor = System.Drawing.Color.DimGray;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label4.ForeColor = System.Drawing.Color.White;
      this.label4.Location = new System.Drawing.Point(3, 326);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(68, 23);
      this.label4.TabIndex = 12;
      this.label4.Text = "Footwork";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label5
      // 
      this.label5.BackColor = System.Drawing.Color.DimGray;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label5.ForeColor = System.Drawing.Color.White;
      this.label5.Location = new System.Drawing.Point(3, 349);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(68, 23);
      this.label5.TabIndex = 10;
      this.label5.Text = "Rebounds";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label6
      // 
      this.label6.BackColor = System.Drawing.Color.DimGray;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label6.ForeColor = System.Drawing.Color.White;
      this.label6.Location = new System.Drawing.Point(3, 303);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(68, 23);
      this.label6.TabIndex = 8;
      this.label6.Text = "Speed";
      this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label7
      // 
      this.label7.BackColor = System.Drawing.Color.DimGray;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label7.ForeColor = System.Drawing.Color.White;
      this.label7.Location = new System.Drawing.Point(3, 395);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(68, 23);
      this.label7.TabIndex = 18;
      this.label7.Text = "Free throws";
      this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label8
      // 
      this.label8.BackColor = System.Drawing.Color.DimGray;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label8.ForeColor = System.Drawing.Color.White;
      this.label8.Location = new System.Drawing.Point(3, 418);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(68, 23);
      this.label8.TabIndex = 16;
      this.label8.Text = "2 point";
      this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label9
      // 
      this.label9.BackColor = System.Drawing.Color.DimGray;
      this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label9.ForeColor = System.Drawing.Color.White;
      this.label9.Location = new System.Drawing.Point(3, 372);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(68, 23);
      this.label9.TabIndex = 14;
      this.label9.Text = "Experience";
      this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label10
      // 
      this.label10.BackColor = System.Drawing.Color.DimGray;
      this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label10.ForeColor = System.Drawing.Color.White;
      this.label10.Location = new System.Drawing.Point(3, 441);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(68, 23);
      this.label10.TabIndex = 20;
      this.label10.Text = "3 point";
      this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label11
      // 
      this.label11.BackColor = System.Drawing.Color.DimGray;
      this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label11.ForeColor = System.Drawing.Color.White;
      this.label11.Location = new System.Drawing.Point(3, 142);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(68, 23);
      this.label11.TabIndex = 26;
      this.label11.Text = "Height";
      this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label12
      // 
      this.label12.BackColor = System.Drawing.Color.DimGray;
      this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label12.ForeColor = System.Drawing.Color.White;
      this.label12.Location = new System.Drawing.Point(3, 165);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(68, 23);
      this.label12.TabIndex = 24;
      this.label12.Text = "Weight";
      this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label13
      // 
      this.label13.BackColor = System.Drawing.Color.DimGray;
      this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label13.ForeColor = System.Drawing.Color.White;
      this.label13.Location = new System.Drawing.Point(3, 119);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(68, 23);
      this.label13.TabIndex = 22;
      this.label13.Text = "Age";
      this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label14
      // 
      this.label14.BackColor = System.Drawing.Color.DimGray;
      this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label14.ForeColor = System.Drawing.Color.White;
      this.label14.Location = new System.Drawing.Point(3, 188);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(68, 23);
      this.label14.TabIndex = 28;
      this.label14.Text = "BMI";
      this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // pictbx
      // 
      this.pictbx.Location = new System.Drawing.Point(118, 3);
      this.pictbx.Name = "pictbx";
      this.pictbx.Size = new System.Drawing.Size(87, 97);
      this.pictbx.TabIndex = 29;
      this.pictbx.TabStop = false;
      // 
      // label15
      // 
      this.label15.AutoSize = true;
      this.label15.Location = new System.Drawing.Point(7, 40);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(22, 13);
      this.label15.TabIndex = 30;
      this.label15.Text = "NT";
      // 
      // lblNt
      // 
      this.lblNt.AutoSize = true;
      this.lblNt.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblNt.Location = new System.Drawing.Point(45, 40);
      this.lblNt.Name = "lblNt";
      this.lblNt.Size = new System.Drawing.Size(12, 15);
      this.lblNt.TabIndex = 31;
      this.lblNt.Text = "-";
      // 
      // lblU21
      // 
      this.lblU21.AutoSize = true;
      this.lblU21.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblU21.Location = new System.Drawing.Point(45, 62);
      this.lblU21.Name = "lblU21";
      this.lblU21.Size = new System.Drawing.Size(12, 15);
      this.lblU21.TabIndex = 33;
      this.lblU21.Text = "-";
      // 
      // label17
      // 
      this.label17.AutoSize = true;
      this.label17.Location = new System.Drawing.Point(7, 62);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(27, 13);
      this.label17.TabIndex = 32;
      this.label17.Text = "U21";
      // 
      // lblU18
      // 
      this.lblU18.AutoSize = true;
      this.lblU18.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblU18.Location = new System.Drawing.Point(45, 85);
      this.lblU18.Name = "lblU18";
      this.lblU18.Size = new System.Drawing.Size(12, 15);
      this.lblU18.TabIndex = 35;
      this.lblU18.Text = "-";
      // 
      // label19
      // 
      this.label19.AutoSize = true;
      this.label19.Location = new System.Drawing.Point(7, 85);
      this.label19.Name = "label19";
      this.label19.Size = new System.Drawing.Size(27, 13);
      this.label19.TabIndex = 34;
      this.label19.Text = "U18";
      // 
      // label16
      // 
      this.label16.BackColor = System.Drawing.Color.DimGray;
      this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label16.ForeColor = System.Drawing.Color.White;
      this.label16.Location = new System.Drawing.Point(3, 464);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(125, 23);
      this.label16.TabIndex = 36;
      this.label16.Text = "Position by score";
      this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label18
      // 
      this.label18.BackColor = System.Drawing.Color.DimGray;
      this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label18.ForeColor = System.Drawing.Color.White;
      this.label18.Location = new System.Drawing.Point(3, 487);
      this.label18.Name = "label18";
      this.label18.Size = new System.Drawing.Size(125, 23);
      this.label18.TabIndex = 37;
      this.label18.Text = "Position by height";
      this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblPosScore
      // 
      this.lblPosScore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblPosScore.BackColor = System.Drawing.Color.DimGray;
      this.lblPosScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblPosScore.ForeColor = System.Drawing.Color.OrangeRed;
      this.lblPosScore.Location = new System.Drawing.Point(128, 464);
      this.lblPosScore.Name = "lblPosScore";
      this.lblPosScore.Size = new System.Drawing.Size(77, 23);
      this.lblPosScore.TabIndex = 40;
      this.lblPosScore.Text = "-";
      this.lblPosScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblPosH
      // 
      this.lblPosH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblPosH.BackColor = System.Drawing.Color.DimGray;
      this.lblPosH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblPosH.ForeColor = System.Drawing.Color.Coral;
      this.lblPosH.Location = new System.Drawing.Point(128, 487);
      this.lblPosH.Name = "lblPosH";
      this.lblPosH.Size = new System.Drawing.Size(77, 23);
      this.lblPosH.TabIndex = 41;
      this.lblPosH.Text = "-";
      this.lblPosH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblAgeValIdx
      // 
      this.lblAgeValIdx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblAgeValIdx.BackColor = System.Drawing.Color.DimGray;
      this.lblAgeValIdx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblAgeValIdx.ForeColor = System.Drawing.Color.Tomato;
      this.lblAgeValIdx.Location = new System.Drawing.Point(128, 510);
      this.lblAgeValIdx.Name = "lblAgeValIdx";
      this.lblAgeValIdx.Size = new System.Drawing.Size(77, 23);
      this.lblAgeValIdx.TabIndex = 43;
      this.lblAgeValIdx.Text = "-";
      this.lblAgeValIdx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label20
      // 
      this.label20.BackColor = System.Drawing.Color.DimGray;
      this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label20.ForeColor = System.Drawing.Color.White;
      this.label20.Location = new System.Drawing.Point(3, 533);
      this.label20.Name = "label20";
      this.label20.Size = new System.Drawing.Size(125, 46);
      this.label20.TabIndex = 45;
      this.label20.Text = "Transfer             Compare";
      this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblProfitability
      // 
      this.lblProfitability.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblProfitability.BackColor = System.Drawing.Color.DimGray;
      this.lblProfitability.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblProfitability.ForeColor = System.Drawing.Color.LightSalmon;
      this.lblProfitability.Location = new System.Drawing.Point(128, 579);
      this.lblProfitability.Name = "lblProfitability";
      this.lblProfitability.Size = new System.Drawing.Size(77, 23);
      this.lblProfitability.TabIndex = 48;
      this.lblProfitability.Text = "-";
      this.lblProfitability.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label23
      // 
      this.label23.BackColor = System.Drawing.Color.DimGray;
      this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label23.ForeColor = System.Drawing.Color.White;
      this.label23.Location = new System.Drawing.Point(3, 579);
      this.label23.Name = "label23";
      this.label23.Size = new System.Drawing.Size(125, 23);
      this.label23.TabIndex = 47;
      this.label23.Text = "Profitability";
      this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblTmCompare
      // 
      this.lblTmCompare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblTmCompare.BackColor = System.Drawing.Color.DimGray;
      this.lblTmCompare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblTmCompare.ForeColor = System.Drawing.Color.Salmon;
      this.lblTmCompare.Location = new System.Drawing.Point(128, 556);
      this.lblTmCompare.Name = "lblTmCompare";
      this.lblTmCompare.Size = new System.Drawing.Size(77, 23);
      this.lblTmCompare.TabIndex = 53;
      this.lblTmCompare.Text = "-";
      this.lblTmCompare.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblTMVal
      // 
      this.lblTMVal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblTMVal.BackColor = System.Drawing.Color.DimGray;
      this.lblTMVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblTMVal.ForeColor = System.Drawing.Color.Salmon;
      this.lblTMVal.Location = new System.Drawing.Point(128, 533);
      this.lblTMVal.Name = "lblTMVal";
      this.lblTMVal.Size = new System.Drawing.Size(77, 23);
      this.lblTMVal.TabIndex = 46;
      this.lblTMVal.Text = "-";
      this.lblTMVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label22
      // 
      this.label22.BackColor = System.Drawing.Color.DimGray;
      this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label22.ForeColor = System.Drawing.Color.White;
      this.label22.Location = new System.Drawing.Point(3, 211);
      this.label22.Name = "label22";
      this.label22.Size = new System.Drawing.Size(82, 23);
      this.label22.TabIndex = 54;
      this.label22.Text = "Skills Index";
      this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblSI
      // 
      this.lblSI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblSI.BackColor = System.Drawing.Color.DimGray;
      this.lblSI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblSI.ForeColor = System.Drawing.Color.White;
      this.lblSI.Location = new System.Drawing.Point(85, 211);
      this.lblSI.Name = "lblSI";
      this.lblSI.Size = new System.Drawing.Size(120, 23);
      this.lblSI.TabIndex = 55;
      this.lblSI.Text = "-";
      this.lblSI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label21
      // 
      this.label21.BackColor = System.Drawing.Color.DimGray;
      this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label21.ForeColor = System.Drawing.Color.White;
      this.label21.Location = new System.Drawing.Point(3, 510);
      this.label21.Name = "label21";
      this.label21.Size = new System.Drawing.Size(125, 23);
      this.label21.TabIndex = 39;
      this.label21.Text = "Age/Value index";
      this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblU18Caps
      // 
      this.lblU18Caps.AutoSize = true;
      this.lblU18Caps.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblU18Caps.Location = new System.Drawing.Point(73, 85);
      this.lblU18Caps.Name = "lblU18Caps";
      this.lblU18Caps.Size = new System.Drawing.Size(12, 15);
      this.lblU18Caps.TabIndex = 61;
      this.lblU18Caps.Text = "-";
      // 
      // lblU21Caps
      // 
      this.lblU21Caps.AutoSize = true;
      this.lblU21Caps.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblU21Caps.Location = new System.Drawing.Point(73, 62);
      this.lblU21Caps.Name = "lblU21Caps";
      this.lblU21Caps.Size = new System.Drawing.Size(12, 15);
      this.lblU21Caps.TabIndex = 59;
      this.lblU21Caps.Text = "-";
      // 
      // lblNtCaps
      // 
      this.lblNtCaps.AutoSize = true;
      this.lblNtCaps.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblNtCaps.Location = new System.Drawing.Point(73, 40);
      this.lblNtCaps.Name = "lblNtCaps";
      this.lblNtCaps.Size = new System.Drawing.Size(12, 15);
      this.lblNtCaps.TabIndex = 57;
      this.lblNtCaps.Text = "-";
      // 
      // hlvlBmi
      // 
      this.hlvlBmi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.hlvlBmi.Level = 23F;
      this.hlvlBmi.Location = new System.Drawing.Point(71, 188);
      this.hlvlBmi.MaximumLevel = 35F;
      this.hlvlBmi.MinimumLevel = 15F;
      this.hlvlBmi.Name = "hlvlBmi";
      this.hlvlBmi.Size = new System.Drawing.Size(134, 23);
      this.hlvlBmi.TabIndex = 27;
      this.hlvlBmi.Text = "23";
      this.hlvlBmi.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hlvlHeight
      // 
      this.hlvlHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.hlvlHeight.Level = 185F;
      this.hlvlHeight.Location = new System.Drawing.Point(71, 142);
      this.hlvlHeight.MaximumLevel = 230F;
      this.hlvlHeight.MinimumLevel = 160F;
      this.hlvlHeight.Name = "hlvlHeight";
      this.hlvlHeight.Size = new System.Drawing.Size(134, 23);
      this.hlvlHeight.TabIndex = 25;
      this.hlvlHeight.Text = "185";
      this.hlvlHeight.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hlvlWeight
      // 
      this.hlvlWeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.hlvlWeight.Level = 90F;
      this.hlvlWeight.Location = new System.Drawing.Point(71, 165);
      this.hlvlWeight.MaximumLevel = 160F;
      this.hlvlWeight.MinimumLevel = 50F;
      this.hlvlWeight.Name = "hlvlWeight";
      this.hlvlWeight.Size = new System.Drawing.Size(134, 23);
      this.hlvlWeight.TabIndex = 23;
      this.hlvlWeight.Text = "90";
      this.hlvlWeight.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hlvlAge
      // 
      this.hlvlAge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.hlvlAge.Level = 15F;
      this.hlvlAge.Location = new System.Drawing.Point(71, 119);
      this.hlvlAge.MaximumLevel = 40F;
      this.hlvlAge.MinimumLevel = 15F;
      this.hlvlAge.Name = "hlvlAge";
      this.hlvlAge.Size = new System.Drawing.Size(134, 23);
      this.hlvlAge.TabIndex = 21;
      this.hlvlAge.Text = "15";
      this.hlvlAge.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hlvl3p
      // 
      this.hlvl3p.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.hlvl3p.Level = 1F;
      this.hlvl3p.Location = new System.Drawing.Point(71, 441);
      this.hlvl3p.MaximumLevel = 30F;
      this.hlvl3p.Name = "hlvl3p";
      this.hlvl3p.Size = new System.Drawing.Size(134, 23);
      this.hlvl3p.TabIndex = 19;
      this.hlvl3p.Text = " 1";
      this.hlvl3p.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hlvlFT
      // 
      this.hlvlFT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.hlvlFT.Level = 1F;
      this.hlvlFT.Location = new System.Drawing.Point(71, 395);
      this.hlvlFT.MaximumLevel = 30F;
      this.hlvlFT.Name = "hlvlFT";
      this.hlvlFT.Size = new System.Drawing.Size(134, 23);
      this.hlvlFT.TabIndex = 17;
      this.hlvlFT.Text = " 1";
      this.hlvlFT.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hlvl2p
      // 
      this.hlvl2p.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.hlvl2p.Level = 1F;
      this.hlvl2p.Location = new System.Drawing.Point(71, 418);
      this.hlvl2p.MaximumLevel = 30F;
      this.hlvl2p.Name = "hlvl2p";
      this.hlvl2p.Size = new System.Drawing.Size(134, 23);
      this.hlvl2p.TabIndex = 15;
      this.hlvl2p.Text = " 1";
      this.hlvl2p.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hlvlExp
      // 
      this.hlvlExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.hlvlExp.Level = 1F;
      this.hlvlExp.Location = new System.Drawing.Point(71, 372);
      this.hlvlExp.MaximumLevel = 30F;
      this.hlvlExp.Name = "hlvlExp";
      this.hlvlExp.Size = new System.Drawing.Size(134, 23);
      this.hlvlExp.TabIndex = 13;
      this.hlvlExp.Text = " 1";
      this.hlvlExp.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hlvlFtw
      // 
      this.hlvlFtw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.hlvlFtw.Level = 1F;
      this.hlvlFtw.Location = new System.Drawing.Point(71, 326);
      this.hlvlFtw.MaximumLevel = 30F;
      this.hlvlFtw.Name = "hlvlFtw";
      this.hlvlFtw.Size = new System.Drawing.Size(134, 23);
      this.hlvlFtw.TabIndex = 11;
      this.hlvlFtw.Text = " 1";
      this.hlvlFtw.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hlvlReb
      // 
      this.hlvlReb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.hlvlReb.Level = 1F;
      this.hlvlReb.Location = new System.Drawing.Point(71, 349);
      this.hlvlReb.MaximumLevel = 30F;
      this.hlvlReb.Name = "hlvlReb";
      this.hlvlReb.Size = new System.Drawing.Size(134, 23);
      this.hlvlReb.TabIndex = 9;
      this.hlvlReb.Text = " 1";
      this.hlvlReb.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hlvlSpe
      // 
      this.hlvlSpe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.hlvlSpe.Level = 1F;
      this.hlvlSpe.Location = new System.Drawing.Point(71, 303);
      this.hlvlSpe.MaximumLevel = 30F;
      this.hlvlSpe.Name = "hlvlSpe";
      this.hlvlSpe.Size = new System.Drawing.Size(134, 23);
      this.hlvlSpe.TabIndex = 7;
      this.hlvlSpe.Text = " 1";
      this.hlvlSpe.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hlvlDri
      // 
      this.hlvlDri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.hlvlDri.Level = 1F;
      this.hlvlDri.Location = new System.Drawing.Point(71, 257);
      this.hlvlDri.MaximumLevel = 30F;
      this.hlvlDri.Name = "hlvlDri";
      this.hlvlDri.Size = new System.Drawing.Size(134, 23);
      this.hlvlDri.TabIndex = 5;
      this.hlvlDri.Text = " 1";
      this.hlvlDri.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hlvlPas
      // 
      this.hlvlPas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.hlvlPas.Level = 1F;
      this.hlvlPas.Location = new System.Drawing.Point(71, 280);
      this.hlvlPas.MaximumLevel = 30F;
      this.hlvlPas.Name = "hlvlPas";
      this.hlvlPas.Size = new System.Drawing.Size(134, 23);
      this.hlvlPas.TabIndex = 3;
      this.hlvlPas.Text = " 1";
      this.hlvlPas.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // hlvlDef
      // 
      this.hlvlDef.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.hlvlDef.Level = 1F;
      this.hlvlDef.Location = new System.Drawing.Point(71, 234);
      this.hlvlDef.MaximumLevel = 30F;
      this.hlvlDef.Name = "hlvlDef";
      this.hlvlDef.Size = new System.Drawing.Size(134, 23);
      this.hlvlDef.TabIndex = 0;
      this.hlvlDef.Text = " 1";
      this.hlvlDef.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // BasicPlayerUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lblU18Caps);
      this.Controls.Add(this.lblU21Caps);
      this.Controls.Add(this.lblNtCaps);
      this.Controls.Add(this.lblSI);
      this.Controls.Add(this.label22);
      this.Controls.Add(this.lblTmCompare);
      this.Controls.Add(this.lblProfitability);
      this.Controls.Add(this.label23);
      this.Controls.Add(this.lblTMVal);
      this.Controls.Add(this.label20);
      this.Controls.Add(this.lblAgeValIdx);
      this.Controls.Add(this.lblPosH);
      this.Controls.Add(this.lblPosScore);
      this.Controls.Add(this.label21);
      this.Controls.Add(this.label18);
      this.Controls.Add(this.label16);
      this.Controls.Add(this.lblU18);
      this.Controls.Add(this.label19);
      this.Controls.Add(this.lblU21);
      this.Controls.Add(this.label17);
      this.Controls.Add(this.lblNt);
      this.Controls.Add(this.label15);
      this.Controls.Add(this.pictbx);
      this.Controls.Add(this.label14);
      this.Controls.Add(this.hlvlBmi);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.hlvlHeight);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.hlvlWeight);
      this.Controls.Add(this.label13);
      this.Controls.Add(this.hlvlAge);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.hlvl3p);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.hlvlFT);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.hlvl2p);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.hlvlExp);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.hlvlFtw);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.hlvlReb);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.hlvlSpe);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.hlvlDri);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.hlvlPas);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.lnkLblPlayer);
      this.Controls.Add(this.hlvlDef);
      this.DoubleBuffered = true;
      this.Name = "BasicPlayerUserControl";
      this.Size = new System.Drawing.Size(210, 613);
      this.Load += new System.EventHandler(this.BasicPlayerUserControl_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pictbx)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    #region form generated members
    private HorizontalLevelIndicatorLabel hlvlDef;
    private System.Windows.Forms.LinkLabel lnkLblPlayer;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private HorizontalLevelIndicatorLabel hlvlPas;
    private System.Windows.Forms.Label label3;
    private HorizontalLevelIndicatorLabel hlvlDri;
    private System.Windows.Forms.Label label4;
    private HorizontalLevelIndicatorLabel hlvlFtw;
    private System.Windows.Forms.Label label5;
    private HorizontalLevelIndicatorLabel hlvlReb;
    private System.Windows.Forms.Label label6;
    private HorizontalLevelIndicatorLabel hlvlSpe;
    private System.Windows.Forms.Label label7;
    private HorizontalLevelIndicatorLabel hlvlFT;
    private System.Windows.Forms.Label label8;
    private HorizontalLevelIndicatorLabel hlvl2p;
    private System.Windows.Forms.Label label9;
    private HorizontalLevelIndicatorLabel hlvlExp;
    private System.Windows.Forms.Label label10;
    private HorizontalLevelIndicatorLabel hlvl3p;
    private System.Windows.Forms.Label label11;
    private HorizontalLevelIndicatorLabel hlvlHeight;
    private System.Windows.Forms.Label label12;
    private HorizontalLevelIndicatorLabel hlvlWeight;
    private System.Windows.Forms.Label label13;
    private HorizontalLevelIndicatorLabel hlvlAge;
    private System.Windows.Forms.Label label14;
    private HorizontalLevelIndicatorLabel hlvlBmi;
    private System.Windows.Forms.PictureBox pictbx;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.Label lblNt;
    private System.Windows.Forms.Label lblU21;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.Label lblU18;
    private System.Windows.Forms.Label label19;
    private Label label16;
    private Label label18;
    private Label lblPosScore;
    private Label lblPosH;
    private Label lblAgeValIdx;
    private Label label20;
    private Label lblProfitability;
    private Label label23;
    private Label lblTmCompare;
    private Label lblTMVal; 
    #endregion
       

  }
}
