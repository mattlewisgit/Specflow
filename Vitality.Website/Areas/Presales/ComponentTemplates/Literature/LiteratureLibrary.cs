namespace Vitality.Website.Areas.Presales.ComponentTemplates.Literature
{
    using System.Collections.Generic;

    using Glass.Mapper.Sc.Configuration.Attributes;

    using Global.Models;

    public class LiteratureLibrary : SitecoreItem
    {
        [SitecoreChildren]
        public IEnumerable<LiteratureCategory> Categories { get; set; }
    }
}
