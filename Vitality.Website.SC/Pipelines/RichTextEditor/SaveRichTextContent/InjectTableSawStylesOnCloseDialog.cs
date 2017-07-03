using Vitality.Website.SC.Pipelines.RenderField;

namespace Vitality.Website.SC.Pipelines.RichTextEditor.SaveRichTextContent
{
    using Sitecore.Shell.Controls.RichTextEditor.Pipelines.SaveRichTextContent;

    public class InjectTableSawStylesOnCloseDialog
    {
        public const string Class = "class";
        public const string DataTablesawMode = "data-tablesaw-mode";

        public void Process(SaveRichTextContentArgs args)
        {            
            args.Content = TableSawHelper.AddTableAttributes(TableSawArgs.Stack(args.Content));
        }
    }
}
