using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    using  Global.Models;
    using SettingsTemplates;

    public class QuoteApplyForm : SitecoreItem
    {
        public string ChildDobSeperatorLabel { get; set; }
        public string ChildDobLastLabel { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<QuestionGroup> QuestionGroups { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public FeedSettings PostcodeFeed { get; set; }
        public string TermsAndCondition { get; set; }
    }
}
