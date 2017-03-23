using System;
using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.Generic
{
    public class ArticleItem : SitecoreItem
    {
        public ArticleItem()
        {
            Image = new Image();
        }

        public Image Image { get; set; }

        public string LeadIn { get; set; }

        public string Title { get; set; }

        public Link Link { get; set; }
    }
}
