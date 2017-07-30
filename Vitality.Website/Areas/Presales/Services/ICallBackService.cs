using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Vitality.Website.Areas.Presales.Handlers.CallBack;

namespace Vitality.Website.Areas.Presales.Services
{
    public interface ICallBackService
    {
        Task<HttpResponseMessage> Post(CallBackPostRequest postData);
    }
}