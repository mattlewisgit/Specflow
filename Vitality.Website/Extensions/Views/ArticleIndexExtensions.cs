using System.Linq;
using Glass.Mapper.Sc.Web.Mvc;
using Vitality.Website.Areas.Presales.ComponentTemplates.Articles;
using Vitality.Website.Areas.Presales.RenderingTemplates;

namespace Vitality.Website.Extensions.Views
{
    public static class ArticleIndexExtensions
    {
        public static int NumberOfColumns(this GlassView<ArticleIndex> view)
        {
            return 12 / view.Model.ArticleItems.Count();
        }

        public static string BackgroundImage(this GlassView<ArticleIndex> view, ArticleItem articleItem)
        {
            if (articleItem != null && articleItem.Image != null && !string.IsNullOrWhiteSpace(articleItem.Image.Src))
            {
                return string.Format("background-image: url('{0}')", articleItem.Image.Src);
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

        public static string ColumnSplitOne(this GlassView<ArticleIndex> view)
        {
            if (view.Model.ArticleItems.Count() > 1)
            {
                return "grid-col-5-12";
            }
            return "grid-col-4-12";
        }

        public static string ColumnSplitTwo(this GlassView<ArticleIndex> view)
        {
            if (view.Model.ArticleItems.Count() > 1)
            {
                return "grid-col-7-12";
            }
            return "grid-col-8-12";
        }

        private static ArticleIndexRendering Parameters(this GlassView<ArticleIndex> view)
        {
            return view.GetRenderingParameters<ArticleIndexRendering>();
        }
    }
}