namespace Vitality.Website.Areas.Presales.ComponentTemplates.Products
{
    using System.Collections.Generic;

    using Glass.Mapper.Sc.Configuration.Attributes;

    using Global.Models;

    public class ProductsComponent : SitecoreItem
    {
        [SitecoreChildren]
        public IEnumerable<ProductPanel> ProductPanels { get; set; }
    }
}
