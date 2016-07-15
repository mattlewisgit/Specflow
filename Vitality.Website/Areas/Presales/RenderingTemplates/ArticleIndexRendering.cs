using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.RenderingTemplates
{
    [SitecoreType(TemplateId = "{441108C5-0850-49B8-B169-06612AB75B3A}", AutoMap = true)]
    public class ArticleIndexRendering
    {
        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public KeyValuePair ImageRelativePosition { get; set; }
    }
}