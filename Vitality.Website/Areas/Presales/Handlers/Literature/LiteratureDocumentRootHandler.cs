using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using Sitecore.ContentSearch;

namespace Vitality.Website.Areas.Presales.Handlers.Literature
{
    public class LiteratureDocumentRootHandler : IRequestHandler<LiteratureDocumentRequest, IEnumerable<LiteratureDocumentDto>>
    {
        private readonly IProviderSearchContext _searchContext;

        public LiteratureDocumentRootHandler()
        {
            if (Sitecore.Context.Site != null)
            {
                var searchableIndex = string.Format("{0}_literature_library", Sitecore.Context.Site.Name);
                this._searchContext = ContentSearchManager.GetIndex(searchableIndex).CreateSearchContext();
            }
        }

        public IEnumerable<LiteratureDocumentDto> Handle(LiteratureDocumentRequest request)
        {
            var searchResult = this._searchContext
                .GetQueryable<LiteratureDocumentSearchResult>()
                .Where(document => document.Library == request.Library);
            
            return LiteratureDocumentDto.From(searchResult);
        }
    }
}
