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

        //static readonly string xmlBasePath = @"c:\Users\andreip.ROECR\AppData\Local\CharazayPlus\";
        //static readonly string xmlBasePath2 = @"c:\Users\Illegitimis\AppData\Local\CharazayPlus\";

        //static readonly string ArenaInfo = @"ArenaInfo";
        //static readonly string Coaches = @"Coaches";
        //static readonly string CountryInfo = @"CountryInfo";
        //static readonly string DivisionInfo = @"DivisionInfo";
        //static readonly string DivisionSchedule = @"DivisionSchedule";
        //static readonly string Economy = @"Economy";
        //static readonly string Match = @"Match";
        //static readonly string MyPlayersTL = @"MyPlayersTL";
        //static readonly string player = @"player";
        //static readonly string PlayerInfo = @"PlayerInfo";
        //static readonly string Players = @"Players";
        //static readonly string Schedule = @"Schedule";
        //static readonly string TeamInfo = @"TeamInfo";
        //static readonly string TeamTransfers = @"TeamTransfers";
        //static readonly string UserInfo = @"UserInfo";
        //static readonly string cachexml = @"cache.xml";

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
            Assert.IsNotNull(obj.user);
            Assert.AreEqual(obj.user.countryid, 6);
            Assert.AreEqual(obj.user.id, 345587u);
            Assert.AreEqual(obj.user.last_active, 0u);

            Assert.AreEqual(obj.user.name, "cvbe");
            Assert.AreEqual(obj.user.registered, 1356443881u);
            Assert.AreEqual(obj.user.supporter, "no");
            Assert.AreEqual(obj.user.teamid, 57711u);

        }

        //TeamInfo_Cvbe.xml
        [TestMethod()]
        public void DeserializeTeamInfoCvbe()
        {
            charazay obj = DeserializeEmbeddedXml("TeamInfo_Cvbe.xml");
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.team);
            Assert.AreEqual(obj.team.id, 57711u);
            Assert.AreEqual(obj.team.countryid, 6);
            Assert.AreEqual(obj.team.userid, 345587u);
            Assert.IsNotNull(obj.team.team_info);
            Assert.AreEqual(obj.team.team_info.arenaid, 57711u);
            Assert.AreEqual(obj.team.team_info.rival, 38088u);
            Assert.IsNotNull(obj.team.team_info.fanclub);
            Assert.IsNotNull(obj.team.team_info.training);
        }


        //ArenaInfo_20120726_21191.xml
        [TestMethod()]
        public void DeserializeArenaInfo_20120726_21191()
        {
            charazay obj = DeserializeEmbeddedXml("ArenaInfo_20120726_21191.xml");
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.arena);
            Assert.AreEqual(obj.arena.id, 21191u);
            Assert.AreEqual(obj.arena.spectators, 15600u);
            Assert.AreEqual(obj.arena.vips, 540u);
            Assert.AreEqual(obj.arena.name, "Rim Top");
        }

        //Coaches_stergein_20140128.xml
        [TestMethod()]
        public void DeserializeCoaches_stergein_20140128()
        {
            charazay obj = DeserializeEmbeddedXml("Coaches_stergein_20140128.xml");
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.coaches);
            Assert.IsNotNull(obj.coaches.coach);
            Assert.AreEqual(obj.coaches.coach.Length, 1);
            Assert.IsNotNull(obj.coaches.coach[0]);
            Assert.IsNotNull(obj.coaches.coach[0].basic);
            Assert.IsNotNull(obj.coaches.coach[0].skills);
            //        
            Assert.AreEqual(obj.coaches.coach[0].id, 2000018u);
            Assert.AreEqual(obj.coaches.coach[0].countryid, 21);
            Assert.AreEqual(obj.coaches.coach[0].teamid, 21191u);
            Assert.AreEqual(obj.coaches.coach[0].price, 6224400u);
            Assert.AreEqual(obj.coaches.coach[0].salary, 185250u);
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
            Assert.IsNotNull(obj.division);
            Assert.IsNotNull(obj.division.standings);
            Assert.IsNotNull(obj.division.standings[0]);
            Assert.AreEqual(obj.division.standings.Length, 16);
            //
            Assert.AreEqual(obj.division.standings[15].position, 16);
            Assert.AreEqual(obj.division.standings[15].owner, 38705u);
            Assert.AreEqual(obj.division.standings[15].teamid, 27862u);
            Assert.AreEqual(obj.division.standings[15].points_against, (ushort)1354);
        }

        //DivisionSchedule_20140128_1013.xml
        [TestMethod()]
        public void Deserialize_DivisionSchedule_20140128_1013()
        {
            charazay obj = DeserializeEmbeddedXml("DivisionSchedule_20140128_1013.xml");
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.schedule);
            Assert.IsNotNull(obj.schedule.round);
            Assert.AreEqual<byte>(obj.schedule.round[0].number, 1);
            Assert.AreEqual<uint>(obj.schedule.round[2].date, 1386430200u);
            Assert.AreEqual<uint>(obj.schedule.round[3].match.id, 22656044u);
        }

        //Economy_stergein_20140128.xml
        [TestMethod()]
        public void Deserialize_Economy_stergein_20140128()
        {
            charazay obj = DeserializeEmbeddedXml("Economy_stergein_20140128.xml");
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.economy);
            Assert.IsNotNull(obj.economy.economy_season);
            Assert.IsNotNull(obj.economy.economy_week);
            Assert.IsNotNull(obj.economy.economy_season.income);
            Assert.IsNotNull(obj.economy.economy_season.expences);
            Assert.IsNotNull(obj.economy.economy_week.income);
            Assert.IsNotNull(obj.economy.economy_week.expences);
            //
            Assert.AreEqual<uint>(obj.economy.economy_season.income.merchandise, 4975425u);
            Assert.AreEqual<uint>(obj.economy.economy_season.expences.facility, 1956000u);
            Assert.AreEqual<uint>(obj.economy.economy_week.expences.maintenance, 370178u);
        }

        //Match_18611008.xml
        [TestMethod()]
        public void Deserialize_Match_18611008()
        {
            charazay obj = DeserializeEmbeddedXml("Match_18611008.xml");
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.match);
            Assert.IsNotNull(obj.match.teams);
            Assert.IsNotNull(obj.match.stats);
            Assert.IsNotNull(obj.match.bballs);
            Assert.IsNotNull(obj.match.lineup);
            Assert.IsNotNull(obj.match.stats.away);
            Assert.IsNotNull(obj.match.stats.home);
            Assert.IsNotNull(obj.match.bballs.home);
            Assert.IsNotNull(obj.match.lineup.home);
            Assert.IsNotNull(obj.match.bballs.away);
            Assert.IsNotNull(obj.match.lineup.away);
        }

        //PlayerInfo_2459629.xml
        [TestMethod()]
        public void Deserialize_PlayerInfo_2459629()
        {
            charazay obj = DeserializeEmbeddedXml("PlayerInfo_2459629.xml");
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.player);
            Assert.IsNotNull(obj.player.basic);
            Assert.IsNotNull(obj.player.skills);
            Assert.IsNotNull(obj.player.status);
            //
            Assert.AreEqual(obj.player.teamid, 42179u);
            Assert.AreEqual(obj.player.promoted_on, 1189887308u);
            Assert.AreEqual(obj.player.basic.weight, (decimal)73.5707);
            Assert.AreEqual(obj.player.skills.speed, 19);
            Assert.AreEqual(obj.player.status.si, 388299u);
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
            Assert.IsNotNull(obj.matches);
            Assert.IsNotNull(obj.matches.match);
            Assert.IsNotNull(obj.matches.match[0]);
            Assert.IsNotNull(obj.matches.match[0].teams);
            //
            Assert.AreEqual(obj.matches.match[3].leagueid, 1013u);
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
            Assert.IsNotNull(obj.user);
            Assert.AreEqual(obj.user.countryid, 5);
            Assert.AreEqual(obj.user.id, 33039u);
            Assert.AreEqual(obj.user.last_active, 1266659428u);

            Assert.AreEqual(obj.user.name, "stergein");
            Assert.AreEqual(obj.user.registered, 1143677349u);
            Assert.AreEqual(obj.user.supporter, "no");
            Assert.AreEqual(obj.user.teamid, 21191u);

        }

        //TeamInfo_20140128.xml
        [TestMethod()]
        public void Deserialize_TeamInfo_20140128()
        {
            charazay obj = DeserializeEmbeddedXml("TeamInfo_20140128.xml");
            Assert.IsNotNull(obj);
            Assert.IsNotNull(obj.team);
            Assert.AreEqual(obj.team.id, 21191u);
            Assert.AreEqual(obj.team.countryid, 5);
            Assert.AreEqual(obj.team.userid, 33039u);
            Assert.IsNotNull(obj.team.team_info);
            Assert.AreEqual(obj.team.team_info.arenaid, 21191u);
            Assert.AreEqual(obj.team.team_info.rival, 13532u);
            Assert.IsNotNull(obj.team.team_info.fanclub);
            Assert.IsNotNull(obj.team.team_info.training);
        }

    }

#pragma warning restore
  }
