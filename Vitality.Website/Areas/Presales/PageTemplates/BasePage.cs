using System.Collections.Generic;

namespace Vitality.Website.Areas.Presales.PageTemplates
{
    using Vitality.Website.Areas.Global.Models;
    using Vitality.Website.Areas.Presales.BaseTemplates;

    public class BasePage : IQuoteFooter
    {
        public bool ShowQuoteFooter { get; set; }

        public IEnumerable<LinkItem> QuoteFooterLinks { get; set; }

        public bool InheritQuoteFooterSettings { get; set; }
    }
}
