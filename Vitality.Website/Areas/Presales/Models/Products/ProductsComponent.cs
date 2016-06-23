using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.Models.Products
{
    public class ProductsComponent : SitecoreItem
    {
        [SitecoreChildren]
        public IEnumerable<ProductPanel> ProductPanels { get; set; }
    }
}