namespace Vitality.Website.SC.Pipelines.HttpRequest
{
    using System;
    using System.IO;
    using System.Web;

    using Sitecore.Data.Items;
    using Sitecore.Pipelines.HttpRequest;
    using static ItemConstants;
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

            var robotsTxtContent = $"User-agent: *{Environment.NewLine}Disallow: /sitecore";

            if (Sitecore.Context.Site != null && Sitecore.Context.Database != null)
            {
                var globalSettingsItem = Sitecore.Context.Database.GetItem(new Sitecore.Data.ID(Presales.Content.Configuration.GlobalSettings.Id));

                if (globalSettingsItem != null)
                {                  
                    var robotsTxtField = globalSettingsItem.Fields[RobotsTxtFieldName];
                    if ((robotsTxtField!= null) &&
                        (!string.IsNullOrEmpty(robotsTxtField.Value)))
                    {
                        robotsTxtContent = robotsTxtField.Value;
                    }
                }
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(robotsTxtContent);
            context.Response.End();
        }
    }
}