namespace Vitality.Website.Areas.Presales.RenderingModels
{
    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;

    using Vitality.Website.Areas.Global.Models;

    [SitecoreType(TemplateId = "{B9CDB7FF-850D-4B1E-9EF0-05F29F29B16E}", AutoMap = true)]
    public class BenefitLeaderRendering
    {
        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public KeyValuePair BackgroundColour { get; set; }
        public bool BackgroundImageLeft { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public KeyValuePair BackgroundPostion { get; set; }
    }
}