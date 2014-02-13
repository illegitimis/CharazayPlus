using AndreiPopescu.CharazayPlus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AndreiPopescu.CharazayPlus.Utils;

namespace CharazayPlus.MSTest
{


  /// <summary>
  ///This is a test class for PlayerTest and is intended
  ///to contain all PlayerTest Unit Tests
  ///</summary>
  [TestClass()]
  public class PlayerTest
  {
    public void predictValueTest (byte age, byte week, PlayerPosition pos, double expected = 0F)
    {
      Player target = PlayerFactory.GetWorthy15YearOld(pos);
      ushort weekNo = (ushort)(17 * (age - 15) + week);
      double actual = PlayerFactory.PredictValue(weekNo, pos);
      Assert.IsTrue(Math.Abs(expected - actual) < 0.005d);
    }


    /// <summary>
    ///A test for PredictValue
    ///</summary>
    [TestMethod()]
    [ExpectedException(typeof(ArgumentException))]
    public void predictValue0 ( )
    {
      predictValueTest(0, 0, PlayerPosition.PG);
    }

    [TestMethod()]
    [ExpectedException(typeof(NotSupportedException))]
    public void worthy15Abstract ( )
    {
      Player target = PlayerFactory.GetWorthy15YearOld(PlayerPosition.Unknown);
      //Assert.IsNull(target);
    }


    [TestMethod()]
    public void shootingScore_Test ( )
    {
      Player target = PlayerFactory.GetWorthy15YearOld(PlayerPosition.PG);
      double expected = 3.9d;
      double actual = target.ShootingScore;
      Assert.IsTrue(Math.Abs(expected - actual) < 0.000001d);
    }


    /// <summary>
    ///16YO TESTS
    ///</summary>
    [TestMethod()]
    public void predictValueAllPG ( )
    {
      Player target = PlayerFactory.GetWorthy15YearOld(PlayerPosition.PG);

      for (ushort week=0; week < 17 * 17; week++)
      {
        PlayerFactory.PredictValue(week, target.PositionEnum);
      }
    }

#pragma warning disable
    [TestMethod()]
    public void predictValue_ObsoleteV10_All ( )
    {
#if DEBUG
      Player target = PlayerFactory.GetWorthy15YearOld(PlayerPosition.PG);
      for (byte age=15; age < 32; age++)
      {
        System.Diagnostics.Debug.WriteLine("{0,-5},{1,-10:F02}", age, target.predictValue(age));
      }
      target = PlayerFactory.GetWorthy15YearOld(PlayerPosition.SG);
      for (byte age=15; age < 32; age++)
      {
        System.Diagnostics.Debug.WriteLine("{0,-5},{1,-10:F02}", age, target.predictValue(age));
      }
      target = PlayerFactory.GetWorthy15YearOld(PlayerPosition.SF);
      for (byte age=15; age < 32; age++)
      {
        System.Diagnostics.Debug.WriteLine("{0,-5},{1,-10:F02}", age, target.predictValue(age));
      }
      target = PlayerFactory.GetWorthy15YearOld(PlayerPosition.PF);
      for (byte age=15; age < 32; age++)
      {
        System.Diagnostics.Debug.WriteLine("{0,-5},{1,-10:F02}", age, target.predictValue(age));
      }
      target = PlayerFactory.GetWorthy15YearOld(PlayerPosition.C);
      for (byte age=15; age < 32; age++)
      {
        System.Diagnostics.Debug.WriteLine("{0,-5},{1,-10:F02}", age, target.predictValue(age));
      }
#endif
    }

    [TestMethod()]
    public void predictValue_ObsoleteV10_32 ( )
    {
#if DEBUG
      byte age=32;
      Player target = PlayerFactory.GetWorthy15YearOld(PlayerPosition.PG);      
      System.Diagnostics.Debug.WriteLine("{0,-5},{1,-10:F02}", age, target.predictValue(age));      
      target = PlayerFactory.GetWorthy15YearOld(PlayerPosition.SG);
      System.Diagnostics.Debug.WriteLine("{0,-5},{1,-10:F02}", age, target.predictValue(age));
      target = PlayerFactory.GetWorthy15YearOld(PlayerPosition.SF);
      System.Diagnostics.Debug.WriteLine("{0,-5},{1,-10:F02}", age, target.predictValue(age));
      target = PlayerFactory.GetWorthy15YearOld(PlayerPosition.PF);
      System.Diagnostics.Debug.WriteLine("{0,-5},{1,-10:F02}", age, target.predictValue(age));
      target = PlayerFactory.GetWorthy15YearOld(PlayerPosition.C);
      System.Diagnostics.Debug.WriteLine("{0,-5},{1,-10:F02}", age, target.predictValue(age));
      
#endif
    }
#pragma warning restore
  }
}
