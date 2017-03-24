namespace Vitality.Website.Extensions.Views
{
    using Areas.Presales.ComponentTemplates.FeatureBlocks;
    using Areas.Presales.ComponentTemplates.Generic;
    using Glass.Mapper.Sc.Web.Mvc;
    using System.Linq;

    public static class AwardLeaderExtensions
    {
        private const int _maxNumberArticles = 12;

        public static int NumberOfColumns(this GlassView<AwardLeader> view) =>
            _maxNumberArticles / view.Model.ArticleItems.Count();

        public static int NumberOfAwardLogos(this GlassView<AwardLeader> view) =>
            _maxNumberArticles / view.Model.AwardLogos.Count();

        public static string BackgroundImage(this GlassView<AwardLeader> view) =>
            view.Model.BackgroundImage.ProtectedSrc(width: 1200);

        public static string BackgroundImage(this GlassView<AwardLeader> view, ArticleItem articleItem) =>
            articleItem != null
            && articleItem.Image != null
            && !string.IsNullOrWhiteSpace(articleItem.Image.Src)
            ? articleItem.Image.ProtectedSrc(width: 388)
            : string.Empty;

        public static string ColumnSplitOne(this GlassView<AwardLeader> view) =>
            view.Model.ArticleItems.Count() > 1
                ? "grid-col-5-12"
                : "grid-col-4-12";

        public static string ColumnSplitTwo(this GlassView<AwardLeader> view) =>
            view.Model.ArticleItems.Count() > 1
                ? "grid-col-7-12"
                : "grid-col-8-12";
    }
}
