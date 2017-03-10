namespace Vitality.Website.SC.Pipelines.RenderField
{
    public class TableSawArgs
    {
        public string Html { get; private set; }
        public string TableClass { get; private set; }
        public string TableMode { get; private set; }

        private TableSawArgs(string html, string tableClass, string tableMode)
        {
            Html = html;
            TableClass = tableClass;
            TableMode = tableMode;
        }

        public static TableSawArgs Stack(string html)
        {
            return new TableSawArgs(html, "data-table tablesaw tablesaw-stack", "stack");
        }

        public static TableSawArgs Swipe(string html)
        {
            return new TableSawArgs(html, "data-table tablesaw tablesaw-swipe", "swipe");
        }
    }
}
