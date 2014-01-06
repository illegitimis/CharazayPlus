using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;
using AndreiPopescu.CharazayPlus.Utils;

namespace AndreiPopescu.CharazayPlus.UI
{
  public partial class StatusUserControl : UserControl
  {
    public StatusUserControl ( )
    {
      InitializeComponent();
    }

    /// <summary>
    /// 
    /// </summary>
    public void initStatus (IEnumerable<Player> _optimumPlayers)
    {
      //XmlServiceDownload();
      TypedObjectListView<Player> tlist = new TypedObjectListView<Player>(this.olvStatus);
      tlist.GenerateAspectGetters();

      // Name
      this.olvcFullName.ImageGetter = delegate(object row) { return (int)(((Player)row).CountryId - 1); };
      this.olvcFullName.GroupKeyGetter = delegate(object row) { return (int)(((Player)row).CountryId); };
      this.olvcFullName.GroupKeyToTitleConverter = delegate(object groupKey)
      {
        Country country = Defines.Countries[(int)groupKey];
        return string.Format("{0} (id={1})", country.Name, country.Id);
      };

      // Age
      this.olvAge.MakeGroupies(
        new byte[] { 17, 19, 22, 24, 26, 28, 30, 32, 35 }
      , new string[] { "< 17", "17-18", "19-21", "22-23", "24-25", "26-27", "28-29", "30-31", "32-34", "> 34" }
      );

      //height
      this.olvcHeight.MakeGroupies(
        new byte[] { 180, 185, 190, 195, 200, 205, 210, 215, 220 }
      , new string[] { "160-180", "180-185", "185-190", "190-195", "195-200", "200-205", "205-210", "210-215", "215-220", "220-230" }
      );

      // weight
      double[] weightMarkers = new double[] { 80d, 90d, 100d, 110d, 120d };
      this.olvcWeight.MakeGroupies(weightMarkers, ObjectListViewExtensions.BuildCustomGroupies<double>(weightMarkers));

      //bmi
      this.olvBmi.AspectToStringConverter = delegate(object val)
      {
        double bmi = (double)val;
        return string.Format("{0:F02}", bmi);
      };
      double[] bmiMarkers = new double[] { 21, 23, 25, 27 };
      this.olvBmi.MakeGroupies(bmiMarkers, ObjectListViewExtensions.BuildCustomGroupies<double>(bmiMarkers));

      //si
      ulong k = (ulong)Math.Pow(10, 3);
      ulong k10 = (ulong)Math.Pow(10, 4);
      ulong k100 = (ulong)Math.Pow(10, 5);

      ulong[] siMarkers = new ulong[] { k10, 2*k10, 35*k, 5*k10, 7*k10, 9*k10, 11*k10, 13*k10
        , 15*k10 , 175*k, 2*k100, 225*k, 25*k10, 275*k, 3*k100, 325*k, 35*k10, 4*k100, 5*k100, 6*k100
      };
      this.olvcSI.MakeGroupies(siMarkers, ObjectListViewExtensions.BuildCustomGroupies<ulong>(siMarkers));

      //salary
      ulong[] salaryMarkers = new ulong[] { k10, 2*k10, 3*k10, 4*k10, 6*k10, k100
        , 125*k, 15*k10 , 175*k, 2*k100, 225*k, 25*k10, 275*k, 3*k100, 35*k10, 4*k100
      };
      this.olvcSalary.MakeGroupies(salaryMarkers, ObjectListViewExtensions.BuildCustomGroupies<ulong>(salaryMarkers));

      // form     
      this.olvcForm.GroupKeyGetter = delegate(object row) { return (byte)(((Player)row).Form); };
      this.olvcForm.GroupKeyToTitleConverter = delegate(object groupKey)
      {
        return string.Format("{0} ({1})", (AndreiPopescu.CharazayPlus.Utils.Form)groupKey, (byte)groupKey);
      };
      this.olvcForm.Renderer = new MultiImageRenderer(Properties.Resources.star13, 8, 1, 8);

      // fame   
      this.olvcFame.GroupKeyGetter = delegate(object row) { return (byte)(((Player)row).Fame); };
      this.olvcFame.GroupKeyToTitleConverter = delegate(object groupKey)
      {
        return string.Format("{0} ({1})", (Fame)groupKey, (byte)groupKey);
      };
      this.olvcFame.Renderer = new MultiImageRenderer(Properties.Resources.star12, 10, 0, 11);

      //fatigue
      byte[] fatigueMarkers = new byte[] { 2, 5, 10, 15, 20, 30 };
      this.olvcFatigue.MakeGroupies(fatigueMarkers, ObjectListViewExtensions.BuildCustomGroupies<byte>(fatigueMarkers));
      this.olvcFatigue.Renderer = new BarTextRenderer(0, 100, new Pen(Color.Bisque), Color.GreenYellow, Color.Red);
      this.olvcFatigue.AspectGetter = (row) => { return ((Player)row).Fatigue; };
      this.olvcFatigue.AspectName = "Fatigue";
      //this.olvcFatigue.AspectToStringConverter = (row) => { return ((Player)row).Fatigue.ToString()+"%"; };
      this.olvcFatigue.AspectToStringFormat = "{0}%";

      // fill
      this.olvStatus.SetObjects(_optimumPlayers);
    }

    private void olv_IsHyperlink (object sender, IsHyperlinkEventArgs e)
    {
      //ObjectListView olv = (ObjectListView)sender;
      //if (olv.GetItemCount() == 0)
      //  return;

      //Player p = (Player)olv.SelectedObject;
      //if (p == null)
      //  return;

      //Web.CharazayDownoadItem playerLink = new Web.CharazayDownoadItem("player", 1, p.Id);
      //e.Url = playerLink.m_uri.AbsoluteUri;
    }

    private void olv_HyperlinkClicked (object sender, HyperlinkClickedEventArgs e)
    {
      //ObjectListViewItem olvi = (ObjectListViewItem)sender;
      //olvi
      //int ri = e.RowIndex;
      //e.Url

      Player p = (Player)e.Item.RowObject;
      if (p == null)
        return;

      Web.CharazayDownoadItem playerLink = new Web.CharazayDownoadItem("player", 1, p.Id);
      e.Url = playerLink.m_uri.AbsoluteUri;
    }
  }
}
