using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using Sitecore;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.Jobs;
using System.Collections;
using System.Web;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Web;
using Vitality.Website.SC.Utilities.Sitemap;

namespace Vitality.Website.SC.Agents
{
    public class SitemapGenerator
    {
        private readonly string databaseName;
        
        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
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
            /*
             * 1. get child pages (page sections) - where hide from sitemap == false
             * 2. build list of unique sitemaps
             * 3. get all descendents of page section - where hide from sitemap == false
             * 4. retrieve most recent published date
             * 5. compare with lastmod date of sitemap index file
             * 6. if any page newer, regenerate entire sitemap
             * 7. update sitemap index file lastmod date
             */

            var homeItem = Database.GetItem(new ID(ItemConstants.Presales.Content.Home.Id));

            if (homeItem == null)
            {
                throw new ArgumentException("Home item not found.");
            }

            // gzip files before saving
            // save lastmod in date format: 2016-07-26T07:00:00+00:00

            SitemapIndexModel sitemapIndexFile = SitemapHelper<SitemapIndexModel>.ReadSitemapFromDisk(ItemConstants.Presales.Content.SitemapSettings.IndexFile);

            string hideFromSitemap = ItemConstants.Presales.Content.SitemapSettings.HideFromSitemapField;
            string sitemap = ItemConstants.Presales.Content.SitemapSettings.SitemapField;

            // 1
            var sectionPages = homeItem.Children.Where(
                p => p.Fields[hideFromSitemap] != null && !IsChecked(p.Fields[hideFromSitemap].Value) && !string.IsNullOrWhiteSpace(p.Fields[sitemap].Value))
                .Select(GetSitemapSettings);
            
            var sectionPagesCollection = sectionPages as IList<SitemapSettings> ?? sectionPages.ToList();

            // Clear any sitemaps from index file that are no longer referenced
            var allSitemaps =
                sectionPagesCollection.Select(
                    p => string.Format("http://dev.vitality.co.uk/{0}.xml.gz", Database.GetItem(p.SitemapItemId).Fields["Value"].Value));

            sitemapIndexFile.Sitemaps.RemoveAll(p => !allSitemaps.Contains(p.Location));

            // 2
            //var sitemapItems = sectionPages.Select(p => p.Sitemap).Distinct();

            // update sitemapindex item lastmod date after updating each sitemap. also set global flag that index file needs regenerating

            // iterate over collection that contains:
            // page url
            // sitemap name
            // sitemap settings

            //3 get all descendents of page section - where hide from sitemap == false
            foreach (var sectionPage in sectionPagesCollection)
            {
                var sectionChildPages = sectionPage.Item.Axes.GetDescendants()
                    .Where(p => !IsChecked(p.Fields[hideFromSitemap].Value));

                if (sectionChildPages.Any())
                {
                    var sitemapName = string.Format("{0}.xml.gz", Database.GetItem(sectionPage.SitemapItemId).Fields["Value"].Value);
                    var sitemapUrl = string.Format("{0}{1}", "http://dev.vitality.co.uk/", sitemapName);
                    string domainUrl2 = WebUtil.GetHostName();

                    // get sitemap lastmod date from index file

                    DateTime sitemapLastModified = DateTime.MinValue;

                    if (sitemapIndexFile != null && sitemapIndexFile.Sitemaps != null && sitemapIndexFile.Sitemaps.Any(p => p.Location.Equals(sitemapUrl)))
                    {
                        sitemapLastModified = DateTime.Parse(sitemapIndexFile.Sitemaps.FirstOrDefault(p => p.Location.Equals(sitemapUrl)).LastModified);
                    }                        

                    // 4 retrieve most recent published date
                    var lastPublished = sectionChildPages.Max(p => p.Statistics.Updated);
                    // 5. compare with lastmod date of sitemap index file
                    if (lastPublished > sitemapLastModified)
                    {
                        BuildSiteMap(sectionChildPages, sitemapName);

                        // TODO: dev.vitality hard coded
                        // TODO: gzip sitemap files
                    }

                    // Update index file
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

                    SitemapHelper<SitemapIndexModel>.SaveSitemapToDisk(sitemapIndexFile, ItemConstants.Presales.Content.SitemapSettings.IndexFile);
                }
            }
        }

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

