using System;
using System.Collections.Generic;

namespace Vitality.Website.SC.Agents.Sitemaps
{
    public class Sitemap
    {
        private readonly List<SitemapSettings> pages = new List<SitemapSettings>();

        public string Name { get; private set; }
        public DateTime LastUpdated = DateTime.MinValue;

        public Sitemap(string name)
        {
            Name = name;
        }

        public void Add(SitemapSettings sitemapSettings)
        {
            if (sitemapSettings.PublishedDate > LastUpdated)
            {
                LastUpdated = sitemapSettings.PublishedDate;
            }

            pages.Add(sitemapSettings);
        }

        public void BuildSitemap()
        {
            var model = new SitemapModel
            {
                SchemaLocation = "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd"
            };

            foreach (var sitemapModel in pages)
            {
                model.Urls.Add(new SitemapUrlModel
                {
                    Location = sitemapModel.PageUrl.EndsWith("/") ? sitemapModel.PageUrl : sitemapModel.PageUrl + "/",
                    ChangeFrequency = sitemapModel.ChangeFrequency,
                    Priority = sitemapModel.Priority
                });
            }

            SitemapHelper<SitemapModel>.SaveSitemapToDisk(model, string.Format("{0}.xml", Name), true);
        }
    }
}
