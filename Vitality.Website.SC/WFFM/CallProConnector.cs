using System;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Vitality.Website.SC.WFFM
{
    public static class CallProConnector
    {
        public static async Task<HttpStatusCode> Send(string xml)
        {
            // Once this app is moved to an API, use a strongly-typed config interface
            // with section, a URI builder and Dependency Injection.
            var baseUrl = new StringBuilder()
                .Append(ConfigurationManager.AppSettings["CALL_PRO_API_URL"])
                .Append("?mode=import&hash=")
                .Append(ConfigurationManager.AppSettings["CALL_PRO_HASH_CODE"]);

            try
            {
                var request = new RestRequest(Method.POST).AddParameter(
                "application/x-www-form-urlencoded",
                $"xml={xml}",
                ParameterType.RequestBody);

                return new RestClient(baseUrl.ToString()).Post(request).StatusCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
