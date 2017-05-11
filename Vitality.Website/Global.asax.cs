using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Vitality.Website.App_Start;
namespace Vitality.Website
{
    public class MvcApplication : Sitecore.Web.Application
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            MvcHandler.DisableMvcResponseHeader = true;
            MapperConfig.Init();
        }

        protected void Application_PreSendRequestHeaders()
        {
            this.Response.Headers.Remove("Server");
        }

        protected void Session_Start()
        {
            var utmCookie = Mvc.Utilities.UtmCookieHelper.CreateUtmCookie(new HttpRequestWrapper(Context.Request));
            if (utmCookie != null)
            {
                Context.Response.Cookies.Add(utmCookie);
            }
        }
    }
}
