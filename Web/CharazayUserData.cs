

namespace AndreiPopescu.CharazayPlus.Web
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;

  /// <summary>
  /// Class contains logon data for a charazay user
  /// </summary>
  public class CharazayUserData
  {
    public string User { get; internal set; }
    public string SecurityCode { get; internal set; }
    public uint DivisionId { get; internal set; }
    public byte CountryId { get; internal set; }
    /// <summary>
    /// arena id and team id coincide
    /// </summary>
    public uint ArenaId { get; internal set; }
    
    internal CharazayUserData ( ) : this(string.Empty, string.Empty) { }
    internal CharazayUserData (string u, string pass) : this (u, pass, 0, 0, 0) { }
 
    //new Web.WebServiceUsers("stergein", "<SecurityCode>", 1013, 5, 21191);
    private CharazayUserData (string u, string pass, uint div, byte c, uint a)
    {
      User = u;
      SecurityCode = pass;
      DivisionId = div;
      CountryId = c;
      ArenaId = a;
    }

    public bool Exists { get { return !string.IsNullOrEmpty(User) && !string.IsNullOrEmpty(SecurityCode); } }
  }
}
