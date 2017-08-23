using System.Collections.Generic;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    public class PermutationViewModel
    {
        public IEnumerable<BenefitOptionViewModel> BenefitOptions { get; set; }
        public string ExternalIdentifier { get; set; }
        public string PerMonthText { get; set; }
        public string Title { get; set; }
    }
}
