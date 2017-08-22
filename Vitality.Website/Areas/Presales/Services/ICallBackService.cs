namespace Vitality.Website.Areas.Presales.Services
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Handlers.CallBack;

    public interface ICallBackService
    {
        Task<HttpResponseMessage> Post(CallBackPostRequest postData);
    }
}