namespace Vitality.Website.Areas.Presales.BaseTemplates
{
    using System;
    using System.Collections.Generic;

    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Maps;

    using Vitality.Website.Areas.Global.Models;
    using Vitality.Website.Areas.Presales.SettingsTemplates;

    public interface IQuoteFooter
    {
        string Headline { get; set; }

        bool InheritQuoteFooterSettings { get; set; }

        bool ShowQuoteFooter { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        IEnumerable<LinkItem> QuoteFooterLinks { get; set; }
    }

    public class QuoteFooterConfig : SitecoreGlassMap<IQuoteFooter>
    {
        public override void Configure()
        {
            this.Map(
                x => x.AutoMap(),
                x => x.Delegate(footer => footer.Headline).GetValue(
                    context => context.Service.GetItem<QuoteFooter>(Guid.Parse("{5F2E1820-3907-400D-B0F4-3C8D6DDB0989}")).Headline)
                );
        }
    }
}
