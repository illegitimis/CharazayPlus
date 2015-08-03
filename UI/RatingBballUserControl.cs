
namespace AndreiPopescu.CharazayPlus.UI
{
  using System.Windows.Forms;
  using BrightIdeasSoftware;
  using AndreiPopescu.CharazayPlus.Utils;
  using AndreiPopescu.CharazayPlus.Extensions;
  using System.Drawing;

  public class RatingBballUserControl : UserControl
  {
    public RatingBballUserControl()
    {
      InitializeComponent();
      RatingType = RatingType.Unknown;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ratings"></param>
    /// <param name="bballs"></param>
    public void SetData(Xsd2.rating[] ratings, Xsd2.bball[] bballs)
    {
      switch (RatingType)
      {
        case RatingType.Home: _lblTitle.Text = "Home Team Ratings"; break;
        case RatingType.Away: _lblTitle.Text = "Away Team Ratings"; break;
        default: break;
      }
      //
      Generator.GenerateColumns(_olv, ratings);
      //
      if (ratings.IsNullOrEmpty())
        _olv.ClearObjects();
      else
      {
        //http://www.charazay.com/images/goldball.png
        //this.olvcFame.Renderer = new MultiImageRenderer(Properties.Resources.star12, 10, 0, 11);
        //http://www.charazay.com/images/ballwhole.jpg

        var colBball = new OLVColumn("bball", null);
        colBball.AspectGetter = delegate(object o) {
            decimal val = 0m;
            Xsd2.rating r = (Xsd2.rating)o;
            foreach (var b in bballs) { 
              if (b.playerid == r.playerid) {
                val = b.bballs;
                break;
              }
            }
            return val;   
         };
        //
        colBball.Renderer = new BarTextRenderer(0, 20, Pens.Black, Color.LawnGreen, Color.IndianRed) { UseStandardBar = false, Brush = Brushes.Black};
        //
        _olv.AllColumns.Add(colBball);
        //
        _olv.SetObjects(ratings);
        //
        // CacheManager
        //
        //
        _olv.RebuildColumns();
        //
        foreach (Xsd2.rating r in ratings)
        {
          CacheManager.Instance.AddPlayer(r.playerid, r.name);
        }
      }
      
    }

    public RatingType RatingType { get; set; }

    #region //-- IDisposable
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
    #endregion

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this._olv = new BrightIdeasSoftware.ObjectListView();
      this._lblTitle = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this._olv)).BeginInit();
      this.SuspendLayout();
      // 
      // _olv
      // 
      this._olv.AlternateRowBackColor = System.Drawing.Color.Gainsboro;
      this._olv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._olv.BackColor = System.Drawing.Color.WhiteSmoke;
      this._olv.FullRowSelect = true;
      this._olv.Location = new System.Drawing.Point(3, 16);
      this._olv.Name = "_olv";
      this._olv.ShowGroups = false;
      this._olv.ShowItemToolTips = true;
      this._olv.Size = new System.Drawing.Size(144, 131);
      this._olv.TabIndex = 1;
      this._olv.UseAlternatingBackColors = true;
      this._olv.UseCompatibleStateImageBehavior = false;
      this._olv.View = System.Windows.Forms.View.Details;
      this._olv.OwnerDraw = true;
      // 
      // _lblTitle
      // 
      this._lblTitle.AutoSize = true;
      this._lblTitle.Location = new System.Drawing.Point(3, 0);
      this._lblTitle.Name = "_lblTitle";
      this._lblTitle.Size = new System.Drawing.Size(97, 13);
      this._lblTitle.TabIndex = 0;
      this._lblTitle.Text = "Rating home/away";
      // 
      // RatingBballUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Controls.Add(this._lblTitle);
      this.Controls.Add(this._olv);
      this.Name = "RatingBballUserControl";
      ((System.ComponentModel.ISupportInitialize)(this._olv)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private BrightIdeasSoftware.ObjectListView _olv;
    private System.Windows.Forms.Label _lblTitle;
  }

  public enum RatingType { Home, Away, Unknown }
}
