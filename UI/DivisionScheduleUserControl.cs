

namespace AndreiPopescu.CharazayPlus.UI
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Drawing;
  using System.Data;
  using System.Text;
  using System.Windows.Forms;
  using AndreiPopescu.CharazayPlus.Utils;
  using System.IO;
  using System.Xml.Serialization;
  using System.Linq;

  public partial class DivisionScheduleUserControl : UserControl
  {
    public DivisionScheduleUserControl ( )
    {
      InitializeComponent();
    }

    public void InitOLV (Xsd2.charazayRound[] _myDivisionFullSchedule)
    {
      //olvcMd.AspectGetter = delegate(object row) { return (uint)(((Xsd2.charazayRound)row).match.id); };
      olvcMd.AspectGetter = delegate(object row) { return (Xsd2.charazayRoundMatch)(((Xsd2.charazayRound)row).match); };
      olvcMd.GroupKeyGetter = delegate(object o)
      {
        Xsd2.charazayRound round = (Xsd2.charazayRound)o;
        return string.Format("Round: {0:D02} {1:yyyy-MMMM-dd}", round.number
          , AndreiPopescu.CharazayPlus.Utils.Compute.EstimatedDateTime(round.date));
      };
      //this.olvcFullName.GroupKeyToTitleConverter = delegate(object groupKey)
      //{
      //  Country country = Defines.Countries[(int)groupKey];
      //  return string.Format("{0} (id={1})", country.Name, country.Id);
      //};
      olvMd.SetObjects(_myDivisionFullSchedule);
    }


    //private void olvMd_Click(object sender, EventArgs e)
    //{
    //  ObjectListView _olv = sender as ObjectListView;
    //  uint mid = ((Xsd2.charazayRound)_olv.SelectedObject).match.id;
    //}

    //private void olvMd_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    //{
    //  if (e.IsSelected)
    //  {
    //    ListViewItem li = e.Item;
    //    int i = e.ItemIndex;
    //  }
    //}

    private void olvMd_SelectionChanged (object sender, EventArgs e)
    {
      if (olvMd.SelectedObjects == null || olvMd.SelectedObjects.Count == 0)
        return;
      var v = olvMd.SelectedObjects[0] as Xsd2.charazayRound;
      if (v == null)
        return;

      MatchRating(v.match.id);
    }

    private void MatchRating (uint matchId)
    {
     
        try
        {
          var SelectedMatch = Utils.Deserializer.GoGetMatchXml ((ulong)matchId);
          //
          ucMatchDetails.SetData(SelectedMatch);
          ucrHome.RatingType = UI.RatingType.Home;
          ucrHome.SetData(SelectedMatch.stats.home, SelectedMatch.bballs.home);
          ucrAway.RatingType = UI.RatingType.Away;
          ucrAway.SetData(SelectedMatch.stats.away, SelectedMatch.bballs.away);
          ucLineup.SetData(SelectedMatch.lineup);
          //
          CacheManager.Instance.AddMatch(SelectedMatch);

        }
        catch (Exception ex)
        {
          System.Diagnostics.Debug.Write(ex.Message);
        }
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
      this.tlp = new System.Windows.Forms.TableLayoutPanel();
      this.olvMd = new BrightIdeasSoftware.ObjectListView();
      this.olvcMd = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.ucrHome = new AndreiPopescu.CharazayPlus.UI.RatingBballUserControl();
      this.ucLineup = new AndreiPopescu.CharazayPlus.UI.LineupHomeAwayUserControl();
      this.ucrAway = new AndreiPopescu.CharazayPlus.UI.RatingBballUserControl();
      this.ucMatchDetails = new AndreiPopescu.CharazayPlus.UI.MatchDetailsUserControl();
      this.tlp.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvMd)).BeginInit();
      this.SuspendLayout();
      // 
      // tlp
      // 
      this.tlp.ColumnCount = 2;
      this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
      this.tlp.Controls.Add(this.ucrHome, 1, 1);
      this.tlp.Controls.Add(this.ucLineup, 1, 3);
      this.tlp.Controls.Add(this.olvMd, 0, 0);
      this.tlp.Controls.Add(this.ucrAway, 1, 2);
      this.tlp.Controls.Add(this.ucMatchDetails, 1, 0);
      this.tlp.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tlp.Location = new System.Drawing.Point(0, 0);
      this.tlp.Name = "tlp";
      this.tlp.RowCount = 4;
      this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
      this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
      this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
      this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
      this.tlp.Size = new System.Drawing.Size(619, 556);
      this.tlp.TabIndex = 6;
      // 
      // olvMd
      // 
      this.olvMd.AllColumns.Add(this.olvcMd);
      this.olvMd.AlternateRowBackColor = System.Drawing.Color.Gainsboro;
      this.olvMd.BackColor = System.Drawing.Color.WhiteSmoke;
      this.olvMd.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcMd});
      this.olvMd.Dock = System.Windows.Forms.DockStyle.Fill;
      this.olvMd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.olvMd.FullRowSelect = true;
      this.olvMd.Location = new System.Drawing.Point(3, 3);
      this.olvMd.Name = "olvMd";
      this.tlp.SetRowSpan(this.olvMd, 4);
      this.olvMd.Size = new System.Drawing.Size(117, 550);
      this.olvMd.TabIndex = 0;
      this.olvMd.UseAlternatingBackColors = true;
      this.olvMd.UseCompatibleStateImageBehavior = false;
      this.olvMd.View = System.Windows.Forms.View.Details;
      this.olvMd.SelectionChanged += new System.EventHandler(this.olvMd_SelectionChanged);
      // 
      // olvcMd
      // 
      this.olvcMd.CellPadding = null;
      this.olvcMd.FillsFreeSpace = true;
      this.olvcMd.Text = "Match Id";
      this.olvcMd.Width = 208;
      // 
      // ucrHome
      // 
      this.ucrHome.AutoSize = true;
      this.ucrHome.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucrHome.BackColor = System.Drawing.Color.Gainsboro;
      this.ucrHome.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucrHome.Location = new System.Drawing.Point(126, 42);
      this.ucrHome.Name = "ucrHome";
      this.ucrHome.RatingType = AndreiPopescu.CharazayPlus.UI.RatingType.Home;
      this.ucrHome.Size = new System.Drawing.Size(490, 174);
      this.ucrHome.TabIndex = 2;
      // 
      // ucLineup
      // 
      this.ucLineup.AutoSize = true;
      this.ucLineup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucLineup.BackColor = System.Drawing.Color.LightGray;
      this.ucLineup.BackColorAway = System.Drawing.Color.LawnGreen;
      this.ucLineup.BackColorHome = System.Drawing.Color.IndianRed;
      this.ucLineup.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucLineup.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.ucLineup.Location = new System.Drawing.Point(126, 402);
      this.ucLineup.Name = "ucLineup";
      this.ucLineup.Size = new System.Drawing.Size(490, 151);
      this.ucLineup.TabIndex = 4;
      // 
      // ucrAway
      // 
      this.ucrAway.AutoSize = true;
      this.ucrAway.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucrAway.BackColor = System.Drawing.Color.LightGray;
      this.ucrAway.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucrAway.Location = new System.Drawing.Point(126, 222);
      this.ucrAway.Name = "ucrAway";
      this.ucrAway.RatingType = AndreiPopescu.CharazayPlus.UI.RatingType.Away;
      this.ucrAway.Size = new System.Drawing.Size(490, 174);
      this.ucrAway.TabIndex = 3;
      // 
      // ucMatchDetails
      // 
      this.ucMatchDetails.AutoSize = true;
      this.ucMatchDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucMatchDetails.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
      this.ucMatchDetails.CausesValidation = false;
      this.ucMatchDetails.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucMatchDetails.Location = new System.Drawing.Point(126, 3);
      this.ucMatchDetails.Name = "ucMatchDetails";
      this.ucMatchDetails.Size = new System.Drawing.Size(490, 33);
      this.ucMatchDetails.TabIndex = 5;
      // 
      // DivisionScheduleUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tlp);
      this.Name = "DivisionScheduleUserControl";
      this.Size = new System.Drawing.Size(619, 556);
      this.tlp.ResumeLayout(false);
      this.tlp.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvMd)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tlp;
    private RatingBballUserControl ucrHome;
    private LineupHomeAwayUserControl ucLineup;
    private BrightIdeasSoftware.ObjectListView olvMd;
    private BrightIdeasSoftware.OLVColumn olvcMd;
    private RatingBballUserControl ucrAway;
    private MatchDetailsUserControl ucMatchDetails;
  
  }
}
