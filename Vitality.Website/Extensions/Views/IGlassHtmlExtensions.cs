using System;
using System.Linq.Expressions;
using System.Web;
using Glass.Mapper.Sc;
using Sitecore.Forms.Mvc.Extensions;

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
            var renderImageTag = source.RenderImage(model, field, parameters, true);

            var img = field.Compile()(model) as Glass.Mapper.Sc.Fields.Image;
            var imageSrc = img != null ? img.Src : null;

            var lazyLoadedImage = renderImageTag.Replace("src=", "data-src=");

            if (!string.IsNullOrWhiteSpace(imageSrc))
            {
                lazyLoadedImage = lazyLoadedImage.Replace("/>", string.Format(@" src=""{0}?w=20""/>", imageSrc));
            }
            var src = field.GetPropertyValue<string>("Src");
            lazyLoadedImage = lazyLoadedImage.Contains(@"class=""")
                ? lazyLoadedImage.Replace(@"class=""", @"class=""lazyload ")
                : lazyLoadedImage.Replace("/>", @" class=""lazyload"" />");

            return new HtmlString(lazyLoadedImage);
        }
    }
}
