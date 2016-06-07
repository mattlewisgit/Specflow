using System;
using Shouldly;
using Sitecore.Shell.Controls.RichTextEditor.Pipelines.SaveRichTextContent;
using Vitality.Website.SC.Pipelines.RichTextEditor.SaveRichTextContent;
using Xunit;

namespace Vitality.Website.SC.UnitTests.Pipelines.RichTextEditor.SaveRichTextContent
{
    public class InjectTableSawStylesTests
    {
        private readonly InjectTableSawStyles injectTableStyles;
        private readonly SaveRichTextContentArgs args;

        public InjectTableSawStylesTests()
        {
            var content = "<p>some test content <table><tr></tr></table><br><table><tr></tr></table></p>";
            this.args = new SaveRichTextContentArgs(content);
            this.injectTableStyles = new InjectTableSawStyles();
        }

        [Fact]
        public void Content_Should_Not_Be_Modified_If_Content_Does_Not_Contain_Tables()
        {
            var content = "<p>some table test content</p>";
            args.Content = content;
            
            injectTableStyles.Process(args);

            args.Content.ShouldBe(content);
        }

        [Fact]
        public void Should_inject_table_saw_class_when_table_element_present()
        {
            var expected = "class=\"data-table tablesaw tablesaw-stack\"";
            
            injectTableStyles.Process(args);

            args.Content.ShouldContain(expected);
        }

        [Fact]
        public void Should_inject_table_saw_data_attribute_when_table_element_present()
        {
            var expected = "data-tablesaw-mode=\"stack\"";

            injectTableStyles.Process(args);

            args.Content.ShouldContain(expected);
        }

        [Fact]
        public void Should_not_modify_content_if_table_already_contains_tablesaw_class()
        {
            var expected = "<p>some test content <table class=\"data-table tablesaw tablesaw-stack\" data-tablesaw-mode=\"stack\"><tr></tr></table></p>";
            args.Content = expected;
            var index = expected.LastIndexOf("class=\"data-table tablesaw tablesaw-stack\"", StringComparison.OrdinalIgnoreCase);
            
            injectTableStyles.Process(args);

            args.Content.LastIndexOf("class=\"data-table tablesaw tablesaw-stack\"", StringComparison.OrdinalIgnoreCase).ShouldBe(index);
        }

        [Fact]
        public void Should_not_modify_content_if_table_already_contains_tablesaw_data_attribute()
        {
            var expected = "<p>some test content <table class=\"data-table tablesaw tablesaw-stack\" data-tablesaw-mode=\"stack\"><tr></tr></table></p>";
            args.Content = expected;
            var index = expected.LastIndexOf("data-tablesaw-mode=\"stack\"", StringComparison.OrdinalIgnoreCase);

            injectTableStyles.Process(args);

            args.Content.LastIndexOf("data-tablesaw-mode=\"stack\"", StringComparison.OrdinalIgnoreCase).ShouldBe(index);
        }

        [Fact]
        public void Should_inject_table_saw_class_and_data_attribute_for_all_tables()
        {
            var expected = "<p>some test content <table class=\"data-table tablesaw tablesaw-stack\" data-tablesaw-mode=\"stack\"><tr></tr></table>" +
                           "<br><table class=\"data-table tablesaw tablesaw-stack\" data-tablesaw-mode=\"stack\"><tr></tr></table></p>";

            injectTableStyles.Process(args);

            args.Content.ShouldBe(expected);
        }
    }
}
