using Shouldly;
using Vitality.Website.SC.Providers;
using Vitality.Website.SC.Utilities;
using Xunit;

namespace Vitality.Website.SC.UnitTests.Providers
{
    public class AppendLinkProviderTests
    {
        public class AppendLinkBuilderTests
        {
            public class HandleSlashTests
            {
                [Fact]
                public void Slash_should_not_be_added_to_url__already_ends_with_slash()
                {
                    var input = "http://dev.vitality.co.uk/business/";
                    var expected = "http://dev.vitality.co.uk/business/";

                    AppendLinkProvider.AppendLinkBuilder.HandleSlash(input).ShouldBe(expected);
                }

                [Fact]
                public void Slash_should_not_be_added_to_any_urls_with_extensions()
                {
                    var input = "http://dev.vitality.co.uk/image1.png";
                    var expected = "http://dev.vitality.co.uk/image1.png";

                    AppendLinkProvider.AppendLinkBuilder.HandleSlash(input).ShouldBe(expected);
                }

                [Fact]
                public void Slash_should_be_added_to_the_end_of_url()
                {
                    var input = "http://dev.vitality.co.uk/business";
                    var expected = "http://dev.vitality.co.uk/business/";

                    AppendLinkProvider.AppendLinkBuilder.HandleSlash(input).ShouldBe(expected);
                }

                [Fact]
                public void Slash_should_be_added_before_query_string_when_query_string_presents()
                {
                    var input = "http://dev.vitality.co.uk/business?type=insurance";
                    var expected = "http://dev.vitality.co.uk/business/?type=insurance";

                    AppendLinkProvider.AppendLinkBuilder.HandleSlash(input).ShouldBe(expected);
                }

                [Fact]
                public void Slash_should_be_added_before_hash_when_fragment_presents()
                {
                    var input = "http://dev.vitality.co.uk/business#insurance";
                    var expected = "http://dev.vitality.co.uk/business/#insurance";

                    AppendLinkProvider.AppendLinkBuilder.HandleSlash(input).ShouldBe(expected);
                }

                [Fact]
                public void Slash_should_be_added_before_query_string_when_query_string_and_hash_presents()
                {
                    var input = "http://dev.vitality.co.uk/business?type=insurance#health";
                    var expected = "http://dev.vitality.co.uk/business/?type=insurance#health";

                    AppendLinkProvider.AppendLinkBuilder.HandleSlash(input).ShouldBe(expected);
                }
            }
        }
    }
}
