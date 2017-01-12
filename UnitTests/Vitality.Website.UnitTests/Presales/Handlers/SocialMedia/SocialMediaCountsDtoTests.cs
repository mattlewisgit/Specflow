using Shouldly;
using Vitality.Website.Areas.Presales.Handlers.SocialMedia;
using Xunit;

namespace Vitality.Website.UnitTests.Presales.Handlers.SocialMedia
{
    public class SocialMediaCountsDtoTests
    {
        public class From
        {
            [Fact]
            public void should_assign_counts_property()
            {
                SocialMediaCountsDto.From(34).Count.ShouldBe(34);
            } 
        }
    }
}
