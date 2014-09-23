
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
  using AndreiPopescu.CharazayPlus.Objects;
  using System.Linq;
  using AndreiPopescu.CharazayPlus.Extensions;

  // Getting player from charazay + adding to olv => add to cache
  public partial class TransferListUserControl : UserControl
  {
    static readonly TimeSpan TimeSpan6H = new TimeSpan(6, 0, 0);
    static readonly TimeSpan TimeSpan30Days = new TimeSpan(30, 0, 0, 0);
    
    public TransferListUserControl ( )
    {
      InitializeComponent();
    }

#if DOTNET30
    //Objects.TransferHistoryDataContext _dcTransfers = null;
#else
    Objects.TransferHistoryDataSetTableAdapters.QueriesTableAdapter _qta = null;
#endif

    #region published events
    //
    public event EventHandler BadPlayerId;
    public event EventHandler PlayerDataUnavailable;
    public event EventHandler <PlayerEventArgs> DownloadPlayerData;
    #endregion

    #region private methods
    private void GenerateOlvColumns ( )
    {
      if (this.olvTL.Columns != null && this.olvTL.Columns.Count > 0)
        return;
      this.olvTL.ShowItemCountOnGroups = true;
      //
      // ui
      //
      Generator.GenerateColumns(this.olvTL, typeof(TLPlayer));

      //
      foreach (OLVColumn col in olvTL.Columns)
      {
        switch (col.DisplayIndex)
        {
          case 0: //position
            //col.IsHeaderVertical = true; 
            col.Groupable = true;
            break;

          case 1: // player name 
            col.Hyperlink = true;
            col.Groupable = false;
            col.Sortable = true;
            break;

          case 2: //age value index
            {
              double[] valueIndices = new double[] { 0.8d, 0.85d, 0.9d, 1d, 1.05d, 1.1d, 1.15d, 1.2d, 1.25d, 1.3d };
              string[] viDesc = ObjectListViewExtensions.BuildCustomGroupies<double>(valueIndices);
              col.MakeGroupies(valueIndices, viDesc);
              //col.IsHeaderVertical = true;
            } break;

          case 3: //prices
            {
              uint[] indices = new uint[] { 10000u, 500000u, 1000000u, 2000000u, 5000000u, 10000000u, 20000000u, 50000000u };
              col.MakeGroupies(indices, ObjectListViewExtensions.BuildCustomGroupies<uint>(indices));
            } break;

          case 4: //profitability
            {
              double[] profitabilityIndices = new double[] { 0.5d, 0.75d, 0.9d, 1d, 1.1d, 1.25d, 1.5d, 2d, 3d, 5d, 10d, 20d, 50d, 100d };
              string[] profitabilityDesc = ObjectListViewExtensions.BuildCustomGroupies<double>(profitabilityIndices);
              col.MakeGroupies(profitabilityIndices, profitabilityDesc);
              //col.IsHeaderVertical = true;
            } break;

          case 5: //deadline
            {
              col.Sortable = true;
              col.Groupable = true;
              col.GroupKeyGetter = delegate(object o) { TLPlayer tlp = (TLPlayer)o; return tlp.DeadLine.Day; };
              col.GroupKeyToTitleConverter = delegate(object groupKey)
              {

                int iDay = (int)groupKey;
                int currentDay = DateTime.Now.Day;
                if (iDay < currentDay) return "deadline reached";
                else if (iDay == currentDay) return "today";
                else if (iDay == 1 + currentDay) return "tomorrow";
                else if (iDay == currentDay + 2) return "day after tomorrow";
                else return "later";
              };
            }
            break;

          case 6: {
            col.Sortable = true;
            col.Groupable = true;
            col.Renderer = new MultiImageRenderer (
              Properties.Resources.star16 //Object imageSelector
              , 3//int maxImages
              , 0//int minValue
              , 4//int maxValue
              );
          } break;

          default: break;
        }
      }
    }

    private PlayerPosition GetPosition ( )
    {
      if (rdC.Checked) return PlayerPosition.C;
      else if (rdPf.Checked) return PlayerPosition.PF;
      else if (rdPg.Checked) return PlayerPosition.PG;
      else if (rdSf.Checked) return PlayerPosition.SF;
      else if (rdSg.Checked) return PlayerPosition.SG;
      else return PlayerPosition.Unknown;
    }

    void SetWaitCursor (Action seqAct)
    {
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        seqAct();
      }
      catch { }
      finally
      {
        Cursor.Current = Cursors.Default;
      }
    }

    void DoScrapeUpdate (TLPlayer tlp)
    {
      var st = ScrapeUpdate(tlp);
      this.lblServertime.Text = st.ToString("yyyy-MM-dd HH:mm:ss");
      this.olvTL.RefreshObject(tlp);
    }
    #endregion

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
      Player basePlayer = ucEvaluatePlayer.GetPlayer(pos);
      //     
      if (basePlayer != null)
      { //
        TLPlayer tlp = new TLPlayer()
        {
          Deadline = dtpDeadline.Value.ToString("yyyy/MM/dd HH:mm"),
          Position = Enum.GetName(typeof(PlayerPosition), pos),
          Price = string.IsNullOrEmpty(tbxPrice.Text) ? (uint)Math.Pow(10, 6) : uint.Parse(tbxPrice.Text),
          AgeValueIndex = basePlayer.ValueIndex,
          PlayerId = basePlayer.Id,
          Name = basePlayer.FullName
        };
        tlp.Profitability = Math.Pow(10d, 6d) * basePlayer.TransferMarketValue / (double)tlp.Price;
        //
        CacheManager.Instance.AddPlayer(basePlayer.Id, basePlayer.FullName);
        //
        olvTL.AddObject(tlp);
        //Data.TransferList.IsDirty = true;
        //
        Data.TransferList.Bookmarks.Add(tlp);
      }
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
        var xsd2p = Deserializer.GoGetPlayerXml(playerId);
        //
        if (xsd2p != null)
        {
          this.ucEvaluatePlayer.SelectedObject = xsd2p;
          this.btnTLAdd.Enabled = (GetPosition() != PlayerPosition.Unknown);
          if (DownloadPlayerData != null)
            DownloadPlayerData(null, new PlayerEventArgs()
            {
              Surname = xsd2p.basic.surname
              ,
              Name = xsd2p.basic.name
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

          case 6: // importance
          {
            TLPlayer current = (TLPlayer)e.RowObject;
            current.Importance = Math.Min((byte)3, Math.Max(byte.Parse (e.NewValue as string), (byte)0));
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
      if (crt == null)
        return;
      //
      var xsdp = Deserializer.GoGetPlayerXml(crt.PlayerId);
      //
      this.ucEvaluatePlayer.SelectedObject = xsdp;
      this.ucBasicPlayerInfo.PlayerByScore = this.ucEvaluatePlayer.GetPlayer(crt.Pos);
      this.ucBasicPlayerInfo.CurrentPrice = crt.Price;
      if (this.ucBasicPlayerInfo.PlayerByScore != null)
        this.ucBasicPlayerInfo.Init();
    }

    private void rd_CheckedChanged (object sender, EventArgs e)
    {
      btnTLAdd.Enabled = true;
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

    private void olvTL_ColumnClick (object sender, ColumnClickEventArgs e)
    {
      switch (e.Column)
      {
        case 1: // player name
          ObjectListViewExtensions.ShowGroups(this.olvTL, false);
          break;

        default:
          if (this.olvTL.ShowGroups == false)
          {
            ObjectListViewExtensions.ShowGroups(this.olvTL, true);
          }
          break;
      }
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
      cmsRemove.Tag = e.Model;
      cmsUpdate.Tag = e.Model;
      cmsOlvTL.Show(e.Location);
    }

    /// <summary>
    /// remove player from TL evaluation
    /// </summary>
    /// <param name="sender">context menu item Remove</param>
    /// <param name="e"></param>
    private void cmsOlvTLRemove_Click (object sender, EventArgs e)
    {
      //Data.TransferList.IsDirty = true;
      //
      if (olvTL.MultiSelect && olvTL.SelectedObjects != null && olvTL.SelectedObjects.Count > 0)
      {
        foreach (object tlPlayer in olvTL.SelectedObjects)
        {
          olvTL.RemoveObject(tlPlayer);
          Data.TransferList.Bookmarks.Remove(tlPlayer as TLPlayer);
        }
      }
      else
      {
        ToolStripItem ti = sender as ToolStripItem;
        if (ti != null && ti.Tag != null)
        {
          olvTL.RemoveObject(ti.Tag);
          Data.TransferList.Bookmarks.Remove(ti.Tag as TLPlayer);
        }
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

    private void cmsOlvTLUpdate_Click (object sender, EventArgs e)
    {
      SetWaitCursor(( ) =>
      {
        if (olvTL.MultiSelect && olvTL.SelectedObjects != null && olvTL.SelectedObjects.Count > 0)
        {
          foreach (object tlPlayer in olvTL.SelectedObjects)
          {
            DoScrapeUpdate(tlPlayer as TLPlayer);
          }
        }
        else
        {
          ToolStripItem ti = sender as ToolStripItem;
          if (ti != null && ti.Tag != null)
          {
            DoScrapeUpdate(ti.Tag as TLPlayer);
          }
        }
        //
#if DOTNET30
        var changeSet = Data.DbEnvironment.Instance.TransferHistoryDC.GetChangeSet();
        if (!changeSet.Deletes.IsNullOrEmpty() || !changeSet.Inserts.IsNullOrEmpty() || !changeSet.Updates.IsNullOrEmpty())
          Data.DbEnvironment.Instance.TransferHistoryDC.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
#else

#endif
      });
      

    }

   
    private DateTime ScrapeUpdate (TLPlayer tlPlayer)
    {
      var page = new AndreiPopescu.CharazayPlus.Web.PlayerPageDownloadItem(tlPlayer.PlayerId);
      var ppi = Web.Scraper.Instance.PlayerPage(page.m_uri);
      //
      // bookmarked player with exact court position as in the list
      //
      var currentPlayer = Utils.Deserializer.GetPlayerFromIdAndPosition(tlPlayer.PlayerId, tlPlayer.Pos);
      //
      if (ppi.IsTransferListed)
      { //
        // update TLPlayer with more relevant site info
        //
        tlPlayer.Deadline = ppi.Deadline.Value.ToString("yyyy.MM.dd HH:mm");
        tlPlayer.Price = ppi.Price.Value;
        //
        // no more 'regula de 3 simpla'
        // tlPlayer.Profitability *= (tlPlayer.Price / (double)ppi.Price.Value);
        //
        tlPlayer.Profitability = currentPlayer.TransferMarketValue * Math.Pow(10, 6) / tlPlayer.Price;
      }
      else
      { //
        // deadline is over
        // transfer details either on player history page or team transfer history
        //
#if DOTNET30
        //if (_dcTransfers == null) _dcTransfers = new TransferHistoryDataContext();
#else
        if (_qta == null)
          _qta = new Objects.TransferHistoryDataSetTableAdapters.QueriesTableAdapter();
#endif
        //
        var pthdi = new AndreiPopescu.CharazayPlus.Web.PlayerTransferHistoryDownloadItem(tlPlayer.PlayerId);
        var th = Web.Scraper.Instance.ParseTransferHistory(pthdi.m_uri).ToList();
        //
        if (th.IsNullOrEmpty())
        { //
          // no history whatsoever, not even promoted on, means he got fired
          // implicitly set tm value to 0
          //
          InsertDb(tlPlayer.Pos, currentPlayer.Age, (decimal)0, (decimal)currentPlayer.ValueIndex, tlPlayer.DeadLine);
          olvTL.RemoveObject(tlPlayer);
          Data.TransferList.Bookmarks.Remove(tlPlayer);
        }
        else
        { //
          // there is transfer history (transfer history matches data)
          // either player is listed with same skills index and in a time window of less than 6hrs
          // or was marked as deadline reached and most recent deadline hsitory is pretty close to where we stand
          //
          var ts = (th[0].TransferDate - tlPlayer.DeadLine);
          if (ts < TimeSpan.Zero) ts = -ts;
          var ts2 = th[0].TransferDate - DateTime.UtcNow;
          if (ts2 < TimeSpan.Zero) ts2 = -ts2;
          if ((th[0].SkillsIndex == currentPlayer.SkillsIndex && ts < TimeSpan6H) || 
              (tlPlayer.DeadLine == DateTime.MinValue && ts2<TimeSpan30Days /*&& currentPlayer.SkillsIndex != th[0].SkillsIndex*/))
          { 
            decimal priceInMillions = th[0].Price / (decimal)1000000;
            //
            // player value index might change in the meantime
            //
            var valIdx = (decimal)Math.Min (tlPlayer.AgeValueIndex, currentPlayer.ValueIndex);
            //if (valIdx > 0)
            //{
              InsertDb(tlPlayer.Pos, currentPlayer.Age, priceInMillions, valIdx, th[0].TransferDate);
              //
              olvTL.RemoveObject(tlPlayer);
              Data.TransferList.Bookmarks.Remove(tlPlayer);
            //}

          }
          else
          { //
            // no matching history found, or slow update
            // player was transferlisted, not bought and not listed again
            // update deadline, but do not change price 
            // profitability updated due to Matlab new interpolation parameters
            //
            tlPlayer.Deadline = DateTime.MinValue.ToString("yyyy.MM.dd HH:mm");
            tlPlayer.Profitability = currentPlayer.TransferMarketValue * Math.Pow(10, 6) / tlPlayer.Price;            
          }
        }

      }

      return ppi.Servertime;
    }

    private void InsertDb (PlayerPosition pos, byte age, decimal priceInMillions, decimal valIdx, DateTime? dt = null)
    {

#if DOTNET30
      char posid = ' ';
#else
  Action a = null; 
#endif

      try
      {
        
        switch (pos)
        {
          case PlayerPosition.C:
          case PlayerPosition.PF:
#if DOTNET30
            posid = 'C';
#else
  a = ()=>_qta.spInsertC(age, valIdx, priceInMillions);
#endif
            break;

          case PlayerPosition.PG:
          case PlayerPosition.SG:
#if DOTNET30
            posid = 'G';
#else
  a = ()=>_qta.spInsertG(age, valIdx, priceInMillions);
#endif
            break;

          case PlayerPosition.SF:
#if DOTNET30
            posid = 'F';
#else
  _qta.spInsertF(age, valIdx, priceInMillions);
#endif
            break;
        }
        if (! Data.DbEnvironment.Instance.TransferHistoryDC.Histories.Any (x=>x.Age==age && x.PosId == posid && x.AgeValueIndex == valIdx && x.Price == priceInMillions && x.Day == dt.Value))
          Data.DbEnvironment.Instance.TransferHistoryDC.Histories.InsertOnSubmit(new History() { Age = age, PosId = posid, AgeValueIndex = valIdx, Price = priceInMillions, Day = dt.Value });
      }
      catch { }
    }

    private void tsmiNone_Click (object sender, EventArgs e)
    {
      PlayerImportance_Click(sender, 0);
    }

    private void PlayerImportance_Click (object sender, byte value)
    {
      SetWaitCursor(( ) =>
      {
        if (olvTL.MultiSelect && olvTL.SelectedObjects != null && olvTL.SelectedObjects.Count > 0)
        {
          foreach (object tlPlayer in olvTL.SelectedObjects)
          {
            UpdatePlayerImportance(tlPlayer as TLPlayer, value);
          }
        }
        else
        {
          ToolStripItem ti = sender as ToolStripItem;
          if (ti != null && ti.Tag != null)
          {
            UpdatePlayerImportance(ti.Tag as TLPlayer, value);
          }
        }
      });
    }

    private void UpdatePlayerImportance (TLPlayer tLPlayer, byte p)
    {
      tLPlayer.Importance = Math.Min((byte)3, Math.Max(p, (byte)0));
      this.olvTL.RefreshObject(tLPlayer);
    }

    private void tsmiSmall_Click (object sender, EventArgs e)
    {
      PlayerImportance_Click(sender, 1);
    }

    private void tsmiMedium_Click (object sender, EventArgs e)
    {
      PlayerImportance_Click(sender, 2);
    }

    private void tsmiHigh_Click (object sender, EventArgs e)
    {
      PlayerImportance_Click(sender, 3);
    }
    #endregion

    #region public methods


    /// <summary>
    /// initializes the olvTL object list view with bookmarked players 
    /// </summary>
    public void InitTransferShortList ( )
    {
      GenerateOlvColumns();
      //
      if (Data.TransferList.Bookmarks.IsNullOrEmpty())
        return;
      olvTL.SetObjects(Data.TransferList.Bookmarks);
      //      
      foreach (TLPlayer tlp in Data.TransferList.Bookmarks)
      {
        // if (tlp.Player != null)
        //   continue;
        ////
        // Xsd2.charazayPlayer p = Deserializer.GoGetPlayerXml(tlp.PlayerId);
        // switch (tlp.Pos)
        // {
        //   case PlayerPosition.C: tlp.Player = new C(p); break;
        //   case PlayerPosition.PF: tlp.Player = new PF(p); break;
        //   case PlayerPosition.SF: tlp.Player = new SF(p); break;
        //   case PlayerPosition.PG: tlp.Player = new PG(p); break;
        //   case PlayerPosition.SG: tlp.Player = new SG(p); break;
        // }
      }

    }
    #endregion
    
   }
}
