

namespace AndreiPopescu.CharazayPlus.UI
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Data;
  using System.Drawing;
  using System.Text;
  using System.Windows.Forms;
  using AndreiPopescu.CharazayPlus.Utils;

  public partial class AboutForm : System.Windows.Forms.Form
  {
    private readonly AssemblyInfo asmInfo = null;
    public AboutForm ( )
    {
      InitializeComponent();

      asmInfo = new AssemblyInfo();
      label2.Text = "Copyright";
      textBox2.Text = asmInfo.Copyright;
      label3.Text = "Version";
      textBox3.Text = asmInfo.Version;
      label4.Text = "Product";
      textBox4.Text = asmInfo.Product + ", " + asmInfo.Title;
      label8.Text = "Company";
      textBox8.Text = asmInfo.Company;
      label9.Text = "Description";
      textBox9.Text = asmInfo.Description;


      //this.ucLblDescr4.Description = asmInfo.AsmFQName;
      //this.ucLblDescr3.Description = asmInfo.Copyright;
      //this.ucLblDescr2.Description = asmInfo.Version;
      //this.ucLblDescr1.Description = asmInfo.Product;
    }
    private TextBox textBox2;
    private Label label2;
    private TextBox textBox3;
    private Label label3;
    private TextBox textBox4;
    private Label label4;
    private TextBox textBox8;
    private Label label8;
    private TextBox textBox9;
    private Label label9;

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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent ( )
    {
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.textBox3 = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.textBox4 = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.textBox8 = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.textBox9 = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pictureBox1.BackgroundImage = global::AndreiPopescu.CharazayPlus.Properties.Resources.Charazay_;
      this.pictureBox1.InitialImage = null;
      this.pictureBox1.Location = new System.Drawing.Point(13, 13);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(428, 134);
      this.pictureBox1.TabIndex = 4;
      this.pictureBox1.TabStop = false;
      // 
      // textBox2
      // 
      this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textBox2.Location = new System.Drawing.Point(147, 180);
      this.textBox2.Multiline = true;
      this.textBox2.Name = "textBox2";
      this.textBox2.ReadOnly = true;
      this.textBox2.Size = new System.Drawing.Size(294, 46);
      this.textBox2.TabIndex = 8;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(13, 180);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(35, 13);
      this.label2.TabIndex = 7;
      this.label2.Text = "label2";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // textBox3
      // 
      this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textBox3.Location = new System.Drawing.Point(147, 260);
      this.textBox3.Name = "textBox3";
      this.textBox3.ReadOnly = true;
      this.textBox3.Size = new System.Drawing.Size(294, 20);
      this.textBox3.TabIndex = 12;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(13, 260);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(35, 13);
      this.label3.TabIndex = 11;
      this.label3.Text = "label3";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // textBox4
      // 
      this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textBox4.Location = new System.Drawing.Point(147, 234);
      this.textBox4.Name = "textBox4";
      this.textBox4.ReadOnly = true;
      this.textBox4.Size = new System.Drawing.Size(294, 20);
      this.textBox4.TabIndex = 10;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(13, 234);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(35, 13);
      this.label4.TabIndex = 9;
      this.label4.Text = "label4";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // textBox8
      // 
      this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textBox8.Location = new System.Drawing.Point(147, 285);
      this.textBox8.Name = "textBox8";
      this.textBox8.ReadOnly = true;
      this.textBox8.Size = new System.Drawing.Size(294, 20);
      this.textBox8.TabIndex = 14;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(13, 285);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(35, 13);
      this.label8.TabIndex = 13;
      this.label8.Text = "label8";
      this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // textBox9
      // 
      this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textBox9.Location = new System.Drawing.Point(147, 153);
      this.textBox9.Name = "textBox9";
      this.textBox9.ReadOnly = true;
      this.textBox9.Size = new System.Drawing.Size(294, 20);
      this.textBox9.TabIndex = 24;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(13, 153);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(35, 13);
      this.label9.TabIndex = 23;
      this.label9.Text = "label9";
      this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // AboutForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(450, 313);
      this.Controls.Add(this.textBox9);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.textBox8);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.textBox3);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.textBox4);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.textBox2);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.pictureBox1);
      this.MaximumSize = new System.Drawing.Size(466, 351);
      this.MinimumSize = new System.Drawing.Size(466, 351);
      this.Name = "AboutForm";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "About Charazay+";
      this.TopMost = true;
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    //private LabelDescriptionUserControl ucLblDescr1;
    //private LabelDescriptionUserControl ucLblDescr2;
    //private LabelDescriptionUserControl ucLblDescr3;
    //private LabelDescriptionUserControl ucLblDescr4;
    private PictureBox pictureBox1;
  }
}
