using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

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

            var xmlSerialize = new XmlSerializer(typeof(T));
            var xmlResult = (T)xmlSerialize.Deserialize(new StringReader(xmlOutput));

            if (xmlResult != null)
            {
                return xmlResult;
            }
            return default(T);
        }
    }
}
