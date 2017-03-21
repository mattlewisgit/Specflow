using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using RestSharp;

namespace Vitality.Website.App.Helpers
{
    public class MockDataHelper : IMockDataHelper
    {
        /// <summary>
        /// Read data from json mock data file then returns a deserialized object of data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public T GetJsonMockData<T>(string filePath)
        {
            string jsonOutput;
            using (var sr = new StreamReader(filePath))
            {
                jsonOutput = sr.ReadToEnd();
            }

            var jsResult = JsonConvert.DeserializeObject<T>(jsonOutput);

            if (jsResult != null)
            {
                return jsResult;
            }
            return default(T);
        }

        /// <summary>
        /// Read data from xml mock data file then returns a deserialized object of data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public T GetXmlMockData<T>(string filePath)
        {
            string xmlOutput;
            using (var sr = new StreamReader(filePath))
            {
                xmlOutput = sr.ReadToEnd();
            }

            // Deserialize
            var restResponse = new RestResponse<T>
            {
                Content = xmlOutput
            };

            var deserializer = new RestSharp.Deserializers.XmlDeserializer();

            return deserializer.Deserialize<T>(restResponse);
        }
    }
}
