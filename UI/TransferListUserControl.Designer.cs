namespace AndreiPopescu.CharazayPlus.UI
{
  partial class TransferListUserControl
  {
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
      this.components = new System.ComponentModel.Container();
      this.tlpTL = new System.Windows.Forms.TableLayoutPanel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnTLAdd = new System.Windows.Forms.Button();
      this.gbxPosition = new System.Windows.Forms.GroupBox();
      this.rdC = new System.Windows.Forms.RadioButton();
      this.rdPf = new System.Windows.Forms.RadioButton();
      this.rdPg = new System.Windows.Forms.RadioButton();
      this.rdSg = new System.Windows.Forms.RadioButton();
      this.rdSf = new System.Windows.Forms.RadioButton();
      this.panel2 = new System.Windows.Forms.Panel();
      this.dtpDeadline = new System.Windows.Forms.DateTimePicker();
      this.label50 = new System.Windows.Forms.Label();
      this.tbxPlayerId = new System.Windows.Forms.TextBox();
      this.label52 = new System.Windows.Forms.Label();
      this.btnTLGet = new System.Windows.Forms.Button();
      this.tbxPrice = new System.Windows.Forms.TextBox();
      this.label51 = new System.Windows.Forms.Label();
      this.olvTL = new BrightIdeasSoftware.ObjectListView();
      this.olvcTLPosition = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLPrice = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLValueIndex = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLProfitability = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLDeadline = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLTotalScore = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLDefensiveScore = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLOffenseScore = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLOffensiveAbilityScore = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLShoot = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLRebounds = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLRebO = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLRebD = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.evaluatePlayerUC = new AndreiPopescu.CharazayPlus.UI.EvaluatePlayerUserControl();
      this.cmsOlvTL = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.cmsOlvTLRemove = new System.Windows.Forms.ToolStripMenuItem();
      this.tlpTL.SuspendLayout();
      this.panel1.SuspendLayout();
      this.gbxPosition.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvTL)).BeginInit();
      this.cmsOlvTL.SuspendLayout();
      this.SuspendLayout();
      // 
      // tlpTL
      // 
      this.tlpTL.ColumnCount = 3;
      this.tlpTL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
      this.tlpTL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74F));
      this.tlpTL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
      this.tlpTL.Controls.Add(this.panel1, 2, 0);
      this.tlpTL.Controls.Add(this.panel2, 0, 0);
      this.tlpTL.Controls.Add(this.olvTL, 0, 1);
      this.tlpTL.Controls.Add(this.evaluatePlayerUC, 1, 0);
      this.tlpTL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tlpTL.Location = new System.Drawing.Point(0, 0);
      this.tlpTL.Name = "tlpTL";
      this.tlpTL.RowCount = 2;
      this.tlpTL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 194F));
      this.tlpTL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tlpTL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tlpTL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tlpTL.Size = new System.Drawing.Size(707, 391);
      this.tlpTL.TabIndex = 12;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnTLAdd);
      this.panel1.Controls.Add(this.gbxPosition);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(617, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(87, 188);
      this.panel1.TabIndex = 0;
      // 
      // btnTLAdd
      // 
      this.btnTLAdd.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.btnTLAdd.Location = new System.Drawing.Point(0, 133);
      this.btnTLAdd.Name = "btnTLAdd";
      this.btnTLAdd.Size = new System.Drawing.Size(87, 55);
      this.btnTLAdd.TabIndex = 9;
      this.btnTLAdd.Text = "Add to List";
      this.btnTLAdd.UseVisualStyleBackColor = true;
      this.btnTLAdd.Click += new System.EventHandler(this.btnTLAdd_Click);
      // 
      // gbxPosition
      // 
      this.gbxPosition.Controls.Add(this.rdC);
      this.gbxPosition.Controls.Add(this.rdPf);
      this.gbxPosition.Controls.Add(this.rdPg);
      this.gbxPosition.Controls.Add(this.rdSg);
      this.gbxPosition.Controls.Add(this.rdSf);
      this.gbxPosition.Dock = System.Windows.Forms.DockStyle.Top;
      this.gbxPosition.Location = new System.Drawing.Point(0, 0);
      this.gbxPosition.Name = "gbxPosition";
      this.gbxPosition.Size = new System.Drawing.Size(87, 135);
      this.gbxPosition.TabIndex = 4;
      this.gbxPosition.TabStop = false;
      this.gbxPosition.Text = "Position";
      // 
      // rdC
      // 
      this.rdC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rdC.AutoSize = true;
      this.rdC.Location = new System.Drawing.Point(6, 108);
      this.rdC.Name = "rdC";
      this.rdC.Size = new System.Drawing.Size(32, 17);
      this.rdC.TabIndex = 4;
      this.rdC.TabStop = true;
      this.rdC.Text = "C";
      this.rdC.UseVisualStyleBackColor = true;
      // 
      // rdPf
      // 
      this.rdPf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rdPf.AutoSize = true;
      this.rdPf.Location = new System.Drawing.Point(6, 85);
      this.rdPf.Name = "rdPf";
      this.rdPf.Size = new System.Drawing.Size(38, 17);
      this.rdPf.TabIndex = 3;
      this.rdPf.TabStop = true;
      this.rdPf.Text = "PF";
      this.rdPf.UseVisualStyleBackColor = true;
      // 
      // rdPg
      // 
      this.rdPg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rdPg.AutoSize = true;
      this.rdPg.Location = new System.Drawing.Point(6, 16);
      this.rdPg.Name = "rdPg";
      this.rdPg.Size = new System.Drawing.Size(40, 17);
      this.rdPg.TabIndex = 0;
      this.rdPg.TabStop = true;
      this.rdPg.Text = "PG";
      this.rdPg.UseVisualStyleBackColor = true;
      // 
      // rdSg
      // 
      this.rdSg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rdSg.AutoSize = true;
      this.rdSg.Location = new System.Drawing.Point(6, 39);
      this.rdSg.Name = "rdSg";
      this.rdSg.Size = new System.Drawing.Size(40, 17);
      this.rdSg.TabIndex = 1;
      this.rdSg.TabStop = true;
      this.rdSg.Text = "SG";
      this.rdSg.UseVisualStyleBackColor = true;
      // 
      // rdSf
      // 
      this.rdSf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rdSf.AutoSize = true;
      this.rdSf.Location = new System.Drawing.Point(6, 62);
      this.rdSf.Name = "rdSf";
      this.rdSf.Size = new System.Drawing.Size(38, 17);
      this.rdSf.TabIndex = 2;
      this.rdSf.TabStop = true;
      this.rdSf.Text = "SF";
      this.rdSf.UseVisualStyleBackColor = true;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.dtpDeadline);
      this.panel2.Controls.Add(this.label50);
      this.panel2.Controls.Add(this.tbxPlayerId);
      this.panel2.Controls.Add(this.label52);
      this.panel2.Controls.Add(this.btnTLGet);
      this.panel2.Controls.Add(this.tbxPrice);
      this.panel2.Controls.Add(this.label51);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(85, 188);
      this.panel2.TabIndex = 1;
      // 
      // dtpDeadline
      // 
      this.dtpDeadline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dtpDeadline.CustomFormat = "yyyy-MM-dd HH:mm";
      this.dtpDeadline.Enabled = false;
      this.dtpDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpDeadline.Location = new System.Drawing.Point(6, 155);
      this.dtpDeadline.Name = "dtpDeadline";
      this.dtpDeadline.ShowUpDown = true;
      this.dtpDeadline.Size = new System.Drawing.Size(84, 20);
      this.dtpDeadline.TabIndex = 8;
      this.dtpDeadline.Visible = false;
      // 
      // label50
      // 
      this.label50.AutoSize = true;
      this.label50.Location = new System.Drawing.Point(0, 0);
      this.label50.Name = "label50";
      this.label50.Size = new System.Drawing.Size(47, 13);
      this.label50.TabIndex = 0;
      this.label50.Text = "Player id";
      this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // tbxPlayerId
      // 
      this.tbxPlayerId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxPlayerId.Location = new System.Drawing.Point(6, 16);
      this.tbxPlayerId.Name = "tbxPlayerId";
      this.tbxPlayerId.Size = new System.Drawing.Size(84, 20);
      this.tbxPlayerId.TabIndex = 1;
      // 
      // label52
      // 
      this.label52.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label52.AutoSize = true;
      this.label52.Enabled = false;
      this.label52.Location = new System.Drawing.Point(3, 139);
      this.label52.Name = "label52";
      this.label52.Size = new System.Drawing.Size(49, 13);
      this.label52.TabIndex = 7;
      this.label52.Text = "Deadline";
      this.label52.Visible = false;
      // 
      // btnTLGet
      // 
      this.btnTLGet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnTLGet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.btnTLGet.Location = new System.Drawing.Point(5, 42);
      this.btnTLGet.Name = "btnTLGet";
      this.btnTLGet.Size = new System.Drawing.Size(84, 37);
      this.btnTLGet.TabIndex = 2;
      this.btnTLGet.Text = "Get";
      this.btnTLGet.UseVisualStyleBackColor = true;
      this.btnTLGet.Click += new System.EventHandler(this.btnTLGet_Click);
      // 
      // tbxPrice
      // 
      this.tbxPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxPrice.Enabled = false;
      this.tbxPrice.Location = new System.Drawing.Point(6, 108);
      this.tbxPrice.Name = "tbxPrice";
      this.tbxPrice.Size = new System.Drawing.Size(84, 20);
      this.tbxPrice.TabIndex = 6;
      this.tbxPrice.Visible = false;
      // 
      // label51
      // 
      this.label51.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label51.AutoSize = true;
      this.label51.Enabled = false;
      this.label51.Location = new System.Drawing.Point(16, 87);
      this.label51.Name = "label51";
      this.label51.Size = new System.Drawing.Size(31, 13);
      this.label51.TabIndex = 5;
      this.label51.Text = "Price";
      this.label51.Visible = false;
      // 
      // olvTL
      // 
      this.olvTL.AllColumns.Add(this.olvcTLPosition);
      this.olvTL.AllColumns.Add(this.olvcTLName);
      this.olvTL.AllColumns.Add(this.olvcTLPrice);
      this.olvTL.AllColumns.Add(this.olvcTLValueIndex);
      this.olvTL.AllColumns.Add(this.olvcTLProfitability);
      this.olvTL.AllColumns.Add(this.olvcTLDeadline);
      this.olvTL.AllColumns.Add(this.olvcTLTotalScore);
      this.olvTL.AllColumns.Add(this.olvcTLDefensiveScore);
      this.olvTL.AllColumns.Add(this.olvcTLOffenseScore);
      this.olvTL.AllColumns.Add(this.olvcTLOffensiveAbilityScore);
      this.olvTL.AllColumns.Add(this.olvcTLShoot);
      this.olvTL.AllColumns.Add(this.olvcTLRebounds);
      this.olvTL.AllColumns.Add(this.olvcTLRebO);
      this.olvTL.AllColumns.Add(this.olvcTLRebD);
      this.olvTL.BackColor = System.Drawing.Color.Beige;
      this.olvTL.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
      this.olvTL.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcTLPosition,
            this.olvcTLName,
            this.olvcTLPrice,
            this.olvcTLValueIndex,
            this.olvcTLProfitability,
            this.olvcTLDeadline,
            this.olvcTLTotalScore,
            this.olvcTLDefensiveScore,
            this.olvcTLOffenseScore,
            this.olvcTLOffensiveAbilityScore,
            this.olvcTLShoot,
            this.olvcTLRebounds,
            this.olvcTLRebO,
            this.olvcTLRebD});
      this.tlpTL.SetColumnSpan(this.olvTL, 3);
      this.olvTL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.olvTL.FullRowSelect = true;
      this.olvTL.HeaderUsesThemes = false;
      this.olvTL.HeaderWordWrap = true;
      this.olvTL.Location = new System.Drawing.Point(3, 197);
      this.olvTL.MinimumSize = new System.Drawing.Size(100, 100);
      this.olvTL.Name = "olvTL";
      this.olvTL.Size = new System.Drawing.Size(701, 191);
      this.olvTL.TabIndex = 10;
      this.olvTL.UseCompatibleStateImageBehavior = false;
      this.olvTL.View = System.Windows.Forms.View.Details;
      this.olvTL.BeforeSorting += new System.EventHandler<BrightIdeasSoftware.BeforeSortingEventArgs>(this.olvTL_BeforeSorting);
      this.olvTL.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.olvTL_CellEditFinishing);
      this.olvTL.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.olvTL_CellEditStarting);
      this.olvTL.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.olvTL_CellRightClick);
      this.olvTL.SelectionChanged += new System.EventHandler(this.olvTL_SelectionChanged);
      this.olvTL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.olvTL_KeyDown);
      // 
      // olvcTLPosition
      // 
      this.olvcTLPosition.AspectName = "Pos";
      this.olvcTLPosition.CellPadding = null;
      this.olvcTLPosition.IsEditable = false;
      this.olvcTLPosition.IsHeaderVertical = true;
      this.olvcTLPosition.Text = "Position";
      this.olvcTLPosition.Width = 50;
      this.olvcTLPosition.WordWrap = true;
      // 
      // olvcTLName
      // 
      this.olvcTLName.AspectName = "Name";
      this.olvcTLName.CellPadding = null;
      this.olvcTLName.Groupable = false;
      this.olvcTLName.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvcTLName.IsEditable = false;
      this.olvcTLName.Text = "Name";
      this.olvcTLName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvcTLName.Width = 110;
      this.olvcTLName.WordWrap = true;
      // 
      // olvcTLPrice
      // 
      this.olvcTLPrice.AspectName = "Price";
      this.olvcTLPrice.CellPadding = null;
      this.olvcTLPrice.Text = "Price";
      // 
      // olvcTLValueIndex
      // 
      this.olvcTLValueIndex.AspectName = "ValueIndex";
      this.olvcTLValueIndex.AspectToStringFormat = "{0:F02}";
      this.olvcTLValueIndex.CellPadding = null;
      this.olvcTLValueIndex.IsEditable = false;
      this.olvcTLValueIndex.IsHeaderVertical = true;
      this.olvcTLValueIndex.Text = "ValueIndex";
      this.olvcTLValueIndex.Width = 35;
      this.olvcTLValueIndex.WordWrap = true;
      // 
      // olvcTLProfitability
      // 
      this.olvcTLProfitability.AspectName = "Profitability";
      this.olvcTLProfitability.AspectToStringFormat = "{0:F02}";
      this.olvcTLProfitability.CellPadding = null;
      this.olvcTLProfitability.IsEditable = false;
      this.olvcTLProfitability.IsHeaderVertical = true;
      this.olvcTLProfitability.Text = "Profitability";
      this.olvcTLProfitability.Width = 35;
      this.olvcTLProfitability.WordWrap = true;
      // 
      // olvcTLDeadline
      // 
      this.olvcTLDeadline.AspectName = "Deadline";
      this.olvcTLDeadline.CellPadding = null;
      this.olvcTLDeadline.Text = "Deadline";
      this.olvcTLDeadline.Width = 100;
      // 
      // olvcTLTotalScore
      // 
      this.olvcTLTotalScore.AspectName = "Total";
      this.olvcTLTotalScore.AspectToStringFormat = "{0:F02}";
      this.olvcTLTotalScore.CellPadding = null;
      this.olvcTLTotalScore.IsEditable = false;
      this.olvcTLTotalScore.IsHeaderVertical = true;
      this.olvcTLTotalScore.Text = "Total";
      this.olvcTLTotalScore.Width = 41;
      this.olvcTLTotalScore.WordWrap = true;
      // 
      // olvcTLDefensiveScore
      // 
      this.olvcTLDefensiveScore.AspectName = "Def";
      this.olvcTLDefensiveScore.AspectToStringFormat = "{0:F02}";
      this.olvcTLDefensiveScore.CellPadding = null;
      this.olvcTLDefensiveScore.IsEditable = false;
      this.olvcTLDefensiveScore.IsHeaderVertical = true;
      this.olvcTLDefensiveScore.Text = "Defensive Score";
      this.olvcTLDefensiveScore.Width = 39;
      this.olvcTLDefensiveScore.WordWrap = true;
      // 
      // olvcTLOffenseScore
      // 
      this.olvcTLOffenseScore.AspectName = "Off";
      this.olvcTLOffenseScore.AspectToStringFormat = "{0:F02}";
      this.olvcTLOffenseScore.CellPadding = null;
      this.olvcTLOffenseScore.IsEditable = false;
      this.olvcTLOffenseScore.IsHeaderVertical = true;
      this.olvcTLOffenseScore.Text = "Offense Score";
      this.olvcTLOffenseScore.Width = 39;
      this.olvcTLOffenseScore.WordWrap = true;
      // 
      // olvcTLOffensiveAbilityScore
      // 
      this.olvcTLOffensiveAbilityScore.AspectName = "OfAb";
      this.olvcTLOffensiveAbilityScore.AspectToStringFormat = "{0:F02}";
      this.olvcTLOffensiveAbilityScore.CellPadding = null;
      this.olvcTLOffensiveAbilityScore.IsEditable = false;
      this.olvcTLOffensiveAbilityScore.IsHeaderVertical = true;
      this.olvcTLOffensiveAbilityScore.Text = "Offensive Ability Score";
      this.olvcTLOffensiveAbilityScore.Width = 39;
      // 
      // olvcTLShoot
      // 
      this.olvcTLShoot.AspectName = "Shoot";
      this.olvcTLShoot.AspectToStringFormat = "{0:F02}";
      this.olvcTLShoot.CellPadding = null;
      this.olvcTLShoot.IsEditable = false;
      this.olvcTLShoot.IsHeaderVertical = true;
      this.olvcTLShoot.Text = "Shooting Score";
      this.olvcTLShoot.Width = 39;
      this.olvcTLShoot.WordWrap = true;
      // 
      // olvcTLRebounds
      // 
      this.olvcTLRebounds.AspectName = "Reb";
      this.olvcTLRebounds.AspectToStringFormat = "{0:F02}";
      this.olvcTLRebounds.CellPadding = null;
      this.olvcTLRebounds.IsEditable = false;
      this.olvcTLRebounds.IsHeaderVertical = true;
      this.olvcTLRebounds.Text = "Rebounds Score";
      this.olvcTLRebounds.Width = 39;
      this.olvcTLRebounds.WordWrap = true;
      // 
      // olvcTLRebO
      // 
      this.olvcTLRebO.AspectName = "RebO";
      this.olvcTLRebO.AspectToStringFormat = "{0:F02}";
      this.olvcTLRebO.CellPadding = null;
      this.olvcTLRebO.IsEditable = false;
      this.olvcTLRebO.IsHeaderVertical = true;
      this.olvcTLRebO.Text = "Offensive Rebounds Score";
      this.olvcTLRebO.Width = 39;
      // 
      // olvcTLRebD
      // 
      this.olvcTLRebD.AspectName = "RebD";
      this.olvcTLRebD.AspectToStringFormat = "{0:F02}";
      this.olvcTLRebD.CellPadding = null;
      this.olvcTLRebD.IsEditable = false;
      this.olvcTLRebD.IsHeaderVertical = true;
      this.olvcTLRebD.Text = "Defensive Rebounds Score";
      this.olvcTLRebD.Width = 39;
      this.olvcTLRebD.WordWrap = true;
      // 
      // evaluatePlayerUC
      // 
      this.evaluatePlayerUC.AutoSize = true;
      this.evaluatePlayerUC.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.evaluatePlayerUC.BackColor = System.Drawing.Color.DimGray;
      this.evaluatePlayerUC.CausesValidation = false;
      this.evaluatePlayerUC.Dock = System.Windows.Forms.DockStyle.Fill;
      this.evaluatePlayerUC.ForeColor = System.Drawing.Color.White;
      this.evaluatePlayerUC.Location = new System.Drawing.Point(94, 3);
      this.evaluatePlayerUC.Name = "evaluatePlayerUC";
      this.evaluatePlayerUC.SelectedObject = null;
      this.evaluatePlayerUC.Size = new System.Drawing.Size(517, 188);
      this.evaluatePlayerUC.TabIndex = 11;
      // 
      // cmsOlvTL
      // 
      this.cmsOlvTL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsOlvTLRemove});
      this.cmsOlvTL.Name = "cmsOlvTL";
      this.cmsOlvTL.Size = new System.Drawing.Size(118, 26);
      // 
      // cmsOlvTLRemove
      // 
      this.cmsOlvTLRemove.Name = "cmsOlvTLRemove";
      this.cmsOlvTLRemove.Size = new System.Drawing.Size(117, 22);
      this.cmsOlvTLRemove.Text = "Remove";
      this.cmsOlvTLRemove.Click += new System.EventHandler(this.cmsOlvTLRemove_Click);
      // 
      // TransferListUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tlpTL);
      this.DoubleBuffered = true;
      this.Name = "TransferListUserControl";
      this.Size = new System.Drawing.Size(707, 391);
      this.tlpTL.ResumeLayout(false);
      this.tlpTL.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.gbxPosition.ResumeLayout(false);
      this.gbxPosition.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvTL)).EndInit();
      this.cmsOlvTL.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tlpTL;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnTLAdd;
    private System.Windows.Forms.GroupBox gbxPosition;
    private System.Windows.Forms.RadioButton rdC;
    private System.Windows.Forms.RadioButton rdPf;
    private System.Windows.Forms.RadioButton rdPg;
    private System.Windows.Forms.RadioButton rdSg;
    private System.Windows.Forms.RadioButton rdSf;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.DateTimePicker dtpDeadline;
    private System.Windows.Forms.Label label50;
    private System.Windows.Forms.TextBox tbxPlayerId;
    private System.Windows.Forms.Label label52;
    private System.Windows.Forms.Button btnTLGet;
    private System.Windows.Forms.TextBox tbxPrice;
    private System.Windows.Forms.Label label51;
    private BrightIdeasSoftware.ObjectListView olvTL;
    private BrightIdeasSoftware.OLVColumn olvcTLPosition;
    private BrightIdeasSoftware.OLVColumn olvcTLName;
    private BrightIdeasSoftware.OLVColumn olvcTLPrice;
    private BrightIdeasSoftware.OLVColumn olvcTLValueIndex;
    private BrightIdeasSoftware.OLVColumn olvcTLProfitability;
    private BrightIdeasSoftware.OLVColumn olvcTLDeadline;
    private BrightIdeasSoftware.OLVColumn olvcTLTotalScore;
    private BrightIdeasSoftware.OLVColumn olvcTLDefensiveScore;
    private BrightIdeasSoftware.OLVColumn olvcTLOffenseScore;
    private BrightIdeasSoftware.OLVColumn olvcTLOffensiveAbilityScore;
    private BrightIdeasSoftware.OLVColumn olvcTLShoot;
    private BrightIdeasSoftware.OLVColumn olvcTLRebounds;
    private BrightIdeasSoftware.OLVColumn olvcTLRebO;
    private BrightIdeasSoftware.OLVColumn olvcTLRebD;
    private EvaluatePlayerUserControl evaluatePlayerUC;
    private System.Windows.Forms.ContextMenuStrip cmsOlvTL;
    private System.Windows.Forms.ToolStripMenuItem cmsOlvTLRemove;
  }
}
