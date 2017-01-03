using Glass.Mapper.Sc.Configuration.Attributes;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.Articles
{
    [SitecoreType(AutoMap = true)]
    public class SmallArticle : ContentArticle
    {
        public string TextCss { get; set; }
    }
}