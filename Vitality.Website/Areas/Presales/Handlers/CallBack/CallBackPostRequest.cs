using MediatR;

namespace Vitality.Website.Areas.Presales.Handlers.CallBack
{
    public class CallBackPostRequest : IRequest<CallBackDto>
    {
        public readonly Models.CallBackData PostData;

        public CallBackPostRequest(Models.CallBackData postData)
        {
            PostData = postData;
        }
    }
}