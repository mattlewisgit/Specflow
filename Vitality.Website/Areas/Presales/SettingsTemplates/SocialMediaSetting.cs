using Glass.Mapper.Sc.Configuration.Attributes;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.SettingsTemplates
{
    [SitecoreType(Cachable = true, AutoMap = true)]
    public class SocialMediaSetting :SitecoreItem
    { 
        public string AppKey { get; set; }
        public string AppSecret { get; set; }
        public string PageOrUserId { get; set; }
        public string SiteName { get; set; }
    }
}