
namespace AndreiPopescu.CharazayPlus.Web
{
  /// <summary>
  /// charazay xml api user data manager
  /// </summary>
  public class WebServiceUsers
  {

    #region //LazyDoubleLockedSingleton
    private static volatile WebServiceUsers instance = null;
    private static object sync = new object();

    public static WebServiceUsers Instance
    {
      get
      {
        if (instance == null)
        {
          lock (sync)
          {
            if (instance == null)
              instance = new WebServiceUsers();            
          }
        }
        return instance;
      }
    } 
    #endregion

    public CharazayUserData MainUser { get; internal set; }
    //public CharazayUserData AlternateUser { get; internal set; }
    //public CharazayUserData SecondTeamUser { get; internal set; }

    public bool HasMainUser { get { return MainUser!=null && MainUser.Exists; } }
    //public bool HasAlternateUser { get { return AlternateUser != null && AlternateUser.Exists; } }
    //public bool HasSecondTeamUser { get { return SecondTeamUser != null && SecondTeamUser.Exists; } }
   
  }
}
