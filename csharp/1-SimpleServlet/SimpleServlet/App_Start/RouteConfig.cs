using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SimpleServlet
{
    public class RouteConfig
    {
        /// <summary>
        /// Set up the application routing tables.
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            // *.axd files are used by ASP.NET to get trace information.
            // Let ASP.NET handle those.
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Default routing maps by name to the controller and action. So
            // a request with "/echo" will be mapped to EchoController, with the
            // action being "Index" (which is the default in this case).
            // If the target route doesn't exist client automatically gets a 404
            // back.
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
