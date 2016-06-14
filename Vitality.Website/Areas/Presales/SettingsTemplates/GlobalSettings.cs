using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vitality.Website.Areas.Global.Models;
using Vitality.Website.Areas.Presales.BaseTemplates;

namespace Vitality.Website.Areas.Presales.SettingsTemplates
{
    public class GlobalSettings : SitecoreItem, IAnalyticsGlobal, IAppReferenceGlobal, IBrowserLatencyGlobal, IBrowserStylingGlobal, IContentFormatGlobal, IGoogleAuthorshipGlobal, IOpenGraphGlobal, IResponsiveDesignGlobal, ITwitterGlobal
    {
        public string Referrer { get; set; }
        public string AppleITunesApp { get; set; }
        public string DnsPrefetch { get; set; }
        public string IeNavButtonColour { get; set; }
        public string ApplicationName { get; set; }
        public string Charset { get; set; }
        public string Publisher { get; set; }
        public string OpenGraphLocale { get; set; }
        public string OpenGraphArticlePublisher { get; set; }
        public string OpenGraphIosAppId { get; set; }
        public string OpenGraphIosAppName { get; set; }
        public string HandheldFriendly { get; set; }
        public string Viewport { get; set; }
        public string TwitterCard { get; set; }
        public string TwitterAppIPhoneId { get; set; }
        public string TwitterAppIPhoneName { get; set; }
    }
}