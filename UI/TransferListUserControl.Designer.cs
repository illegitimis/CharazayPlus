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
      this.evaluatePlayerUC = new AndreiPopescu.CharazayPlus.UI.EvaluatePlayerUserControl();
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
      this.cmsOlvTL = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.cmsOlvTLRemove = new System.Windows.Forms.ToolStripMenuItem();
      this.tlpTL.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvTL)).BeginInit();
      this.flp.SuspendLayout();
      this.gbxPosition.SuspendLayout();
      this.cmsOlvTL.SuspendLayout();
      this.SuspendLayout();
      // 
      // tlpTL
      // 
      this.tlpTL.ColumnCount = 2;
      this.tlpTL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
      this.tlpTL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.33334F));
      this.tlpTL.Controls.Add(this.olvTL, 1, 1);
      this.tlpTL.Controls.Add(this.evaluatePlayerUC, 0, 0);
      this.tlpTL.Controls.Add(this.flp, 0, 1);
      this.tlpTL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tlpTL.Location = new System.Drawing.Point(0, 0);
      this.tlpTL.Name = "tlpTL";
      this.tlpTL.RowCount = 2;
      this.tlpTL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
      this.tlpTL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
      this.tlpTL.Size = new System.Drawing.Size(703, 642);
      this.tlpTL.TabIndex = 12;
      // 
      // olvTL
      // 
      this.olvTL.BackColor = System.Drawing.Color.Beige;
      this.olvTL.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
      this.olvTL.Cursor = System.Windows.Forms.Cursors.Default;
      this.olvTL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.olvTL.FullRowSelect = true;
      this.olvTL.HeaderUsesThemes = false;
      this.olvTL.HeaderWordWrap = true;
      this.olvTL.Location = new System.Drawing.Point(120, 195);
      this.olvTL.MinimumSize = new System.Drawing.Size(100, 100);
      this.olvTL.Name = "olvTL";
      this.olvTL.Size = new System.Drawing.Size(580, 444);
      this.olvTL.SortGroupItemsByPrimaryColumn = false;
      this.olvTL.TabIndex = 18;
      this.olvTL.UseCompatibleStateImageBehavior = false;
      this.olvTL.UseHyperlinks = true;
      this.olvTL.View = System.Windows.Forms.View.Details;
      this.olvTL.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.olvTL_CellEditFinishing);
      this.olvTL.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.olvTL_CellEditStarting);
      this.olvTL.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.olvTL_CellRightClick);
      this.olvTL.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(this.olvTL_HyperlinkClicked);
      this.olvTL.IsHyperlink += new System.EventHandler<BrightIdeasSoftware.IsHyperlinkEventArgs>(this.olvTL_IsHyperlink);
      this.olvTL.SelectionChanged += new System.EventHandler(this.olvTL_SelectionChanged);
      this.olvTL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.olvTL_KeyDown);
      // 
      // evaluatePlayerUC
      // 
      this.evaluatePlayerUC.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.evaluatePlayerUC.BackColor = System.Drawing.Color.DimGray;
      this.evaluatePlayerUC.CausesValidation = false;
      this.tlpTL.SetColumnSpan(this.evaluatePlayerUC, 2);
      this.evaluatePlayerUC.Dock = System.Windows.Forms.DockStyle.Fill;
      this.evaluatePlayerUC.ForeColor = System.Drawing.Color.White;
      this.evaluatePlayerUC.Location = new System.Drawing.Point(3, 3);
      this.evaluatePlayerUC.Name = "evaluatePlayerUC";
      this.evaluatePlayerUC.SelectedObject = null;
      this.evaluatePlayerUC.Size = new System.Drawing.Size(697, 186);
      this.evaluatePlayerUC.TabIndex = 16;
      // 
      // flp
      // 
      this.flp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.flp.Controls.Add(this.label50);
      this.flp.Controls.Add(this.tbxPlayerId);
      this.flp.Controls.Add(this.btnTLGet);
      this.flp.Controls.Add(this.label51);
      this.flp.Controls.Add(this.tbxPrice);
      this.flp.Controls.Add(this.label52);
      this.flp.Controls.Add(this.dtpDeadline);
      this.flp.Controls.Add(this.gbxPosition);
      this.flp.Controls.Add(this.btnTLAdd);
      this.flp.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.flp.Location = new System.Drawing.Point(3, 195);
      this.flp.Name = "flp";
      this.flp.Size = new System.Drawing.Size(111, 444);
      this.flp.TabIndex = 17;
      // 
      // label50
      // 
      this.label50.AutoSize = true;
      this.label50.Location = new System.Drawing.Point(3, 0);
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
      this.tbxPlayerId.Location = new System.Drawing.Point(3, 16);
      this.tbxPlayerId.Name = "tbxPlayerId";
      this.tbxPlayerId.Size = new System.Drawing.Size(108, 20);
      this.tbxPlayerId.TabIndex = 1;
      // 
      // btnTLGet
      // 
      this.btnTLGet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnTLGet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.btnTLGet.Location = new System.Drawing.Point(3, 42);
      this.btnTLGet.Name = "btnTLGet";
      this.btnTLGet.Size = new System.Drawing.Size(108, 53);
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
      this.label51.Location = new System.Drawing.Point(3, 98);
      this.label51.Name = "label51";
      this.label51.Size = new System.Drawing.Size(108, 13);
      this.label51.TabIndex = 5;
      this.label51.Text = "Price";
      // 
      // tbxPrice
      // 
      this.tbxPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxPrice.Location = new System.Drawing.Point(3, 114);
      this.tbxPrice.Name = "tbxPrice";
      this.tbxPrice.Size = new System.Drawing.Size(108, 20);
      this.tbxPrice.TabIndex = 6;
      // 
      // label52
      // 
      this.label52.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label52.AutoSize = true;
      this.label52.Location = new System.Drawing.Point(3, 137);
      this.label52.Name = "label52";
      this.label52.Size = new System.Drawing.Size(108, 13);
      this.label52.TabIndex = 7;
      this.label52.Text = "Deadline";
      // 
      // dtpDeadline
      // 
      this.dtpDeadline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dtpDeadline.CustomFormat = "yyyy-MM-dd HH:mm";
      this.dtpDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpDeadline.Location = new System.Drawing.Point(3, 153);
      this.dtpDeadline.Name = "dtpDeadline";
      this.dtpDeadline.ShowUpDown = true;
      this.dtpDeadline.Size = new System.Drawing.Size(108, 20);
      this.dtpDeadline.TabIndex = 8;
      // 
      // gbxPosition
      // 
      this.gbxPosition.Controls.Add(this.rdC);
      this.gbxPosition.Controls.Add(this.rdPf);
      this.gbxPosition.Controls.Add(this.rdPg);
      this.gbxPosition.Controls.Add(this.rdSg);
      this.gbxPosition.Controls.Add(this.rdSf);
      this.gbxPosition.Dock = System.Windows.Forms.DockStyle.Top;
      this.gbxPosition.Location = new System.Drawing.Point(3, 179);
      this.gbxPosition.Name = "gbxPosition";
      this.gbxPosition.Size = new System.Drawing.Size(108, 128);
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
      this.rdC.Size = new System.Drawing.Size(32, 17);
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
      this.rdPf.Size = new System.Drawing.Size(38, 17);
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
      this.rdPg.Size = new System.Drawing.Size(40, 17);
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
      this.rdSg.Size = new System.Drawing.Size(40, 17);
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
      this.rdSf.Size = new System.Drawing.Size(38, 17);
      this.rdSf.TabIndex = 2;
      this.rdSf.TabStop = true;
      this.rdSf.Text = "SF";
      this.rdSf.UseVisualStyleBackColor = true;
      this.rdSf.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
      // 
      // btnTLAdd
      // 
      this.btnTLAdd.Enabled = false;
      this.btnTLAdd.Location = new System.Drawing.Point(3, 313);
      this.btnTLAdd.Name = "btnTLAdd";
      this.btnTLAdd.Size = new System.Drawing.Size(108, 52);
      this.btnTLAdd.TabIndex = 16;
      this.btnTLAdd.Text = "Add to List";
      this.btnTLAdd.UseVisualStyleBackColor = true;
      this.btnTLAdd.Click += new System.EventHandler(this.btnTLAdd_Click);
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
    private System.Windows.Forms.ToolStripMenuItem cmsOlvTLRemove;
    private EvaluatePlayerUserControl evaluatePlayerUC;
    private System.Windows.Forms.FlowLayoutPanel flp;
    private System.Windows.Forms.GroupBox gbxPosition;
    private System.Windows.Forms.RadioButton rdC;
    private System.Windows.Forms.RadioButton rdPf;
    private System.Windows.Forms.RadioButton rdPg;
    private System.Windows.Forms.RadioButton rdSg;
    private System.Windows.Forms.RadioButton rdSf;
    private System.Windows.Forms.Button btnTLAdd;
    private BrightIdeasSoftware.ObjectListView olvTL;
  }
}
