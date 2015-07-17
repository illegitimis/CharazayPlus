using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleBrowser;
using System.IO;
using AndreiPopescu.CharazayPlus.Objects;
using System.Globalization;
using System.Net;
using AndreiPopescu.CharazayPlus.Extensions;

namespace AndreiPopescu.CharazayPlus.Web
{
  /// <summary>
  /// Navigate and translate data from the Charazay website
  /// </summary>
  class Scraper
  {
    #region singleton
    private static object sync = new object();

    public static Scraper Instance
    {
      get { lock (sync) { return SingletonCreator.PrivateScraperInstance; } }
    }

    private static class SingletonCreator
    {
      static SingletonCreator ( )
      {
        PrivateScraperInstance = new Scraper();
      }

      internal static readonly Scraper PrivateScraperInstance = null;
    }

    /// <summary>
    /// private constructor
    /// </summary>
    Scraper ( )
    {
      this.browser = new Browser();
      // log the browser request/response data to files so we can interrogate them in case of an issue with our scraping
      browser.RequestLogged += (/*Browser*/ req, /*HttpRequestLog*/ log) =>
      {
        Console.WriteLine(" -> " + log.Method + " request to " + log.Url);
        Console.WriteLine(" <- Response status code: " + log.StatusCode);
      };
      browser.MessageLogged += (/*Browser*/ _browser, /*string*/ log) => Console.WriteLine(log);


      // we'll fake the user agent for websites that alter their content for unrecognised browsers
      browser.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";

      //browser.Cookies.Add(new Cookie("__utma", "91201864.1959694309.1356151134.1356231348.1356234562.6", "/", ".charazay.com"));
      //browser.Cookies.Add(new Cookie("__atuvc", "6%7C51%2C2%7C52", "/", "www.charazay.com"));
      browser.Cookies.Add(new Cookie("language", "en", "/", ".charazay.com"));
      browser.Cookies.Add(new Cookie("charazay_unq", "96ff73712d0112586b52587dee44dcf4", "/", ".charazay.com"));
			//
    }
    #endregion

    
    #region simple browser automation

    Browser browser = null;

    public void Login ( )
    {

      try
      {
        // browse to 
        browser.Navigate("http://www.charazay.com/");
        if (LastRequestFailed()) return; // always check the last request in case the page failed to load
        // click the login link and click it
        browser.Log("First we need to log in, so browse to the login page, fill in the login details and submit the form.");


        //<input class="form_small" name="username" type="text" size="7" maxlength="30">
        //<input name="username" size="7" maxlength="30" placeholder="Username" type="text">
        var user = browser.Find(ElementType.TextField, "name", "username");
        if (!user.Exists || user.TotalElementsFound > 1)
        {
          user = browser.Find("input", new { name = "username", placeholder = "Username", size =7, maxlength=30});
        }
        // 
        if (!user.Exists) return;
        user.Value = "elphy";

        //<input class="form_small" name="password" type="password" size="7" maxlength="30">
        //<input name="password" size="7" maxlength="30" placeholder="Password" type="password">
        var pasw = browser.Find(ElementType.TextField, "name", "password");
        if (!pasw.Exists || pasw.TotalElementsFound > 1)
        {
          pasw = browser.Find("input", new { name = "password", placeholder = "Password", size = 7, maxlength = 30 });
        }
        //
        if (!pasw.Exists) return;
        pasw.Value = "zdreanta123";

        //<input class="form_small" type="submit" value="Login">
        //<input value="" type="submit">
        var loginLink = browser.Find("input", FindBy.Value, "Login");
        if (!loginLink.Exists)
          loginLink = browser.Find("input", new { type = "submit" });

        if (!loginLink.Exists)
          browser.Log("Can't find the login link! Perhaps the site is down for maintenance?");
        else
          loginLink.Click();
        
        if (LastRequestFailed()) return;

        // see if the login succeeded - ContainsText() is very forgiving, so don't worry about whitespace, casing, html tags separating the text, etc.
        if (browser.ContainsText("Incorrect login or password"))
        {
          browser.Log("Login failed!", LogMessageType.Error);
        }
        else
        {



        }

      }
      catch (Exception ex)
      {
        browser.Log(ex.Message, LogMessageType.Error);
        browser.Log(ex.StackTrace, LogMessageType.StackTrace);
      }
      finally
      {
        //var path = WriteFile("log-" + DateTime.UtcNow.Ticks + ".html", browser.RenderHtmlLogFile("SimpleBrowser Sample - Request Log"));
        //Process.Start(path);
      }
    }

