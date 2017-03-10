namespace Vitality.Website.Extensions.Views
{
    using System.Collections.Generic;
    using System.Linq;

    using Glass.Mapper.Sc.Web.Mvc;

    using Vitality.Website.Areas.Presales.ComponentTemplates.Literature;
    using Vitality.Website.Areas.Presales.PageTemplates;

    public static class LiteratureLibraryPageExtensions
    {
        public static IEnumerable<LiteratureCategory> LiteratureCategories(this GlassView<LiteratureLibraryPage> view)
        {
            if (view.Model.LiteratureLibrary != null && view.Model.LiteratureLibrary.Categories != null)
            {
                return view.Model.LiteratureLibrary.Categories;
            }
            return Enumerable.Empty<LiteratureCategory>();
        }
    }
}
