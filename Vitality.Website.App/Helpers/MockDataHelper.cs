using System.IO;
using RestSharp;
using RestSharp.Deserializers;

namespace Vitality.Website.App.Helpers
{
    public class MockDataHelper : IMockDataHelper
    {
        /// <summary>
        /// Read data from Static file from the file system
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="deserializer"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public T GetMockData<T>(IDeserializer deserializer, string filePath)
        {
            string fileOutput;
            using (var sr = new StreamReader(filePath))
            {
                fileOutput = sr.ReadToEnd();
            }
            // Deserialize
            var restResponse = new RestResponse<T>
            {
                Content = fileOutput
            };
            return deserializer.Deserialize<T>(restResponse);
        }

        /// <summary>
        /// Read data from a url , IE sitecore file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileUrl"></param>
        /// <returns></returns>
        public T GetMockData<T>(string fileUrl) where T : new()
        {
            var restClient = new RestClient(fileUrl);
            return restClient.Execute<T>(new RestRequest(Method.GET)).Data;
        }
    }
}
