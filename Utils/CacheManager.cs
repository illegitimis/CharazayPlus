
namespace AndreiPopescu.CharazayPlus.Utils
{
  using System.Collections.Generic;
  using System.IO;
  using System.Xml.Serialization;
  //using AndreiPopescu.CharazayPlus.Utils;
    
  /// <summary>
  /// keeps a cache of player & team names
  /// </summary>
  public class CacheManager
  {
    /// <summary>
    /// lazily initialized player & team dictionaries
    /// </summary>
    private static Dictionary<ulong, string> _players = null;
    private static Dictionary<uint, string> _teams = null;
    private static Dictionary<uint, string> _matches = null;

    private string path()
    {
      AssemblyInfo asInfo = new AssemblyInfo();
      if (!Directory.Exists(asInfo.ApplicationFolder))
        Directory.CreateDirectory(asInfo.ApplicationFolder);
      string path = Path.Combine(asInfo.ApplicationFolder, "cache.xml");
      if (!File.Exists(path))
      {

        StreamWriter sw = File.CreateText(path);
        sw.WriteLine ("<?xml version=\"1.0\"?>");
        sw.WriteLine("<cache><players></players><teams></teams><matches></matches></cache>");        
        sw.Close();
      }
      return path;
    }

    #region Singleton
    private static CacheManager _instance = null;
    private static bool _isFinalized = false;

    private CacheManager()
    { //
      // deserialize from cache.xml
      //
      _players = new Dictionary<ulong, string>();
      _teams = new Dictionary<uint, string>();
      _matches = new Dictionary<uint, string>();

      using (FileStream fs = new FileStream(path(), FileMode.Open, FileAccess.Read))
      {
        cache cache = null;
        cache = (cache)(new XmlSerializer(typeof(cache)).Deserialize(fs));
        foreach (player p in cache.players)
          AddPlayer(p);
        foreach (team t in cache.teams)
          AddTeam(t);
        if (cache.matches != null)
        { 
        foreach (match m in cache.matches)
          AddMatch(m);
        }
      }
    }

    /// <summary>
    /// static Cache instance
    /// </summary>
    public static CacheManager Instance
    {
      get
      {
        if (_instance == null)
          _instance = new CacheManager();
        return _instance;
      }
    } 
    #endregion

    /// <summary>
    /// finalizer, will be called on application end
    /// updated cache data is persisted to xml
    /// </summary>
    ~CacheManager()
    {
      if (_isFinalized)
        return;

      using (FileStream fs = new FileStream(path(), FileMode.Truncate, FileAccess.Write))
      {
        XmlSerializer serializer = new XmlSerializer(typeof(cache));
        cache cache = new cache();
        List<player> lp = new List<player>();
        //
        // add existing players
        //
        foreach (var v in _players)
        {
          lp.Add(new player { id = v.Key, name = v.Value });
        }
        //
        // add existing teams
        //
        List<team> lt = new List<team>();
        foreach (var v in _teams)
        {
          lt.Add(new team { id = v.Key, name = v.Value });
        }
        //
        // add matches
        //
        List<match> lm = new List<match>();
        foreach (var m in _matches)
        {
          lm.Add(new match { id = m.Key, name = m.Value });
        }
        //
        cache.players = lp.ToArray();
        cache.teams = lt.ToArray();
        cache.matches = lm.ToArray();
        //
        serializer.Serialize(fs, cache);
        _isFinalized = true;

      }
    }

   
    #region Public Methods
    public void AddPlayer(player p)
    {
      if (_players.Count == 0 || !_players.ContainsKey(p.id))
        _players.Add(p.id, p.name);
    }

    public void AddPlayer(ulong id, string name)
    {
      if (_players.Count == 0 || !_players.ContainsKey(id))
        _players.Add(id, name);
    }

    public void AddTeam(team t)
    {
      if (_teams.Count == 0)
        _teams.Add(t.id, t.name);
      else
      {
        if (_teams.ContainsKey(t.id))
          _teams[t.id] = t.name;
        else
          _teams.Add(t.id, t.name);
      }

    }

    public void AddTeam(uint id, string name)
    {
      if (_teams.Count == 0)
        _teams.Add(id, name);
      else
      {
        if (_teams.ContainsKey(id))
          _teams[id] = name;
        else
          _teams.Add(id, name);
      }

    }

    public void AddMatch (match m)
    {
      if (Extensions.IsNullOrEmpty(_matches))
        _matches.Add(m.id, m.name);
      else
      {
        if (_matches.ContainsKey(m.id))
          _matches[m.id] = m.name;
        else
          _matches.Add(m.id, m.name);
      }
    }

    public void AddMatch (Xsd2.match m)
    {
      if (Extensions.IsNullOrEmpty(_matches))
        _matches.Add(m.id, m.ToString());
      else
      {
        if (_matches.ContainsKey(m.id))
          _matches[m.id] = m.ToString();
        else
          _matches.Add(m.id, m.ToString());
      }
    }
    
    public string PlayerName(ulong id)
    {
      return _players.ContainsKey(id) ? _players[id] : id.ToString();
    }

    public string TeamName(uint id)
    {
      return _teams.ContainsKey(id) ? _teams[id] : id.ToString();
    }

    internal string MatchName (uint mid)
    {
      return _matches.ContainsKey(mid) ? _matches[mid] : mid.ToString();
    }

    //public string PlayerName(uint id)
    //    {

    //  //playersField.Where (p => p.id == id)
    //      player plyr = (from p in this.players
    //                        where p.id == id
    //                        select p).FirstOrDefault();
    //      return plyr.name;
    //    }

    //    public string TeamName(ushort id)
    //    {
    //      //playersField.Where (p => p.id == id)
    //      team tm = (from m in this.teams
    //                      where m.id == id
    //                      select m).FirstOrDefault();
    //      return tm.name;
    //    } 
    #endregion



    
  }

}