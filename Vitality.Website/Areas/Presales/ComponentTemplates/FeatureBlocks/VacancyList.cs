using Glass.Mapper.Sc.Configuration.Attributes;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.FeatureBlocks
{
    [SitecoreType(AutoMap = true)]
    public class VacancyList : SitecoreItem
    {
        public string AllDepartmentsText { get; set; }
        public string AllLocationsText { get; set; }
        public string FindoutMoreText { get; set; }
        public string Headline { get; set; }
        public string ShowMoreText { get; set; }
    }
}
