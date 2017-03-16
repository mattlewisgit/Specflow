using System;
using Sitecore.Configuration;
using Sitecore.Data.Items;
using Sitecore.Sites;

namespace Vitality.Website.SC.Agents.Sitemaps
{
    public class SitemapSettings
    {
        private const string HideFromSitemapField = "HideFromSitemap";
        private const string InheritSitemapSettingsField = "InheritSitemapSettings";
        private const string SitemapField = "Sitemap";
        private const string ChangeFrequencyField = "ChangeFrequency";
        private const string PriorityField = "Priority";

        public string PageUrl { get; set; }
        public bool HideFromSitemap { get; set; }
        public bool InheritSitemapSettings { get; set; }
        public string SitemapName { get; set; }
        public string ChangeFrequency { get; set; }
        public string Priority { get; set; }
        public DateTime PublishedDate { get; set; }

        public static SitemapSettings From(Item item, string baseUrl, string subdomain)
        {
            string itemUrl;

            using (new SiteContextSwitcher(Factory.GetSite(subdomain)))
            {
                var site = Sitecore.Context.Data.Site;

                itemUrl = item
                    .Paths
                    .Path
                    .ToLower()
                    .Replace(site.RootPath.ToLower(), string.Empty)
                    .Replace(site.StartItem.ToLower(), string.Empty)
                    .TrimStart('/');
            }

            itemUrl = baseUrl + itemUrl;

            var publishedDate = item.Statistics.Updated;
            var hideFromSitemap = item[HideFromSitemapField] == "1";

            if (hideFromSitemap)
            {
                return new SitemapSettings { HideFromSitemap = true };
            }

            var currentItem = item;

            while (currentItem[InheritSitemapSettingsField] == "1" &&
                !currentItem.Paths.Path.Equals
                    (ItemConstants.Presales.Content.Home.Path, StringComparison.InvariantCultureIgnoreCase))
            {
                currentItem = currentItem.Parent;
            }

            if (string.IsNullOrWhiteSpace(currentItem[ChangeFrequencyField]) ||
                string.IsNullOrWhiteSpace(currentItem[SitemapField]))
            {
                return new SitemapSettings { HideFromSitemap = true };
            }

            return new SitemapSettings
            {
                PageUrl = itemUrl,
                ChangeFrequency = currentItem
                    .Database
                    .GetItem(currentItem[ChangeFrequencyField])
                    ?.Fields["Value"]
                    ?.Value
                    ?? string.Empty,
                Priority = currentItem[PriorityField],
                SitemapName = currentItem
                    .Database
                    .GetItem(currentItem[SitemapField])
                    ?.Fields["Value"]
                    ?.Value
                    ?? string.Empty,
                PublishedDate = publishedDate,
                HideFromSitemap = false
            };
        }
    }
}
