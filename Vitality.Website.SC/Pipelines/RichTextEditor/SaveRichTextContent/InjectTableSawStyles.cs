namespace Vitality.Website.SC.Pipelines.RichTextEditor.SaveRichTextContent
{
    using System.IO;
    using System.Linq;

    using Sitecore.Shell.Controls.RichTextEditor.Pipelines.SaveRichTextContent;
    using Sitecore.WordOCX.HtmlDocument;

    public class InjectTableSawStyles
    {
        static class Attributes
        {
            public const string Class = "class";
            public const string DataTablesawMode = "data-tablesaw-mode";
        }

        public void Process(SaveRichTextContentArgs args)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(args.Content);

            var tables = htmlDoc.DocumentNode.SelectNodes("//table");

            if (tables == null)
            {
                return;
            }

            foreach (var attributes in tables.Select(table => table.Attributes))
            {
                if (attributes[Attributes.Class] == null)
                {
                    attributes.Add(Attributes.Class, string.Empty);
                }
                
                if (attributes[Attributes.DataTablesawMode] == null)
                {
                    attributes.Add(Attributes.DataTablesawMode, string.Empty);
                }

                attributes[Attributes.Class].Value = "data-table tablesaw tablesaw-stack";
                attributes[Attributes.DataTablesawMode].Value = "stack";
            }

            using (var textWriter = new StringWriter())
            {
                htmlDoc.Save(textWriter);
                args.Content = textWriter.ToString();
            }
        }
    }
}
