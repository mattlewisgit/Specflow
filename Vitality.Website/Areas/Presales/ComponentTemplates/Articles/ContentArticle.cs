using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.ContentCollection
{
    [SitecoreType(AutoMap = true)]
    public class ContentArticle : SitecoreItem
    {
        public ContentArticle()
        {
            Image = new Image();
        }
        public Link CallToAction { get; set; }
        public string Headline { get; set; }
        public Image Image { get; set; }
        public string LeadIn { get; set; }
    }
}
