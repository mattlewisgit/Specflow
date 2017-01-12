using Glass.Mapper.Sc.Configuration.Attributes;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.SettingsTemplates
{
    [SitecoreType(AutoMap = true)]
    public class SocialMediaSettings :SitecoreItem
    { 
        public string AppKey { get; set; }
        public string AppSecret { get; set; }
        public string EntityId { get; set; }
        public string SiteIdentifier { get; set; }
    }
}