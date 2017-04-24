using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.SettingsTemplates
{
    [SitecoreType(AutoMap = true)]
    public class FeedSettings : SitecoreItem
    {
        public string Endpoint { get; set; }
        public Link MockDataFile { get; set; }
    }
}
