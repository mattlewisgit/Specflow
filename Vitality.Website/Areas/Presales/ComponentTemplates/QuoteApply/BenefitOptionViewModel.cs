using System;
using System.Collections.Generic;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    public class BenefitOptionViewModel
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public IEnumerable<Guid> PermutationIds { get; set; }
        public string Title { get; set; }
    }
}
