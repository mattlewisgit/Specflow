// <summary>Extracted from Sitecore Shared Source</summary>
// <url>http://trac.sitecore.net/LinkProvider/</url>

using System;
using System.IO;

namespace Vitality.Website.SC.Providers
{
    public class LinkProvider : Sitecore.Links.LinkProvider
    {
        public override string GetItemUrl(Sitecore.Data.Items.Item item, Sitecore.Links.UrlOptions urlOptions)
        {
            var resultUrl = base.GetItemUrl(item, urlOptions);

            if (!item.Paths.IsMediaItem)
            {
                resultUrl = ApplySlash(resultUrl);
            }
            return resultUrl;
        }

        public bool AppendSlash { get; set; }

        protected string ApplySlash(string url)
        {
            if (url.EndsWith("/"))
            {
                return url;
            }
            var uri = new Uri(url);

            if (this.AppendSlash && !Path.HasExtension(uri.AbsoluteUri))
            {
                url += "/";
            }
            return url;
        }
    }
}
