namespace Vitality.Website.SC.Pipelines.HttpRequest
{
    using Sitecore.Diagnostics;
    using Sitecore.Pipelines.HttpRequest;
    using System;
    using System.IO;
    using System.Web;
    using System.Xml;

    public class SitemapResolver : HttpRequestProcessor
    {
        private const string SiteMapLocation = "sitemaps";

        public override void Process(HttpRequestArgs args)
        {
            var context = HttpContext.Current;

            var siteName = Sitecore.Context.Site.Name;

            if (context.Request.CurrentExecutionFilePathExtension
                .Equals(".xml", StringComparison.InvariantCultureIgnoreCase))
            {
                context.Response.ClearContent();

                var fileName = ReformatXmlFile(args, siteName);

                if (File.Exists(fileName))
                {
                    var xmlFileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read,FileShare.Read);

                    var doc = new XmlDocument();
                    doc.Load(xmlFileStream);

                    context.Response.ContentType = "text/xml";
                    context.Response.ContentEncoding = System.Text.Encoding.UTF8;
                    context.Response.Expires = -1;
                    context.Response.Cache.SetAllowResponseInBrowserHistory(true);

                    doc.Save(context.Response.Output);

                    context.Response.End();
                }
                else
                {
                    Log.Warn(string.Format("Requested sitemap file {0} does not exist.", fileName), this);
                }
            }
            else if (context.Request.CurrentExecutionFilePathExtension
                .Equals(".gz",StringComparison.InvariantCultureIgnoreCase))
            {
                context.Response.ContentType = "application/octet-stream";
                context.Response.WriteFile(ReformatXmlFile(args, siteName));
            }
            else
            {
                // No need to cater for other extensions.
            }
        }

        private static string ReformatXmlFile(HttpRequestArgs args, string siteName)
        {
            var secondUrlSegment = args.Context.Request.Url?.Segments?[1] ?? string.Empty;
            return $"{HttpRuntime.AppDomainAppPath}{SiteMapLocation}//{siteName}_{secondUrlSegment}";
        }
    }
}
