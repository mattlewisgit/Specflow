using System.Web;
namespace Vitality.Website
{
    public class MvcApplication : Sitecore.Web.Application
    {
        protected void Application_PreSendRequestHeaders()
        {
            Response.Headers.Remove("Server");
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
