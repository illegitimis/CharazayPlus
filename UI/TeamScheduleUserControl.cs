

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
    }

    public void Init (Xsd2.match[] schedule, uint uid)
    {
      foreach(var m in schedule)
        m.MyTeamId = uid;
      foreach (var mt in schedule.Select(m => m.MatchType).Distinct())
        this.chklstMatchTypes.Items.Add(mt);

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
            e.Url = teamLink.m_uri.AbsoluteUri;
          } break;
        case 4:
          { // team
            Web.CharazayDownloadItem teamLink = new Web.CharazayDownloadItem("team", 0, s.AwayTeamId);
            e.Url = teamLink.m_uri.AbsoluteUri;
          } break;
        case 0:
          { // user
            Web.CharazayDownloadItem matchLink = new Web.CharazayDownloadItem("match", 0, s.Id);
            e.Url = matchLink.m_uri.AbsoluteUri;
          } break;

      default: break;
      }

    }

    private Label label1;
    private TextBox txtSearch;

  

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
      this.fdlv = new BrightIdeasSoftware.FastObjectListView();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.gbxWL = new System.Windows.Forms.GroupBox();
      this.rdWLLost = new System.Windows.Forms.RadioButton();
      this.rdWLAll = new System.Windows.Forms.RadioButton();
      this.rdWLWin = new System.Windows.Forms.RadioButton();
      this.gbxTeamSchedulePlayed = new System.Windows.Forms.GroupBox();
      this.rdPlayedNo = new System.Windows.Forms.RadioButton();
      this.rdPlayedYes = new System.Windows.Forms.RadioButton();
      this.rdPlayedAll = new System.Windows.Forms.RadioButton();
      this.chklstMatchTypes = new System.Windows.Forms.ListBox();
      this.label1 = new System.Windows.Forms.Label();
      this.txtSearch = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.fdlv)).BeginInit();
      this.tableLayoutPanel1.SuspendLayout();
      this.gbxWL.SuspendLayout();
      this.gbxTeamSchedulePlayed.SuspendLayout();
      this.SuspendLayout();
      // 
      // fdlv
      // 
      this.fdlv.AlternateRowBackColor = System.Drawing.Color.LightGray;
      this.fdlv.BackColor = System.Drawing.Color.Silver;
      this.fdlv.CausesValidation = false;
      this.fdlv.Dock = System.Windows.Forms.DockStyle.Fill;
      this.fdlv.Location = new System.Drawing.Point(3, 3);
      this.fdlv.Name = "fdlv";
      this.tableLayoutPanel1.SetRowSpan(this.fdlv, 5);
      this.fdlv.ShowGroups = false;
      this.fdlv.Size = new System.Drawing.Size(323, 332);
      this.fdlv.SortGroupItemsByPrimaryColumn = false;
      this.fdlv.Sorting = System.Windows.Forms.SortOrder.Ascending;
      this.fdlv.TabIndex = 0;
      this.fdlv.UseAlternatingBackColors = true;
      this.fdlv.UseCompatibleStateImageBehavior = false;
      this.fdlv.UseHyperlinks = true;
      this.fdlv.View = System.Windows.Forms.View.Details;
      this.fdlv.VirtualMode = true;
      this.fdlv.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(this.fdlv_HyperlinkClicked);
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
      this.tableLayoutPanel1.Controls.Add(this.gbxWL, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.fdlv, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.gbxTeamSchedulePlayed, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.chklstMatchTypes, 1, 2);
      this.tableLayoutPanel1.Controls.Add(this.label1, 1, 3);
      this.tableLayoutPanel1.Controls.Add(this.txtSearch, 1, 4);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 5;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(454, 338);
      this.tableLayoutPanel1.TabIndex = 1;
      // 
      // gbxWL
      // 
      this.gbxWL.Controls.Add(this.rdWLLost);
      this.gbxWL.Controls.Add(this.rdWLAll);
      this.gbxWL.Controls.Add(this.rdWLWin);
      this.gbxWL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gbxWL.Location = new System.Drawing.Point(332, 123);
      this.gbxWL.Name = "gbxWL";
      this.gbxWL.Size = new System.Drawing.Size(119, 114);
      this.gbxWL.TabIndex = 4;
      this.gbxWL.TabStop = false;
      this.gbxWL.Text = "Won/Lost";
      // 
      // rdWLLost
      // 
      this.rdWLLost.AutoSize = true;
      this.rdWLLost.Location = new System.Drawing.Point(5, 66);
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
      this.rdWLWin.Location = new System.Drawing.Point(6, 43);
      this.rdWLWin.Name = "rdWLWin";
      this.rdWLWin.Size = new System.Drawing.Size(48, 17);
      this.rdWLWin.TabIndex = 0;
      this.rdWLWin.Text = "Won";
      this.rdWLWin.UseVisualStyleBackColor = true;
      this.rdWLWin.CheckedChanged += new System.EventHandler(this.rdWL_CheckedChanged);
      // 
      // gbxTeamSchedulePlayed
      // 
      this.gbxTeamSchedulePlayed.Controls.Add(this.rdPlayedNo);
      this.gbxTeamSchedulePlayed.Controls.Add(this.rdPlayedYes);
      this.gbxTeamSchedulePlayed.Controls.Add(this.rdPlayedAll);
      this.gbxTeamSchedulePlayed.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gbxTeamSchedulePlayed.Location = new System.Drawing.Point(332, 3);
      this.gbxTeamSchedulePlayed.Name = "gbxTeamSchedulePlayed";
      this.gbxTeamSchedulePlayed.Size = new System.Drawing.Size(119, 114);
      this.gbxTeamSchedulePlayed.TabIndex = 1;
      this.gbxTeamSchedulePlayed.TabStop = false;
      this.gbxTeamSchedulePlayed.Text = "Played";
      // 
      // rdPlayedNo
      // 
      this.rdPlayedNo.AutoSize = true;
      this.rdPlayedNo.Location = new System.Drawing.Point(7, 66);
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
      this.rdPlayedYes.Location = new System.Drawing.Point(7, 43);
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
      // chklstMatchTypes
      // 
      this.chklstMatchTypes.Dock = System.Windows.Forms.DockStyle.Fill;
      this.chklstMatchTypes.FormattingEnabled = true;
      this.chklstMatchTypes.Location = new System.Drawing.Point(332, 243);
      this.chklstMatchTypes.Name = "chklstMatchTypes";
      this.chklstMatchTypes.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
      this.chklstMatchTypes.Size = new System.Drawing.Size(119, 37);
      this.chklstMatchTypes.TabIndex = 5;
      this.chklstMatchTypes.SelectedValueChanged += new System.EventHandler(this.chklstMatchTypes_SelectedValueChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label1.Location = new System.Drawing.Point(332, 283);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(119, 20);
      this.label1.TabIndex = 6;
      this.label1.Text = "Search";
      // 
      // txtSearch
      // 
      this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.txtSearch.Location = new System.Drawing.Point(332, 306);
      this.txtSearch.Name = "txtSearch";
      this.txtSearch.Size = new System.Drawing.Size(119, 22);
      this.txtSearch.TabIndex = 7;
      this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
      // 
      // TeamScheduleUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "TeamScheduleUserControl";
      this.Size = new System.Drawing.Size(454, 338);
      ((System.ComponentModel.ISupportInitialize)(this.fdlv)).EndInit();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.gbxWL.ResumeLayout(false);
      this.gbxWL.PerformLayout();
      this.gbxTeamSchedulePlayed.ResumeLayout(false);
      this.gbxTeamSchedulePlayed.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private FastObjectListView fdlv;
    Utils.MatchType[] _matchTypes;
    private TableLayoutPanel tableLayoutPanel1;
    private GroupBox gbxTeamSchedulePlayed;
    private RadioButton rdPlayedNo;
    private RadioButton rdPlayedYes;
    private RadioButton rdPlayedAll;
    private GroupBox gbxWL;
    private RadioButton rdWLLost;
    private RadioButton rdWLAll;
    private RadioButton rdWLWin;
    private ListBox chklstMatchTypes;

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
      this.fdlv.UseFiltering = true;
      this.fdlv.ModelFilter = new ModelFilter((x) => 
        this.chklstMatchTypes.SelectedItems
        .Cast<Utils.MatchType>()
        .Any(y => ((Xsd2.match)x).MatchType == y)
        );
      
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

  }
}
