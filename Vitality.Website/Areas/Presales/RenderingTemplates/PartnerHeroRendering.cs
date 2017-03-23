namespace Vitality.Website.Areas.Presales.RenderingTemplates
{
    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;

    using Vitality.Website.Areas.Global.Models;

    [SitecoreType(TemplateId = "{5B28A872-2800-495E-86C4-D3B1EA5917A5}", AutoMap = true)]
    public class PartnerHeroRendering
    {
        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public KeyValuePair FontTheme { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public KeyValuePair ImageRelativePosition { get; set; }
    }
}
