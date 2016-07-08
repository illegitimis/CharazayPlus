
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
    static readonly IDecidePlayerPositionAlgorithm a1 = new TotalScoreAlgorithm();
    static readonly IDecidePlayerPositionAlgorithm a2 = new MostAdequatePositionByHeightAlgorithm();
    static readonly IDecidePlayerPositionAlgorithm a3 = new PotentialPlayerPositionAlgorithm();
    static readonly IDecidePlayerPositionAlgorithm smart = new DecidePlayerPositionAggregatorAlgorithm();
    static readonly IDecidePlayerPositionAlgorithm facets = new FacetsAlgorithm();

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
    [TestCategory("RegexParse")]
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
    [TestCategory("RegexParse")]
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
      var status = new charazayPlayerStatus() { };

      string pattern = @"(?<left>[^\r\n\t:]+):\s+(?<right>[^:\r\n\t]+)";
      Regex rgx = new Regex(pattern, RegexOptions.Multiline);
      foreach (Match match in rgx.Matches(input))
      {
        Group grp0 = match.Groups["left"];
        Group grp1 = match.Groups["right"];
        switch (grp0.Value)
        {
          case "Age": basic.age = byte.Parse(grp1.Value); break;
          case "Weight":
            basic.weight = decimal.Parse(grp1.Value, System.Globalization.CultureInfo.CreateSpecificCulture("ro-RO"));
            break;
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

          case "Form": status.form = byte.Parse(grp1.Value); break;
          case "Fatigue": status.fatigue = int.Parse(grp1.Value.Replace(" %", "")); break;

          default: break;
        }

      }

      return new charazayPlayer() { skills = skills, basic = basic, status = status };
    }

    [TestMethod]
    [TestCategory("RegexParse")]
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
    [TestCategory("RegexParse")]
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
    [TestCategory("RegexParse")]
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
    [TestCategory("RegexParse")]
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
    [TestCategory("smart")]
    [TestCategory("RegexParse")]
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

      var x = smart.Decide(eval, 3, false).ToList();
      Assert.IsNotNull(x);
      CollectionAssert.AllItemsAreInstancesOfType(x, typeof(Player));
      Assert.AreEqual(3, x.Count);

      var y = smart.Decide(eval, 3, true).ToList();
      Assert.IsNotNull(y);
      CollectionAssert.AllItemsAreInstancesOfType(y, typeof(Player));
      Assert.AreEqual(3, x.Count);
    }

    [TestMethod]
    [TestCategory("smart")]
    public void SorinDasanu_205946()
    {
      charazayPlayer p = ParseHtmlTextToPlayer(@"Age: 	15 		Fatigue: 	23 %
Height: 	207 		Weight: 	116,55
Skills Index: 	18.042 		Salary: 	€ 21.196
Defence: 	5 		Free Throws: 	4
Two Point: 	5 		Three Point: 	7
Dribbling: 	2 		Passing: 	4
Speed: 	5 		Footwork: 	9
Rebounds: 	7 		Experience: 	1");

      PlayerEvaluator eval = new PlayerEvaluator(p);

      var x = smart.Decide(eval, 3, false).ToList();
      Assert.IsNotNull(x);
      CollectionAssert.AllItemsAreInstancesOfType(x, typeof(Player));
      Assert.AreEqual(3, x.Count);
      Assert.AreEqual(x[0].PositionEnum, ST_PlayerPositionEnum.C);
      Assert.AreEqual(x[0].ValueIndex, 1.1, 0.01);
      Assert.AreEqual(x[1].PositionEnum, ST_PlayerPositionEnum.PF);
      Assert.AreEqual(x[1].ValueIndex, 1.07, 0.01);

      var y = smart.Decide(eval, 3, true).ToList();
      Assert.IsNotNull(y);
      CollectionAssert.AllItemsAreInstancesOfType(y, typeof(Player));
      Assert.AreEqual(3, x.Count);
    }

    [TestMethod]
    [TestCategory("smart")]
    public void Ilea_Enescu_90435()
    {
      charazayPlayer p = ParseHtmlTextToPlayer(@"Age: 	16 		Fatigue: 	7 %
Height: 	173 		Weight: 	76,02
Skills Index: 	26.243 		Salary: 	€ 35.614
Defence: 	7 		Free Throws: 	7
Two Point: 	5 		Three Point: 	7
Dribbling: 	9 		Passing: 	6
Speed: 	9 		Footwork: 	3
Rebounds: 	4 		Experience: 	3");

      PlayerEvaluator eval = new PlayerEvaluator(p);

      var x = smart.Decide(eval, 3, false).ToList();
      Assert.IsNotNull(x);
      CollectionAssert.AllItemsAreInstancesOfType(x, typeof(Player));
      Assert.AreEqual(3, x.Count);
      Assert.AreEqual(x[0].PositionEnum, ST_PlayerPositionEnum.PG);
      Assert.AreEqual(x[0].ValueIndex, 1.12, 0.01);
      Assert.AreEqual(x[1].PositionEnum, ST_PlayerPositionEnum.SG);
      Assert.AreEqual(x[1].ValueIndex, 1.08, 0.01);

      var y = smart.Decide(eval, 3, true).ToList();
      Assert.IsNotNull(y);
      CollectionAssert.AllItemsAreInstancesOfType(y, typeof(Player));
      Assert.AreEqual(3, x.Count);
    }

    [TestMethod]
    [TestCategory("smart")]
    public void NicolaeIoanovici_167552()
    {
      charazayPlayer p = ParseHtmlTextToPlayer(@"Age: 	16 		Fatigue: 	7 %
Height: 	203 		Weight: 	113,33
Skills Index: 	28.639 		Salary: 	€ 43.742
Defence: 	8 		Free Throws: 	7
Two Point: 	6 		Three Point: 	7
Dribbling: 	5 		Passing: 	4
Speed: 	9 		Footwork: 	7
Rebounds: 	7 		Experience: 	3");

      PlayerEvaluator eval = new PlayerEvaluator(p);

      var x = smart.Decide(eval, 3, false).ToList();
      Assert.IsNotNull(x);
      CollectionAssert.AllItemsAreInstancesOfType(x, typeof(Player));
      Assert.AreEqual(3, x.Count);
      Assert.AreEqual(x[0].PositionEnum, ST_PlayerPositionEnum.SF);
      Assert.AreEqual(x[0].ValueIndex, 1.13, 0.01);
      Assert.AreEqual(x[1].PositionEnum, ST_PlayerPositionEnum.PF);
      Assert.AreEqual(x[1].ValueIndex, 1.10, 0.01);

      var y = smart.Decide(eval, 3, true).ToList();
      Assert.IsNotNull(y);
      CollectionAssert.AllItemsAreInstancesOfType(y, typeof(Player));
      Assert.AreEqual(3, x.Count);
    }

    [TestMethod]
    [TestCategory("smart")]
    public void CristianMavrocordat_90434()
    {
      charazayPlayer p = ParseHtmlTextToPlayer(@"Age: 	16 		Fatigue: 	7 %
Height: 	188 		Weight: 	77,76
Skills Index: 	34.526 		Salary: 	€ 41.894
Defence: 	8 		Free Throws: 	5
Two Point: 	6 		Three Point: 	6
Dribbling: 	10 		Passing: 	6
Speed: 	9 		Footwork: 	4
Rebounds: 	5 		Experience: 	3");

      PlayerEvaluator eval = new PlayerEvaluator(p);

      var x = smart.Decide(eval, 3, false).ToList();
      Assert.IsNotNull(x);
      CollectionAssert.AllItemsAreInstancesOfType(x, typeof(Player));
      Assert.AreEqual(3, x.Count);
      Assert.AreEqual(x[0].PositionEnum, ST_PlayerPositionEnum.PG);
      Assert.AreEqual(x[0].ValueIndex, 1.19, 0.01);
      Assert.AreEqual(x[1].PositionEnum, ST_PlayerPositionEnum.SG);
      Assert.AreEqual(x[1].ValueIndex, 1.16, 0.01);

      var y = smart.Decide(eval, 3, true).ToList();
      Assert.IsNotNull(y);
      CollectionAssert.AllItemsAreInstancesOfType(y, typeof(Player));
      Assert.AreEqual(3, x.Count);
    }

    [TestMethod]
    [TestCategory("RegexParse")]
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
    [TestCategory("RegexParse")]
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

    [TestMethod]
    public void StateBytes_SorinDasanu()
    {
      charazayPlayer p = ParseHtmlTextToPlayer(@"Form: 4
Age: 	15 		Fatigue: 	37 %
Height: 	207 		Weight: 	116,55
Skills Index: 	18.504 		Salary: 	€ 21.196
Defence: 	5 		Free Throws: 	4
Two Point: 	5 		Three Point: 	7
Dribbling: 	2 		Passing: 	4
Speed: 	5 		Footwork: 	9
Rebounds: 	7 		Experience: 	1");

      byte[] byteArray = new byte[15] { 
                p.basic.age,                //0
                p.basic.height,             //1
                (byte)p.basic.weight,       //2
                p.status.form,              //3
                (byte)p.status.fatigue,     //4 
                p.skills.defence,           //5
                p.skills.freethrow,         //6
                p.skills.twopoint,          //7
                p.skills.threepoint,        //8
                p.skills.dribling,          //9
                p.skills.passing,           //10
                p.skills.speed,             //11
                p.skills.footwork,          //12
                p.skills.rebounds,          //13
                p.skills.experience         //14
            };

      string b64s = Convert.ToBase64String(byteArray, 0, 15, Base64FormattingOptions.None);
      Assert.AreEqual("D890BCUFBAUHAgQFCQcB", b64s);
      byte[] result = Convert.FromBase64String(b64s);
      CollectionAssert.AreEqual(byteArray, result);

      byteArray = new byte[] { 15, 207, 116, 4, 37, 5, 4, 5, 7, 2, 4, 5, 9, 7, 1 };
      b64s = Convert.ToBase64String(byteArray, 0, 15, Base64FormattingOptions.None);
      Assert.AreEqual("D890BCUFBAUHAgQFCQcB", b64s);
      result = Convert.FromBase64String(b64s);
      CollectionAssert.AreEqual(byteArray, result);
    }

    [TestMethod]
    public void StateBytes_EmilioDiaz()
    {
      charazayPlayer p = ParseHtmlTextToPlayer(@"Age: 	27 		Fatigue: 	11 %
Height: 	190 		Weight: 	81,17
Skills Index: 	488.306 		Salary: 	€ 274.899
Defence: 	17 		Free Throws: 	9
Two Point: 	6 		Three Point: 	7
Dribbling: 	16 		Passing: 	6
Speed: 	24 		Footwork: 	5
Rebounds: 	4 		Experience: 	19");

      byte[] byteArray = new byte[15] { 
                p.basic.age,                //0
                p.basic.height,             //1
                (byte)p.basic.weight,       //2
                p.status.form,              //3
                (byte)p.status.fatigue,     //4 
                p.skills.defence,           //5
                p.skills.freethrow,         //6
                p.skills.twopoint,          //7
                p.skills.threepoint,        //8
                p.skills.dribling,          //9
                p.skills.passing,           //10
                p.skills.speed,             //11
                p.skills.footwork,          //12
                p.skills.rebounds,          //13
                p.skills.experience         //14
            };

      string b64s = Convert.ToBase64String(byteArray, 0, 15, Base64FormattingOptions.None);
      Assert.AreEqual("G75RAAsRCQYHEAYYBQQT", b64s);
      byte[] result = Convert.FromBase64String(b64s);
      CollectionAssert.AreEqual(byteArray, result);
    }

    [TestMethod]
    public void EmilioDiaz_Facets()
    {
      PlayerEvaluator eval = new PlayerEvaluator(ParseHtmlTextToPlayer(@"Age: 	27 		Fatigue: 	11 %
Height: 	190 		Weight: 	81,17
Skills Index: 	488.306 		Salary: 	€ 274.899
Defence: 	17 		Free Throws: 	9
Two Point: 	6 		Three Point: 	7
Dribbling: 	16 		Passing: 	6
Speed: 	24 		Footwork: 	5
Rebounds: 	4 		Experience: 	19"));

      var best2 = eval.Best2(facets).ToArray();
      Assert.AreEqual(ST_PlayerPositionEnum.PG, best2[0].PositionEnum);
      Assert.AreEqual(ST_PlayerPositionEnum.SG, best2[1].PositionEnum);

      best2 = eval.Best2(smart).ToArray();
      Assert.AreEqual(ST_PlayerPositionEnum.PG, best2[0].PositionEnum);
      Assert.AreEqual(ST_PlayerPositionEnum.SF, best2[1].PositionEnum);
    }

    [TestMethod]
    public void SorinDasanu_Facets()
    {
      PlayerEvaluator eval = new PlayerEvaluator(ParseHtmlTextToPlayer(@"Form: 4
Age: 	15 		Fatigue: 	37 %
Height: 	207 		Weight: 	116,55
Skills Index: 	18.504 		Salary: 	€ 21.196
Defence: 	5 		Free Throws: 	4
Two Point: 	5 		Three Point: 	7
Dribbling: 	2 		Passing: 	4
Speed: 	5 		Footwork: 	9
Rebounds: 	7 		Experience: 	1"));

      var best2 = eval.Best2(facets).ToArray();
      Assert.AreEqual(ST_PlayerPositionEnum.C, best2[0].PositionEnum);
      Assert.AreEqual(ST_PlayerPositionEnum.PF, best2[1].PositionEnum);

      best2 = eval.Best2(smart).ToArray();
      Assert.AreEqual(ST_PlayerPositionEnum.C, best2[0].PositionEnum);
      Assert.AreEqual(ST_PlayerPositionEnum.PF, best2[1].PositionEnum);
    }

    [TestMethod]
    public void ArnoMeyer_Facets()
    {
      PlayerEvaluator eval = new PlayerEvaluator(ParseHtmlTextToPlayer(@"Form: 5
Age: 	25 		Fatigue: 	11 %
Height: 	201 		Weight: 	91,22
Skills Index: 	212.207 		Salary: 	€ 165.796
Defence: 	19 		Free Throws: 	5
Two Point: 	5 		Three Point: 	4
Dribbling: 	10 		Passing: 	6
Speed: 	20 		Footwork: 	6
Rebounds: 	7 		Experience: 	15"));

      var best2 = eval.Best2(facets).ToArray();
      Assert.AreEqual(ST_PlayerPositionEnum.SF, best2[0].PositionEnum);
      Assert.AreEqual(ST_PlayerPositionEnum.SG, best2[1].PositionEnum);

      best2 = eval.Best2(smart).ToArray();
      Assert.AreEqual(ST_PlayerPositionEnum.SF, best2[0].PositionEnum);
      Assert.AreEqual(ST_PlayerPositionEnum.PG, best2[1].PositionEnum);
    }

    [TestMethod]
    public void SlobodanRistić_Facets()
    {
      PlayerEvaluator eval = new PlayerEvaluator(ParseHtmlTextToPlayer(@"Form: 6
Age: 	26 		Fatigue: 	11 %
Height: 	198 		Weight: 	95,21
Skills Index: 	295.726 		Salary: 	€ 232.515
Defence: 	22 		Free Throws: 	5
Two Point: 	8 		Three Point: 	6
Dribbling: 	9 		Passing: 	6
Speed: 	22 		Footwork: 	7
Rebounds: 	6 		Experience: 	17"));

      var best2 = eval.Best2(facets).ToArray();
      Assert.AreEqual(ST_PlayerPositionEnum.SG, best2[0].PositionEnum);
      Assert.AreEqual(ST_PlayerPositionEnum.SF, best2[1].PositionEnum);

      best2 = eval.Best2(smart).ToArray();
      Assert.AreEqual(ST_PlayerPositionEnum.SF, best2[0].PositionEnum);
      Assert.AreEqual(ST_PlayerPositionEnum.PG, best2[1].PositionEnum);
    }

    [TestMethod]
    public void TymoteuszMucha_Facets()
    {
      PlayerEvaluator eval = new PlayerEvaluator(ParseHtmlTextToPlayer(@"Form: 5
Age: 	17 		Fatigue: 	4 %
Height: 	180 		Weight: 	74,52
Skills Index: 	47.907 		Salary: 	€ 57.688
Defence: 	14 		Free Throws: 	6
Two Point: 	6 		Three Point: 	7
Dribbling: 	7 		Passing: 	9
Speed: 	8 		Footwork: 	3
Rebounds: 	5 		Experience: 	4"));

      var best2 = eval.Best2(facets).ToArray();
      Assert.AreEqual(ST_PlayerPositionEnum.PG, best2[0].PositionEnum);
      Assert.AreEqual(ST_PlayerPositionEnum.SG, best2[1].PositionEnum);

      best2 = eval.Best2(smart).ToArray();
      Assert.AreEqual(ST_PlayerPositionEnum.PG, best2[0].PositionEnum);
      Assert.AreEqual(ST_PlayerPositionEnum.SG, best2[1].PositionEnum);
    }

    [TestMethod]
    public void Alex_Jeffery_Facets()
    {
      PlayerEvaluator eval = new PlayerEvaluator(ParseHtmlTextToPlayer(@"Form: 5
Age: 	15 		Fatigue: 	0 %
Height: 	188 		Weight: 	77,53
Skills Index: 	21.864 		Salary: 	€ 28.567
Defence: 	9 		Free Throws: 	5
Two Point: 	7 		Three Point: 	5
Dribbling: 	7 		Passing: 	3
Speed: 	8 		Footwork: 	4
Rebounds: 	4 		Experience: 	2"));

      var best2 = eval.Best2(facets).ToArray();
      Assert.AreEqual(ST_PlayerPositionEnum.SF, best2[0].PositionEnum);
      Assert.AreEqual(ST_PlayerPositionEnum.SG, best2[1].PositionEnum);

      best2 = eval.Best2(smart).ToArray();
      Assert.AreEqual(ST_PlayerPositionEnum.SG, best2[0].PositionEnum);
      Assert.AreEqual(ST_PlayerPositionEnum.SF, best2[1].PositionEnum);
    }

    [TestMethod]
    public void Ferdinando_Ipsale_Facets()
    {
      PlayerEvaluator eval = new PlayerEvaluator(ParseHtmlTextToPlayer(@"Form: 1
Age: 	15 		Fatigue: 	0 %
Height: 	185 		Weight: 	88,64
Skills Index: 	14.941 		Salary: 	€ 21.030
Defence: 	6 		Free Throws: 	4
Two Point: 	5 		Three Point: 	7
Dribbling: 	4 		Passing: 	4
Speed: 	9 		Footwork: 	4
Rebounds: 	5 		Experience: 	0"));

      var best2 = eval.Best2(facets).ToArray();
      Assert.AreEqual(ST_PlayerPositionEnum.SG, best2[0].PositionEnum);
      Assert.AreEqual(ST_PlayerPositionEnum.SF, best2[1].PositionEnum);

      best2 = eval.Best2(smart).ToArray();
      Assert.AreEqual(ST_PlayerPositionEnum.SG, best2[0].PositionEnum);
      Assert.AreEqual(ST_PlayerPositionEnum.SF, best2[1].PositionEnum);
    }
  }
}
