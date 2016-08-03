using System;
using System.Xml.Serialization;

namespace Vitality.Website.SC.Utilities.Sitemap
{
    [Serializable()]
    public class SitemapIndexesModel : IEquatable<SitemapIndexesModel>
    {
        [XmlElement("loc")]
        public string Location { get; set; }
        [XmlElement("lastmod")]
        public string LastModified { get; set; }

        public bool Equals(SitemapIndexesModel other)
        {
            return String.Equals(this.Location, other.Location, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
