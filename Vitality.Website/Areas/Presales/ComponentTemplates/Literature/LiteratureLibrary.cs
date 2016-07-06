namespace Vitality.Website.Areas.Presales.ComponentTemplates.Literature
{
    using System.Collections.Generic;

    using Vitality.Website.Areas.Global.Models;

    public class LiteratureLibrary : SitecoreItem
    {
        public IEnumerable<LiteratureCategory> Categories { get; set; }
    }
}