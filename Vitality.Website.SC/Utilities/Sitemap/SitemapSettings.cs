using Sitecore.Data.Items;

namespace Vitality.Website.SC.Utilities.Sitemap
{
    public class SitemapSettings
    {
        public Item Item { get; set; }
        public string PageUrl { get; set; }
        public bool HideFromSitemap { get; set; }
        public bool InheritSitemapSettings { get; set; }
        public string SitemapItemId { get; set; }
        public string ChangeFrequency { get; set; }
        public string Priority { get; set; }
    }
}
