using System;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using Newtonsoft.Json;
using RestSharp;

namespace Vitality.Website.App.Helpers
{
    public static class ApiHelper
    {
        public static string StatusCodeKey = "StatusCode";
        public static string MoreInfoKey = "MoreInfo";

        /// <summary>
        /// Check the status code from the response if not OK throw an exception with error data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        public static T HandleResponse<T>(this IRestResponse<T> response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            }
            var exception = new Exception(response.ErrorMessage);
            exception.Data.Add(StatusCodeKey, response.StatusCode);
            exception.Data.Add(MoreInfoKey, response.Content);
            throw exception;
        }

        /// <summary>
        /// Read data from json mock data file then returns a deserialized object of data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T GetJsonMockData<T>(string filePath)
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
        public static T GetXmlMockData<T>(string filePath)
        {
            string xmlOutput;
            using (var sr = new StreamReader(filePath))
            {
                xmlOutput = sr.ReadToEnd();
            }

            var xmlSerialize = new XmlSerializer(typeof(T));
            var xmlResult = (T) xmlSerialize.Deserialize(new StringReader(xmlOutput));

            if (xmlResult != null)
            {
                return xmlResult;
            }
            return default(T);
        }
    }
}


//http://www.latestvacancies.com/vitality/rss/RSSFeed_External.asp
