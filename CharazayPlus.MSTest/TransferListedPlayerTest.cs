using AndreiPopescu.CharazayPlus.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CharazayPlus.MSTest
{
    
    
    /// <summary>
    ///This is m test class for TransferListedPlayerTest and is intended
    ///to contain all TransferListedPlayerTest Unit Tests
    ///</summary>
  [TestClass()]
  public class TransferListedPlayerTest
  {


    private TestContext testContextInstance;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the from test run.
    ///</summary>
    public TestContext TestContext
    {
      get
      {
        return testContextInstance;
      }
      set
      {
        testContextInstance = value;
      }
    }

    #region Additional test attributes
    // 
    //You can use the following additional attributes as you write your tests:
    //
    //Use ClassInitialize to run code before running the first test in the class
    //[ClassInitialize()]
    //public static void MyClassInitialize(TestContext testContext)
    //{
    //}
    //
    //Use ClassCleanup to run code after all tests in m class have run
    //[ClassCleanup()]
    //public static void MyClassCleanup()
    //{
    //}
    //
    //Use TestInitialize to run code before running each test
    //[TestInitialize()]
    //public void MyTestInitialize()
    //{
    //}
    //
    //Use TestCleanup to run code after each test has run
    //[TestCleanup()]
    //public void MyTestCleanup()
    //{
    //}
    //
    #endregion


    /// <summary>
    ///A test for TransferListedPlayer Constructor
    ///</summary>
    [TestMethod()]
    public void TransferListedPlayerConstructorTest1 ( )
    {
      IList<string> strings = new List<string>{
      "2014-08-23 01:45", 
      "?act=player&code=1&id=3436214", 
      "Juan Jaspe",
      "?act=team&id=42132",  
      "Aruba Aloe Warriors" , 
      "846,083", 
      "0", 
      "140,001", 
      "?act=team&id=52829", 
      "Chasseur de tête"
      };
      TransferListedPlayer target = new TransferListedPlayer(strings);
      //
      Assert.AreEqual<DateTime>(new DateTime(2014, 8, 23, 1, 45, 0, DateTimeKind.Utc), target.Deadline);
      Assert.AreEqual<uint>(3436214u, target.PlayerId);
      Assert.AreEqual<string>("Juan Jaspe", target.PlayerName);
      Assert.AreEqual<uint>(42132u, target.OwnerTeamId);
      Assert.AreEqual<string>("Aruba Aloe Warriors", target.OwnerTeamName);
      Assert.AreEqual<uint>(846083u, target.SkillsIndex);
      Assert.AreEqual<uint>(0u, target.StartingPrice);
      Assert.AreEqual<uint>(140001u, target.Bid);
      Assert.AreEqual<uint>(52829u, target.BidHolderTeamId);
      Assert.AreEqual<string>("Chasseur de tête", target.BidHolderTeamName);

    }

    [TestMethod()]
    public void TransferListedPlayerConstructorTest2 ( )
    {
     
      IList<string> strings = new List<string>{
      "2014-08-21 20:58", 
      "19903991", 
      " Adolfo Javelosa",
      "12998",  
      "  Jeepney " , 
      "803,880", 
      "0", 
      "2,660,000", 
      "26241", 
      " Bulacan Basketball Club"
      };
      TransferListedPlayer target = new TransferListedPlayer(strings);
      //
      Assert.AreEqual<DateTime>(new DateTime(2014,8,21,20,58,0,DateTimeKind.Utc) , target.Deadline);
      Assert.AreEqual<uint>(19903991u, target.PlayerId);
      Assert.AreEqual<string>("Adolfo Javelosa", target.PlayerName);
      Assert.AreEqual<uint>(12998u, target.OwnerTeamId);
      Assert.AreEqual<string>("Jeepney", target.OwnerTeamName);
      Assert.AreEqual<uint>(803880u, target.SkillsIndex);
      Assert.AreEqual<uint>(0u, target.StartingPrice);
      Assert.AreEqual<uint>(2660000u, target.Bid);
      Assert.AreEqual<uint>(26241u, target.BidHolderTeamId);
      Assert.AreEqual<string>("Bulacan Basketball Club", target.BidHolderTeamName);
      
    }
  }
}
