using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using Sitecore.Pipelines.HttpRequest;

namespace Vitality.Website.SC.Pipelines.HttpRequest
{
    public class SitemapResolver : HttpRequestProcessor
    {
        private const string SiteMapLocation = "sitemaps";

        public override void Process(HttpRequestArgs args)
        {
            var context = HttpContext.Current;
            
            var subdomain = GetSubDomain(context.Request.Url);
            
            if (context.Request.CurrentExecutionFilePathExtension == ".xml")
            {
                context.Response.ClearContent();

                var xmlFileStream = new FileStream(ReformatXmlFile(args, subdomain), FileMode.Open, FileAccess.Read, FileShare.Read);
                
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
            else if (context.Request.CurrentExecutionFilePathExtension == ".gz")
            {
                context.Response.ContentType = "application/octet-stream";
                context.Response.WriteFile(ReformatXmlFile(args, subdomain));
            }
        }

        private static string ReformatXmlFile(HttpRequestArgs args, string subdomain)
        {
            return string.Format("{0}{1}//{2}{3}", HttpRuntime.AppDomainAppPath, SiteMapLocation, subdomain + "_", args.Context.Request.Url.Segments[1]);
        }

        private static string GetSubDomain(Uri url)
        {
            if (url.HostNameType == UriHostNameType.Dns)
            {
                var host = url.Host;

                var nodes = host.Split('.');
                var startNode = 0;
                if (nodes[0] == "www") startNode = 1;

                return string.Format("{0}", nodes[startNode]);
            }

            return null;
        }
    }
}