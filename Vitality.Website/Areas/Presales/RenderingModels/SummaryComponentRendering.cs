namespace Vitality.Website.Areas.Presales.RenderingModels
{
    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;

    using Vitality.Website.Areas.Global.Models;

    [SitecoreType(TemplateId = "{7D52C634-D455-42EE-ADB6-17090ECFAFA9}", AutoMap = true)]
    public class SummaryComponentRendering
    {
        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public KeyValuePair ImageRelativePosition { get; set; }
    }
}