namespace Vitality.Website.UnitTests.Presales.Controllers.LiteratureLibraryControllerTests
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;

    using Shouldly;

    using Areas.Presales.Controllers;
    using Areas.Presales.Handlers.Literature;
    using TestDoubles;

    using Xunit;

    public class List_Tests
    {
        private readonly LiteratureLibraryController controller;

        public List_Tests()
        {
            var handler = new MediatorStub<LiteratureDocumentSummariesRequest, IEnumerable<LiteratureDocumentSummaryDto>>(new LiteratureDocumentSummariesHandler(index => new SearchContextStub()));
            controller = new LiteratureLibraryController(handler);
        }

        [Fact]
        public void Should_respond_400_bad_request_when_library_is_not_a_valid_argument()
        {
            controller.List(null, "personal-healthcare").StatusCode.ShouldBe(HttpStatusCode.BadRequest);
            controller.List(string.Empty, "personal-healthcare").StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Fact]
        public void Should_respond_400_bad_request_when_category_is_not_a_valid_argument()
        {
            controller.List("personal-healthcare", null).StatusCode.ShouldBe(HttpStatusCode.BadRequest);
            controller.List("personal-healthcare", string.Empty).StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Fact(Skip = "This is currently written as a intergration test.")]
        public void Should_respond_404_not_found_when_no_documents_match_library_category()
        {
            controller.List("sales-literature", "adviser-healthcare").StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }

        [Fact(Skip = "This is currently written as a intergration test.")]
        public void Should_respond_200_ok_when_documents_match_library_and_category()
        {
            controller.List(SearchContextStub.MatchingLibrary, SearchContextStub.MatchingCategory).StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Fact(Skip = "This is currently written as a intergration test.")]
        public void Should_contain_a_collection_of_matching_documents_in_the_response_body()
        {
            controller.List(SearchContextStub.MatchingLibrary, SearchContextStub.MatchingCategory).Content.ReadAsAsync<IEnumerable<LiteratureDocumentSummaryDto>>().Result.ShouldNotBeEmpty();
        }
    }
}
