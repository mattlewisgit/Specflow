using System;

namespace Vitality.Website.SC.Pipelines.HttpRequest
{
    using Sitecore.Pipelines.HttpRequest;

    public class ItemNotFound : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
