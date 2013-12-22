
namespace CharazayPlus.Tests
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
    public void ImplicitOperator20130818 ()
    {
      CharazayDate cd = new DateTime(2013,8,18);
      Assert.AreEqual<byte>(cd.Season, 28);
      Assert.AreEqual<byte>(cd.Week, 2);
      Assert.AreEqual<byte>(cd.Day, 3);

    }
  }
}
