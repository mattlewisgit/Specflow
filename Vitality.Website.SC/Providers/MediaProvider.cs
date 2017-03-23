namespace Vitality.Website.SC.Providers
{
    using System;

    using Sitecore;
    using Sitecore.Data.Items;
    using Sitecore.Resources.Media;
    using Sitecore.Web;

    public class MediaProvider : Sitecore.Resources.Media.MediaProvider
    {
        public override string GetMediaUrl(MediaItem item, MediaUrlOptions options)
        {
            if (options.AlwaysIncludeServerUrl && string.IsNullOrWhiteSpace(options.MediaLinkServerUrl))
            {
                options.MediaLinkServerUrl = new UriBuilder(WebUtil.GetServerUrl(false)) { Scheme = Context.Site.SiteInfo.Scheme, Port = -1 }.ToString();
            }
            return base.GetMediaUrl(item, options);
        }
    }
}
