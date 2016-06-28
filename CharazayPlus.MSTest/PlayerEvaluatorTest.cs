
namespace CharazayPlus.MSTest
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using AndreiPopescu.CharazayPlus.Utils;
    using AndreiPopescu.CharazayPlus.Xsd2;
    using AndreiPopescu.CharazayPlus;
    using AndreiPopescu.CharazayPlus.Model;

    [TestClass]
    public class PlayerEvaluatorTest
    {
        static readonly IDecidePlayerPositionAlgorithm a1 = new DecidePlayerPositionByTotalScoreAlgorithm();
        static readonly IDecidePlayerPositionAlgorithm a2 = new DecideMostAdequatePlayerPositionByHeightAlgorithm();
        static readonly IDecidePlayerPositionAlgorithm a3 = new DecidePotentialPlayerPositionAlgorithm();

        [TestMethod]
        public void AldoMariani ()
        {
            var xsdp = new charazayPlayer() { 
                skills = new charazayPlayerSkills() {
                    defence = 16,
                    dribling = 4,
                    experience = 27, 
                    footwork = 24, 
                    freethrow = 7,
                    passing = 6,
                    rebounds = 15,
                    speed = 9,
                    threepoint = 7,
                    twopoint = 10,
                },
                basic = new charazayPlayerBasic(){
                    age = 32,
                    height = 207,
                    name = "Aldo",
                    surname="Mariani",
                    weight = 110.34m
                }
            };
            var eval = new PlayerEvaluator(xsdp);
            Player p = null;
            p = eval.Best(a1);
            Assert.AreEqual(ST_PlayerPositionEnum.C, p.PositionEnum);
            p = eval.Best(a2);
            Assert.AreEqual(ST_PlayerPositionEnum.SF, p.PositionEnum);
            p = eval.Best(a3);
            Assert.AreEqual(ST_PlayerPositionEnum.C, p.PositionEnum);
            
        }

        [TestMethod]
        public void LeoFiru()
        {
            var xsdp = new charazayPlayer()
            {
                skills = new charazayPlayerSkills()
                {
                    defence = 5,
                    dribling = 5,
                    experience = 3,
                    footwork = 7,
                    freethrow = 5,
                    passing = 4,
                    rebounds = 6,
                    speed = 8,
                    threepoint = 6,
                    twopoint = 6,
                },
                basic = new charazayPlayerBasic()
                {
                    age = 16,
                    height = 210,
                    name = "Leo",
                    surname = "Firu",
                    weight = 119.07m
                }
            };
            var eval = new PlayerEvaluator(xsdp);
            Player p = null;
            p = eval.Best(a1);
            Assert.AreEqual(ST_PlayerPositionEnum.SF, p.PositionEnum);
            Assert.AreEqual(6.8, p.TotalScore, 0.01);
            p = eval.Best(a2);
            Assert.AreEqual(ST_PlayerPositionEnum.SF, p.PositionEnum);
            Assert.AreEqual(6.8, p.TotalScore, 0.01);
            p = eval.Best(a3);
            Assert.AreEqual(ST_PlayerPositionEnum.C, p.PositionEnum);
            Assert.AreEqual(6.8, p.TotalScore, 0.01);

        }
    }
}
