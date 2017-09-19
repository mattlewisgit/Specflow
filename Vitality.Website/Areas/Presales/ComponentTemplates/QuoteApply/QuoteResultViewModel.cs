using System.Collections.Generic;
using Glass.Mapper.Sc.Fields;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    public class QuoteResultViewModel
    {
        public string PersonalisedGreetingText { get; set; }
        public string IntroductionText { get; set; }
        public string AlternativeCallToAction { get; set; }
        public string AlternativeCallToActionText { get; set; }
        public IEnumerable<BenefitViewModel> Benefits { get; set; }
        public string CallToAction { get; set; }
        public string CallToActionText { get; set; }
        public Image EditIcon { get; set; }
        public string HelpText { get; set; }
        public IEnumerable<PermutationViewModel> Permutations { get; set; }
        public string PrintText { get; set; }
        public string QuoteReferenceText { get; set; }
        public string QuoteValidText { get; set; }
        public string ServiceOutagePage { get; set; }
        public string TooltipButtonText { get; set; }
        public string TooltipText { get; set; }
    }
}
