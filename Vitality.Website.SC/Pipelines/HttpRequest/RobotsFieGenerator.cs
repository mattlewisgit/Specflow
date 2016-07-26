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
        public override void Process(HttpRequestArgs args)
        {
            var context = HttpContext.Current;

            if (context == null)
            {
                return;
            }

            var requestUrl = context.Request.Url.ToString();

            if (string.IsNullOrEmpty(requestUrl) || !requestUrl.ToLower().EndsWith("robots.txt"))
            {
                return;
            }

            var robotsTxtContent = $"User-agent: *{Environment.NewLine}Disallow: /sitecore";

            if (Sitecore.Context.Site != null && Sitecore.Context.Database != null)
            {
                var globalSettingsItem = Sitecore.Context.Database.GetItem(new Sitecore.Data.ID(Presales.Content.Configuration.GlobalSettings.Id));

                if (globalSettingsItem != null)
                {
                    var robotsTxtFieldName = "RobotsTxt";
                    robotsTxtContent = globalSettingsItem.Fields[robotsTxtFieldName].Value;
                    if ((globalSettingsItem.Fields[robotsTxtFieldName] != null) &&
                        (!string.IsNullOrEmpty(globalSettingsItem.Fields[robotsTxtFieldName].Value)))
                    {
                        robotsTxtContent = globalSettingsItem.Fields[robotsTxtFieldName].Value;
                    }
                }
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(robotsTxtContent);
            context.Response.End();
        }
    }
}