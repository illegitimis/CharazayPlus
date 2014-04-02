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

  public partial class MyEconomyUserControl : UserControl
  {
    public MyEconomyUserControl ( )
    {
      InitializeComponent();
    }

    /// <summary>
    /// my team transfer history
    /// tab: My Economy
    /// </summary>
    [Obsolete("OLV instead of grid")]
    public void InitDgMyTransfers (Xsd2.charazayTransfer[] _myTransfers)
    {
#if DOTNET30
      dgTeamTransfers.initGridPrologue ();            
      dgTeamTransfers.GenerateTextBoxColumn( "Seller", "Seller");
      dgTeamTransfers.GenerateTextBoxColumn( "Buyer", "Buyer");
      dgTeamTransfers.GenerateTextBoxColumn( "Date", "Date");
      dgTeamTransfers.GenerateTextBoxColumn( "Player", "Player");
      dgTeamTransfers.GenerateTextBoxColumn( "Skill Index", "si");
      dgTeamTransfers.GenerateTextBoxColumn( "Price", "price");
      dgTeamTransfers.initGridEpilogue<Xsd2.charazayTransfer> (_myTransfers);      
#else
      DataGridExtensions.initGridPrologue(dgTeamTransfers);
      DataGridExtensions.GenerateTextBoxColumn(dgTeamTransfers, "Seller", "Seller");
      DataGridExtensions.GenerateTextBoxColumn(dgTeamTransfers, "Buyer", "Buyer");
      DataGridExtensions.GenerateTextBoxColumn(dgTeamTransfers, "Date", "Date");
      DataGridExtensions.GenerateTextBoxColumn(dgTeamTransfers, "Player", "Player");
      DataGridExtensions.GenerateTextBoxColumn(dgTeamTransfers, "Skill Index", "si");
      DataGridExtensions.GenerateTextBoxColumn(dgTeamTransfers, "Price", "price");
      DataGridExtensions.initGridEpilogue<Xsd2.charazayTransfer>(dgTeamTransfers, _myTransfers);
#endif
    }

    public void InitOLV (Xsd2.charazayTransfer[] transfers)
    {
      Generator.GenerateColumns(this.olv, typeof(Xsd2.charazayTransfer));
      foreach (OLVColumn col in this.olv.Columns)
      {
        switch (col.DisplayIndex)
        {
          // seller
          case 0:
            col.GroupKeyGetter = delegate(object row) { return ((Xsd2.charazayTransfer)row).sellteam == _myTeamId; };
            col.GroupKeyToTitleConverter = delegate(object groupKey) { string s = (bool)groupKey ? "by me" : "to me"; return "Sold " + s; };
            break;
          //buyer
          case 1:
            col.GroupKeyGetter = delegate(object row) { return ((Xsd2.charazayTransfer)row).buyteam == _myTeamId; };
            col.GroupKeyToTitleConverter = delegate(object groupKey) { string s = (bool)groupKey ? "by me" : "from me"; return "Bought " + s; };
            break;
          //date
          case 2:
            col.GroupKeyGetter = delegate(object row) { CharazayDate cd = ((Xsd2.charazayTransfer)row).Date; return cd.Season; };
            col.GroupKeyToTitleConverter = delegate(object groupKey) { return string.Format("Season {0}", (byte)groupKey); };
            break;
          //player
          case 3:
            col.Groupable = false;
            break;
          //price
          case 4:
            {
              uint k = 100000u;
              uint m = 10u * k;
              uint[] priceMarkers = new uint[] { k, 3u * k, m, 2u * m, 3u * m, 5u * m, 7u * m, 10u * m, 15u * m, 20u * m, 25u * m, 30u * m, 40u * m, 50u * m, 75u * m, 100u * m };
              col.MakeGroupies(priceMarkers, ObjectListViewExtensions.BuildCustomGroupies<uint>(priceMarkers));
            }
            break;
          //si
          case 5:
            { 
            uint k = 1000u; uint m = 10000u; uint n = 100000u;
            uint[] siMarkers = new uint[] { m, 15u * k, 2 * m, 3u * m, 5 * m, 7 * m, n, 12 * m, 15 * m, 175 * k, 2 * n, 25 * m, 3 * n, 35 * m, 4 * n, 5 * n, 6 * n, 7 * n, 8 * n };
            col.MakeGroupies(siMarkers, ObjectListViewExtensions.BuildCustomGroupies<uint>(siMarkers));
            }
            break;
        }
      }
      this.olv.SetObjects(transfers);

    }


    public void InitEconomyUserControls (Xsd2.charazayEconomy _economy)
    {
      ucEconomyWeek.LabelsInit(_economy.economy_week.income, _economy.economy_week.expences, true);
      ucEconomySeason.LabelsInit(_economy.economy_season.income, _economy.economy_season.expences, false);
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
      this.label54 = new System.Windows.Forms.Label();
      this.dgTeamTransfers = new System.Windows.Forms.DataGridView();
      this.olv = new BrightIdeasSoftware.ObjectListView();
      this.label1 = new System.Windows.Forms.Label();
      this.ucEconomyWeek = new AndreiPopescu.CharazayPlus.EconomyUserControl();
      this.ucEconomySeason = new AndreiPopescu.CharazayPlus.EconomyUserControl();
      ((System.ComponentModel.ISupportInitialize)(this.dgTeamTransfers)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.olv)).BeginInit();
      this.SuspendLayout();
      // 
      // label54
      // 
      this.label54.AutoSize = true;
      this.label54.Location = new System.Drawing.Point(3, 3);
      this.label54.Name = "label54";
      this.label54.Size = new System.Drawing.Size(98, 13);
      this.label54.TabIndex = 1;
      this.label54.Text = "My Team Transfers";
      // 
      // dgTeamTransfers
      // 
      this.dgTeamTransfers.Location = new System.Drawing.Point(0, 0);
      this.dgTeamTransfers.Name = "dgTeamTransfers";
      this.dgTeamTransfers.Size = new System.Drawing.Size(240, 150);
      this.dgTeamTransfers.TabIndex = 0;
      // 
      // olv
      // 
      this.olv.AlternateRowBackColor = System.Drawing.Color.Gray;
      this.olv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.olv.BackColor = System.Drawing.Color.DimGray;
      this.olv.Cursor = System.Windows.Forms.Cursors.Default;
      this.olv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.olv.ForeColor = System.Drawing.Color.White;
      this.olv.FullRowSelect = true;
      this.olv.Location = new System.Drawing.Point(6, 20);
      this.olv.Name = "olv";
      this.olv.Size = new System.Drawing.Size(176, 426);
      this.olv.SortGroupItemsByPrimaryColumn = false;
      this.olv.TabIndex = 2;
      this.olv.UseCompatibleStateImageBehavior = false;
      this.olv.UseHyperlinks = true;
      this.olv.View = System.Windows.Forms.View.Details;
      this.olv.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(this.olv_HyperlinkClicked);
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(490, 4);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(93, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "My Team Balance";
      // 
      // ucEconomyWeek
      // 
      this.ucEconomyWeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ucEconomyWeek.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucEconomyWeek.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
      this.ucEconomyWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.ucEconomyWeek.Location = new System.Drawing.Point(188, 20);
      this.ucEconomyWeek.Name = "ucEconomyWeek";
      this.ucEconomyWeek.Size = new System.Drawing.Size(395, 170);
      this.ucEconomyWeek.TabIndex = 0;
      // 
      // ucEconomySeason
      // 
      this.ucEconomySeason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ucEconomySeason.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucEconomySeason.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
      this.ucEconomySeason.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.ucEconomySeason.Location = new System.Drawing.Point(188, 196);
      this.ucEconomySeason.Name = "ucEconomySeason";
      this.ucEconomySeason.Size = new System.Drawing.Size(395, 170);
      this.ucEconomySeason.TabIndex = 0;
      // 
      // MyEconomyUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.label1);
      this.Controls.Add(this.olv);
      this.Controls.Add(this.label54);
      this.Controls.Add(this.ucEconomyWeek);
      this.Controls.Add(this.ucEconomySeason);
      this.Name = "MyEconomyUserControl";
      this.Size = new System.Drawing.Size(586, 449);
      ((System.ComponentModel.ISupportInitialize)(this.dgTeamTransfers)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.olv)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    #region fields
    private System.Windows.Forms.Label label54;
    private System.Windows.Forms.DataGridView dgTeamTransfers;
    private EconomyUserControl ucEconomyWeek;
    private EconomyUserControl ucEconomySeason;
    private BrightIdeasSoftware.ObjectListView olv;
    private Label label1;
    private  uint _myTeamId;
    #endregion

    private void olv_HyperlinkClicked (object sender, HyperlinkClickedEventArgs e)
    {
      Xsd2.charazayTransfer transfer = (Xsd2.charazayTransfer)e.Item.RowObject;
      if (transfer == null)
        return;
      //
      switch (e.ColumnIndex)
      {
        case 0:
          { //seller
            Web.CharazayDownloadItem teamLink = new Web.CharazayDownloadItem("team", 0, transfer.sellteam);
            e.Url = teamLink.m_uri.AbsoluteUri;
          } break;
        case 1:
          { //buyer
            Web.CharazayDownloadItem teamLink = new Web.CharazayDownloadItem("team", 0, transfer.buyteam);
            e.Url = teamLink.m_uri.AbsoluteUri;
          } break;
        case 3:
          { //player
            Web.CharazayDownloadItem teamLink = new Web.CharazayDownloadItem("player", 1, transfer.playerid);
            e.Url = teamLink.m_uri.AbsoluteUri;
          } break;
        default: break;
      }

    }

    public uint MyTeamId { get { return _myTeamId; } set { _myTeamId = value; } }
  }
}
