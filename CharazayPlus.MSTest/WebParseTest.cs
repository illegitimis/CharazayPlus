

namespace CharazayPlus.MSTest
{
  using System;
  using System.Text;
  using System.Collections.Generic;
  using System.Linq;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using System.Globalization;
  using AndreiPopescu.CharazayPlus.Extensions;


  [TestClass]
  public class WebParseTest
  {
    [TestMethod]
    public void AfterSiteDesignModification1603_Login ( )
    {
      AndreiPopescu.CharazayPlus.Web.Scraper.Instance.Login();
    }
    
    [TestMethod]
    public void AfterSiteDesignModification1603_PlayerPage ( )
    {
      Uri uri = new Uri("http://www.charazay.com/index.php?act=player&code=1&id=41747008", UriKind.Absolute);
      var ppi = AndreiPopescu.CharazayPlus.Web.Scraper.Instance.PlayerPage(uri);
      Assert.IsNotNull(ppi);
      Assert.IsTrue(ppi.IsTransferListed);
      Assert.IsTrue(ppi.Deadline > new DateTime(2016, 3, 20));
      Assert.IsTrue(ppi.Now > new DateTime(2016, 3, 18));
      Assert.IsTrue(ppi.Servertime > new DateTime(2016, 3, 18));
      Assert.IsTrue(ppi.Price >= 0);
      Assert.IsTrue(ppi.StartingPrice >= 0);


      uri = new Uri("http://www.charazay.com/?act=player&code=1&id=24376130", UriKind.Absolute);
      ppi = AndreiPopescu.CharazayPlus.Web.Scraper.Instance.PlayerPage(uri);
      Assert.IsNotNull(ppi);
      Assert.IsTrue(ppi.IsTransferListed);
      Assert.IsTrue(ppi.Deadline > new DateTime(2016, 3, 18));
      Assert.IsTrue(ppi.Now > new DateTime(2016, 3, 18));
      Assert.IsTrue(ppi.Servertime > new DateTime(2016, 3, 18));
      Assert.IsTrue(ppi.Price >= 0);
      Assert.IsTrue(ppi.StartingPrice >= 0);
      Assert.AreNotEqual(0, ppi.LastBidByTeamId);
      Assert.IsNotNull(ppi.LastBidByTeamName);
    }

    //
    [TestMethod]
    public void AfterSiteDesignModification1603_PlayerTransferHistory ( )
    {
      Uri uri = new Uri("http://www.charazay.com/index.php?act=player&code=2&id=24376130", UriKind.Absolute);
      var ths = AndreiPopescu.CharazayPlus.Web.Scraper.Instance.ParseTransferHistory(uri).ToList();

      Assert.IsNotNull(ths);
      Assert.AreEqual(ths.Count, 2);
      Assert.IsTrue(ths[0].TransferDate < new DateTime(2016, 3, 18));
      Assert.IsTrue(ths[1].TransferDate < new DateTime(2016, 3, 18));
      
    }

    
    [TestMethod]
    public void AfterSiteDesignModification1603_ClassicMarket ( )
    {
      Uri uri = new Uri(
        "http://www.charazay.com/?act=transfer&id2=0&userid=0&code=1&country=&profile=&name=&price_l=&price_h=&value_l=900000&value_h=&age_l=&age_h=&height_l=&height_h=&defence_l=&defence_h=&ft_l=&ft_h=&tpt_l=&tpt_h=&thpt_l=&thpt_h=&dribbling_l=&dribbling_h=&passing_l=&passing_h=&speed_l=&speed_h=&footwork_l=&footwork_h=&rebound_l=&rebound_h=&experience_l=&experience_h=&skill1a=0&skill1b=0&skill1c=0&skill1d=0&skill1_l=&skill1_h=&skill2a=0&skill2b=0&skill2c=0&skill2d=0&skill2_l=&skill2_h=&view=1"
        , UriKind.Absolute);
      var ths = AndreiPopescu.CharazayPlus.Web.Scraper.Instance.ClassicTransferMarket(uri).ToList();

      Assert.IsNotNull(ths);
      Assert.AreEqual(ths.Count, 10);
      Assert.IsTrue(ths[0].Deadline > new DateTime(2016, 3, 18));
      Assert.IsTrue(ths[1].Deadline > new DateTime(2016, 3, 18));

    }

    [TestMethod]
    public void UintParseTest()
    {
      Assert.AreEqual(ParsingExtensions.GetUInt("2.100.000"), 2100000u);
      Assert.AreEqual(ParsingExtensions.GetUInt("1,700,000"), 1700000u);
      
      //uint j = uint.Parse("2.100.000", NumberStyles.AllowThousands | NumberStyles.Integer);
      //Assert.AreEqual(j, 2100000u);


      //uint i = uint.Parse("1,900,000", NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
      //Assert.AreEqual(i, 1900000u);

      //i = uint.Parse("1,900,000", NumberStyles.AllowThousands, new CultureInfo("ro-RO", true));
      //Assert.AreEqual(i, 1900000);
      
    }
  }
}
