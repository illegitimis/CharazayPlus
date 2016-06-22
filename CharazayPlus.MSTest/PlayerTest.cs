

namespace CharazayPlus.MSTest
{
using AndreiPopescu.CharazayPlus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AndreiPopescu.CharazayPlus.Utils;
using AndreiPopescu.CharazayPlus.Model;

  /// <summary>
  ///This is m test class for PlayerTest and is intended
  ///to contain all PlayerTest Unit Tests
  ///</summary>
  [TestClass()]
  public class PlayerTest
  {
    void predictValueTest (byte age, byte week, ST_PlayerPositionEnum pos, double expected = 0F)
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
      predictValueTest(0, 0, ST_PlayerPositionEnum.PG);
    }

    [TestMethod()]
    [ExpectedException(typeof(NotSupportedException))]
    public void worthy15Abstract ( )
    {
      Player target = PlayerFactory.GetWorthy15YearOld(ST_PlayerPositionEnum.Unknown);
      //Assert.IsNull(target);
    }


    [TestMethod()]
    public void shootingScore_Test ( )
    {
      Player target = PlayerFactory.GetWorthy15YearOld(ST_PlayerPositionEnum.PG);
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
      Player target = PlayerFactory.GetWorthy15YearOld(ST_PlayerPositionEnum.PG);

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
      Player target = PlayerFactory.GetWorthy15YearOld(ST_PlayerPositionEnum.PG);
      for (byte age=15; age < 32; age++)
      {
        System.Diagnostics.Debug.WriteLine("{0,-5},{1,-10:F02}", age, target.predictValue(age));
      }
      target = PlayerFactory.GetWorthy15YearOld(ST_PlayerPositionEnum.SG);
      for (byte age=15; age < 32; age++)
      {
        System.Diagnostics.Debug.WriteLine("{0,-5},{1,-10:F02}", age, target.predictValue(age));
      }
      target = PlayerFactory.GetWorthy15YearOld(ST_PlayerPositionEnum.SF);
      for (byte age=15; age < 32; age++)
      {
        System.Diagnostics.Debug.WriteLine("{0,-5},{1,-10:F02}", age, target.predictValue(age));
      }
      target = PlayerFactory.GetWorthy15YearOld(ST_PlayerPositionEnum.PF);
      for (byte age=15; age < 32; age++)
      {
        System.Diagnostics.Debug.WriteLine("{0,-5},{1,-10:F02}", age, target.predictValue(age));
      }
      target = PlayerFactory.GetWorthy15YearOld(ST_PlayerPositionEnum.C);
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
      Player target = PlayerFactory.GetWorthy15YearOld(ST_PlayerPositionEnum.PG);      
      System.Diagnostics.Debug.WriteLine("{0,-5},{1,-10:F02}", age, target.predictValue(age));      
      target = PlayerFactory.GetWorthy15YearOld(ST_PlayerPositionEnum.SG);
      System.Diagnostics.Debug.WriteLine("{0,-5},{1,-10:F02}", age, target.predictValue(age));
      target = PlayerFactory.GetWorthy15YearOld(ST_PlayerPositionEnum.SF);
      System.Diagnostics.Debug.WriteLine("{0,-5},{1,-10:F02}", age, target.predictValue(age));
      target = PlayerFactory.GetWorthy15YearOld(ST_PlayerPositionEnum.PF);
      System.Diagnostics.Debug.WriteLine("{0,-5},{1,-10:F02}", age, target.predictValue(age));
      target = PlayerFactory.GetWorthy15YearOld(ST_PlayerPositionEnum.C);
      System.Diagnostics.Debug.WriteLine("{0,-5},{1,-10:F02}", age, target.predictValue(age));
      
#endif
    }
#pragma warning restore
  }
}
