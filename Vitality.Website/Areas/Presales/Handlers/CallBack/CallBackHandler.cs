using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using MediatR;
using Vitality.Website.Areas.Presales.Handlers.Bsl;
using Vitality.Website.Areas.Presales.Services;

namespace Vitality.Website.Areas.Presales.Handlers.CallBack
{
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