
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
            
      List<double[]> actual = TransferMarket.Find(age, pos).ToList();
      Assert.AreEqual(19, actual.Count);
      
      //double[] actual0 = actual[0];
      //Assert.AreEqual(0.92f, actual0[0]);
      //Assert.AreEqual(0.04f, actual0[1]);

      //double[] actual18 = actual[18];
      //Assert.AreEqual(1.17f, actual18[0]);
      //Assert.AreEqual(21.106666f, actual18[1]);

      LeastSquares.Fit fiteo = new LeastSquares.ExponentialOptimum(actual);
      LeastSquares.Fit fite = new LeastSquares.Exponential(actual);
      LeastSquares.Fit fit = new LeastSquares.Linear(actual);

    }

    [TestMethod()]
    public void FindTest_C31( )
    {
      byte age = 31;
      char pos = 'C';

      List<double[]> actual = TransferMarket.Find(age, pos).ToList();
      Assert.AreEqual(22, actual.Count);

      //double[] first = actual[0];
      //Assert.AreEqual(0.99f, first[0]);
      //Assert.AreEqual(3.06f, first[1]);

      //double[] last = actual[21];
      //Assert.AreEqual(1.22f, last[0]);
      //Assert.AreEqual(30f, last[1]);

      LeastSquares.Fit fiteo = new LeastSquares.ExponentialOptimum(actual);
      LeastSquares.Fit fite = new LeastSquares.Exponential(actual);
      LeastSquares.Fit fit = new LeastSquares.Linear(actual);
    }

    [TestMethod()]
    public void FindTest ( )
    {
      char[] pos = new char[]{'C','F','G'};
      for (byte age= 15; age <= 35; age++)
      {
        foreach (char c in pos)
        {
          List<double[]> actual = TransferMarket.Find(age, c).ToList();
          
          LeastSquares.Fit opt = new LeastSquares.ExponentialOptimum(actual);
          LeastSquares.Fit exp = new LeastSquares.Exponential(actual);
          LeastSquares.Fit lin = new LeastSquares.Linear(actual);
          
          LeastSquares.Fit fit = null;
          char method = '-';
          double r2 = 0d;
          try
          {
            if (opt.R2 > r2)
            {
              method = 'o'; r2 = opt.R2; fit = opt;
            }
          }
          catch { }
          try
          {
          if (lin.R2 > r2)
          {
            method = 'l'; r2 = lin.R2; fit = lin;
          }}
          catch { }
          try
          {
            if (exp.R2 > r2)
            {
              method = 'e'; r2 = exp.R2; fit = exp;
            }
          }
          catch { }
          System.Diagnostics.Debug.WriteLine("{0} {1} {2} {3:F02} {4}", age, c, method, r2, fit);
        }
      }
      
    
      
    }
  }
}
