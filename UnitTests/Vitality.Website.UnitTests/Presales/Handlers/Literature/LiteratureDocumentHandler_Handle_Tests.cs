namespace Vitality.Website.UnitTests.Presales.Handlers.Literature
{
    using Shouldly;

    using Vitality.Website.Areas.Presales.Handlers.Literature;
    using Vitality.Website.UnitTests.TestDoubles;

    using Xunit;

    public class LiteratureDocumentHandler_Handle_Tests
    {
        private readonly LiteratureDocumentHandler handler;

        public LiteratureDocumentHandler_Handle_Tests()
        {
            this.handler = new LiteratureDocumentHandler(index => new SearchContextStub());
        }

        [Fact]
        public void Should_return_a_document_when_it_matches_library_category_and_title()
        {
            this.handler.Handle(new LiteratureDocumentRequest("sales-literature", SearchContextStub.MatchingCategory, SearchContextStub.MatchingTitle, false)).ShouldNotBeNull();
        }

        [Fact]
        public void Should_include_documents_summaries_with_the_same_category_when_include_available_literature_true()
        {
            this.handler.Handle(new LiteratureDocumentRequest("sales-literature", SearchContextStub.MatchingCategory, SearchContextStub.MatchingTitle, true)).AvailableLiterature.ShouldNotBeEmpty();
        }
    }
}
