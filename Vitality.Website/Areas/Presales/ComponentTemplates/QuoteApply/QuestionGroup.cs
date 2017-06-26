using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    using Global.Models;

    public class QuestionGroup : SitecoreItem
    {
        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public KeyValuePair BasedOnKey { get; set; }
        public string BasedOnValues { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public KeyValuePair Key { get; set; }
        public string HelpText { get; set; }
        public string Label { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<Question> Questions { get; set; }
        public string ValidationMessage { get; set; }
    }
}
