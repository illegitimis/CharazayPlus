using AndreiPopescu.CharazayPlus.XsdMerge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CharazayPlus.Tests
{
    
#pragma warning disable
    /// <summary>
    ///This is a test class for matchTest and is intended
    ///to contain all matchTest Unit Tests
    ///</summary>
    [TestClass()]
    public class XsdMerge
    {

        static readonly string xmlBasePath = @"c:\Users\andreip.ROECR\AppData\Local\CharazayPlus\";
        static readonly string xmlBasePath2 = @"c:\Users\Illegitimis\AppData\Local\CharazayPlus\";

        static readonly string ArenaInfo = @"ArenaInfo";
        static readonly string Coaches = @"Coaches";
        static readonly string CountryInfo = @"CountryInfo";
        static readonly string DivisionInfo = @"DivisionInfo";
        static readonly string DivisionSchedule = @"DivisionSchedule";
        static readonly string Economy = @"Economy";
        static readonly string Match = @"Match";
        static readonly string MyPlayersTL = @"MyPlayersTL";
        static readonly string player = @"player";
        static readonly string PlayerInfo = @"PlayerInfo";
        static readonly string Players = @"Players";
        static readonly string Schedule = @"Schedule";
        static readonly string TeamInfo = @"TeamInfo";
        static readonly string TeamTransfers = @"TeamTransfers";
        static readonly string UserInfo = @"UserInfo";
        static readonly string cachexml = @"cache.xml";

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




    }

#pragma warning restore
  }
