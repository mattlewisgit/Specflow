using MediatR;

namespace Vitality.Website.Areas.Presales.Handlers.Bsl
{
    public class BslGetRequest : IAsyncRequest<BslDto>
    {
        public readonly string BslEndpoint;
        public BslGetRequest(string bslEndpoint)
        {
            BslEndpoint = bslEndpoint;
        }
    }
}
