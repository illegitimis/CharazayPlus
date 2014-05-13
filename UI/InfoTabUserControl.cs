/* InfoTabUserControl
 * custom UserControl for the Info tab
 * Changelog:
 * v1.1.1.0
 * removed DataGrid, added ObjectListView
 * removed separate designer file
 */

namespace AndreiPopescu.CharazayPlus.UI
{
  using System.Windows.Forms;

  public partial class InfoTabUserControl : UserControl
  {
    public InfoTabUserControl ( )
    {
      InitializeComponent();
    }

    public object SelectedGridObject { set { this.propGridInfo.SelectedObject = value; } } 
    
    public void DataContext (object sbl)
    {
      dgDivisionList.DataSource = sbl;
      dgDivisionList.Columns["countryid"].Visible = false;
      dgDivisionList.AllowUserToOrderColumns = true;
    }

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
      this.splitContainer3 = new System.Windows.Forms.SplitContainer();
      this.propGridInfo = new System.Windows.Forms.PropertyGrid();
      this.dgDivisionList = new System.Windows.Forms.DataGridView();
      this.label53 = new System.Windows.Forms.Label();
      this.splitContainer3.Panel1.SuspendLayout();
      this.splitContainer3.Panel2.SuspendLayout();
      this.splitContainer3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgDivisionList)).BeginInit();
      this.SuspendLayout();
      // 
      // splitContainer3
      // 
      this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer3.Location = new System.Drawing.Point(0, 0);
      this.splitContainer3.Name = "splitContainer3";
      // 
      // splitContainer3.Panel1
      // 
      this.splitContainer3.Panel1.Controls.Add(this.propGridInfo);
      // 
      // splitContainer3.Panel2
      // 
      this.splitContainer3.Panel2.Controls.Add(this.dgDivisionList);
      this.splitContainer3.Panel2.Controls.Add(this.label53);
      this.splitContainer3.Size = new System.Drawing.Size(804, 475);
      this.splitContainer3.SplitterDistance = 371;
      this.splitContainer3.TabIndex = 4;
      // 
      // propGridInfo
      // 
      this.propGridInfo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.propGridInfo.Location = new System.Drawing.Point(0, 0);
      this.propGridInfo.Name = "propGridInfo";
      this.propGridInfo.Size = new System.Drawing.Size(371, 475);
      this.propGridInfo.TabIndex = 0;
      this.propGridInfo.CommandsVisibleIfAvailable = true;
      // 
      // dgDivisionList
      // 
      this.dgDivisionList.AllowUserToAddRows = false;
      this.dgDivisionList.AllowUserToDeleteRows = false;
      this.dgDivisionList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgDivisionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgDivisionList.Location = new System.Drawing.Point(6, 16);
      this.dgDivisionList.Name = "dgDivisionList";
      this.dgDivisionList.ReadOnly = true;
      this.dgDivisionList.Size = new System.Drawing.Size(420, 456);
      this.dgDivisionList.TabIndex = 1;
      // 
      // label53
      // 
      this.label53.AutoSize = true;
      this.label53.Location = new System.Drawing.Point(3, 0);
      this.label53.Name = "label53";
      this.label53.Size = new System.Drawing.Size(102, 13);
      this.label53.TabIndex = 2;
      this.label53.Text = "Country Division List";
      // 
      // InfoTabUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitContainer3);
      this.Name = "InfoTabUserControl";
      this.Size = new System.Drawing.Size(804, 475);
      this.splitContainer3.Panel1.ResumeLayout(false);
      this.splitContainer3.Panel2.ResumeLayout(false);
      this.splitContainer3.Panel2.PerformLayout();
      this.splitContainer3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgDivisionList)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer3;
    private System.Windows.Forms.PropertyGrid propGridInfo;
    private System.Windows.Forms.DataGridView dgDivisionList;
    private System.Windows.Forms.Label label53;
  }
}
