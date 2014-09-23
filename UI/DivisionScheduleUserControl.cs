

namespace AndreiPopescu.CharazayPlus.UI
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Drawing;
  using System.Data;
  using System.Text;
  using System.Windows.Forms;
  using AndreiPopescu.CharazayPlus.Utils;
  using System.IO;
  using System.Xml.Serialization;
  using System.Linq;

  public partial class DivisionScheduleUserControl : UserControl
  {
    public DivisionScheduleUserControl ( )
    {
      InitializeComponent();
    }

    public void InitOLV (Xsd2.charazayRound[] _myDivisionFullSchedule)
    {
      //olvcMd.AspectGetter = delegate(object row) { return (uint)(((Xsd2.charazayRound)row).match.id); };
      olvcMd.AspectGetter = delegate(object row) { return (Xsd2.charazayRoundMatch)(((Xsd2.charazayRound)row).match); };
      olvcMd.GroupKeyGetter = delegate(object o)
      {
        Xsd2.charazayRound round = (Xsd2.charazayRound)o;
        return string.Format("Round: {0:D02} {1:yyyy-MMMM-dd}", round.number
          , AndreiPopescu.CharazayPlus.Utils.Compute.EstimatedDateTime(round.date));
      };
      //this.olvcFullName.GroupKeyToTitleConverter = delegate(object groupKey)
      //{
      //  Country country = Defines.Countries[(int)groupKey];
      //  return string.Format("{0} (id={1})", country.Name, country.Id);
      //};
      olvMd.SetObjects(_myDivisionFullSchedule);
    }


    //private void olvMd_Click(object sender, EventArgs e)
    //{
    //  ObjectListView olv = sender as ObjectListView;
    //  uint mid = ((Xsd2.charazayRound)olv.SelectedObject).match.id;
    //}

    //private void olvMd_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    //{
    //  if (e.IsSelected)
    //  {
    //    ListViewItem li = e.Item;
    //    int i = e.ItemIndex;
    //  }
    //}

    private void olvMd_SelectionChanged (object sender, EventArgs e)
    {
      if (olvMd.SelectedObjects == null || olvMd.SelectedObjects.Count == 0)
        return;
      var v = olvMd.SelectedObjects[0] as Xsd2.charazayRound;
      if (v == null)
        return;

      MatchRating(v.match.id);
    }

    private void MatchRating (uint matchId)
    {
     
        try
        {
          var SelectedMatch = Utils.Deserializer.GoGetMatchXml ((ulong)matchId);
          //
          ucMatchDetails.SetData(SelectedMatch);
          ucrHome.RatingType = UI.RatingType.Home;
          ucrHome.SetData(SelectedMatch.stats.home, SelectedMatch.bballs.home);
          ucrAway.RatingType = UI.RatingType.Away;
          ucrAway.SetData(SelectedMatch.stats.away, SelectedMatch.bballs.away);
          ucLineup.SetData(SelectedMatch.lineup);
          //
          CacheManager.Instance.AddMatch(SelectedMatch);

        }
        catch (Exception ex)
        {
          System.Diagnostics.Debug.Write(ex.Message);
        }
      }
    

  
  }
}
