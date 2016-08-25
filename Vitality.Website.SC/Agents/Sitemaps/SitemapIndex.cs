using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Items;

namespace Vitality.Website.SC.Agents.Sitemaps
{
    public class SitemapIndex
    {
        private readonly string baseUrl;
        private readonly List<Sitemap> sitemaps;
        private readonly SitemapIndexModel sitemapIndexFile;
        private string IndexFile = "sitemapindex.xml";

        public SitemapIndex(string baseUrl, IEnumerable<Item> sitemaps)
        {
            this.baseUrl = baseUrl;
            this.sitemaps = sitemaps.Select(sitemap => new Sitemap(sitemap["Value"])).ToList();
            sitemapIndexFile = SitemapHelper<SitemapIndexModel>.ReadSitemapFromDisk(IndexFile) ?? new SitemapIndexModel();
        }

        public void Build(string website)
        {
            foreach (var sitemap in sitemaps)
            {
                var presales = Sitecore.Configuration.Factory.GetSite(website);

                var domainUrl = string.Format("{0}://{1}/", presales.SiteInfo.Scheme, presales.SiteInfo.HostName);
                var sitemapUrl = string.Format("{0}{1}", domainUrl, sitemap.Name + ".xml.gz");

                var sitemapIndexes = sitemapIndexFile.Sitemaps.FirstOrDefault(x => x.Location.Equals(sitemapUrl, StringComparison.OrdinalIgnoreCase));
                if (sitemapIndexes == null)
                {
                    sitemapIndexes = new SitemapIndexesModel { Location = sitemapUrl, LastModified = DateTime.MinValue.ToString("o") };
                }

                if (sitemap.LastUpdated > DateTime.Parse(sitemapIndexes.LastModified))
                {
                    sitemapIndexes.LastModified = DateTime.Now.ToString("o");

                    var sitemapIndexesModel = sitemapIndexFile.Sitemaps.FirstOrDefault(x => x.Location == sitemapUrl);
                    if (sitemapIndexesModel != null)
                    {
                        sitemapIndexFile.Sitemaps.Remove(sitemapIndexesModel);
                    }
                    sitemapIndexFile.Sitemaps.Add(sitemapIndexes);

                    sitemap.BuildSitemap(website);
                }
            }

            //Update the file name to reflect the current site
            IndexFile = $"{website}_{IndexFile}";

            SitemapHelper<SitemapIndexModel>.SaveSitemapToDisk(sitemapIndexFile, IndexFile, false);
        }

        public void AddToRelativeSitemap(Item item)
        {
            var sitemapItem = SitemapSettings.From(item, baseUrl);
            if (sitemapItem.HideFromSitemap)
            {
                return;
            }

            var sitemap = sitemaps.FirstOrDefault(x => x.Name.Equals(sitemapItem.SitemapName, StringComparison.OrdinalIgnoreCase));
            if (sitemap != null)
            {
                sitemap.Add(sitemapItem);
            }
        }   
    }
}
