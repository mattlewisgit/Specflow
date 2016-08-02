// <summary>Extracted from Sitecore Shared Source</summary>
// <url>http://trac.sitecore.net/LinkProvider/</url>

using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Links;
using Sitecore.Web;
using System;
using System.IO;

namespace Vitality.Website.SC.Providers
{
    public class AppendLinkProvider : LinkProvider
    {
        protected override LinkBuilder CreateLinkBuilder(UrlOptions options)
        {
            return new AppendLinkBuilder(options);
        }

        public class AppendLinkBuilder : LinkBuilder
        {
            public AppendLinkBuilder(UrlOptions options): base(options)
            {
            }

            protected override string BuildItemUrl(Item item)
            {
                Assert.ArgumentNotNull((object)item, "item");
                var siteInfo = ResolveTargetSite(item);
                var itemPathElement = GetItemPathElement(item, siteInfo);

                if (itemPathElement.Length == 0)
                {
                    return string.Empty;
                }

                var serverUrlElement = GetServerUrlElement(siteInfo);

                string url;

                if (siteInfo == null)
                {
                    url = BuildItemUrl(serverUrlElement, itemPathElement);
                }
                else
                {
                    url = BuildItemUrl(serverUrlElement, itemPathElement, siteInfo.VirtualFolder);
                }

                return HandleSlash(url);
            }

            public static string HandleSlash(string url)
            {
                if (string.IsNullOrWhiteSpace(url) || url.EndsWith("/"))
                {
                    return url;
                }

                var uri = new Uri(url);
                if (Path.HasExtension(uri.AbsoluteUri))
                {
                    return url;
                }

                var slashPosition = GetSlashPosition(url);

                var prefix = url.Substring(0, slashPosition);

                if (!prefix.EndsWith("/"))
                {
                    url = string.Format("{0}/{1}", prefix ,url.Substring(slashPosition));
                }

                return url;
            }

            private static int GetSlashPosition(string url)
            {
                //if a query string present add the slash before it
                var slashPosition = url.IndexOf("?");

                if (slashPosition < 0)
                {
                    //then check for hash and if present enter slash before it 
                    slashPosition = url.IndexOf("#");
                    if (slashPosition < 0)
                    {
                        slashPosition = url.Length;
                    }
                }
                return slashPosition;
            }
        }
    }
}
