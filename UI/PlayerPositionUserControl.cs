
namespace AndreiPopescu.CharazayPlus.UI
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Drawing;
  using System.Data;
  using System.Text;
  using System.Windows.Forms;
  using BrightIdeasSoftware;
  using AndreiPopescu.CharazayPlus.Utils;

  public partial class PlayerPositionUserControl : UserControl
  {
    public PlayerPositionUserControl ( )
    {
      InitializeComponent();
    }

    /// <summary>
    /// Position based list customizer
    /// </summary>
    /// <typeparam name="T">player type</typeparam>
    /// <param name="olv">object list view</param>
    /// <param name="players">player derived collection</param>
    private void initOLV<T> (ObjectListView olv, List<T> players)
      where T : Player
    {
      Generator.GenerateColumns(olv, players);
      olv.HeaderUsesThemes = false;

      double[] scoreMarkers = new double[] { 5, 8, 10, 12, 14, 16, 18, 20 };
      string[] descriptions = ObjectListViewExtensions.BuildCustomGroupies<double>(scoreMarkers);

      foreach (OLVColumn col in olv.Columns)
      {
        col.IsHeaderVertical = true;
        /*Custom.TagPosition*/
        string tag = col.Tag as string;
        if (!tag.Contains("Position"))
          col.IsVisible = false;

        switch (col.DisplayIndex)
        { 
          case 0:
            { // name column
              col.GroupKeyGetter = delegate(object row) { return ((T)row).HeightForPosition; };
              col.GroupKeyToTitleConverter = delegate(object groupKey)
              {
                PositionHeight adequacy = (PositionHeight)groupKey;
                if (adequacy == PositionHeight.Adequate)
                {
                  return string.Format("{0} [{1} - {2}]", adequacy, players[0].MinimumHeight, players[0].MaximumHeight);
                }
                else
                  return adequacy.ToString();
              };

            } break;

          case 28:
            { // value index
              double[] avMarks = new double[] { 0.6, 0.8, 0.9, 0.95, 1, 1.02, 1.04, 1.06, 1.08, 1.1, 1.12, 1.15, 1.2, 1.25, 1.3, 1.4, 1.5};
              string[] avDescr = ObjectListViewExtensions.BuildCustomGroupies<double>(avMarks);
              col.MakeGroupies(avMarks, avDescr);
            } break;

          case 29:
            { // transfer market value
              double[] avMarks = new double[] { 0.5d, 1d, 2d, 5d, 10d, 15d, 20d, 30d, 50d, 75d, 100d, 150d };
              string[] avDescr = ObjectListViewExtensions.BuildCustomGroupies<double>(avMarks);
              col.MakeGroupies(avMarks, avDescr);
            } break;

          default:
            { // 1-27
              col.MakeGroupies(scoreMarkers, descriptions);
            } break;
        }
      }
      olv.RebuildColumns();

      // either call works
      olv.SetObjects(players);
    }

    public void Init<T> (List<T> players) where T : Player
    {
      initOLV<T>(this.olv, players);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent ( )
    {
      this.olv = new BrightIdeasSoftware.ObjectListView();
      this.ucEvaluatePlayer = new AndreiPopescu.CharazayPlus.UI.EvaluatePlayerUserControl();
      ((System.ComponentModel.ISupportInitialize)(this.olv)).BeginInit();
      this.SuspendLayout();
      // 
      // olv
      // 
      this.olv.AlternateRowBackColor = System.Drawing.Color.DimGray;
      this.olv.BackColor = System.Drawing.Color.Gray;
      this.olv.Dock = System.Windows.Forms.DockStyle.Fill;
      this.olv.ForeColor = System.Drawing.Color.White;
      this.olv.FullRowSelect = true;
      this.olv.Location = new System.Drawing.Point(0, 0);
      this.olv.Name = "olv";
      this.olv.Size = new System.Drawing.Size(662, 285);
      this.olv.SortGroupItemsByPrimaryColumn = false;
      this.olv.TabIndex = 1;
      this.olv.UseAlternatingBackColors = true;
      this.olv.UseCompatibleStateImageBehavior = false;
      this.olv.View = System.Windows.Forms.View.Details;
      this.olv.SelectedIndexChanged += new System.EventHandler(this.olv_SelectedIndexChanged);
      // 
      // ucEvaluatePlayer
      // 
      this.ucEvaluatePlayer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucEvaluatePlayer.BackColor = System.Drawing.Color.DimGray;
      this.ucEvaluatePlayer.CausesValidation = false;
      this.ucEvaluatePlayer.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.ucEvaluatePlayer.ForeColor = System.Drawing.Color.White;
      this.ucEvaluatePlayer.Location = new System.Drawing.Point(0, 155);
      this.ucEvaluatePlayer.Name = "ucEvaluatePlayer";
      this.ucEvaluatePlayer.SelectedObject = null;
      this.ucEvaluatePlayer.Size = new System.Drawing.Size(662, 130);
      this.ucEvaluatePlayer.TabIndex = 2;
      // 
      // PlayerPositionUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.ucEvaluatePlayer);
      this.Controls.Add(this.olv);
      this.DoubleBuffered = true;
      this.Name = "PlayerPositionUserControl";
      this.Size = new System.Drawing.Size(662, 285);
      ((System.ComponentModel.ISupportInitialize)(this.olv)).EndInit();
      this.ResumeLayout(false);

    }

   
    
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
    #endregion

    private BrightIdeasSoftware.ObjectListView olv;
    private EvaluatePlayerUserControl ucEvaluatePlayer;

    private void olv_SelectedIndexChanged (object sender, EventArgs e)
    {
      
      ObjectListView olv = (ObjectListView)sender;
      Player p = null;
      if (olv.SelectedObject != null)
      { 
        p = (Player)olv.SelectedObject;
      }
      else if (olv.SelectedObjects != null && olv.SelectedObjects.Count > 0)
      {
        p = (Player)(olv.SelectedObjects[0]);
      }
      if (p!=null)
        ucEvaluatePlayer.SelectedObject = p.BasePlayer;
    }

  }
}
