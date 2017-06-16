using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Vitality.Website.Areas.Presales.SettingsTemplates;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    using  Global.Models;

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
