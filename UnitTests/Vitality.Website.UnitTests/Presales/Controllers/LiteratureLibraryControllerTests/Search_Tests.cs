namespace Vitality.Website.UnitTests.Presales.Controllers.LiteratureLibraryControllerTests
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;

    using Shouldly;

    using Vitality.Website.Areas.Presales.Controllers;
    using Vitality.Website.Areas.Presales.Handlers.Literature;
    using Vitality.Website.UnitTests.TestDoubles;

    using Xunit;

    public class Search_Tests
    {
        private readonly LiteratureLibraryController controller;

        public Search_Tests()
        {
            var handler = new MediatorStub<LiteratureDocumentSummariesRequest, IEnumerable<LiteratureDocumentSummaryDto>>(new LiteratureDocumentSummariesHandler(index => new SearchContextStub()));
            this.controller = new LiteratureLibraryController(handler);
        }

        [Fact]
        public void Should_respond_400_bad_request_when_library_is_not_a_valid_argument()
        {
            this.controller.Search(null, "core-cover").StatusCode.ShouldBe(HttpStatusCode.BadRequest);
            this.controller.Search(string.Empty, "core-cover").StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Fact]
        public void Should_respond_400_bad_request_when_title_is_not_a_valid_argument()
        {
            this.controller.Search("sales-literature", null).StatusCode.ShouldBe(HttpStatusCode.BadRequest);
            this.controller.Search("sales-literature", string.Empty).StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Fact]
        public void Should_respond_404_not_found_when_no_documents_match_library_and_title()
        {
            this.controller.Search(SearchContextStub.MatchingLibrary, "Health-online").StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }

        [Fact]
        public void Should_respond_200_ok_when_documents_match_library_and_title()
        {
            this.controller.Search(SearchContextStub.MatchingLibrary, "cover").StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Fact]
        public void Should_contain_a_collection_of_matching_documents_in_the_response_body()
        {
            this.controller.Search(SearchContextStub.MatchingLibrary, "cover").Content.ReadAsAsync<IEnumerable<LiteratureDocumentSummaryDto>>().Result.ShouldNotBeEmpty();
        }
    }
}
