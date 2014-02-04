namespace CharazayPlus.MSTest
{

    using charazay = AndreiPopescu.CharazayPlus.XsdMerge.charazay;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using System.Reflection;
    
#pragma warning disable
    /// <summary>
    ///This is a test class for matchTest and is intended
    ///to contain all matchTest Unit Tests
    ///</summary>
    [TestClass()]
    public class XsdMerge
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
        /*
        public string BasePath
        {
          get
          {
            if (Directory.Exists(xmlBasePath))
              return xmlBasePath;
            else if (Directory.Exists(xmlBasePath2))
              return xmlBasePath2;
            else
              return @".\";
          }          
        }
        */
        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {

        }
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

        /*
        /// <summary>
        ///A test for AwayTeamName
        ///</summary>
        [TestMethod()]
        public void MatchDeserializeTest()
        {
            string dir = Path.Combine(xmlBasePath, Match);
            Assert.IsTrue (Directory.Exists(dir)) ;
            var matchXmls = Directory.GetFiles(dir, "*.xml");
            Assert.IsNotNull(matchXmls);
            Assert.IsTrue(matchXmls.Count() > 0);
            using (FileStream fs = new FileStream(matchXmls.First(), FileMode.Open, FileAccess.Read))
            {
                var srlz = new XmlSerializer(typeof(charazay));
                charazay o = (charazay)srlz.Deserialize(fs);
                Assert.IsNotNull(o);
                Assert.IsNotNull(o.match);
            }            
        }

        [TestMethod()]
        public void MatchSerializeTest1()
        {
            charazay o = new charazay() { Items = new object[] { new match() { id = 0 } } };
            string path = Path.Combine(BasePath, DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")+".xml");
                 
            using (FileStream fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write))
            {
                var srlz = new XmlSerializer(typeof(charazay));

                srlz.Serialize(fs, o);                
            }
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var srlz = new XmlSerializer(typeof(charazay));
                o = (charazay)srlz.Deserialize(fs);
                Assert.IsNotNull(o);
                Assert.IsNotNull(o.match);
            }
        }
        */

        private charazay DeserializeEmbeddedXml(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "CharazayPlus.MSTest." + fileName;
            charazay obj = null;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                obj = (charazay)(new XmlSerializer(typeof(charazay)).Deserialize(stream));
            }
            return obj;
        }

        //UserInfo_Cvbe.xml
        [TestMethod()]
        public void DeserializeUserInfoCvbe()
        {
            charazay obj = DeserializeEmbeddedXml("UserInfo_Cvbe.xml");
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.User);
            Assert.AreEqual(obj.User.countryid, 6);
            Assert.AreEqual(obj.User.id, 345587u);
            Assert.AreEqual(obj.User.last_active, 0u);

            Assert.AreEqual(obj.User.name, "cvbe");
            Assert.AreEqual(obj.User.registered, 1356443881u);
            Assert.AreEqual(obj.User.supporter, "no");
            Assert.AreEqual(obj.User.teamid, 57711u);

        }

        //TeamInfo_Cvbe.xml
        [TestMethod()]
        public void DeserializeTeamInfoCvbe()
        {
            charazay obj = DeserializeEmbeddedXml("TeamInfo_Cvbe.xml");
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.Team);
            Assert.AreEqual(obj.Team.id, 57711u);
            Assert.AreEqual(obj.Team.countryid, 6);
            Assert.AreEqual(obj.Team.userid, 345587u);
            Assert.IsNotNull(obj.Team.team_info);
            Assert.AreEqual(obj.Team.team_info.arenaid, 57711u);
            Assert.AreEqual(obj.Team.team_info.rival, 38088u);
            Assert.IsNotNull(obj.Team.team_info.fanclub);
            Assert.IsNotNull(obj.Team.team_info.training);
        }


        //ArenaInfo_20120726_21191.xml
        [TestMethod()]
        public void DeserializeArenaInfo_20120726_21191()
        {
            charazay obj = DeserializeEmbeddedXml("ArenaInfo_20120726_21191.xml");
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.Arena);
            Assert.AreEqual(obj.Arena.id, 21191u);
            Assert.AreEqual(obj.Arena.spectators, 15600u);
            Assert.AreEqual(obj.Arena.vips, 540u);
            Assert.AreEqual(obj.Arena.name, "Rim Top");
        }

        //Coaches_stergein_20140128.xml
        [TestMethod()]
        public void DeserializeCoaches_stergein_20140128()
        {
            charazay obj = DeserializeEmbeddedXml("Coaches_stergein_20140128.xml");
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.Coaches);
            Assert.IsNotNull(obj.Coaches.coach);
            Assert.AreEqual(obj.Coaches.coach.Length, 1);
            Assert.IsNotNull(obj.Coaches.coach[0]);
            Assert.IsNotNull(obj.Coaches.coach[0].basic);
            Assert.IsNotNull(obj.Coaches.coach[0].skills);
            //        
            Assert.AreEqual(obj.Coaches.coach[0].id, 2000018u);
            Assert.AreEqual(obj.Coaches.coach[0].countryid, 21);
            Assert.AreEqual(obj.Coaches.coach[0].teamid, 21191u);
            Assert.AreEqual(obj.Coaches.coach[0].price, 6224400u);
            Assert.AreEqual(obj.Coaches.coach[0].salary, 185250u);
        }

        //CountryInfo_20140128_5_1.xml
        [TestMethod()]
        public void Deserialize_CountryInfo_20140128_5_1()
        {
            charazay obj = DeserializeEmbeddedXml("CountryInfo_20140128_5_1.xml");
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.Country);
            Assert.IsNotNull(obj.Country.division);
            Assert.IsNotNull(obj.Country.division[0]);
            Assert.AreEqual(obj.Country.division.Length, 31);
            //
            Assert.AreEqual(obj.Country.division[0].countryid, 5);
            Assert.AreEqual(obj.Country.division[0].id, 1013u);
            Assert.AreEqual(obj.Country.division[0].level, 1);
            Assert.AreEqual(obj.Country.division[0].lh, (ushort)251);
        }

        //DivisionInfo_20140128_1013.xml
        [TestMethod()]
        public void Deserialize_DivisionInfo_20140128_1013()
        {
            charazay obj = DeserializeEmbeddedXml("DivisionInfo_20140128_1013.xml");
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.Division);
            Assert.IsNotNull(obj.Division.standings);
            Assert.IsNotNull(obj.Division.standings[0]);
            Assert.AreEqual(obj.Division.standings.Length, 16);
            //
            Assert.AreEqual(obj.Division.standings[15].position, 16);
            Assert.AreEqual(obj.Division.standings[15].owner, 38705u);
            Assert.AreEqual(obj.Division.standings[15].teamid, 27862u);
            Assert.AreEqual(obj.Division.standings[15].points_against, (ushort)1354);
        }

        //DivisionSchedule_20140128_1013.xml
        [TestMethod()]
        public void Deserialize_DivisionSchedule_20140128_1013()
        {
            charazay obj = DeserializeEmbeddedXml("DivisionSchedule_20140128_1013.xml");
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.Schedule);
            Assert.IsNotNull(obj.Schedule.round);
            Assert.AreEqual<byte>(obj.Schedule.round[0].number, 1);
            Assert.AreEqual<uint>(obj.Schedule.round[2].date, 1386430200u);
            Assert.AreEqual<uint>(obj.Schedule.round[3].match.id, 22656044u);
        }

        //Economy_stergein_20140128.xml
        [TestMethod()]
        public void Deserialize_Economy_stergein_20140128()
        {
            charazay obj = DeserializeEmbeddedXml("Economy_stergein_20140128.xml");
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.Economy);
            Assert.IsNotNull(obj.Economy.economy_season);
            Assert.IsNotNull(obj.Economy.economy_week);
            Assert.IsNotNull(obj.Economy.economy_season.income);
            Assert.IsNotNull(obj.Economy.economy_season.expences);
            Assert.IsNotNull(obj.Economy.economy_week.income);
            Assert.IsNotNull(obj.Economy.economy_week.expences);
            //
            Assert.AreEqual<uint>(obj.Economy.economy_season.income.merchandise, 4975425u);
            Assert.AreEqual<uint>(obj.Economy.economy_season.expences.facility, 1956000u);
            Assert.AreEqual<uint>(obj.Economy.economy_week.expences.maintenance, 370178u);
        }

        //Match_18611008.xml
        [TestMethod()]
        public void Deserialize_Match_18611008()
        {
            charazay obj = DeserializeEmbeddedXml("Match_18611008.xml");
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.Match);
            Assert.IsNotNull(obj.Match.teams);
            Assert.IsNotNull(obj.Match.stats);
            Assert.IsNotNull(obj.Match.bballs);
            Assert.IsNotNull(obj.Match.lineup);
            Assert.IsNotNull(obj.Match.stats.away);
            Assert.IsNotNull(obj.Match.stats.home);
            Assert.IsNotNull(obj.Match.bballs.home);
            Assert.IsNotNull(obj.Match.lineup.home);
            Assert.IsNotNull(obj.Match.bballs.away);
            Assert.IsNotNull(obj.Match.lineup.away);
        }

        //PlayerInfo_2459629.xml
        [TestMethod()]
        public void Deserialize_PlayerInfo_2459629()
        {
            charazay obj = DeserializeEmbeddedXml("PlayerInfo_2459629.xml");
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.Player);
            Assert.IsNotNull(obj.Player.basic);
            Assert.IsNotNull(obj.Player.skills);
            Assert.IsNotNull(obj.Player.status);
            //
            Assert.AreEqual(obj.Player.teamid, 42179u);
            Assert.AreEqual(obj.Player.promoted_on, 1189887308u);
            Assert.AreEqual(obj.Player.basic.weight, (decimal)73.5707);
            Assert.AreEqual(obj.Player.skills.speed, 19);
            Assert.AreEqual(obj.Player.status.si, 388299u);
        }

        //Players_stergein_20140128.xml
        [TestMethod()]
        public void Deserialize_Players_stergein_20140128()
        {
            charazay obj = DeserializeEmbeddedXml("Players_stergein_20140128.xml");
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.Players);
            Assert.IsNotNull(obj.Players.player);
            Assert.IsNotNull(obj.Players.player[0]);
            Assert.IsNotNull(obj.Players.player[0].basic);
            Assert.IsNotNull(obj.Players.player[0].skills);
            Assert.IsNotNull(obj.Players.player[0].status);
            //
            Assert.AreEqual(obj.Players.player[obj.Players.player.Length - 1].teamid, 21191u);
        }

        //Schedule_stergein_20140128.xml
        [TestMethod()]
        public void Deserialize_Schedule_stergein_20140128()
        {
            charazay obj = DeserializeEmbeddedXml("Schedule_stergein_20140128.xml");
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.Matches);
            Assert.IsNotNull(obj.Matches.match);
            Assert.IsNotNull(obj.Matches.match[0]);
            Assert.IsNotNull(obj.Matches.match[0].teams);
            //
            Assert.AreEqual(obj.Matches.match[3].leagueid, 1013u);
        }

        //TeamTransfers_20140128.xml
        [TestMethod()]
        public void Deserialize_TeamTransfers_20140128()
        {
            charazay obj = DeserializeEmbeddedXml("TeamTransfers_20140128.xml");
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.Transfers);
            Assert.IsNotNull(obj.Transfers.transfer);
            Assert.IsNotNull(obj.Transfers.transfer[0]);
            //
            Assert.AreEqual(obj.Transfers.transfer[2].playerid, 4113311u);
            Assert.AreEqual(obj.Transfers.transfer[2].sellteam, 46912u);
        }

        //UserInfo_20140128.xml    
        [TestMethod()]
        public void Deserialize_UserInfo_20140128()
        {
            charazay obj = DeserializeEmbeddedXml("UserInfo_20140128.xml");
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.User);
            Assert.AreEqual(obj.User.countryid, 5);
            Assert.AreEqual(obj.User.id, 33039u);
            Assert.AreEqual(obj.User.last_active, 1266659428u);

            Assert.AreEqual(obj.User.name, "stergein");
            Assert.AreEqual(obj.User.registered, 1143677349u);
            Assert.AreEqual(obj.User.supporter, "no");
            Assert.AreEqual(obj.User.teamid, 21191u);

        }

        //TeamInfo_20140128.xml
        [TestMethod()]
        public void Deserialize_TeamInfo_20140128()
        {
            charazay obj = DeserializeEmbeddedXml("TeamInfo_20140128.xml");
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.Team);
            Assert.AreEqual(obj.Team.id, 21191u);
            Assert.AreEqual(obj.Team.countryid, 5);
            Assert.AreEqual(obj.Team.userid, 33039u);
            Assert.IsNotNull(obj.Team.team_info);
            Assert.AreEqual(obj.Team.team_info.arenaid, 21191u);
            Assert.AreEqual(obj.Team.team_info.rival, 13532u);
            Assert.IsNotNull(obj.Team.team_info.fanclub);
            Assert.IsNotNull(obj.Team.team_info.training);
        }

    }

#pragma warning restore
  }
