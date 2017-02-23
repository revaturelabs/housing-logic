using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Housing.Logic.Client
{
    /// <summary>
    /// Default routing
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Specifies default route template
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {

            var cors = new EnableCorsAttribute(
            origins: "*",
            headers: "*",
            methods: "*");

            config.EnableCors(cors);


            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}/",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
