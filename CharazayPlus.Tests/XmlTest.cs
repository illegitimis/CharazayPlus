using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CharazayPlus.Tests
{
  [TestClass()]
  public class XmlTest
  {
    internal const string XmlTestFilesDirectory = @"..\..\xml";
    internal const uint uim = uint.MaxValue;

    //[TestMethod()]
    public DataSet LoadDatasetFromXml(string fileName)
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
    public DataSet LoadDatasetFromXml(string xmlDataFileName, string xmlSchemaFileName)
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
  }
}
