using Glass.Mapper.Sc.Configuration.Attributes;
using Vitality.Website.Areas.Global.Models;
using Glass.Mapper.Sc.Fields;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.FeatureBlocks
{
    [SitecoreType(AutoMap = true)]
    public class VacancyList : SitecoreItem
    {
        public string Headline { get; set; }
        public string LocationsDropdownLabel { get; set; }
        public string AllLocationsText { get; set; }
        public string DepartmentsDropdownLabel { get; set; }
        public string AllDepartmentsText { get; set; }      
        public string FindoutMoreText { get; set; }
        public string NoVacanciesFoundText { get; set; }
        public string FeedSettings { get; set; }
        
        public string LocationText { get; set; }
        public string SalaryText { get; set; }
        public string ClosesOnText { get; set; }
        public string ApplyForVacancyText { get; set; }
        public string ShareVacancyText { get; set; }
        public string BackToVacanciesListText { get; set; }
    }
}
