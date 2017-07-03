// <summary>Extracted from Sitecore Shared Source</summary>
// <url>http://trac.sitecore.net/LinkProvider/</url>

using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Links;
using System;
using System.IO;
using Sitecore.Configuration;

namespace Vitality.Website.SC.Providers
{
    public class AppendLinkProvider : LinkProvider
    {
        /// <summary>
        /// There is a known issues of sitecore doesn't apply siteResolving property for Link Manager
        /// http://stackoverflow.com/questions/29774360/sitecore-link-manager-url-options-site-resolving-is-not-set
        /// Therefore it needs to be applied here
        /// </summary>
        /// <returns>UrlOptions</returns>
        public override UrlOptions GetDefaultUrlOptions()
        {
            var urlOptions = base.GetDefaultUrlOptions();
            urlOptions.SiteResolving = Settings.Rendering.SiteResolving;
            return urlOptions;
        }

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
                const string slash = "/";

                if (string.IsNullOrWhiteSpace(url) || url.EndsWith(slash))
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

                return !prefix.EndsWith(slash)
                    ? string.Format("{0}/{1}", prefix, url.Substring(slashPosition))
                    : url;
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
