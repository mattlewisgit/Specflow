using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Web.Mvc;
using Vitality.Website.Areas.Presales.Models.Products;

namespace Vitality.Website.Extensions.Views
{
    public static class ProductsComponentExtensions
    {
        public static int NumberOfColumns(this GlassView<ProductsComponent> view)
        {
            return 12 / view.Model.ProductPanels.Count();
        }
    }
}