    bool LastRequestFailed ( )
    {
      if (browser.LastWebException != null)
      {
        browser.Log("There was an error loading the page: " + browser.LastWebException.Message);
        return true;
      }
      return false;
    }
    #endregion

    /// <summary>
    /// parse the transfer market
    /// </summary>
    /// <param name="uri"></param>
    /// <returns></returns>
    public IEnumerable<Objects.TransferListedPlayer> ClassicTransferMarket (Uri uri)
    {
      // After logging in, we should check that the page contains elements that we recognise
      if (!browser.ContainsText("Latest News") && !browser.ContainsText("Current Bid"))
        browser.Log("There wasn't the usual login failure message, but the text we normally expect isn't present on the page");
      else
      {
        browser.Navigate(uri);
      }

      bool allowPagination = true;
      IDictionary<int,Uri> paginationUris = new Dictionary<int, Uri>();
      return ParseClassicTransferMarket(allowPagination, paginationUris);

    }

    private IEnumerable<Objects.TransferListedPlayer> ParseClassicTransferMarket (bool allowPagination, IDictionary<int, Uri> paginationUris)
    { //
      var divmcfs = browser.Select("div.mc-fs");
      if (!divmcfs.Exists)
        yield break;
      
      var tbl = divmcfs.Select("table");
      if (!tbl.Exists)
        yield break;

      var trs = tbl.Select("tr");
      foreach (var tr in trs)
      {
        var tds = tr.Select("td");
        if (tds.TotalElementsFound == 7)
        { //
          // list of strings per each row
          //
          string date=null, teambid=null, teambidid=null,pn=null,pid=null,teamown=null,teamownid=null,si=null,prc=null,bid=null;
          int tdIndex = 0;
          foreach (var td in tds)
          {
            switch (tdIndex)
            {
              case 0: date = td.Value; break;
              case 1:
                pn = td.Value;
                pid = td.Select("a").GetAttribute("href");
                break;
              case 2:
                teamown = td.Value;
                teamownid = string.IsNullOrWhiteSpace(teamown) ? null : td.Select("a").GetAttribute("href");
                break;
              case 3: si = td.Value; break;
              case 4: prc = td.Value; break;
              case 5: bid = td.Value; break;
              case 6:
                teambid = td.Value;
                teambidid = string.IsNullOrWhiteSpace(teambid) ? null : td.Select("a").GetAttribute("href");
                break;
            }

            tdIndex++;
          }
          yield return new Objects.TransferListedPlayer(date, pn, pid, teamown, teamownid, si, prc, bid, teambid, teambidid);
        }
        //
        // pagination urls
        //
        if (tds.TotalElementsFound == 1 && allowPagination)
        {
          // this gets current, only td
          foreach (var td in tds)
          {
            if (td.Value.Contains(">>"))
            {
              foreach (var a in td.Select("a"))
              {
                if (a.Value != ">>")
                {
                  int pageno = int.Parse(a.Value);
                  paginationUris[pageno] = new Uri(browser.Url, a.GetAttribute("href"));
                }
              }
            }
          }
        }
        else
          continue;

      }
      if (allowPagination)
      {
        // add to the list only the first time
        // prevent multiple loops over pagination uris
        allowPagination = false;
        foreach (var pagUri in paginationUris)
        {//a.Click();
          browser.Navigate(pagUri.Value);
          //
          foreach (var tlp in ParseClassicTransferMarket(allowPagination, paginationUris))
          {
            yield return tlp;
          }
        }
      }


    }