            SitemapHelper<SitemapModel>.SaveSitemapToDisk(model, sitemapName);
        }

        private bool IsChecked(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && value == "1";
        }

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

        private Item GetPageSectionItem(Item item)
        {
            while (item.ParentID.Guid != ItemConstants.Presales.Content.Home.Id && item.ID.Guid != ItemConstants.Presales.Content.Home.Id)
            {
                item = item.Parent;
            }

            return item;
        }

        public void Execute(Item[] items, Sitecore.Tasks.CommandItem command, Sitecore.Tasks.ScheduleItem schedule)
        {
            Sitecore.Diagnostics.Log.Info("Generating Sitemaps...", this);

            // Use XmlDocument & StreamWriter
            // either pass all items in via query or just home item and query from there
            // command not getting executed
            // will task run on both CD servers? no need to run on CM server

            /*
            XmlDocument doc = new XmlDocument();
            XmlNode newChild1 = (XmlNode)doc.CreateXmlDeclaration("1.0", "UTF-8", (string)null);
            doc.AppendChild(newChild1);
            XmlNode newChild2 = (XmlNode)doc.CreateElement("sitemapindex");
            XmlAttribute attribute = doc.CreateAttribute("xmlns");
            attribute.Value = SitemapManagerConfiguration.XmlnsTpl;
            newChild2.Attributes.Append(attribute);
            doc.AppendChild(newChild2);
            foreach (DictionaryEntry dictionaryEntry in SitemapManager.m_Sites)
            {
                Site site = SiteManager.GetSite(dictionaryEntry.Key.ToString());
                string str = dictionaryEntry.Value.ToString();
                string serverUrlBySite = SitemapManagerConfiguration.GetServerUrlBySite(site.Name);
                doc = this.BuildSitemapIndexItem(doc, string.Format("{0}/{1}", (object)serverUrlBySite, (object)str));
            }
            return doc.OuterXml;

            string strSiteLanguage = "";
            site.Properties.TryGetValue("language", out strSiteLanguage);
            XmlDocument doc = new XmlDocument();
            XmlNode newChild1 = (XmlNode)doc.CreateXmlDeclaration("1.0", "UTF-8", (string)null);
            doc.AppendChild(newChild1);
            XmlNode newChild2 = (XmlNode)doc.CreateElement("urlset");
            XmlAttribute attribute = doc.CreateAttribute("xmlns");
            attribute.Value = SitemapManagerConfiguration.XmlnsTpl;
            newChild2.Attributes.Append(attribute);
            doc.AppendChild(newChild2);
            foreach (Item obj in items)
            {
                Language language = Enumerable.FirstOrDefault<Language>((IEnumerable<Language>)obj.Languages, (Func<Language, bool>)(i => i.Name.ToLower().Equals(strSiteLanguage.ToLower())));
                if (language != (Language)null && Enumerable.Any<Sitecore.Data.Version>((IEnumerable<Sitecore.Data.Version>)ItemManager.GetVersions(obj, language)))
                {
                    string url = SitemapManager.HtmlEncode(this.GetItemUrl(obj, site));
                    doc = this.BuildSitemapItem(doc, obj, site, url);
                }
            }
            return doc.OuterXml;


            string str = this.BuildSitemapXML(sitemapItems, site1, site2);
            StreamWriter streamWriter = new StreamWriter(path, false);
            streamWriter.Write(str);
            streamWriter.Close();
            */
            Sitecore.Diagnostics.Log.Info("Generating Sitemaps Completed.", this);
        }
    }
}
