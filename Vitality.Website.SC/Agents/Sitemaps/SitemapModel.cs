using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Vitality.Website.SC.Agents.Sitemaps
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
}
