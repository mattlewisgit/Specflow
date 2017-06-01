using MediatR;

namespace Vitality.Website.Areas.Presales.Handlers.Bsl
{
    public class BslPostRequest : IRequest<BslDto>
    {
        public readonly string BslEndpoint;
        public readonly object PostData;
        public BslPostRequest(string bslEndpoint, object postData)
        {
            PostData = postData;
            BslEndpoint = bslEndpoint;
        }
    }
}
