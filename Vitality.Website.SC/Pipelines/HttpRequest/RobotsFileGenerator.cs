namespace Vitality.Website.SC.Pipelines.HttpRequest
{
    using System;
    using System.IO;
    using System.Web;

    using Sitecore.Data.Items;
    using Sitecore.Pipelines.HttpRequest;
    /// <remarks>
    /// Based off solution provided here https://sitecorecorner.com/2014/07/30/handling-sitecore-multi-site-instance-robots-txt/
    /// </remarks>
    public class RobotsFileGenerator : HttpRequestProcessor
    {
        private const string RobotsTxtFieldName = "RobotsTxt";

        public override void Process(HttpRequestArgs args)
        {
            var context = HttpContext.Current;

            if (context == null)
            {
                return;
            }

            var requestUrl = context.Request.Url.ToString();

            if (string.IsNullOrEmpty(requestUrl) || !requestUrl.EndsWith("robots.txt", StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }

            var robotsTxtContent = string.Format(@"User-agent: *{0}Disallow: /sitecore", Environment.NewLine);

            if (Sitecore.Context.Site != null && Sitecore.Context.Database != null)
            {
                var siteSettingsItem = Sitecore.Context.Database.GetItem(ItemConstants.Presales.Content.Configuration.SiteSettings.Path);

                if (siteSettingsItem != null)
                {                  
                    var robotsTxtField = siteSettingsItem[RobotsTxtFieldName];
                    if (!string.IsNullOrEmpty(robotsTxtField))
                    {
                        robotsTxtContent = robotsTxtField;
                    }
                }
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(robotsTxtContent);
            context.Response.End();
        }
    }
}