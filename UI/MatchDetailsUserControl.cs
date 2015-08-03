
namespace AndreiPopescu.CharazayPlus.UI
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Drawing;
  using System.Data;
  using System.Text;
  using System.Windows.Forms;
  using AndreiPopescu.CharazayPlus.Utils;

  public partial class MatchDetailsUserControl : UserControl
  {
    public MatchDetailsUserControl()
    {
      InitializeComponent();      
    }

    public void SetData (Xsd2.match m)
    {
      label1.Text = m.HomeTeamName;
      label2.Text = m.homescore.ToString();

      label5.Text = m.AwayTeamName;
      label4.Text = m.awayscore.ToString();

      label9.Text = ((MatchType)m.type).ToString();
      label7.Text = m.spectators.ToString();
      label11.Text = m.vips.ToString();
      //
      CacheManager.Instance.AddTeam(m.teams.hometeam, m.HomeTeamName);
      CacheManager.Instance.AddTeam(m.teams.awayteam, m.AwayTeamName);
      //
      CacheManager.Instance.AddMatch(m);
    }

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
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.lblVips = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.lblSpectators = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.lblType = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.flowMatchDetails = new System.Windows.Forms.FlowLayoutPanel();
      this.flowMatchDetails.SuspendLayout();
      this.SuspendLayout();
      // 
      // _lblTitle
      // 
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.Color.Transparent;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(3, 0);
      this.label1.Name = "_lblTitle";
      this.label1.Size = new System.Drawing.Size(0, 13);
      this.label1.TabIndex = 0;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label2.ForeColor = System.Drawing.Color.Red;
      this.label2.Location = new System.Drawing.Point(9, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(0, 13);
      this.label2.TabIndex = 1;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label4.ForeColor = System.Drawing.Color.Red;
      this.label4.Location = new System.Drawing.Point(31, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(0, 13);
      this.label4.TabIndex = 3;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.BackColor = System.Drawing.Color.Transparent;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(37, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(0, 13);
      this.label5.TabIndex = 4;
      // 
      // lblVips
      // 
      this.lblVips.AutoSize = true;
      this.lblVips.BackColor = System.Drawing.Color.Black;
      this.lblVips.ForeColor = System.Drawing.Color.White;
      this.lblVips.Location = new System.Drawing.Point(244, 0);
      this.lblVips.Name = "lblVips";
      this.lblVips.Size = new System.Drawing.Size(30, 13);
      this.lblVips.TabIndex = 9;
      this.lblVips.Text = "Vips:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(197, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(41, 13);
      this.label7.TabIndex = 8;
      this.label7.Text = "label7";
      // 
      // lblSpectators
      // 
      this.lblSpectators.AutoSize = true;
      this.lblSpectators.BackColor = System.Drawing.Color.Black;
      this.lblSpectators.ForeColor = System.Drawing.Color.White;
      this.lblSpectators.Location = new System.Drawing.Point(130, 0);
      this.lblSpectators.Name = "lblSpectators";
      this.lblSpectators.Size = new System.Drawing.Size(61, 13);
      this.lblSpectators.TabIndex = 7;
      this.lblSpectators.Text = "Spectators:";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label9.Location = new System.Drawing.Point(83, 0);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(41, 13);
      this.label9.TabIndex = 6;
      this.label9.Text = "label9";
      // 
      // lblType
      // 
      this.lblType.AutoSize = true;
      this.lblType.BackColor = System.Drawing.Color.Black;
      this.lblType.ForeColor = System.Drawing.Color.White;
      this.lblType.Location = new System.Drawing.Point(43, 0);
      this.lblType.Name = "lblType";
      this.lblType.Size = new System.Drawing.Size(34, 13);
      this.lblType.TabIndex = 5;
      this.lblType.Text = "Type:";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.BackColor = System.Drawing.Color.Transparent;
      this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label11.Location = new System.Drawing.Point(280, 0);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(48, 13);
      this.label11.TabIndex = 10;
      this.label11.Text = "label11";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(15, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(10, 13);
      this.label3.TabIndex = 11;
      this.label3.Text = "-";
      // 
      // flowMatchDetails
      // 
      this.flowMatchDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.flowMatchDetails.Controls.Add(this.label1);
      this.flowMatchDetails.Controls.Add(this.label2);
      this.flowMatchDetails.Controls.Add(this.label3);
      this.flowMatchDetails.Controls.Add(this.label4);
      this.flowMatchDetails.Controls.Add(this.label5);
      this.flowMatchDetails.Controls.Add(this.lblType);
      this.flowMatchDetails.Controls.Add(this.label9);
      this.flowMatchDetails.Controls.Add(this.lblSpectators);
      this.flowMatchDetails.Controls.Add(this.label7);
      this.flowMatchDetails.Controls.Add(this.lblVips);
      this.flowMatchDetails.Controls.Add(this.label11);
      this.flowMatchDetails.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flowMatchDetails.Location = new System.Drawing.Point(0, 0);
      this.flowMatchDetails.Name = "flowMatchDetails";
      this.flowMatchDetails.Size = new System.Drawing.Size(509, 23);
      this.flowMatchDetails.TabIndex = 12;
      // 
      // MatchDetailsUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
      this.CausesValidation = false;
      this.Controls.Add(this.flowMatchDetails);
      this.DoubleBuffered = true;
      this.Name = "MatchDetailsUserControl";
      this.Size = new System.Drawing.Size(509, 23);
      this.flowMatchDetails.ResumeLayout(false);
      this.flowMatchDetails.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label lblVips;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label lblSpectators;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label lblType;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.FlowLayoutPanel flowMatchDetails;

    [DefaultValue(FlowDirection.LeftToRight), Description("Flow Direction"), Category("Appearance"), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
    public FlowDirection FlowDirection
    {
      get { return this.flowMatchDetails.FlowDirection; }
      set { this.flowMatchDetails.FlowDirection = value; }
    }
  }
}
