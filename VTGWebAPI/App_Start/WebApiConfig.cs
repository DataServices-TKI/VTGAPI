using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Cors;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace VTGWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
           // config.SuppressDefaultHostAuthentication();
           // config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.Formatters.Remove(config.Formatters.XmlFormatter);

          var cors = new EnableCorsAttribute("https://vtguat.telethonkids.org.au", "*", "*");
            
        // var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
          //  var cors = new EnableCorsAttribute("https://dataservices-tki.github.io", "*", "*");

            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
