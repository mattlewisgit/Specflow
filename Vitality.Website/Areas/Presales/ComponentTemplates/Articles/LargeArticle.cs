using Glass.Mapper.Sc.Configuration.Attributes;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.ContentCollection
{
    [SitecoreType(AutoMap = true)]
    public class LargeArticle :ContentArticle
    {
        public string  TextCss { get; set; }
        public string ButtonCss { get; set; }
    }
}