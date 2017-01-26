using System.Collections.Generic;
using System.Linq;
using Glass.Mapper.Sc.Web.Mvc;
using Vitality.Website.Areas.Presales.ComponentTemplates.Articles;
using Vitality.Website.Areas.Presales.RenderingTemplates;

namespace Vitality.Website.Extensions.Views
{
    public static class ArticleIndexExtensions
    {
        public static int NumberOfColumns(this GlassView<ArticleIndex> view, IEnumerable<ArticleItem> articleItems )
        {
            return 12 / articleItems.Count();
        }

        public static string BackgroundImage(this GlassView<ArticleIndex> view, ArticleItem articleItem)
        {
            if (articleItem != null && articleItem.Image != null && !string.IsNullOrWhiteSpace(articleItem.Image.Src))
            {
                return articleItem.Image.ProtectedSrc(width: 388);
            }
            return "";
        }

        public static string ImageRelativePosition(this GlassView<ArticleIndex> view, ArticleItem articleItem)
        {
            if (Parameters(view).ImageRelativePosition != null)
            {
                return Parameters(view).ImageRelativePosition.Value;
            }
            return string.Empty;
        }

        public static string ColumnSplitOne(this GlassView<ArticleIndex> view, IEnumerable<ArticleItem> articleItems)
        {
            if (articleItems.Count() > 1)
            {
                return "grid-col-5-12";
            }
            return "grid-col-4-12";
        }

        public static string ColumnSplitTwo(this GlassView<ArticleIndex> view, IEnumerable<ArticleItem> articleItems)
        {
            if (articleItems.Count() > 1)
            {
                return "grid-col-7-12";
            }
            return "grid-col-8-12";
        }

        private static ArticleIndexRendering Parameters(this GlassView<ArticleIndex> view)
        {
            return view.GetRenderingParameters<ArticleIndexRendering>();
        }

        public static IEnumerable<IEnumerable<T>> SplitBy<T>(this IEnumerable<T> source, int splitSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / splitSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}