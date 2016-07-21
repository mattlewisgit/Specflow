using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Web.Mvc;
using Vitality.Website.Areas.Presales.ComponentTemplates.FeatureBlocks;
using Vitality.Website.Areas.Presales.ComponentTemplates.Generic;

namespace Vitality.Website.Extensions.Views
{
    public static class AwardLeaderExtensions
    {
        public static int NumberOfColumns(this GlassView<AwardLeader> view)
        {
            return 12 / view.Model.ArticleItems.Count();
        }

        public static int NumberOfAwardLogos(this GlassView<AwardLeader> view)
        {
            return 12 / view.Model.AwardLogos.Count();
        }

        public static string BackgroundImage(this GlassView<AwardLeader> view, ArticleItem articleItem)
        {
            if (articleItem != null && articleItem.Image != null && !string.IsNullOrWhiteSpace(articleItem.Image.Src))
            {
                return string.Format("background-image: url('{0}')", articleItem.Image.Src);
            }
            return "";
        }

        public static string ColumnSplitOne(this GlassView<AwardLeader> view)
        {
            if (view.Model.ArticleItems.Count() > 1)
            {
                return "grid-col-5-12";
            }
            return "grid-col-4-12";
        }

        public static string ColumnSplitTwo(this GlassView<AwardLeader> view)
        {
            if (view.Model.ArticleItems.Count() > 1)
            {
                return "grid-col-7-12";
            }
            return "grid-col-8-12";
        }
    }
}

