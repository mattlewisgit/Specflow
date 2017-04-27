namespace Vitality.Website.Areas.Presales.ComponentTemplates.FeatureBlocks
{
    using System.Collections.Generic;
    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;
    using Global.Models;
    using SettingsTemplates;

    [SitecoreType(AutoMap = true)]
    public class VacancyList : SitecoreItem
    {
        public string AllDepartmentsText { get; set; }
        public string AllLocationsText { get; set; }
        public string ApplyForVacancyText { get; set; }
        public string BackToVacanciesListText { get; set; }

        public string ClosesOnText { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<LinkItem> Departments { get; set; }

        public string DepartmentsDropdownLabel { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public FeedSettings FeedSettings { get; set; }

        public string FeedType { get; set; }

        public string FindoutMoreText { get; set; }
        public string Headline { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<LinkItem> Locations { get; set; }

        public string LocationsDropdownLabel { get; set; }

        public string LocationText { get; set; }
        public string NoVacanciesFoundText { get; set; }


        public string SalaryText { get; set; }
        public string ShareVacancyText { get; set; }
    }
}
