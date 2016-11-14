using System.Web.Mvc;
using System.Web.Routing;

namespace F1App.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(null,"{controller}/{action}", new { controller = "Home", action = "Index" });
            routes.MapRoute(null, "", new { controller = "Home", action = "Index" });            
        }
    } 
}
