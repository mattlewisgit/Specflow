using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    using  Global.Models;

    public class QuoteApplyForm : SitecoreItem
    {
        public string TermsAndCondition { get; set; }

        // Field Data
        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<QuestionGroup> QuestionGroups { get; set; }
    }
}
