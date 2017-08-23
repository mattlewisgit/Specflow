//using MediatR;
//using System.Threading.Tasks;
//using Vitality.Website.Areas.Presales.Services;

//namespace Vitality.Website.Areas.Presales.Handlers.Bsl
//{
//    public class BslPostHandler : IAsyncRequestHandler<BslPostRequest, BslDto>
//    {
//        private readonly IPresalesBslService _presalesBslService;

//        public BslPostHandler(IPresalesBslService presalesBslService)
//        {
//            _presalesBslService = presalesBslService;
//        }

//        public async Task<BslDto> Handle(BslPostRequest request) =>
//            await BslDto.From(_presalesBslService.Post<string>(request.BslEndpoint, request.PostData));
//    }
//}
