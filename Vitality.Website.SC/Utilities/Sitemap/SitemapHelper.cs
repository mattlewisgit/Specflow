using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Sites;
using Sitecore.Data;
using Sitecore.Web;

namespace Vitality.Website.SC.Utilities.Sitemap
{
    public class SitemapHelper<T>
    {
        public static void CreateSitemapIndexFile(IEnumerable<SitemapIndexModel> sitemaps)
        {
            /*
            XmlDocument doc = new XmlDocument();

            XmlNode xmlNode = (XmlNode)doc.CreateXmlDeclaration("1.0", "UTF-8", (string)null);
            doc.AppendChild(xmlNode);

            XmlNode sitemapIndexNode = (XmlNode)doc.CreateElement("sitemapindex");
            XmlAttribute sitemapIndexNamespace = doc.CreateAttribute("xmlns");
            sitemapIndexNamespace.Value = "http://www.sitemaps.org/schemas/sitemap/0.9";
            sitemapIndexNode.Attributes.Append(sitemapIndexNamespace);

            doc.AppendChild(sitemapIndexNode);

            foreach (SitemapIndexModel sitemap in sitemaps)
            {
                XmlNode sitemapNode = (XmlNode) doc.CreateElement("sitemap");
                doc.AppendChild(sitemapNode);
                
                XmlNode locationNode = (XmlNode)doc.CreateElement("loc");
                locationNode.Value = sitemap.Location;
                sitemapNode.AppendChild(locationNode);

                XmlNode lastModifiedNode = (XmlNode)doc.CreateElement("lastmod");
                lastModifiedNode.Value = sitemap.LastModified;
                sitemapNode.AppendChild(sitemapNode);                
            }

            SaveSitemapToDisk(doc.OuterXml, "sitemapindex.xml");
             * */
        }

        public static void SaveSitemapToDisk(T model, string sitemapName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            var xmlWriterSetting = new XmlWriterSettings()
            {
                Encoding = System.Text.Encoding.UTF8,
                Indent = true,
                OmitXmlDeclaration = false
            };

            string xmlFile = string.Format("{0}{1}", HttpRuntime.AppDomainAppPath, sitemapName);

            using (XmlWriter writer = XmlWriter.Create(xmlFile, xmlWriterSetting))
            {
                serializer.Serialize(writer, model);
            }
        }

        public static T ReadSitemapFromDisk(string sitemapName)
        {
            T model = default(T);

            string xmlFile = string.Format("{0}{1}", HttpRuntime.AppDomainAppPath, sitemapName);

            if (File.Exists(xmlFile))
            {
                XmlSerializer serializer = new XmlSerializer(typeof (T));

                using (XmlReader reader = XmlReader.Create(xmlFile))
                {
                    model = (T) serializer.Deserialize(reader);
                }
            }
            //else
            //{
            //    SaveSitemapToDisk(model, sitemapName);
            //}

            return model;
        }
    }
}
