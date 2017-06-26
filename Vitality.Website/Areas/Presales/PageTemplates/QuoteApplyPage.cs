using Glass.Mapper.Sc.Fields;
namespace Vitality.Website.Areas.Presales.PageTemplates
{
    using Global.Models;
    using BaseTemplates;

    public class QuoteApplyPage : SitecoreItem, IGoogleTagManagerGlobal, ISerpAppearancePage,
        IIndexationPage, IOpenGraphGlobal, IOpenGraphPage, IQubitOpenTagGlobal, IWebmasterToolsGlobal, IJsonSchemaGlobal,
        ISitemap, ISearch
    {
        public string BingSiteVerification { get; set; }
        public string ChangeFrequency { get; set; }
        public string Description { get; set; }
        public string GoogleSiteVerification { get; set; }
        public string GoogleTagManagerId { get; set; }
        public string JsonSchemaScript { get; set; }
        public bool HideFromSitemap { get; set; }
        public bool HideFromSearch { get; set; }
        public bool InheritSitemapSettings { get; set; }
        public Image Logo { get; set; }
        public string OpenGraphArticlePublisher { get; set; }
        public string OpenGraphDescription { get; set; }
        public Image OpenGraphImage { get; set; }
        public string OpenGraphIosAppId { get; set; }
        public string OpenGraphIosAppName { get; set; }
        public string OpenGraphSiteName { get; set; }
        public string OpenGraphTitle { get; set; }
        public string OpenGraphType { get; set; }
        public LinkItem Priority { get; set; }
        public string OpenGraphUrl { get; set; }
        public string QubitOpenTagId { get; set; }
        public string Robots { get; set; }
        public LinkItem Sitemap { get; set; }
        public string Title { get; set; }
    }
}
