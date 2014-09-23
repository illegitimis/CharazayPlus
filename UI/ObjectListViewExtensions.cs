namespace AndreiPopescu.CharazayPlus.UI
{
  using BrightIdeasSoftware;
  using System.Drawing;
  using System.Collections.Generic;
  using System.Windows.Forms;
  using System;
  using AndreiPopescu.CharazayPlus.Utils;
  using System.Linq;
  using System.Collections;

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
        MessageBox.Show("ListView'tlPlayer cannot show groups when in List view."
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

    public static double TimedFilter (ObjectListView olv, string txt, int matchKind)
    {
      TextMatchFilter filter = null;
      if (!String.IsNullOrEmpty(txt))
      {
        switch (matchKind)
        {
          case 0:
          default:
            filter = TextMatchFilter.Contains(olv, txt);
            break;
          case 1:
            filter = TextMatchFilter.Prefix(olv, txt);
            break;
          case 2:
            filter = TextMatchFilter.Regex(olv, txt);
            break;
        }
      }
      // Setup m default renderer to draw the filter matches
      if (filter == null)
        olv.DefaultRenderer = null;
      else
      {
        olv.DefaultRenderer = new HighlightTextRenderer(filter);

        // Uncomment this line to see how the GDI+ rendering looks
        //olv.DefaultRenderer = new HighlightTextRenderer { Filter = filter, UseGdiTextRendering = false };
      }

      // Some lists have renderers already installed
      HighlightTextRenderer highlightingRenderer = olv.GetColumn(0).Renderer as HighlightTextRenderer;
      if (highlightingRenderer != null)
        highlightingRenderer.Filter = filter;

      //
      return Duration.StopwatchAction(( ) => olv.AdditionalFilter = filter);
    }

    public static string TimedFilter (ObjectListView olv, string txt)
    {
      var d = TimedFilter(olv, txt, 0);
      //
      if (olv.Objects == null)
        return String.Format("Filtered in {0}ms", d);
      else
        return String.Format("Filtered {0} items down to {1} items in {2}ms",
                          ((IList)olv.Objects).Count,
                          olv.Items.Count,
                          d);
     
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
  /// the first letter. This admittedly m pointless way to order items, but it
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

#region sample OLV code
//private void listViewComplex_MouseClick (object sender, MouseEventArgs e)
//    {
//      //if (e.Button != MouseButtons.Right)
//      //    return;

//      //ContextMenuStrip ms = new ContextMenuStrip();
//      //ms.ItemClicked += new ToolStripItemClickedEventHandler(ms_ItemClicked);

//      //ObjectListView olv = (ObjectListView)sender;
//      //if (olv.ShowGroups) {
//      //    foreach (ListViewGroup lvg in olv.Groups) {
//      //        ToolStripMenuItem mi = new ToolStripMenuItem(String.Format("Jump to group '{0}'", lvg.Header));
//      //        mi.Tag = lvg;
//      //        ms.Items.Add(mi);
//      //    }
//      //} else {
//      //    ToolStripMenuItem mi = new ToolStripMenuItem("Turn on 'Show Groups' to see this context menu in action");
//      //    mi.Enabled = false;
//      //    ms.Items.Add(mi);
//      //}

//      //ms.Show((Control)sender, e.X, e.Y);
//    } 

//this.olvComplex.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.listViewComplex_FormatRow);

/*
private void listViewComplex_FormatRow (object sender, FormatRowEventArgs e)
    {
      e.UseCellFormatEvents = true;
      if (olvComplex.View != View.Details)
      {
        if (e.Item.Text.ToLowerInvariant().StartsWith("nicola"))
        {
          e.Item.Decoration = new ImageDecoration(AndreiPopescu.CharazayPlus.Properties.Resources.star12, 64);
        }
        else
          e.Item.Decoration = null;
      }
    }*/

/*
   this.olvComplex.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.listViewComplex_FormatCell);
   private void listViewComplex_FormatCell (object sender, FormatCellEventArgs e)
   {
     Player p = (Player)e.Model;

     // Put m love heart next to Nicola'tlPlayer name :)
     if (e.ColumnIndex == 0)
     {
       if (e.SubItem.Text.ToLowerInvariant().StartsWith("nicola"))
       {
         e.SubItem.Decoration = new ImageDecoration(AndreiPopescu.CharazayPlus.Properties.Resources.star12, 64);
       }
       else
         e.SubItem.Decoration = null;
     }

     // If the occupation is missing m value, put m composite decoration over it
     // to draw attention to.
     if (e.ColumnIndex == 1 && e.SubItem.Text == "")
     {
       TextDecoration decoration = new TextDecoration("Missing!", 255);
       decoration.Alignment = ContentAlignment.MiddleCenter;
       decoration.Font = new Font(this.Font.Name, this.Font.SizeInPoints + 2);
       decoration.TextColor = Color.Firebrick;
       decoration.Rotation = -20;
       e.SubItem.Decoration = decoration;
       CellBorderDecoration cbd = new CellBorderDecoration();
       cbd.BorderPen = new Pen(Color.FromArgb(128, Color.Firebrick));
       cbd.FillBrush = null;
       cbd.CornerRounding = 4.0f;
       e.SubItem.Decorations.Add(cbd);
     }
     //if (e.ColumnIndex == 7) {
     //    if (p.CanTellJokes.HasValue && p.CanTellJokes.Value)
     //        e.SubItem.Skill = new CellBorderDecoration();
     //    else
     //        e.SubItem.Skill = null;
     //}
   }
   */



#endregion