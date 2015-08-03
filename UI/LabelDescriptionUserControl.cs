using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AndreiPopescu.CharazayPlus.UI
{
  public partial class LabelDescriptionUserControl : UserControl
  {
    public LabelDescriptionUserControl()
    {
      InitializeComponent();
    }

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
      this.lbl = new System.Windows.Forms.Label();
      this.txtDescription = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // lbl
      // 
      this.lbl.AutoSize = true;
      this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl.Location = new System.Drawing.Point(4, 4);
      this.lbl.Name = "lbl";
      this.lbl.Size = new System.Drawing.Size(41, 13);
      this.lbl.TabIndex = 0;
      this.lbl.Text = "_lblTitle";
      // 
      // txtDescription
      // 
      this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtDescription.Location = new System.Drawing.Point(84, 4);
      this.txtDescription.Name = "txtDescription";
      this.txtDescription.ReadOnly = true;
      this.txtDescription.Size = new System.Drawing.Size(208, 13);
      this.txtDescription.TabIndex = 1;
      // 
      // LabelDescriptionUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Controls.Add(this.txtDescription);
      this.Controls.Add(this.lbl);
      this.DoubleBuffered = true;
      this.Name = "LabelDescriptionUserControl";
      this.Size = new System.Drawing.Size(295, 20);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lbl;
    private System.Windows.Forms.TextBox txtDescription;

    public string Label { get { return lbl.Text; } set { lbl.Text = value; } }
    public string Description { get { return txtDescription.Text; } set { txtDescription.Text = value; } }
    public bool IsMultiline { 
      get { return txtDescription.Multiline; } 
      set 
      { 
        txtDescription.Multiline = value;
        txtDescription.ScrollBars = ScrollBars.Vertical;
      } 
    }
  }
}
