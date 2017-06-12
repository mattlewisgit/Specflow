using System.Collections.Generic;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    public class QuoteApplyFormViewModel
    {
        public string TermsAndCondition { get; set; }
        public IEnumerable<QuestionGroupViewModel> QuestionGroups { get; set; }
    }
}
