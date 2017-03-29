namespace Vitality.Website.Areas.Presales.Handlers.Literature
{
    using Core;

    public class LiteratureDocumentSummaryDto
    {
        public string Key { get; set; }

        public string CategoryKey { get; set; }

        public string Title { get; set; }

        public static LiteratureDocumentSummaryDto From(LiteratureDocumentSearchResult searchResult) =>
            new LiteratureDocumentSummaryDto
            {
                CategoryKey = searchResult.Category.ToLowerHyphenatedWords(),
                Key = searchResult.Title.ToLowerHyphenatedWords(),
                Title = searchResult.Title
            };
    }
}
