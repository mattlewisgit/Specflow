using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using Sitecore.Pipelines.HttpRequest;
using Sitecore.Diagnostics;

namespace Vitality.Website.SC.Pipelines.HttpRequest
{
    public class SitemapResolver : HttpRequestProcessor
    {
        private const string SiteMapLocation = "sitemaps";

        public override void Process(HttpRequestArgs args)
        {
            var context = HttpContext.Current;
            
            var siteName = Sitecore.Context.Site.Name;
            
            if (string.Equals(context.Request.CurrentExecutionFilePathExtension,".xml", StringComparison.InvariantCultureIgnoreCase))
            {
                context.Response.ClearContent();

                var fileName = ReformatXmlFile(args, siteName);

                if (File.Exists(fileName))
                {
                    var xmlFileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read,
                        FileShare.Read);

                    //xml.
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
            else if (string.Equals(context.Request.CurrentExecutionFilePathExtension, ".gz",StringComparison.InvariantCultureIgnoreCase))
            {
                context.Response.ContentType = "application/octet-stream";
                context.Response.WriteFile(ReformatXmlFile(args, siteName));
            }
        }

        private static string ReformatXmlFile(HttpRequestArgs args, string siteName)
        {
            return string.Format("{0}{1}//{2}{3}", HttpRuntime.AppDomainAppPath, SiteMapLocation, siteName + "_", args.Context.Request.Url.Segments[1]);
        } 
    }
}