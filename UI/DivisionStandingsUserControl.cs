using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AndreiPopescu.CharazayPlus.UI
{
  public partial class DivisionStandingsUserControl : UserControl
  {
    public DivisionStandingsUserControl ( )
    {
      InitializeComponent();
    }

    #region Populate DataGridViews
    void dg_CellContentClick (object sender, DataGridViewCellEventArgs e)
    {
      //throw new NotImplementedException();
    }

    /// <summary>
    /// Fills the object list view with the division full schedule on the 'My Division' tab
    /// </summary>
    public void Init (Xsd2.charazayDivision _myDivisionStandings)
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
  }
}
