namespace Vitality.Website.Areas.Presales.BaseTemplates
{
    using System.Collections.Generic;

    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;

    using Global.Models;

    public interface IQuoteFooter
    {
        string Headline { get; set; }

        bool InheritQuoteFooterSettings { get; set; }

        bool ShowQuoteFooter { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        IEnumerable<LinkItem> QuoteFooterLinks { get; set; }
    }
}
