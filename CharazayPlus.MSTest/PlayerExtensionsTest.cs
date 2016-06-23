using AndreiPopescu.CharazayPlus.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using AndreiPopescu.CharazayPlus.Model;
using System.Collections.Generic;
using AndreiPopescu.CharazayPlus;
using AndreiPopescu.CharazayPlus.Utils;
using QPH = AndreiPopescu.CharazayPlus.Utils.QualitativePositionHeight;
using POS = AndreiPopescu.CharazayPlus.Model.ST_PlayerPositionEnum;


namespace CharazayPlus.MSTest
{
    
    
    /// <summary>
    ///This is a test class for PlayerExtensionsTest and is intended
    ///to contain all PlayerExtensionsTest Unit Tests
    ///</summary>
  [TestClass()]
  public class PlayerExtensionsTest
  {
    ///// <summary>
    /////A test for DecideOnTotalScore
    /////</summary>
    //[TestMethod()]
    //public void DecideOnTotalScoreFacetsTest ( )
    //{
    //  PG pg = null; // TODO: Initialize to an appropriate value
    //  SG sg = null; // TODO: Initialize to an appropriate value
    //  SF sf = null; // TODO: Initialize to an appropriate value
    //  PF pf = null; // TODO: Initialize to an appropriate value
    //  C c = null; // TODO: Initialize to an appropriate value
    //  Player expected = null; // TODO: Initialize to an appropriate value
    //  Player actual;
    //  actual = PlayerExtensions.DecideOnTotalScore(pg, sg, sf, pf, c);
    //  Assert.AreEqual(expected, actual);
    //  Assert.Inconclusive("Verify the correctness of this test method.");
    //}

    ///// <summary>
    /////A test for DecideOnTotalScore
    /////</summary>
    //[TestMethod()]
    //public void DecideOnTotalScoreEnumerableTest ( )
    //{
    //  IEnumerable<Player> players = null; // TODO: Initialize to an appropriate value
    //  Player expected = null; // TODO: Initialize to an appropriate value
    //  Player actual;
    //  actual = PlayerExtensions.DecideOnTotalScore(players);
    //  Assert.AreEqual(expected, actual);
    //  Assert.Inconclusive("Verify the correctness of this test method.");
    //}

    /// <summary>
    ///A test for MostAdequatePositionForHeight
    ///</summary>
    
    [TestMethod()]
    public void MostAdequatePositionForHeightTests ( )
    {
      Assert.AreEqual(ST_PlayerPositionEnum.PG, PlayerExtensions.MostAdequatePositionForHeight(160));
      Assert.AreEqual(ST_PlayerPositionEnum.PG, PlayerExtensions.MostAdequatePositionForHeight(170));
      Assert.AreEqual(ST_PlayerPositionEnum.PG, PlayerExtensions.MostAdequatePositionForHeight(185));
      Assert.AreEqual(ST_PlayerPositionEnum.PG, PlayerExtensions.MostAdequatePositionForHeight(186));
      Assert.AreEqual(ST_PlayerPositionEnum.PG, PlayerExtensions.MostAdequatePositionForHeight(187));
      Assert.AreEqual(ST_PlayerPositionEnum.PG, PlayerExtensions.MostAdequatePositionForHeight(190));
      Assert.AreEqual(ST_PlayerPositionEnum.SG, PlayerExtensions.MostAdequatePositionForHeight(193));
      Assert.AreEqual(ST_PlayerPositionEnum.SG, PlayerExtensions.MostAdequatePositionForHeight(194));
      Assert.AreEqual(ST_PlayerPositionEnum.SG, PlayerExtensions.MostAdequatePositionForHeight(195));
      Assert.AreEqual(ST_PlayerPositionEnum.SG, PlayerExtensions.MostAdequatePositionForHeight(198));
      Assert.AreEqual(ST_PlayerPositionEnum.SG, PlayerExtensions.MostAdequatePositionForHeight(199));
      Assert.AreEqual(ST_PlayerPositionEnum.SF, PlayerExtensions.MostAdequatePositionForHeight(200));
      Assert.AreEqual(ST_PlayerPositionEnum.SF, PlayerExtensions.MostAdequatePositionForHeight(203));
      Assert.AreEqual(ST_PlayerPositionEnum.SF, PlayerExtensions.MostAdequatePositionForHeight(205));
      Assert.AreEqual(ST_PlayerPositionEnum.SF, PlayerExtensions.MostAdequatePositionForHeight(208));
      Assert.AreEqual(ST_PlayerPositionEnum.PF, PlayerExtensions.MostAdequatePositionForHeight(210));
      Assert.AreEqual(ST_PlayerPositionEnum.PF, PlayerExtensions.MostAdequatePositionForHeight(212));
      Assert.AreEqual(ST_PlayerPositionEnum.PF, PlayerExtensions.MostAdequatePositionForHeight(215));
      Assert.AreEqual(ST_PlayerPositionEnum.C, PlayerExtensions.MostAdequatePositionForHeight(217));
      Assert.AreEqual(ST_PlayerPositionEnum.C, PlayerExtensions.MostAdequatePositionForHeight(220));
      Assert.AreEqual(ST_PlayerPositionEnum.C, PlayerExtensions.MostAdequatePositionForHeight(225));
      Assert.AreEqual(ST_PlayerPositionEnum.C, PlayerExtensions.MostAdequatePositionForHeight(230));
    }

