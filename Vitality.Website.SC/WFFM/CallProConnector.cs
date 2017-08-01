using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Net.Http;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Vitality.Core;
using Vitality.Mvc.Models;
using Vitality.Mvc.Utilities;

namespace Vitality.Website.SC.WFFM
{
    public static class CallProConnector
    {
        public static async Task<HttpResponseMessage> Send(string xml)
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
                var client = new RestClient(baseUrl.ToString());

                var response = await client.ExecutePostTaskAsync(request);// ExecuteTaskAsync(request);

                return new HttpResponseMessage(response.StatusCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<HttpResponseMessage> CreateCallProData(Dictionary<string,string> dictionary )
        {
            var item = Sitecore.Context.Database.GetItem(new ID("6CC3BF23-E604-4CC6-8FFC-62DE90C86075"));

            var xmlTemplate = item.Fields["Xml"].Value;

            string requestXml;

            try
            {
                // Transform XML.
                requestXml = xmlTemplate.Replace(dictionary);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Send(requestXml);
        }
    }
}
