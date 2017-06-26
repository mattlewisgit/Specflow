using System.Collections.Generic;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    public class QuoteApplyFormViewModel
    {
        public string ChildDobSeperatorLabel { get; set; }
        public string ChildDobLastLabel { get; set; }
        public IEnumerable<QuestionGroupViewModel> QuestionGroups { get; set; }
        public string PostcodeFeedEndpoint { get; set; }

        public string TermsAndCondition { get; set; }
    }
}
