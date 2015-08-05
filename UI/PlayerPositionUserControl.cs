
namespace AndreiPopescu.CharazayPlus.UI
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Drawing;
  using System.Data;
  using System.Text;
  using System.Linq;
  using System.Windows.Forms;
  using BrightIdeasSoftware;
  using AndreiPopescu.CharazayPlus.Extensions;
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
    /// <param name="_olv">object list view</param>
    /// <param name="players">player derived collection</param>
    private void initOLV<T> (ObjectListView olv, IList<T> players)
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
      //
      olv.SetObjects(players);
      //
      olv.Sort(olv.AllColumns.FirstOrDefault(c => c.AspectName == "ValueIndex"), SortOrder.Descending);
    }

    public void Init<T> (IList<T> players) where T : Player
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
      this.components = new System.ComponentModel.Container();
      this.olv = new BrightIdeasSoftware.ObjectListView();
      this.ucEvaluatePlayer = new AndreiPopescu.CharazayPlus.UI.EvaluatePlayerUserControl();
      this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.tsmiTransferBookmark = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.olv)).BeginInit();
      this.cms.SuspendLayout();
      this.SuspendLayout();
      // 
      // _olv
      // 
      this.olv.AlternateRowBackColor = System.Drawing.Color.DimGray;
      this.olv.BackColor = System.Drawing.Color.Gray;
      this.olv.Dock = System.Windows.Forms.DockStyle.Fill;
      this.olv.ForeColor = System.Drawing.Color.White;
      this.olv.FullRowSelect = true;
      this.olv.Location = new System.Drawing.Point(0, 0);
      this.olv.Name = "_olv";
      this.olv.Size = new System.Drawing.Size(662, 285);
      this.olv.SortGroupItemsByPrimaryColumn = false;
      this.olv.TabIndex = 1;
      this.olv.UseAlternatingBackColors = true;
      this.olv.UseCompatibleStateImageBehavior = false;
      this.olv.View = System.Windows.Forms.View.Details;
      this.olv.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.olv_CellRightClick);
      this.olv.SelectedIndexChanged += new System.EventHandler(this.olv_SelectedIndexChanged);
      // 
      // ucEvaluatePlayer
      // 
      this.ucEvaluatePlayer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucEvaluatePlayer.BackColor = System.Drawing.Color.DimGray;
      this.ucEvaluatePlayer.CausesValidation = false;
      this.ucEvaluatePlayer.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.ucEvaluatePlayer.ForeColor = System.Drawing.Color.White;
      this.ucEvaluatePlayer.IsFatigue = false;
      this.ucEvaluatePlayer.IsForm = false;
      this.ucEvaluatePlayer.IsHeightWeightImpact = false;
      this.ucEvaluatePlayer.Location = new System.Drawing.Point(0, 155);
      this.ucEvaluatePlayer.Name = "ucEvaluatePlayer";
      this.ucEvaluatePlayer.SelectedObject = null;
      this.ucEvaluatePlayer.Size = new System.Drawing.Size(662, 130);
      this.ucEvaluatePlayer.TabIndex = 2;
      // 
      // cms
      // 
      this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTransferBookmark});
      this.cms.Name = "cms";
      this.cms.Size = new System.Drawing.Size(175, 26);
      // 
      // tsmiTransferBookmark
      // 
      this.tsmiTransferBookmark.Name = "tsmiTransferBookmark";
      this.tsmiTransferBookmark.Size = new System.Drawing.Size(174, 22);
      this.tsmiTransferBookmark.Text = "Transfer Bookmark";
      this.tsmiTransferBookmark.Click += new System.EventHandler(this.tsmiTransferBookmark_Click);
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
      this.Load += new System.EventHandler(this.PlayerPositionUserControl_Load);
      ((System.ComponentModel.ISupportInitialize)(this.olv)).EndInit();
      this.cms.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    private ContextMenuStrip cms;
    private ToolStripMenuItem tsmiTransferBookmark;

   
    
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

    private void PlayerPositionUserControl_Load (object sender, EventArgs e)
    {
      this.ucEvaluatePlayer.IsHeightWeightImpact = true;
      this.ucEvaluatePlayer.EvaluationType = Evaluation.season30;
    }

    private void tsmiTransferBookmark_Click (object sender, EventArgs e)
    {
      // object type attached is Player
      var crtPlayer = (Player)this.olv.SelectedObject;
      if (crtPlayer == null) return;
      //
      // search for bookmarks with same id and court position
      //
      var found = Data.TransferList.Bookmarks.FirstOrDefault(tlp => tlp.PlayerId == crtPlayer.Id && tlp.Pos == crtPlayer.PositionEnum);
      if (found == null)
      { //
        // not found => add
        //
        Data.TransferList.Bookmarks.Add(new Objects.TLPlayer()
        {
          Deadline = DateTime.UtcNow.ToString("yyyy/MM/dd HH:mm"),
          AgeValueIndex = crtPlayer.ValueIndex,
          Price = 1000000u,
          Profitability = Math.Pow(10d, 6d) * crtPlayer.TransferMarketValue / 1000000d,
          Position = crtPlayer.PositionEnum.ToString(),
          Name = crtPlayer.FullName,
          PlayerId = crtPlayer.Id
        });
      }
      else
      { //
        // found => update
        //
        found.Deadline = DateTime.UtcNow.ToString("yyyy/MM/dd HH:mm");
        found.AgeValueIndex = crtPlayer.ValueIndex;
        found.Price = 1000000u;
        found.Profitability = Math.Pow(10d, 6d) * crtPlayer.TransferMarketValue / 1000000d;
      }
      
    }

    private void olv_CellRightClick (object sender, CellRightClickEventArgs e)
    {
      e.MenuStrip = cms;
      cms.Show(e.Location);    
    }

  }
}
