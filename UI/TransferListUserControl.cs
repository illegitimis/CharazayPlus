
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
  using BrightIdeasSoftware;
  using System.IO;
  using System.Xml.Serialization;
  using System.Collections;

  // Getting player from charazay + adding to olv => add to cache
  public partial class TransferListUserControl : UserControl
  {
    public TransferListUserControl ( )
    {
      InitializeComponent();
    }
  
    // reading from serialized xml, getting players
    public Web.WebServiceUser User {get; set;}
    //
    public event EventHandler BadPlayerId;
    public event EventHandler PlayerDataUnavailable;
    public event EventHandler <PlayerEventArgs> DownloadPlayerData;
  
    /// <summary>
    /// serialize the transfer listed players that have been evaluated 
    /// </summary>
    public void SerializePlayersTL ( )
    {
      string tlFile = Web.XmlDownloadItem.Category2FileName(Web.Category.MyPlayersTL);
      FileStream fs = null;
      try
      {
        fs = new FileStream(tlFile, FileMode.Truncate, FileAccess.Write);

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
      }
      finally
      {
        fs.Close();
      }
      
    }

    /// <summary>
    /// initializes the olvTL object list view with bookmarked players 
    /// </summary>
    public void InitTransferShortList ( )
    {
      FileStream fs = null;
      TLPlayers tlPlayers = null;
      try
      { //
        // data source
        //
        string tlFile = Web.XmlDownloadItem.Category2FileName(Web.Category.MyPlayersTL);
        fs = new FileStream(tlFile, FileMode.Open, FileAccess.Read);
        //
        // copy most recent not null file to today null file
        //
        if (fs.Length == 0)
        {
          fs = GetMostRecent(tlFile, fs);
        }

        tlPlayers = (TLPlayers)(new XmlSerializer(typeof(TLPlayers)).Deserialize(fs));
        
      }
      catch (Exception) { }
      finally { fs.Close(); }
      //
      // ui
      //
      Generator.GenerateColumns(this.olvTL, typeof(TLPlayer));
      // from the total score column on
      double[] scoreMarkers = new double[] { 3, 5, 8, 11, 14, 17, 20 };
      string[] scoreDescriptions = ObjectListViewExtensions.BuildCustomGroupies<double>(scoreMarkers);
      // value index
      double[] valueIndices = new double[] { 0.8d, 0.85d, 0.9d, 1d, 1.05d, 1.1d, 1.15d, 1.2d, 1.25d, 1.3d };
      string[] viDesc = ObjectListViewExtensions.BuildCustomGroupies<double>(valueIndices);
      // profitability
      double[] profitabilityIndices = new double[] { 0.5d, 0.75d, 0.9d, 1d, 1.1d, 1.25d, 1.5d, 2d, 3d, 5d, 10d, 20d, 50d, 100d };
      string[] profitabilityDesc = ObjectListViewExtensions.BuildCustomGroupies<double>(profitabilityIndices);
      //
      foreach (OLVColumn col in olvTL.Columns)
      {
        switch (col.DisplayIndex)
        {
          case 0: col.IsHeaderVertical = true; break;
          case 1: col.Hyperlink = true; col.Groupable = false; break;
          case 5: col.Groupable = false; break;
          case 6: 
          case 7:
          case 8:
          case 9:
          case 10:
          case 11:
          case 12:
          case 13: 
          col.MakeGroupies(scoreMarkers, scoreDescriptions);
          col.IsHeaderVertical = true;
          break;
          case 4: 
            col.MakeGroupies(profitabilityIndices, profitabilityDesc);
            col.IsHeaderVertical = true;
            break;
          case 2: 
            col.MakeGroupies(valueIndices, viDesc);
            col.IsHeaderVertical = true;
            break;
        }
      }
      //
      if (tlPlayers == null || tlPlayers.TLPlayer == null)
        return;
      olvTL.SetObjects(tlPlayers.TLPlayer);
      //      
      foreach (TLPlayer tlp in tlPlayers.TLPlayer)
      {
        if (tlp.Player != null)
          continue;
        Xsd2.charazay obj = DownloadPlayer (tlp.PlayerId);
        Xsd2.charazayPlayer p = obj.player;
        switch (tlp.Pos)
        {
          case PlayerPosition.C: tlp.Player = new C(p); break;
          case PlayerPosition.PF: tlp.Player = new PF(p); break;
          case PlayerPosition.SF: tlp.Player = new SF(p);break;
          case PlayerPosition.PG: tlp.Player = new PG(p); break;
          case PlayerPosition.SG: tlp.Player = new SG(p); break;
        }       
      }
     
    }

    private FileStream GetMostRecent (string tlFile, FileStream fs)
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
      return fs;
    }

    #region event handlers
    /// <summary>
    /// adds the property grid player to the olvTL list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnTLAdd_Click (object sender, EventArgs e)
    {
      PlayerPosition pos = GetPosition();
      //
      Player basePlayer = evaluatePlayerUC.GetPlayer(pos);
      //     
      TLPlayer tlp = new TLPlayer();
      if (basePlayer != null)
      { //
        tlp.Deadline = dtpDeadline.Value.ToString("yyyy/MM/dd HH:mm");      
        tlp.Position = Enum.GetName(typeof(PlayerPosition), pos);
        tlp.Price = string.IsNullOrEmpty(tbxPrice.Text) ? (uint)Math.Pow(10, 6) : uint.Parse(tbxPrice.Text);      
        tlp.Profitability = Math.Pow(10d,6d)*basePlayer.TransferMarketValue / (double)tlp.Price;
        //
        tlp.Player = basePlayer;
        CacheManager.Instance.AddPlayer(basePlayer.Id, basePlayer.FullName);
        //
        olvTL.AddObject(tlp);
      }      
    }

    private PlayerPosition GetPosition ()
    {
      if (rdC.Checked) return PlayerPosition.C;
      else if (rdPf.Checked) return PlayerPosition.PF;
      else if (rdPg.Checked) return PlayerPosition.PG;
      else if (rdSf.Checked) return PlayerPosition.SF;
      else if (rdSg.Checked) return PlayerPosition.SG;
      else return PlayerPosition.Unknown;
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
        Xsd2.charazay obj = DownloadPlayer(playerId);
        if (obj != null && obj.player != null)
        {
          this.evaluatePlayerUC.SelectedObject = obj.player;
          this.btnTLAdd.Enabled = (GetPosition() != PlayerPosition.Unknown);
          if (DownloadPlayerData != null) 
            DownloadPlayerData(null, new PlayerEventArgs() 
            { 
              Surname = obj.player.basic.surname
              , 
              Name=obj.player.basic.name
            });
        }
        else
        {
          if (PlayerDataUnavailable != null) PlayerDataUnavailable(this, null);
          this.btnTLAdd.Enabled = false;
        }        
      }
      else
      { //bad player id
        if (BadPlayerId != null) BadPlayerId(this, null);
        this.btnTLAdd.Enabled = false;
      }
    }

    /// <summary>
    /// You can create an event handler for the CellEditFinishing event (see below). 
    /// In that handler, you would write the code to get the modified value from the control, 
    /// put that new value into the model object, 
    /// and set Cancel to true so that the ObjectListView knows 
    /// that it doesn’m have to do anything else. 
    /// You will also need to call at least RefreshItem() or RefreshObject(), 
    /// so that the changes to the model object are shown in the ObjectListView.
    /// Read more: http://objectlistview.sourceforge.net/_cs/cellEditing.html#cell-editing-label#ixzz1hTD9xwsQ
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void olvTL_CellEditFinishing (object sender, CellEditEventArgs e)
    {
      try
      {
        switch (e.SubItemIndex)
        {
          case 3: // price column
            {
              TLPlayer current = (TLPlayer)e.RowObject;
              // update profitability, multiply by old price, divide by new price
              current.Profitability *= (uint)e.Value;
              current.Profitability /= (uint)e.NewValue;
              // update model price
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

    private void olvTL_CellEditStarting (object sender, CellEditEventArgs e) { }

    private void olvTL_SelectionChanged (object sender, EventArgs e)
    {
      ObjectListView olv = sender as ObjectListView;
      if (olv == null)
        olv = olvTL;
      TLPlayer crt = (TLPlayer)olv.SelectedObject;
      if (crt != null && crt.Player != null && crt.Player.BasePlayer != null)
        this.evaluatePlayerUC.SelectedObject = crt.Player.BasePlayer;
    } 
    
    private void rd_CheckedChanged (object sender, EventArgs e)
    {
      btnTLAdd.Enabled = true;
    }
    #endregion


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

    private void olvTL_KeyDown (object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Delete)
      {
        e.Handled = true;
        cmsOlvTLRemove_Click(null, null);
      }
    }
    #endregion

    private Xsd2.charazay DownloadPlayer (ulong playerId)
    {
      Web.Downloader crawler = new Web.Downloader();
      Web.PlayerXml xmlPlayer = new Web.PlayerXml(User, playerId);
      crawler.Add(xmlPlayer);
      crawler.Get(true);
      //
      FileStream fs = null;
      Xsd2.charazay obj = null;

      try
      {
        fs = new FileStream(xmlPlayer.m_fileName, FileMode.Open, FileAccess.ReadWrite);
        obj = (Xsd2.charazay)(new XmlSerializer(typeof(Xsd2.charazay)).Deserialize(fs));
      }
      catch (Exception ex)
      {
        if (ex is InvalidOperationException && ex.InnerException != null && ex.InnerException is FormatException)
        {
          string m = ex.Message.Replace("There is an error in XML document", "");
          string [] tokens = m.Split(new char[] { ' ', '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
          //System.InvalidOperationException was unhandled
          //Message=There is an error in XML document (3, 126).
          //InnerException: System.FormatException
          //Message=Input string was not in a correct format.
          long errPos = long.Parse(tokens[1]);
          fs.Seek(errPos + 8, SeekOrigin.Begin);
          fs.WriteByte(0);
        }
      }
      finally
      {
        fs.Close();
      }
      if (xmlPlayer.DeserializationType != Web.XmlSerializationType.Player)
        throw new Exception("Web.XmlSerializationType.Player");
      return obj;
    }

    private void olvTL_IsHyperlink (object sender, IsHyperlinkEventArgs e)
    {
      //e.Url
    }

    private void olvTL_HyperlinkClicked (object sender, HyperlinkClickedEventArgs e)
    {
      TLPlayer tlp = (TLPlayer)e.Item.RowObject;
      if (tlp == null) return;
      //
      switch (e.ColumnIndex)
      {
        case 1:
        {
          Web.CharazayDownloadItem playerLink = new Web.CharazayDownloadItem("player", 1, tlp.PlayerId);
          e.Url = playerLink.m_uri.AbsoluteUri;
        } break;       
        default: break;
      }
    }

    
    
  }
}
