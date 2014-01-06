namespace AndreiPopescu.CharazayPlus.UI
{
  partial class MyEconomyUserControl
  {
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent ( )
    {
      this.splitEconomy = new System.Windows.Forms.SplitContainer();
      this.label54 = new System.Windows.Forms.Label();
      this.dgTeamTransfers = new System.Windows.Forms.DataGridView();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.ucEconomyWeek = new AndreiPopescu.CharazayPlus.EconomyUserControl();
      this.ucEconomySeason = new AndreiPopescu.CharazayPlus.EconomyUserControl();
      this.splitEconomy.Panel1.SuspendLayout();
      this.splitEconomy.Panel2.SuspendLayout();
      this.splitEconomy.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgTeamTransfers)).BeginInit();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitEconomy
      // 
      this.splitEconomy.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitEconomy.Location = new System.Drawing.Point(0, 0);
      this.splitEconomy.Name = "splitEconomy";
      // 
      // splitEconomy.Panel1
      // 
      this.splitEconomy.Panel1.Controls.Add(this.label54);
      this.splitEconomy.Panel1.Controls.Add(this.dgTeamTransfers);
      // 
      // splitEconomy.Panel2
      // 
      this.splitEconomy.Panel2.Controls.Add(this.splitContainer2);
      this.splitEconomy.Size = new System.Drawing.Size(586, 449);
      this.splitEconomy.SplitterDistance = 271;
      this.splitEconomy.TabIndex = 2;
      // 
      // label54
      // 
      this.label54.AutoSize = true;
      this.label54.Location = new System.Drawing.Point(4, 9);
      this.label54.Name = "label54";
      this.label54.Size = new System.Drawing.Size(98, 13);
      this.label54.TabIndex = 1;
      this.label54.Text = "My Team Transfers";
      // 
      // dgTeamTransfers
      // 
      this.dgTeamTransfers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgTeamTransfers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.dgTeamTransfers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
      this.dgTeamTransfers.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.dgTeamTransfers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgTeamTransfers.Location = new System.Drawing.Point(7, 25);
      this.dgTeamTransfers.Name = "dgTeamTransfers";
      this.dgTeamTransfers.Size = new System.Drawing.Size(1350, 1502);
      this.dgTeamTransfers.TabIndex = 0;
      // 
      // splitContainer2
      // 
      this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer2.Location = new System.Drawing.Point(0, 0);
      this.splitContainer2.Name = "splitContainer2";
      this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this.ucEconomyWeek);
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.ucEconomySeason);
      this.splitContainer2.Size = new System.Drawing.Size(311, 449);
      this.splitContainer2.SplitterDistance = 198;
      this.splitContainer2.TabIndex = 0;
      // 
      // ucEconomyWeek
      // 
      this.ucEconomyWeek.AutoSize = true;
      this.ucEconomyWeek.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucEconomyWeek.Location = new System.Drawing.Point(0, 0);
      this.ucEconomyWeek.Name = "ucEconomyWeek";
      this.ucEconomyWeek.Size = new System.Drawing.Size(300, 130);
      this.ucEconomyWeek.TabIndex = 0;
      // 
      // ucEconomySeason
      // 
      this.ucEconomySeason.AutoSize = true;
      this.ucEconomySeason.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucEconomySeason.Location = new System.Drawing.Point(0, 0);
      this.ucEconomySeason.Name = "ucEconomySeason";
      this.ucEconomySeason.Size = new System.Drawing.Size(300, 130);
      this.ucEconomySeason.TabIndex = 0;
      // 
      // MyEconomyUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitEconomy);
      this.Name = "MyEconomyUserControl";
      this.Size = new System.Drawing.Size(586, 449);
      this.splitEconomy.Panel1.ResumeLayout(false);
      this.splitEconomy.Panel1.PerformLayout();
      this.splitEconomy.Panel2.ResumeLayout(false);
      this.splitEconomy.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgTeamTransfers)).EndInit();
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel1.PerformLayout();
      this.splitContainer2.Panel2.ResumeLayout(false);
      this.splitContainer2.Panel2.PerformLayout();
      this.splitContainer2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitEconomy;
    private System.Windows.Forms.Label label54;
    private System.Windows.Forms.DataGridView dgTeamTransfers;
    private System.Windows.Forms.SplitContainer splitContainer2;
    private EconomyUserControl ucEconomyWeek;
    private EconomyUserControl ucEconomySeason;
  }
}
