

namespace AndreiPopescu.CharazayPlus.UI
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Drawing;
  using System.Data;
  using System.Linq;
  using System.Text;
  using System.Windows.Forms;
  using BrightIdeasSoftware;

  /// <summary>
  /// replaces the grid based old user control <see cref="MyTeamScheduleUserControl"/>
  /// </summary>
  public class TeamScheduleUserControl : UserControl
  {
    public TeamScheduleUserControl ( )
    {
      InitializeComponent();
      //
      this.ucMatchDetails.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
      this.splitter.Panel2Collapsed = true;
      this.splitterTB.Panel2Collapsed = true;
      this.splitterTB.IsSplitterFixed = true;
      this.splitterTB.FixedPanel = FixedPanel.Panel1;
      this.splitterLR.IsSplitterFixed = true;
      this.splitterTB.FixedPanel = FixedPanel.Panel2;      
    }

    public void Init (Xsd2.match[] schedule, uint uid)
    {
      foreach(var m in schedule)
        m.MyTeamId = uid;
      foreach (var mt in schedule.Select(m => m.MatchType).Distinct())
        //this.chklstMatchTypes.Items.Add(mt)
        ;

      //
      Generator.GenerateColumns(this.fdlv, typeof(Xsd2.match));
      //
      this.fdlv.HeaderUsesThemes = false;
      this.fdlv.ShowGroups = false;
      //
      foreach (OLVColumn col in fdlv.Columns)
      {
        switch (col.Index)
        {
          case 0: //id
            col.IsHeaderVertical = false; break;
          case 1: //home team
            col.IsHeaderVertical = false; break;
          case 4: //away team
            col.IsHeaderVertical = false; break;
          case 5: //type
            col.IsHeaderVertical = false; break;
          case 6: //played
            col.IsHeaderVertical = true; break;
          case 7: //won
            col.IsHeaderVertical = true; 
            //col.UsesFiltering 
            break;
          case 8: //date
            col.IsHeaderVertical = false; 
            col.AspectToStringFormat = "{0:yyyy-MM-dd}";
            break;

          default:
        col.IsHeaderVertical = true;
        break;
        }
        
      }
      //
      this.fdlv.SetObjects(schedule);
     //
      this.fdlv.RebuildColumns();
    }

    private void fdlv_HyperlinkClicked (object sender, HyperlinkClickedEventArgs e)
    {
      Xsd2.match s = (Xsd2.match)e.Item.RowObject;
      if (s == null)
        return;
      //
      switch (e.ColumnIndex)
      {
        case 1:
          { // team
            Web.CharazayDownloadItem teamLink = new Web.CharazayDownloadItem("team", 0, s.HomeTeamId);
            e.Url = teamLink.Uri.AbsoluteUri;
          } break;
        case 4:
          { // team
            Web.CharazayDownloadItem teamLink = new Web.CharazayDownloadItem("team", 0, s.AwayTeamId);
            e.Url = teamLink.Uri.AbsoluteUri;
          } break;
        case 0:
          { // user
            Web.CharazayDownloadItem matchLink = new Web.CharazayDownloadItem("match", 0, s.Id);
            e.Url = matchLink.Uri.AbsoluteUri;
          } break;

      default: break;
      }

    }

    private Label label1;
    private TextBox txtSearch;
    private FastObjectListView fdlv;
    private MatchDetailsUserControl ucMatchDetails;
    private RatingBballUserControl ucRatingHome;
    private RatingBballUserControl ucRatingAway;
    private LineupHomeAwayUserControl ucLineup;
    private SplitContainer splitter;
    private TableLayoutPanel tlpRating;
    private SplitContainer splitterLR;
    private SplitContainer splitterTB;

  

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
      this.label1 = new System.Windows.Forms.Label();
      this.txtSearch = new System.Windows.Forms.TextBox();
      this.gbxWL = new System.Windows.Forms.GroupBox();
      this.rdWLLost = new System.Windows.Forms.RadioButton();
      this.rdWLAll = new System.Windows.Forms.RadioButton();
      this.rdWLWin = new System.Windows.Forms.RadioButton();
      this.gbxTeamSchedulePlayed = new System.Windows.Forms.GroupBox();
      this.rdPlayedNo = new System.Windows.Forms.RadioButton();
      this.rdPlayedYes = new System.Windows.Forms.RadioButton();
      this.rdPlayedAll = new System.Windows.Forms.RadioButton();
      this.fdlv = new BrightIdeasSoftware.FastObjectListView();
      this.splitter = new System.Windows.Forms.SplitContainer();
      this.splitterLR = new System.Windows.Forms.SplitContainer();
      this.splitterTB = new System.Windows.Forms.SplitContainer();
      this.ucMatchDetails = new AndreiPopescu.CharazayPlus.UI.MatchDetailsUserControl();
      this.ucLineup = new AndreiPopescu.CharazayPlus.UI.LineupHomeAwayUserControl();
      this.tlpRating = new System.Windows.Forms.TableLayoutPanel();
      this.ucRatingHome = new AndreiPopescu.CharazayPlus.UI.RatingBballUserControl();
      this.ucRatingAway = new AndreiPopescu.CharazayPlus.UI.RatingBballUserControl();
      this.gbxWL.SuspendLayout();
      this.gbxTeamSchedulePlayed.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.fdlv)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
      this.splitter.Panel1.SuspendLayout();
      this.splitter.Panel2.SuspendLayout();
      this.splitter.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitterLR)).BeginInit();
      this.splitterLR.Panel1.SuspendLayout();
      this.splitterLR.Panel2.SuspendLayout();
      this.splitterLR.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitterTB)).BeginInit();
      this.splitterTB.Panel1.SuspendLayout();
      this.splitterTB.Panel2.SuspendLayout();
      this.splitterTB.SuspendLayout();
      this.tlpRating.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label1.Location = new System.Drawing.Point(32, 74);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(47, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "Search";
      // 
      // txtSearch
      // 
      this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.txtSearch.Location = new System.Drawing.Point(92, 69);
      this.txtSearch.Name = "txtSearch";
      this.txtSearch.Size = new System.Drawing.Size(263, 22);
      this.txtSearch.TabIndex = 7;
      this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
      // 
      // gbxWL
      // 
      this.gbxWL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.gbxWL.Controls.Add(this.rdWLLost);
      this.gbxWL.Controls.Add(this.rdWLAll);
      this.gbxWL.Controls.Add(this.rdWLWin);
      this.gbxWL.Location = new System.Drawing.Point(192, 15);
      this.gbxWL.Name = "gbxWL";
      this.gbxWL.Size = new System.Drawing.Size(163, 48);
      this.gbxWL.TabIndex = 4;
      this.gbxWL.TabStop = false;
      this.gbxWL.Text = "Won/Lost";
      // 
      // rdWLLost
      // 
      this.rdWLLost.AutoSize = true;
      this.rdWLLost.Location = new System.Drawing.Point(103, 19);
      this.rdWLLost.Name = "rdWLLost";
      this.rdWLLost.Size = new System.Drawing.Size(45, 17);
      this.rdWLLost.TabIndex = 2;
      this.rdWLLost.Text = "Lost";
      this.rdWLLost.UseVisualStyleBackColor = true;
      this.rdWLLost.CheckedChanged += new System.EventHandler(this.rdWL_CheckedChanged);
      // 
      // rdWLAll
      // 
      this.rdWLAll.AutoSize = true;
      this.rdWLAll.Checked = true;
      this.rdWLAll.Location = new System.Drawing.Point(7, 20);
      this.rdWLAll.Name = "rdWLAll";
      this.rdWLAll.Size = new System.Drawing.Size(36, 17);
      this.rdWLAll.TabIndex = 1;
      this.rdWLAll.TabStop = true;
      this.rdWLAll.Text = "All";
      this.rdWLAll.UseVisualStyleBackColor = true;
      this.rdWLAll.CheckedChanged += new System.EventHandler(this.rdWL_CheckedChanged);
      // 
      // rdWLWin
      // 
      this.rdWLWin.AutoSize = true;
      this.rdWLWin.Location = new System.Drawing.Point(49, 19);
      this.rdWLWin.Name = "rdWLWin";
      this.rdWLWin.Size = new System.Drawing.Size(48, 17);
      this.rdWLWin.TabIndex = 0;
      this.rdWLWin.Text = "Won";
      this.rdWLWin.UseVisualStyleBackColor = true;
      this.rdWLWin.CheckedChanged += new System.EventHandler(this.rdWL_CheckedChanged);
      // 
      // gbxTeamSchedulePlayed
      // 
      this.gbxTeamSchedulePlayed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.gbxTeamSchedulePlayed.Controls.Add(this.rdPlayedNo);
      this.gbxTeamSchedulePlayed.Controls.Add(this.rdPlayedYes);
      this.gbxTeamSchedulePlayed.Controls.Add(this.rdPlayedAll);
      this.gbxTeamSchedulePlayed.Location = new System.Drawing.Point(28, 15);
      this.gbxTeamSchedulePlayed.Name = "gbxTeamSchedulePlayed";
      this.gbxTeamSchedulePlayed.Size = new System.Drawing.Size(158, 48);
      this.gbxTeamSchedulePlayed.TabIndex = 1;
      this.gbxTeamSchedulePlayed.TabStop = false;
      this.gbxTeamSchedulePlayed.Text = "Played";
      // 
      // rdPlayedNo
      // 
      this.rdPlayedNo.AutoSize = true;
      this.rdPlayedNo.Location = new System.Drawing.Point(98, 20);
      this.rdPlayedNo.Name = "rdPlayedNo";
      this.rdPlayedNo.Size = new System.Drawing.Size(39, 17);
      this.rdPlayedNo.TabIndex = 2;
      this.rdPlayedNo.Text = "No";
      this.rdPlayedNo.UseVisualStyleBackColor = true;
      this.rdPlayedNo.CheckedChanged += new System.EventHandler(this.rdPlayed_CheckedChanged);
      // 
      // rdPlayedYes
      // 
      this.rdPlayedYes.AutoSize = true;
      this.rdPlayedYes.Location = new System.Drawing.Point(49, 20);
      this.rdPlayedYes.Name = "rdPlayedYes";
      this.rdPlayedYes.Size = new System.Drawing.Size(43, 17);
      this.rdPlayedYes.TabIndex = 1;
      this.rdPlayedYes.Text = "Yes";
      this.rdPlayedYes.UseVisualStyleBackColor = true;
      this.rdPlayedYes.CheckedChanged += new System.EventHandler(this.rdPlayed_CheckedChanged);
      // 
      // rdPlayedAll
      // 
      this.rdPlayedAll.AutoSize = true;
      this.rdPlayedAll.Checked = true;
      this.rdPlayedAll.Location = new System.Drawing.Point(7, 20);
      this.rdPlayedAll.Name = "rdPlayedAll";
      this.rdPlayedAll.Size = new System.Drawing.Size(36, 17);
      this.rdPlayedAll.TabIndex = 0;
      this.rdPlayedAll.TabStop = true;
      this.rdPlayedAll.Text = "All";
      this.rdPlayedAll.UseVisualStyleBackColor = true;
      this.rdPlayedAll.CheckedChanged += new System.EventHandler(this.rdPlayed_CheckedChanged);
      // 
      // fdlv
      // 
      this.fdlv.AlternateRowBackColor = System.Drawing.Color.LightGray;
      this.fdlv.BackColor = System.Drawing.Color.Silver;
      this.fdlv.CausesValidation = false;
      this.fdlv.Dock = System.Windows.Forms.DockStyle.Fill;
      this.fdlv.FullRowSelect = true;
      this.fdlv.Location = new System.Drawing.Point(0, 0);
      this.fdlv.MultiSelect = false;
      this.fdlv.Name = "fdlv";
      this.fdlv.ShowGroups = false;
      this.fdlv.Size = new System.Drawing.Size(416, 318);
      this.fdlv.SortGroupItemsByPrimaryColumn = false;
      this.fdlv.Sorting = System.Windows.Forms.SortOrder.Ascending;
      this.fdlv.TabIndex = 2;
      this.fdlv.UseAlternatingBackColors = true;
      this.fdlv.UseCompatibleStateImageBehavior = false;
      this.fdlv.UseFiltering = true;
      this.fdlv.UseHotItem = true;
      this.fdlv.UseHyperlinks = true;
      this.fdlv.UseTranslucentHotItem = true;
      this.fdlv.UseTranslucentSelection = true;
      this.fdlv.View = System.Windows.Forms.View.Details;
      this.fdlv.VirtualMode = true;
      this.fdlv.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(this.fdlv_HyperlinkClicked);
      this.fdlv.SelectedIndexChanged += new System.EventHandler(this.fdlv_SelectedIndexChanged);
      // 
      // splitter
      // 
      this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitter.Location = new System.Drawing.Point(0, 0);
      this.splitter.Name = "splitter";
      this.splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitter.Panel1
      // 
      this.splitter.Panel1.Controls.Add(this.splitterLR);
      // 
      // splitter.Panel2
      // 
      this.splitter.Panel2.Controls.Add(this.tlpRating);
      this.splitter.Size = new System.Drawing.Size(778, 473);
      this.splitter.SplitterDistance = 318;
      this.splitter.TabIndex = 12;
      // 
      // splitterLR
      // 
      this.splitterLR.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitterLR.Location = new System.Drawing.Point(0, 0);
      this.splitterLR.Name = "splitterLR";
      // 
      // splitterLR.Panel1
      // 
      this.splitterLR.Panel1.Controls.Add(this.fdlv);
      // 
      // splitterLR.Panel2
      // 
      this.splitterLR.Panel2.Controls.Add(this.splitterTB);
      this.splitterLR.Size = new System.Drawing.Size(778, 318);
      this.splitterLR.SplitterDistance = 416;
      this.splitterLR.TabIndex = 12;
      // 
      // splitterTB
      // 
      this.splitterTB.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitterTB.Location = new System.Drawing.Point(0, 0);
      this.splitterTB.Name = "splitterTB";
      this.splitterTB.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitterTB.Panel1
      // 
      this.splitterTB.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
      this.splitterTB.Panel1.Controls.Add(this.gbxTeamSchedulePlayed);
      this.splitterTB.Panel1.Controls.Add(this.gbxWL);
      this.splitterTB.Panel1.Controls.Add(this.txtSearch);
      this.splitterTB.Panel1.Controls.Add(this.label1);
      // 
      // splitterTB.Panel2
      // 
      this.splitterTB.Panel2.BackColor = System.Drawing.Color.LightGray;
      this.splitterTB.Panel2.Controls.Add(this.ucMatchDetails);
      this.splitterTB.Panel2.Controls.Add(this.ucLineup);
      this.splitterTB.Size = new System.Drawing.Size(358, 318);
      this.splitterTB.SplitterDistance = 98;
      this.splitterTB.TabIndex = 0;
      // 
      // ucMatchDetails
      // 
      this.ucMatchDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ucMatchDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucMatchDetails.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
      this.ucMatchDetails.CausesValidation = false;
      this.ucMatchDetails.Location = new System.Drawing.Point(3, 0);
      this.ucMatchDetails.Name = "ucMatchDetails";
      this.ucMatchDetails.Size = new System.Drawing.Size(352, 27);
      this.ucMatchDetails.TabIndex = 8;
      // 
      // ucLineup
      // 
      this.ucLineup.AutoSize = true;
      this.ucLineup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucLineup.BackColorAway = System.Drawing.Color.LightGreen;
      this.ucLineup.BackColorHome = System.Drawing.Color.LightCoral;
      this.ucLineup.Location = new System.Drawing.Point(9, 33);
      this.ucLineup.Name = "ucLineup";
      this.ucLineup.Size = new System.Drawing.Size(346, 153);
      this.ucLineup.TabIndex = 11;
      // 
      // tlpRating
      // 
      this.tlpRating.ColumnCount = 2;
      this.tlpRating.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tlpRating.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tlpRating.Controls.Add(this.ucRatingHome, 0, 0);
      this.tlpRating.Controls.Add(this.ucRatingAway, 1, 0);
      this.tlpRating.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tlpRating.Location = new System.Drawing.Point(0, 0);
      this.tlpRating.Name = "tlpRating";
      this.tlpRating.RowCount = 1;
      this.tlpRating.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tlpRating.Size = new System.Drawing.Size(778, 151);
      this.tlpRating.TabIndex = 11;
      // 
      // ucRatingHome
      // 
      this.ucRatingHome.AutoSize = true;
      this.ucRatingHome.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucRatingHome.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucRatingHome.Location = new System.Drawing.Point(3, 3);
      this.ucRatingHome.Name = "ucRatingHome";
      this.ucRatingHome.RatingType = AndreiPopescu.CharazayPlus.UI.RatingType.Home;
      this.ucRatingHome.Size = new System.Drawing.Size(383, 145);
      this.ucRatingHome.TabIndex = 9;
      // 
      // ucRatingAway
      // 
      this.ucRatingAway.AutoSize = true;
      this.ucRatingAway.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucRatingAway.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucRatingAway.Location = new System.Drawing.Point(392, 3);
      this.ucRatingAway.Name = "ucRatingAway";
      this.ucRatingAway.RatingType = AndreiPopescu.CharazayPlus.UI.RatingType.Away;
      this.ucRatingAway.Size = new System.Drawing.Size(383, 145);
      this.ucRatingAway.TabIndex = 10;
      // 
      // TeamScheduleUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitter);
      this.Name = "TeamScheduleUserControl";
      this.Size = new System.Drawing.Size(778, 473);
      this.gbxWL.ResumeLayout(false);
      this.gbxWL.PerformLayout();
      this.gbxTeamSchedulePlayed.ResumeLayout(false);
      this.gbxTeamSchedulePlayed.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.fdlv)).EndInit();
      this.splitter.Panel1.ResumeLayout(false);
      this.splitter.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
      this.splitter.ResumeLayout(false);
      this.splitterLR.Panel1.ResumeLayout(false);
      this.splitterLR.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitterLR)).EndInit();
      this.splitterLR.ResumeLayout(false);
      this.splitterTB.Panel1.ResumeLayout(false);
      this.splitterTB.Panel1.PerformLayout();
      this.splitterTB.Panel2.ResumeLayout(false);
      this.splitterTB.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitterTB)).EndInit();
      this.splitterTB.ResumeLayout(false);
      this.tlpRating.ResumeLayout(false);
      this.tlpRating.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private GroupBox gbxTeamSchedulePlayed;
    private RadioButton rdPlayedNo;
    private RadioButton rdPlayedYes;
    private RadioButton rdPlayedAll;
    private GroupBox gbxWL;
    private RadioButton rdWLLost;
    private RadioButton rdWLAll;
    private RadioButton rdWLWin;

    private void rdPlayed_CheckedChanged (object sender, EventArgs e)
    {
      this.fdlv.UseFiltering = true;
      if (rdPlayedYes.Checked)
        this.fdlv.ModelFilter = new ModelFilter((x)=>((Xsd2.match)x).Played);
      else if (rdPlayedNo.Checked)
        this.fdlv.ModelFilter = new ModelFilter((x) => !((Xsd2.match)x).Played);
      else
        this.fdlv.ModelFilter = null;      
    }

    private void rdWL_CheckedChanged (object sender, EventArgs e)
    {
      this.fdlv.UseFiltering = true;
      if (rdWLWin.Checked)
        this.fdlv.ModelFilter = new ModelFilter((x) => ((Xsd2.match)x).Won);
      else if (rdWLLost.Checked)
        this.fdlv.ModelFilter = new ModelFilter((x) => !((Xsd2.match)x).Won);
      else
        this.fdlv.ModelFilter = null;   
        //if (filter == null)
        //         fdlv.DefaultRenderer = null;
        //     else {
        //       fdlv.DefaultRenderer = new HighlightTextRenderer(filter);
 
                 // Uncomment this line to see how the GDI+ rendering looks
                 //olv.DefaultRenderer = new HighlightTextRenderer { Filter = filter, UseGdiTextRendering = false };
             //}
      
    }

    private void chklstMatchTypes_SelectedValueChanged (object sender, EventArgs e)
    {
      ////this.fdlv.UseFiltering = true;
      ////this.fdlv.ModelFilter = new ModelFilter((x) => 
      ////  this.chklstMatchTypes.SelectedItems
      ////  .Cast<Utils.MatchType>()
      ////  .Any(y => ((Xsd2.match)x).MatchType == y)
      ////  );
      
    }

    private void txtSearch_TextChanged (object sender, EventArgs e)
    {
       if (!String.IsNullOrEmpty(txtSearch.Text))
       {
         TextMatchFilter filter = TextMatchFilter.Contains(this.fdlv, this.txtSearch.Text);
          this.fdlv.DefaultRenderer = new HighlightTextRenderer(filter);
       }
       else
        this.fdlv.DefaultRenderer = null;
    }

    private void fdlv_SelectedIndexChanged (object sender, EventArgs e)
    {
      this.splitter.Panel2Collapsed = false;
      this.splitterTB.Panel2Collapsed = false;
      //
      Xsd2.match currentMatch = (Xsd2.match)this.fdlv.SelectedObject;
      //
     
        try
        {
          var SelectedMatch = Utils.Deserializer.GoGetMatchXml((ulong)currentMatch.Id);
          //
          ucMatchDetails.SetData(SelectedMatch);
          ucRatingHome.RatingType = UI.RatingType.Home;
          ucRatingHome.SetData(SelectedMatch.stats.home, SelectedMatch.bballs.home);
          ucRatingAway.RatingType = UI.RatingType.Away;
          ucRatingAway.SetData(SelectedMatch.stats.away, SelectedMatch.bballs.away);
          ucLineup.SetData(SelectedMatch.lineup);
          //
          AndreiPopescu.CharazayPlus.Utils.CacheManager.Instance.AddMatch(SelectedMatch);

        }
        catch (Exception ex)
        {
          System.Diagnostics.Debug.Write(ex.Message);
        }
      
    }

   

   

  }
}
