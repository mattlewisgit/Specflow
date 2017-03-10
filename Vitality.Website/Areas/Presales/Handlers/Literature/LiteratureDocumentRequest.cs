using System.Collections.Generic;

namespace Vitality.Website.Areas.Presales.Handlers.Literature
{
    using System;

    using MediatR;

    public class LiteratureDocumentRequest : IRequest<LiteratureDocumentDto>, IRequest<IEnumerable<LiteratureDocumentDto>>
    {
        public readonly string Library;
        public readonly string Category;
        public readonly string Title;
        public readonly bool IncludeAvailableLiterature;

        public Guid DocumentId { get; set; }
        
        public LiteratureDocumentRequest(
            string library,
            string category,
            string title,
            bool includeAvailableLiterature)
        {
            this.Library = library;
            this.Category = category;
            this.Title = title;
            this.IncludeAvailableLiterature = includeAvailableLiterature;
        }

        public LiteratureDocumentRequest(string library)
        {
            this.Library = library;
        }
    }
}
