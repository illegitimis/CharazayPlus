
namespace AndreiPopescu.CharazayPlus.UI
{
  using System.Windows.Forms;
  using BrightIdeasSoftware;
  using AndreiPopescu.CharazayPlus.Utils;

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
        case RatingType.Home: label1.Text = "Home Team Ratings"; break;
        case RatingType.Away: label1.Text = "Away Team Ratings"; break;
        default: break;
      }
      
      Generator.GenerateColumns(olv, ratings);
      if (Extensions.IsNullOrEmpty(ratings))
        olv.ClearObjects();
      else
      {
        olv.SetObjects(ratings);
        //
        // CacheManager
        //
        foreach (Xsd2.rating r in ratings)
        {
          CacheManager.Instance.AddPlayer(r.playerid, r.name);
        }
      }
        


      //olv.Columns.Add("bball");
      //olv.AllColumns[18].AspectPutter = 
      //  delegate (Xsd2.rating r) 
      //  {

      //  }
      
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
      this.olv = new BrightIdeasSoftware.ObjectListView();
      this.label1 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.olv)).BeginInit();
      this.SuspendLayout();
      // 
      // olv
      // 
      this.olv.AlternateRowBackColor = System.Drawing.Color.Gainsboro;
      this.olv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.olv.BackColor = System.Drawing.Color.WhiteSmoke;
      this.olv.FullRowSelect = true;
      this.olv.Location = new System.Drawing.Point(3, 16);
      this.olv.Name = "olv";
      this.olv.ShowGroups = false;
      this.olv.ShowItemToolTips = true;
      this.olv.Size = new System.Drawing.Size(144, 131);
      this.olv.TabIndex = 1;
      this.olv.UseAlternatingBackColors = true;
      this.olv.UseCompatibleStateImageBehavior = false;
      this.olv.View = System.Windows.Forms.View.Details;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(97, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Rating home/away";
      // 
      // RatingBballUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Controls.Add(this.label1);
      this.Controls.Add(this.olv);
      this.Name = "RatingBballUserControl";
      ((System.ComponentModel.ISupportInitialize)(this.olv)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private BrightIdeasSoftware.ObjectListView olv;
    private System.Windows.Forms.Label label1;
  }

  public enum RatingType { Home, Away, Unknown }
}
