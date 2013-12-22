
namespace AndreiPopescu.CharazayPlus.UI
{
  using System;
  using System.Drawing;
  using System.Windows.Forms;
  using System.Drawing.Drawing2D;
  using System.ComponentModel;

  public class VLabel : System.Windows.Forms.Label
  {

    private bool bFlip = true;

    public VLabel()
    {
    }

    protected override void OnPaintBackground (System.Windows.Forms.PaintEventArgs pevent)
    {
      base.OnPaintBackground(pevent);
    }

    protected override void OnPaint (PaintEventArgs e)
    {
      graphics(e.Graphics);
      
    }

    private void graphics (Graphics g)
    {
      StringFormat stringFormat = new StringFormat();
      stringFormat.Alignment = StringAlignment.Center;
      stringFormat.Trimming = StringTrimming.None;
      stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;

      Brush textBrush = new SolidBrush(this.ForeColor);

      Matrix storedState = g.Transform;

      if (bFlip)
      {
        g.RotateTransform(180f);

        g.TranslateTransform(-ClientRectangle.Width, -ClientRectangle.Height);
      }

      g.DrawString(
        this.Text,
        this.Font,
        textBrush,
        ClientRectangle,
        stringFormat);

      g.Transform = storedState;
    }

    [Description("When this parameter is true the VLabel flips at 180 degrees.")
    , Category("Appearance")]
    public bool Flip180
    {
      get
      {
        return bFlip;
      }
      set
      {
        bFlip = value;
        this.Invalidate();
      }
    }
  }
}
