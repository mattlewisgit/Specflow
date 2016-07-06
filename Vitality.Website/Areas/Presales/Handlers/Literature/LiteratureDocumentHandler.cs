namespace Vitality.Website.Areas.Presales.Handlers.Literature
{
    using System.Linq;

    using MediatR;

    using Sitecore.ContentSearch;

    using Vitality.Website.SC;

    public class LiteratureDocumentHandler : IRequestHandler<LiteratureDocumentRequest, LiteratureDocumentDto>
    {
        private readonly IProviderSearchContext searchContext;

        public LiteratureDocumentHandler(IProviderSearchContext searchContext)
        {
            this.searchContext = searchContext;
        }

        public LiteratureDocumentDto Handle(LiteratureDocumentRequest request)
        {
            var searchResult = this.searchContext
                .GetQueryable<LiteratureDocumentSearchResult>()
                .FirstOrDefault(document => 
                    document.Library == request.Library && 
                    document.Category == request.Category &&
                    document.Title == request.Document &&
                    document.TemplateId == ItemConstants.Presales.Templates.Literature.Document.Id);
            var literatureDocument = LiteratureDocumentDto.From(searchResult);

            if (request.IncludeAvailableLiterature)
            {
                literatureDocument.AvailableLiterature = this.searchContext.GetQueryable<LiteratureDocumentSearchResult>()
                        .Where(document => document.Category == searchResult.Category && document.Library == searchResult.Library)
                        .Select(LiteratureDocumentSummaryDto.From)
                        .ToArray();
            }

            return literatureDocument;
        }
    }
}