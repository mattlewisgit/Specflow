using Glass.Mapper.Sc.Fields;

using Vitality.Website.Areas.Global.Models;
using Vitality.Website.Areas.Presales.BaseTemplates;

namespace Vitality.Website.Areas.Presales.SettingsTemplates
{
    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Maps;

    [SitecoreType(Cachable = true)]
    public class SiteSettings : SitecoreItem, IAppReferenceGlobal, IBrowserLatencyGlobal, IBrowserStylingGlobal, IDuplicateContentPage, IGoogleAuthorshipGlobal, IGoogleTagManagerGlobal,
        IIndexationPage, IOpenGraphGlobal, IOpenGraphPage, IQubitOpenTagGlobal, ISerpAppearancePage, ITwitterGlobal, ITwitterPage, IWebmasterToolsGlobal, IJsonSchemaGlobal
    {
        public string AppleITunesApp { get; set; }
        public string[] DnsPrefetch { get; set; }
        public string ApplicationName { get; set; }
        public string Canonical { get; set; }
        public string Publisher { get; set; }
        public string GoogleTagManagerId { get; set; }
        public string Robots { get; set; }
        public string OpenGraphArticlePublisher { get; set; }
        public string OpenGraphIosAppId { get; set; }
        public string OpenGraphIosAppName { get; set; }
        public string OpenGraphTitle { get; set; }
        public string OpenGraphType { get; set; }
        public string OpenGraphUrl { get; set; }
        public Image OpenGraphImage { get; set; }
        public string OpenGraphSiteName { get; set; }
        public string OpenGraphDescription { get; set; }
        public string QubitOpenTagId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TwitterCard { get; set; }
        public string TwitterAppIPhoneId { get; set; }
        public string TwitterAppIPhoneName { get; set; }
        public string TwitterSite { get; set; }
        public string TwitterTitle { get; set; }
        public string TwitterDescription { get; set; }
        public Image TwitterImage { get; set; }
        public string GoogleSiteVerification { get; set; }
        public string BingSiteVerification { get; set; }
        public string JsonSchemaScript { get; set; }
    }

    public class SiteSettingsConfig : SitecoreGlassMap<SiteSettings>
    {
        public override void Configure()
        {
            this.Map(
                x => x.AutoMap(),
                x => x.Delegate(settings => settings.DnsPrefetch).GetValue(context => context.Item["DnsPrefetch"].Split('|')));
        }
    }
}
