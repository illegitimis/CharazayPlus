using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AndreiPopescu.CharazayPlus.UI
{
  public class SideTabControl : TabControl
  {
    public SideTabControl()
    {
      InitializeComponent();

      MustOverride();
    }

    private void tabControlSide_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
    {
      Graphics g = e.Graphics;
      Brush _textBrush;

      // Get the item from the collection.
      TabPage _tabPage = this.TabPages[e.Index];

      // Get the real bounds for the tab rectangle.
      Rectangle _tabBounds = this.GetTabRect(e.Index);

      if (e.State == DrawItemState.Selected)
      {

        // Draw a different background color, and don'm paint a focus rectangle.
        _textBrush = new SolidBrush(Color.Red);
        g.FillRectangle(Brushes.Gray, e.Bounds);
      }
      else
      {
        _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
        e.DrawBackground();
      }

      // Use our own font.
      Font _tabFont = new Font("Arial", (float)10.0, FontStyle.Bold, GraphicsUnit.Pixel);

      // Draw string. Center the text.
      StringFormat _stringFlags = new StringFormat();
      _stringFlags.Alignment = StringAlignment.Center;
      _stringFlags.LineAlignment = StringAlignment.Center;
      g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, _stringFlags);
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

    private void MustOverride()
    {
      // must
      this.Alignment = System.Windows.Forms.TabAlignment.Right;
      this.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
      
      this.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;

      //Set the ItemSize property to the preferred fixed size for the tabs. 
      //Keep in mind that the ItemSize property behaves as though the tabs were on top, 
      //although they are right-aligned. As a result, in order to make the tabs wider, 
      //you must change the Height property, and in order to make them taller, 
      //you must change the Width property. 
      this.Height = 250;
      this.Width = 125;
      this.ItemSize = new Size(26, 104);
      this.MinimumSize = new Size(104, 104);
      
      this.DrawItem += new System.Windows.Forms.DrawItemEventHandler(tabControlSide_DrawItem);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      components = new System.ComponentModel.Container();
      //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;           
    }

    #endregion
  }
}
