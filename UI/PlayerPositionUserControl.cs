
namespace AndreiPopescu.CharazayPlus.UI
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Drawing;
  using System.Data;
  using System.Text;
  using System.Windows.Forms;
  using BrightIdeasSoftware;
  using AndreiPopescu.CharazayPlus.Utils;

  public partial class PlayerPositionUserControl : UserControl
  {
    public PlayerPositionUserControl ( )
    {
      InitializeComponent();
    }

    /// <summary>
    /// Position based list customizer
    /// </summary>
    /// <typeparam name="T">player type</typeparam>
    /// <param name="olv">object list view</param>
    /// <param name="players">player derived collection</param>
    private void initOLV<T> (ObjectListView olv, List<T> players)
      where T : Player
    {
      Generator.GenerateColumns(olv, players);
      olv.HeaderUsesThemes = false;

      double[] scoreMarkers = new double[] { 6, 8, 10, 12, 14, 16 };
      string[] descriptions = ObjectListViewExtensions.BuildCustomGroupies<double>(scoreMarkers);

      foreach (OLVColumn col in olv.Columns)
      {
        col.IsHeaderVertical = true;
        //col.MaximumWidth = 80;
        //col.MinimumWidth = 40;
        //col.Width = 65;

        string tag = col.Tag as string;
        if (!tag.Contains(/*Custom.TagPosition*/ "Position"))
          col.IsVisible = false;

        switch (col.DisplayIndex)
        {
          case 0:
            {
              //col.MaximumWidth = 200;
              //col.MinimumWidth = 100;
              //col.Width = 130;


              col.GroupKeyGetter = delegate(object row) { return ((T)row).HeightForPosition; };
              col.GroupKeyToTitleConverter = delegate(object groupKey)
              {
                PositionHeight adequacy = (PositionHeight)groupKey;
                if (adequacy == PositionHeight.Adequate)
                {
                  return string.Format("{0} [{1} - {2}]", adequacy, players[0].MinimumHeight, players[0].MaximumHeight);
                }
                else
                  return adequacy.ToString();
              };

            } break;

          default:
            {
              //col.AspectToStringFormat = "{0:F02}";
              col.MakeGroupies(scoreMarkers, descriptions);
            } break;
        }
      }
      olv.RebuildColumns();

      // either call works
      olv.SetObjects(players);
    }

    public void Init<T> (List<T> players) where T : Player
    {
      initOLV<T>(this.olv, players);
    }

  }
}