    /// <summary>
    /// parse a player transfer history
    /// </summary>
    /// <param name="uri"></param>
    /// <returns></returns>
    public IEnumerable<Objects.SitePlayerTransferHistory> ParseTransferHistory (Uri uri)
    {
      this.browser.Navigate(uri);
      if (this.browser.ContainsText("Player ID not found"))
        yield break;
      //
      var table = this.browser.Find("table", FindBy.Id, "players");
      if (table == null || table.TotalElementsFound > 1)
        table = browser.Select("table#players.adminique-table");
      //
      foreach (var tr in table.Select("tr"))
      {
        string date=null,from=null,fromid=null,to=null,toid=null,si=null,price=null;
        //
        var tds = tr.Select("td");
        switch (tds.TotalElementsFound)
        {
          case 5:
            {
              int tdIndex = 0;
              foreach (var td in tds)
              {
                switch (tdIndex)
                {
                  case 0: date = td.Value; break;
                  case 1: from = td.Value;
                    try
                    {
                      fromid = string.IsNullOrWhiteSpace(from)
                                        ? null
                                        : td.Select("a").GetAttribute("href");
                    }
                    catch
                    {
                      fromid = null;
                    }
                      break;
                  case 2: to = td.Value; try
                      {
                        toid = string.IsNullOrWhiteSpace(to) ? null : td.Select("a").GetAttribute("href");
                      }
                      catch 
                      {
                        toid = null;
                      } break;
                  case 3: si = td.Value; break;
                  case 4: price = td.Value; break;
                }
                tdIndex++;
              }
              yield return new Objects.SitePlayerTransferHistory(date, from, fromid, to, toid, si, price);
            } break;

          case 4:
            {
              int tdIndex = 0;
              foreach (var td in tds)
              {
                switch (tdIndex)
                {
                  case 0: date = td.Value; break;
                  case 1: from = td.Value; break;
                  case 2: si = td.Value; break;
                  default: break;
                }
                tdIndex++;
              }
              yield return new Objects.SitePlayerTransferHistory(date, from, si);
            } break;

          default: break;
        }

      }

    }
    