    /// <summary>
    ///A test for QualitativePositionsForHeight
    ///</summary>
    [TestMethod()]
    public void QualitativePositionForHeightTests ( )
    {
      CollectionAssert.AreEqual(new QPH[] {QPH.ShortPG},  PlayerExtensions.QualitativePositionsForHeight (170).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.ShortPG }, PlayerExtensions.QualitativePositionsForHeight(179).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.BelowAveragePG, QPH.ShortSG }, PlayerExtensions.QualitativePositionsForHeight(180).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.BelowAveragePG, QPH.ShortSG }, PlayerExtensions.QualitativePositionsForHeight(185).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.AboveAveragePG, QPH.ShortSG }, PlayerExtensions.QualitativePositionsForHeight(186).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.AboveAveragePG, QPH.ShortSG }, PlayerExtensions.QualitativePositionsForHeight(189).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.AboveAveragePG, QPH.BelowAverageSG }, PlayerExtensions.QualitativePositionsForHeight(190).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.AboveAveragePG, QPH.BelowAverageSG }, PlayerExtensions.QualitativePositionsForHeight(194).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.TallPG, QPH.AboveAverageSG, QPH.ShortSF }, PlayerExtensions.QualitativePositionsForHeight(195).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.TallPG, QPH.AboveAverageSG, QPH.ShortSF }, PlayerExtensions.QualitativePositionsForHeight(199).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.TallSG, QPH.BelowAverageSF }, PlayerExtensions.QualitativePositionsForHeight(200).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.TallSG, QPH.BelowAverageSF }, PlayerExtensions.QualitativePositionsForHeight(204).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.AboveAverageSF, QPH.BelowAveragePF, QPH.ShortC }, PlayerExtensions.QualitativePositionsForHeight(205).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.AboveAverageSF, QPH.BelowAveragePF, QPH.ShortC }, PlayerExtensions.QualitativePositionsForHeight(209).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.TallSF, QPH.BelowAveragePF, QPH.BelowAverageC }, PlayerExtensions.QualitativePositionsForHeight(210).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.TallSF, QPH.BelowAveragePF, QPH.BelowAverageC }, PlayerExtensions.QualitativePositionsForHeight(212).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.TallSF, QPH.AboveAveragePF, QPH.BelowAverageC }, PlayerExtensions.QualitativePositionsForHeight(213).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.TallSF, QPH.AboveAveragePF, QPH.BelowAverageC }, PlayerExtensions.QualitativePositionsForHeight(219).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.TallPF, QPH.AboveAverageC }, PlayerExtensions.QualitativePositionsForHeight(220).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.TallC }, PlayerExtensions.QualitativePositionsForHeight(230).ToArray());
    }

    [TestMethod()]
    public void QualitativePositionsForAge17AndHeightTests ( )
    {
      CollectionAssert.AreEqual(new QPH[] { QPH.ShortPG }, PlayerExtensions.QualitativePositionsForAgeAndHeight(17,170).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.BelowAveragePG, QPH.AboveAveragePG }, PlayerExtensions.QualitativePositionsForAgeAndHeight(17,179).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.BelowAveragePG, QPH.ShortSG }, PlayerExtensions.QualitativePositionsForAgeAndHeight(17,180).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.BelowAveragePG, QPH.ShortSG }, PlayerExtensions.QualitativePositionsForAgeAndHeight(17,185).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.AboveAveragePG, QPH.ShortSG }, PlayerExtensions.QualitativePositionsForAgeAndHeight(17,186).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.AboveAveragePG, QPH.ShortSG }, PlayerExtensions.QualitativePositionsForAgeAndHeight(17,189).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.AboveAveragePG, QPH.BelowAverageSG }, PlayerExtensions.QualitativePositionsForAgeAndHeight(17,190).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.AboveAveragePG, QPH.BelowAverageSG }, PlayerExtensions.QualitativePositionsForAgeAndHeight(17,194).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.TallPG, QPH.AboveAverageSG, QPH.ShortSF }, PlayerExtensions.QualitativePositionsForAgeAndHeight(17,195).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.TallPG, QPH.AboveAverageSG, QPH.ShortSF }, PlayerExtensions.QualitativePositionsForAgeAndHeight(17,199).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.TallSG, QPH.BelowAverageSF }, PlayerExtensions.QualitativePositionsForAgeAndHeight(17,200).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.TallSG, QPH.BelowAverageSF }, PlayerExtensions.QualitativePositionsForAgeAndHeight(17,204).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.AboveAverageSF, QPH.BelowAveragePF, QPH.ShortC }, PlayerExtensions.QualitativePositionsForAgeAndHeight(17,205).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.AboveAverageSF, QPH.BelowAveragePF, QPH.ShortC }, PlayerExtensions.QualitativePositionsForAgeAndHeight(17,209).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.TallSF, QPH.BelowAveragePF, QPH.BelowAverageC }, PlayerExtensions.QualitativePositionsForAgeAndHeight(17,210).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.TallSF, QPH.BelowAveragePF, QPH.BelowAverageC }, PlayerExtensions.QualitativePositionsForAgeAndHeight(17,212).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.TallSF, QPH.AboveAveragePF, QPH.BelowAverageC }, PlayerExtensions.QualitativePositionsForAgeAndHeight(17,213).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.TallSF, QPH.AboveAveragePF, QPH.BelowAverageC }, PlayerExtensions.QualitativePositionsForAgeAndHeight(17,219).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.TallPF, QPH.AboveAverageC }, PlayerExtensions.QualitativePositionsForAgeAndHeight(17,220).ToArray());
      CollectionAssert.AreEqual(new QPH[] { QPH.TallC }, PlayerExtensions.QualitativePositionsForAgeAndHeight(17,230).ToArray());
    }

    [TestMethod()]
    public void PotentialPositionForHeightTests ( )
    {
      CollectionAssert.AreEqual(new POS[] { POS.PG }, PlayerExtensions.PotentialPositionsForHeight(170).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG }, PlayerExtensions.PotentialPositionsForHeight(179).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG }, PlayerExtensions.PotentialPositionsForHeight(180).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG }, PlayerExtensions.PotentialPositionsForHeight(185).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG }, PlayerExtensions.PotentialPositionsForHeight(186).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG }, PlayerExtensions.PotentialPositionsForHeight(189).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG }, PlayerExtensions.PotentialPositionsForHeight(190).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG }, PlayerExtensions.PotentialPositionsForHeight(194).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG, POS.SF }, PlayerExtensions.PotentialPositionsForHeight(195).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG, POS.SF }, PlayerExtensions.PotentialPositionsForHeight(199).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.SG, POS.SF }, PlayerExtensions.PotentialPositionsForHeight(200).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.SG, POS.SF }, PlayerExtensions.PotentialPositionsForHeight(204).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.SF, POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForHeight(205).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.SF, POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForHeight(209).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.SF, POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForHeight(210).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.SF, POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForHeight(212).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.SF, POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForHeight(213).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.SF, POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForHeight(219).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForHeight(220).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.C }, PlayerExtensions.PotentialPositionsForHeight(230).ToArray());
    }

    [TestMethod()]
    public void AllPossiblePositionsBasedOnAgeOver18AndHeightTests()
    {
      CollectionAssert.AreEqual(new POS[] { POS.PG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(18, 170).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(19, 175).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(20, 180).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(21, 185).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(22, 190).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG, POS.SF }, PlayerExtensions.PotentialPositionsForAgeAndHeight(22, 195).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.SG, POS.SF }, PlayerExtensions.PotentialPositionsForAgeAndHeight(23, 200).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.SF, POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForAgeAndHeight(25, 205).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.SF, POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForAgeAndHeight(24, 210).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.SF, POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForAgeAndHeight(26, 215).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForAgeAndHeight(27, 220).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForAgeAndHeight(28, 225).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.C }, PlayerExtensions.PotentialPositionsForAgeAndHeight(29, 230).ToArray());
    }

    [TestMethod()]
    public void AllPossiblePositionsBasedOnAge15AndHeightTests ( )
    {     
        CollectionAssert.AreEqual(new POS[] { POS.PG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(15, 150).ToArray());
        CollectionAssert.AreEqual(new POS[] { POS.PG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(15, 155).ToArray());
        CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(15, 160).ToArray());
        CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(15, 165).ToArray());
        CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(15, 170).ToArray());
        CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG, POS.SF }, PlayerExtensions.PotentialPositionsForAgeAndHeight(15, 175).ToArray());
        CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG, POS.SF }, PlayerExtensions.PotentialPositionsForAgeAndHeight(15, 180).ToArray());
        CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG, POS.SF, POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForAgeAndHeight(15, 185).ToArray());
        CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG, POS.SF, POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForAgeAndHeight(15, 190).ToArray());
        CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG, POS.SF, POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForAgeAndHeight(15, 195).ToArray());
        CollectionAssert.AreEqual(new POS[] { POS.SG, POS.SF, POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForAgeAndHeight(15, 200).ToArray());
        CollectionAssert.AreEqual(new POS[] { POS.SF, POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForAgeAndHeight(15, 205).ToArray());
        CollectionAssert.AreEqual(new POS[] { POS.SF, POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForAgeAndHeight(15, 210).ToArray());
    }

    [TestMethod()]
    public void AllPossiblePositionsBasedOnAge16AndHeightTests ( )
    {
      CollectionAssert.AreEqual(new POS[] { POS.PG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(16, 150).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(16, 155).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(16, 160).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(16, 165).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(16, 170).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(16, 175).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(16, 180).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG, POS.SF }, PlayerExtensions.PotentialPositionsForAgeAndHeight(16, 185).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG, POS.SF }, PlayerExtensions.PotentialPositionsForAgeAndHeight(16, 190).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG, POS.SF, POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForAgeAndHeight(16, 195).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.SG, POS.SF, POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForAgeAndHeight(16, 200).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.SF, POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForAgeAndHeight(16, 205).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.SF, POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForAgeAndHeight(16, 210).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.SF, POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForAgeAndHeight(16, 217).ToArray());
    }

    [TestMethod()]
    public void AllPossiblePositionsBasedOnAge17AndHeightTests ( )
    {
      CollectionAssert.AreEqual(new POS[] { POS.PG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(17, 150).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(17, 155).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(17, 160).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(17, 165).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(17, 170).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(17, 175).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(17, 180).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG }, PlayerExtensions.PotentialPositionsForAgeAndHeight(17, 185).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG, POS.SF }, PlayerExtensions.PotentialPositionsForAgeAndHeight(17, 190).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PG, POS.SG, POS.SF }, PlayerExtensions.PotentialPositionsForAgeAndHeight(17, 195).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.SG, POS.SF, POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForAgeAndHeight(17, 200).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.SF, POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForAgeAndHeight(17, 205).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.SF, POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForAgeAndHeight(17, 210).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.SF, POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForAgeAndHeight(17, 215).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForAgeAndHeight(17, 220).ToArray());
      CollectionAssert.AreEqual(new POS[] { POS.PF, POS.C }, PlayerExtensions.PotentialPositionsForAgeAndHeight(17, 224).ToArray());
    }

  }
}
