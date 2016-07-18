
namespace CharazayPlus.WebApi
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Web.Http;
  using System.Web.Http.Cors;

  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // Web API configuration and services
      // http://www.asp.net/web-api/overview/security/enabling-cross-origin-requests-in-web-api
      //
      var corsAttr = new EnableCorsAttribute(
        origins: "http://www.charazay.com,http://54.229.122.56,http://54.194.193.243",
        headers: "*",
        methods: "get,post"
      ) { SupportsCredentials = false };
      config.EnableCors(corsAttr);

      // Web API routes
      config.MapHttpAttributeRoutes();

      //https://www.simple-talk.com/dotnet/asp.net/attribute-routing-in-web-api-v2/
      //config.Routes.MapHttpRoute(
      //    name: "player/aggregate/top",
      //    routeTemplate: "player/aggregate/top",
      //    defaults: new { controller = "Player", action = "GetAggregatedBestPlayer" }
      //);

      //config.Routes.MapHttpRoute(
      //    name: "player/aggregate",
      //    routeTemplate: "player/aggregate",
      //    defaults: new { controller = "Player", action = "GetAggregatedBestPlayers" }
      //);

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );
    }
  }
}
