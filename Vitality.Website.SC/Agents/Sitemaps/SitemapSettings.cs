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
            string itemUrl = "";

            using (new SiteContextSwitcher(Factory.GetSite(subdomain)))
            {
                itemUrl = item.Paths.Path.ToLower();
                itemUrl = itemUrl.Replace(Sitecore.Context.Data.Site.RootPath.ToLower(), "");
                itemUrl = itemUrl.Replace(Sitecore.Context.Data.Site.StartItem.ToLower(), "");
            }

            itemUrl = baseUrl + itemUrl;

            var publishedDate = item.Statistics.Updated;
            var hideFromSitemap = item[HideFromSitemapField] == "1";

            if (hideFromSitemap)
            {
                return new SitemapSettings {HideFromSitemap = true};
            }

            while (item[InheritSitemapSettingsField] == "1" &&
                !string.Equals(item.Paths.Path,ItemConstants.Presales.Content.Home.Path, StringComparison.InvariantCultureIgnoreCase))
            {
                item = item.Parent;
            }

            if (string.IsNullOrWhiteSpace(item[ChangeFrequencyField]) || string.IsNullOrWhiteSpace(item[SitemapField]))
            {
                return new SitemapSettings { HideFromSitemap = true };
            }

            return new SitemapSettings
            {
                PageUrl = itemUrl,
                ChangeFrequency = item.Database.GetItem(item[ChangeFrequencyField]) != null ? item.Database.GetItem(item[ChangeFrequencyField]).Fields["Value"].Value : "",
                Priority = item[PriorityField],
                SitemapName = item.Database.GetItem(item[SitemapField]) != null ? item.Database.GetItem(item[SitemapField]).Fields["Value"].Value : "",
                PublishedDate = publishedDate,
                HideFromSitemap = false
            };
        }
    }
}
