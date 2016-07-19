namespace Vitality.Website.SC.Pipelines.HttpRequest
{
    using System.IO;
    using System.Web;

    using Sitecore.Data.Items;
    using Sitecore.Pipelines.HttpRequest;

    /// <remarks>
    /// Based off solution provided here https://laubplusco.net/handling-404-sitecore-avoid-302-redirects/
    /// </remarks>
    public class NotFoundItemResolver : HttpRequestProcessor
    {
        public const string ItemNotFound = "ItemNotFound";

        private const string NotFoundKey = "notFoundItem";

        public override void Process(HttpRequestArgs args)
        {
            if (Sitecore.Context.Item != null || 
                Sitecore.Context.Site == null ||
                this.NotFoundItemIsNotConfigured() ||
                this.RequestIsASitecoreClientRequest(args) ||
                this.RequestIsAPhysicalFileRequest(args))
            {
                return;
            }

            Sitecore.Context.Item = this.GetSiteNotFoundItem();

            if (Sitecore.Context.Item != null)
            {
                HttpContext.Current.Items[ItemNotFound] = true;
            }
        }

        private Item GetSiteNotFoundItem()
        {
            var startItemPath = VirtualPathUtility.AppendTrailingSlash(Sitecore.Context.Site.StartPath);
            var notFoundItemPath = VirtualPathUtility.Combine(startItemPath, Sitecore.Context.Site.Properties[NotFoundKey]);
            return Sitecore.Context.Database.GetItem(notFoundItemPath);
        }

        private bool NotFoundItemIsNotConfigured()
        {
            return string.IsNullOrWhiteSpace(Sitecore.Context.Site.Properties[NotFoundKey]);
        }

        private bool RequestIsASitecoreClientRequest(HttpRequestArgs args)
        {
            return args.LocalPath.ToLowerInvariant().StartsWith("/sitecore");
        }

        private bool RequestIsAPhysicalFileRequest(HttpRequestArgs args)
        {
            return File.Exists(HttpContext.Current.Server.MapPath(args.Url.FilePath));
        }
    }
}
