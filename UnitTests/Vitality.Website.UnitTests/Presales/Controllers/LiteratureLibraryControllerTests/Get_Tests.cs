namespace Vitality.Website.UnitTests.Presales.Controllers.LiteratureLibraryControllerTests
{
    using System;
    using System.Net;
    using System.Net.Http;

    using Shouldly;

    using Vitality.Website.Areas.Presales.Controllers;
    using Vitality.Website.Areas.Presales.Handlers;
    using Vitality.Website.Areas.Presales.Handlers.Literature;
    using Vitality.Website.UnitTests.TestDoubles;

    using Xunit;

    public class Get_Tests
    {
        private readonly LiteratureLibraryController controller;

        public Get_Tests()
        {
            var handler = new MediatorStub<LiteratureDocumentRequest, LiteratureDocumentDto>(new LiteratureDocumentHandler(new SearchContextStub()));
            this.controller = new LiteratureLibraryController(handler);
        }

        [Fact]
        public void Should_respond_400_bad_request_when_library_is_not_a_valid_argument()
        {
            this.controller.Get(null, "personal-healthcare", "core-cover").StatusCode.ShouldBe(HttpStatusCode.BadRequest);
            this.controller.Get(string.Empty, "personal-healthcare", "core-cover").StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Fact]
        public void Should_respond_400_bad_request_when_category_is_not_a_valid_argument()
        {
            this.controller.Get("sales-literature", null, "core-cover").StatusCode.ShouldBe(HttpStatusCode.BadRequest);
            this.controller.Get("sales-literature", string.Empty, "core-cover").StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Fact]
        public void Should_respond_400_bad_request_when_document_is_not_a_valid_argument()
        {
            this.controller.Get("sales-literature", "personal-healthcare", null).StatusCode.ShouldBe(HttpStatusCode.BadRequest);
            this.controller.Get("sales-literature", "personal-healthcare", string.Empty).StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Fact]
        public void Should_respond_404_not_found_when_no_document_matches_library_category_and_title()
        {
            this.controller.Get("sales-literature", "personal-healthcare", "life-cover").StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }

        [Fact]
        public void Should_respond_200_ok_when_document_matches_library_category_and_title()
        {
            this.controller.Get("sales-literature", SearchContextStub.MatchingCategory, SearchContextStub.MatchingTitle).StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Fact]
        public void Should_contain_document_in_response_body_when_document_matches_library_category_and_title()
        {
            this.controller.Get("sales-literature", SearchContextStub.MatchingCategory, SearchContextStub.MatchingTitle).Content.ReadAsAsync<LiteratureDocumentDto>().Result.ShouldNotBeNull();
        }
    }
}
