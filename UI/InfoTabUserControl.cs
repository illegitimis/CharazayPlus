
namespace AndreiPopescu.CharazayPlus.UI
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Drawing;
  using System.Data;
  using System.Text;
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


  }
}
