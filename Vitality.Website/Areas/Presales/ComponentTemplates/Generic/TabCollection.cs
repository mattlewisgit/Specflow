namespace Vitality.Website.Areas.Presales.ComponentTemplates.Generic
{
    using System.Collections.Generic;

    using Glass.Mapper.Sc.Configuration.Attributes;

    using Global.Models;

    public class TabCollection : SitecoreItem
    {
        public string Heading { get; set; }

        [SitecoreChildren]
        public IEnumerable<Tab> Tabs { get; set; }
    }
}
