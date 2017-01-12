using Glass.Mapper.Sc.Configuration.Attributes;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.Articles
{
    [SitecoreType(AutoMap = true)]
    public class MediumArticle : ContentArticle
    {
        public string OpeningParagraph { get; set; }
    }
}