using System.IO;
using System.Linq;
using Sitecore.Security.AccessControl;
using Sitecore.WordOCX.HtmlDocument;

namespace Vitality.Website.SC.Pipelines.RenderField
{
    public static class TableSawHelper
    {
        public const string Class = "class";
        public const string DataTablesawMode = "data-tablesaw-mode";
        public const string DataTablesawMinimap = "data-tablesaw-minimap";
        public const string DataTablesawPriority = "data-tablesaw-priority";

        public static string AddTableAttributes(TableSawArgs args)
        {
            bool isSwipe = args.TableMode.ToLowerInvariant() == "swipe";

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

                    if (attributes[DataTablesawMinimap] == null && isSwipe)
                    {
                        attributes.Add(DataTablesawMinimap, string.Empty);
                    }
                    
                    attributes[Class].Value = args.TableClass;
                    attributes[DataTablesawMode].Value = args.TableMode;
                }                
            }

            if (isSwipe)
            {
                var tableHeaders = htmlDoc.DocumentNode.SelectNodes("//table//thead//tr/*[1]");

                if (tableHeaders != null)
                {
                    foreach (var tableHeader in tableHeaders)
                    {
                        tableHeader.Attributes.Add(DataTablesawPriority, "persist");
                    }
                }
            }

            if (tables != null || isSwipe)
            {
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
