﻿namespace Vitality.Website.Areas.Presales.ComponentTemplates.FeatureBlocks
{
    using System.Collections.Generic;

    public class VacancyListViewModel
    {
        public string AllDepartmentsText { get; set; }
        public string AllLocationsText { get; set; }
        public string ApplyForVacancyText { get; set; }
        public string BackToVacanciesListText { get; set; }
        public IEnumerable<string> Departments { get; set; }
        public string DepartmentsDropdownLabel { get; set; }
        public string FeedSettingsEndpoint { get; set; }
        public string FeedSettingsType { get; set; }
        public string FeedSettingsMockDataFileUrl { get; set; }
        public string FindoutMoreText { get; set; }
        public string Headline { get; set; }
        public IEnumerable<string> Locations { get; set; }
        public string LocationsDropdownLabel { get; set; }
        public string LocationText { get; set; }
        public string NoVacanciesFoundText { get; set; }
        public string SalaryText { get; set; }
        public string ShareVacancyText { get; set; }
        public string VacancyClosesOn { get; set; }
    }
}