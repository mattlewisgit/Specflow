using System;
using System.Linq.Expressions;
using System.Web;
using Glass.Mapper.Sc;

namespace Vitality.Website.Extensions.Views
{
    // ReSharper disable once InconsistentNaming
    public static class IGlassHtmlExtensions
    {
        public static HtmlString RenderLazyImage<T>(
            this IGlassHtml source,
            T model,
            Expression<Func<T, object>> field,
            object parameters = null) where T : class
        {
            /*
             * generate image tag using specified max width
             * convert src to data-src
             * generate image tag using 20px max width
             * combine both image tags
             * apply lazyload class
             */

            var renderImageTag = source.RenderImage(model, field, parameters, true);

            if (Sitecore.Context.PageMode.IsExperienceEditor || Sitecore.Context.PageMode.IsPreview)
            {
                return new HtmlString(renderImageTag);
            }

            var lazyParameters = new {mw = 20, alt = string.Empty};
            var renderLazyImageTag = source.RenderImage(model, field, lazyParameters, true);

            var lazyLoadedImageFirstPart = renderImageTag.Replace("src=", "data-src=").Replace("/>", string.Empty);
            var lazyLoadedImageSecondPart = renderLazyImageTag.Replace("<img ", string.Empty)
                .Replace("alt=''", String.Empty);
            var lazyLoadedImage = $"{lazyLoadedImageFirstPart}{lazyLoadedImageSecondPart}";
            lazyLoadedImage = lazyLoadedImage.Contains("class='")
                ? lazyLoadedImage.Replace("class='", "class='lazyload ")
                : lazyLoadedImage.Replace("/>", " class='lazyload' />");

            return new HtmlString(lazyLoadedImage);
        }
    }
}
