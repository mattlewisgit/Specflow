using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    public class QuoteResultViewModel
    {
        public IEnumerable<BenefitViewModel> Benefits { get; set; }

        public string CallToActionText { get; set; }
        public string HelpText { get; set; }

        public IEnumerable<PermutationViewModel> Permutations { get; set; }

        public string PrintText { get; set; }
        public string QuoteReferenceText { get; set; }
        public string QuoteValidText { get; set; }
    }
}
