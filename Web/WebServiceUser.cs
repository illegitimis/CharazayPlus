
namespace AndreiPopescu.CharazayPlus.Web
{
  public class WebServiceUser
  {
    public string user;
    public string securityCode;
    public uint divisionId;
    public byte countryId;
    public uint arenaId;

    public WebServiceUser (string u, string pass)
    {
      user = u;
      securityCode = pass;
    }

    public WebServiceUser (string u, string pass, uint div, byte c, uint a)
    {
      user = u;
      securityCode = pass;
      divisionId = div;
      countryId = c;
      arenaId = a;
    }
  }
}
