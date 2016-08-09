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

        public SitemapGenerator(string databaseName)
        {
            Error.AssertString(databaseName, "databaseName", false);
            this.database = Factory.GetDatabase(databaseName);
        }

        public void Run()
        {
            var homeItem = database.GetItem(new ID(ItemConstants.Presales.Content.Home.Id));
            if (homeItem == null)
            {
                throw new ArgumentException("Home item not found.");
            }

            string baseUrl;
            using (new SiteContextSwitcher(Factory.GetSite("presales")))
            {
                baseUrl = LinkManager.GetItemUrl(homeItem, new UrlOptions { AlwaysIncludeServerUrl = true, LanguageEmbedding = LanguageEmbedding.Never });
            }

            sitemapIndex = new SitemapIndex(baseUrl, database.GetItem(new ID(ItemConstants.Presales.Content.Configuration.Sitemaps.Id)).Children);

            RecurseContentTree(homeItem);

            sitemapIndex.Build();
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
