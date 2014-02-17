namespace AndreiPopescu.CharazayPlus.UI
{
    using System.Windows.Forms;

    public partial class DivisionStandingsUserControl : UserControl
    {
        public DivisionStandingsUserControl()
        {
            InitializeComponent();
        }

        #region Populate DataGridViews
        void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Fills the object list view with the division full schedule on the 'My Division' tab
        /// </summary>
        public void Init(Xsd2.charazayDivision _myDivisionStandings)
        {
#if DOTNET30
      dgStandings.initGridPrologue();
      dgStandings.GenerateTextBoxColumn( "#", "position");
      dgStandings.GenerateLinkColumn( "Team", "Name", dg_CellContentClick);      
      dgStandings.GenerateTextBoxColumn( "Pld", "played");
      dgStandings.GenerateTextBoxColumn( "W", "wins");
      dgStandings.GenerateTextBoxColumn("L", "loss");
      dgStandings.GenerateTextBoxColumn("+", "points_made");
      dgStandings.GenerateTextBoxColumn("-", "points_against");
      dgStandings.GenerateTextBoxColumn("Pts", "points");
      dgStandings.GenerateTextBoxColumn("Owner", "owner");
      dgStandings.initGridEpilogue<Xsd2.charazayDivisionStanding>( _myDivisionStandings.standings);
#else
            DataGridExtensions.initGridPrologue(dgStandings);
            DataGridExtensions.GenerateTextBoxColumn(dgStandings, "#", "position");
            DataGridExtensions.GenerateLinkColumn(dgStandings, "Team", "Name", dg_CellContentClick);
            DataGridExtensions.GenerateTextBoxColumn(dgStandings, "Pld", "played");
            DataGridExtensions.GenerateTextBoxColumn(dgStandings, "W", "wins");
            DataGridExtensions.GenerateTextBoxColumn(dgStandings, "L", "loss");
            DataGridExtensions.GenerateTextBoxColumn(dgStandings, "+", "points_made");
            DataGridExtensions.GenerateTextBoxColumn(dgStandings, "-", "points_against");
            DataGridExtensions.GenerateTextBoxColumn(dgStandings, "Pts", "points");
            DataGridExtensions.GenerateTextBoxColumn(dgStandings, "Owner", "owner");
            DataGridExtensions.initGridEpilogue<Xsd2.charazayDivisionStanding>(dgStandings, _myDivisionStandings.standings);
#endif
        }

        #endregion

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
          this.dgStandings = new System.Windows.Forms.DataGridView();
          ((System.ComponentModel.ISupportInitialize)(this.dgStandings)).BeginInit();
          this.SuspendLayout();
          // 
          // dgStandings
          // 
          this.dgStandings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
          this.dgStandings.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
          this.dgStandings.BackgroundColor = System.Drawing.Color.DimGray;
          this.dgStandings.CausesValidation = false;
          this.dgStandings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
          this.dgStandings.Dock = System.Windows.Forms.DockStyle.Fill;
          this.dgStandings.GridColor = System.Drawing.Color.Silver;
          this.dgStandings.Location = new System.Drawing.Point(0, 0);
          this.dgStandings.Name = "dgStandings";
          this.dgStandings.Size = new System.Drawing.Size(457, 283);
          this.dgStandings.TabIndex = 3;
          // 
          // DivisionStandingsUserControl
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this.dgStandings);
          this.DoubleBuffered = true;
          this.ForeColor = System.Drawing.Color.White;
          this.Name = "DivisionStandingsUserControl";
          this.Size = new System.Drawing.Size(457, 283);
          ((System.ComponentModel.ISupportInitialize)(this.dgStandings)).EndInit();
          this.ResumeLayout(false);

        }

        #endregion

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgStandings;
    }
}
