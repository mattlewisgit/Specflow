using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    public class QuoteApplyFooter : SitecoreItem
    {
        public Link CallToAction { get; set; }
        public string CallToActionText { get; set; }
        public string CallUsText { get; set; }
        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public KeyValuePair ContactNumber { get; set; }
        public bool EnableProgressBar { get; set; }
        public Image LeftImage { get; set; }
        public Image MiddleImage { get; set; }
        public Image RightImage { get; set; }
        public bool IsFormAttached { get; set; }
        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public KeyValuePair OpeningHoursText { get; set; }
    }
}
