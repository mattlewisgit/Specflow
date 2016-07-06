namespace Vitality.Website.Areas.Presales.PageTemplates
{
    using Glass.Mapper.Sc.Fields;

    using Vitality.Website.Areas.Global.Models;

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

        public string LiteratureHeadline { get; set; }

        public string SelectionHeadline { get; set; }
    }
}