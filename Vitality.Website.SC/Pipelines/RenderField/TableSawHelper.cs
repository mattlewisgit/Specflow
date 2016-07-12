using System.IO;
using System.Linq;
using Sitecore.WordOCX.HtmlDocument;

namespace Vitality.Website.SC.Pipelines.RenderField
{
    public static class TableSawHelper
    {
        public const string Class = "class";
        public const string DataTablesawMode = "data-tablesaw-mode";

        public static string AddTableAttributes(TableSawArgs args)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(args.Html);

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

                    attributes[Class].Value = args.TableClass;
                    attributes[DataTablesawMode].Value = args.TableMode;
                }

                using (var textWriter = new StringWriter())
                {
                    htmlDoc.Save(textWriter);
                    return textWriter.ToString();
                }
            }

            return args.Html;
        }
    }
}
