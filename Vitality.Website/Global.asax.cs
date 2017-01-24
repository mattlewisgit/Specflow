using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Vitality.Website.SC;

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

        protected void Session_Start()
        {
            // Create urchin tracker module session cookie
            HttpCookie utmCookie = new HttpCookie(ConfigurationManager.AppSettings["UtmCookieName"]);
            utmCookie[Constants.CookieSettings.UtmCookieSource] = Request.Params[ConfigurationManager.AppSettings["UtmCookieSource"]];
            utmCookie[Constants.CookieSettings.UtmCookieMedium] = Request.Params[ConfigurationManager.AppSettings["UtmCookieMedium"]];
            utmCookie[Constants.CookieSettings.UtmCookieCampaign] = Request.Params[ConfigurationManager.AppSettings["UtmCookieCampaign"]];
            utmCookie[Constants.CookieSettings.UtmCookieTerm] = Request.Params[ConfigurationManager.AppSettings["UtmCookieTerm"]];
            utmCookie[Constants.CookieSettings.UtmCookieContent] = Request.Params[ConfigurationManager.AppSettings["UtmCookieContent"]];
            utmCookie[Constants.CookieSettings.RefUrl] = Request.UrlReferrer != null ? Request.UrlReferrer.ToString() : string.Empty;
            utmCookie.Expires = DateTime.MinValue;

            Response.Cookies.Add(utmCookie);
        }
    }
}
