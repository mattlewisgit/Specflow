namespace Vitality.Website.UnitTests.Extensions
{
    using System.Linq;

    using Shouldly;

    using Vitality.Website.Extensions;

    using Xunit;

    public class EnumerableExtensionsTests
    {
        public class GroupIntoRowsTests
        {
            [Fact]
            public void Enumerable_has_no_elements_should_return_empty()
            {
                Enumerable.Empty<int>().GroupIntoRows(5).ShouldBeEmpty();
            }

            [Fact]
            public void Enumerable_has_elements_should_return_all_elements()
            {
                Enumerable.Range(0, 10).GroupIntoRows(10).SelectMany(links => links).Count().ShouldBe(10);
            }

            [Fact]
            public void Elements_per_group_should_not_exceed_elements_per_row()
            {
                Enumerable.Range(0, 10).GroupIntoRows(9).First().Count().ShouldBe(9);
            }
        }
    }
}
