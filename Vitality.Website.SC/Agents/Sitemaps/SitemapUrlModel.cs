using System;
using System.Xml.Serialization;

namespace Vitality.Website.SC.Agents.Sitemaps
{
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
