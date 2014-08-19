namespace AndreiPopescu.CharazayPlus.UI
{
  using System;
  using System.ComponentModel;
  using System.IO;
  using System.Data;
  using System.Drawing;
  using System.Drawing.Drawing2D;
  using System.Collections;
  using System.Collections.Generic;
  using System.Windows.Forms;
  using System.Diagnostics;
  using BrightIdeasSoftware;
  using AndreiPopescu.CharazayPlus.Data;
  
  
  /// <summary>
  /// Description of MainForm.
  /// </summary>
  public class PlayerSkillsUserControl : UserControl
  {
    #region designer

    /// <summary>
    /// Designer variable used to keep track of non-visual components.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Disposes resources used by the form.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose (bool disposing)
    {
      if (disposing)
      {
        if (components != null)
        {
          components.Dispose();
        }
      }
      base.Dispose(disposing);
    }

    /// <summary>
    /// This method is required for Windows Forms designer support.
    /// Do not change the method contents inside the source code editor. The Forms designer might
    /// not be able to load this method if it was changed manually.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
      "Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters", MessageId = "System.Windows.Forms.Control.set_Text(System.String)")]
    private void InitializeComponent ( )
    {
      this.components = new System.ComponentModel.Container();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.imageList2 = new System.Windows.Forms.ImageList(this.components);
      this.olvComplex = new BrightIdeasSoftware.ObjectListView();
      this.olvcFN = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcDef = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcDefA = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcFT = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcFTA = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvc2p = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvc2pA = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvc3p = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvc3pA = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcDri = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcDriA = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcPas = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcPasA = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcSpe = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcSpeA = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcFtw = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcFtwA = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcReb = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcRebA = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcValueIndex = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcPosSk = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcPosH = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.groupImageList = new System.Windows.Forms.ImageList(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.olvComplex)).BeginInit();
      this.SuspendLayout();
      // 
      // imageList1
      // 
      this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
      this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // imageList2
      // 
      this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
      this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
      this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // olvComplex
      // 
      this.olvComplex.AllColumns.Add(this.olvcFN);
      this.olvComplex.AllColumns.Add(this.olvcDef);
      this.olvComplex.AllColumns.Add(this.olvcDefA);
      this.olvComplex.AllColumns.Add(this.olvcFT);
      this.olvComplex.AllColumns.Add(this.olvcFTA);
      this.olvComplex.AllColumns.Add(this.olvc2p);
      this.olvComplex.AllColumns.Add(this.olvc2pA);
      this.olvComplex.AllColumns.Add(this.olvc3p);
      this.olvComplex.AllColumns.Add(this.olvc3pA);
      this.olvComplex.AllColumns.Add(this.olvcDri);
      this.olvComplex.AllColumns.Add(this.olvcDriA);
      this.olvComplex.AllColumns.Add(this.olvcPas);
      this.olvComplex.AllColumns.Add(this.olvcPasA);
      this.olvComplex.AllColumns.Add(this.olvcSpe);
      this.olvComplex.AllColumns.Add(this.olvcSpeA);
      this.olvComplex.AllColumns.Add(this.olvcFtw);
      this.olvComplex.AllColumns.Add(this.olvcFtwA);
      this.olvComplex.AllColumns.Add(this.olvcReb);
      this.olvComplex.AllColumns.Add(this.olvcRebA);
      this.olvComplex.AllColumns.Add(this.olvcValueIndex);
      this.olvComplex.AllColumns.Add(this.olvcPosSk);
      this.olvComplex.AllColumns.Add(this.olvcPosH);
      this.olvComplex.AllowColumnReorder = true;
      this.olvComplex.AllowDrop = true;
      this.olvComplex.AlternateRowBackColor = System.Drawing.Color.LightGray;
      this.olvComplex.BackColor = System.Drawing.Color.Silver;
      this.olvComplex.CheckedAspectName = "";
      this.olvComplex.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcFN,
            this.olvcDef,
            this.olvcDefA,
            this.olvcFT,
            this.olvcFTA,
            this.olvc2p,
            this.olvc2pA,
            this.olvc3p,
            this.olvc3pA,
            this.olvcDri,
            this.olvcDriA,
            this.olvcPas,
            this.olvcPasA,
            this.olvcSpe,
            this.olvcSpeA,
            this.olvcFtw,
            this.olvcFtwA,
            this.olvcReb,
            this.olvcRebA,
            this.olvcValueIndex,
            this.olvcPosSk,
            this.olvcPosH});
      this.olvComplex.Cursor = System.Windows.Forms.Cursors.Default;
      this.olvComplex.Dock = System.Windows.Forms.DockStyle.Fill;
      this.olvComplex.EmptyListMsg = "This list is empty. Press \"Add\" to create some items";
      this.olvComplex.ForeColor = System.Drawing.Color.Black;
      this.olvComplex.FullRowSelect = true;
      this.olvComplex.GroupImageList = this.groupImageList;
      this.olvComplex.GroupWithItemCountFormat = "{0} ({1} people)";
      this.olvComplex.GroupWithItemCountSingularFormat = "{0} ({1} Player)";
      this.olvComplex.HeaderUsesThemes = false;
      this.olvComplex.HeaderWordWrap = true;
      this.olvComplex.HideSelection = false;
      this.olvComplex.LargeImageList = this.imageList2;
      this.olvComplex.Location = new System.Drawing.Point(0, 0);
      this.olvComplex.Name = "olvComplex";
      this.olvComplex.OverlayImage.Alignment = System.Drawing.ContentAlignment.BottomLeft;
      this.olvComplex.OverlayText.Alignment = System.Drawing.ContentAlignment.TopRight;
      this.olvComplex.OverlayText.BorderColor = System.Drawing.Color.DarkRed;
      this.olvComplex.OverlayText.BorderWidth = 4F;
      this.olvComplex.OverlayText.InsetX = 10;
      this.olvComplex.OverlayText.InsetY = 35;
      this.olvComplex.OverlayText.Rotation = 20;
      this.olvComplex.OverlayText.Text = "";
      this.olvComplex.OverlayText.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
      this.olvComplex.OwnerDraw = true;
      this.olvComplex.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
      this.olvComplex.ShowCommandMenuOnRightClick = true;
      this.olvComplex.ShowGroups = false;
      this.olvComplex.ShowImagesOnSubItems = true;
      this.olvComplex.ShowItemCountOnGroups = true;
      this.olvComplex.ShowItemToolTips = true;
      this.olvComplex.Size = new System.Drawing.Size(907, 374);
      this.olvComplex.SmallImageList = this.imageList1;
      this.olvComplex.TabIndex = 0;
      this.olvComplex.UseAlternatingBackColors = true;
      this.olvComplex.UseCompatibleStateImageBehavior = false;
      this.olvComplex.UseFilterIndicator = true;
      this.olvComplex.UseFiltering = true;
      this.olvComplex.UseHotItem = true;
      this.olvComplex.UseHyperlinks = true;
      this.olvComplex.UseSubItemCheckBoxes = true;
      this.olvComplex.View = System.Windows.Forms.View.Details;
      this.olvComplex.BeforeCreatingGroups += new System.EventHandler<BrightIdeasSoftware.CreateGroupsEventArgs>(this.olvComplex_BeforeCreatingGroups);
      this.olvComplex.CellOver += new System.EventHandler<BrightIdeasSoftware.CellOverEventArgs>(this.listViewComplex_CellOver);
      this.olvComplex.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.listViewComplex_CellRightClick);
      this.olvComplex.CellToolTipShowing += new System.EventHandler<BrightIdeasSoftware.ToolTipShowingEventArgs>(this.listViewComplex_CellToolTip);
      this.olvComplex.GroupStateChanged += new System.EventHandler<BrightIdeasSoftware.GroupStateChangedEventArgs>(this.olv_GroupStateChanged);
      this.olvComplex.HeaderToolTipShowing += new System.EventHandler<BrightIdeasSoftware.ToolTipShowingEventArgs>(this.listViewComplex_HeaderToolTipShowing);
      this.olvComplex.HotItemChanged += new System.EventHandler<BrightIdeasSoftware.HotItemChangedEventArgs>(this.olv_HotItemChanged);
      this.olvComplex.GroupTaskClicked += new System.EventHandler<BrightIdeasSoftware.GroupTaskClickedEventArgs>(this.listViewComplex_GroupTaskClicked);
      this.olvComplex.SelectedIndexChanged += new System.EventHandler(this.ListViewSelectedIndexChanged);
      // 
      // olvcFN
      // 
      this.olvcFN.AspectName = "FullName";
      this.olvcFN.CellPadding = null;
      this.olvcFN.HeaderImageKey = "(none)";
      this.olvcFN.ImageAspectName = "";
      this.olvcFN.Text = "Player";
      this.olvcFN.ToolTipText = "Tooltip for Player column. This was configurated in the IDE. (Hold down Control t" +
    "o see a different tooltip)";
      this.olvcFN.UseInitialLetterForGroup = true;
      this.olvcFN.Width = 180;
      // 
      // olvcDef
      // 
      this.olvcDef.CellPadding = null;
      // 
      // olvcDefA
      // 
      this.olvcDefA.CellPadding = null;
      // 
      // olvcFT
      // 
      this.olvcFT.CellPadding = null;
      // 
      // olvcFTA
      // 
      this.olvcFTA.CellPadding = null;
      // 
      // olvc2p
      // 
      this.olvc2p.CellPadding = null;
      // 
      // olvc2pA
      // 
      this.olvc2pA.CellPadding = null;
      // 
      // olvc3p
      // 
      this.olvc3p.CellPadding = null;
      // 
      // olvc3pA
      // 
      this.olvc3pA.CellPadding = null;
      // 
      // olvcDri
      // 
      this.olvcDri.CellPadding = null;
      // 
      // olvcDriA
      // 
      this.olvcDriA.CellPadding = null;
      // 
      // olvcPas
      // 
      this.olvcPas.CellPadding = null;
      // 
      // olvcPasA
      // 
      this.olvcPasA.CellPadding = null;
      // 
      // olvcSpe
      // 
      this.olvcSpe.CellPadding = null;
      // 
      // olvcSpeA
      // 
      this.olvcSpeA.CellPadding = null;
      // 
      // olvcFtw
      // 
      this.olvcFtw.CellPadding = null;
      // 
      // olvcFtwA
      // 
      this.olvcFtwA.CellPadding = null;
      // 
      // olvcReb
      // 
      this.olvcReb.CellPadding = null;
      // 
      // olvcRebA
      // 
      this.olvcRebA.CellPadding = null;
      // 
      // olvcValueIndex
      // 
      this.olvcValueIndex.CellPadding = null;
      // 
      // olvcPosSk
      // 
      this.olvcPosSk.CellPadding = null;
      // 
      // olvcPosH
      // 
      this.olvcPosH.CellPadding = null;
      // 
      // groupImageList
      // 
      this.groupImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
      this.groupImageList.ImageSize = new System.Drawing.Size(16, 16);
      this.groupImageList.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // PlayerSkillsUserControl
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.olvComplex);
      this.Name = "PlayerSkillsUserControl";
      this.Size = new System.Drawing.Size(907, 374);
      this.Load += new System.EventHandler(this.MainForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.olvComplex)).EndInit();
      this.ResumeLayout(false);

    }

    private void OlvColumnsPropertiesInit ( )
    {
      // 
      // olvcDef
      // 
      this.olvcDef.CellPadding = null;
      this.olvcDef.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.olvcDef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.InitDisplayColumn(this.olvcDef, "Defence");
      // 
      // olvcDefA
      // 
      this.olvcDefA.CellPadding = null;
      this.olvcDefA.GroupWithItemCountFormat = "{0} ({1} candidates)";
      this.olvcDefA.GroupWithItemCountSingularFormat = "{0} (only {1} candidate)";
      this.olvcDefA.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvcDefA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvcDefA.ToolTipText = "Group on this column to see full group formatting possibilities";
      this.InitActiveColumn(this.olvcDefA, "Defence");
      // 
      // olvcFT
      // 
      this.olvcFT.CellPadding = null;
      this.olvcFT.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.InitDisplayColumn(this.olvcFT, "Freethrows");
      // 
      // olvcFTA
      // 
      this.olvcFTA.CellPadding = null;
      //this.olvcFTA.GroupWithItemCountFormat = "{0} has {1} birthdays";
      //this.olvcFTA.GroupWithItemCountSingularFormat = "{0} has only {1} birthday";
      this.InitActiveColumn(this.olvcFTA, "Freethrows");
      // 
      // olvc2p
      // 
      this.olvc2p.CellPadding = null;
      this.InitDisplayColumn(this.olvc2p, "TwoPoint");
      // 
      // olvc2pA
      // 
      this.olvc2pA.CellPadding = null;
      this.InitActiveColumn(this.olvc2pA, "TwoPoint");
      // 
      // olvc3p
      // 
      this.olvc3p.CellPadding = null;
      this.InitDisplayColumn(this.olvc3p, "ThreePoint");
      // 
      // olvc3pA
      // 
      this.olvc3pA.CellPadding = null;
      this.olvc3pA.ToolTipText = "estimation of 3p skill used by engine";
      this.InitActiveColumn(this.olvc3pA, "ThreePoint");
      // 
      // olvcDri
      // 
      this.olvcDri.CellPadding = null;
      this.olvcDri.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.olvcDri.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.InitDisplayColumn(this.olvcDri, "Dribling");
      // 
      // olvcDriA
      // 
      this.olvcDriA.CellPadding = null;
      this.olvcDriA.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.olvcDriA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.InitActiveColumn(this.olvcDriA, "Dribling");
      // 
      // olvcPas
      // 
      this.InitDisplayColumn(this.olvcPas, "Passing");
      // 
      // olvcPasA
      //       
      this.InitActiveColumn(this.olvcPasA, "Passing");
      // 
      // olvcSpe
      //       
      this.InitDisplayColumn(this.olvcSpe, "Speed");
      // 
      // olvcSpeA
      // 
      this.InitActiveColumn(this.olvcSpeA, "Speed");
      // 
      // olvcFtw
      // 
      this.InitDisplayColumn(this.olvcFtw, "Footwork");
      // 
      // olvcFtwA
      // 
      this.InitActiveColumn(this.olvcFtwA, "Footwork");
      // 
      // olvcReb
      // 
      this.InitDisplayColumn(this.olvcReb, "Rebounds");
      // 
      // olvcRebA
      // 
      this.InitActiveColumn(this.olvcRebA, "Rebounds");
      //
      //nkotb
      //
      this.olvcValueIndex.AspectName = "ValueIndex";
      this.olvcValueIndex.AspectToStringFormat = "{0:F02}";
      this.olvcValueIndex.Text = "Value Index";
      this.olvcValueIndex.IsHeaderVertical = true;
      this.olvcValueIndex.IsEditable = false;
      this.olvcValueIndex.Width = 59;
      //
      this.olvcPosSk.AspectName = "PositionEnum";
      this.olvcPosSk.Text = "Position by skill";
      this.olvcPosSk.IsHeaderVertical = true;
      this.olvcPosSk.IsEditable = false;
      this.olvcPosSk.Width = 59;
      //
      this.olvcPosH.AspectName = "PositionHeightBased";
      this.olvcPosH.Text = "Position by height";
      this.olvcPosH.IsHeaderVertical = true;
      this.olvcPosH.IsEditable = false;
      this.olvcPosH.Width = 59;
    }

    private void InitDisplayColumn (OLVColumn col, string text)
    {
      col.AspectName = text+"_Display";
      col.Text = text;
      col.IsHeaderVertical = true;
      col.IsTileViewColumn = true;
      col.IsEditable = false;
      col.Width = 41;
    }

    private void InitActiveColumn (OLVColumn col, string text)
    {
      col.AspectName = text;
      col.AspectToStringFormat = "{0:F02}";
      col.Text = "Active " + text;
      col.IsHeaderVertical = true;
      col.IsTileViewColumn = true;
      col.IsEditable = false;
      col.Width = 59;
    }

    // verified
    //private MultiImageRenderer salaryRenderer;
    //private MultiImageRenderer cookingSkillRenderer;
    private ImageList groupImageList;
    private OLVColumn olvcDri;
    private OLVColumn olvcDriA;
    private OLVColumn olvcPas;
    private OLVColumn olvcPasA;
    private OLVColumn olvcSpe;
    private OLVColumn olvcSpeA;
    private OLVColumn olvcFtw;
    private OLVColumn olvcFtwA;
    private OLVColumn olvcReb;
    private OLVColumn olvcRebA;
    OLVColumn olvcValueIndex;
    OLVColumn olvcPosSk;
    OLVColumn olvcPosH;
    private OLVColumn olvcFT;
    private OLVColumn olvcDef;
    private OLVColumn olvc3p;
    private OLVColumn olvcFN;
    private OLVColumn olvcDefA;
    private OLVColumn olvcFTA;
    private OLVColumn olvc2p;
    private ObjectListView olvComplex;
    private BrightIdeasSoftware.OLVColumn olvc2pA;
    private System.Windows.Forms.ImageList imageList1;
    private ImageList imageList2;
    private OLVColumn olvc3pA;
    #endregion

   
    /// <summary>
    ///
    /// </summary>
    public PlayerSkillsUserControl ()
    { //
      // The InitializeComponent() call is required for Windows Forms designer support.
      //
      InitializeComponent();
      OlvColumnsPropertiesInit();
    }

    public void Initialize ( )
    {
      // Use different font under Vista
      if (ObjectListView.IsVistaOrLater)
        this.Font = new Font("Segoe UI", 9);     
      
      InitializeComplexExample();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="list"></param>
    void InitializeComplexExample ()
    {
      this.olvComplex.AddDecoration(new EditingCellBorderDecoration(true));

      this.olvcFN.AspectToStringConverter = delegate(object cellValue) { return ((String)cellValue).ToUpperInvariant(); };
     
      this.olvcDefA.MakeGroupies(
        new object[] { 6D, 11D, 16D, 21D }                                      //values
        , new string[] { "Really poor", "Bad", "Decent", "Good", "Mega" }       //descriptions
        , new string[] { "not", "hamburger", "toast", "beef", "chef" }          //images
        , new string[] {
                    "This guy won't stop your grandma",
                    "Will stop grandma, have difficulties with grandpa",
                    "Will stop poor attacking play",
                    "Will give a hard time to most players",
                    "Will give hell even to most threatening attackers" }       //subtitles
        , new string[] { "Shield now!", "consider Shield", "", "nice", "wow" }  //tasks
      );

      // Hourly rate column
      this.olvc2p.MakeGroupies(
          new byte[] { 4, 7, 10 },
          new string[] { "Bad", "Decent", "Good", "Mega" });
      
      // Install a custom renderer that draws the Tile view in a special way
      this.olvComplex.ItemRenderer = new PlayerSkillsRenderer();
      //
      ObjectListViewExtensions.HotItemOverlay(this.olvComplex, new PlayerSkillsOverlay());
      //
      this.olvComplex.SetObjects(PlayersEnvironment.OptimumPlayers);
    //
      ObjectListViewExtensions.ShowGroups(this.olvComplex, true);
    //
      ObjectListViewExtensions.ChangeOwnerDrawn(this.olvComplex, true);
  
    }

    public event EventHandler <PlayerSelectionEventArgs> SelectionChanged;

    #region Form event handlers

    private void MainForm_Load (object sender, EventArgs e)
    {
      // Make the tooltips look somewhat different
      this.olvComplex.CellToolTip.BackColor = Color.Black;
      this.olvComplex.CellToolTip.ForeColor = Color.AntiqueWhite;
      this.olvComplex.HeaderToolTip.BackColor = Color.AntiqueWhite;
      this.olvComplex.HeaderToolTip.ForeColor = Color.Black;
      this.olvComplex.HeaderToolTip.IsBalloon = true;
      //
      
    }

    void ListViewSelectedIndexChanged (object sender, System.EventArgs e)
    {
      ObjectListView listView = (ObjectListView)sender;
      Player p = (Player)listView.SelectedObject;

      if (SelectionChanged != null)
        SelectionChanged(this, new PlayerSelectionEventArgs()
        {
          SelectedIndices = listView.SelectedIndices.Count
          ,
          FullName = (p == null) ? "" : p.FullName
          ,
          ItemCount = listView.GetItemCount()
        });    
    }
    #endregion

    #region tooltip
    private void listViewComplex_CellToolTip (object sender, ToolTipShowingEventArgs e)
    {
      // Show a long tooltip over cells when the control key is down
      if (Control.ModifierKeys != Keys.Control)
        return;

      OLVColumn col = e.Column ?? e.ListView.GetColumn(0);
      string stringValue = col.GetStringValue(e.Model);

      e.IsBalloon = !ObjectListView.IsVistaOrLater; // balloons don't work reliably on vista
      e.ToolTipControl.SetMaxWidth(400);
      e.Title = ((Player)e.Model).FullName;
      e.StandardIcon = ToolTipControl.StandardIcons.InfoLarge;
      e.BackColor = Color.AliceBlue;
      e.ForeColor = Color.IndianRed;
      e.AutoPopDelay = 15000;
      e.Font = new Font("Tahoma", 12.0f);
      e.Text = String.Format("column '{0}'\r\nValue shown: '{1}'", col.Text, stringValue);
    }

    private void listViewComplex_HeaderToolTipShowing (object sender, ToolTipShowingEventArgs e)
    {
      if (Control.ModifierKeys != Keys.Control)
        return;
      //
      e.StandardIcon = ToolTipControl.StandardIcons.Info;
      e.AutoPopDelay = 10000;
      e.Title = e.Column.Text;
      //
      if (e.Column.Text.StartsWith("Active"))
        e.Text = string.Format("This is an estimation of the actual value of the player's '{0}' skill used by the engine, taking into account experince, height and BMI.", e.Column.AspectName);
      else if (e.Column.AspectName.EndsWith("_Display"))
        e.Text = string.Format("This is the value of the player's '{0}' skill on the player page.", e.Column.Text);
      else
      {
        e.Title = "Player full name";
        e.Text = "Complete name of the player";
      }

    } 
    #endregion

    #region right click
    private void listViewComplex_CellRightClick (object sender, CellRightClickEventArgs e)
    {
      ContextMenuStrip ms = new ContextMenuStrip();
      ms.ItemClicked += new ToolStripItemClickedEventHandler(ms_ItemClicked);

      ObjectListView olv = e.ListView;
      if (olv.ShowGroups)
      {
        foreach (ListViewGroup lvg in olv.Groups)
        {
          ToolStripMenuItem mi = new ToolStripMenuItem(String.Format("Jump to group '{0}'", lvg.Header));
          mi.Tag = lvg;
          ms.Items.Add(mi);
        }
      }
      else
      {
        ToolStripMenuItem mi = new ToolStripMenuItem("Turn on 'Show Groups' to see this context menu in action");
        mi.Enabled = false;
        ms.Items.Add(mi);
      }

      e.MenuStrip = ms;
    }

    void ms_ItemClicked (object sender, ToolStripItemClickedEventArgs e)
    {
      ToolStripMenuItem mi = (ToolStripMenuItem)e.ClickedItem;
      ListViewGroup lvg = (ListViewGroup)mi.Tag;
      ObjectListView olv = (ObjectListView)lvg.ListView;
      olv.EnsureGroupVisible(lvg);
    } 
    #endregion

    #region diagnostics
    private void listViewComplex_CellOver (object sender, CellOverEventArgs e)
    {
      System.Diagnostics.Trace.WriteLine(String.Format("over ({0}, {1}). model {2}", e.RowIndex, e.ColumnIndex, e.Model));
    }

    private void olv_HotItemChanged (object sender, HotItemChangedEventArgs e)
    {
      System.Diagnostics.Trace.WriteLine(String.Format("** HOT ITEM ({0}, {1}, {2})", e.HotRowIndex, e.HotColumnIndex, e.HotCellHitLocation));
      //
      ObjectListView olv = sender as ObjectListView;
      if (sender == null)
      {
        //this.toolStripStatusLabel3.Text = "";
        return;
      }

      switch (e.HotCellHitLocation)
      {
        case HitTestLocation.Nothing:
          //this.toolStripStatusLabel3.Text = "Over nothing";
          break;
        case HitTestLocation.Group:
          //this.toolStripStatusLabel3.Text = String.Format("Over group '{0}', {1}", e.HotGroup.Header, e.HotCellHitLocationEx);
          break;
        case HitTestLocation.GroupExpander:
          //this.toolStripStatusLabel3.Text = String.Format("Over group expander of '{0}'", e.HotGroup.Header);
          break;
        default:
          //this.toolStripStatusLabel3.Text = String.Format("Over {0} of ({1}, {2})", e.HotCellHitLocation, e.HotRowIndex, e.HotColumnIndex);
          break;
      }
    }


    #endregion

    #region group
    private void olvComplex_BeforeCreatingGroups (object sender, CreateGroupsEventArgs e)
    {
      if (e.Parameters.PrimarySort == olvcDriA && Control.ModifierKeys == Keys.Control)
      {
        e.Parameters.GroupComparer = new StrangeGroupComparer(e.Parameters.PrimarySortOrder);
        e.Parameters.ItemComparer = new StrangeItemComparer(this.olvComplex.GetColumn(0), e.Parameters.PrimarySortOrder);
      }
    }

    private void olv_GroupStateChanged (object sender, GroupStateChangedEventArgs e)
    {
      System.Diagnostics.Debug.WriteLine(String.Format("Group '{0}' was {1}{2}{3}{4}{5}{6}",
          e.Group.Header,
          e.Selected ? "Selected" : "",
          e.Focused ? "Focused" : "",
          e.Collapsed ? "Collapsed" : "",
          e.Unselected ? "Unselected" : "",
          e.Unfocused ? "Unfocused" : "",
          e.Uncollapsed ? "Uncollapsed" : ""));

    }

    private void listViewComplex_GroupTaskClicked (object sender, GroupTaskClickedEventArgs e)
    {
      MessageBox.Show(String.Format("group task click: {0}", e.Group), "OLV Demo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    } 
    #endregion

   

    public void ApplyFilter (string filter)
    {
      ObjectListViewExtensions.TimedFilter(this.olvComplex, filter);
    }

        
   
  }

  /// <summary>
  /// This simple class just shows how an overlay can be drawn when the hot item changes.
  /// </summary>
  internal class PlayerSkillsOverlay : AbstractOverlay
  {
    const int CardHeight = 250;
    const int CardWidth = 300;
    const int CardOffset = 80;
    //
    public PlayerSkillsOverlay ( )
    {
      businessCardRenderer.HeaderBackBrush = new SolidBrush(Definitions.White_230_240_250);
      businessCardRenderer.BorderPen = new Pen(Definitions.White_230_240_250, 7);
      this.Transparency = 255;
    }
    #region IOverlay Members

    public override void Draw (ObjectListView olv, Graphics g, Rectangle r)
    {
      if (olv.HotRowIndex < 0)
        return;

      if (olv.View == System.Windows.Forms.View.Tile)
        return;

      OLVListItem item = olv.GetItem(olv.HotRowIndex);
      if (item == null)
        return;
      //
      var cardBounds = new Rectangle(r.Right - CardWidth - CardOffset, r.Bottom - CardHeight - CardOffset, CardWidth, CardHeight);
      businessCardRenderer.DrawBusinessCard(g, cardBounds, item.RowObject, olv, item);
    }

    #endregion

    private PlayerSkillsRenderer businessCardRenderer = new PlayerSkillsRenderer();
  }

  /// <summary>
  /// Hackish renderer that draw a fancy version of a person for a Tile view.
  /// </summary>
  /// <remarks>This is not the way to write a professional level renderer.
  /// It is hideously inefficient (we should at least cache the images),
  /// but it is obvious</remarks>
  internal class PlayerSkillsRenderer : AbstractRenderer
  {
    public override bool RenderItem (DrawListViewItemEventArgs e, Graphics g, Rectangle itemBounds, object rowObject)
    {
      // If we're in any other view than Tile, return false to say that we haven't done
      // the rendereing and the default process should do it's stuff
      ObjectListView olv = e.Item.ListView as ObjectListView;
      if (olv == null || olv.View != View.Tile)
        return false;

      // Use buffered graphics to kill flickers
      BufferedGraphics buffered = BufferedGraphicsManager.Current.Allocate(g, itemBounds);
      g = buffered.Graphics;
      g.Clear(olv.BackColor);
      g.SmoothingMode = ObjectListView.SmoothingMode;
      g.TextRenderingHint = ObjectListView.TextRenderingHint;

      if (e.Item.Selected)
      {
        this.BorderPen = Pens.Blue;
        this.HeaderBackBrush = new SolidBrush(olv.HighlightBackgroundColorOrDefault);
      }
      else
      {
        this.BorderPen = new Pen(Color.FromArgb(0x33, 0x33, 0x33));
        this.HeaderBackBrush = new SolidBrush(Color.FromArgb(0x33, 0x33, 0x33));
      }
      DrawBusinessCard(g, itemBounds, rowObject, olv, (OLVListItem)e.Item);

      // Finally render the buffered graphics
      buffered.Render();
      buffered.Dispose();

      // Return true to say that we've handled the drawing
      return true;
    }

    //    internal Pen BorderPen = new Pen(Color.FromArgb(0x33, 0x33, 0x33));
    internal Pen BorderPen = Pens.Black;
    internal Brush TextBrush = Brushes.Black;
    internal Brush HeaderTextBrush = new SolidBrush(Color.FromArgb(10,20,30));
    internal Brush HeaderBackBrush = Brushes.Goldenrod;
    internal Brush BackBrush = new SolidBrush(Color.FromArgb(211, 211, 211));
    //
    const int spacing = 8;
    const int rounding = 20;

    /// <summary>
    /// draws the player skill decoration
    /// </summary>
    /// <param name="g">graphics object</param>
    /// <param name="itemBounds">decoration bounds</param>
    /// <param name="rowObject">the player object bound to a row</param>
    /// <param name="olv">list view</param>
    /// <param name="item"></param>
    public void DrawBusinessCard (Graphics g, Rectangle itemBounds, object rowObject, ObjectListView olv, OLVListItem item)
    {
      // Allow a border around the card
      itemBounds.Inflate(-2, -2);
      // Draw card background      
      var path = this.GetRoundedRect(itemBounds, rounding);
      g.FillPath(this.BackBrush, path);
      g.DrawPath(this.BorderPen, path);
      g.Clip = new Region(itemBounds);
      // Now draw the text portion
      RectangleF textBoxRect = itemBounds;
      itemBounds.Inflate(-spacing, -spacing);
      //
      StringFormat fmt = new StringFormat(StringFormatFlags.NoWrap);
      fmt.Trimming = StringTrimming.EllipsisCharacter;
      fmt.Alignment = StringAlignment.Center;
      fmt.LineAlignment = StringAlignment.Near;
      //
      // Draw the title (player name)
      //
      using (Font font = new Font("Tahoma", 11, FontStyle.Bold))
      { // Measure the height of the title
        SizeF size = g.MeasureString(item.Text, font, (int)textBoxRect.Width, fmt);
        RectangleF r3 = textBoxRect;
        r3.Height = size.Height;
        path = this.GetRoundedRect(r3, 15);
        g.FillPath(this.HeaderBackBrush, path);
        g.DrawString(item.Text, font, this.HeaderTextBrush, textBoxRect, fmt);
        textBoxRect.Y += size.Height + spacing;
      }
      //
      // Draw the other bits of information
      //
      using (Font font = new Font("Tahoma", 8))
      { // measure longest card string
        SizeF size = g.MeasureString("Active Three Point", font, itemBounds.Width, fmt);
        textBoxRect.Height = size.Height;
        fmt.Alignment = StringAlignment.Near;
        //
        textBoxRect.Inflate(-5f, 0f);
        using (Font fontb = new Font(font, FontStyle.Bold | FontStyle.Underline)) 
        {
          DrawLine(g, "SKILL", "SITE", "ACTIVE", fmt, fontb, ref size, ref textBoxRect);
        }

#if TEST
        for (int i = 0; i < olv.Columns.Count; i++)
        {
          OLVColumn column = olv.GetColumn(i);          
          if (column.IsTileViewColumn)
          {
            g.DrawString(column.Text, font, this.TextBrush, textBoxRect, fmt);
            RectangleF rVal = new RectangleF(textBoxRect.X + size.Width + spacing, textBoxRect.Y, textBoxRect.Width, textBoxRect.Height);
            g.DrawString(column.GetStringValue(rowObject), font, Brushes.DarkRed, rVal, fmt);
            textBoxRect.Y += size.Height;
          }
        }
#endif
        Player p = (Player)rowObject;
       //
        
        //
        DrawLine(g, "Defence", p.Defence_Display.ToString(), p.Defence.ToString("F02"), fmt, font, ref size, ref textBoxRect);
        //
        DrawLine(g, "Frethrows", p.Freethrows_Display.ToString(), p.Freethrows.ToString("F02"), fmt, font, ref size, ref textBoxRect);
        //
        DrawLine(g, "2P", p.TwoPoint_Display.ToString(), p.TwoPoint.ToString("F02"), fmt, font, ref size, ref textBoxRect);
        //
        DrawLine(g, "3P", p.ThreePoint_Display.ToString(), p.ThreePoint.ToString("F02"), fmt, font, ref size, ref textBoxRect);
        //
        DrawLine(g, "Dribbling", p.Dribling_Display.ToString(), p.Dribling.ToString("F02"), fmt, font, ref size, ref textBoxRect);
        //
        DrawLine(g, "Passing", p.Passing_Display.ToString(), p.Passing.ToString("F02"), fmt, font, ref size, ref textBoxRect);
        //
        DrawLine(g, "Speed", p.Speed_Display.ToString(), p.Speed.ToString("F02"), fmt, font, ref size, ref textBoxRect);
        //
        DrawLine(g, "Footwork", p.Footwork_Display.ToString(), p.Footwork.ToString("F02"), fmt, font, ref size, ref textBoxRect);
        //
        DrawLine(g, "Rebounds", p.Rebounds_Display.ToString(), p.Rebounds.ToString("F02"), fmt, font, ref size, ref textBoxRect);
        //

      }
    }

    private void DrawLine (Graphics g, string description, string value1, string value2, StringFormat fmt, Font font, ref SizeF size, ref RectangleF textBoxRect)
    {
      g.DrawString(description, font, this.TextBrush, textBoxRect, fmt);
      RectangleF rVal = new RectangleF(textBoxRect.X + size.Width + spacing, textBoxRect.Y, textBoxRect.Width, textBoxRect.Height);
      g.DrawString(value1, font, Brushes.DarkRed, rVal, fmt);
      rVal.X += (size.Width + spacing);
      g.DrawString(value2, font, Brushes.DarkGreen, rVal, fmt);
      textBoxRect.Y += size.Height;     
    }

    private System.Drawing.Drawing2D.GraphicsPath GetRoundedRect (RectangleF rect, float diameter)
    {
      var path = new System.Drawing.Drawing2D.GraphicsPath();

      RectangleF arc = new RectangleF(rect.X, rect.Y, diameter, diameter);
      path.AddArc(arc, 180, 90);
      arc.X = rect.Right - diameter;
      path.AddArc(arc, 270, 90);
      arc.Y = rect.Bottom - diameter;
      path.AddArc(arc, 0, 90);
      arc.X = rect.Left;
      path.AddArc(arc, 90, 90);
      path.CloseFigure();

      return path;
    }
  }
}
