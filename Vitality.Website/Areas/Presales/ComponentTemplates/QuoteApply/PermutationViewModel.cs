using System.Collections.Generic;
using Glass.Mapper.Sc.Fields;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    public class PermutationViewModel
    {
        public IEnumerable<BenefitOptionViewModel> BenefitOptions { get; set; }
        public Image CrossIcon { get; set; }
        public string ExternalIdentifier { get; set; }
        public string PerMonthText { get; set; }
        public Image TickIcon { get; set; }
        public string Title { get; set; }
    }
}
