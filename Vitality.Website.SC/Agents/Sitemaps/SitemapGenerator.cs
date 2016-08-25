using System;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Links;
using Sitecore.Sites;

namespace Vitality.Website.SC.Agents.Sitemaps
{
    /// <summary>
    /// Generates sitemaps and sitemap index file.
    /// </summary>
    public class SitemapGenerator
    {
        public const string Name = "SitemapGenerator";

        private readonly Database database;
        private SitemapIndex sitemapIndex;
        private readonly string subdomain; 

        public SitemapGenerator(string databaseName, string subdomainName)
        {
            Error.AssertString(databaseName, "databaseName", false);
            database = Factory.GetDatabase(databaseName);
            subdomain = subdomainName;
        }

        public void Run()
        {   
            using (new SiteContextSwitcher(Factory.GetSite(subdomain)))
            {
                var path = Sitecore.Context.Site.StartPath;
                var homeItem = database.GetItem(path);

                if (homeItem == null)
                {
                    throw new ArgumentException("Home item not found.");
                }

                var baseUrl = LinkManager.GetItemUrl(homeItem, new UrlOptions { AlwaysIncludeServerUrl = true, LanguageEmbedding = LanguageEmbedding.Never });
                
                sitemapIndex = new SitemapIndex(baseUrl, database.GetItem(ItemConstants.Presales.Content.Configuration.Sitemaps.Path).Children);

                RecurseContentTree(homeItem);

                sitemapIndex.Build(subdomain);
            }
        }

        private void RecurseContentTree(Item item)
        {
            sitemapIndex.AddToRelativeSitemap(item);

            if (item.HasChildren)
            {
                foreach (Item child in item.Children)
                {
                    RecurseContentTree(child);
                }
            }
        }
    }
}
