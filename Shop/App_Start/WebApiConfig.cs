using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using EnableCorsAttribute = Cors.ConfigProfiles.EnableCorsAttribute;
namespace Shop
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы Web API
            // Настройка Web API для использования только проверки подлинности посредством маркера-носителя.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.Formatters.Clear();
            JsonMediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();
            JsonSerializerSettings jsonSettings = new JsonSerializerSettings();
            var isoConverter = new IsoDateTimeConverter();
            isoConverter.DateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonSettings.Converters.Add(isoConverter);
            jsonFormatter.SerializerSettings = jsonSettings;
            config.Formatters.Add(jsonFormatter);

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.EnableCors(new EnableCorsAttribute("DefaultProfile"));
          

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
