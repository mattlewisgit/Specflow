namespace Vitality.Website.Extensions.Views
{
    using System.Collections.Generic;
    using System.Linq;

    using Glass.Mapper.Sc.Web.Mvc;

    using Vitality.Website.Areas.Presales.ComponentTemplates.Navigation;

    public static class GlobalFooterExtensions
    {
        public static IEnumerable<FooterSection> FooterSections(this GlassView<GlobalFooter> view)
        {
            var allcolumns = new List<FooterSection>();
            allcolumns.AddRange(view.Model.FooterLinksColumn1);
            allcolumns.AddRange(view.Model.FooterLinksColumn2);
            allcolumns.AddRange(view.Model.FooterLinksColumn3);
            return allcolumns;
        }

        public static IEnumerable<IGrouping<int, FooterSection>> GroupFooterSectionsByColumn(this GlassView<GlobalFooter> view)
        {
            var column1 = view.Model.FooterLinksColumn1.GroupBy(item => 1);
            var column2 = view.Model.FooterLinksColumn2.GroupBy(item => 2);
            var column3 = view.Model.FooterLinksColumn3.GroupBy(item => 3);

            return column1.Concat(column2.Concat(column3));
        }
    }
}