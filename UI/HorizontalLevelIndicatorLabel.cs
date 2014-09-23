namespace AndreiPopescu.CharazayPlus.UI
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Drawing;
  using System.Data;
  using System.Text;
  using System.Windows.Forms;
  using System.Drawing.Drawing2D;

  public class HorizontalLevelIndicatorLabel : Label
  {
    public HorizontalLevelIndicatorLabel ( )
    {
      InitializeComponent();
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
      components = new System.ComponentModel.Container();
      this.Text = string.Empty;
      this.DoubleBuffered = true;
    }

    #endregion

    #region property grid
    //The LabelGradient class inherited the default BackColor property, which we no longer wish to use. 
    //We can shadow the default BackColor by overriding it, allowing us to hide it.
    //The Browsable attribute set to false specifies that the property should not be displayed in the Property Browser window.
    //EditorBrowsable attribute set to EditorBrowsableState.Never hides the property of the control from intelliSense.

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public override System.Drawing.Color BackColor
    {
      get { return Color.DimGray; }
      set { ;}
    }

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public override System.Drawing.Color ForeColor
    {
      get { return Color.WhiteSmoke; }
      set { ;}
    }

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public override bool AutoSize
    {
      get { return false; }
      set { ;}
    }

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public override ContentAlignment TextAlign
    {
      get { return ContentAlignment.BottomRight; }
      set { }
    }


    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public override string Text
    {
      get { return base.Text; }
      set { base.Text = value; }
    }


    private float _level = 30;
    private float _min = 0f;
    private float _max = float.MaxValue;
    private  bool _show;

    [DefaultValue(float.MaxValue / 2), Description("Level"), Category("Data")]
    public float Level
    {
      get { return _level; }
      set
      {
        _level = Math.Max(Math.Min(value, float.MaxValue), 0);
        Text = _show ? string.Format("{0,2} / {1,2}", _level, _max) : string.Format("{0,2}", _level);        
      }
    }

    [DefaultValue(float.MaxValue), Description("Maximum Level"), Category("Data")]
    public float MaximumLevel
    {
      get { return _max; }
      set
      {
        _max = Math.Max(Math.Min(value, float.MaxValue), 0);
        Text = _show ? string.Format("{0,2} / {1,2}", _level, _max) : string.Format("{0,2}", _level);
      }
    }

    [DefaultValue(0f), Description("Minimum Level"), Category("Data")]
    public float MinimumLevel
    {
      get { return _min; }
      set
      {
        _min = Math.Max(value, 0);
        if (_min==0f)
          Text = _show ? string.Format("{0,2} / {1,2}", _level, _max) : string.Format("{0,2}", _level);
        else
          Text = _show ? string.Format("{0,2} / {1,2} / {2,2}", _min, _level, _max) : string.Format("{0,2}", _level);
      }
    }

    [DefaultValue(false), Description("show maximum value in text description"), Category("Appearance")]
    public bool ShowMaximumValueText
    {
      get { return _show; }
      set
      {
        _show = value;
        Text = string.Format("{0,2}", _level);
      }
    }
    #endregion

    protected override void OnPaintBackground (System.Windows.Forms.PaintEventArgs pevent)
    {
      Graphics gfx = pevent.Graphics;
      base.OnPaintBackground(pevent);

      #region MyRegion
      //RectangleF rect = new Rectangle(0, 0, this.Width/3, this.Height);
      //// Dispose of brush resources after use
      //using (LinearGradientBrush lgb = new LinearGradientBrush(
      //  rect, Color.Green, Color.GreenYellow, LinearGradientMode.Horizontal))
      //  gfx.FillRectangle(lgb, rect);

      //rect = new RectangleF(this.Width / 3, 0, this.Width / 3, this.Height);
      //using (LinearGradientBrush lgb = new LinearGradientBrush(
      //  rect, Color.YellowGreen, Color.Yellow, LinearGradientMode.Horizontal))
      //  gfx.FillRectangle(lgb, rect);

      //rect = new RectangleF(2*this.Width / 3, 0, this.Width / 3, this.Height);
      //using (LinearGradientBrush lgb = new LinearGradientBrush(
      //  rect, Color.Gold, Color.Red, LinearGradientMode.Horizontal))
      //  gfx.FillRectangle(lgb, rect);

      //RectangleF

      //ControlPaint.DrawBorder3D(gfx, rect1);
      //b3dstyle 
      #endregion

      float red = 0f;
      float green = 255f;
      float blue = 0f;
      //
      float quot = this.Width / (MaximumLevel-MinimumLevel);
      // zone width is 2
      float y = 0f;
      float h = (float)this.Height;
      float x = 0;
      float w2 = this.Width / 2f;
      float c = 255f / (float)this.Width;
      // color increase level
      float inc = c * 2.5f;
      while (x < quot * (Level-MinimumLevel))
      {
        gfx.FillRectangle(new SolidBrush(Color.FromArgb((int)red, (int)green, Math.Max(Math.Min((int)blue, 255), 0)))
          , x, y + 0.5f, 2f, h - 1f);
        //
        x += 2.5f;
        //        
        red += inc;
        green -= inc;
        if (x < w2)
          blue += inc * 2;
        else
          blue -= inc * 2;
        //blue = 255 * (float)Math.Sin(Math.PI / this.Width * x);

      }
      //SizeF sz = gfx.MeasureString(Text, this.Font);
      //gfx.DrawString(text, this.Font, new SolidBrush(this.ForeColor), new PointF(0, 0));
      //gfx.DrawString(Text, this.Font, new SolidBrush(this.ForeColor), new PointF(this.Width - 1f - sz.Width, this.Height - 1f - sz.Height)); 
    }

  }
}