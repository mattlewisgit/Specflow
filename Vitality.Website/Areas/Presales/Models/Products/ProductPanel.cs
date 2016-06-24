using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.Models.Products
{
    public class ProductPanel : SitecoreItem
    {
        public Image Image { get; set; }

        public string OpeningParagraph { get; set; }

        public Link CallToAction { get; set; }
    }
}