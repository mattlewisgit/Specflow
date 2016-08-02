// <summary>Extracted from Sitecore Shared Source</summary>
// <url>http://trac.sitecore.net/LinkProvider/</url>

using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Web;
using System;
using System.IO;

namespace Vitality.Website.SC.Providers
{
    public class LinkProvider : Sitecore.Links.LinkProvider
    {
        protected override Sitecore.Links.LinkProvider.LinkBuilder CreateLinkBuilder(Sitecore.Links.UrlOptions options)
        {
            return new LinkBuilder(options);
        }

        public new class LinkBuilder : Sitecore.Links.LinkProvider.LinkBuilder
        {
            public LinkBuilder(Sitecore.Links.UrlOptions options): base(options)
            {
            }

            protected override string BuildItemUrl(Item item)
            {
                Assert.ArgumentNotNull((object)item, "item");
                var siteInfo = this.ResolveTargetSite(item);
                var itemPathElement = this.GetItemPathElement(item, siteInfo);

                if (itemPathElement.Length == 0)
                {
                    return string.Empty;
                }

                var serverUrlElement = this.GetServerUrlElement(siteInfo);

                string url;

                if (siteInfo == null)
                {
                    url = this.BuildItemUrl(serverUrlElement, itemPathElement);
                }
                else
                {
                    url = this.BuildItemUrl(serverUrlElement, itemPathElement, siteInfo.VirtualFolder);
                }

                return this.HandleSlash(url);
            }

            private string HandleSlash(string url)
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

                var prefix = url.Substring(0, slashPosition);

                if (!prefix.EndsWith("/"))
                {
                    url = string.Format("{0}/{1}", prefix ,url.Substring(slashPosition));
                }

                return url;
            }
        }
    }
}
