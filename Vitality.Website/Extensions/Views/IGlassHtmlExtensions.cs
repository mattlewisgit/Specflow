using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Web;
using System.Web.Routing;
using Glass.Mapper.Sc;
using Sitecore.Collections;
using Sitecore.Text;

namespace Vitality.Website.Extensions.Views
{
    // ReSharper disable once InconsistentNaming
    public static class IGlassHtmlExtensions
    {
        public static HtmlString RenderLazyImage<T>(
            this IGlassHtml source,
            T model,
            Expression<Func<T, object>> field,
            string imageSrc,
            int maxWidth) where T : class
        {
            var renderImageTag = source.RenderImage(model, field, new { @class = "lazyload", mw = maxWidth }, true);

            var lazyLoadedImage = renderImageTag
                .Replace("src=", "data-src=")
                .Replace("/>", string.Format(@"src=""{0}?w=20""/>", imageSrc));

            return new HtmlString(lazyLoadedImage);
        }
    }
}
