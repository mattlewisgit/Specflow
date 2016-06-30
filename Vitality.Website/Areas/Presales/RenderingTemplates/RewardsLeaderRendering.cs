namespace Vitality.Website.Areas.Presales.RenderingTemplates
{
    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;

    using Vitality.Website.Areas.Global.Models;

    [SitecoreType(TemplateId = "{A76E5C3E-5239-4D0D-A730-100E747B7D89}", AutoMap = true)]
    public class RewardsLeaderRendering
    {
        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public KeyValuePair BackgroundColour { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public KeyValuePair IconsPerRow { get; set; }
    }
}