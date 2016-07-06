namespace Vitality.Website.UnitTests.Presales.Handlers
{
    using System;

    using Shouldly;

    using Vitality.Website.Areas.Presales.Handlers;
    using Vitality.Website.UnitTests.TestDoubles;

    using Xunit;

    public class LiteratureDocumentHandler_Handle_Tests
    {
        private readonly LiteratureDocumentHandler handler;

        public LiteratureDocumentHandler_Handle_Tests()
        {
            this.handler = new LiteratureDocumentHandler(new SearchContextStub());
        }

        [Fact]
        public void Should_return_null_when_no_documents_match_library_category_and_document()
        {
            this.handler.Handle(new LiteratureDocumentRequest("sales-literature", SearchContextStub.MatchingCategory, SearchContextStub.NonMatchingTitle, false)).ShouldBeNull();
        }

        [Fact]
        public void Should_return_document_with_matching_library_category_and_document()
        {
            this.handler.Handle(new LiteratureDocumentRequest("sales-literature", SearchContextStub.MatchingCategory, SearchContextStub.MatchingTitle, false)).ShouldNotBeNull();
        }

        [Fact]
        public void Should_return_null_when_matching_document_does_not_have_literature_document_template()
        {
            this.handler.Handle(new LiteratureDocumentRequest("sales-literature", SearchContextStub.MatchingCategory, SearchContextStub.NonMatchingTitle, false)).ShouldBeNull();
        }

        [Fact]
        public void Should_include_documents_with_same_category_as_document_when_include_available_literature_true()
        {
            this.handler.Handle(new LiteratureDocumentRequest("sales-literature", SearchContextStub.MatchingCategory, SearchContextStub.MatchingTitle, true)).AvailableLiterature.ShouldNotBeEmpty();
        }
    }
}
