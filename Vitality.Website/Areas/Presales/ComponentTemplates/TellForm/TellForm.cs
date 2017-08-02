using System.Collections.Generic;
using System.Collections.Specialized;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.TellForm
{
    using Global.Models;

    public class TellForm : SitecoreItem
    {
        public NameValueCollection AdditionalData { get; set; }
        public string OkBtnText { get; set; }
        public string OkBtnHelpText { get; set; }
        public string PostAction { get; set; }
        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<QuestionGroup> QuestionGroups { get; set; }
        public Link ServiceOutagePage { get; set; }
        public string TermsAndCondition { get; set; }
    }
}
