namespace Vitality.Website.Areas.Presales.Handlers.Literature
{
    using MediatR;
    using SC;
    using Sitecore.ContentSearch;
    using System.Collections.Generic;
    using System.Linq;

    public class LiteratureDocumentHandler : IRequestHandler<LiteratureDocumentRequest, LiteratureDocumentDto>
    {
        private readonly IProviderSearchContext _searchContext;

        public LiteratureDocumentHandler()
        {
            if (Sitecore.Context.Site != null)
            {
                var searchableIndex = $"{Sitecore.Context.Site.Name}_literature_library";
                _searchContext = ContentSearchManager.GetIndex(searchableIndex).CreateSearchContext();
            }
        }

        public LiteratureDocumentDto Handle(LiteratureDocumentRequest request)
        {
            var searchResult = _searchContext
                .GetQueryable<LiteratureDocumentSearchResult>()
                .FirstOrDefault(document =>
                    document.Library == request.Library &&
                    document.Category == request.Category &&
                    document.Title == request.Title &&
                    document.TemplateId == ItemConstants.Presales.Templates.Literature.Document.Id);

            var literatureDocument = LiteratureDocumentDto
                .From(new List<LiteratureDocumentSearchResult>{ searchResult })
                .FirstOrDefault();

            if (request.IncludeAvailableLiterature && literatureDocument != null)
            {
                literatureDocument
                    .AvailableLiterature = _searchContext.GetQueryable<LiteratureDocumentSearchResult>()
                    .Where(document => document.Category == searchResult.Category
                        && document.Library == searchResult.Library)
                    .Select(LiteratureDocumentSummaryDto.From)
                    .ToArray();
            }

            return literatureDocument;
        }
    }
}
