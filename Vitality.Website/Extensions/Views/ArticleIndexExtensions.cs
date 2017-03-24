namespace Vitality.Website.Extensions.Views
{
    using Areas.Presales.ComponentTemplates.Articles;
    using Areas.Presales.RenderingTemplates;
    using Glass.Mapper.Sc.Web.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public static class ArticleIndexExtensions
    {
        public static int NumberOfColumns
            (this GlassView<ArticleIndex> view, IEnumerable<ArticleItem> articleItems) =>
                12 / articleItems.Count();

        public static string BackgroundImage(this GlassView<ArticleIndex> view, ArticleItem articleItem)
        {
            return articleItem != null
                && articleItem.Image != null
                && !string.IsNullOrWhiteSpace(articleItem.Image.Src)
                ? articleItem.Image.ProtectedSrc(width: 388)
                : string.Empty;
        }

        public static string ImageRelativePosition
            (this GlassView<ArticleIndex> view, ArticleItem articleItem) =>
                Parameters(view)?.ImageRelativePosition?.Value ?? string.Empty;

        public static string ColumnSplitOne
            (this GlassView<ArticleIndex> view, IEnumerable<ArticleItem> articleItems) =>
                articleItems.Count() > 1
                    ? "grid-col-5-12"
                    : "grid-col-4-12";

        public static string ColumnSplitTwo
            (this GlassView<ArticleIndex> view, IEnumerable<ArticleItem> articleItems) =>
                articleItems.Count() > 1
                    ? "grid-col-7-12"
                    : "grid-col-8-12";

        private static ArticleIndexRendering Parameters(this GlassView<ArticleIndex> view) =>
            view.GetRenderingParameters<ArticleIndexRendering>();

        public static IEnumerable<IEnumerable<T>> SplitBy<T>
            (this IEnumerable<T> source, int splitSize) =>
                source
                    .Select((x, i) => new { Index = i, Value = x })
                    .GroupBy(x => x.Index / splitSize)
                    .Select(x => x.Select(v => v.Value).ToList())
                    .ToList();
    }
}
