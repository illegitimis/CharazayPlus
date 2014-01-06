namespace AndreiPopescu.CharazayPlus.UI
{
  partial class PlayerPositionUserControl
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
      this.olv = new BrightIdeasSoftware.ObjectListView();
      ((System.ComponentModel.ISupportInitialize)(this.olv)).BeginInit();
      this.SuspendLayout();
      // 
      // olv
      // 
      this.olv.AlternateRowBackColor = System.Drawing.Color.DimGray;
      this.olv.BackColor = System.Drawing.Color.Gray;
      this.olv.Dock = System.Windows.Forms.DockStyle.Fill;
      this.olv.ForeColor = System.Drawing.Color.White;
      this.olv.Location = new System.Drawing.Point(0, 0);
      this.olv.Name = "olv";
      this.olv.Size = new System.Drawing.Size(150, 150);
      this.olv.TabIndex = 1;
      this.olv.UseAlternatingBackColors = true;
      this.olv.UseCompatibleStateImageBehavior = false;
      this.olv.View = System.Windows.Forms.View.Details;
      // 
      // PlayerPositionUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.olv);
      this.DoubleBuffered = true;
      this.Name = "PlayerPositionUserControl";
      ((System.ComponentModel.ISupportInitialize)(this.olv)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private BrightIdeasSoftware.ObjectListView olv;
  }
}
