namespace Vitality.Website.UnitTests.Presales.Handlers.Literature
{
    using Shouldly;

    using Vitality.Website.Areas.Presales.Handlers.Literature;
    using Vitality.Website.UnitTests.TestDoubles;

    using Xunit;

    public class LiteratureDocumentSummariesHandler_Handle_Tests
    {
        private readonly LiteratureDocumentSummariesHandler handler;

        public LiteratureDocumentSummariesHandler_Handle_Tests()
        {
            this.handler = new LiteratureDocumentSummariesHandler(new SearchContextStub());
        }

        [Fact]
        public void Should_be_an_empty_collection_when_no_documents_match_library_and_title()
        {
            this.handler.Handle(new LiteratureDocumentSummariesRequest(SearchContextStub.MatchingLibrary, title: "Health-online")).ShouldBeEmpty();
        }

        [Fact]
        public void Should_contain_document_summaries_when_documents_match_library_and_title()
        {
            this.handler.Handle(new LiteratureDocumentSummariesRequest(SearchContextStub.MatchingLibrary, title: "cover")).ShouldNotBeEmpty();
        }

        [Fact]
        public void Should_be_an_empty_collection_when_no_documents_match_library_and_category()
        {
            this.handler.Handle(new LiteratureDocumentSummariesRequest(SearchContextStub.MatchingLibrary, category: "adviser-healthcare")).ShouldBeEmpty();
        }

        [Fact]
        public void Should_contain_document_summaries_where_category_id_matches_literature_category_id()
        {
            this.handler.Handle(new LiteratureDocumentSummariesRequest(SearchContextStub.MatchingLibrary, category: SearchContextStub.MatchingCategory)).ShouldNotBeEmpty();
        }

        [Fact]
        public void Should_not_contain_document_summaries_where_template_is_not_a_literature_document()
        {
            this.handler.Handle(new LiteratureDocumentSummariesRequest(SearchContextStub.MatchingLibrary, category: SearchContextStub.MatchingCategory)).ShouldNotContain(document => document.Title == SearchContextStub.NonMatchingTitle);
        }
    }
}
