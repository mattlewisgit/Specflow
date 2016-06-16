using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;
using Vitality.Website.Areas.Presales.BaseTemplates;

namespace Vitality.Website.Areas.Presales.SettingsTemplates
{
    public class GlobalSettings : SitecoreItem, IAppReferenceGlobal, IBrowserLatencyGlobal, IBrowserStylingGlobal, IDuplicateContentPage, IGoogleAuthorshipGlobal, IGoogleTagManagerGlobal, 
        IIndexationPage, IOpenGraphGlobal, IOpenGraphPage, IQubitOpenTagGlobal, IResponseTapGlobal, ISerpAppearancePage, ITwitterGlobal, ITwitterPage, IWebmasterToolsGlobal
    {
        public string AppleITunesApp { get; set; }
        public string[] DnsPrefetch { get; set; }
        public string ApplicationName { get; set; }
        public string Canonical { get; set; }
        public string Publisher { get; set; }
        public string GoogleTagManagerScript { get; set; }
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
        public string QubitOpenTagScript { get; set; }
        public string ResponseTapScript { get; set; }
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
    }
}