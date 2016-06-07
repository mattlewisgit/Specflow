using System;
using System.IO;
using System.Web.UI;
using Sitecore.Shell.Controls.RichTextEditor.Pipelines.SaveRichTextContent;
using Sitecore.WordOCX.HtmlDocument;

namespace Vitality.Website.SC.Pipelines.RichTextEditor.SaveRichTextContent
{
    public class InjectTableSawStyles
    {
        public void Process(SaveRichTextContentArgs args)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(args.Content);

            var tables = htmlDoc.DocumentNode.SelectNodes("//table");

            if (tables != null)
            {
                foreach (var table in tables)
                {
                    if (table.Attributes["class"] == null)
                    {
                        table.Attributes.Add("class", string.Empty);
                    }
                    if (table.Attributes["data-tablesaw-mode"] == null)
                    {
                        table.Attributes.Add("data-tablesaw-mode", string.Empty);
                    }

                    table.Attributes["class"].Value = "data-table tablesaw tablesaw-stack";
                    table.Attributes["data-tablesaw-mode"].Value = "stack";
                }
            }

            using (var textWriter = new StringWriter())
            {
                htmlDoc.Save(textWriter);
                args.Content = textWriter.ToString();
            }
        }
    }
}
    