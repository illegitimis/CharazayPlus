using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AndreiPopescu.CharazayPlus.Objects;
using System.IO;

namespace AndreiPopescu.CharazayPlus.Data
{
  class TransferList
  {
    public static IList<TLPlayer> Bookmarks { get { return Nested.TLPlayers; } }
    //public static TLPlayers Bookmarks { get { return Nested.TLPlayers; } }

    public void Add (TLPlayer tlp) { Nested.TLPlayers.Add(tlp); }

    //public static bool IsDirty { get { return Nested.isDirty; } set { Nested.isDirty = value; } }

    private class Nested
    {
      internal static readonly IList<TLPlayer> TLPlayers;
      //internal static readonly TLPlayers TLPlayers;

      internal static bool isDirty = false;

      static Nested ( )
      {
        TLPlayers = new List<TLPlayer>();
        FileStream fs = null;
        //TLPlayers = null;
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
          TLPlayers = x.TLPlayer.ToList();
        }
        catch (Exception) { }
        finally { fs.Close(); }

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