using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using Sitecore.ContentSearch;

namespace Vitality.Website.Areas.Presales.Handlers.Literature
{
    public class LiteratureDocumentRootHandler : IRequestHandler<LiteratureDocumentRequest, IEnumerable<LiteratureDocumentDto>>
    {
        private readonly IProviderSearchContext searchContext;

        public LiteratureDocumentRootHandler(Func<string, IProviderSearchContext> searchContextFactory)
        {
            this.searchContext = searchContextFactory("literature_library");
        }

        public IEnumerable<LiteratureDocumentDto> Handle(LiteratureDocumentRequest request)
        {
            var searchResult = this.searchContext
                .GetQueryable<LiteratureDocumentSearchResult>()
                .Where(document => document.Library == request.Library);
            
            return LiteratureDocumentDto.From(searchResult);
        }
    }
}