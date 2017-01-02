using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.FeatureBlocks
{
    [SitecoreType(AutoMap = true)]
    public class SocialMedia : SitecoreItem
    {
        public SocialMedia()
        {
            Icon = new Image();
        }
        public string BackgroundColor { get; set; }
        public Link CallToAction { get; set; }
        public Image Icon { get; set; }
        public string LeadIn { get; set; }
    }
}
