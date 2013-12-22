
namespace AndreiPopescu.CharazayPlus.Web
{
  internal class WebServiceUser
  {
    internal string user;
    internal string securityCode;
    internal int divisionId;
    internal byte countryId;
    internal int arenaId;

    internal WebServiceUser (string u, string pass)
    {
      user = u;
      securityCode = pass;
    }

    internal WebServiceUser (string u, string pass, int div, byte c, int a)
    {
      user = u;
      securityCode = pass;
      divisionId = div;
      countryId = c;
      arenaId = a;
    }
  }
}
