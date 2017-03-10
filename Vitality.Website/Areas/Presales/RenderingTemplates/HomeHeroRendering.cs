namespace Vitality.Website.Areas.Presales.RenderingTemplates
{
    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;

    using Vitality.Website.Areas.Global.Models;

    [SitecoreType(TemplateId = "{A91288D3-080B-4E0A-8253-96C70D78B30C}", AutoMap = true)]
    public class HomeHeroRendering
    {
        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public KeyValuePair FontTheme { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public KeyValuePair ImageRelativePosition { get; set; }
    }
}
