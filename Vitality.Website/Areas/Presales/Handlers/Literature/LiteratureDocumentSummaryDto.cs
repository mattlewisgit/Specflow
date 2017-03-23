namespace Vitality.Website.Areas.Presales.Handlers.Literature
{
    using Vitality.Website.Extensions;

    public class LiteratureDocumentSummaryDto
    {
        public string Key { get; set; }

        public string CategoryKey { get; set; }

        public string Title { get; set; }

        public static LiteratureDocumentSummaryDto From(LiteratureDocumentSearchResult searchResult)
        {
            return new LiteratureDocumentSummaryDto
                   {
                       Key = searchResult.Title.ToLowerHyphenatedString(),
                       CategoryKey = searchResult.Category.ToLowerHyphenatedString(),
                       Title = searchResult.Title
                   };
        }
    }
}
