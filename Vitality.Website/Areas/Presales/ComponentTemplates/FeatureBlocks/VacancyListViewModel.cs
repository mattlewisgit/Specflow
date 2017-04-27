using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.FeatureBlocks
{
    public class VacancyListViewModel
    {
        public string Headline { get; set; }
        public string LocationsLabel { get; set; }
        public string AllLocations { get; set; }
        public string DepartmentsLabel { get; set; }
        public string AllDepartments { get; set; }
        public string FindOutMore { get; set; }
        public string NoVacancies { get; set; }
        public string VacancyLocation { get; set; }
        public string VacancySalary { get; set; }
        public string VacancyClosesOn { get; set; }
        public string ApplyForVacancy { get; set; }
        public string ShareForVacancy { get; set; }
        public string BackToVacancyListing { get; set; }
        public IEnumerable<string> Locations { get; set; }
        public IEnumerable<string> Departments { get; set; }
        public string FeedSettingsEndpoint { get; set; }
        public string FeedSettingsMockDataFileUrl { get; set; }
    }
}
