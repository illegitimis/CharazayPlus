namespace AndreiPopescu.CharazayPlus.UI
{
  using BrightIdeasSoftware;
  using System.Drawing;
  using System.Collections.Generic;
  using System.Windows.Forms;
  using System;

  public static class ObjectListViewExtensions
  {
    /// <summary>
    /// USED by <see cref="HotItemOverlay"/>
    /// </summary>
    /// <param name="olv"></param>
    /// <param name="hotItemMode"></param>
    /// <param name="bFullRowSelect"></param>
    /// <param name="bExplorerTheme"></param>
    public static void ChangeHotItemStyle (ObjectListView olv
      , HotItemMode hotItemMode
      , bool bFullRowSelect=true
      , bool bExplorerTheme = true
      )
    {

      olv.UseTranslucentHotItem = false;                                                              
      olv.UseHotItem = true;
      olv.FullRowSelect = bFullRowSelect; // olvComplex should be full row select
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
            if (bExplorerTheme)
              ChangeOwnerDrawn(olv, false);
          }
          break;
      }
      olv.Invalidate();
    }

    /// <summary>
    /// used by <see cref="ChangeHotItemStyle"/>
    /// </summary>
    /// <param name="listview"></param>
    /// <param name="value"></param>
    public static void ChangeOwnerDrawn (ObjectListView listview, bool value)
    {
      listview.OwnerDraw = value;
      listview.BuildList();
    }

    /// <summary>
    /// derive group names from markers
    /// </summary>
    /// <typeparam name="T">value array type</typeparam>
    /// <param name="values">array of special group markers</param>
    public static string[] BuildCustomGroupies<T> (T[] values)
    {
      List<string> groupKeys = new List<string>(values.Length + 1);
      groupKeys.Add(string.Format("< {0}", values[0]));

      for (int i = 0; i < values.Length - 1; i++)
      {
        groupKeys.Add(string.Format("[{0} - {1})", values[i], values[i + 1]));
      }

      groupKeys.Add(string.Format("> {0}", values[values.Length - 1]));

      return groupKeys.ToArray();
    }

    public static void HotItemOverlay (ObjectListView olvComplex,  IOverlay overlay)
    {
      ChangeHotItemStyle(olvComplex, HotItemMode.Translucent);

      // Make the hot item show an overlay when it changes
      if (olvComplex.UseTranslucentHotItem)
      {
        olvComplex.HotItemStyle.Overlay = overlay;
        // very silly but this removes the old and adds the new overlay
        olvComplex.HotItemStyle = olvComplex.HotItemStyle;
      }
      //
      olvComplex.UseTranslucentSelection = olvComplex.UseTranslucentHotItem;
      //
      olvComplex.Invalidate();
    }

    public static void ShowGroups (ObjectListView olv, bool active)
    {
      if (active && olv.View == View.List)
      {
        MessageBox.Show("ListView's cannot show groups when in List view."
          , "CharazayPlus", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      else
      {
        olv.ShowGroups = active;
        olv.BuildList();
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="olv"></param>
    /// <param name="active"></param>
    public static void ShowLabelsOnGroups (ObjectListView olv, bool active)
    {
      olv.ShowItemCountOnGroups = active;
      if (olv.ShowGroups)
        olv.BuildGroups();
    }

    public static void ChangeEditable (ObjectListView olv, string text)
    {
      if (text == "No")
        olv.CellEditActivation = ObjectListView.CellEditActivateMode.None;
      else if (text == "Single Click")
        olv.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClick;
      else if (text == "Double Click")
        olv.CellEditActivation = ObjectListView.CellEditActivateMode.DoubleClick;
      else
        olv.CellEditActivation = ObjectListView.CellEditActivateMode.F2Only;
    }
  }

  public enum HotItemMode
  {
    // 0-none(NO)
    None
    ,
    //1-text color (cool)
    TextColor
    ,
    //2-border - cool ptr lista de jucatori, echipa proprie  
    Border
    ,
    //3-translucent - misto ptr skills tasb
    Translucent
    ,
    //4-lightbox - fundal gri
    Lightbox
    ,
    //5-vista (NO)
    Vista,
    
  }

  /// <summary>
  /// This comparer sort groups alphabetically by their header, BUT ignoring the first letter
  /// </summary>
  public class StrangeGroupComparer : IComparer<OLVGroup>
  {
    public StrangeGroupComparer (SortOrder order)
    {
      this.sortOrder = order;
    }

    public int Compare (OLVGroup x, OLVGroup y)
    {

      string xValue = x.Header;
      string yValue = y.Header;

      if (xValue.Length >= 2)
        xValue = xValue.Substring(1);
      if (yValue.Length >= 2)
        yValue = yValue.Substring(1);

      int result = String.Compare(xValue, yValue, StringComparison.CurrentCultureIgnoreCase);

      if (this.sortOrder == SortOrder.Descending)
        result = 0 - result;

      return result;
    }

    private SortOrder sortOrder;
  }

  /// <summary>
  /// StrangeItemComparer is an example of how to customize the ordering of items
  /// within groups. It orders items by their text representation but ignoring
  /// the first letter. This admittedly a pointless way to order items, but it
  /// is simply an example.
  /// </summary>
  public class StrangeItemComparer : IComparer<OLVListItem>
  {
    public StrangeItemComparer (OLVColumn col, SortOrder order)
    {
      this.column = col;
      this.sortOrder = order;
    }

    public int Compare (OLVListItem x, OLVListItem y)
    {

      string xValue = this.column.GetStringValue(x.RowObject);
      string yValue = this.column.GetStringValue(y.RowObject);

      if (xValue.Length >= 2)
        xValue = xValue.Substring(1);
      if (yValue.Length >= 2)
        yValue = yValue.Substring(1);

      int result = String.Compare(xValue, yValue, StringComparison.CurrentCultureIgnoreCase);

      if (this.sortOrder == SortOrder.Descending)
        result = 0 - result;

      return result;
    }

    private OLVColumn column;
    private SortOrder sortOrder;
  }



}
