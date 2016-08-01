using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Items;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Diagnostics;
using System.Web;
using Sitecore.Links;
using Vitality.Website.SC.Utilities.Sitemap;
using System.IO;

namespace Vitality.Website.SC.Agents
{
    /// <summary>
    /// Generates sitemaps and sitemap index file.
    /// </summary>
    public class SitemapGenerator
    {
        private readonly string databaseName;
        
        public Database Database
        {
            get
            {
                Database database = Factory.GetDatabase(this.databaseName);
                Error.Assert(database != null, "Could not find database: " + this.databaseName);
                return database;
            }
        }

        public SitemapGenerator(string databaseName)
        {
            Error.AssertString(databaseName, "databaseName", false);
            this.databaseName = databaseName;
        }

        public void Run()
        {
            var homeItem = Database.GetItem(new ID(ItemConstants.Presales.Content.Home.Id));

            if (homeItem == null)
            {
                throw new ArgumentException("Home item not found.");
            }

            // Read sitemap index file from disk
            SitemapIndexModel sitemapIndexFile = SitemapHelper<SitemapIndexModel>.ReadSitemapFromDisk(ItemConstants.Presales.Content.SitemapSettings.IndexFile);
            sitemapIndexFile = sitemapIndexFile ?? new SitemapIndexModel();

            // Retrieve all top level pages that have an associated sitemap.
            var sectionPages = homeItem.Children.Where(
                p => p.Fields[ItemConstants.Presales.Content.SitemapSettings.HideFromSitemapField] != null 
                    && !IsChecked(p.Fields[ItemConstants.Presales.Content.SitemapSettings.HideFromSitemapField].Value) 
                    && !string.IsNullOrWhiteSpace(p.Fields[ItemConstants.Presales.Content.SitemapSettings.SitemapField].Value))
                .Select(GetSitemapSettings);
            
            var sectionPagesCollection = sectionPages as IList<SitemapSettings> ?? sectionPages.ToList();

            var itemUri = new Uri(LinkManager.GetItemUrl(homeItem));
            var domainUrl = string.Format("{0}://{1}/", itemUri.Scheme, itemUri.Host);

            // Retrieve all used sitemaps.
            var allSitemaps =
                sectionPagesCollection.Select(
                    p => string.Format("{0}{1}.xml.gz", domainUrl, Database.GetItem(p.SitemapItemId).Fields["Value"].Value));

            // Remove any existing sitemaps from index file that are no longer referenced.
            sitemapIndexFile.Sitemaps.RemoveAll(p => !allSitemaps.Contains(p.Location));

            foreach (var sectionPage in sectionPagesCollection)
            {
                // Retrieve all pages which will be used to populate sitemap.
                var sectionChildPages = sectionPage.Item.Axes.GetDescendants()
                    .Where(p => !IsChecked(p.Fields[ItemConstants.Presales.Content.SitemapSettings.HideFromSitemapField].Value)).ToList();

                // Add current page to page collection.
                sectionChildPages.Insert(0, sectionPage.Item);

                if (sectionChildPages.Any())
                {
                    var sitemapName = string.Format("{0}.xml.gz", Database.GetItem(sectionPage.SitemapItemId).Fields["Value"].Value);
                    var sitemapUrl = string.Format("{0}{1}", domainUrl, sitemapName);

                    DateTime sitemapLastModified = DateTime.MinValue;

                    if (sitemapIndexFile != null && sitemapIndexFile.Sitemaps != null && sitemapIndexFile.Sitemaps.Any(p => p.Location.Equals(sitemapUrl)))
                    {
                        // Retrieve lastmod date of sitemap from index file.
                        sitemapLastModified = DateTime.Parse(sitemapIndexFile.Sitemaps.FirstOrDefault(p => p.Location.Equals(sitemapUrl)).LastModified);
                    }                        

                    // Retrieve most recent published date of child pages.
                    var lastPublished = sectionChildPages.Max(p => p.Statistics.Updated);
                    
                    string xmlFile = string.Format("{0}{1}", HttpRuntime.AppDomainAppPath, sitemapName);

                    // Regenerate sitemap if new published content exists.
                    if ((lastPublished > sitemapLastModified) || !File.Exists(xmlFile))
                    {
                        BuildSiteMap(sectionChildPages, sitemapName);
                    }

                    // Update sitemaps lastmod date within index file.
                    var sitemapIndexRow =
                        sitemapIndexFile.Sitemaps.FirstOrDefault(
                            p => p.Location.ToLowerInvariant() == sitemapUrl.ToLowerInvariant());

                    string dateTime = DateTime.Now.ToString("yyyy-MM-dd" + "T" + "hh:mm:ss");
                    if (sitemapIndexRow == null)
                    {
                        sitemapIndexFile.Sitemaps.Add(new SitemapIndexesModel {Location = sitemapUrl, LastModified = dateTime});
                    }
                    else
                    {
                        sitemapIndexRow.LastModified = dateTime;
                    }

                    // Save changes to sitemap index file.
                    SitemapHelper<SitemapIndexModel>.SaveSitemapToDisk(sitemapIndexFile, ItemConstants.Presales.Content.SitemapSettings.IndexFile, false);
                }
            }

            // Ensure sitemap index file exists.
            if (!File.Exists(string.Format("{0}{1}", HttpRuntime.AppDomainAppPath, sitemapIndexFile)))
            {
                SitemapHelper<SitemapIndexModel>.SaveSitemapToDisk(sitemapIndexFile, ItemConstants.Presales.Content.SitemapSettings.IndexFile, false);
            }
        }

