using System.Collections.Generic;

namespace Vitality.Website.Areas.Presales.PageTemplates
{
    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Maps;

    using Vitality.Website.Areas.Global.Models;
    using Vitality.Website.Areas.Presales.BaseTemplates;
    using Vitality.Website.Areas.Presales.SettingsTemplates;
    using Vitality.Website.SC;

    public class BasePage : SitecoreItem, IQuoteFooter
    {
        public bool ShowQuoteFooter { get; set; }

        public IEnumerable<LinkItem> QuoteFooterLinks { get; set; }

        public string Headline { get; set; }

        public bool InheritQuoteFooterSettings { get; set; }

        [SitecoreParent]
        public BasePage Parent { get; set; }
    }

    public class BasePageConfig : SitecoreGlassMap<BasePage>
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
