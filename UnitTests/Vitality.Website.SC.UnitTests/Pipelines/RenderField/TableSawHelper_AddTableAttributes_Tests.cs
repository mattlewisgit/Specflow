using System;
using Shouldly;
using Vitality.Website.SC.Pipelines.RenderField;
using Xunit;

namespace Vitality.Website.SC.UnitTests.Pipelines.RenderField
{
    public class TableSawHelper_AddTableAttributes_Tests
    {
        private TableSawArgs args;

        public TableSawHelper_AddTableAttributes_Tests()
        {
            const string content = @"
            <p>
                some test content
                <table>
                    <tr></tr>
                </table>
                <br>
                <table>
                    <tr></tr>
                </table>
            </p>";

            args = TableSawArgs.Stack(content);
        }

        [Fact]
        public void Content_Should_Not_Be_Modified_If_Content_Does_Not_Contain_Tables()
        {
            const string content = "<p>some table test content</p>";
            args = TableSawArgs.Stack(content);
            
            TableSawHelper.AddTableAttributes(args).ShouldBe(content);
        }

        [Fact]
        public void Should_inject_table_saw_class_when_table_element_present()
        {
            const string expected = "class=\"data-table tablesaw tablesaw-stack\"";
            
            TableSawHelper.AddTableAttributes(args).ShouldContain(expected);
        }

        [Fact]
        public void Should_inject_table_saw_data_attribute_when_table_element_present()
        {
            const string expected = "data-tablesaw-mode=\"stack\"";

            TableSawHelper.AddTableAttributes(args).ShouldContain(expected);
        }

        [Fact]
        public void Should_not_modify_content_if_table_already_contains_tablesaw_class()
        {
            const string expected = @"
            <p>
                some test content
                <table class=""data-table tablesaw tablesaw-stack"" data-tablesaw-mode=""stack"">
                    <tr></tr>
                </table>
            </p>";

            args = TableSawArgs.Stack(expected);
            var index = expected.LastIndexOf("class=\"data-table tablesaw tablesaw-stack\"", StringComparison.OrdinalIgnoreCase);

            TableSawHelper.AddTableAttributes(args).LastIndexOf("class=\"data-table tablesaw tablesaw-stack\"", StringComparison.OrdinalIgnoreCase).ShouldBe(index);
        }

        [Fact]
        public void Should_not_modify_content_if_table_already_contains_tablesaw_data_attribute()
        {
            const string expected = @"
            <p>
                some test content
                <table class=""data-table tablesaw tablesaw-stack"" data-tablesaw-mode=""stack"">
                    <tr></tr>
                </table>
            </p>";

            args = TableSawArgs.Stack(expected);
            var index = expected.LastIndexOf("data-tablesaw-mode=\"stack\"", StringComparison.OrdinalIgnoreCase);

            TableSawHelper.AddTableAttributes(args).LastIndexOf("data-tablesaw-mode=\"stack\"", StringComparison.OrdinalIgnoreCase).ShouldBe(index);
        }

        [Fact]
        public void Should_inject_table_saw_class_and_data_attribute_for_all_tables()
        {
            const string expected = @"
            <p>
                some test content
                <table class=""data-table tablesaw tablesaw-stack"" data-tablesaw-mode=""stack"">
                    <tr></tr>
                </table>
                <br>
                <table class=""data-table tablesaw tablesaw-stack"" data-tablesaw-mode=""stack"">
                    <tr></tr>
                </table>
            </p>";

            TableSawHelper.AddTableAttributes(args).ShouldBe(expected);
        }
    }
}
