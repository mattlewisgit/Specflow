using System.Configuration;
using System.Net;
using System.Text;
using RestSharp;

namespace Vitality.Website.App.CallPro
{
    public static class CallProConnector
    {
        public static HttpStatusCode Send(string xml)
        {
            var baseUrl = new StringBuilder();
            baseUrl.Append(ConfigurationManager.AppSettings["CALL_PRO_API_URL"]);
            baseUrl.Append("?mode=import&hash=");
            baseUrl.Append(ConfigurationManager.AppSettings["CALL_PRO_HASH_CODE"]);

            RestClient client = new RestClient(baseUrl.ToString());

            var request = new RestRequest(Method.POST);
            request.AddParameter(
                "application/x-www-form-urlencoded",
                string.Format("xml={0}", xml),
                ParameterType.RequestBody);

            var response = client.Post(request);

            return response.StatusCode;
        }
    }
}
