﻿using System;
using System.Collections.Generic;
using Glass.Mapper.Sc.Fields;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    public class BenefitViewModel
    {
        public IEnumerable<BenefitOptionViewModel> BenefitOptions { get; set; }
        public string Code { get; set; }
        public string EditTitle { get; set; }
        public string EditTooltip { get; set; }
        public Guid Id { get; set; }
        public bool IsEditable { get; set; }
        public Image Icon { get; set; }
        public bool IsModule { get; set; }
        public string SelectedOption { get; set; }
        public string Title { get; set; }
        public string Tooltip { get; set; }
    }
}
