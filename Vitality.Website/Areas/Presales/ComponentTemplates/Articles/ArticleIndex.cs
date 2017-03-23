using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.Articles
{
    public class ArticleIndex : SitecoreItem
    {
        public string Headline { get; set; }
        
        public string OpeningParagraph { get; set; }

        [SitecoreChildren]
        public IEnumerable<ArticleItem> ArticleItems { get; set; }
    }
}
