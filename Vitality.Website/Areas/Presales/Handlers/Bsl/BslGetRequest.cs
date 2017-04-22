using MediatR;

namespace Vitality.Website.Areas.Presales.Handlers.Bsl
{
    public class BslGetRequest : IAsyncRequest<BslDto>
    {
        public readonly string Endpoint;
        public BslGetRequest(string endpoint)
        {
            Endpoint = endpoint;
        }
    }
}
