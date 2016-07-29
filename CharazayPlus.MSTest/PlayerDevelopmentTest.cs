namespace CharazayPlus.MSTest
{
  using System.Collections.Generic;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using System.Reflection;
  using System.IO;
  using System.Xml.Serialization;
  using AndreiPopescu.CharazayPlus.Model;
  using API = AndreiPopescu.CharazayPlus.Xsd2.charazay;
  using AndreiPopescu.CharazayPlus.Utils;
  using System.Diagnostics;

  [TestClass]
  public class PlayerDevelopmentTest
  {
    [TestMethod]
    public void TestEmbeddedDeserialization ( )
    {
      Development d = DeserializeEmbeddedXml<Development>("PlayerDevelopment.xml");
      Assert.IsNotNull(d);
      Assert.IsNotNull(d.PlayerItems);
      Assert.AreEqual(d.PlayerItems.Count, 2);
      CollectionAssert.AllItemsAreNotNull(d.PlayerItems);
      CollectionAssert.AllItemsAreNotNull(d.PlayerItems[0].ItemValues);
      Assert.AreEqual(d.PlayerItems[0].ItemValues.Count, 38);
    }


    [TestMethod]
    public void TestSerializationNaive ( )
    {
      using (Stream stream = File.Open ("zbc.xml", FileMode.OpenOrCreate))
      {
        var d = new Development();
        d.PlayerItems = new List<PlayerDevelopment>();
        d.PlayerItems.Add(new PlayerDevelopment());
        d.PlayerItems.Add(new PlayerDevelopment());
        var srlz = new XmlSerializer(typeof(Development));
        srlz.Serialize(stream, d);
        
      }
    }

    private T DeserializeEmbeddedXml<T> (string fileName)
      where T : class
    {
      var assembly = Assembly.GetExecutingAssembly();
      var resourceName = "CharazayPlus.MSTest." + fileName;

      //Development obj = null;
      T obj = null;
      using (Stream stream = assembly.GetManifestResourceStream(resourceName))
      {
        //obj = (Development)(new XmlSerializer(typeof(Development)).Deserialize(stream));
        obj = (T)(new XmlSerializer(typeof(T)).Deserialize(stream));
      }
      return obj;
    }

    private T DeserializeXmlFile<T> (string fileName)
      where T : class
    {
      T obj = null;
      using (Stream stream = File.OpenRead(fileName))
      {
        //obj = (Development)(new XmlSerializer(typeof(Development)).Deserialize(stream));
        obj = (T)(new XmlSerializer(typeof(T)).Deserialize(stream));
      }
      return obj;
    }
    
    [TestMethod]
    public void TestBuildDevelopmentOutOf3Files ( )
    {
      string[] xmls = new string[] {
        @"c:\Users\Illegitimis\AppData\Local\CharazayPlus\Players\20150807.xml",
        @"c:\Users\Illegitimis\AppData\Local\CharazayPlus\Players\20150718.xml",
        @"c:\Users\Illegitimis\AppData\Local\CharazayPlus\Players\20150520.xml"  
      };
      //
      Development d = new Development() { PlayerItems = new List<PlayerDevelopment>() };
      //
      foreach (string path in xmls)
      {
        string sdate = Path.GetFileNameWithoutExtension(path).Substring(2);
        API api = DeserializeXmlFile<API>(path);
        //
        d.DecorateFromPlayers(api, sdate);        
      }
      //
      
    }

    /// <summary>
    /// recreates Development.xml from player history (Players/yyyyMMdd.xml)
    /// can be used to recreate file on crashes
    /// </summary>
    [TestMethod]
    public void TestBuildDevelopmentFull ( )
    {
      AssemblyInfo asInfo = new AssemblyInfo();
      string developmentXmlPath = Path.Combine(asInfo.ApplicationFolder, "Development.xml");
      string dir = Path.Combine(asInfo.ApplicationFolder, "Players");
      //
      using (var fs = File.Open (developmentXmlPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
      {
        Development d = new Development() { PlayerItems = new List<PlayerDevelopment>() };
        //
        foreach (var xml in Directory.GetFiles(dir,"*.xml"))
        {
          string sdate = Path.GetFileNameWithoutExtension(xml).Substring(2);
          API api = DeserializeXmlFile<API>(xml);
          //
          d.DecorateFromPlayers(api, sdate);
          //
          Trace.WriteLine(sdate);          
        }
        //
        var srlz = new XmlSerializer(typeof(Development));
        srlz.Serialize(fs, d);
      }
    }

  }
}
