
namespace CharazayPlus.MSTest
{
  using AndreiPopescu.CharazayPlus.Utils;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using System;
  using System.Collections.Generic;
  using System.Linq; 
 
    /// <summary>
    ///This is a test class for TransferMarketTest and is intended
    ///to contain all TransferMarketTest Unit Tests
    ///</summary>
  [TestClass()]
  public class TransferMarketTest
  {


    private TestContext testContextInstance;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
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
    //Use ClassCleanup to run code after all tests in a class have run
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
    ///A test for Find
    ///</summary>
    [TestMethod()]
    public void FindTest_C32 ( )
    {
      byte age = 32; 
      char pos = 'C'; 
            
      List<float[]> actual = TransferMarket.Find(age, pos).ToList();
      Assert.AreEqual(19, actual.Count);
      
      float[] actual0 = actual[0];
      Assert.AreEqual(0.92f, actual0[0]);
      Assert.AreEqual(0.04f, actual0[1]);

      float[] actual18 = actual[18];
      Assert.AreEqual(1.17f, actual18[0]);
      Assert.AreEqual(21.106666f, actual18[1]);

      LeastSquares.Fit fiteo = new LeastSquares.ExponentialOptimum(actual);
      LeastSquares.Fit fite = new LeastSquares.Exponential(actual);
      LeastSquares.Fit fit = new LeastSquares.Linear(actual);
    }

    [TestMethod()]
    public void FindTest_C31( )
    {
      byte age = 31;
      char pos = 'C';

      List<float[]> actual = TransferMarket.Find(age, pos).ToList();
      Assert.AreEqual(22, actual.Count);

      float[] first = actual[0];
      Assert.AreEqual(0.99f, first[0]);
      Assert.AreEqual(3.06f, first[1]);

      float[] last = actual[21];
      Assert.AreEqual(1.22f, last[0]);
      Assert.AreEqual(30f, last[1]);

      LeastSquares.Fit fiteo = new LeastSquares.ExponentialOptimum(actual);
      LeastSquares.Fit fite = new LeastSquares.Exponential(actual);
      LeastSquares.Fit fit = new LeastSquares.Linear(actual);
    }
  }
}
