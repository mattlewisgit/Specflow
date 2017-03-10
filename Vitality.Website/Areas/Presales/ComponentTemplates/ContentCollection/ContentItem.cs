namespace Vitality.Website.Areas.Presales.ComponentTemplates.ContentCollection
{
    public class ContentItem <T>
    {
        public T Item { get; set; }
        public string PartialView { get; set; }
        public int SortOrder { get; set; }
    }
}
