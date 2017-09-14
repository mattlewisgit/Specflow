using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    public class Benefit : SitecoreItem
    {
        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<BenefitOption> BenefitOptions { get; set; }
        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public KeyValuePair Code { get; set; }
        public string EditTitle { get; set; }
        public string EditTooltip { get; set; }
        public bool IsEditable { get; set; }
        public Image Icon { get; set; }
        public bool IsModule { get; set; }
        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public KeyValuePair SelectedOption { get; set; }
        public string Title { get; set; }
        public string Tooltip { get; set; }
    }
}
