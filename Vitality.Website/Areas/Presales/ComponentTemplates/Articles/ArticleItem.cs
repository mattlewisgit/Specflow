using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.Articles
{
    public class ArticleItem : SitecoreItem
    {
        public Image Image { get; set; }

        public string LeadIn { get; set; }

        public string Title { get; set; }

        public Link Link { get; set; }
    }
}