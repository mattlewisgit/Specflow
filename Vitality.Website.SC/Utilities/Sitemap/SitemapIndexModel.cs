using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Vitality.Website.SC.Utilities.Sitemap
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
