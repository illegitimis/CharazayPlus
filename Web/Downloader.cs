
namespace AndreiPopescu.CharazayPlus.Web
{
  using System;
  using System.Collections.Generic;
  using System.Text;
  using System.Net;
  using System.IO;

  /// <summary>
  /// 
  /// </summary>
  internal class Downloader : IDisposable
  {
    const string dnsErrorMessage = @"The remote name could not be resolved: 'www.charazay.com'";
    readonly string[] charazayIPs = new string[] { @"54.229.122.56", "54.194.193.243" };

    #region fields
    private WebClient webClient = new WebClient();
    private List<DownloadItem> itemsToDownload = new List<DownloadItem>();

    public IEnumerable<DownloadItem> Items { get { return itemsToDownload; } }

    #endregion

    private void RefreshUserAgent ( )
    {
      webClient.Headers.Add("user-agent", "Charazay Plus");
    }

    internal Downloader ( )
    {
      //webClient.BaseAddress = 

    }

    internal void Add (DownloadItem di)
    {
      //enumerable.CopyTo(itemsToDownload);
      itemsToDownload.Add(di);
    }

    internal void AddRange (IEnumerable<DownloadItem> downloadItems)
    {
      foreach (DownloadItem di in downloadItems)
        Add(di);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="refreshUserAgent"></param>
    public void Get (bool refreshUserAgent=false)
    {
      foreach (DownloadItem item in this.itemsToDownload)
      {
        bool isSuccesfulDownload = false;
        if (refreshUserAgent) RefreshUserAgent(); 
        //
        if (item.FileExists && !item.FileInvalid) return;
        //
        while (!isSuccesfulDownload)
        {
          try
          {
            webClient.DownloadFile(item.m_uri, item.m_fileName);
            isSuccesfulDownload = true;
          }
          catch (WebException e)
          {
            if (e.Message == dnsErrorMessage)
            {
              foreach (var ip in charazayIPs)
              {
                if (isSuccesfulDownload) break;
                item.m_uri = new Uri(item.m_uri.AbsoluteUri.Replace("www.charazay.com", ip));
                try
                {
                  if (refreshUserAgent) RefreshUserAgent();
                  webClient.DownloadFile(item.m_uri, item.m_fileName);
                  isSuccesfulDownload = true;
                }
                catch (WebException)
                {
                  isSuccesfulDownload = false;
                }
              }
              
            }
          }
        }
        //
        if (!isSuccesfulDownload)
        {
          item.m_fileName = GetMostRecentFile(item.m_fileName);
        } 
      }
    }

    internal void ForceGet (bool refreshUserAgent)
    {
      foreach (DownloadItem item in itemsToDownload)
      {
        if (refreshUserAgent)
        {
          RefreshUserAgent();
        }
        bool bFileExists = File.Exists(item.m_fileName);

        if (bFileExists)
        {
          File.Delete(item.m_fileName);
        }

        try
        {
          webClient.DownloadFile(item.m_uri, item.m_fileName);
        }
        catch (WebException)
        {
          //if (item.m_offline)
            item.m_fileName = GetMostRecentFile(item.m_fileName);
        }

      }
    }

    private string GetMostRecentFile (string zeroByteFilePath)
    {
      string directoryName = Path.GetDirectoryName(zeroByteFilePath);
      FileInfo mostRecent = null;

      foreach (string file in Directory.GetFiles(directoryName))
      {
        FileInfo fi = new FileInfo(file);
        if (fi.Length == 0)
          continue;

        if (mostRecent == null)
          mostRecent = fi;
        else
        {
          if (fi.CreationTime > mostRecent.CreationTime)
            mostRecent = fi;
        }
      }

      return mostRecent.FullName;
    }

    public void Dispose ( )
    {
      this.webClient.Dispose();
      this.itemsToDownload = null;
    }


  }
}
