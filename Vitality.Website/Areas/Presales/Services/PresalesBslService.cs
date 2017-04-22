using System.Configuration;
using System.Net;
using System.Threading.Tasks;
using RestSharp;

namespace Vitality.Website.Areas.Presales.Services
{
    public class PresalesBslService : IPresalesBslService
    {
        private readonly RestClient _restClient;

        public PresalesBslService()
        {
            _restClient = new RestClient(ConfigurationManager.AppSettings[PresalesConstants.Bsl.PresalesBslUrl]);

        }

        public async Task<T> Get<T>(string endpointWithQuery)
        {
            var request = CreateRequest(endpointWithQuery, Method.GET);
            return Handle(await _restClient.ExecuteTaskAsync<T>(request));
        }

        public async Task<T> Post<T>(string endpoint, object postData)
        {
            var request = CreateRequest(endpoint, Method.POST);
            request.AddJsonBody(postData);
            return Handle(await _restClient.ExecuteTaskAsync<T>(request));
        }

        private RestRequest CreateRequest(string endpoint, Method method)
        {
            return new RestRequest(endpoint, method)
            {
                OnBeforeDeserialization = resp => { resp.ContentType = PresalesConstants.ContentTypes.ApplicationJson; }
            };
        }

        private T Handle<T>(IRestResponse<T> response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            }
            throw response.ErrorException;
        }
    }
}
