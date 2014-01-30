using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Serialization;
using System.Reflection;

namespace CharazayPlus.Tests
{
  [TestClass()]
  public class XmlTest
  {
    internal const string XmlTestFilesDirectory = @"..\..\xml";
    internal const uint uim = uint.MaxValue;

    //[TestMethod()]
    public DataSet LoadDatasetFromXml (string fileName)
    {
      DataSet ds = new DataSet();
      FileStream fs = null;

      try
      {
        fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        using (StreamReader reader = new StreamReader(fs))
        {
          ds.ReadXml(reader);
        }
      }
      catch (Exception e)
      {
        MessageBox.Show(e.ToString());
      }
      finally
      {
        if (fs != null)
          fs.Close();
      }

      return ds;
    }

    //[TestMethod()]
    public DataSet LoadDatasetFromXml (string xmlDataFileName, string xmlSchemaFileName)
    {
      DataSet ds = new DataSet();
      FileStream fs = null;
      ds.ReadXmlSchema(xmlSchemaFileName);

      try
      {
        fs = new FileStream(xmlDataFileName, FileMode.Open, FileAccess.Read);
        using (StreamReader reader = new StreamReader(fs))
        {
          ds.ReadXml(reader, XmlReadMode.IgnoreSchema);
        }
      }
      catch (Exception e)
      {
        MessageBox.Show(e.ToString());
      }
      finally
      {
        if (fs != null)
          fs.Close();
      }

      return ds;
    }

    private AndreiPopescu.CharazayPlus.Xsd2.charazay DeserializeEmbeddedXml (string fileName)
    {
      var assembly = Assembly.GetExecutingAssembly();
      var resourceName = "CharazayPlus.Tests." + fileName;
      AndreiPopescu.CharazayPlus.Xsd2.charazay obj = null;
      using (Stream stream = assembly.GetManifestResourceStream(resourceName))
      {
        obj = (AndreiPopescu.CharazayPlus.Xsd2.charazay)(new XmlSerializer(typeof(AndreiPopescu.CharazayPlus.Xsd2.charazay)).Deserialize(stream));
      }
      return obj;
    }

    [TestMethod()]
    public void DeserializeUserInfoCvbe ( )
    {
      AndreiPopescu.CharazayPlus.Xsd2.charazay obj =DeserializeEmbeddedXml("UserInfo_Cvbe.xml");
      Assert.IsNotNull(obj);
      Assert.IsNotNull(obj.user);
      Assert.AreEqual(obj.user.countryid, 6);
      Assert.AreEqual(obj.user.id, 345587u);
      Assert.AreEqual(obj.user.last_active, 0u);

      Assert.AreEqual(obj.user.name, "cvbe");
      Assert.AreEqual(obj.user.registered, 1356443881u);
      Assert.AreEqual(obj.user.supporter, "no");
      Assert.AreEqual(obj.user.teamid, 57711u);

    }

    [TestMethod()]
    public void DeserializeTeamInfoCvbe ( )
    {
      AndreiPopescu.CharazayPlus.Xsd2.charazay obj =DeserializeEmbeddedXml("TeamInfo_Cvbe.xml");
      Assert.IsNotNull(obj);
      Assert.IsNotNull(obj.team);
      Assert.AreEqual(obj.team.id, 57711u);
      Assert.AreEqual(obj.team.countryid, 6);
      Assert.AreEqual(obj.team.userid, 345587u);
      Assert.IsNotNull(obj.team.team_info);
      Assert.AreEqual(obj.team.team_info.arenaid, 57711u);
      Assert.AreEqual(obj.team.team_info.rival, 38088u);
      Assert.IsNotNull(obj.team.team_info.fanclub);
      Assert.IsNotNull(obj.team.team_info.training);
    }

  }
}
