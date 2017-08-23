using System;
using Glass.Mapper.Sc.Fields;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    public class BenefitViewModel
    {
        public Guid Id { get; set; }
        public bool IsEditable { get; set; }
        public Image Image { get; set; }
        public string Title { get; set; }
        public string Tooltip { get; set; }
    }
}
