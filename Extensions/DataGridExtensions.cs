

namespace AndreiPopescu.CharazayPlus.Extensions
{
  using System;
  using System.Collections.Generic;
  using System.Text;
  using System.Windows.Forms;
  using System.Drawing; 

  public static class DataGridExtensions
  {
    #region DataGridView initialization helpers
#if DOTNET30
    public static void initGridPrologue (this DataGridView dgv)
#else
    public static void initGridPrologue (DataGridView dgv)
#endif    
    {
      dgv.Columns.Clear();
      dgv.AutoGenerateColumns = false;
    }

#if DOTNET30
     public static void initGridEpilogue<T> (this DataGridView dgv, T[] xsd2Array)
#else
    public static void initGridEpilogue<T> (DataGridView dgv, T[] xsd2Array)
#endif   
    {
      dgv.DataSource = new AndreiPopescu.CharazayPlus.Utils.SortableBindingList<T>(xsd2Array);
      //dgv.AutoSize = true;
      dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
    }

    //private void initGridEpilogue<T>(DataGridView dgv, T[] xsd2Array, bool find)
    //{
    //  FilteredBindingList <T> ssbl =
    //    new FilteredBindingList<T>();

    //  foreach (T m in xsd2Array)
    //    ssbl.Add(m);

    //  //BindingSource bs = new BindingSource ();
    //  //bs.DataSource = ssbl;
    //  //bs.Filter = "round=0";
    //  //bs.Sort = "MatchType DESC";
    //  //dgv.DataSource = bs;

    //  //ssbl.Filter = "round=0";
    //  ssbl.Filter = "played='yes'";

    //  dgv.DataSource = ssbl;

    //  //dgv.AutoSize = true;
    //  dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

    //  //int i = ssbl.Find("played", "yes");


    //}

#if DOTNET30
    public static void GenerateTextBoxColumn (this DataGridView dg, string name, string property)
#else
    public static void GenerateTextBoxColumn (DataGridView dg, string name, string property)
#endif    
    {
      DataGridViewColumn column = new DataGridViewTextBoxColumn();
      column.DataPropertyName = property;
      column.Name = name;
      dg.Columns.Add(column);
    }

#if DOTNET30
    public static void GenerateLinkColumn (this DataGridView dgv, string name, string property)
#else
    public static void GenerateLinkColumn (DataGridView dgv, string name, string property)
#endif
    
    {
      GenerateLinkColumn(dgv, name, property, null);
    }

    //private void GenerateLinkColumn(DataGridView dgv, string name, string property, Delegate _CellContentClick)
#if DOTNET30
    public static void GenerateLinkColumn (this DataGridView dgv, string name, string property, DataGridViewCellEventHandler _CellContentClick)
#else
    public static void GenerateLinkColumn (DataGridView dgv, string name, string property, DataGridViewCellEventHandler _CellContentClick)
#endif
    
    {
      DataGridViewLinkColumn column2 = new DataGridViewLinkColumn();
      column2.DataPropertyName = property;
      column2.Name = name;
      column2.ActiveLinkColor = Color.White;
      column2.LinkBehavior = LinkBehavior.SystemDefault;
      column2.LinkColor = Color.Blue;
      column2.TrackVisitedState = true;

      if (_CellContentClick != null)
        dgv.CellContentClick += new DataGridViewCellEventHandler(_CellContentClick);

      dgv.Columns.Add(column2);
    }
    #endregion
  }
}
