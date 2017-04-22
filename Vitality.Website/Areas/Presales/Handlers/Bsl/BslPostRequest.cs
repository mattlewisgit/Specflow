using MediatR;

namespace Vitality.Website.Areas.Presales.Handlers.Bsl
{
    public class BslPostRequest : IAsyncRequest<BslDto>
    {
        public readonly string Endpoint;
        public readonly object PostData;
        public BslPostRequest(string endpoint, object postData)
        {
            PostData = postData;
            Endpoint = endpoint;
        }
    }
}
