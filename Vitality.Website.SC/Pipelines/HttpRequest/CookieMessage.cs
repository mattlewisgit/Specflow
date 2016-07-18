namespace Vitality.Website.SC.Pipelines.HttpRequest
{
    using System;
    using System.Web;

    using Sitecore.Pipelines.HttpRequest;
    
    public class CookieMessage : HttpRequestProcessor
    {
        public const string Name = "cookieMessage";

        public const string Show = "show";

        public override void Process(HttpRequestArgs args)
        {
            var cookieMessageCookie = args.Context.Request.Cookies.Get(Name);
            if (cookieMessageCookie == null)
            {
                cookieMessageCookie = new HttpCookie(Name, Show) { Expires = DateTime.Today.AddDays(-1) };
                args.Context.Response.Cookies.Add(cookieMessageCookie);
            }
        }
    }
}
