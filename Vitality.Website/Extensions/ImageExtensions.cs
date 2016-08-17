namespace Vitality.Website.Extensions
{
    using Glass.Mapper;
    using Glass.Mapper.Sc.Fields;

    public static class ImageExtensions
    {
        public static string ProtectedSrc(this Image image, int height = 0, int width = 0)
        {
            var src = new UrlBuilder(image.Src);
            if (height > 0)
            {
                src.AddToQueryString("mh", height.ToString());
            }
            if (width > 0)
            {
                src.AddToQueryString("mw", width.ToString());
            }
            return Sitecore.Resources.Media.HashingUtils.ProtectAssetUrl(src.ToString());
        }
    }
}
