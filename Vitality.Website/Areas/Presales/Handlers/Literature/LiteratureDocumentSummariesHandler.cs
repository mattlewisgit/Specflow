namespace Vitality.Website.Areas.Presales.Handlers.Literature
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using MediatR;

    using Sitecore.ContentSearch;
    using Sitecore.ContentSearch.Linq.Utilities;

    using Vitality.Website.SC;

    public class LiteratureDocumentSummariesHandler : IRequestHandler<LiteratureDocumentSummariesRequest, IEnumerable<LiteratureDocumentSummaryDto>>
    {
        private readonly IProviderSearchContext searchContext;

        public LiteratureDocumentSummariesHandler(Func<string, IProviderSearchContext> searchContextFactory)
        {
            this.searchContext = searchContextFactory("literature_library");
        }

        public IEnumerable<LiteratureDocumentSummaryDto> Handle(LiteratureDocumentSummariesRequest request)
        {
            var searchResults = this.searchContext
                .GetQueryable<LiteratureDocumentSearchResult>()
                .Where(this.MatchingLiteratureDocumentSummaries(request))
                .ToArray();

            return searchResults.Select(LiteratureDocumentSummaryDto.From).ToArray();
        }

        private Expression<Func<LiteratureDocumentSearchResult, bool>> MatchingLiteratureDocumentSummaries(LiteratureDocumentSummariesRequest request)
        {
            var query = PredicateBuilder.Create<LiteratureDocumentSearchResult>(document => 
                document.Library == request.Library && 
                document.TemplateId == ItemConstants.Presales.Templates.Literature.Document.Id);
            if (!string.IsNullOrWhiteSpace(request.Title))
            {
                query = query.And(document => document.Title.Contains(request.Title));
            }
            if (!string.IsNullOrWhiteSpace(request.Category))
            {
                query = query.And(document => document.Category == request.Category);
            }
            return query;
        }
    }
}
