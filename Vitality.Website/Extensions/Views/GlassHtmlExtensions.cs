using System;
using System.Linq.Expressions;
using System.Web;
using Glass.Mapper.Sc;
using Vitality.Website.Constants;

namespace Vitality.Website.Extensions.Views
{
    public static class GlassHtmlExtensions
    {
        /// <summary>
        /// On IoC level,  GlassHtml Image tag format is set to lazy load 
        /// as most of our images should be lazy loaded. 
        /// This extension is to render any images should not be lazy loaded. 
        /// </summary>
        public static HtmlString RenderNotLazyImage<T>(this Glass.Mapper.Sc.Web.Mvc.GlassView<T> glassView,
            Expression<Func<T, object>> field,
            object parameters = null,
            bool isEditable = false,
            bool outputHeightWidth = false) where T : class
        {
            // Change the Image tag format to original
            GlassHtml.ImageTagFormat = GlassMapperConstants.ImageTagFormat;
            var renderImageTag = glassView.GlassHtml.RenderImage(glassView.Model, field, parameters, isEditable,
                outputHeightWidth);
            // Revert the Image tag format to lazy load
            GlassHtml.ImageTagFormat = GlassMapperConstants.LazyImageTagFormat;
            return
                new HtmlString(renderImageTag);
        }
    }
}