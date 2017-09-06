using MediatR;

namespace Vitality.Website.Areas.Presales.Handlers.Quote
{
    public class GetApplicationRequest : IRequest<object>
    {
        public readonly string ApplicationId;
        public GetApplicationRequest(string applicaitonId)
        {
            ApplicationId = applicaitonId;
        }
    }
}
