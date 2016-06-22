

namespace CharazayPlus.MSTest
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using AndreiPopescu.CharazayPlus.Data;
  using AndreiPopescu.CharazayPlus.Utils;
  using AndreiPopescu.CharazayPlus.Objects;
  using AndreiPopescu.CharazayPlus.Interpolate;



  [TestClass]
  public class OutliersTest
  {
    public delegate void GetABDelegate (byte age, char pos, out double a, out double b);
   
    public void TestAgainstMatlabJuly2015Averages ( )
    {
      //var Outliers = new List<History>();

      for (byte age = 15; age <= 35; age++)
      {
        foreach (char pos in new[] { 'G', 'F', 'C' })
        {
          double a4, b4;
          MatlabInterpolant201507.Instance.GetAB(age, pos, out a4, out b4);
          //
          var queryFilterAgePos = from th in DbEnvironment.Instance.TransferHistoryDC.History
                      where th.Age == age && th.PosId == pos
                      group th by th.AgeValueIndex into g
                      orderby g.Key ascending
                      select g;
          foreach (var x in queryFilterAgePos)
          {
            //grpHistoryItems.Key
            double estimatedPriceMean = a4 * Math.Exp((double)x.Key * b4);
            List<History> outliers = null;
            if (x.Count() > 1)
            {
              var meanDifs = x.Select(i => (double)i.Price - estimatedPriceMean);
              double variance = meanDifs.DotProduct(meanDifs);
              double stdev = Math.Sqrt(variance);
              outliers = x.Where(i => (double)i.Price > estimatedPriceMean + 3 * stdev || (double)i.Price < estimatedPriceMean - 3 * stdev).ToList();
            }
            else
            {
              outliers = x.Where(i => ((double)i.Price > 3 * estimatedPriceMean || (double)i.Price < estimatedPriceMean / 3)
                && Math.Abs((double)i.Price - estimatedPriceMean) > 3d
                && (i.Price > 1 || i.AgeValueIndex > 1)
                ).ToList();
            }
            if (!outliers.Empty())
            { 
              DbEnvironment.Instance.TransferHistoryDC.Outliers.InsertAllOnSubmit(
                //outliers.Cast<Outliers>()
                outliers.Select(o=>(Outliers)o)
                );
              // Add renamed to insert on submit
              DbEnvironment.Instance.TransferHistoryDC.History.DeleteAllOnSubmit (outliers);              
            }
          }

          DbEnvironment.Instance.TransferHistoryDC.SubmitChanges();
        }
      }


      //foreach (var h in Outliers)
      //  Debug.WriteLine(h);
    }

    public void RemoveOutliersHelper ( GetABDelegate del)
    {
      for (byte age = 15; age <= 35; age++)
      {
        foreach (char pos in new[] { 'G', 'F', 'C' })
        {
          double a, b;
          del(age, pos, out a, out b);
          //
          var queryFilterAgePosGroupValueIndex =
                                  from th in DbEnvironment.Instance.TransferHistoryDC.History
                                  where th.Age == age && th.PosId == pos
                                  group th by th.AgeValueIndex into g
                                  orderby g.Key ascending
                                  select g;
          foreach (var grpHistoryItems in queryFilterAgePosGroupValueIndex)
          {
            //grpHistoryItems.Key is the value index
            double estimated = (double)(a * Math.Exp((double)grpHistoryItems.Key * b));

            // add interpolated mean in the list of items too
            var prices = grpHistoryItems.Select(x => (double)x.Price).ToArray();
            var pricesForValueIndex = prices.Union(new[] { estimated });
            double stdev = pricesForValueIndex.StandardDeviation();

            // remove BIG only
            //outliers = grpHistoryItems.Where(i => (double)i.Price > estimated + 2.5 * stdev || (double)i.Price < estimated - 2.5 * stdev).ToList();
            var outliers = grpHistoryItems.Where(i => (double)i.Price > estimated + 2 * stdev).ToArray();

            if (outliers.Length > 0)
            {
              DbEnvironment.Instance.TransferHistoryDC.Outliers.InsertAllOnSubmit(outliers.Select(o => (Outliers)o));
              // Add renamed to insert on submit
              DbEnvironment.Instance.TransferHistoryDC.History.DeleteAllOnSubmit(outliers);
            }
          }

          DbEnvironment.Instance.TransferHistoryDC.SubmitChanges();
        }
      }


      //foreach (var h in Outliers)
      //  Debug.WriteLine(h);
    }

    //before: 11234 data, 267 outliers
    //after: 11043, 458    //--10661--849
     [TestMethod]
    public void RemoveNov2015 (  )
    {
      RemoveOutliersHelper (MatlabInterpolant201511.Instance.GetAB);
    }

    /// <summary>
    /// before:  849, 11359
    /// after:  1143, 11065
    /// </summary>
     [TestMethod]
     public void RemoveJan2016 ( )
     {
       RemoveOutliersHelper(MatlabInterpolant201601.Instance.GetAB);
     }

     /// <summary>
     /// select COUNT(*) from History   before:  11978 after: 11706 
     /// select COUNT(*) from Outliers  before:  1143  after: 1415
     /// </summary>
     [TestMethod]
     public void RemoveOutliersApril2016 ( )
     {
       RemoveOutliersHelper(MatlabInterpolant201604.Instance.GetAB);
     }

     /// <summary>
     /// select COUNT(*) from History   before:11881 after: 11809 
     /// select COUNT(*) from Outliers  before:1415  after: 1487
     /// </summary>
     [TestMethod]
     public void RemoveOutliers201605May ( )
     {
       RemoveOutliersHelper(MatlabInterpolant201604.Instance.GetAB);
     }


     /// <summary>
     /// select COUNT(*) from History   before:11881 after: 11809 
     /// select COUNT(*) from Outliers  before:1415  after: 1487
     /// </summary>
     [TestMethod]
     public void RemoveOutliers201606JUNE( )
     {
       //RemoveOutliersHelper(MatlabInterpolant201604.Instance.GetAB);
       RemoveOutliersHelper(MatlabInterpolant201604.Instance.GetAB);
     }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestVariance_NullInput ()
    {
      IEnumerable<double> x = null;
      x.Variance();
    }

    [TestMethod]
    public void TestVariance_SmallEnumerable ( )
    {
      IEnumerable<double> x = new double[] {};
      Assert.AreEqual (x.Variance(), 0) ;
      x = new double[] { 13d };
      Assert.AreEqual(x.Variance(), 0);
    }

    [TestMethod]
    public void TestVariance ( )
    {
      IEnumerable<double> x = new double[] { 1,2,3,4,5};
      Assert.AreEqual(x.Variance(), 2);
      Assert.AreEqual(x.StandardDeviation(), Math.Sqrt(2));
    }
  }
}
