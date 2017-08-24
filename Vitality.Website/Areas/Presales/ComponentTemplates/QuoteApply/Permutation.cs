using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    public class Permutation : SitecoreItem
    {
        public Image CrossIcon { get; set; }
        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public KeyValuePair ExternalIdentifier { get; set; }
        public string PerMonthText { get; set; }
        public Image TickIcon { get; set; }
        public string Title { get; set; }
    }
}
