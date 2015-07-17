namespace AndreiPopescu.CharazayPlus.UI
{
  partial class StatusUserControl
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
      this.olvStatus = new BrightIdeasSoftware.ObjectListView();
      this.olvcFullName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvAge = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcHeight = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcWeight = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvBmi = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcSI = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcSalary = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcForm = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcFame = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcFatigue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcInjured = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcInjuryDays = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcNt = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcNtU21 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcNtU18 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      ((System.ComponentModel.ISupportInitialize)(this.olvStatus)).BeginInit();
      this.SuspendLayout();
      // 
      // olvStatus
      // 
      this.olvStatus.AllColumns.Add(this.olvcFullName);
      this.olvStatus.AllColumns.Add(this.olvAge);
      this.olvStatus.AllColumns.Add(this.olvcHeight);
      this.olvStatus.AllColumns.Add(this.olvcWeight);
      this.olvStatus.AllColumns.Add(this.olvBmi);
      this.olvStatus.AllColumns.Add(this.olvcSI);
      this.olvStatus.AllColumns.Add(this.olvcSalary);
      this.olvStatus.AllColumns.Add(this.olvcForm);
      this.olvStatus.AllColumns.Add(this.olvcFame);
      this.olvStatus.AllColumns.Add(this.olvcFatigue);
      this.olvStatus.AllColumns.Add(this.olvcInjured);
      this.olvStatus.AllColumns.Add(this.olvcInjuryDays);
      this.olvStatus.AllColumns.Add(this.olvcNt);
      this.olvStatus.AllColumns.Add(this.olvcNtU21);
      this.olvStatus.AllColumns.Add(this.olvcNtU18);
      this.olvStatus.AllowColumnReorder = true;
      this.olvStatus.AlternateRowBackColor = System.Drawing.Color.DimGray;
      this.olvStatus.BackColor = System.Drawing.Color.Gray;
      this.olvStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcFullName,
            this.olvAge,
            this.olvcHeight,
            this.olvcWeight,
            this.olvBmi,
            this.olvcSI,
            this.olvcSalary,
            this.olvcForm,
            this.olvcFame,
            this.olvcFatigue,
            this.olvcInjured,
            this.olvcInjuryDays,
            this.olvcNt,
            this.olvcNtU21,
            this.olvcNtU18});
      this.olvStatus.Cursor = System.Windows.Forms.Cursors.Default;
      this.olvStatus.Dock = System.Windows.Forms.DockStyle.Fill;
      this.olvStatus.ForeColor = System.Drawing.Color.White;
      this.olvStatus.FullRowSelect = true;
      this.olvStatus.HeaderUsesThemes = false;
      this.olvStatus.HideSelection = false;
      this.olvStatus.Location = new System.Drawing.Point(0, 0);
      this.olvStatus.Name = "olvStatus";
      this.olvStatus.OwnerDraw = true;
      this.olvStatus.ShowItemToolTips = true;
      this.olvStatus.Size = new System.Drawing.Size(986, 416);
      this.olvStatus.SortGroupItemsByPrimaryColumn = false;
      this.olvStatus.TabIndex = 1;
      this.olvStatus.UseAlternatingBackColors = true;
      this.olvStatus.UseCompatibleStateImageBehavior = false;
      this.olvStatus.UseHotItem = true;
      this.olvStatus.UseHyperlinks = true;
      this.olvStatus.UseTranslucentHotItem = true;
      this.olvStatus.View = System.Windows.Forms.View.Details;
      this.olvStatus.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(this.olv_HyperlinkClicked);
      this.olvStatus.IsHyperlink += new System.EventHandler<BrightIdeasSoftware.IsHyperlinkEventArgs>(this.olv_IsHyperlink);
      // 
      // olvcFullName
      // 
      this.olvcFullName.AspectName = "FullName";
      this.olvcFullName.CellPadding = null;
      this.olvcFullName.Hyperlink = true;
      this.olvcFullName.MaximumWidth = 200;
      this.olvcFullName.MinimumWidth = 100;
      this.olvcFullName.Text = "Name";
      this.olvcFullName.ToolTipText = "Player full name";
      this.olvcFullName.UseInitialLetterForGroup = true;
      this.olvcFullName.Width = 160;
      this.olvcFullName.WordWrap = true;
      // 
      // olvAge
      // 
      this.olvAge.AspectName = "Age";
      this.olvAge.CellPadding = null;
      this.olvAge.MaximumWidth = 60;
      this.olvAge.MinimumWidth = 25;
      this.olvAge.Text = "Age";
      this.olvAge.Width = 40;
      // 
      // olvcHeight
      // 
      this.olvcHeight.AspectName = "Height";
      this.olvcHeight.CellPadding = null;
      this.olvcHeight.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.olvcHeight.MaximumWidth = 70;
      this.olvcHeight.MinimumWidth = 30;
      this.olvcHeight.Text = "Height";
      this.olvcHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.olvcHeight.Width = 50;
      // 
      // olvcWeight
      // 
      this.olvcWeight.AspectName = "Weight";
      this.olvcWeight.CellPadding = null;
      this.olvcWeight.MaximumWidth = 70;
      this.olvcWeight.MinimumWidth = 40;
      this.olvcWeight.Text = "Weight";
      this.olvcWeight.Width = 50;
      // 
      // olvBmi
      // 
      this.olvBmi.AspectName = "BMI";
      this.olvBmi.CellPadding = null;
      this.olvBmi.MaximumWidth = 60;
      this.olvBmi.MinimumWidth = 40;
      this.olvBmi.Text = "BMI";
      this.olvBmi.ToolTipText = "Body mass index";
      this.olvBmi.Width = 50;
      // 
      // olvcSI
      // 
      this.olvcSI.AspectName = "SkillsIndex";
      this.olvcSI.CellPadding = null;
      this.olvcSI.MaximumWidth = 80;
      this.olvcSI.MinimumWidth = 50;
      this.olvcSI.Text = "SI";
      this.olvcSI.ToolTipText = "Skills index";
      // 
      // olvcSalary
      // 
      this.olvcSalary.AspectName = "Salary";
      this.olvcSalary.CellPadding = null;
      this.olvcSalary.MaximumWidth = 65;
      this.olvcSalary.MinimumWidth = 45;
      this.olvcSalary.Text = "Salary";
      this.olvcSalary.Width = 55;
      // 
      // olvcForm
      // 
      this.olvcForm.AspectName = "Form";
      this.olvcForm.CellPadding = null;
      this.olvcForm.IsEditable = false;
      this.olvcForm.MaximumWidth = 150;
      this.olvcForm.MinimumWidth = 80;
      this.olvcForm.Text = "Form";
      this.olvcForm.ToolTipText = "Player form";
      this.olvcForm.Width = 110;
      // 
      // olvcFame
      // 
      this.olvcFame.AspectName = "Fame";
      this.olvcFame.CellPadding = null;
      this.olvcFame.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvcFame.MaximumWidth = 130;
      this.olvcFame.MinimumWidth = 50;
      this.olvcFame.Text = "Fame";
      this.olvcFame.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvcFame.Width = 120;
      // 
      // olvcFatigue
      // 
      this.olvcFatigue.AspectName = "Fatigue";
      this.olvcFatigue.CellPadding = null;
      this.olvcFatigue.IsEditable = false;
      this.olvcFatigue.MaximumWidth = 100;
      this.olvcFatigue.MinimumWidth = 50;
      this.olvcFatigue.Text = "Fatigue";
      this.olvcFatigue.Width = 70;
      // 
      // olvcInjured
      // 
      this.olvcInjured.AspectName = "Injury";
      this.olvcInjured.CellPadding = null;
      this.olvcInjured.CheckBoxes = true;
      this.olvcInjured.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvcInjured.IsHeaderVertical = true;
      this.olvcInjured.Text = "Injured?";
      this.olvcInjured.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvcInjured.Width = 40;
      // 
      // olvcInjuryDays
      // 
      this.olvcInjuryDays.AspectName = "InjuryDays";
      this.olvcInjuryDays.CellPadding = null;
      this.olvcInjuryDays.IsEditable = false;
      this.olvcInjuryDays.MaximumWidth = 50;
      this.olvcInjuryDays.MinimumWidth = 30;
      this.olvcInjuryDays.Text = "Injury Days";
      this.olvcInjuryDays.Width = 45;
      // 
      // olvcNt
      // 
      this.olvcNt.AspectName = "NT";
      this.olvcNt.CellPadding = null;
      this.olvcNt.CheckBoxes = true;
      this.olvcNt.IsEditable = false;
      this.olvcNt.IsHeaderVertical = true;
      this.olvcNt.Text = "NT?";
      this.olvcNt.Width = 40;
      // 
      // olvcNtU21
      // 
      this.olvcNtU21.AspectName = "U21NT";
      this.olvcNtU21.CellPadding = null;
      this.olvcNtU21.CheckBoxes = true;
      this.olvcNtU21.IsEditable = false;
      this.olvcNtU21.IsHeaderVertical = true;
      this.olvcNtU21.Text = "U21 NT?";
      this.olvcNtU21.ToolTipText = "under 21 national team member";
      this.olvcNtU21.Width = 40;
      // 
      // olvcNtU18
      // 
      this.olvcNtU18.AspectName = "U18NT";
      this.olvcNtU18.CellPadding = null;
      this.olvcNtU18.CheckBoxes = true;
      this.olvcNtU18.IsEditable = false;
      this.olvcNtU18.IsHeaderVertical = true;
      this.olvcNtU18.Text = "U18 NT?";
      this.olvcNtU18.ToolTipText = "under 18 national team member";
      this.olvcNtU18.Width = 40;
      // 
      // StatusUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.olvStatus);
      this.Name = "StatusUserControl";
      this.Size = new System.Drawing.Size(986, 416);
      ((System.ComponentModel.ISupportInitialize)(this.olvStatus)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private BrightIdeasSoftware.ObjectListView olvStatus;
    private BrightIdeasSoftware.OLVColumn olvcFullName;
    private BrightIdeasSoftware.OLVColumn olvAge;
    private BrightIdeasSoftware.OLVColumn olvcHeight;
    private BrightIdeasSoftware.OLVColumn olvcWeight;
    private BrightIdeasSoftware.OLVColumn olvBmi;
    private BrightIdeasSoftware.OLVColumn olvcSI;
    private BrightIdeasSoftware.OLVColumn olvcSalary;
    private BrightIdeasSoftware.OLVColumn olvcForm;
    private BrightIdeasSoftware.OLVColumn olvcFame;
    private BrightIdeasSoftware.OLVColumn olvcFatigue;
    private BrightIdeasSoftware.OLVColumn olvcInjured;
    private BrightIdeasSoftware.OLVColumn olvcInjuryDays;
    private BrightIdeasSoftware.OLVColumn olvcNt;
    private BrightIdeasSoftware.OLVColumn olvcNtU21;
    private BrightIdeasSoftware.OLVColumn olvcNtU18;
  }
}
