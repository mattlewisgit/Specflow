namespace Vitality.Website.SC.Pipelines.RichTextEditor.SaveRichTextContent
{
    using System.IO;
    using System.Linq;

    using Sitecore.Shell.Controls.RichTextEditor.Pipelines.SaveRichTextContent;
    using Sitecore.WordOCX.HtmlDocument;

    public class InjectTableSawStyles
    {
        public const string Class = "class";
        public const string DataTablesawMode = "data-tablesaw-mode";

        public void Process(SaveRichTextContentArgs args)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(args.Content);

            var tables = htmlDoc.DocumentNode.SelectNodes("//table");

            if (tables != null)
            {
                foreach (var attributes in tables.Select(table => table.Attributes))
                {
                    if (attributes[Class] == null)
                    {
                        attributes.Add(Class, string.Empty);
                    }

                    if (attributes[DataTablesawMode] == null)
                    {
                        attributes.Add(DataTablesawMode, string.Empty);
                    }

                    attributes[Class].Value = "data-table tablesaw tablesaw-stack";
                    attributes[DataTablesawMode].Value = "stack";
                }

                using (var textWriter = new StringWriter())
                {
                    htmlDoc.Save(textWriter);
                    args.Content = textWriter.ToString();
                }
            }
        }
    }
}
