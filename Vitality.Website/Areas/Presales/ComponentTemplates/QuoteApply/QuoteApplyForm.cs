using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    using Global.Models;
    using SettingsTemplates;

    public class QuoteApplyForm : SitecoreItem
    {
        public string CallToActionText { get; set; }
        public string ChildDobSeperatorLabel { get; set; }
        public string ChildDobLastLabel { get; set; }
        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<QuestionGroup> QuestionGroups { get; set; }
        public Link ServiceOutagePage { get; set; }
        public string TermsAndCondition { get; set; }
    }
}