        /// <summary>
        /// Generates sitemap file and saves to disk.
        /// </summary>
        /// <param name="sectionChildPages">Items used to populate sitemap.</param>
        /// <param name="sitemapName">Sitemap filename.</param>
        private void BuildSiteMap(IEnumerable<Item> sectionChildPages, string sitemapName)
        {
            SitemapModel model = new SitemapModel();
            model.SchemaLocation = "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd";

            foreach (var page in sectionChildPages)
            {
                var sitemapModel = GetSitemapSettings(page);
                model.Urls.Add(new SitemapUrlModel
                {
                    Location = sitemapModel.PageUrl.EndsWith("/") ? sitemapModel.PageUrl : sitemapModel.PageUrl + "/",
                    ChangeFrequency = sitemapModel.ChangeFrequency,
                    Priority = sitemapModel.Priority
                });
            }

            SitemapHelper<SitemapModel>.SaveSitemapToDisk(model, sitemapName, true);
        }

        private bool IsChecked(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && value == "1";
        }

        /// <summary>
        /// Casts Item to SitemapSettings.
        /// </summary>
        /// <param name="item">Item to cast.</param>
        /// <returns>SitemapSettings object.</returns>
        private SitemapSettings GetSitemapSettings(Item item)
        {
            string itemUrl = LinkManager.GetItemUrl(item);

            // retrieve inherited settings if required
            while (item[ItemConstants.Presales.Content.SitemapSettings.InheritSitemapSettingsField] == "1" && item.ID.Guid != ItemConstants.Presales.Content.Home.Id && item.ParentID.Guid != ItemConstants.Presales.Content.Home.Id)
            {
                item = item.Parent;
            }
           
            return new SitemapSettings
            {
                Item = item,
                PageUrl = itemUrl,
                ChangeFrequency = Database.GetItem(item.Fields[ItemConstants.Presales.Content.SitemapSettings.ChangeFrequencyField].Value).Fields["Value"].Value,
                Priority = item.Fields[ItemConstants.Presales.Content.SitemapSettings.PriorityField].Value,
                SitemapItemId = GetPageSectionItem(item).Fields[ItemConstants.Presales.Content.SitemapSettings.SitemapField].Value
            };
        }

        /// <summary>
        /// Retrieves top level page item.
        /// </summary>
        /// <param name="item">Current context item.</param>
        /// <returns></returns>
        private Item GetPageSectionItem(Item item)
        {
            while (item.ParentID.Guid != ItemConstants.Presales.Content.Home.Id && item.ID.Guid != ItemConstants.Presales.Content.Home.Id)
            {
                item = item.Parent;
            }

            return item;
        }
    }
}
