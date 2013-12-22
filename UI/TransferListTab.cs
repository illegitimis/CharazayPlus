namespace AndreiPopescu.CharazayPlus
{
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Drawing;
  using System.Windows.Forms;
  using System.Xml.Serialization;
  using System.IO;
  using BrightIdeasSoftware;
  using AndreiPopescu.CharazayPlus.Utils;

  public partial class MainForm : System.Windows.Forms.Form
  {
    #region //-- Transfer List

    readonly IDictionary<TLPlayer,Xsd2.charazayPlayer> _mapTL = new Dictionary<TLPlayer, Xsd2.charazayPlayer>();

    /// <summary>
    /// adds the property grid player to the olvTL list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnTLAdd_Click (object sender, EventArgs e)
    {
      //TransferListedPlayerPropertyGridObject obj =
      //  (TransferListedPlayerPropertyGridObject)propGridTL.SelectedObject;
      
      //
      PlayerPosition pos = PlayerPosition.Unknown;
      if (rdC.Checked) pos = PlayerPosition.C;
      else if (rdPf.Checked) pos = PlayerPosition.PF;
      else if (rdPg.Checked) pos = PlayerPosition.PG;
      else if (rdSf.Checked) pos = PlayerPosition.SF;
      else if (rdSg.Checked) pos = PlayerPosition.SG;
      else pos = PlayerPosition.Unknown;
      Player basePlayer = evaluatePlayerUC.GetPlayer(pos);
      //     
      TLPlayer tlp = new TLPlayer();
      if (basePlayer != null)
      {
        //tlp.Date = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
        tlp.Deadline = dtpDeadline.Value.ToString("yyyy/MM/dd HH:mm");
        tlp.Def = (decimal)basePlayer.DefensiveScore;
        tlp.Name = basePlayer.FullName;
        tlp.OfAb = (decimal)basePlayer.OffensiveAbilityScore;
        tlp.Off = (decimal)basePlayer.OffensiveScore;
        tlp.Position = Enum.GetName(typeof(PlayerPosition), pos);
        tlp.Price = string.IsNullOrEmpty(tbxPrice.Text) ? (uint)Math.Pow(10, 6) : uint.Parse(tbxPrice.Text);
        tlp.ValueIndex = (decimal)basePlayer.ValueIndex;
        tlp.Profitability = (decimal)basePlayer.Profitability((double)tlp.Price);
        tlp.Reb = (decimal)basePlayer.ReboundScore;
        tlp.RebO = (decimal)basePlayer.OffensiveReboundsScore;
        tlp.RebD = (decimal)basePlayer.DefensiveReboundsScore;
        tlp.Shoot = (decimal)basePlayer.ShootingScore;
        tlp.Total = (decimal)basePlayer.TotalScore;
        
        olvTL.AddObject(tlp);
      }
      if (!_mapTL.ContainsKey(tlp))
        _mapTL.Add(tlp, basePlayer.BasePlayer);
    }
    
    /// <summary>
    /// serialize the transfer listed players that have been evaluated 
    /// </summary>
    private void SerializePlayersTL ( )
    {
      string tlFile = Web.XmlDownloadItem.Category2FileName(Web.Category.MyPlayersTL);
      FileStream fs = new FileStream(tlFile, FileMode.Truncate, FileAccess.Write);

      XmlSerializer serializer = new XmlSerializer(typeof(TLPlayers));
      TLPlayers tlps = new TLPlayers();

      ArrayList arl = olvTL.Objects as ArrayList;
      if (arl != null)
      {
        object o = arl.ToArray(typeof(TLPlayer));
        tlps.TLPlayer = (TLPlayer[])o;
      }
      else
      {
        tlps.TLPlayer = (TLPlayer[])olvTL.Objects;
      }

      serializer.Serialize(fs, tlps);

      fs.Close();
    }

    /// <summary>
    /// download player data from charazay
    /// and fills evaluate player user control
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnTLGet_Click (object sender, EventArgs e)
    {
      ulong playerId;
      if (ulong.TryParse(tbxPlayerId.Text, out playerId))
      {
        Web.Downloader crawler = new Web.Downloader();
        Web.PlayerXml xmlPlayer = new Web.PlayerXml(_wsu, playerId);
        crawler.Add(xmlPlayer);
        crawler.Get(true);

        //btnTLGet.Enabled = true;

        FileStream fs = null;
        Xsd2.charazay obj = null;
        try
        {
          fs = new FileStream(xmlPlayer.m_fileName, FileMode.Open, FileAccess.ReadWrite);
          obj = (Xsd2.charazay)(new XmlSerializer(typeof(Xsd2.charazay)).Deserialize(fs));
        }
        catch (Exception ex) {
          if (ex is InvalidOperationException && ex.InnerException != null && ex.InnerException is FormatException)
          {
            string m = ex.Message.Replace("There is an error in XML document", "");
            string [] tokens = m.Split(new char[] {' ', '(', ')', ','}, StringSplitOptions.RemoveEmptyEntries);
            //System.InvalidOperationException was unhandled
            //Message=There is an error in XML document (3, 126).
            //InnerException: System.FormatException
            //Message=Input string was not in a correct format.
            long errPos = long.Parse(tokens[1]);
            fs.Seek(errPos+8, SeekOrigin.Begin);
            fs.WriteByte(0);
          }
        }
        finally
        {
          fs.Close();
        }
        if (xmlPlayer.DeserializationType != Web.XmlSerializationType.Player)
          throw new Exception("Web.XmlSerializationType.Player");

        //propGridTL.SelectedObject = new TransferListedPlayerPropertyGridObject(obj.player);
        if (obj != null)
          this.evaluatePlayerUC.SelectedObject = obj.player;
      }
      else
      {
        //btnTLGet.Enabled = false;
      }
    }

    #endregion

    private void MainForm_FormClosing (object sender, FormClosingEventArgs e)
    {
      SerializePlayersTL();
      GC.WaitForPendingFinalizers();
    }

    private void olvTL_BeforeSorting (object sender, BeforeSortingEventArgs e)
    {
      ObjectListView olv = sender as ObjectListView;
      if (olv == null)
        olv = olvTL;
      olv.ShowGroups = (e.ColumnToGroupBy.Text != "ValueIndex");
    }

    /// <summary>
    /// initializes the olvTL object list view with bookmarked players 
    /// </summary>
    private void initTransferShortList ( )
    {
      try
      {
        //
        // data source
        //
        string tlFile = Web.XmlDownloadItem.Category2FileName(Web.Category.MyPlayersTL);
        FileStream fs = new FileStream(tlFile, FileMode.Open, FileAccess.Read);

        // copy most recent not null file to today null file
        if (fs.Length == 0)
        {
          string dir = Path.GetDirectoryName(fs.Name);
          string fileToday = Path.GetFileName(fs.Name);

          string[] files = Directory.GetFiles(dir, "*.xml");
          if (files.Length > 1)
          {
            DateTime dt = DateTime.MinValue;
            FileInfo mostRecent = null;

            foreach (string file in files)
            {
              FileInfo fi = new FileInfo(file);
              if (fi.Name != fileToday && fi.LastWriteTime > dt)
              {
                mostRecent = fi;
                dt = fi.LastWriteTime;
              }
            }

            if (mostRecent != null)
            {
              fs.Close();
              File.Delete(tlFile);
              File.Copy(mostRecent.FullName, tlFile);
              fs = new FileStream(tlFile, FileMode.Open, FileAccess.Read);
            }
          }
        }

        TLPlayers tlPlayers = (TLPlayers)(new XmlSerializer(typeof(TLPlayers)).Deserialize(fs));
        fs.Close();
        //
        // ui
        //
        TypedObjectListView<TLPlayer> tlist = new TypedObjectListView<TLPlayer>(this.olvTL);
        tlist.GenerateAspectGetters();

        decimal[] scoreMarkers = new decimal[] { 3, 5, 8, 11, 14, 17, 20 };
        string[] scoreDescriptions = BuildCustomGroupies<decimal>(scoreMarkers);

        // value index
        decimal[] valueIndices = new decimal[] { 0.8m, 0.85m, 0.9m, 1m, 1.05m, 1.1m, 1.15m, 1.2m, 1.25m, 1.3m };
        string[] viDesc = BuildCustomGroupies<decimal>(valueIndices);
        olvcTLValueIndex.MakeGroupies(valueIndices, viDesc);

        // profitability
        decimal[] profitabilityIndices = new decimal[] { 0.6m, 0.75m, 0.9m, 1m, 1.1m, 1.25m, 1.5m, 2m, 3m, 5m, 10m };
        string[] profitabilityDesc = BuildCustomGroupies<decimal>(profitabilityIndices);
        olvcTLProfitability.MakeGroupies(profitabilityIndices, profitabilityDesc);

        // from the total score column on
        olvcTLTotalScore.MakeGroupies(scoreMarkers, scoreDescriptions);
        olvcTLShoot.MakeGroupies(scoreMarkers, scoreDescriptions);
        olvcTLDefensiveScore.MakeGroupies(scoreMarkers, scoreDescriptions);
        olvcTLOffenseScore.MakeGroupies(scoreMarkers, scoreDescriptions);
        olvcTLOffensiveAbilityScore.MakeGroupies(scoreMarkers, scoreDescriptions);
        olvcTLRebD.MakeGroupies(scoreMarkers, scoreDescriptions);
        olvcTLRebO.MakeGroupies(scoreMarkers, scoreDescriptions);

        //foreach (OLVColumn col in olvSkills.Columns)
        //{

        //  switch (col.DisplayIndex)
        //  {
        //    case 3:
        //    { 
        //    }     
        //      break;
        //    case 4:
        //      { 
        //      }
        //      break;
        //    case 6: 
        //    case 7:
        //    case 8:
        //    case 9:
        //    case 10:
        //    case 11:
        //    case 12:
        //    case 13:

        //      break;

        //    default: break;
        //  }
        //}

        //olvTL.RebuildColumns();
        olvTL.SetObjects(tlPlayers.TLPlayer);
      }
      catch (Exception) { }
    }

    /// <summary>
    /// You can create an event handler for the CellEditFinishing event (see below). 
    /// In that handler, you would write the code to get the modified value from the control, 
    /// put that new value into the model object, 
    /// and set Cancel to true so that the ObjectListView knows 
    /// that it doesn’m have to do anything else. 
    /// You will also need to call at least RefreshItem() or RefreshObject(), 
    /// so that the changes to the model object are shown in the ObjectListView.
    /// Read more: http://objectlistview.sourceforge.net/cs/cellEditing.html#cell-editing-label#ixzz1hTD9xwsQ
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void olvTL_CellEditFinishing (object sender, CellEditEventArgs e)
    {
      try
      {
        switch (e.SubItemIndex)
        {
          case 2: // price column
            {
              TLPlayer current = (TLPlayer)e.RowObject;
              current.Profitability *= (uint)e.Value;
              current.Profitability /= (uint)e.NewValue;
              current.Price = (uint)e.NewValue;
            } break;

          case 5: // deadline
            {
              TLPlayer current = (TLPlayer)e.RowObject;
              current.Deadline = e.NewValue as string;
            } break;

          default: break;
        }
      }
      catch (Exception)
      {

      }
      finally
      {
        e.Cancel = true;
        olvTL.RefreshItem(e.ListViewItem);
      }
    }

    private void olvTL_CellEditStarting (object sender, CellEditEventArgs e)
    {

    }

    //private void olvTL_ModelDropped(object sender, ModelDropEventArgs e)
    //{

    //}

    //private void olvTL_EnabledChanged(object sender, EventArgs e)
    //{

    //}

    //private void olvTL_Leave(object sender, EventArgs e)
    //{

    //}

    #region Context Menu
    /// <summary>
    /// show the context menu on right click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void olvTL_CellRightClick (object sender, CellRightClickEventArgs e)
    {
      e.MenuStrip = cmsOlvTL;
      cmsOlvTLRemove.Tag = e.Model;
      cmsOlvTL.Show(e.Location);
    }

    /// <summary>
    /// remove player from TL evaluation
    /// </summary>
    /// <param name="sender">context menu item Remove</param>
    /// <param name="e"></param>
    private void cmsOlvTLRemove_Click (object sender, EventArgs e)
    {
      if (olvTL.MultiSelect && olvTL.SelectedObjects != null && olvTL.SelectedObjects.Count > 0)
      {
        foreach (object tlPlayer in olvTL.SelectedObjects)
          olvTL.RemoveObject(tlPlayer);
      }
      else
      {
        ToolStripItem ti = sender as ToolStripItem;
        if (ti != null && ti.Tag != null)
          olvTL.RemoveObject(ti.Tag);
      }
    }
    #endregion

    private void olvTL_KeyDown (object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Delete)
      {
        e.Handled = true;
        cmsOlvTLRemove_Click(null, null);
      }
    }

    private void olvTL_SelectionChanged (object sender, EventArgs e)
    {
      ObjectListView olv = sender as ObjectListView;
      if (olv == null)
        olv = olvTL;
      TLPlayer crt = (TLPlayer)olv.SelectedObject;
      if (crt != null)
        this.evaluatePlayerUC.SelectedObject = _mapTL[crt];
    }

    private SplitContainer splitTrnRight;
    private ObjectListView olvTrainingEfficiency;
    private CheckBox chkTEu18;
    private Label lblSkillsActive;
    private Label lblSkillsDisplay;
    private ObjectListView olvSkills;
    private OLVColumn olvcskName;
    private TabPage tabPage1;
    private UI.PlayerSkillsUserControl userControl11;
  }
}