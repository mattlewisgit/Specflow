﻿using System.Collections.Generic;

namespace Vitality.Website.Areas.Presales.Handlers.Literature
{
    using System;
    using System.Linq;

    using MediatR;

    using Sitecore.ContentSearch;

    using Vitality.Website.SC;

    public class LiteratureDocumentHandler : IRequestHandler<LiteratureDocumentRequest, LiteratureDocumentDto>
    {
        private readonly IProviderSearchContext searchContext;

        public LiteratureDocumentHandler(Func<string, IProviderSearchContext> searchContextFactory)
        {
            this.searchContext = searchContextFactory("literature_library");
        }

        public LiteratureDocumentDto Handle(LiteratureDocumentRequest request)
        {
            var searchResult = this.searchContext
                .GetQueryable<LiteratureDocumentSearchResult>()
                .FirstOrDefault(document => 
                    document.Library == request.Library && 
                    document.Category == request.Category &&
                    document.Title == request.Title &&
                    document.TemplateId == ItemConstants.Presales.Templates.Literature.Document.Id);
            var literatureDocument = LiteratureDocumentDto.From(new List<LiteratureDocumentSearchResult>{searchResult}).FirstOrDefault();

            if (request.IncludeAvailableLiterature)
            {
                if (literatureDocument != null)
                {
                    literatureDocument.AvailableLiterature = searchContext.GetQueryable<LiteratureDocumentSearchResult>()
                            .Where(document => document.Category == searchResult.Category && document.Library == searchResult.Library)
                            .Select(LiteratureDocumentSummaryDto.From)
                            .ToArray();
                }
            }

            return literatureDocument;
        }
    }
}