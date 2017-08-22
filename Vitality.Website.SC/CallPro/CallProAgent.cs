using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data;
using Sitecore.Diagnostics;
using Vitality.Core;
using Vitality.Website.SC.Utilities;
using Vitality.Website.SC.WFFM;

namespace Vitality.Website.SC.CallPro
{
    public static class CallProAgent
    {
        public static async Task<HttpResponseMessage> Execute(Dictionary<string, string> dictionary)
        {
            Log.Info("FormFields:" + dictionary.Count, "CallProAgent");
            Assert.ArgumentNotNull(dictionary, "dictionary Fields");

            var callBackSchemaId = ConfigurationManager.AppSettings["CALL_PRO_INDIVIDUAL_CALLBACK"];
            var item = Sitecore.Context.Database.GetItem(new ID(callBackSchemaId));
            
            Assert.ArgumentNotNull(item, "item");
            Assert.ArgumentNotNull(item.Fields["Xml"], "Call Pro Schema Xml");

            var xmlTemplate = item.Fields["Xml"].Value;

            Assert.ArgumentNotNull(item, "Call Pro Schema");
            Assert.AreEqual(item.TemplateID.ToString(), WffmConstants.XmlSchemaTemplateId, string.Empty);

            string requestXml;

            try
            {
                // Transform XML.
                requestXml = xmlTemplate.Replace(dictionary);

                PresalesLog.Log.Info(requestXml);
            }
            catch (Exception ex)
            {
                Log.Error($"Error Transforming Call Pro XML Data: Error:{ex.Message}. InnerException: {ex.InnerException?.Message ?? string.Empty}", "CallProAgent");
                throw;
            }
            return await CallProConnector.Send(requestXml);
        }
    }
}
