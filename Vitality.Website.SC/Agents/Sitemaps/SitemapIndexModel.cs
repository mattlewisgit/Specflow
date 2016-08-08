using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Vitality.Website.SC.Agents.Sitemaps
{
    [Serializable()]
    [XmlRoot("sitemapindex", Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9")]
    public class SitemapIndexModel
    {
        public SitemapIndexModel()
        {
            Sitemaps = new List<SitemapIndexesModel>();
        }

        [XmlElement("sitemap", typeof(SitemapIndexesModel))]
        public List<SitemapIndexesModel> Sitemaps { get; set; }
    }
}
