namespace Vitality.Website.SC.Pipelines.HttpRequest
{
    using System;
    using System.Web;

    using Sitecore.Pipelines.HttpRequest;
    
    public class CookieConsent : HttpRequestProcessor
    {
        private const string ConsentCookie = "cc";

        public override void Process(HttpRequestArgs args)
        {
            var consentCookie = args.Context.Request.Cookies.Get(ConsentCookie) ?? new HttpCookie(ConsentCookie, "show");
            
            consentCookie.Expires = DateTime.Today.AddDays(-1);

            args.Context.Response.Cookies.Add(consentCookie);
        }
    }
}
