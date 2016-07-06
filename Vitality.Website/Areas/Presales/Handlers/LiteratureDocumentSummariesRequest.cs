namespace Vitality.Website.Areas.Presales.Handlers
{
    using System.Collections.Generic;

    using MediatR;

    public class LiteratureDocumentSummariesRequest : IRequest<IEnumerable<LiteratureDocumentSummaryDto>>
    {
        public readonly string Library;
        public readonly string Category;
        public readonly string Title;

        public LiteratureDocumentSummariesRequest(string library, string category = null, string title = null)
        {
            this.Library = library;
            this.Category = category;
            this.Title = title;
        }
    }
}