    /// <summary>
    /// parse player page
    /// </summary>
    /// <param name="uri"></param>
    /// <returns></returns>
    internal PlayerPageInfo PlayerPage (Uri uri)
    {
      lock (sync)
      {
        this.browser.Navigate(uri);
        if (!browser.ContainsText("Team Name:"))
        {
          Login();
          this.browser.Navigate(uri);
        }
        //
        PlayerPageInfo ppi = new PlayerPageInfo();
        //

        // September 02, 2014 12:53:34
        ppi.Servertime = DateTime.ParseExact(browser.Select("span#servertime").Value
          , "MMMM dd, yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        //
        var form = GetPlayerBidForm();
        if (form == null || !form.Exists)
        { // no longer on TM
          //http://www.charazay.com/index.php?act=team&id=13469#transfers
          //http://www.charazay.com/index.php?act=error&code=1&id=4
          //ppi.IsTransferListed = false;
        }
        else
        {
          var x = form.Select("span#deadline");
          if (x.Exists)
          {
            ppi.Deadline = DateTime.ParseExact(x.Value, "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            //
            ppi.Now = DateTime.ParseExact(form.Select("span#now").Value
            , "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            //
            string current_bid = form.Select("span#current_bid").Value;
            ppi.CurrentBid = ParsingExtensions.GetUInt(current_bid);
            //
            var last_bidby = form.Select("span#last_bidby");
            if (last_bidby.Exists)
            {
              ppi.LastBidByTeamName = TransferListedPlayer.TeamName(last_bidby.Value);
              ppi.LastBidByTeamId = TransferListedPlayer.TeamId(last_bidby.Select("a").GetAttribute("href"));
            }
            //
            foreach (var td in form.Select("td"))
            {
              if (td.GetAttribute("class") == "right" && td.GetAttribute("style") == "width: 15em;")
              {
                ppi.StartingPrice = ParsingExtensions.GetUInt(td.Value);
                break;
              }
            }
          }
          else 
          {
            x = form.Select("input.form_small");
            //if (x.Exists)

          }
         
        }
        return ppi;
      }
    }

    private HtmlResult GetPlayerBidForm ( )
    {
      var form = browser.Find("form", FindBy.Name, "bid");
      if (form == null || !form.Exists)
        form = this.browser.Select("form");
      return form;
    }

    /// <summary>
    /// bid on a player
    /// </summary>
    /// <param name="uri"></param>
    internal void PlayerBid (Uri uri)
    {
      this.browser.Navigate(uri);
      var form = GetPlayerBidForm();
      var i1 = form.Select("input#new_bid");
      i1.Value = "10000";
      var i2 = form.Select("input.inputSubmit");
      i2.Click();
      if (this.browser.ContainsText("Your bid is lower than the current asked price") ||
        this.browser.ContainsText("Latest News (See All)"))
      {
        this.browser.Navigate(uri);
      }
    }

    
  }

}


#region tm 1
//{
//  //var divc = browser.Select("div.container_12.clearfix");
//  //var mainmenu = browser.Select("ul#mainmenu.sf-menu");
//  //var myTeamLink = browser.Find("m", FindBy.Text, "My Team");
//  var tmLink = browser.Find("m", FindBy.Text, "Transfer Market");

//  if(tmLink == null)
//    browser.Log("Can't find transfer market link!");
//  else
//    tmLink.Click();
//  //should go to http://www.charazay.com/index.php?act=transfer
//  if (!browser.ContainsText("Make sure you read the Transfer Market Rules before using the Transfer Market."))
//    browser.Log("Transfer market page does not contain usual info");
//  //
//  var divsrch = browser.Select("div#search-content.tabcontent");
//  if (!divsrch.Exists)
//    divsrch = browser.Find("div", FindBy.Id, "search-content");
//  if (!divsrch.Exists)
//    return;

//  var fieldsets = divsrch.Select("fieldset");
//  //if (fieldsets.TotalElementsFound != 2)
//  //  return;
//  HtmlResult btnsrch=null;

//  foreach (var fieldset in fieldsets)
//  {
//    browser.Log(fieldset.Select("legend").Value);
//    switch (fieldset.Select("legend").Value)
//    {
//      case "Search Options":
//        var so = fieldset.Select("select#code.selectOne");
//    if (!so.Exists) so = browser.Find("select", FindBy.Id, "code");
//    if (so.Exists)
//    {
//      browser.Log(so.Value);
//    }
//        break;

//      case "Search Criteria":
//      //var x = fieldset.Select("div.criteria_left");
//      //browser.Log(string.Format("x: {0}", x.TotalElementsFound));
//      //var y = fieldset.Select("div.criteria_right");
//      //browser.Log(string.Format("y: {0}", y.TotalElementsFound));
//      var z = fieldset.Select("input.inputText");
//      if (z.TotalElementsFound != 4)
//        return;

//      while (z.Exists && z.Next())
//      {
//        switch (z.GetAttribute("name"))
//        {
//          case "price_l": z.Value = "1000000"; break;
//          case "price_h": break;
//          case "value_l": z.Value = "800000"; break;
//          case "value_h": break;

//        }                    
//      }
//      btnsrch = fieldset.Select("button.button");
//      break;


//      default:
//        break;
//    }


//  }//fieldsets loop
//  if (btnsrch.Exists && btnsrch.Value == "Search Transfer Market")
//    btnsrch.Click();
//  //
//  var trs = browser.Select("table").Select("tr");
//  foreach (var tr in trs)
//  {
//    browser.Log(tr.Value);
//  }

//} 
#endregion