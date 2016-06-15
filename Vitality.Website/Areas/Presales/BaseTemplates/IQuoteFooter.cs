namespace Vitality.Website.Areas.Presales.BaseTemplates
{
    using System.Collections.Generic;

    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Maps;

    using Vitality.Website.Areas.Global.Models;
    using Vitality.Website.Areas.Presales.SettingsTemplates;
    using Vitality.Website.SC;

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
                    context => context.Service.GetItem<QuoteFooter>(ItemConstants.Presales.Content.Configuration.QuoteFooter.Id).Headline)
                );
        }
    }
}
