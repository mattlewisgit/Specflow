namespace Vitality.Website.Areas.Presales.ComponentTemplates.CallToAction
{
    using System.Collections.Generic;

    using Glass.Mapper.Sc.Configuration.Attributes;

    using Vitality.Website.Areas.Global.Models;

    public class PrimaryCallToAction : SitecoreItem
    {
        [SitecoreChildren]
        public IEnumerable<CallToActionPanel> Panels { get; set; }
    }
}