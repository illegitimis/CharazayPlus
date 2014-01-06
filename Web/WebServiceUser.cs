
namespace AndreiPopescu.CharazayPlus.Web
{
  public class WebServiceUser
  {
    public string user;
    public string securityCode;
    public int divisionId;
    public byte countryId;
    public int arenaId;

    public WebServiceUser (string u, string pass)
    {
      user = u;
      securityCode = pass;
    }

    public WebServiceUser (string u, string pass, int div, byte c, int a)
    {
      user = u;
      securityCode = pass;
      divisionId = div;
      countryId = c;
      arenaId = a;
    }
  }
}
