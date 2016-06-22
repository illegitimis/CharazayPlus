
namespace AndreiPopescu.CharazayPlus.Data
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using AndreiPopescu.CharazayPlus.Model;
  using System.IO;

  class TransferList
  {
    //public static IList<TLPlayer> Bookmarks { get { return Nested.TLPlayers; } }
    //public static TLPlayers Bookmarks { get { return Nested.TLPlayers; } }
    public static List<CT_TransferBookmark> Bookmarks { get { return Nested.TransferBookmarks; } }

    //public static bool IsDirty { get { return Nested.isDirty; } set { Nested.isDirty = value; } }
    //public void Add (TLPlayer tlp) { Nested.TLPlayers.Add(tlp); }

    private class Nested
    {
      //internal static readonly IList<TLPlayer> TLPlayers;
      //internal static readonly TLPlayers TLPlayers;
      internal static readonly List<CT_TransferBookmark> TransferBookmarks;

      internal static bool isDirty = false;

      static Nested ( )
      {
        TransferBookmarks = DeserializeTransferBookmarks();
      }

      [Obsolete("Replaced by DeserializeTransferBookmarks")]
      private static List<TLPlayer> DeserializeTLPlayers ( )
      {
        var o = new List<TLPlayer>();

        FileStream fs = null;
        
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

          var x = (TLPlayers)(new System.Xml.Serialization.XmlSerializer(typeof(TLPlayers)).Deserialize(fs));
          o = x.TLPlayer.ToList();
        }
        catch  
        { 
        }
        finally 
        { 
          fs.Close(); 
        }

        return o;
      }

      private static List<CT_TransferBookmark> DeserializeTransferBookmarks ( )
      {       
        FileStream fs = null;

        try
        { //
          // data source
          //
          string tlFile = Web.XmlDownloadItem.NotDailyCategoryFileName(Web.Category.TransferBookmarks);
          fs = new FileStream(tlFile, FileMode.Open, FileAccess.Read);

          var root = (CT_TransferBookmarks)(new System.Xml.Serialization.XmlSerializer(typeof(CT_TransferBookmarks)).Deserialize(fs));
          return root.Items;
        }
        catch
        {
        }
        finally
        {
          fs.Close();
        }

        return new List<CT_TransferBookmark>();
      }

      static private FileStream GetMostRecent (string tlFile, FileStream fs)
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
    }
  }
}