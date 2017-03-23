using System.IO;
using RestSharp;
using RestSharp.Deserializers;

namespace Vitality.Website.App.Helpers
{
    public class MockDataHelper : IMockDataHelper
    {
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
    }
}
