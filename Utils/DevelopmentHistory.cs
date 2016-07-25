

namespace AndreiPopescu.CharazayPlus.Utils
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Xml.Serialization;
  using System.IO;
  using AndreiPopescu.CharazayPlus.Model;

  /// <summary>
  /// Historical player development out of Players API files
  /// will be updated daily with team data info
  /// </summary>
  public class DevelopmentHistory
  {
    public Development Development { get; private set; }

    public AndreiPopescu.CharazayPlus.Xsd2.charazayPlayer[] Players { private get; set; }

    public void Validate ( ) { }

    private string SerializedDevelopmentFilePath
    {
      get {
        AssemblyInfo asInfo = new AssemblyInfo();
        if (!Directory.Exists(asInfo.ApplicationFolder))
          Directory.CreateDirectory(asInfo.ApplicationFolder);

        string path = Path.Combine(asInfo.ApplicationFolder, "Development.xml");
        if (!File.Exists(path))
        {
          StreamWriter sw = File.CreateText(path);
          sw.WriteLine("<?xml version=\"1.0\"?><development />");
          sw.Close();
        }
        return path;
      }
      
    }

    #region Singleton
    private static DevelopmentHistory _instance = null;
    private static volatile object _syncObject = new object();
    private static bool _isFinalized = false;

    private DevelopmentHistory ( )
    { //
      // deserialize from Development.xml
      //
      using (FileStream fs = new FileStream(SerializedDevelopmentFilePath, FileMode.Open, FileAccess.Read))
      {
        Development = (Development)(new XmlSerializer(typeof(Development)).Deserialize(fs));
      }
    }

    public static DevelopmentHistory Instance
    {
      get
      {
        if (_instance == null)
        {
          lock (_syncObject)
          {
            if (_instance == null)
              _instance = new DevelopmentHistory();
          }
        }
        return _instance;
      }
    }
    #endregion

    /// <summary>
    /// finalizer, will be called on application end
    /// updated cache data is persisted to xml
    /// </summary>
    ~DevelopmentHistory ( )
    {
      if (_isFinalized)
        return;

      lock (_syncObject)
      {
        // backup
        var fn = SerializedDevelopmentFilePath;
        File.Copy(sourceFileName: fn, destFileName: fn + ".bak", overwrite: true);

        using (FileStream fs = new FileStream(fn, FileMode.Truncate, FileAccess.Write))
        {
          XmlSerializer serializer = new XmlSerializer(typeof(Development));
          //
          Development.DecorateFromPlayers(Players, DateTime.UtcNow.ToString("yyMMdd"));
          //
          serializer.Serialize(fs, Development);
          //
          _isFinalized = true;
        }
      }
    }
  }
}
