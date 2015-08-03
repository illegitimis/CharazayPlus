using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AndreiPopescu.CharazayPlus.Data;
using AndreiPopescu.CharazayPlus.Utils;
using System.Diagnostics;
using AndreiPopescu.CharazayPlus.Objects;

namespace CharazayPlus.MSTest
{
  [TestClass]
  public class OutliersTest
  {
        
    [TestMethod]
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
            //x.Key
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
  }
}
