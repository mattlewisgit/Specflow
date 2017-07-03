namespace Vitality.Website.Areas.Presales.PageTemplates
{
    using System;
    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Fields;
    using Global.Models;
    using ComponentTemplates.Literature;

    public class LiteratureLibraryPage : SitecoreItem
    {
        public string Headline { get; set; }

        public string OpeningParagraph { get; set; }

        public string CardHeadline { get; set; }

        public string CardOpeningParagraph { get; set; }

        public Link CardLink { get; set; }

        public Image CardImage { get; set; }

        public string SearchHeadline { get; set; }

        public string SearchPlaceholderText { get; set; }

        public string CategoriesHeadline { get; set; }

        public DateTime EffectivePlanDate { get; set; }

        public string LiteratureHeadline { get; set; }

        public string SelectionHeadline { get; set; }

        public string DownloadLinkText { get; set; }

        public string EmailLinkText { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public LiteratureLibrary LiteratureLibrary { get; set; }

        public string StepHeaderOne { get; set; }

        public string StepHeaderTwo { get; set; }

        public string StepHeaderThree { get; set; }

        public string StepOne { get; set; }

        public string StepTwo { get; set; }

        public string StepThree { get; set; }

        public string PreviousButtonText { get; set; }

        public string NextButtonText { get; set; }

        public string DownloadButtonText { get; set; }

        public string DayLabel { get; set; }

        public string MonthLabel { get; set; }

        public string YearLabel { get; set; }

        public string DayValidationErrorMessageOne { get; set; }

        public string DayValidationErrorMessageTwo { get; set; }

        public string MonthValidationErrorMessage { get; set; }

        public string ResultsLabel { get; set; }

        public string UnexpectedResultsLabel { get; set; }

        public string ChangeSelectionLabel { get; set; }

        public string StepHeaderTwoExample { get; set; }

        public string PlanTypes { get; set; }

        public string PlanNumbers { get; set; }

        public string NotFoundErrorMessage { get; set; }
    }
}
