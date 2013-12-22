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
  
  internal static class Definitions
  {
    public static Color White_230_240_250 = Color.FromArgb(230, 240, 250);
    public static Color DarkGray60 = Color.FromArgb(60, 60, 60);
    public static Color DarkGray39 = Color.FromArgb(39, 39, 39);
    public static Color White_230_220_210 = Color.FromArgb(230, 220, 210);
  }
  
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
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization"
      , "CA1303:DoNotPassLiteralsAsLocalizedParameters"
      , MessageId = "System.Windows.Forms.Control.set_Text(System.String)")]
    private void InitializeComponent ( )
    {
      this.components = new System.ComponentModel.Container();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.imageList2 = new System.Windows.Forms.ImageList(this.components);
      this.gbxFilter = new System.Windows.Forms.GroupBox();
      this.txtFilterComplex = new System.Windows.Forms.TextBox();
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
      this.groupImageList = new System.Windows.Forms.ImageList(this.components);
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
      this.btnAdd = new System.Windows.Forms.Button();
      this.btnRemove = new System.Windows.Forms.Button();
      this.cmbEditable = new System.Windows.Forms.ComboBox();
      this.btnCopySel = new System.Windows.Forms.Button();
      this.btnRebuild = new System.Windows.Forms.Button();
      this.chkGroups = new System.Windows.Forms.CheckBox();
      this.lblEditable = new System.Windows.Forms.Label();
      this.chkOwnerDraw = new System.Windows.Forms.CheckBox();
      this.gbxFilter.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvComplex)).BeginInit();
      this.statusStrip1.SuspendLayout();
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
      // gbxFilter
      // 
      this.gbxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.gbxFilter.Controls.Add(this.txtFilterComplex);
      this.gbxFilter.Location = new System.Drawing.Point(757, 12);
      this.gbxFilter.Name = "gbxFilter";
      this.gbxFilter.Size = new System.Drawing.Size(138, 44);
      this.gbxFilter.TabIndex = 18;
      this.gbxFilter.TabStop = false;
      this.gbxFilter.Text = "Filter";
      // 
      // txtFilterComplex
      // 
      this.txtFilterComplex.Location = new System.Drawing.Point(7, 20);
      this.txtFilterComplex.Name = "txtFilterComplex";
      this.txtFilterComplex.Size = new System.Drawing.Size(125, 20);
      this.txtFilterComplex.TabIndex = 0;
      this.txtFilterComplex.TextChanged += new System.EventHandler(this.textBoxFilterComplex_TextChanged);
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
      this.olvComplex.AllowColumnReorder = true;
      this.olvComplex.AllowDrop = true;
      this.olvComplex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.olvComplex.AlternateRowBackColor = Definitions.DarkGray60;
      this.olvComplex.BackColor = Definitions.DarkGray39;
      this.olvComplex.ForeColor = Definitions.White_230_220_210;
      this.olvComplex.CheckedAspectName = "";
      this.olvComplex.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcFN,
            this.olvcDef, this.olvcDefA,
            this.olvcFT, this.olvcFTA,
            this.olvc2p, this.olvc2pA,
            this.olvc3p, this.olvc3pA,
            this.olvcDri, this.olvcDriA,
            this.olvcPas, this.olvcPasA,
            this.olvcSpe, this.olvcSpeA,
            this.olvcFtw, this.olvcFtwA,
            this.olvcReb, this.olvcRebA,
      });
      this.olvComplex.Cursor = System.Windows.Forms.Cursors.Default;
      this.olvComplex.EmptyListMsg = "This list is empty. Press \"Add\" to create some items";
      this.olvComplex.FullRowSelect = true;
      this.olvComplex.GroupImageList = this.groupImageList;
      this.olvComplex.GroupWithItemCountFormat = "{0} ({1} people)";
      this.olvComplex.GroupWithItemCountSingularFormat = "{0} ({1} Player)";
      this.olvComplex.HeaderUsesThemes = false;
      this.olvComplex.HeaderWordWrap = true;
      this.olvComplex.HideSelection = false;
      this.olvComplex.LargeImageList = this.imageList2;
      this.olvComplex.Location = new System.Drawing.Point(12, 12);
      this.olvComplex.Name = "olvComplex";
      this.olvComplex.OverlayImage.Alignment = System.Drawing.ContentAlignment.BottomLeft;
      this.olvComplex.OverlayText.Alignment = System.Drawing.ContentAlignment.TopRight;
      this.olvComplex.OverlayText.BorderColor = System.Drawing.Color.DarkRed;
      this.olvComplex.OverlayText.BorderWidth = 4F;
      this.olvComplex.OverlayText.InsetX = 10;
      this.olvComplex.OverlayText.InsetY = 35;
      this.olvComplex.OverlayText.Rotation = 20;
      this.olvComplex.OverlayText.Text = "";
      this.olvComplex.OverlayText.TextColor = Color.FromArgb(192,192,192);
      this.olvComplex.OwnerDraw = true;
      this.olvComplex.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
      this.olvComplex.ShowCommandMenuOnRightClick = true;
      this.olvComplex.ShowGroups = false;
      this.olvComplex.ShowImagesOnSubItems = true;
      this.olvComplex.ShowItemCountOnGroups = true;
      this.olvComplex.ShowItemToolTips = true;
      this.olvComplex.Size = new System.Drawing.Size(739, 337);
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
      this.olvComplex.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.listViewComplex_CellEditFinishing);
      this.olvComplex.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.listViewComplex_CellEditStarting);
      this.olvComplex.CellEditValidating += new BrightIdeasSoftware.CellEditEventHandler(this.listViewComplex_CellEditValidating);
      this.olvComplex.CellOver += new System.EventHandler<BrightIdeasSoftware.CellOverEventArgs>(this.listViewComplex_CellOver);
      this.olvComplex.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.listViewComplex_CellRightClick);
      this.olvComplex.CellToolTipShowing += new System.EventHandler<BrightIdeasSoftware.ToolTipShowingEventArgs>(this.listViewComplex_CellToolTip);
      this.olvComplex.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.listViewComplex_FormatCell);
      this.olvComplex.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.listViewComplex_FormatRow);
      this.olvComplex.GroupStateChanged += new System.EventHandler<BrightIdeasSoftware.GroupStateChangedEventArgs>(this.olv_GroupStateChanged);
      this.olvComplex.HeaderToolTipShowing += new System.EventHandler<BrightIdeasSoftware.ToolTipShowingEventArgs>(this.listViewComplex_HeaderToolTipShowing);
      this.olvComplex.HotItemChanged += new System.EventHandler<BrightIdeasSoftware.HotItemChangedEventArgs>(this.olv_HotItemChanged);
      this.olvComplex.GroupTaskClicked += new System.EventHandler<BrightIdeasSoftware.GroupTaskClickedEventArgs>(this.listViewComplex_GroupTaskClicked);
      this.olvComplex.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.olvComplex_ItemChecked);
      this.olvComplex.SelectedIndexChanged += new System.EventHandler(this.ListViewSelectedIndexChanged);
      this.olvComplex.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewComplex_MouseClick);
      // 
      // olvcFN
      // 
      this.olvcFN.AspectName = "FullName";
      this.olvcFN.CellPadding = null;
      this.olvcFN.HeaderImageKey = "(none)";
      this.olvcFN.ImageAspectName = "";
      this.olvcFN.Text = "Player";
      this.olvcFN.ToolTipText = "Tooltip for Player column. This was configurated in the IDE. (Hold down Control to see a different tooltip)";
      this.olvcFN.UseInitialLetterForGroup = true;
      this.olvcFN.Width = 150;
      // 
      // olvcDef
      // 
      this.olvcDef.CellPadding = null;
      this.olvcDef.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.olvcDef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.initDisplayColumn(this.olvcDef, "Defence");
      // 
      // olvcDefA
      // 
      this.olvcDefA.CellPadding = null;
      this.olvcDefA.GroupWithItemCountFormat = "{0} ({1} candidates)";
      this.olvcDefA.GroupWithItemCountSingularFormat = "{0} (only {1} candidate)";
      this.olvcDefA.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvcDefA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvcDefA.ToolTipText = "Group on this column to see full group formatting possibilities";
      this.initActiveColumn(this.olvcDefA, "Defence");
      // 
      // olvcFT
      // 
      this.olvcFT.CellPadding = null;
      this.olvcFT.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.initDisplayColumn(this.olvcFT, "Freethrows");
      // 
      // olvcFTA
      // 
      this.olvcFTA.CellPadding = null;
      this.olvcFTA.GroupWithItemCountFormat = "{0} has {1} birthdays";
      this.olvcFTA.GroupWithItemCountSingularFormat = "{0} has only {1} birthday";
      this.initActiveColumn(this.olvcFTA, "Freethrows");
      // 
      // olvc2p
      // 
      this.olvc2p.CellPadding = null;
      this.initDisplayColumn(this.olvc2p, "TwoPoint");
      // 
      // olvc2pA
      // 
      this.olvc2pA.CellPadding = null;
      this.initActiveColumn(this.olvc2pA, "TwoPoint");
      // 
      // olvc3p
      // 
      this.olvc3p.CellPadding = null;
      this.initDisplayColumn(this.olvc3p, "ThreePoint");
      // 
      // olvc3pA
      // 
      this.olvc3pA.CellPadding = null;
      this.olvc3pA.ToolTipText = "estimation of 3p skill used by engine";
      this.initActiveColumn(this.olvc3pA, "ThreePoint");
      // 
      // olvcDri
      // 
      this.olvcDri.CellPadding = null;
      this.olvcDri.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.olvcDri.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.initDisplayColumn(this.olvcDri, "Dribling");
      // 
      // olvcDriA
      // 
      this.olvcDriA.CellPadding = null;
      this.olvcDriA.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.olvcDriA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.initActiveColumn(this.olvcDriA, "Dribling");
      // 
      // olvcPas
      // 
      this.initDisplayColumn(this.olvcPas, "Passing");
      // 
      // olvcPasA
      //       
      this.initActiveColumn(this.olvcPasA, "Passing");
      // 
      // olvcSpe
      //       
      this.initDisplayColumn(this.olvcSpe, "Speed");
      // 
      // olvcSpeA
      // 
      this.initActiveColumn(this.olvcSpeA, "Speed");
      // 
      // olvcFtw
      // 
      this.initDisplayColumn(this.olvcFtw, "Footwork");
      // 
      // olvcFtwA
      // 
      this.initActiveColumn(this.olvcFtwA, "Footwork");
      // 
      // olvcReb
      // 
      this.initDisplayColumn(this.olvcReb, "Rebounds");
      // 
      // olvcRebA
      // 
      this.initActiveColumn(this.olvcRebA, "Rebounds");
      // 
      // groupImageList
      // 
      this.groupImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
      this.groupImageList.ImageSize = new System.Drawing.Size(16, 16);
      this.groupImageList.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel3});
      this.statusStrip1.Location = new System.Drawing.Point(0, 352);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(907, 22);
      this.statusStrip1.TabIndex = 3;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
      // 
      // toolStripStatusLabel3
      // 
      this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
      this.toolStripStatusLabel3.Size = new System.Drawing.Size(892, 17);
      this.toolStripStatusLabel3.Spring = true;
      this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
      this.toolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // btnAdd
      // 
      this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAdd.Location = new System.Drawing.Point(764, 229);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(46, 23);
      this.btnAdd.TabIndex = 27;
      this.btnAdd.Text = "Add";
      this.btnAdd.UseVisualStyleBackColor = true;
      // 
      // btnRemove
      // 
      this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnRemove.Location = new System.Drawing.Point(764, 258);
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.Size = new System.Drawing.Size(57, 23);
      this.btnRemove.TabIndex = 28;
      this.btnRemove.Text = "Remove";
      this.btnRemove.UseVisualStyleBackColor = true;
      // 
      // cmbEditable
      // 
      this.cmbEditable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cmbEditable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbEditable.FormattingEnabled = true;
      this.cmbEditable.Items.AddRange(new object[] {
            "No",
            "Single Click",
            "Double Click",
            "F2 Only"});
      this.cmbEditable.Location = new System.Drawing.Point(764, 160);
      this.cmbEditable.Name = "cmbEditable";
      this.cmbEditable.Size = new System.Drawing.Size(131, 21);
      this.cmbEditable.TabIndex = 24;
      this.cmbEditable.SelectedIndexChanged += new System.EventHandler(this.cmbEditable_SelectedIndexChanged);
      // 
      // btnCopySel
      // 
      this.btnCopySel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCopySel.Location = new System.Drawing.Point(764, 287);
      this.btnCopySel.Name = "btnCopySel";
      this.btnCopySel.Size = new System.Drawing.Size(88, 23);
      this.btnCopySel.TabIndex = 29;
      this.btnCopySel.Text = "Copy &Selection";
      this.btnCopySel.UseVisualStyleBackColor = true;
      // 
      // btnRebuild
      // 
      this.btnRebuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnRebuild.Location = new System.Drawing.Point(764, 316);
      this.btnRebuild.Name = "btnRebuild";
      this.btnRebuild.Size = new System.Drawing.Size(56, 23);
      this.btnRebuild.TabIndex = 30;
      this.btnRebuild.Text = "&Rebuild";
      this.btnRebuild.UseVisualStyleBackColor = true;
      // 
      // chkGroups
      // 
      this.chkGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.chkGroups.Location = new System.Drawing.Point(764, 62);
      this.chkGroups.Name = "chkGroups";
      this.chkGroups.Size = new System.Drawing.Size(131, 21);
      this.chkGroups.TabIndex = 21;
      this.chkGroups.Text = "&Groups";
      this.chkGroups.UseVisualStyleBackColor = true;
      this.chkGroups.CheckedChanged += new System.EventHandler(this.chkGroups_CheckedChanged);
      // 
      // lblEditable
      // 
      this.lblEditable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblEditable.AutoSize = true;
      this.lblEditable.Location = new System.Drawing.Point(761, 144);
      this.lblEditable.Name = "lblEditable";
      this.lblEditable.Size = new System.Drawing.Size(48, 13);
      this.lblEditable.TabIndex = 23;
      this.lblEditable.Text = "Editable:";
      // 
      // chkOwnerDraw
      // 
      this.chkOwnerDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.chkOwnerDraw.AutoSize = true;
      this.chkOwnerDraw.Checked = true;
      this.chkOwnerDraw.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkOwnerDraw.Location = new System.Drawing.Point(764, 90);
      this.chkOwnerDraw.Name = "chkOwnerDraw";
      this.chkOwnerDraw.Size = new System.Drawing.Size(89, 17);
      this.chkOwnerDraw.TabIndex = 31;
      this.chkOwnerDraw.Text = "Owner drawn";
      this.chkOwnerDraw.UseVisualStyleBackColor = true;
      this.chkOwnerDraw.CheckedChanged += new System.EventHandler(this.chkOwnerDraw_CheckedChanged);
      // 
      // PlayerSkillsUserControl
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.chkOwnerDraw);
      this.Controls.Add(this.gbxFilter);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.btnAdd);
      this.Controls.Add(this.btnRemove);
      this.Controls.Add(this.cmbEditable);
      this.Controls.Add(this.lblEditable);
      this.Controls.Add(this.btnCopySel);
      this.Controls.Add(this.btnRebuild);
      this.Controls.Add(this.chkGroups);
      this.Controls.Add(this.olvComplex);
      this.Name = "PlayerSkillsUserControl";
      this.Size = new System.Drawing.Size(907, 374);
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.gbxFilter.ResumeLayout(false);
      this.gbxFilter.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvComplex)).EndInit();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    private void initDisplayColumn (OLVColumn col, string text)
    {
      col.AspectName = text+"_Display";
      col.Text = text;
      col.IsHeaderVertical = true;
      col.IsTileViewColumn = true;
      col.IsEditable = false;
      col.Width = 41;
    }

    private void initActiveColumn (OLVColumn col, string text)
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
    private BrightIdeasSoftware.OLVColumn olvcFT;
    private BrightIdeasSoftware.OLVColumn olvcDef;
    private BrightIdeasSoftware.OLVColumn olvc3p;
    private BrightIdeasSoftware.OLVColumn olvcFN;
    private BrightIdeasSoftware.OLVColumn olvcDefA;
    private BrightIdeasSoftware.OLVColumn olvcFTA;
    private BrightIdeasSoftware.OLVColumn olvc2p;
    private ObjectListView olvComplex;
    private BrightIdeasSoftware.OLVColumn olvc2pA;
    private System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private ImageList imageList2;
    private OLVColumn olvc3pA;
    private GroupBox gbxFilter;
    private TextBox txtFilterComplex;
    private ToolStripStatusLabel toolStripStatusLabel3;
    private Button btnAdd;
    private Button btnRemove;
    private ComboBox cmbEditable;
    private Label lblEditable;
    private Button btnCopySel;
    private Button btnRebuild;
    private CheckBox chkOwnerDraw;
    private CheckBox chkGroups;
    #endregion

   
    /// <summary>
    ///
    /// </summary>
    public PlayerSkillsUserControl ()
    {
      //
      // The InitializeComponent() call is required for Windows Forms designer support.
      //
      InitializeComponent();      
      
    }

    List<Player> masterList;
    public List<Player> Players { get { return masterList; }
      set {
        if (value != null)
        {
          masterList = value;

          List<Player> list = new List<Player>();
          foreach (Player p in masterList)
            list.Add(p);

          // Change this value to see the performance on bigger lists.
          // Each list builds about 1000 rows per second.
          //while (list.Count < 5000) {
          //    foreach (Player p in masterList)
          //        list.Add(new Player(p));
          //}

          InitializeExamples(list);
        }
        
      }
    }

    void InitializeExamples ( List<Player> list)
    {
      // Use different font under Vista
      if (ObjectListView.IsVistaOrLater)
        this.Font = new Font("Segoe UI", 9);     
      
      InitializeComplexExample(list);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="list"></param>
    void InitializeComplexExample (List<Player> list)
    {
      this.olvComplex.AddDecoration(new EditingCellBorderDecoration(true));

      // The following line makes getting aspect about 10x faster. Since getting the aspect is
      // the slowest part of building the ListView, it is worthwhile BUT NOT NECESSARY to do.
      TypedObjectListView<Player> tlist = new TypedObjectListView<Player>(this.olvComplex);
      tlist.GenerateAspectGetters();
      /* The line above the equivilent to typing the following:
      tlist.GetColumn(0).AspectGetter = delegate(Player x) { return x.Name; };
      tlist.GetColumn(1).AspectGetter = delegate(Player x) { return x.Occupation; };
      tlist.GetColumn(2).AspectGetter = delegate(Player x) { return x.CulinaryRating; };
      tlist.GetColumn(3).AspectGetter = delegate(Player x) { return x.YearOfBirth; };
      tlist.GetColumn(4).AspectGetter = delegate(Player x) { return x.BirthDate; };
      tlist.GetColumn(5).AspectGetter = delegate(Player x) { return x.GetRate(); };
      tlist.GetColumn(6).AspectGetter = delegate(Player x) { return x.Comments; };
      */

      this.olvcFN.AspectToStringConverter = delegate(object cellValue)
      {
        return ((String)cellValue).ToUpperInvariant();
      };
      // Cooking skill columns
      this.olvcDefA.MakeGroupies(
        //values
          new object[] { 6D, 11D, 16D, 21D},
          //descriptions
          new string[] { "Really poor", "Bad", "Decent", "Good", "Mega" },
          //images
          new string[] { "not", "hamburger", "toast", "beef", "chef" },
          //subtitles
          new string[] {
                    "This guy won't stop your grandma",
                    "Will stop grandma, have difficulties with grandpa",
                    "Will stop poor attacking play",
                    "Will give a hard time to most players",
                    "Will give hell even to most threatening attackers" },
          //tasks
          new string[] { "Shield now!", "consider Shield", "", "nice", "wow" }
      );

      // Hourly rate column
      this.olvc2p.MakeGroupies(
          new byte[] { 4, 7, 10 },
          new string[] { "Bad", "Decent", "Good", "Mega" });
      
      // Salary indicator column
      this.olvc2pA.AspectGetter = delegate(object row)
      {
        Player p = (Player)row;
        return (p.TwoPoint < 4) ? "Bad" : ((p.TwoPoint > 7) ? "Good" : "Decent");
      };
      //this.olvc2pA.Renderer = new MappedImageRenderer(new Object[] { "Little"
      //  ,  AndreiPopescu.CharazayPlus.Properties.Resources.star12 , "Medium"
      //  , AndreiPopescu.CharazayPlus.Properties.Resources.star13, "Lots"
      //  , AndreiPopescu.CharazayPlus.Properties.Resources.star16 });        

      // Install a custom renderer that draws the Tile view in a special way
      this.olvComplex.ItemRenderer = new PlayerSkillsRenderer();

      //
      cmbHotItem_SelectedIndexChanged();
      //
      this.cmbEditable.SelectedIndex = 0;

      this.olvComplex.SetObjects(list);
    }


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

    #endregion

    #region Utilities

    void ShowGroupsChecked (ObjectListView olv, CheckBox cb)
    {
      if (cb.Checked && olv.View == View.List)
      {
        cb.Checked = false;
        MessageBox.Show("ListView's cannot show groups when in List view.", "Object List View Demo", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      else
      {
        olv.ShowGroups = cb.Checked;
        olv.BuildList();
      }
    }

    void ShowLabelsOnGroupsChecked (ObjectListView olv, CheckBox cb)
    {
      olv.ShowItemCountOnGroups = cb.Checked;
      if (olv.ShowGroups)
        olv.BuildGroups();
    }

    void HandleSelectionChanged (ObjectListView listView)
    {
      string msg;
      Player p = (Player)listView.SelectedObject;
      if (p == null)
        msg = listView.SelectedIndices.Count.ToString();
      else
        msg = String.Format("'{0}'", p.Name);
      this.toolStripStatusLabel1.Text = String.Format("Selected {0} of {1} items", msg, listView.GetItemCount());
    }

    void ListViewSelectedIndexChanged (object sender, System.EventArgs e)
    {
      HandleSelectionChanged((ObjectListView)sender);
    }
    
    void ChangeOwnerDrawn (ObjectListView listview, bool value)
    {
      listview.OwnerDraw = value;
      listview.BuildList();
    }

    #endregion

    #region Complex Tab Event Handlers

    void chkGroups_CheckedChanged (object sender, System.EventArgs e)
    {
      ShowGroupsChecked(this.olvComplex, (CheckBox)sender);
    }

    #endregion


    #region Cell editing example

    private void listViewComplex_CellEditStarting (object sender, CellEditEventArgs e)
    {
      // We only want to mess with the Cooking Skill column
      if (e.Column.Text != "Cooking skill")
        return;

      ComboBox cb = new ComboBox();
      cb.Bounds = e.CellBounds;
      cb.Font = ((ObjectListView)sender).Font;
      cb.DropDownStyle = ComboBoxStyle.DropDownList;
      cb.Items.AddRange(new String[] { "Pay to eat out", "Suggest take-away", "Passable", "Seek dinner invitation", "Hire as chef" });
      cb.SelectedIndex = Math.Max(0, Math.Min(cb.Items.Count - 1, ((int)e.Value) / 10));
      cb.SelectedIndexChanged += new EventHandler(cb_SelectedIndexChanged);
      cb.Tag = e.RowObject; // remember which Player we are editing
      e.Control = cb;
    }

    private void cb_SelectedIndexChanged (object sender, EventArgs e)
    {
      ComboBox cb = (ComboBox)sender;
      //((Player)cb.Tag).CulinaryRating = cb.SelectedIndex * 10;
    }

    private void listViewComplex_CellEditValidating (object sender, CellEditEventArgs e)
    {
      // Disallow professions from starting with "a" or "z" -- just to be arbitrary
      if (e.Column.Text == "Occupation")
      {
        string newValue = ((TextBox)e.Control).Text;
        if (newValue.ToLowerInvariant().StartsWith("a") || newValue.ToLowerInvariant().StartsWith("z"))
        {
          e.Cancel = true;
          MessageBox.Show(this, "Occupations cannot begin with 'a' or 'z' (just to show cell edit validation at work).", "ObjectListViewDemo",
              MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }

      // Disallow birthdays from being on the 29th -- just to be arbitrary
      if (e.Column.Text == "Birthday")
      {
        DateTime newValue = ((DateTimePicker)e.Control).Value;
        if (newValue != null && newValue.Day == 29)
        {
          e.Cancel = true;
          MessageBox.Show(this, "Sorry. Birthdays cannot be on 29th of any month (just to show cell edit validation at work).", "ObjectListViewDemo",
              MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }

    }

    private void listViewComplex_CellEditFinishing (object sender, CellEditEventArgs e)
    {
      // We only want to mess with the Cooking Skill column
      if (e.Column.Text != "Cooking skill")
        return;

      // Stop listening for change events
      ((ComboBox)e.Control).SelectedIndexChanged -= new EventHandler(cb_SelectedIndexChanged);

      // Any updating will have been down in the SelectedIndexChanged event handler
      // Here we simply make the list redraw the involved ListViewItem
      ((ObjectListView)sender).RefreshItem(e.ListViewItem);

      // We have updated the model object, so we cancel the auto update
      e.Cancel = true;
    }

    private void cmbEditable_SelectedIndexChanged (object sender, EventArgs e)
    {
      this.ChangeEditable(this.olvComplex, (ComboBox)sender);
    }

    private void ChangeEditable (ObjectListView objectListView, ComboBox comboBox)
    {
      if (comboBox.Text == "No")
        objectListView.CellEditActivation = ObjectListView.CellEditActivateMode.None;
      else if (comboBox.Text == "Single Click")
        objectListView.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClick;
      else if (comboBox.Text == "Double Click")
        objectListView.CellEditActivation = ObjectListView.CellEditActivateMode.DoubleClick;
      else
        objectListView.CellEditActivation = ObjectListView.CellEditActivateMode.F2Only;
    }

    #endregion


    private void listViewComplex_MouseClick (object sender, MouseEventArgs e)
    {
      //if (e.Button != MouseButtons.Right)
      //    return;

      //ContextMenuStrip ms = new ContextMenuStrip();
      //ms.ItemClicked += new ToolStripItemClickedEventHandler(ms_ItemClicked);

      //ObjectListView olv = (ObjectListView)sender;
      //if (olv.ShowGroups) {
      //    foreach (ListViewGroup lvg in olv.Groups) {
      //        ToolStripMenuItem mi = new ToolStripMenuItem(String.Format("Jump to group '{0}'", lvg.Header));
      //        mi.Tag = lvg;
      //        ms.Items.Add(mi);
      //    }
      //} else {
      //    ToolStripMenuItem mi = new ToolStripMenuItem("Turn on 'Show Groups' to see this context menu in action");
      //    mi.Enabled = false;
      //    ms.Items.Add(mi);
      //}

      //ms.Show((Control)sender, e.X, e.Y);
    }

    /*
    private static void BlendBitmaps(Graphics g, Bitmap b1, Bitmap b2, float transition)
    {
        float[][] colorMatrixElements = {
new float[] {1,  0,  0,  0, 0},        // red scaling factor of 2
new float[] {0,  1,  0,  0, 0},        // green scaling factor of 1
new float[] {0,  0,  1,  0, 0},        // blue scaling factor of 1
new float[] {0,  0,  0,  transition, 0},        // alpha scaling factor of 1
new float[] {0,  0,  0,  0, 1}};    // three translations of 0.2

        ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
        ImageAttributes imageAttributes = new ImageAttributes();
        imageAttributes.SetColorMatrix(colorMatrix);

        g.DrawImage(
           b1,
           new Rectangle(0, 0, b1.Size.Width, b1.Size.Height),  // destination rectangle
           0, 0,        // upper-left corner of source rectangle
           b1.Size.Width,       // width of source rectangle
           b1.Size.Height,      // height of source rectangle
           GraphicsUnit.Pixel,
           imageAttributes);

        colorMatrix.Matrix33 = 1.0f - transition;
        imageAttributes.SetColorMatrix(colorMatrix);

        g.DrawImage(
           b2,
           new Rectangle(0, 0, b2.Size.Width, b2.Size.Height),  // destination rectangle
           0, 0,        // upper-left corner of source rectangle
           b2.Size.Width,       // width of source rectangle
           b2.Size.Height,      // height of source rectangle
           GraphicsUnit.Pixel,
           imageAttributes);
    }
    */

    private void listViewComplex_CellToolTip (object sender, ToolTipShowingEventArgs e)
    {
      // Show a long tooltip over cells when the control key is down
      if (Control.ModifierKeys != Keys.Control)
        return;

      OLVColumn col = e.Column ?? e.ListView.GetColumn(0);
      string stringValue = col.GetStringValue(e.Model);
      if (stringValue.StartsWith("m", StringComparison.InvariantCultureIgnoreCase))
      {
        e.IsBalloon = !ObjectListView.IsVistaOrLater; // balloons don't work reliably on vista
        e.ToolTipControl.SetMaxWidth(400);
        e.Title = "WARNING";
        e.StandardIcon = ToolTipControl.StandardIcons.InfoLarge;
        e.BackColor = Color.AliceBlue;
        e.ForeColor = Color.IndianRed;
        e.AutoPopDelay = 15000;
        e.Font = new Font("Tahoma", 12.0f);
        e.Text = "THIS VALUE BEGINS WITH A DANGEROUS LETTER!\r\n\r\n" +
            "On no account should members of the public attempt to pronounce this word without " +
            "the assistance of trained vocalization specialists.";
      }
      else
      {
        e.Text = String.Format("Tool tip for '{0}', column '{1}'\r\nValue shown: '{2}'",
            ((Player)e.Model).Name, col.Text, stringValue);
      }
    }

    private void listViewComplex_HeaderToolTipShowing (object sender, ToolTipShowingEventArgs e)
    {
      if (Control.ModifierKeys != Keys.Control)
        return;

      e.Title = "Information";
      e.StandardIcon = ToolTipControl.StandardIcons.Info;
      e.AutoPopDelay = 10000;
      e.Text = String.Format("More details about the '{0}' column\r\n\r\nThis only shows when the control key is down.",
          e.Column.Text);
    }


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

    private void listViewComplex_CellOver (object sender, CellOverEventArgs e)
    {
      //System.Diagnostics.Trace.WriteLine(String.Format("over ({0}, {1}). model {2}",
      //    e.RowIndex, e.ColumnIndex, e.Model));
    }

    private void listViewComplex_HotItemChanged (object sender, HotItemChangedEventArgs e)
    {
      //System.Diagnostics.Trace.WriteLine(String.Format("** HOT ITEM ({0}, {1}, {2})",
      //    e.HotRowIndex, e.HotColumnIndex, e.HotCellHitLocation));
    }

    private void listViewComplex_FormatRow (object sender, FormatRowEventArgs e)
    {
      e.UseCellFormatEvents = true;
      if (olvComplex.View != View.Details)
      {
        if (e.Item.Text.ToLowerInvariant().StartsWith("nicola"))
        {
          e.Item.Decoration = new ImageDecoration(AndreiPopescu.CharazayPlus.Properties.Resources.star12, 64);
        }
        else
          e.Item.Decoration = null;
      }
    }

    private void listViewComplex_FormatCell (object sender, FormatCellEventArgs e)
    {
      Player p = (Player)e.Model;

      // Put a love heart next to Nicola's name :)
      if (e.ColumnIndex == 0)
      {
        if (e.SubItem.Text.ToLowerInvariant().StartsWith("nicola"))
        {
          e.SubItem.Decoration = new ImageDecoration(AndreiPopescu.CharazayPlus.Properties.Resources.star12, 64);
        }
        else
          e.SubItem.Decoration = null;
      }

      // If the occupation is missing a value, put a composite decoration over it
      // to draw attention to.
      if (e.ColumnIndex == 1 && e.SubItem.Text == "")
      {
        TextDecoration decoration = new TextDecoration("Missing!", 255);
        decoration.Alignment = ContentAlignment.MiddleCenter;
        decoration.Font = new Font(this.Font.Name, this.Font.SizeInPoints + 2);
        decoration.TextColor = Color.Firebrick;
        decoration.Rotation = -20;
        e.SubItem.Decoration = decoration;
        CellBorderDecoration cbd = new CellBorderDecoration();
        cbd.BorderPen = new Pen(Color.FromArgb(128, Color.Firebrick));
        cbd.FillBrush = null;
        cbd.CornerRounding = 4.0f;
        e.SubItem.Decorations.Add(cbd);
      }
      //if (e.ColumnIndex == 7) {
      //    if (p.CanTellJokes.HasValue && p.CanTellJokes.Value)
      //        e.SubItem.Decoration = new CellBorderDecoration();
      //    else
      //        e.SubItem.Decoration = null;
      //}
    }

    private void listViewComplex_GroupTaskClicked (object sender, GroupTaskClickedEventArgs e)
    {
      MessageBox.Show(String.Format("group task click: {0}", e.Group), "OLV Demo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    /// <summary>
    /// ????
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void cmbHotItem_SelectedIndexChanged ( )
    {
      this.ChangeHotItemStyle(this.olvComplex, HotItemMode.Translucent);


      // Make the hot item show an overlay when it changes
      if (this.olvComplex.UseTranslucentHotItem)
      {
        this.olvComplex.HotItemStyle.Overlay = new PlayerSkillsOverlay();
        this.olvComplex.HotItemStyle = this.olvComplex.HotItemStyle;
      }

      this.olvComplex.UseTranslucentSelection = this.olvComplex.UseTranslucentHotItem;

      this.olvComplex.Invalidate();
    }

    private void ChangeHotItemStyle (ObjectListView olv, HotItemMode hotItemMode)
    {

      olv.UseTranslucentHotItem = false;
      olv.UseHotItem = true;
      olv.FullRowSelect = olv == this.olvComplex; // olvComplex should be full row select
      olv.UseExplorerTheme = false;

      switch (hotItemMode)
      {
        case HotItemMode.None:
          olv.UseHotItem = false;
          break;
        case HotItemMode.TextColor:
          HotItemStyle hotItemStyle = new HotItemStyle();
          hotItemStyle.ForeColor = Color.AliceBlue;
          hotItemStyle.BackColor = Color.FromArgb(255, 64, 64, 64);
          olv.HotItemStyle = hotItemStyle;
          break;
        case HotItemMode.Border:
          RowBorderDecoration rbd = new RowBorderDecoration();
          rbd.BorderPen = new Pen(Color.SeaGreen, 2);
          rbd.FillBrush = null;
          rbd.CornerRounding = 4.0f;
          HotItemStyle hotItemStyle2 = new HotItemStyle();
          hotItemStyle2.Decoration = rbd;
          olv.HotItemStyle = hotItemStyle2;
          break;
        case HotItemMode.Translucent: //
          olv.UseTranslucentHotItem = true;
          break;
        case HotItemMode.Lightbox:
          HotItemStyle hotItemStyle3 = new HotItemStyle();
          hotItemStyle3.Decoration = new LightBoxDecoration();
          olv.HotItemStyle = hotItemStyle3;
          break;
        case HotItemMode.Vista:
          if (ObjectListView.IsVistaOrLater)
          {
            olv.FullRowSelect = true;
            olv.UseHotItem = false;
            olv.UseExplorerTheme = true;
            // Using Explorer theme doesn't work in owner drawn mode
            if (olv == this.olvComplex)
              ChangeOwnerDrawn(olv, false);
          }
          break;
      }
      olv.Invalidate();
    }

    private void textBoxFilterComplex_TextChanged (object sender, EventArgs e)
    {
      this.TimedFilter(this.olvComplex, txtFilterComplex.Text);
    }

    void TimedFilter (ObjectListView olv, string txt)
    {
      this.TimedFilter(olv, txt, 0);
    }

    void TimedFilter (ObjectListView olv, string txt, int matchKind)
    {
      TextMatchFilter filter = null;
      if (!String.IsNullOrEmpty(txt))
      {
        switch (matchKind)
        {
          case 0:
          default:
            filter = TextMatchFilter.Contains(olv, txt);
            break;
          case 1:
            filter = TextMatchFilter.Prefix(olv, txt);
            break;
          case 2:
            filter = TextMatchFilter.Regex(olv, txt);
            break;
        }
      }
      // Setup a default renderer to draw the filter matches
      if (filter == null)
        olv.DefaultRenderer = null;
      else
      {
        olv.DefaultRenderer = new HighlightTextRenderer(filter);

        // Uncomment this line to see how the GDI+ rendering looks
        //olv.DefaultRenderer = new HighlightTextRenderer { Filter = filter, UseGdiTextRendering = false };
      }

      // Some lists have renderers already installed
      HighlightTextRenderer highlightingRenderer = olv.GetColumn(0).Renderer as HighlightTextRenderer;
      if (highlightingRenderer != null)
        highlightingRenderer.Filter = filter;

      Stopwatch stopWatch = new Stopwatch();
      stopWatch.Start();
      olv.AdditionalFilter = filter;
      //olv.Invalidate();
      stopWatch.Stop();

      IList objects = olv.Objects as IList;
      if (objects == null)
        this.toolStripStatusLabel1.Text =
            String.Format("Filtered in {0}ms", stopWatch.ElapsedMilliseconds);
      else
        this.toolStripStatusLabel1.Text =
            String.Format("Filtered {0} items down to {1} items in {2}ms",
                          objects.Count,
                          olv.Items.Count,
                          stopWatch.ElapsedMilliseconds);
    }


    private void olvComplex_BeforeCreatingGroups (object sender, CreateGroupsEventArgs e)
    {
      if (e.Parameters.PrimarySort == olvcDriA && Control.ModifierKeys == Keys.Control)
      {
        e.Parameters.GroupComparer = new StrangeGroupComparer(e.Parameters.PrimarySortOrder);
        e.Parameters.ItemComparer = new StrangeItemComparer(this.olvComplex.GetColumn(0), e.Parameters.PrimarySortOrder);
      }
    }


    private void olvComplex_ItemChecked (object sender, ItemCheckedEventArgs e)
    {
      System.Diagnostics.Debug.WriteLine("here");
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

    private void olv_HotItemChanged (object sender, HotItemChangedEventArgs e)
    {
      ObjectListView olv = sender as ObjectListView;
      if (sender == null)
      {
        this.toolStripStatusLabel3.Text = "";
        return;
      }

      switch (e.HotCellHitLocation)
      {
        case HitTestLocation.Nothing:
          this.toolStripStatusLabel3.Text = "Over nothing";
          break;
        case HitTestLocation.Group:
          this.toolStripStatusLabel3.Text = String.Format("Over group '{0}', {1}", e.HotGroup.Header, e.HotCellHitLocationEx);
          break;
        case HitTestLocation.GroupExpander:
          this.toolStripStatusLabel3.Text = String.Format("Over group expander of '{0}'", e.HotGroup.Header);
          break;
        default:
          this.toolStripStatusLabel3.Text = String.Format("Over {0} of ({1}, {2})", e.HotCellHitLocation, e.HotRowIndex, e.HotColumnIndex);
          break;
      }
    }

    private void chkOwnerDraw_CheckedChanged (object sender, EventArgs e)
    {
      ChangeOwnerDrawn(this.olvComplex, this.chkOwnerDraw.Checked);
    }

    #region before new columns
    /*
      void InitializeComplexExample (List<Player> list)
    {
      this.olvComplex.AddDecoration(new EditingCellBorderDecoration(true));

      // The following line makes getting aspect about 10x faster. Since getting the aspect is
      // the slowest part of building the ListView, it is worthwhile BUT NOT NECESSARY to do.
      TypedObjectListView<Player> tlist = new TypedObjectListView<Player>(this.olvComplex);
      tlist.GenerateAspectGetters();
      //The line above the equivilent to typing the following:
      tlist.GetColumn(0).AspectGetter = delegate(Player x) { return x.Name; };
      tlist.GetColumn(1).AspectGetter = delegate(Player x) { return x.Occupation; };
      tlist.GetColumn(2).AspectGetter = delegate(Player x) { return x.CulinaryRating; };
      tlist.GetColumn(3).AspectGetter = delegate(Player x) { return x.YearOfBirth; };
      tlist.GetColumn(4).AspectGetter = delegate(Player x) { return x.BirthDate; };
      tlist.GetColumn(5).AspectGetter = delegate(Player x) { return x.GetRate(); };
      tlist.GetColumn(6).AspectGetter = delegate(Player x) { return x.Comments; };
      

      this.olvcPlayer.AspectToStringConverter = delegate(object cellValue)
      {
        return ((String)cellValue).ToUpperInvariant();
      };
      this.olvcPlayer.ImageGetter = delegate(object row)
      {
        // People whose names start with a vowel get a star,
        // the last few letters get music and everyone else gets a Player
        string name = ((Player)row).Name.ToUpperInvariant();
        if (name.Length > 0 && "AEIOU".Contains(name.Substring(0, 1)))
          return "star";
        if (name.CompareTo("T") < 0)
          return 2; // Player

        return "music";
      };

      // Cooking skill columns
      this.olvcCookingSkill.MakeGroupies(
          new object[] { 10, 20, 30, 40 },
          new string[] { "Pay to eat out", "Suggest take-away", "Passable", "Seek dinner invitation", "Hire as chef" },
          new string[] { "not", "hamburger", "toast", "beef", "chef" },
          new string[] {
                    "Pay good money -- or flee the house -- rather than eat their homecooked food",
                    "Offer to buy takeaway rather than risk what may appear on your plate",
                    "Neither spectacular nor dangerous",
                    "Try to visit at dinner time to wrangle an invitation to dinner",
                    "Do whatever is necessary to procure their services" },
          new string[] { "Call 911", "Phone PizzaHut", "", "Open calendar", "Check bank balance" }
      );

      // Hourly rate column
      this.olvcHourlyRate.MakeGroupies(
          new Double[] { 100, 1000 },
          new string[] { "Less than $100", "$100-$1000", "Megabucks" });
      //this.olvcHourlyRate.AspectPutter = delegate(object x, object newValue) { ((Player)x).ShootingPosition((double)newValue); };

      // Salary indicator column
      this.olvcMoneyImage.AspectGetter = delegate(object row)
      {
        if (((Player)row).Salary < 100000)
          return "Little";
        if (((Player)row).Salary > 300000)
          return "Lots";
        return "Medium";
      };
      this.olvcMoneyImage.Renderer = new MappedImageRenderer(new Object[] { "Little"
        ,  AndreiPopescu.CharazayPlus.Properties.Resources.star12 , "Medium"
        , AndreiPopescu.CharazayPlus.Properties.Resources.star13, "Lots"
        , AndreiPopescu.CharazayPlus.Properties.Resources.star16 });

      // Birthday column
      this.olvcBirthday.GroupKeyGetter = delegate(object row)
      {
        return ((Player)row).Age;
      };
      this.olvcBirthday.GroupKeyToTitleConverter = delegate(object key)
      {
        return (new DateTime(1, (int)key, 1)).ToString("MMMM");
      };
      this.olvcBirthday.ImageGetter = delegate(object row)
      {
        Player p = (Player)row;
        // People born in leap years get an asterisk (yes, the leap year calculation is wrong).
        if ((p.Age % 4) == 0)
          return "hidden";

        return -1; // no image
      };
      this.olvcBirthday.ClusteringStrategy = new DateTimeClusteringStrategy(DateTimePortion.Month, "MMMM");

      // Use this column to test sorting and group on TimeSpan objects
      this.olvcDaysSinceBirth.AspectGetter = delegate(object row)
      {
        return ((Player)row).BMI;
      };
      this.olvcDaysSinceBirth.AspectToStringFormat = "{0:F02}";
    

      // Install a custom renderer that draws the Tile view in a special way
      this.olvComplex.ItemRenderer = new PlayerSkillsRenderer();

      // Drag and drop support
      // You can set up drag and drop explicitly (like this) or, in the IDE, you can set
      // IsSimpleDropSource and IsSimpleDragSource and respond to CanDrop and Dropped events

      this.olvComplex.DragSource = new SimpleDragSource();
      SimpleDropSink dropSink = new SimpleDropSink();
      this.olvComplex.DropSink = dropSink;
      dropSink.CanDropOnItem = true;
      //dropSink.CanDropOnSubItem = true;
      dropSink.FeedbackColor = Color.IndianRed; // just to be different

      dropSink.ModelCanDrop += new EventHandler<ModelDropEventArgs>(delegate(object sender, ModelDropEventArgs e)
      {
        Player Player = e.TargetModel as Player;
        if (Player == null)
        {
          e.Effect = DragDropEffects.None;
        }
        else
        {
          if (Player.ShootingPosition == Utils.ShooterPosition.MostOutside)
          {
            e.Effect = DragDropEffects.None;
            e.InfoMessage = "Can't drop on someone who is already married";
          }
          else
          {
            e.Effect = DragDropEffects.Move;
          }
        }
      });

      dropSink.ModelDropped += new EventHandler<ModelDropEventArgs>(delegate(object sender, ModelDropEventArgs e)
      {
        if (e.TargetModel == null)
          return;

        // Change the dropped people plus the target Player to be married
        ((Player)e.TargetModel).PositionType = typeof(PG);
        foreach (Player p in e.SourceModels)
          p.PositionType = typeof(PG);

        // Force them to refresh
        e.ListView.RefreshObject(e.TargetModel);
        e.ListView.RefreshObjects(e.SourceModels);
      });

      //
      cmbHotItem_SelectedIndexChanged();
      //
      this.cmbEditable.SelectedIndex = 0;

      this.olvComplex.SetObjects(list);
    }
     */
    #endregion
  }

  /// <summary>
  /// This simple class just shows how an overlay can be drawn when the hot item changes.
  /// </summary>
  internal class PlayerSkillsOverlay : AbstractOverlay
  {
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

      var cardSize = new Size(200, 200);
      var cardBounds = new Rectangle(r.Right - cardSize.Width - 8, r.Bottom - cardSize.Height - 8, cardSize.Width, cardSize.Height);
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
      const int spacing = 8;

      // Allow a border around the card
      itemBounds.Inflate(-2, -2);

      // Draw card background
      const int rounding = 20;
      var path = this.GetRoundedRect(itemBounds, rounding);
      g.FillPath(this.BackBrush, path);
      g.DrawPath(this.BorderPen, path);
      g.Clip = new Region(itemBounds);

      // Now draw the text portion
      RectangleF textBoxRect = itemBounds;
      itemBounds.Inflate(-spacing, -spacing);
      //textBoxRect.X += (itemBounds.Width + spacing);
      //textBoxRect.Width = itemBounds.Right - textBoxRect.X - spacing;

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
        //olv.GetColumn("olvcDef").GetStringValue(rowObject)
        
        g.DrawString("Defence", font, this.TextBrush, textBoxRect, fmt);
        RectangleF rVal = new RectangleF(textBoxRect.X + size.Width + spacing, textBoxRect.Y, textBoxRect.Width, textBoxRect.Height);
        g.DrawString(p.Defence_Display.ToString(), font, Brushes.DarkRed, rVal, fmt);
        rVal.X += + size.Width/5f + spacing;
        g.DrawString(p.Defence.ToString("F02"), font, Brushes.DarkGreen, rVal, fmt);
        textBoxRect.Y += size.Height;
        //
        g.DrawString("Frethrows", font, this.TextBrush, textBoxRect, fmt);
        rVal = new RectangleF(textBoxRect.X + size.Width + spacing, textBoxRect.Y, textBoxRect.Width, textBoxRect.Height);        
        g.DrawString(p.Freethrows_Display.ToString(), font, Brushes.DarkRed, rVal, fmt);
        rVal.X += +size.Width / 5f + spacing;
        g.DrawString(p.Freethrows.ToString("F02"), font, Brushes.DarkGreen, rVal, fmt);
        textBoxRect.Y += size.Height;
        //
        g.DrawString("2P", font, this.TextBrush, textBoxRect, fmt);
        rVal = new RectangleF(textBoxRect.X + size.Width + spacing, textBoxRect.Y, textBoxRect.Width, textBoxRect.Height);
        g.DrawString(p.TwoPoint_Display.ToString(), font, Brushes.DarkRed, rVal, fmt);
        rVal.X += +size.Width / 5f + spacing;
        g.DrawString(p.TwoPoint.ToString("F02"), font, Brushes.DarkGreen, rVal, fmt);
        textBoxRect.Y += size.Height;
        //
        g.DrawString("3P", font, this.TextBrush, textBoxRect, fmt);
        rVal = new RectangleF(textBoxRect.X + size.Width + spacing, textBoxRect.Y, textBoxRect.Width, textBoxRect.Height);
        g.DrawString(p.ThreePoint_Display.ToString(), font, Brushes.DarkRed, rVal, fmt);
        rVal.X += +size.Width / 5f + spacing;
        g.DrawString(p.ThreePoint.ToString("F02"), font, Brushes.DarkGreen, rVal, fmt);
        textBoxRect.Y += size.Height;
        //
        g.DrawString("Dribbling", font, this.TextBrush, textBoxRect, fmt);
        rVal = new RectangleF(textBoxRect.X + size.Width + spacing, textBoxRect.Y, textBoxRect.Width, textBoxRect.Height);
        g.DrawString(p.Dribling_Display.ToString(), font, Brushes.DarkRed, rVal, fmt);
        rVal.X += +size.Width / 5f + spacing;
        g.DrawString(p.Dribling.ToString("F02"), font, Brushes.DarkGreen, rVal, fmt);
        textBoxRect.Y += size.Height;
        //
        g.DrawString("Passing", font, this.TextBrush, textBoxRect, fmt);
        rVal = new RectangleF(textBoxRect.X + size.Width + spacing, textBoxRect.Y, textBoxRect.Width, textBoxRect.Height);
        g.DrawString(p.Passing_Display.ToString(), font, Brushes.DarkRed, rVal, fmt);
        rVal.X += +size.Width / 5f + spacing;
        g.DrawString(p.Passing.ToString("F02"), font, Brushes.DarkGreen, rVal, fmt);
        textBoxRect.Y += size.Height;
        //
        g.DrawString("Speed", font, this.TextBrush, textBoxRect, fmt);
        rVal = new RectangleF(textBoxRect.X + size.Width + spacing, textBoxRect.Y, textBoxRect.Width, textBoxRect.Height);
        g.DrawString(p.Speed_Display.ToString(), font, Brushes.DarkRed, rVal, fmt);
        rVal.X += +size.Width / 5f + spacing;
        g.DrawString(p.Speed.ToString("F02"), font, Brushes.DarkGreen, rVal, fmt);
        textBoxRect.Y += size.Height;
        //
        g.DrawString("Footwork", font, this.TextBrush, textBoxRect, fmt);
        rVal = new RectangleF(textBoxRect.X + size.Width + spacing, textBoxRect.Y, textBoxRect.Width, textBoxRect.Height);
        g.DrawString(p.Footwork_Display.ToString(), font, Brushes.DarkRed, rVal, fmt);
        rVal.X += +size.Width / 5f + spacing;
        g.DrawString(p.Footwork.ToString("F02"), font, Brushes.DarkGreen, rVal, fmt);
        textBoxRect.Y += size.Height;
        //
        g.DrawString("Rebounds", font, this.TextBrush, textBoxRect, fmt);
        rVal = new RectangleF(textBoxRect.X + size.Width + spacing, textBoxRect.Y, textBoxRect.Width, textBoxRect.Height);
        g.DrawString(p.Rebounds_Display.ToString(), font, Brushes.DarkRed, rVal, fmt);
        rVal.X += +size.Width / 5f + spacing;
        g.DrawString(p.Rebounds.ToString("F02"), font, Brushes.DarkGreen, rVal, fmt);
        textBoxRect.Y += size.Height;
        //
      }
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
