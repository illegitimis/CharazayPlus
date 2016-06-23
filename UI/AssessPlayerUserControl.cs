using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AndreiPopescu.CharazayPlus.UI
{
  public class AssessPlayerUserControl : UserControl
  {
    #region init
    public AssessPlayerUserControl ( )
    {
      InitializeComponent();
    }

    private void AssessPlayerUserControl_Load (object sender, EventArgs e)
    {
      this.ucEvaluatePlayer.EvaluationType = Utils.Evaluation.old;
      this.ucEvaluatePlayer2014.EvaluationType = Utils.Evaluation.season30;
    } 
    #endregion

    /// <summary>
    /// The main worker method
    /// </summary>
    /// <param name="trackBar">trackbar with scroll change</param>
    /// <param name="label">label to update</param>
    private void OnTrackBarScroll (TrackBar trackBar, Label label)
    {
      label.Text = String.Format("{0}: {1}", label.Tag, trackBar.Value);
      var p =  new Xsd2.charazayPlayer()
      {
        skills = new Xsd2.charazayPlayerSkills()
        {
          defence = (byte)this.trkbrDef.Value,
          dribling = (byte)this.trkbrDri.Value,
          experience = (byte)this.trkbrExp.Value,
          footwork = (byte)this.trkbrFtw.Value,
          freethrow = (byte)this.trkbrFre.Value,
          passing = (byte)this.trkbrPas.Value,
          rebounds = (byte)this.trkbrReb.Value,
          speed = (byte)this.trkbrSpe.Value,
          threepoint = (byte)this.trkbr3p.Value,
          twopoint = (byte)this.trkbr2p.Value
        },
        basic = new Xsd2.charazayPlayerBasic()
        {
          age = (byte)this.trkbrAge.Value,
          height = (byte)this.trkbrH.Value,
          weight = (byte)this.trkbrW.Value,
        },
        status = new Xsd2.charazayPlayerStatus() 
        {
          fatigue = this.trkbrFatigue.Value,
          form = (byte)this.trkbrForm.Value,
        }
      };
      
      this.ucEvaluatePlayer.SelectedObject = p;
      this.ucEvaluatePlayer2014.SelectedObject = p;
      //
      Player[] olds = this.ucEvaluatePlayer.Evaluator.GetPlayers().ToArray();
      var oldp = Extensions.PlayerExtensions.DecideOnTotalScore(olds);
      this.lblValOld.Text = String.Format("BEFORE SEASON 30\r\nPosition: {0}\r\nValue: {1:F02}€\r\n", oldp.PositionEnum, oldp.TransferMarketValue);
      //
      Player[] news = this.ucEvaluatePlayer2014.Evaluator.GetPlayers().ToArray();
      var newp = Extensions.PlayerExtensions.DecideOnTotalScore(news);
      this.lblValNew.Text = String.Format("AFTER SEASON 30\r\nPosition: {0}\r\nValue: {1:F02}€\r\n", newp.PositionEnum, newp.TransferMarketValue);
    }

    #region trackbar scroll events

    private void trkbrDef_Scroll (object sender, EventArgs e)
    {
      OnTrackBarScroll(sender as TrackBar, this.lblDef);
    }

    private void trkbrDri_Scroll (object sender, EventArgs e)
    {
      OnTrackBarScroll(sender as TrackBar, this.lblDri);
    }

    private void trkbrPas_Scroll (object sender, EventArgs e)
    {
      OnTrackBarScroll(sender as TrackBar, this.lblPas);
    }

    private void trkbrSpe_Scroll (object sender, EventArgs e)
    {
      OnTrackBarScroll(sender as TrackBar, this.lblSpe);
    }

    private void trkbrFtw_Scroll (object sender, EventArgs e)
    {
      OnTrackBarScroll(sender as TrackBar, this.lblFtw);
    }

    private void trkbrReb_Scroll (object sender, EventArgs e)
    {
      OnTrackBarScroll(sender as TrackBar, this.lblReb);
    }

    private void trkbrExp_Scroll (object sender, EventArgs e)
    {
      OnTrackBarScroll(sender as TrackBar, this.lblExp);
    }

    private void trkbrFre_Scroll (object sender, EventArgs e)
    {
      OnTrackBarScroll(sender as TrackBar, this.lblFt);
    }

    private void trkbr3p_Scroll (object sender, EventArgs e)
    {
      OnTrackBarScroll(sender as TrackBar, this.lbl3p);
    }

    private void trkbr2p_Scroll (object sender, EventArgs e)
    {
      OnTrackBarScroll(sender as TrackBar, this.lbl2p);
    }

    private void trkbrAge_Scroll (object sender, EventArgs e)
    {
      OnTrackBarScroll(sender as TrackBar, this.lblAge);
    }

    private void trkbrH_Scroll (object sender, EventArgs e)
    {
      OnTrackBarScroll(sender as TrackBar, this.lblH);
    }

    private void trkbrFatigue_Scroll (object sender, EventArgs e)
    {
      OnTrackBarScroll(sender as TrackBar, this.lblFatigue);
    }

    private void trkbrForm_Scroll (object sender, EventArgs e)
    {
      OnTrackBarScroll(sender as TrackBar, this.lblForm);
    }

    private void trkbrW_Scroll (object sender, EventArgs e)
    {
      OnTrackBarScroll(sender as TrackBar, this.lblW);
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
      this.tlpAssessPlayer = new System.Windows.Forms.TableLayoutPanel();
      this.trkbrForm = new System.Windows.Forms.TrackBar();
      this.lblForm = new System.Windows.Forms.Label();
      this.trkbrFatigue = new System.Windows.Forms.TrackBar();
      this.trkbrW = new System.Windows.Forms.TrackBar();
      this.lblW = new System.Windows.Forms.Label();
      this.ucEvaluatePlayer2014 = new AndreiPopescu.CharazayPlus.UI.EvaluatePlayerUserControl();
      this.trkbrDef = new System.Windows.Forms.TrackBar();
      this.lblH = new System.Windows.Forms.Label();
      this.trkbrDri = new System.Windows.Forms.TrackBar();
      this.lblAge = new System.Windows.Forms.Label();
      this.trkbrH = new System.Windows.Forms.TrackBar();
      this.lbl3p = new System.Windows.Forms.Label();
      this.trkbrPas = new System.Windows.Forms.TrackBar();
      this.lbl2p = new System.Windows.Forms.Label();
      this.trkbrSpe = new System.Windows.Forms.TrackBar();
      this.lblFt = new System.Windows.Forms.Label();
      this.trkbrAge = new System.Windows.Forms.TrackBar();
      this.lblExp = new System.Windows.Forms.Label();
      this.trkbrFtw = new System.Windows.Forms.TrackBar();
      this.lblReb = new System.Windows.Forms.Label();
      this.trkbrReb = new System.Windows.Forms.TrackBar();
      this.lblFtw = new System.Windows.Forms.Label();
      this.trkbrExp = new System.Windows.Forms.TrackBar();
      this.lblSpe = new System.Windows.Forms.Label();
      this.trkbr3p = new System.Windows.Forms.TrackBar();
      this.lblPas = new System.Windows.Forms.Label();
      this.trkbrFre = new System.Windows.Forms.TrackBar();
      this.lblDri = new System.Windows.Forms.Label();
      this.trkbr2p = new System.Windows.Forms.TrackBar();
      this.lblDef = new System.Windows.Forms.Label();
      this.ucEvaluatePlayer = new AndreiPopescu.CharazayPlus.UI.EvaluatePlayerUserControl();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.chkIsHW = new System.Windows.Forms.CheckBox();
      this.chkIsFatigue = new System.Windows.Forms.CheckBox();
      this.chkIsForm = new System.Windows.Forms.CheckBox();
      this.lblFatigue = new System.Windows.Forms.Label();
      this.lblValOld = new System.Windows.Forms.Label();
      this.lblValNew = new System.Windows.Forms.Label();
      this.tlpAssessPlayer.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrForm)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrFatigue)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrW)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrDef)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrDri)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrH)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrPas)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrSpe)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrAge)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrFtw)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrReb)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrExp)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbr3p)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrFre)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbr2p)).BeginInit();
      this.flowLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tlpAssessPlayer
      // 
      this.tlpAssessPlayer.ColumnCount = 4;
      this.tlpAssessPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tlpAssessPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
      this.tlpAssessPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tlpAssessPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
      this.tlpAssessPlayer.Controls.Add(this.trkbrForm, 3, 7);
      this.tlpAssessPlayer.Controls.Add(this.lblForm, 2, 7);
      this.tlpAssessPlayer.Controls.Add(this.trkbrFatigue, 3, 0);
      this.tlpAssessPlayer.Controls.Add(this.trkbrW, 3, 1);
      this.tlpAssessPlayer.Controls.Add(this.lblW, 2, 1);
      this.tlpAssessPlayer.Controls.Add(this.ucEvaluatePlayer2014, 1, 9);
      this.tlpAssessPlayer.Controls.Add(this.trkbrDef, 1, 2);
      this.tlpAssessPlayer.Controls.Add(this.lblH, 0, 1);
      this.tlpAssessPlayer.Controls.Add(this.trkbrDri, 1, 4);
      this.tlpAssessPlayer.Controls.Add(this.lblAge, 0, 0);
      this.tlpAssessPlayer.Controls.Add(this.trkbrH, 1, 1);
      this.tlpAssessPlayer.Controls.Add(this.lbl3p, 2, 3);
      this.tlpAssessPlayer.Controls.Add(this.trkbrPas, 3, 4);
      this.tlpAssessPlayer.Controls.Add(this.lbl2p, 0, 3);
      this.tlpAssessPlayer.Controls.Add(this.trkbrSpe, 1, 5);
      this.tlpAssessPlayer.Controls.Add(this.lblFt, 2, 2);
      this.tlpAssessPlayer.Controls.Add(this.trkbrAge, 1, 0);
      this.tlpAssessPlayer.Controls.Add(this.lblExp, 2, 6);
      this.tlpAssessPlayer.Controls.Add(this.trkbrFtw, 3, 5);
      this.tlpAssessPlayer.Controls.Add(this.lblReb, 0, 6);
      this.tlpAssessPlayer.Controls.Add(this.trkbrReb, 1, 6);
      this.tlpAssessPlayer.Controls.Add(this.lblFtw, 2, 5);
      this.tlpAssessPlayer.Controls.Add(this.trkbrExp, 3, 6);
      this.tlpAssessPlayer.Controls.Add(this.lblSpe, 0, 5);
      this.tlpAssessPlayer.Controls.Add(this.trkbr3p, 3, 3);
      this.tlpAssessPlayer.Controls.Add(this.lblPas, 2, 4);
      this.tlpAssessPlayer.Controls.Add(this.trkbrFre, 3, 2);
      this.tlpAssessPlayer.Controls.Add(this.lblDri, 0, 4);
      this.tlpAssessPlayer.Controls.Add(this.trkbr2p, 1, 3);
      this.tlpAssessPlayer.Controls.Add(this.lblDef, 0, 2);
      this.tlpAssessPlayer.Controls.Add(this.ucEvaluatePlayer, 1, 8);
      this.tlpAssessPlayer.Controls.Add(this.flowLayoutPanel1, 0, 7);
      this.tlpAssessPlayer.Controls.Add(this.lblFatigue, 2, 0);
      this.tlpAssessPlayer.Controls.Add(this.lblValOld, 0, 8);
      this.tlpAssessPlayer.Controls.Add(this.lblValNew, 0, 9);
      this.tlpAssessPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tlpAssessPlayer.Location = new System.Drawing.Point(0, 0);
      this.tlpAssessPlayer.Name = "tlpAssessPlayer";
      this.tlpAssessPlayer.RowCount = 10;
      this.tlpAssessPlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
      this.tlpAssessPlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
      this.tlpAssessPlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
      this.tlpAssessPlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
      this.tlpAssessPlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
      this.tlpAssessPlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
      this.tlpAssessPlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
      this.tlpAssessPlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
      this.tlpAssessPlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tlpAssessPlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tlpAssessPlayer.Size = new System.Drawing.Size(744, 564);
      this.tlpAssessPlayer.TabIndex = 26;
      // 
      // trkbrForm
      // 
      this.trkbrForm.CausesValidation = false;
      this.trkbrForm.Dock = System.Windows.Forms.DockStyle.Fill;
      this.trkbrForm.LargeChange = 2;
      this.trkbrForm.Location = new System.Drawing.Point(448, 318);
      this.trkbrForm.Maximum = 8;
      this.trkbrForm.Minimum = 1;
      this.trkbrForm.Name = "trkbrForm";
      this.trkbrForm.Size = new System.Drawing.Size(293, 49);
      this.trkbrForm.TabIndex = 34;
      this.trkbrForm.Value = 1;
      this.trkbrForm.Scroll += new System.EventHandler(this.trkbrForm_Scroll);
      // 
      // lblForm
      // 
      this.lblForm.AutoSize = true;
      this.lblForm.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblForm.Location = new System.Drawing.Point(374, 315);
      this.lblForm.Name = "lblForm";
      this.lblForm.Size = new System.Drawing.Size(68, 55);
      this.lblForm.TabIndex = 33;
      this.lblForm.Tag = "Form";
      this.lblForm.Text = "Form";
      // 
      // trkbrFatigue
      // 
      this.trkbrFatigue.CausesValidation = false;
      this.trkbrFatigue.Dock = System.Windows.Forms.DockStyle.Fill;
      this.trkbrFatigue.Location = new System.Drawing.Point(448, 3);
      this.trkbrFatigue.Maximum = 100;
      this.trkbrFatigue.Name = "trkbrFatigue";
      this.trkbrFatigue.Size = new System.Drawing.Size(293, 39);
      this.trkbrFatigue.TabIndex = 32;
      this.trkbrFatigue.TickFrequency = 2;
      this.trkbrFatigue.Scroll += new System.EventHandler(this.trkbrFatigue_Scroll);
      // 
      // trkbrW
      // 
      this.trkbrW.CausesValidation = false;
      this.trkbrW.Dock = System.Windows.Forms.DockStyle.Fill;
      this.trkbrW.Location = new System.Drawing.Point(448, 48);
      this.trkbrW.Maximum = 160;
      this.trkbrW.Minimum = 50;
      this.trkbrW.Name = "trkbrW";
      this.trkbrW.Size = new System.Drawing.Size(293, 39);
      this.trkbrW.TabIndex = 28;
      this.trkbrW.TickFrequency = 2;
      this.trkbrW.Value = 50;
      this.trkbrW.Scroll += new System.EventHandler(this.trkbrW_Scroll);
      // 
      // lblW
      // 
      this.lblW.AutoSize = true;
      this.lblW.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblW.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblW.Location = new System.Drawing.Point(374, 45);
      this.lblW.Name = "lblW";
      this.lblW.Size = new System.Drawing.Size(68, 45);
      this.lblW.TabIndex = 27;
      this.lblW.Tag = "Weight";
      this.lblW.Text = "Weight";
      // 
      // ucEvaluatePlayer2014
      // 
      this.ucEvaluatePlayer2014.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucEvaluatePlayer2014.BackColor = System.Drawing.Color.DimGray;
      this.ucEvaluatePlayer2014.CausesValidation = false;
      this.tlpAssessPlayer.SetColumnSpan(this.ucEvaluatePlayer2014, 3);
      this.ucEvaluatePlayer2014.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucEvaluatePlayer2014.ForeColor = System.Drawing.Color.White;
      this.ucEvaluatePlayer2014.IsFatigue = false;
      this.ucEvaluatePlayer2014.IsForm = false;
      this.ucEvaluatePlayer2014.IsHeightWeightImpact = false;
      this.ucEvaluatePlayer2014.Location = new System.Drawing.Point(77, 470);
      this.ucEvaluatePlayer2014.Name = "ucEvaluatePlayer2014";
      this.ucEvaluatePlayer2014.SelectedObject = null;
      this.ucEvaluatePlayer2014.Size = new System.Drawing.Size(664, 91);
      this.ucEvaluatePlayer2014.TabIndex = 26;
      // 
      // trkbrDef
      // 
      this.trkbrDef.CausesValidation = false;
      this.trkbrDef.Dock = System.Windows.Forms.DockStyle.Fill;
      this.trkbrDef.Location = new System.Drawing.Point(77, 93);
      this.trkbrDef.Maximum = 30;
      this.trkbrDef.Minimum = 1;
      this.trkbrDef.Name = "trkbrDef";
      this.trkbrDef.Size = new System.Drawing.Size(291, 39);
      this.trkbrDef.TabIndex = 0;
      this.trkbrDef.Value = 1;
      this.trkbrDef.Scroll += new System.EventHandler(this.trkbrDef_Scroll);
      // 
      // lblH
      // 
      this.lblH.AutoSize = true;
      this.lblH.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblH.Location = new System.Drawing.Point(3, 45);
      this.lblH.Name = "lblH";
      this.lblH.Size = new System.Drawing.Size(68, 45);
      this.lblH.TabIndex = 24;
      this.lblH.Tag = "Height";
      this.lblH.Text = "Height";
      // 
      // trkbrDri
      // 
      this.trkbrDri.CausesValidation = false;
      this.trkbrDri.Dock = System.Windows.Forms.DockStyle.Fill;
      this.trkbrDri.Location = new System.Drawing.Point(77, 183);
      this.trkbrDri.Maximum = 30;
      this.trkbrDri.Minimum = 1;
      this.trkbrDri.Name = "trkbrDri";
      this.trkbrDri.Size = new System.Drawing.Size(291, 39);
      this.trkbrDri.TabIndex = 2;
      this.trkbrDri.Value = 1;
      this.trkbrDri.Scroll += new System.EventHandler(this.trkbrDri_Scroll);
      // 
      // lblAge
      // 
      this.lblAge.AutoSize = true;
      this.lblAge.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblAge.Location = new System.Drawing.Point(3, 0);
      this.lblAge.Name = "lblAge";
      this.lblAge.Size = new System.Drawing.Size(68, 45);
      this.lblAge.TabIndex = 22;
      this.lblAge.Tag = "Age";
      this.lblAge.Text = "Age";
      // 
      // trkbrH
      // 
      this.trkbrH.CausesValidation = false;
      this.trkbrH.Dock = System.Windows.Forms.DockStyle.Fill;
      this.trkbrH.Location = new System.Drawing.Point(77, 48);
      this.trkbrH.Maximum = 230;
      this.trkbrH.Minimum = 160;
      this.trkbrH.Name = "trkbrH";
      this.trkbrH.Size = new System.Drawing.Size(291, 39);
      this.trkbrH.TabIndex = 23;
      this.trkbrH.TickFrequency = 2;
      this.trkbrH.Value = 160;
      this.trkbrH.Scroll += new System.EventHandler(this.trkbrH_Scroll);
      // 
      // lbl3p
      // 
      this.lbl3p.AutoSize = true;
      this.lbl3p.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lbl3p.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lbl3p.Location = new System.Drawing.Point(374, 135);
      this.lbl3p.Name = "lbl3p";
      this.lbl3p.Size = new System.Drawing.Size(68, 45);
      this.lbl3p.TabIndex = 20;
      this.lbl3p.Tag = "Three Point";
      this.lbl3p.Text = "Three Point";
      // 
      // trkbrPas
      // 
      this.trkbrPas.CausesValidation = false;
      this.trkbrPas.Dock = System.Windows.Forms.DockStyle.Fill;
      this.trkbrPas.Location = new System.Drawing.Point(448, 183);
      this.trkbrPas.Maximum = 30;
      this.trkbrPas.Minimum = 1;
      this.trkbrPas.Name = "trkbrPas";
      this.trkbrPas.Size = new System.Drawing.Size(293, 39);
      this.trkbrPas.TabIndex = 4;
      this.trkbrPas.Value = 1;
      this.trkbrPas.Scroll += new System.EventHandler(this.trkbrPas_Scroll);
      // 
      // lbl2p
      // 
      this.lbl2p.AutoSize = true;
      this.lbl2p.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lbl2p.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lbl2p.Location = new System.Drawing.Point(3, 135);
      this.lbl2p.Name = "lbl2p";
      this.lbl2p.Size = new System.Drawing.Size(68, 45);
      this.lbl2p.TabIndex = 18;
      this.lbl2p.Tag = "Two Point";
      this.lbl2p.Text = "Two Point";
      // 
      // trkbrSpe
      // 
      this.trkbrSpe.CausesValidation = false;
      this.trkbrSpe.Dock = System.Windows.Forms.DockStyle.Fill;
      this.trkbrSpe.Location = new System.Drawing.Point(77, 228);
      this.trkbrSpe.Maximum = 30;
      this.trkbrSpe.Minimum = 1;
      this.trkbrSpe.Name = "trkbrSpe";
      this.trkbrSpe.Size = new System.Drawing.Size(291, 39);
      this.trkbrSpe.TabIndex = 6;
      this.trkbrSpe.Value = 1;
      this.trkbrSpe.Scroll += new System.EventHandler(this.trkbrSpe_Scroll);
      // 
      // lblFt
      // 
      this.lblFt.AutoSize = true;
      this.lblFt.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblFt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblFt.Location = new System.Drawing.Point(374, 90);
      this.lblFt.Name = "lblFt";
      this.lblFt.Size = new System.Drawing.Size(68, 45);
      this.lblFt.TabIndex = 15;
      this.lblFt.Tag = "Free Throws";
      this.lblFt.Text = "Free Throws";
      // 
      // trkbrAge
      // 
      this.trkbrAge.CausesValidation = false;
      this.trkbrAge.Dock = System.Windows.Forms.DockStyle.Fill;
      this.trkbrAge.Location = new System.Drawing.Point(77, 3);
      this.trkbrAge.Maximum = 40;
      this.trkbrAge.Minimum = 15;
      this.trkbrAge.Name = "trkbrAge";
      this.trkbrAge.Size = new System.Drawing.Size(291, 39);
      this.trkbrAge.TabIndex = 21;
      this.trkbrAge.Value = 15;
      this.trkbrAge.Scroll += new System.EventHandler(this.trkbrAge_Scroll);
      // 
      // lblExp
      // 
      this.lblExp.AutoSize = true;
      this.lblExp.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblExp.Location = new System.Drawing.Point(374, 270);
      this.lblExp.Name = "lblExp";
      this.lblExp.Size = new System.Drawing.Size(68, 45);
      this.lblExp.TabIndex = 13;
      this.lblExp.Tag = "Experience";
      this.lblExp.Text = "Experience";
      // 
      // trkbrFtw
      // 
      this.trkbrFtw.CausesValidation = false;
      this.trkbrFtw.Dock = System.Windows.Forms.DockStyle.Fill;
      this.trkbrFtw.Location = new System.Drawing.Point(448, 228);
      this.trkbrFtw.Maximum = 30;
      this.trkbrFtw.Minimum = 1;
      this.trkbrFtw.Name = "trkbrFtw";
      this.trkbrFtw.Size = new System.Drawing.Size(293, 39);
      this.trkbrFtw.TabIndex = 8;
      this.trkbrFtw.Value = 1;
      this.trkbrFtw.Scroll += new System.EventHandler(this.trkbrFtw_Scroll);
      // 
      // lblReb
      // 
      this.lblReb.AutoSize = true;
      this.lblReb.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblReb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblReb.Location = new System.Drawing.Point(3, 270);
      this.lblReb.Name = "lblReb";
      this.lblReb.Size = new System.Drawing.Size(68, 45);
      this.lblReb.TabIndex = 11;
      this.lblReb.Tag = "Rebounds";
      this.lblReb.Text = "Rebounds";
      // 
      // trkbrReb
      // 
      this.trkbrReb.CausesValidation = false;
      this.trkbrReb.Dock = System.Windows.Forms.DockStyle.Fill;
      this.trkbrReb.Location = new System.Drawing.Point(77, 273);
      this.trkbrReb.Maximum = 30;
      this.trkbrReb.Minimum = 1;
      this.trkbrReb.Name = "trkbrReb";
      this.trkbrReb.Size = new System.Drawing.Size(291, 39);
      this.trkbrReb.TabIndex = 10;
      this.trkbrReb.Value = 1;
      this.trkbrReb.Scroll += new System.EventHandler(this.trkbrReb_Scroll);
      // 
      // lblFtw
      // 
      this.lblFtw.AutoSize = true;
      this.lblFtw.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblFtw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblFtw.Location = new System.Drawing.Point(374, 225);
      this.lblFtw.Name = "lblFtw";
      this.lblFtw.Size = new System.Drawing.Size(68, 45);
      this.lblFtw.TabIndex = 9;
      this.lblFtw.Tag = "Footwork";
      this.lblFtw.Text = "Footwork";
      // 
      // trkbrExp
      // 
      this.trkbrExp.CausesValidation = false;
      this.trkbrExp.Dock = System.Windows.Forms.DockStyle.Fill;
      this.trkbrExp.Location = new System.Drawing.Point(448, 273);
      this.trkbrExp.Maximum = 30;
      this.trkbrExp.Name = "trkbrExp";
      this.trkbrExp.Size = new System.Drawing.Size(293, 39);
      this.trkbrExp.TabIndex = 12;
      this.trkbrExp.Scroll += new System.EventHandler(this.trkbrExp_Scroll);
      // 
      // lblSpe
      // 
      this.lblSpe.AutoSize = true;
      this.lblSpe.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblSpe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblSpe.Location = new System.Drawing.Point(3, 225);
      this.lblSpe.Name = "lblSpe";
      this.lblSpe.Size = new System.Drawing.Size(68, 45);
      this.lblSpe.TabIndex = 7;
      this.lblSpe.Tag = "Speed";
      this.lblSpe.Text = "Speed";
      // 
      // trkbr3p
      // 
      this.trkbr3p.CausesValidation = false;
      this.trkbr3p.Dock = System.Windows.Forms.DockStyle.Fill;
      this.trkbr3p.Location = new System.Drawing.Point(448, 138);
      this.trkbr3p.Maximum = 30;
      this.trkbr3p.Minimum = 1;
      this.trkbr3p.Name = "trkbr3p";
      this.trkbr3p.Size = new System.Drawing.Size(293, 39);
      this.trkbr3p.TabIndex = 17;
      this.trkbr3p.Value = 1;
      this.trkbr3p.Scroll += new System.EventHandler(this.trkbr3p_Scroll);
      // 
      // lblPas
      // 
      this.lblPas.AutoSize = true;
      this.lblPas.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblPas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblPas.Location = new System.Drawing.Point(374, 180);
      this.lblPas.Name = "lblPas";
      this.lblPas.Size = new System.Drawing.Size(68, 45);
      this.lblPas.TabIndex = 5;
      this.lblPas.Tag = "Passing";
      this.lblPas.Text = "Passing";
      // 
      // trkbrFre
      // 
      this.trkbrFre.CausesValidation = false;
      this.trkbrFre.Dock = System.Windows.Forms.DockStyle.Fill;
      this.trkbrFre.Location = new System.Drawing.Point(448, 93);
      this.trkbrFre.Maximum = 30;
      this.trkbrFre.Minimum = 1;
      this.trkbrFre.Name = "trkbrFre";
      this.trkbrFre.Size = new System.Drawing.Size(293, 39);
      this.trkbrFre.TabIndex = 14;
      this.trkbrFre.Value = 1;
      this.trkbrFre.Scroll += new System.EventHandler(this.trkbrFre_Scroll);
      // 
      // lblDri
      // 
      this.lblDri.AutoSize = true;
      this.lblDri.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblDri.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblDri.Location = new System.Drawing.Point(3, 180);
      this.lblDri.Name = "lblDri";
      this.lblDri.Size = new System.Drawing.Size(68, 45);
      this.lblDri.TabIndex = 3;
      this.lblDri.Tag = "Dribbling";
      this.lblDri.Text = "Dribbling";
      // 
      // trkbr2p
      // 
      this.trkbr2p.CausesValidation = false;
      this.trkbr2p.Dock = System.Windows.Forms.DockStyle.Fill;
      this.trkbr2p.Location = new System.Drawing.Point(77, 138);
      this.trkbr2p.Maximum = 30;
      this.trkbr2p.Minimum = 1;
      this.trkbr2p.Name = "trkbr2p";
      this.trkbr2p.Size = new System.Drawing.Size(291, 39);
      this.trkbr2p.TabIndex = 16;
      this.trkbr2p.Value = 1;
      this.trkbr2p.Scroll += new System.EventHandler(this.trkbr2p_Scroll);
      // 
      // lblDef
      // 
      this.lblDef.AutoSize = true;
      this.lblDef.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblDef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblDef.Location = new System.Drawing.Point(3, 90);
      this.lblDef.Name = "lblDef";
      this.lblDef.Size = new System.Drawing.Size(68, 45);
      this.lblDef.TabIndex = 1;
      this.lblDef.Tag = "Defense";
      this.lblDef.Text = "Defense";
      // 
      // ucEvaluatePlayer
      // 
      this.ucEvaluatePlayer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucEvaluatePlayer.BackColor = System.Drawing.Color.DimGray;
      this.ucEvaluatePlayer.CausesValidation = false;
      this.tlpAssessPlayer.SetColumnSpan(this.ucEvaluatePlayer, 3);
      this.ucEvaluatePlayer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucEvaluatePlayer.ForeColor = System.Drawing.Color.White;
      this.ucEvaluatePlayer.IsFatigue = false;
      this.ucEvaluatePlayer.IsForm = false;
      this.ucEvaluatePlayer.IsHeightWeightImpact = false;
      this.ucEvaluatePlayer.Location = new System.Drawing.Point(77, 373);
      this.ucEvaluatePlayer.Name = "ucEvaluatePlayer";
      this.ucEvaluatePlayer.SelectedObject = null;
      this.ucEvaluatePlayer.Size = new System.Drawing.Size(664, 91);
      this.ucEvaluatePlayer.TabIndex = 25;
      // 
      // flowLayoutPanel1
      // 
      this.tlpAssessPlayer.SetColumnSpan(this.flowLayoutPanel1, 2);
      this.flowLayoutPanel1.Controls.Add(this.chkIsHW);
      this.flowLayoutPanel1.Controls.Add(this.chkIsFatigue);
      this.flowLayoutPanel1.Controls.Add(this.chkIsForm);
      this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 318);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(365, 49);
      this.flowLayoutPanel1.TabIndex = 30;
      // 
      // chkIsHW
      // 
      this.chkIsHW.AutoSize = true;
      this.chkIsHW.Dock = System.Windows.Forms.DockStyle.Fill;
      this.chkIsHW.Location = new System.Drawing.Point(3, 3);
      this.chkIsHW.Name = "chkIsHW";
      this.chkIsHW.Size = new System.Drawing.Size(231, 17);
      this.chkIsHW.TabIndex = 30;
      this.chkIsHW.Text = "Height and Weight Impact on Active Skills?";
      this.chkIsHW.UseVisualStyleBackColor = true;
      this.chkIsHW.CheckedChanged += new System.EventHandler(this.chkIsHW_CheckedChanged);
      // 
      // chkIsFatigue
      // 
      this.chkIsFatigue.AutoSize = true;
      this.chkIsFatigue.Dock = System.Windows.Forms.DockStyle.Fill;
      this.chkIsFatigue.Location = new System.Drawing.Point(3, 26);
      this.chkIsFatigue.Name = "chkIsFatigue";
      this.chkIsFatigue.Size = new System.Drawing.Size(182, 17);
      this.chkIsFatigue.TabIndex = 31;
      this.chkIsFatigue.Text = "Take Fatigue into Consideration?";
      this.chkIsFatigue.UseVisualStyleBackColor = true;
      this.chkIsFatigue.CheckedChanged += new System.EventHandler(this.chkIsFatigue_CheckedChanged);
      // 
      // chkIsForm
      // 
      this.chkIsForm.AutoSize = true;
      this.chkIsForm.Dock = System.Windows.Forms.DockStyle.Fill;
      this.chkIsForm.Location = new System.Drawing.Point(191, 26);
      this.chkIsForm.Name = "chkIsForm";
      this.chkIsForm.Size = new System.Drawing.Size(170, 17);
      this.chkIsForm.TabIndex = 32;
      this.chkIsForm.Text = "Take Form into Consideration?";
      this.chkIsForm.UseVisualStyleBackColor = true;
      this.chkIsForm.CheckedChanged += new System.EventHandler(this.chkIsForm_CheckedChanged);
      // 
      // lblFatigue
      // 
      this.lblFatigue.AutoSize = true;
      this.lblFatigue.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblFatigue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblFatigue.Location = new System.Drawing.Point(374, 0);
      this.lblFatigue.Name = "lblFatigue";
      this.lblFatigue.Size = new System.Drawing.Size(68, 45);
      this.lblFatigue.TabIndex = 31;
      this.lblFatigue.Tag = "Fatigue";
      this.lblFatigue.Text = "Fatigue";
      // 
      // lblValOld
      // 
      this.lblValOld.AutoSize = true;
      this.lblValOld.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblValOld.Location = new System.Drawing.Point(3, 370);
      this.lblValOld.Name = "lblValOld";
      this.lblValOld.Size = new System.Drawing.Size(0, 15);
      this.lblValOld.TabIndex = 35;
      // 
      // lblValNew
      // 
      this.lblValNew.AutoSize = true;
      this.lblValNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblValNew.Location = new System.Drawing.Point(3, 467);
      this.lblValNew.Name = "lblValNew";
      this.lblValNew.Size = new System.Drawing.Size(0, 15);
      this.lblValNew.TabIndex = 36;
      // 
      // AssessPlayerUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tlpAssessPlayer);
      this.DoubleBuffered = true;
      this.Name = "AssessPlayerUserControl";
      this.Size = new System.Drawing.Size(744, 564);
      this.Load += new System.EventHandler(this.AssessPlayerUserControl_Load);
      this.tlpAssessPlayer.ResumeLayout(false);
      this.tlpAssessPlayer.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrForm)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrFatigue)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrW)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrDef)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrDri)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrH)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrPas)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrSpe)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrAge)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrFtw)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrReb)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrExp)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbr3p)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbrFre)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkbr2p)).EndInit();
      this.flowLayoutPanel1.ResumeLayout(false);
      this.flowLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    #region generate member fields
    private Label lblValOld;
    private Label lblValNew;
    private Label lblW;
    private Label lblAge;
    private TrackBar trkbrW;
    private FlowLayoutPanel flowLayoutPanel1;
    private CheckBox chkIsHW;
    private CheckBox chkIsFatigue;
    private CheckBox chkIsForm;
    private Label lblFatigue;
    private TrackBar trkbrFatigue;
    private Label lblForm;
    private TrackBar trkbrForm;
    private System.Windows.Forms.TableLayoutPanel tlpAssessPlayer;
    private EvaluatePlayerUserControl ucEvaluatePlayer2014;
    private System.Windows.Forms.TrackBar trkbrDef;
    private System.Windows.Forms.Label lblH;
    private System.Windows.Forms.TrackBar trkbrDri;
    private System.Windows.Forms.TrackBar trkbrH;
    private System.Windows.Forms.Label lbl3p;
    private System.Windows.Forms.TrackBar trkbrPas;
    private System.Windows.Forms.Label lbl2p;
    private System.Windows.Forms.TrackBar trkbrSpe;
    private System.Windows.Forms.Label lblFt;
    private System.Windows.Forms.TrackBar trkbrAge;
    private System.Windows.Forms.Label lblExp;
    private System.Windows.Forms.TrackBar trkbrFtw;
    private System.Windows.Forms.Label lblReb;
    private System.Windows.Forms.TrackBar trkbrReb;
    private System.Windows.Forms.Label lblFtw;
    private System.Windows.Forms.TrackBar trkbrExp;
    private System.Windows.Forms.Label lblSpe;
    private System.Windows.Forms.TrackBar trkbr3p;
    private System.Windows.Forms.Label lblPas;
    private System.Windows.Forms.TrackBar trkbrFre;
    private System.Windows.Forms.Label lblDri;
    private System.Windows.Forms.TrackBar trkbr2p;
    private System.Windows.Forms.Label lblDef;
    private EvaluatePlayerUserControl ucEvaluatePlayer;
    #endregion

    #region checks
    private void chkIsHW_CheckedChanged (object sender, EventArgs e)
    {
      this.ucEvaluatePlayer.IsHeightWeightImpact = this.chkIsHW.Checked;
      this.ucEvaluatePlayer2014.IsHeightWeightImpact = this.chkIsHW.Checked;
    }

    private void chkIsFatigue_CheckedChanged (object sender, EventArgs e)
    {
      this.ucEvaluatePlayer.IsFatigue = this.chkIsFatigue.Checked;
      this.ucEvaluatePlayer2014.IsFatigue = this.chkIsFatigue.Checked;
    }

    private void chkIsForm_CheckedChanged (object sender, EventArgs e)
    {
      this.ucEvaluatePlayer.IsForm = this.chkIsForm.Checked;
      this.ucEvaluatePlayer2014.IsForm = this.chkIsForm.Checked;
    } 
    #endregion

   
  }
}
