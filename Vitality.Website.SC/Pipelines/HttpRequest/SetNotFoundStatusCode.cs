namespace Vitality.Website.SC.Pipelines.HttpRequest
{
    using System;

    using Sitecore.Pipelines.HttpRequest;

    public class SetNotFoundStatusCode : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            throw new NotImplementedException();
        }
    }
}