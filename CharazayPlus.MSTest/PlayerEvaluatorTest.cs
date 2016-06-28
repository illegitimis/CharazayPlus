
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
            Assert.AreEqual(ST_PlayerPositionEnum.C, p.PositionEnum);
            Assert.AreEqual(6.65, p.TotalScore, 0.01);
            p = eval.Best(a3);
            Assert.AreEqual(ST_PlayerPositionEnum.SF, p.PositionEnum);
            Assert.AreEqual(6.8, p.TotalScore, 0.01);
        }

        [TestMethod]
        public void TymoteuszMucha()
        {
            var xsdp = new charazayPlayer()
            {
                skills = new charazayPlayerSkills()
                {
                    defence = 14,
                    dribling = 7,
                    experience = 4,
                    footwork = 3,
                    freethrow = 6,
                    passing =9,
                    rebounds = 5,
                    speed = 8,
                    threepoint = 7,
                    twopoint = 6,
                },
                basic = new charazayPlayerBasic()
                {
                    age = 17,
                    height = 180,
                    name = "Tymoteusz",
                    surname = "Mucha",
                    weight = 74.52m
                }
            };
            var eval = new PlayerEvaluator(xsdp);
            Player p = null;
            p = eval.Best(a1);
            Assert.AreEqual(ST_PlayerPositionEnum.PG, p.PositionEnum);
            Assert.AreEqual(9.56, p.TotalScore, 0.01);
            p = eval.Best(a2);
            Assert.AreEqual(ST_PlayerPositionEnum.PG, p.PositionEnum);
            Assert.AreEqual(9.56, p.TotalScore, 0.01);
            p = eval.Best(a3);
            Assert.AreEqual(ST_PlayerPositionEnum.PG, p.PositionEnum);
            Assert.AreEqual(9.56, p.TotalScore, 0.01);
        }

        [TestMethod]
        public void JezdimirHajdarpašić()
        {
            var xsdp = new charazayPlayer()
            {
                skills = new charazayPlayerSkills()
                {
                    defence = 7,
                    dribling = 3,
                    experience = 2,
                    footwork = 8,
                    freethrow = 7,
                    passing = 5,
                    rebounds = 6,
                    speed = 8,
                    threepoint = 5,
                    twopoint = 7,
                },
                basic = new charazayPlayerBasic()
                {
                    age = 15,
                    height = 205,
                    name = "Jezdimir",
                    surname = "Hajdarpašić",
                    weight = 98.76m
                }
            };
            var eval = new PlayerEvaluator(xsdp);
            Player p = null;
            p = eval.Best(a1);
            Assert.AreEqual(ST_PlayerPositionEnum.C, p.PositionEnum);
            Assert.AreEqual(7.25, p.TotalScore, 0.01);
            p = eval.Best(a2);
            Assert.AreEqual(ST_PlayerPositionEnum.C, p.PositionEnum);
            Assert.AreEqual(7.25, p.TotalScore, 0.01);
            p = eval.Best(a3);
            Assert.AreEqual(ST_PlayerPositionEnum.C, p.PositionEnum);
            Assert.AreEqual(7.25, p.TotalScore, 0.01);
        }

        [TestMethod]
        public void TihomirHaramija()
        {
            var xsdp = new charazayPlayer()
            {
                skills = new charazayPlayerSkills()
                {
                    defence = 8,
                    dribling = 6,
                    experience = 2,
                    footwork = 9,
                    freethrow = 7,
                    passing = 4,
                    rebounds = 4,
                    speed = 7,
                    threepoint = 6,
                    twopoint = 7,
                },
                basic = new charazayPlayerBasic()
                {
                    age = 15,
                    height = 197,
                    name = "Tihomir",
                    surname = "Haramija",
                    weight = 103.89m
                }
            };
            var eval = new PlayerEvaluator(xsdp);
            Player p = null;
            p = eval.Best(a1);
            Assert.AreEqual(ST_PlayerPositionEnum.PF, p.PositionEnum);
            Assert.AreEqual(7.37, p.TotalScore, 0.01);
            p = eval.Best(a2);
            Assert.AreEqual(ST_PlayerPositionEnum.PF, p.PositionEnum);
            Assert.AreEqual(7.37, p.TotalScore, 0.01);
            p = eval.Best(a3);
            Assert.AreEqual(ST_PlayerPositionEnum.PF, p.PositionEnum);
            Assert.AreEqual(7.37, p.TotalScore, 0.01);
        }

        [TestMethod]
        public void RobertUdarević()
        {
            var xsdp = new charazayPlayer()
            {
                skills = new charazayPlayerSkills()
                {
                    defence = 8,
                    dribling = 4,
                    experience = 2,
                    footwork = 9,
                    freethrow = 6,
                    passing = 4,
                    rebounds = 7,
                    speed = 7,
                    threepoint = 7,
                    twopoint = 6,
                },
                basic = new charazayPlayerBasic()
                {
                    age = 15,
                    height = 204,
                    name = "Robert",
                    surname = "Udarević",
                    weight = 111.88m
                }
            };
            var eval = new PlayerEvaluator(xsdp);
            Player p = null;
            p = eval.Best(a1);
            Assert.AreEqual(ST_PlayerPositionEnum.C, p.PositionEnum);
            Assert.AreEqual(7.66, p.TotalScore, 0.01);
            p = eval.Best(a2);
            Assert.AreEqual(ST_PlayerPositionEnum.PF, p.PositionEnum);
            Assert.AreEqual(7.61, p.TotalScore, 0.01);
            p = eval.Best(a3);
            Assert.AreEqual(ST_PlayerPositionEnum.C, p.PositionEnum);
            Assert.AreEqual(7.66, p.TotalScore, 0.01);
        }

        [TestMethod]
        public void MamoruYamada()
        {
            var xsdp = new charazayPlayer()
            {
                skills = new charazayPlayerSkills()
                {
                    defence = 7,
                    dribling = 5,
                    experience = 2,
                    footwork = 4,
                    freethrow = 5,
                    passing = 9,
                    rebounds = 5,
                    speed = 7,
                    threepoint = 5,
                    twopoint = 7,
                },
                basic = new charazayPlayerBasic()
                {
                    age = 15,
                    height = 195,
                    name = "Mamoru",
                    surname = "Yamada",
                    weight = 83.52m
                }
            };
            var eval = new PlayerEvaluator(xsdp);
            Player p = null;
            p = eval.Best(a1);
            Assert.AreEqual(ST_PlayerPositionEnum.PG, p.PositionEnum);
            Assert.AreEqual(7.19, p.TotalScore, 0.01);
            p = eval.Best(a2);
            Assert.AreEqual(ST_PlayerPositionEnum.SF, p.PositionEnum);
            Assert.AreEqual(6.59, p.TotalScore, 0.01);
            p = eval.Best(a3);
            Assert.AreEqual(ST_PlayerPositionEnum.SF, p.PositionEnum);
            Assert.AreEqual(6.59, p.TotalScore, 0.01);
        }

        [TestMethod]
        public void FadilRadić()
        {
            var xsdp = new charazayPlayer()
            {
                skills = new charazayPlayerSkills()
                {
                    defence = 5,
                    dribling = 6,
                    experience = 3,
                    footwork = 6,
                    freethrow = 7,
                    passing = 4,
                    rebounds = 5,
                    speed = 9,
                    threepoint = 6,
                    twopoint = 8,
                },
                basic = new charazayPlayerBasic()
                {
                    age = 15,
                    height = 195,
                    name = "Fadil",
                    surname = "Radić",
                    weight = 98.10m
                }
            };
            var eval = new PlayerEvaluator(xsdp);
            Player p = null;
            p = eval.Best(a1);
            Assert.AreEqual(ST_PlayerPositionEnum.SG, p.PositionEnum);
            Assert.AreEqual(7.21, p.TotalScore, 0.01);
            p = eval.Best(a2);
            Assert.AreEqual(ST_PlayerPositionEnum.SF, p.PositionEnum);
            Assert.AreEqual(7.07, p.TotalScore, 0.01);
            p = eval.Best(a3);
            Assert.AreEqual(ST_PlayerPositionEnum.SF, p.PositionEnum);
            Assert.AreEqual(7.07, p.TotalScore, 0.01);
        }
    }
}
