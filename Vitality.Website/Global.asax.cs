using System.Web.Mvc;
using System.Web.Routing;

namespace Vitality.Website
{
    public class MvcApplication : Sitecore.Web.Application
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            MvcHandler.DisableMvcResponseHeader = true;
        }

        protected void Application_PreSendRequestHeaders()
        {
            this.Response.Headers.Remove("Server");
        }
    }
}
