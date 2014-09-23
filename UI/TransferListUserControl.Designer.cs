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
      this.olvTL = new BrightIdeasSoftware.ObjectListView();
      this.ucEvaluatePlayer = new AndreiPopescu.CharazayPlus.UI.EvaluatePlayerUserControl();
      this.flp = new System.Windows.Forms.FlowLayoutPanel();
      this.label50 = new System.Windows.Forms.Label();
      this.tbxPlayerId = new System.Windows.Forms.TextBox();
      this.btnTLGet = new System.Windows.Forms.Button();
      this.label51 = new System.Windows.Forms.Label();
      this.tbxPrice = new System.Windows.Forms.TextBox();
      this.label52 = new System.Windows.Forms.Label();
      this.dtpDeadline = new System.Windows.Forms.DateTimePicker();
      this.gbxPosition = new System.Windows.Forms.GroupBox();
      this.rdC = new System.Windows.Forms.RadioButton();
      this.rdPf = new System.Windows.Forms.RadioButton();
      this.rdPg = new System.Windows.Forms.RadioButton();
      this.rdSg = new System.Windows.Forms.RadioButton();
      this.rdSf = new System.Windows.Forms.RadioButton();
      this.btnTLAdd = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.lblServertime = new System.Windows.Forms.Label();
      this.ucBasicPlayerInfo = new AndreiPopescu.CharazayPlus.UI.BasicPlayerUserControl();
      this.cmsOlvTL = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.cmsRemove = new System.Windows.Forms.ToolStripMenuItem();
      this.cmsUpdate = new System.Windows.Forms.ToolStripMenuItem();
      this.cmsImportance = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiHigh = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiMedium = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiSmall = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiNone = new System.Windows.Forms.ToolStripMenuItem();
      this.tlpTL.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvTL)).BeginInit();
      this.flp.SuspendLayout();
      this.gbxPosition.SuspendLayout();
      this.cmsOlvTL.SuspendLayout();
      this.SuspendLayout();
      // 
      // tlpTL
      // 
      this.tlpTL.ColumnCount = 3;
      this.tlpTL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tlpTL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tlpTL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
      this.tlpTL.Controls.Add(this.olvTL, 1, 1);
      this.tlpTL.Controls.Add(this.ucEvaluatePlayer, 0, 0);
      this.tlpTL.Controls.Add(this.flp, 0, 1);
      this.tlpTL.Controls.Add(this.ucBasicPlayerInfo, 2, 1);
      this.tlpTL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tlpTL.Location = new System.Drawing.Point(0, 0);
      this.tlpTL.Name = "tlpTL";
      this.tlpTL.RowCount = 2;
      this.tlpTL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tlpTL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
      this.tlpTL.Size = new System.Drawing.Size(703, 642);
      this.tlpTL.TabIndex = 12;
      // 
      // olvTL
      // 
      this.olvTL.AlternateRowBackColor = System.Drawing.Color.Silver;
      this.olvTL.BackColor = System.Drawing.Color.LightGray;
      this.olvTL.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
      this.olvTL.Cursor = System.Windows.Forms.Cursors.Default;
      this.olvTL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.olvTL.FullRowSelect = true;
      this.olvTL.HeaderUsesThemes = false;
      this.olvTL.HeaderWordWrap = true;
      this.olvTL.HighlightBackgroundColor = System.Drawing.Color.LightSlateGray;
      this.olvTL.HighlightForegroundColor = System.Drawing.Color.White;
      this.olvTL.Location = new System.Drawing.Point(143, 131);
      this.olvTL.MinimumSize = new System.Drawing.Size(100, 100);
      this.olvTL.Name = "olvTL";
      this.olvTL.OwnerDraw = true;
      this.olvTL.Size = new System.Drawing.Size(345, 508);
      this.olvTL.SortGroupItemsByPrimaryColumn = false;
      this.olvTL.Sorting = System.Windows.Forms.SortOrder.Descending;
      this.olvTL.TabIndex = 18;
      this.olvTL.UseAlternatingBackColors = true;
      this.olvTL.UseCompatibleStateImageBehavior = false;
      this.olvTL.UseHotItem = true;
      this.olvTL.UseHyperlinks = true;
      this.olvTL.View = System.Windows.Forms.View.Details;
      this.olvTL.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.olvTL_CellEditFinishing);
      this.olvTL.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.olvTL_CellEditStarting);
      this.olvTL.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.olvTL_CellRightClick);
      this.olvTL.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(this.olvTL_HyperlinkClicked);
      this.olvTL.IsHyperlink += new System.EventHandler<BrightIdeasSoftware.IsHyperlinkEventArgs>(this.olvTL_IsHyperlink);
      this.olvTL.SelectionChanged += new System.EventHandler(this.olvTL_SelectionChanged);
      this.olvTL.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.olvTL_ColumnClick);
      this.olvTL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.olvTL_KeyDown);
      // 
      // ucEvaluatePlayer
      // 
      this.ucEvaluatePlayer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucEvaluatePlayer.BackColor = System.Drawing.Color.DimGray;
      this.ucEvaluatePlayer.CausesValidation = false;
      this.tlpTL.SetColumnSpan(this.ucEvaluatePlayer, 3);
      this.ucEvaluatePlayer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucEvaluatePlayer.ForeColor = System.Drawing.Color.White;
      this.ucEvaluatePlayer.Location = new System.Drawing.Point(3, 3);
      this.ucEvaluatePlayer.Name = "ucEvaluatePlayer";
      this.ucEvaluatePlayer.SelectedObject = null;
      this.ucEvaluatePlayer.Size = new System.Drawing.Size(697, 122);
      this.ucEvaluatePlayer.TabIndex = 16;
      // 
      // flp
      // 
      this.flp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.flp.BackColor = System.Drawing.Color.Gainsboro;
      this.flp.Controls.Add(this.label50);
      this.flp.Controls.Add(this.tbxPlayerId);
      this.flp.Controls.Add(this.btnTLGet);
      this.flp.Controls.Add(this.label51);
      this.flp.Controls.Add(this.tbxPrice);
      this.flp.Controls.Add(this.label52);
      this.flp.Controls.Add(this.dtpDeadline);
      this.flp.Controls.Add(this.gbxPosition);
      this.flp.Controls.Add(this.btnTLAdd);
      this.flp.Controls.Add(this.label1);
      this.flp.Controls.Add(this.lblServertime);
      this.flp.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.flp.Location = new System.Drawing.Point(3, 131);
      this.flp.Name = "flp";
      this.flp.Size = new System.Drawing.Size(134, 508);
      this.flp.TabIndex = 17;
      // 
      // label50
      // 
      this.label50.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label50.AutoSize = true;
      this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label50.Location = new System.Drawing.Point(3, 0);
      this.label50.Name = "label50";
      this.label50.Size = new System.Drawing.Size(125, 15);
      this.label50.TabIndex = 0;
      this.label50.Text = "Player id";
      this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // tbxPlayerId
      // 
      this.tbxPlayerId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxPlayerId.CausesValidation = false;
      this.tbxPlayerId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.tbxPlayerId.Location = new System.Drawing.Point(3, 18);
      this.tbxPlayerId.MinimumSize = new System.Drawing.Size(108, 25);
      this.tbxPlayerId.Name = "tbxPlayerId";
      this.tbxPlayerId.Size = new System.Drawing.Size(125, 22);
      this.tbxPlayerId.TabIndex = 1;
      // 
      // btnTLGet
      // 
      this.btnTLGet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnTLGet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.btnTLGet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.btnTLGet.Location = new System.Drawing.Point(3, 46);
      this.btnTLGet.Name = "btnTLGet";
      this.btnTLGet.Size = new System.Drawing.Size(125, 53);
      this.btnTLGet.TabIndex = 2;
      this.btnTLGet.Text = "Get";
      this.btnTLGet.UseVisualStyleBackColor = true;
      this.btnTLGet.Click += new System.EventHandler(this.btnTLGet_Click);
      // 
      // label51
      // 
      this.label51.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label51.AutoSize = true;
      this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label51.Location = new System.Drawing.Point(3, 102);
      this.label51.Name = "label51";
      this.label51.Size = new System.Drawing.Size(125, 15);
      this.label51.TabIndex = 5;
      this.label51.Text = "StartingPrice";
      // 
      // tbxPrice
      // 
      this.tbxPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.tbxPrice.Location = new System.Drawing.Point(3, 120);
      this.tbxPrice.Name = "tbxPrice";
      this.tbxPrice.Size = new System.Drawing.Size(125, 22);
      this.tbxPrice.TabIndex = 6;
      // 
      // label52
      // 
      this.label52.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label52.AutoSize = true;
      this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label52.Location = new System.Drawing.Point(3, 145);
      this.label52.Name = "label52";
      this.label52.Size = new System.Drawing.Size(125, 15);
      this.label52.TabIndex = 7;
      this.label52.Text = "Deadline";
      // 
      // dtpDeadline
      // 
      this.dtpDeadline.CustomFormat = "yyyy-MM-dd HH:mm";
      this.dtpDeadline.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dtpDeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.dtpDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpDeadline.Location = new System.Drawing.Point(3, 163);
      this.dtpDeadline.MinimumSize = new System.Drawing.Size(125, 21);
      this.dtpDeadline.Name = "dtpDeadline";
      this.dtpDeadline.ShowUpDown = true;
      this.dtpDeadline.Size = new System.Drawing.Size(125, 21);
      this.dtpDeadline.TabIndex = 8;
      // 
      // gbxPosition
      // 
      this.gbxPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gbxPosition.Controls.Add(this.rdC);
      this.gbxPosition.Controls.Add(this.rdPf);
      this.gbxPosition.Controls.Add(this.rdPg);
      this.gbxPosition.Controls.Add(this.rdSg);
      this.gbxPosition.Controls.Add(this.rdSf);
      this.gbxPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.gbxPosition.Location = new System.Drawing.Point(3, 190);
      this.gbxPosition.Name = "gbxPosition";
      this.gbxPosition.Size = new System.Drawing.Size(125, 139);
      this.gbxPosition.TabIndex = 16;
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
      this.rdC.Size = new System.Drawing.Size(33, 19);
      this.rdC.TabIndex = 4;
      this.rdC.TabStop = true;
      this.rdC.Text = "C";
      this.rdC.UseVisualStyleBackColor = true;
      this.rdC.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
      // 
      // rdPf
      // 
      this.rdPf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rdPf.AutoSize = true;
      this.rdPf.Location = new System.Drawing.Point(6, 85);
      this.rdPf.Name = "rdPf";
      this.rdPf.Size = new System.Drawing.Size(40, 19);
      this.rdPf.TabIndex = 3;
      this.rdPf.TabStop = true;
      this.rdPf.Text = "PF";
      this.rdPf.UseVisualStyleBackColor = true;
      this.rdPf.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
      // 
      // rdPg
      // 
      this.rdPg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rdPg.AutoSize = true;
      this.rdPg.Location = new System.Drawing.Point(6, 16);
      this.rdPg.Name = "rdPg";
      this.rdPg.Size = new System.Drawing.Size(42, 19);
      this.rdPg.TabIndex = 0;
      this.rdPg.TabStop = true;
      this.rdPg.Text = "PG";
      this.rdPg.UseVisualStyleBackColor = true;
      this.rdPg.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
      // 
      // rdSg
      // 
      this.rdSg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rdSg.AutoSize = true;
      this.rdSg.Location = new System.Drawing.Point(6, 39);
      this.rdSg.Name = "rdSg";
      this.rdSg.Size = new System.Drawing.Size(42, 19);
      this.rdSg.TabIndex = 1;
      this.rdSg.TabStop = true;
      this.rdSg.Text = "SG";
      this.rdSg.UseVisualStyleBackColor = true;
      this.rdSg.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
      // 
      // rdSf
      // 
      this.rdSf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rdSf.AutoSize = true;
      this.rdSf.Location = new System.Drawing.Point(6, 62);
      this.rdSf.Name = "rdSf";
      this.rdSf.Size = new System.Drawing.Size(40, 19);
      this.rdSf.TabIndex = 2;
      this.rdSf.TabStop = true;
      this.rdSf.Text = "SF";
      this.rdSf.UseVisualStyleBackColor = true;
      this.rdSf.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
      // 
      // btnTLAdd
      // 
      this.btnTLAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnTLAdd.Enabled = false;
      this.btnTLAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.btnTLAdd.Location = new System.Drawing.Point(3, 335);
      this.btnTLAdd.Name = "btnTLAdd";
      this.btnTLAdd.Size = new System.Drawing.Size(125, 52);
      this.btnTLAdd.TabIndex = 16;
      this.btnTLAdd.Text = "Add to List";
      this.btnTLAdd.UseVisualStyleBackColor = true;
      this.btnTLAdd.Click += new System.EventHandler(this.btnTLAdd_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 390);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(57, 13);
      this.label1.TabIndex = 17;
      this.label1.Text = "Servertime";
      // 
      // lblServertime
      // 
      this.lblServertime.BackColor = System.Drawing.Color.Black;
      this.lblServertime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblServertime.ForeColor = System.Drawing.Color.White;
      this.lblServertime.Location = new System.Drawing.Point(3, 403);
      this.lblServertime.Name = "lblServertime";
      this.lblServertime.Size = new System.Drawing.Size(125, 32);
      this.lblServertime.TabIndex = 18;
      this.lblServertime.Text = "-";
      this.lblServertime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // ucBasicPlayerInfo
      // 
      this.ucBasicPlayerInfo.CurrentPrice = null;
      this.ucBasicPlayerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucBasicPlayerInfo.Location = new System.Drawing.Point(494, 131);
      this.ucBasicPlayerInfo.Name = "ucBasicPlayerInfo";
      this.ucBasicPlayerInfo.PlayerByScore = null;
      this.ucBasicPlayerInfo.PlayerByValueIndex = null;
      this.ucBasicPlayerInfo.Size = new System.Drawing.Size(206, 508);
      this.ucBasicPlayerInfo.TabIndex = 19;
      // 
      // cmsOlvTL
      // 
      this.cmsOlvTL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsRemove,
            this.cmsUpdate,
            this.cmsImportance});
      this.cmsOlvTL.Name = "cmsOlvTL";
      this.cmsOlvTL.Size = new System.Drawing.Size(136, 70);
      // 
      // cmsRemove
      // 
      this.cmsRemove.Name = "cmsRemove";
      this.cmsRemove.Size = new System.Drawing.Size(135, 22);
      this.cmsRemove.Text = "Remove";
      this.cmsRemove.Click += new System.EventHandler(this.cmsOlvTLRemove_Click);
      // 
      // cmsUpdate
      // 
      this.cmsUpdate.Name = "cmsUpdate";
      this.cmsUpdate.Size = new System.Drawing.Size(135, 22);
      this.cmsUpdate.Text = "Update";
      this.cmsUpdate.Click += new System.EventHandler(this.cmsOlvTLUpdate_Click);
      // 
      // cmsImportance
      // 
      this.cmsImportance.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHigh,
            this.tsmiMedium,
            this.tsmiSmall,
            this.tsmiNone});
      this.cmsImportance.Name = "cmsImportance";
      this.cmsImportance.Size = new System.Drawing.Size(135, 22);
      this.cmsImportance.Text = "Importance";
      // 
      // tsmiHigh
      // 
      this.tsmiHigh.Name = "tsmiHigh";
      this.tsmiHigh.Size = new System.Drawing.Size(119, 22);
      this.tsmiHigh.Text = "High";
      this.tsmiHigh.Click += new System.EventHandler(this.tsmiHigh_Click);
      // 
      // tsmiMedium
      // 
      this.tsmiMedium.Name = "tsmiMedium";
      this.tsmiMedium.Size = new System.Drawing.Size(119, 22);
      this.tsmiMedium.Text = "Medium";
      this.tsmiMedium.Click += new System.EventHandler(this.tsmiMedium_Click);
      // 
      // tsmiSmall
      // 
      this.tsmiSmall.Name = "tsmiSmall";
      this.tsmiSmall.Size = new System.Drawing.Size(119, 22);
      this.tsmiSmall.Text = "Small";
      this.tsmiSmall.Click += new System.EventHandler(this.tsmiSmall_Click);
      // 
      // tsmiNone
      // 
      this.tsmiNone.Name = "tsmiNone";
      this.tsmiNone.Size = new System.Drawing.Size(119, 22);
      this.tsmiNone.Text = "None";
      this.tsmiNone.Click += new System.EventHandler(this.tsmiNone_Click);
      // 
      // TransferListUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tlpTL);
      this.DoubleBuffered = true;
      this.Name = "TransferListUserControl";
      this.Size = new System.Drawing.Size(703, 642);
      this.tlpTL.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.olvTL)).EndInit();
      this.flp.ResumeLayout(false);
      this.flp.PerformLayout();
      this.gbxPosition.ResumeLayout(false);
      this.gbxPosition.PerformLayout();
      this.cmsOlvTL.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tlpTL;
    private System.Windows.Forms.DateTimePicker dtpDeadline;
    private System.Windows.Forms.Label label50;
    private System.Windows.Forms.TextBox tbxPlayerId;
    private System.Windows.Forms.Label label52;
    private System.Windows.Forms.Button btnTLGet;
    private System.Windows.Forms.TextBox tbxPrice;
    private System.Windows.Forms.Label label51;
    private System.Windows.Forms.ContextMenuStrip cmsOlvTL;
    private System.Windows.Forms.ToolStripMenuItem cmsRemove;
    private EvaluatePlayerUserControl ucEvaluatePlayer;
    private System.Windows.Forms.FlowLayoutPanel flp;
    private System.Windows.Forms.GroupBox gbxPosition;
    private System.Windows.Forms.RadioButton rdC;
    private System.Windows.Forms.RadioButton rdPf;
    private System.Windows.Forms.RadioButton rdPg;
    private System.Windows.Forms.RadioButton rdSg;
    private System.Windows.Forms.RadioButton rdSf;
    private System.Windows.Forms.Button btnTLAdd;
    private BrightIdeasSoftware.ObjectListView olvTL;
    private System.Windows.Forms.ToolStripMenuItem cmsUpdate;
    private BasicPlayerUserControl ucBasicPlayerInfo;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lblServertime;
    private System.Windows.Forms.ToolStripMenuItem cmsImportance;
    private System.Windows.Forms.ToolStripMenuItem tsmiHigh;
    private System.Windows.Forms.ToolStripMenuItem tsmiMedium;
    private System.Windows.Forms.ToolStripMenuItem tsmiSmall;
    private System.Windows.Forms.ToolStripMenuItem tsmiNone;
  }
}
