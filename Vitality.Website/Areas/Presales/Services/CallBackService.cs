using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Vitality.Website.Areas.Presales.Handlers.CallBack;
using Vitality.Website.Areas.Presales.Models;
using Vitality.Website.SC.WFFM;

namespace Vitality.Website.Areas.Presales.Services
{
    public class CallBackService : ICallBackService
    {
        public static string Serialize<T>(T dataToSerialize)
        {
            try
            {
                var stringwriter = new System.IO.StringWriter();
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stringwriter, dataToSerialize);
                return stringwriter.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HttpResponseMessage> Post(CallBackPostRequest postData)
        {
            var postDataXml = Serialize(postData);
            return await CallProConnector.Send(postDataXml);
        }
    }
}