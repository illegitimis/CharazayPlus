
namespace CharazayPlus.MSTest
{
  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AndreiPopescu.CharazayPlus.Utils;

  [TestClass()]
  public class DateTest
  {
    [TestMethod()]
    public void CharazayDate_20130818 ( )
    {
      CharazayDate cd = new DateTime(2013,8,18);
      Assert.AreEqual<byte>(cd.Season, 28);
      Assert.AreEqual<byte>(cd.Week, 2);
      Assert.AreEqual<byte>(cd.Day, 3);

    }

    //S29 W9 D5
    [TestMethod()]
    public void CharazayDate_2014_2_4 ( )
    {
      var dt = new DateTime(2014, 2, 4);
      var dt2 = dt.AddDays(-9 * 7 - 5);
      CharazayDate cd = dt;
      Assert.AreEqual<byte>(cd.Season, 29);
      Assert.AreEqual<byte>(cd.Week, 9);
      Assert.AreEqual<byte>(cd.Day, 5);

    }

    [TestMethod()]
    public void CharazayDate_Start28 ( )
    {
      var dt = new DateTime(2013, 8, 9);
      CharazayDate cd = dt;
      Assert.AreEqual<byte>(cd.Season, 28);
      Assert.AreEqual<byte>(cd.Week, 1);
      Assert.AreEqual<byte>(cd.Day, 1);
    }

    [TestMethod()]
    public void CharazayDate_Start29 ( )
    {
      var dt = new DateTime(2013, 12, 06);
      CharazayDate cd = dt;
      Assert.AreEqual<byte>(cd.Season, 29);
      Assert.AreEqual<byte>(cd.Week, 1);
      Assert.AreEqual<byte>(cd.Day, 1);
    }

    //S30 W6 D5
    [TestMethod()]
    public void CharazayDate_20140513 ( )
    {
      var dt = new DateTime(2014, 05, 13);
      CharazayDate cd = dt;
      Assert.AreEqual<byte>(cd.Season, 30);
      Assert.AreEqual<byte>(cd.Week, 6);
      Assert.AreEqual<byte>(cd.Day, 5);
    }
  }
}
