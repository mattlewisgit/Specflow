using Glass.Mapper.Sc.Configuration.Attributes;
using Vitality.Website.App.Interfaces;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.SettingsTemplates
{
    [SitecoreType(AutoMap = true)]
    public class FeedSettings : SitecoreItem, IFeedSettings
    {
        public string MockDataFile { get; set; }
        public string Password { get; set; }
        public string FeedUrl { get; set; }
        public string Username { get; set; }
    }
}
