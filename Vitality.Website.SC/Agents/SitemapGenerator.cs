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
using Sitecore.ContentSearch.Utilities;

namespace Vitality.Website.SC.Agents
{
    public static class SitemapSettings
    {
        public static readonly string HideFromSitemap = "HideFromSitemap";
        public static readonly string InheritSitemapSettings = "InheritSitemapSettings";
        public static readonly string Sitemap = "Sitemap";
        public static readonly string ChangeFrequency = "ChangeFrequency";
        public static readonly string Priority = "Priority";
    }

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
             * get child pages (page sections) - where hide from sitemap == false
             * build list of unique sitemaps
             * get all descendents of page section - where hide from sitemap == false
             * retrieve most recent published date
             * compare with lastmod date of sitemap index file
             * if any page newer, regenerate entire sitemap
             * update sitemap index file lastmod date
             */

            var homeItem = Database.GetItem(new ID(ItemConstants.Presales.Content.Home.Id));

            if (homeItem == null)
            {
                throw new ArgumentException("Home item not found.");
            }

            var sectionPages = homeItem.Children.Where(p => p.Fields[SitemapSettings.HideFromSitemap] != null && !IsChecked(p.Fields[SitemapSettings.HideFromSitemap].Value));

        }

        private bool IsChecked(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && value == "1";
        }

        private Item GetSitemapSettings(Item item)
        {
            var contextItem = item;
            while (contextItem[SitemapSettings.InheritSitemapSettings] == "1" && contextItem.ID.Guid != ItemConstants.Presales.Content.Home.Id)
            {
                contextItem = contextItem.Parent;
            }

            return contextItem;
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
