namespace Vitality.Website.UnitTests.Presales.Handlers.Literature
{
    using Shouldly;

    using Areas.Presales.Handlers.Literature;
    using TestDoubles;

    using Xunit;

    public class LiteratureDocumentSummariesHandler_Handle_Tests
    {
        private readonly LiteratureDocumentSummariesHandler handler;

        public LiteratureDocumentSummariesHandler_Handle_Tests()
        {
            handler = new LiteratureDocumentSummariesHandler(index => new SearchContextStub());
        }

        [Fact(Skip = "This is currently written as a intergration test.")]
        public void Should_be_an_empty_collection_when_no_documents_match_library_and_title()
        {
            handler.Handle(new LiteratureDocumentSummariesRequest(SearchContextStub.MatchingLibrary, title: "Health-online")).ShouldBeEmpty();
        }

        [Fact(Skip = "This is currently written as a intergration test.")]
        public void Should_contain_document_summaries_when_documents_match_library_and_title()
        {
            handler.Handle(new LiteratureDocumentSummariesRequest(SearchContextStub.MatchingLibrary, title: "cover")).ShouldNotBeEmpty();
        }

        [Fact(Skip = "This is currently written as a intergration test.")]
        public void Should_be_an_empty_collection_when_no_documents_match_library_and_category()
        {
            handler.Handle(new LiteratureDocumentSummariesRequest(SearchContextStub.MatchingLibrary, category: "adviser-healthcare")).ShouldBeEmpty();
        }

        [Fact(Skip = "This is currently written as a intergration test.")]
        public void Should_contain_document_summaries_where_category_id_matches_literature_category_id()
        {
            handler.Handle(new LiteratureDocumentSummariesRequest(SearchContextStub.MatchingLibrary, category: SearchContextStub.MatchingCategory)).ShouldNotBeEmpty();
        }

        [Fact(Skip = "This is currently written as a intergration test.")]
        public void Should_not_contain_document_summaries_when_template_is_not_a_literature_document()
        {
            handler.Handle(new LiteratureDocumentSummariesRequest(SearchContextStub.MatchingLibrary, category: SearchContextStub.MatchingCategory)).ShouldNotContain(document => document.Title == SearchContextStub.NonMatchingTitle);
        }
    }
}
