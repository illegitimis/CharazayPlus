
namespace AndreiPopescu.CharazayPlus.Web
{
  /// <summary>
  /// charazay xml api user data
  /// </summary>
  public class WebServiceUser
  {

    #region //LazyDoubleLockedSingleton
    private static volatile WebServiceUser instance = null;
    private static object sync = new object();

   
    private WebServiceUser ( ) : this(string.Empty, string.Empty) { }
    private WebServiceUser (string u, string pass) : this (u, pass, 0, 0, 0) { }
 
    //new Web.WebServiceUser("stergein", "security_code", 1013, 5, 21191);
    private WebServiceUser (string u, string pass, uint div, byte c, uint a)
    {
      user = u;
      securityCode = pass;
      divisionId = div;
      countryId = c;
      arenaId = a;
    }

    public static WebServiceUser Instance
    {
      get
      {
        if (instance == null)
        {
          lock (sync)
          {
            if (instance == null)
              instance = new WebServiceUser();
          }
        }
        return instance;
      }
    } 
    #endregion

    
    public string user {get; internal set;}
    public string securityCode { get; internal set; }
    public uint divisionId { get; internal set; }
    public byte countryId { get; internal set; }
    public uint arenaId { get; internal set; }

   
  }
}
