using System.Web.Mvc;
using System.Web.Routing;

namespace Vitality.Website
{
    public class RouteConfig
    {
        /// <remarks>
        /// {controller}/{action}/{id}'. If you wish to keep this route, please remove it from the Mvc.IllegalRoutes setting
        /// </remarks>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        }
    }
}
