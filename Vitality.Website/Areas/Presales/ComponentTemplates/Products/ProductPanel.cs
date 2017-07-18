namespace Vitality.Website.Areas.Presales.ComponentTemplates.Products
{
    using Glass.Mapper.Sc.Fields;

    using Global.Models;

    public class ProductPanel : SitecoreItem
    {
        public Image Image { get; set; }

        public string OpeningParagraph { get; set; }

        public Link CallToAction { get; set; }
    }
}
