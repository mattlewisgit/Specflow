using System.Collections.Generic;
using System.Linq;
using MediatR;
using Sitecore.ContentSearch;

namespace Vitality.Website.Areas.Presales.Handlers.Literature
{
    public class LiteratureDocumentRootHandler : IRequestHandler<LiteratureDocumentRequest, IEnumerable<LiteratureDocumentDto>>
    {
        public IEnumerable<LiteratureDocumentDto> Handle(LiteratureDocumentRequest request)
        {
            IEnumerable<LiteratureDocumentDto> literatureDocuments = new List<LiteratureDocumentDto>();

            if (Sitecore.Context.Site != null)
            {
                var searchableIndex = string.Format("{0}_literature_library", Sitecore.Context.Site.Name);

                using (var searchContext = ContentSearchManager.GetIndex(searchableIndex).CreateSearchContext())
                {
                    var searchResult = searchContext
                        .GetQueryable<LiteratureDocumentSearchResult>()
                        .Where(document => document.Library == request.Library);

                    literatureDocuments = LiteratureDocumentDto.From(searchResult);
                }
            }

            return literatureDocuments;
        }
    }
}
