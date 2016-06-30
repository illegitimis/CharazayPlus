
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
    using System.Text.RegularExpressions;

    [TestClass]
    public class PlayerEvaluatorTest
    {
        static readonly IDecidePlayerPositionAlgorithm a1 = new DecidePlayerPositionByTotalScoreAlgorithm();
        static readonly IDecidePlayerPositionAlgorithm a2 = new DecideMostAdequatePlayerPositionByHeightAlgorithm();
        static readonly IDecidePlayerPositionAlgorithm a3 = new DecidePotentialPlayerPositionAlgorithm();

        [TestMethod]
        public void AldoMariani()
        {
            var xsdp = new charazayPlayer()
            {
                skills = new charazayPlayerSkills()
                {
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
                basic = new charazayPlayerBasic()
                {
                    age = 32,
                    height = 207,
                    name = "Aldo",
                    surname = "Mariani",
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
                    passing = 9,
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

        static void Eval(PlayerEvaluator eval, IDecidePlayerPositionAlgorithm algo, ST_PlayerPositionEnum pos, double total)
        {
            Player p = eval.Best(algo);
            Assert.AreEqual(pos, p.PositionEnum);
            Assert.AreEqual(total, p.TotalScore, 0.01);
        }
        static void Eval(charazayPlayer xsdp, IDecidePlayerPositionAlgorithm algo, ST_PlayerPositionEnum pos, double total)
        {
            PlayerEvaluator eval = new PlayerEvaluator(xsdp);
            Player p = eval.Best(algo);
            Assert.AreEqual(pos, p.PositionEnum);
            Assert.AreEqual(total, p.TotalScore, 0.01);
        }

        [TestMethod]
        public void TahaMungar_41778287()
        {
            charazayPlayer p = ParseHtmlTextToPlayer(@"
Team Name: 	3Soldi
Fame: 	Barely Known
Suggested Positions: 	Small Forward
Shooting Guard
Form: 5
Age: 	16 		Fatigue: 	45 %
Height: 	190 		Weight: 	85,56
Skills Index: 	29.754 		Salary: 	€ 44.780
Defence: 	11 		Free Throws: 	6
Two Point: 	6 		Three Point: 	5
Dribbling: 	7 		Passing: 	6
Speed: 	7 		Footwork: 	8
Rebounds: 	3 		Experience: 	2");
            Eval(p, a1, ST_PlayerPositionEnum.PG, 8.02);
            Eval(p, a2, ST_PlayerPositionEnum.SG, 7.64);
            Eval(p, a3, ST_PlayerPositionEnum.PG, 8.02);
        }

        [TestMethod]
        public void LuigiPinelli41809360()
        {
            charazayPlayer p = ParseHtmlTextToPlayer(@"Team Name: 	3Soldi
Fame: 	Barely Known
Suggested Positions: 	Small Forward
Shooting Guard
Form: 5
Age: 	16 		Fatigue: 	93 %
Height: 	194 		Weight: 	86,19
Skills Index: 	24.743 		Salary: 	€ 29.005
Defence: 	10 		Free Throws: 	4
Two Point: 	5 		Three Point: 	5
Dribbling: 	8 		Passing: 	3
Speed: 	8 		Footwork: 	6
Rebounds: 	5 		Experience: 	3");
            Eval(p, a1, ST_PlayerPositionEnum.SF, 7.77);
            Eval(p, a2, ST_PlayerPositionEnum.SF, 7.77);
            Eval(p, a3, ST_PlayerPositionEnum.SF, 7.77);
        }

        charazayPlayer ParseHtmlTextToPlayer(string input)
        {
            var basic = new charazayPlayerBasic() { };
            var skills = new charazayPlayerSkills() { };

            string pattern = @"(?<left>[^\r\n\t:]+):\s+(?<right>[^:\r\n\t]+)";
            Regex rgx = new Regex(pattern, RegexOptions.Multiline);
            foreach (Match match in rgx.Matches(input))
            {
                Group grp0 = match.Groups["left"];
                Group grp1 = match.Groups["right"];
                switch (grp0.Value)
                {
                    case "Age": basic.age = byte.Parse(grp1.Value); break;
                    case "Weight": basic.weight = decimal.Parse(grp1.Value, System.Globalization.CultureInfo.CreateSpecificCulture("ro-RO")); ; break;
                    case "Height": basic.height = byte.Parse(grp1.Value); break;

                    case "Defence": skills.defence = byte.Parse(grp1.Value); break;
                    case "Free Throws": skills.freethrow = byte.Parse(grp1.Value); break;
                    case "Two Point": skills.twopoint = byte.Parse(grp1.Value); break;
                    case "Three Point": skills.threepoint = byte.Parse(grp1.Value); break;
                    case "Dribbling": skills.dribling = byte.Parse(grp1.Value); break;
                    case "Passing": skills.passing = byte.Parse(grp1.Value); break;
                    case "Speed": skills.speed = byte.Parse(grp1.Value); break;
                    case "Footwork": skills.footwork = byte.Parse(grp1.Value); break;
                    case "Rebounds": skills.rebounds = byte.Parse(grp1.Value); break;
                    case "Experience": skills.experience = byte.Parse(grp1.Value); break;

                    default: break;
                }

            }

            return new charazayPlayer() { skills = skills, basic = basic };
        }

        [TestMethod]
        public void ManuelTeixeira_41850561()
        {
            charazayPlayer p = ParseHtmlTextToPlayer(@"Team Name: 	Burning Lions
Fame: 	Unknown Player
Suggested Positions: 	Small Forward
Shooting Guard
Form: 3
Age: 	16 		Fatigue: 	0 %
Height: 	190 		Weight: 	88,08
Skills Index: 	17.551 		Salary: 	€ 21.412
Defence: 	5 		Free Throws: 	4
Two Point: 	6 		Three Point: 	6
Dribbling: 	4 		Passing: 	2
Speed: 	11 		Footwork: 	6
Rebounds: 	4 		Experience: 	1");
            Eval(p, a1, ST_PlayerPositionEnum.SF, 6.58);
            Eval(p, a2, ST_PlayerPositionEnum.SG, 6.37);
            Eval(p, a3, ST_PlayerPositionEnum.SF, 6.58);
        }

        [TestMethod]
        public void GuglielmoDowntownFerrero41823184()
        {
            charazayPlayer p = ParseHtmlTextToPlayer(@"Age: 	16 		Fatigue: 	5 %
Height: 	196 		Weight: 	95,95
Skills Index: 	28.754 		Salary: 	€ 36.874
Defence: 	12 		Free Throws: 	7
Two Point: 	8 		Three Point: 	5
Dribbling: 	5 		Passing: 	4
Speed: 	5 		Footwork: 	4
Rebounds: 	7 		Experience: 	3");
            Eval(p, a1, ST_PlayerPositionEnum.PG, 7.28);
            Eval(p, a2, ST_PlayerPositionEnum.SF, 7.19);
            Eval(p, a3, ST_PlayerPositionEnum.SF, 7.19);
        }

        [TestMethod]
        public void AdolisPacenka_41884742()
        {
            charazayPlayer p = ParseHtmlTextToPlayer(@"Age: 	15 		Fatigue: 	0 %
Height: 	185 		Weight: 	83,17
Skills Index: 	19.355 		Salary: 	€ 26.928
Defence: 	6 		Free Throws: 	5
Two Point: 	7 		Three Point: 	5
Dribbling: 	7 		Passing: 	3
Speed: 	9 		Footwork: 	4
Rebounds: 	4 		Experience: 	2");
            Eval(p, a1, ST_PlayerPositionEnum.SG, 6.75);
            Eval(p, a2, ST_PlayerPositionEnum.SG, 6.75);
            Eval(p, a3, ST_PlayerPositionEnum.SG, 6.75);
        }

        [TestMethod]
        public void NachoCancino_41886522()
        {
            charazayPlayer p = ParseHtmlTextToPlayer(@"Age: 	15 		Fatigue: 	0 %
Height: 	189 		Weight: 	87,87
Skills Index: 	21.177 		Salary: 	€ 29.384
Defence: 	7 		Free Throws: 	5
Two Point: 	6 		Three Point: 	7
Dribbling: 	6 		Passing: 	4
Speed: 	9 		Footwork: 	4
Rebounds: 	6 		Experience: 	0");
            Eval(p, a1, ST_PlayerPositionEnum.SG, 6.52);
            Eval(p, a2, ST_PlayerPositionEnum.SF, 6.5);
            Eval(p, a3, ST_PlayerPositionEnum.SG, 6.52);
        }

        [TestMethod]
        public void ManueleBonvicini_41832680()
        {
            charazayPlayer p = ParseHtmlTextToPlayer(@"Age: 	15 		Fatigue: 	2 %
Height: 	193 		Weight: 	88,65
Skills Index: 	23.589 		Salary: 	€ 27.825
Defence: 	6 		Free Throws: 	5
Two Point: 	7 		Three Point: 	5
Dribbling: 	7 		Passing: 	4
Speed: 	11 		Footwork: 	3
Rebounds: 	6 		Experience: 	2");
            Eval(p, a1, ST_PlayerPositionEnum.SG, 7.48);
            Eval(p, a2, ST_PlayerPositionEnum.SF, 7.34);
            Eval(p, a3, ST_PlayerPositionEnum.SF, 7.34);

            PlayerEvaluator eval = new PlayerEvaluator(p);
            var smart = new Smart();
            var x = smart.Decide(eval, 2, false).ToList();
            var y = smart.Decide(eval, 2, true).ToList();

        }

        [TestMethod]
        public void EgeSavçýn_41890289()
        {
            charazayPlayer p = ParseHtmlTextToPlayer(@"Age: 	15 		Fatigue: 	0 %
Height: 	196 		Weight: 	87,97
Skills Index: 	7.462 		Salary: 	€ 9.850
Defence: 	3 		Free Throws: 	6
Two Point: 	1 		Three Point: 	2
Dribbling: 	2 		Passing: 	5
Speed: 	6 		Footwork: 	4
Rebounds: 	4 		Experience: 	0");
            Eval(p, a1, ST_PlayerPositionEnum.SF, 3.97);
            Eval(p, a2, ST_PlayerPositionEnum.SF, 3.97);
            Eval(p, a3, ST_PlayerPositionEnum.SF, 3.97);
        }

        [TestMethod]
        public void MassimilianoDeZotti_41849918()
        {
            charazayPlayer p = ParseHtmlTextToPlayer(@"Age: 	15 		Fatigue: 	0 %
Height: 	202 		Weight: 	110,10
Skills Index: 	24.626 		Salary: 	€ 29.005
Defence: 	7 		Free Throws: 	5
Two Point: 	7 		Three Point: 	5
Dribbling: 	3 		Passing: 	5
Speed: 	8 		Footwork: 	10
Rebounds: 	5 		Experience: 	2");
            PlayerEvaluator eval = new PlayerEvaluator(p);
            var l1 = eval.Best2(a1).ToList();
            var l2 = eval.Best2(a2).ToList();
            var l3 = eval.Best2(a3).ToList();
        }

        class Pair
        {
            public ST_PlayerPositionEnum Pos { get; set; }
            public double Score { get; set; }
        }

        [TestMethod]
        public void xxx ()
        {
           
            Pair p1 = new Pair() { Pos = ST_PlayerPositionEnum.PG, Score = 1 };
            Pair p2 = new Pair() { Pos = ST_PlayerPositionEnum.SG, Score = 1 };
            Pair p3 = new Pair() { Pos = ST_PlayerPositionEnum.SF, Score = 1 };
            var l = new[] { p1, p1, p1, p2, p2, p3, p3, p3 };

            var grouped = l.ToLookup(x => x);
            var maxRepetitions = grouped.Max(x => x.Count());
            var maxRepeatedItems = grouped
                .Where(x => x.Count() == maxRepetitions)
                .Select(x => x.Key);
            var maxScore = maxRepeatedItems.Max(x => x.Score);
            var pair = maxRepeatedItems
                .Where(x => x.Score == maxScore)
                .First();

            var q = from p in l
                    group p by p.Pos into g
                    orderby g.Count() descending
                    select new { Count = g.Count(), Item = g } ;

            var t = q.Take(2);

        }

    }
}
