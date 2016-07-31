using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Vitality.Website.SC.Utilities.Sitemap
{
    [Serializable()]
    [XmlRoot("urlset", Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9")]
    public class SitemapModel
    {
        public SitemapModel()
        {
            Urls = new List<SitemapUrlModel>();
        }

        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }
        
        [XmlElement("url", typeof(SitemapUrlModel))]        
        public List<SitemapUrlModel> Urls { get; set; }
    }

    [Serializable()]
    public class SitemapUrlModel
    {
        [XmlElement("loc")]
        public string Location { get; set; }
        [XmlElement("changefreq")]
        public string ChangeFrequency { get; set; }
        [XmlElement("priority")]
        public string Priority { get; set; }
    }
}
