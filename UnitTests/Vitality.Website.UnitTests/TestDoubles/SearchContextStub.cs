namespace Vitality.Website.UnitTests.TestDoubles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sitecore.ContentSearch;
    using Sitecore.ContentSearch.Linq.Common;
    using Sitecore.ContentSearch.Security;

    using Vitality.Website.Areas.Presales.Handlers.Literature;
    using Vitality.Website.SC;

    public class SearchContextStub : IProviderSearchContext
    {
        public static readonly string MatchingLibrary = "sales-literature";
        public static readonly string MatchingTitle = "core-cover";
        public static readonly string MatchingCategory = "personal-healthcare";
        public static readonly LiteratureDocumentSearchResult MatchingResult = new LiteratureDocumentSearchResult
                                                                                {
                                                                                    Title = MatchingTitle,
                                                                                    Library = MatchingLibrary,
                                                                                    Category = MatchingCategory,
                                                                                    TemplateId = ItemConstants.Presales.Templates.Literature.Document.Id
                                                                                };

        public static readonly string AdditionalMatchingTitle = "cancer-cover";
        public static readonly LiteratureDocumentSearchResult AdditionalMatchingResult = new LiteratureDocumentSearchResult
                                                                                {
                                                                                    Title = AdditionalMatchingTitle,
                                                                                    Library = MatchingLibrary,
                                                                                    Category = MatchingCategory,
                                                                                    TemplateId = ItemConstants.Presales.Templates.Literature.Document.Id
                                                                                };

        public static readonly string NonMatchingTitle = "business-cover";
        public static readonly LiteratureDocumentSearchResult NonMatchingResult = new LiteratureDocumentSearchResult
                                                                                    {
                                                                                        Title = NonMatchingTitle,
                                                                                        Library = MatchingLibrary,
                                                                                        Category = MatchingCategory,
                                                                                        TemplateId = Guid.NewGuid()
                                                                                    };
        
        private readonly IQueryable<LiteratureDocumentSearchResult> documents;

        public SearchContextStub()
        {
            this.documents = new[] { MatchingResult, AdditionalMatchingResult, NonMatchingResult }.AsQueryable();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TItem> GetQueryable<TItem>()
        {
            return (IQueryable<TItem>)this.documents;
        }

        public IEnumerable<SearchIndexTerm> GetTermsByFieldName(string fieldName, string prefix)
        {
            throw new NotImplementedException();
        }

        public ISearchIndex Index { get; private set; }

        public bool ConvertQueryDatesToUtc { get; set; }

        public SearchSecurityOptions SecurityOptions { get; private set; }

        public IQueryable<TItem> GetQueryable<TItem>(params IExecutionContext[] executionContexts)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TItem> GetQueryable<TItem>(IExecutionContext executionContext)
        {
            throw new NotImplementedException();
        }
    }
}
