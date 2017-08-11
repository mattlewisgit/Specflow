namespace Vitality.Website.Areas.Presales.Handlers.CallBack
{
    using System.Threading.Tasks;
    using MediatR;
    using Services;

    public class CallBackHandler : IAsyncRequestHandler<CallBackPostRequest, CallBackDto> 
    {
        private readonly ICallBackService _callBackService;

        public CallBackHandler(ICallBackService callBackService)
        {
            _callBackService = callBackService;
        }

        public async Task<CallBackDto> Handle(CallBackPostRequest request)
        {
            return await CallBackDto.From(_callBackService.Post(request));
        }
    }
}