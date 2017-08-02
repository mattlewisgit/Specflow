using Glass.Mapper.Sc.Fields;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.PromotionSidebar
{
    using Global.Models;

    public class PromotionSidebarContent : SitecoreItem
    {
        public Image Avatar { get; set; }
        public string Content { get; set; }
    }
}
