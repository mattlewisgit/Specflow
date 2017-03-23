namespace Vitality.Website.SC.Pipelines.HttpRequest
{
    using System.Net;
    using System.Web;

    using Sitecore.Pipelines.HttpRequest;

    public class SetNotFoundStatusCode : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            if (HttpContext.Current.Items[NotFoundItemResolver.ItemNotFound] != null && (bool)HttpContext.Current.Items[NotFoundItemResolver.ItemNotFound])
            {
                HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.NotFound;
                HttpContext.Current.Response.TrySkipIisCustomErrors = true;
            }
        }
    }
}
