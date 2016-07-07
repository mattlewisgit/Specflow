namespace Vitality.Website.Areas.Presales.Handlers.Literature
{
    using System;

    using MediatR;

    public class LiteratureDocumentRequest : IRequest<LiteratureDocumentDto>
    {
        public readonly string Library;
        public readonly string Category;
        public readonly string Document;
        public readonly bool IncludeAvailableLiterature;

        public Guid DocumentId { get; set; }
        
        public LiteratureDocumentRequest(
            string library,
            string category,
            string document,
            bool includeAvailableLiterature)
        {
            this.Library = library;
            this.Category = category;
            this.Document = document;
            this.IncludeAvailableLiterature = includeAvailableLiterature;
        }
    }
}