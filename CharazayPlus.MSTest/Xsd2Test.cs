namespace CharazayPlus.MSTest
{
    using System;
    using System.Collections.Generic;
    //using System.Linq;
    using System.Text;
    using System.Data;
    using System.IO;
    using System.Windows.Forms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Xml.Serialization;
    using System.Reflection;
    using chrzyobj = AndreiPopescu.CharazayPlus.Xsd2.charazay;

  [TestClass()]
  public class Xsd2Test
  {
    internal const string XmlTestFilesDirectory = @"..\..\xml";
    internal const uint uim = uint.MaxValue;

    #region trial xml code
    //[TestMethod()]
    public DataSet LoadDatasetFromXml(string fileName)
    {
        DataSet ds = new DataSet();
        FileStream fs = null;

        try
        {
            fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            using (StreamReader reader = new StreamReader(fs))
            {
                ds.ReadXml(reader);
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
        }
        finally
        {
            if (fs != null)
                fs.Close();
        }

        return ds;
    }

    //[TestMethod()]
    public DataSet LoadDatasetFromXml(string xmlDataFileName, string xmlSchemaFileName)
    {
        DataSet ds = new DataSet();
        FileStream fs = null;
        ds.ReadXmlSchema(xmlSchemaFileName);

        try
        {
            fs = new FileStream(xmlDataFileName, FileMode.Open, FileAccess.Read);
            using (StreamReader reader = new StreamReader(fs))
            {
                ds.ReadXml(reader, XmlReadMode.IgnoreSchema);
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
        }
        finally
        {
            if (fs != null)
                fs.Close();
        }

        return ds;
    } 
    #endregion

    private chrzyobj DeserializeEmbeddedXml (string fileName)
    {
      var assembly = Assembly.GetExecutingAssembly();
      var resourceName = "CharazayPlus.MSTest.EmbeddedXml." + fileName;
      chrzyobj obj = null;
      using (Stream stream = assembly.GetManifestResourceStream(resourceName))
      {
        obj = (chrzyobj)(new XmlSerializer(typeof(chrzyobj)).Deserialize(stream));
      }
      return obj;
    }
    
      //UserInfo_Cvbe.xml
    [TestMethod()]
    public void Deserialize_UserInfoCvbe ( )
    {
      chrzyobj obj =DeserializeEmbeddedXml("UserInfo_Cvbe.xml");
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
    public void Deserialize_TeamInfoCvbe ( )
    {
      chrzyobj obj =DeserializeEmbeddedXml("TeamInfo_Cvbe.xml");
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
    public void Deserialize_ArenaInfo_20120726_21191()
    {
        chrzyobj obj = DeserializeEmbeddedXml("ArenaInfo_20120726_21191.xml");
        Assert.IsNotNull(obj);
        Assert.IsNotNull(obj.arena);
        Assert.AreEqual(obj.arena.id, 21191u);
        Assert.AreEqual(obj.arena.spectators, 15600u);
        Assert.AreEqual(obj.arena.vips, 540u);
        Assert.AreEqual(obj.arena.name, "Rim Top");
    }

      //Coaches_stergein_20140128.xml
    [TestMethod()]
    public void Deserialize_Coaches_stergein_20140128()
    {
        chrzyobj obj = DeserializeEmbeddedXml("Coaches_stergein_20140128.xml");
        Assert.IsNotNull(obj);
        Assert.IsNotNull(obj.coaches);
        Assert.AreEqual(obj.coaches.Length, 1);
        Assert.IsNotNull(obj.coaches[0]);
        Assert.IsNotNull(obj.coaches[0].basic);
        Assert.IsNotNull(obj.coaches[0].skills);
        //        
        Assert.AreEqual(obj.coaches[0].id, 2000018u);
        Assert.AreEqual(obj.coaches[0].countryid, 21);
        Assert.AreEqual(obj.coaches[0].teamid, 21191u);
        Assert.AreEqual(obj.coaches[0].price, 6224400u);
        Assert.AreEqual(obj.coaches[0].salary, 185250u);        
    }

      //CountryInfo_20140128_5_1.xml
    [TestMethod()]
    public void Deserialize_CountryInfo_20140128_5_1()
    {
        chrzyobj obj = DeserializeEmbeddedXml("CountryInfo_20140128_5_1.xml");
        Assert.IsNotNull(obj);
        Assert.IsNotNull(obj.country);
        Assert.IsNotNull(obj.country.division);
        Assert.IsNotNull(obj.country.division[0]);
        Assert.AreEqual(obj.country.division.Length,31);
        //
        Assert.AreEqual(obj.country.division[0].countryid, 5);
        Assert.AreEqual(obj.country.division[0].id, 1013u);
        Assert.AreEqual(obj.country.division[0].level, 1);
        Assert.AreEqual(obj.country.division[0].lh, (ushort)251);
    }

      //DivisionInfo_20140128_1013.xml
    [TestMethod()]
    public void Deserialize_DivisionInfo_20140128_1013()
    {
        chrzyobj obj = DeserializeEmbeddedXml("DivisionInfo_20140128_1013.xml");
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
        chrzyobj obj = DeserializeEmbeddedXml("DivisionSchedule_20140128_1013.xml");
        Assert.IsNotNull(obj);
        Assert.IsNotNull(obj.schedule);
        Assert.IsNotNull(obj.schedule[0]);
        Assert.AreEqual<byte>(obj.schedule[0].number, 1);
        Assert.AreEqual<uint>(obj.schedule[2].date, 1386430200u);
        Assert.AreEqual<uint>(obj.schedule[3].match.id, 22656044u);
    }

      //Economy_stergein_20140128.xml
    [TestMethod()]
    public void Deserialize_Economy_stergein_20140128()
    {
        chrzyobj obj = DeserializeEmbeddedXml("Economy_stergein_20140128.xml");
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
        chrzyobj obj = DeserializeEmbeddedXml("Match_18611008.xml");
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
        chrzyobj obj = DeserializeEmbeddedXml("PlayerInfo_2459629.xml");
        Assert.IsNotNull(obj);
        Assert.IsNotNull(obj.player);
        Assert.IsNotNull(obj.player.basic);
        Assert.IsNotNull(obj.player.skills);
        Assert.IsNotNull(obj.player.status);
        //
        Assert.AreEqual(obj.player.teamid, "42179");
        Assert.AreEqual(obj.player.promoted_on, 1189887308u);
        Assert.AreEqual(obj.player.basic.weight, (decimal)73.5707);
        Assert.AreEqual(obj.player.skills.speed, 19);
        Assert.AreEqual(obj.player.status.si, 388299u);
    }

//Players_stergein_20140128.xml
    [TestMethod()]
    public void Deserialize_Players_stergein_20140128()
    {
        chrzyobj obj = DeserializeEmbeddedXml("Players_stergein_20140128.xml");
        Assert.IsNotNull(obj);
        Assert.IsNotNull(obj.players);
        Assert.IsNotNull(obj.players[0]);
        Assert.IsNotNull(obj.players[0].basic);
        Assert.IsNotNull(obj.players[0].skills);
        Assert.IsNotNull(obj.players[0].status);
        //
        Assert.AreEqual(obj.players[obj.players.Length - 1].teamid, "21191");        
    }

//Schedule_stergein_20140128.xml
    [TestMethod()]
    public void Deserialize_Schedule_stergein_20140128()
    {
        chrzyobj obj = DeserializeEmbeddedXml("Schedule_stergein_20140128.xml");
        Assert.IsNotNull(obj);
        Assert.IsNotNull(obj.matches);
        Assert.IsNotNull(obj.matches[0]);
        Assert.IsNotNull(obj.matches[0].teams);        
        //
        Assert.AreEqual(obj.matches[3].leagueid, 1013u);
    }

//TeamTransfers_20140128.xml
    [TestMethod()]
    public void Deserialize_TeamTransfers_20140128()
    {
        chrzyobj obj = DeserializeEmbeddedXml("TeamTransfers_20140128.xml");
        Assert.IsNotNull(obj);
        Assert.IsNotNull(obj.team_transfers);
        Assert.IsNotNull(obj.team_transfers[0]);        
        //
        Assert.AreEqual(obj.team_transfers[2].playerid, 4113311u);
        Assert.AreEqual(obj.team_transfers[2].sellteam, 46912u);
    }

      //UserInfo_20140128.xml    
    [TestMethod()]
    public void Deserialize_UserInfo_20140128()
    {
        chrzyobj obj = DeserializeEmbeddedXml("UserInfo_20140128.xml");
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
        chrzyobj obj = DeserializeEmbeddedXml("TeamInfo_20140128.xml");
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

    //ERR
    [TestMethod()]
    public void Deserialize_ERROR ( )
    {
      chrzyobj obj = DeserializeEmbeddedXml("Error.xml");
      Assert.IsNotNull(obj);
      Assert.IsNotNull(obj.error);
      Assert.IsNotNull(obj.error.message);
      Assert.AreEqual<string>(obj.error.message, "Missing division id");
    }

    //Fatigue_Minus1_20140215.xml
    [TestMethod()]
    public void Deserialize_Fatigue_Minus1_20140215 ( )
    {
      chrzyobj obj = DeserializeEmbeddedXml("Fatigue_Minus1_20140215.xml");
      Assert.IsNotNull(obj);
      Assert.IsNotNull(obj.players);
      Assert.IsNotNull(obj.players[0]);
      Assert.IsNotNull(obj.players[0].basic);
      Assert.IsNotNull(obj.players[0].skills);
      Assert.IsNotNull(obj.players[0].status);
      //
      Assert.AreEqual(obj.players[3].status.fatigue, 0);
      Assert.AreEqual(obj.players[0].status.fatigue, 0);
    }
  }
}
