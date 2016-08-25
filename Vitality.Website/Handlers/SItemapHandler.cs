using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace Vitality.Website.Handlers
{
    public class SitemapHandler : IHttpHandler
    {
        private const string SiteMapLocation = "sitemaps";

        public void ProcessRequest(HttpContext context)
        {
            var requestedSite = context.Request.Url.Host.ToLower();

            var subdomain = GetSubDomain(context.Request.Url);

            var xmlFile = string.Format("{0}{1}//{2}{3}", HttpRuntime.AppDomainAppPath, SiteMapLocation, subdomain + "_", context.Request.Url.Segments[1]);

            FileStream xmlFileStream = new FileStream(xmlFile, FileMode.Open, FileAccess.Read, FileShare.Read);

            if (context.Request.CurrentExecutionFilePathExtension == ".xml")
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlFileStream);

                context.Response.ContentType = "text/xml";
                context.Response.ContentEncoding = System.Text.Encoding.UTF8;
                context.Response.Expires = -1;
                context.Response.Cache.SetAllowResponseInBrowserHistory(true);

                doc.Save(context.Response.Output);
            }
            else if (context.Request.CurrentExecutionFilePathExtension == ".gz")
            {
                context.Response.ContentType = "application/octet-stream";
                context.Response.WriteFile(xmlFile);
            }
        }

        public bool IsReusable { get; }

        private static string GetSubDomain(Uri url)
        {
            if (url.HostNameType == UriHostNameType.Dns)
            {
                string host = url.Host;

                var nodes = host.Split('.');
                int startNode = 0;
                if (nodes[0] == "www") startNode = 1;

                return string.Format("{0}", nodes[startNode]);
            }

            return null;
        }
    }
}