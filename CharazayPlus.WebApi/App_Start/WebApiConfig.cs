using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CharazayPlus.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

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
