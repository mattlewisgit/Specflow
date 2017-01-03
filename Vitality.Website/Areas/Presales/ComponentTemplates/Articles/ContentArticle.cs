using System;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.ContentSearch.Linq.Extensions;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.Articles
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
        [SitecoreField("__Sortorder")]
        public int SortOrder { get; set; }
    }
}
