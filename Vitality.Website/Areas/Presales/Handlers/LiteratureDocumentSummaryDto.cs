namespace Vitality.Website.Areas.Presales.Handlers
{
    using Vitality.Website.Areas.Presales.Models.Literature;
    using Vitality.Website.Extensions;

    public class LiteratureDocumentSummaryDto
    {
        public string Key { get; set; }

        public string Title { get; set; }

        public static LiteratureDocumentSummaryDto From(LiteratureDocumentSearchResult searchResult)
        {
            return new LiteratureDocumentSummaryDto
                   {
                       Key = searchResult.Title.ToLowerHyphenatedString(),
                       Title = searchResult.Title
                   };
        }
    }
}