using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.PromotionSidebar
{
    using Global.Models;

    public class PromotionSidebar : SitecoreItem
    {
        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<PromotionSidebarContent> Promotions { get; set; }
    }
}
