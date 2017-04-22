using System.Threading.Tasks;

namespace Vitality.Website.Areas.Presales.Services
{
    public interface IPresalesBslService
    {
        Task<T> Get<T>(string endpointWithQuery);
        Task<T> Post<T>(string endpoint, object postData);
    }
}
