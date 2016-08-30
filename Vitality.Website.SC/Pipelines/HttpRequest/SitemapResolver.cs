using System;
using System.IO;
using System.Web;
using System.Xml;
using Sitecore.Pipelines.HttpRequest;

namespace Vitality.Website.SC.Pipelines.HttpRequest
{
    public class SitemapResolver : HttpRequestProcessor
    {
        private const string SiteMapLocation = "sitemaps";

        public override void Process(HttpRequestArgs args)
        {

            var requestedSite = HttpContext.Current.Request.Url.Host.ToLower();

            var subdomain = GetSubDomain(HttpContext.Current.Request.Url);

            var xmlFile = string.Format("{0}{1}//{2}{3}", HttpRuntime.AppDomainAppPath, SiteMapLocation, subdomain + "_", HttpContext.Current.Request.Url.Segments[1]);

            FileStream xmlFileStream = new FileStream(xmlFile, FileMode.Open, FileAccess.Read, FileShare.Read);

            if (HttpContext.Current.Request.CurrentExecutionFilePathExtension == ".xml")
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlFileStream);

                HttpContext.Current.Response.ContentType = "text/xml";
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
                HttpContext.Current.Response.Expires = -1;
                HttpContext.Current.Response.Cache.SetAllowResponseInBrowserHistory(true);

                doc.Save(HttpContext.Current.Response.Output);
            }
            else if (HttpContext.Current.Request.CurrentExecutionFilePathExtension == ".gz")
            {
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                HttpContext.Current.Response.WriteFile(xmlFile);
            }
        }

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