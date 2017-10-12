using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using MediatR;
using Sitecore.Data;
using Sitecore.Diagnostics;
using Vitality.Core;
using Vitality.Mvc.Models;
using Vitality.Mvc.Utilities;
using Vitality.Website.Areas.Presales.Handlers.Bsl;
using Vitality.Website.Areas.Presales.Models;
using Vitality.Website.SC.Utilities;
using Vitality.Website.SC.WFFM;
using Newtonsoft.Json;

namespace Vitality.Website.Areas.Presales.Controllers
{
    public class CallBackController : BaseController
    {
        public CallBackController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("api/callpro")]
        public async Task<HttpResponseMessage> CallPro(string bslEndpoint, CallBackData model)
        {
            if (string.IsNullOrEmpty(bslEndpoint) || !ModelState.IsValid)
            {
                return HandleBadRequest();
            }

            var generatedCallProData = GenerateCallProData(model);

            var request = JsonConvert.SerializeObject(new { FeedSettings = new object(), Xml = TransformXML(generatedCallProData) });

            return await GetResponseAsync<BslPostRequest, BslDto>(new BslPostRequest(bslEndpoint, request), result => result != null);
        }

        private Dictionary<string, string> GenerateCallProData(CallBackData callBackPostRequest)
        {
            var today = DateTime.Today;

            var formFieldsDictionary = new Dictionary<string, string>
            {
                {"{TODAY}", today.ToShortDateString()},
                {"{DAY}", today.Day.ToString("D2")},
                {"{MONTH}", today.Month.ToString("D2")},
                {"{YEAR}", today.Year.ToString()},
                {"{NEXTMONTH}", today.AddMonths(1).ToShortDateString()},
                {"{NEXTYEAR}", today.AddYears(1).ToShortDateString()},
                {"{TELEPHONENUMBER}", callBackPostRequest.PhoneNumber},
                {"{TITLE}", callBackPostRequest.Title},
                {"{FIRSTNAME}", callBackPostRequest.Firstname},
                {"{LASTNAME}", callBackPostRequest.Lastname},
                {"{EMAILADDRESS}", callBackPostRequest.EmailAddress},
                {"{CALLBACKTIME}", callBackPostRequest.CallBackTime},
                {"{REFERENCEID}", callBackPostRequest.ReferenceId }
            };

            var utmCookie = UtmCookieHelper.GetUtmCookie(new HttpRequestWrapper(HttpContext.Current.Request));

            if (utmCookie == null) { return formFieldsDictionary; }

            var utmCookieSettings = UtmCookieSettings.Instance;

            formFieldsDictionary.Add($"{{{utmCookieSettings.UtmCookieCampaignKey.ToUpper()}}}", utmCookie[utmCookieSettings.UtmCookieCampaignKey]);
            formFieldsDictionary.Add($"{{{utmCookieSettings.UtmCookieContentKey.ToUpper()}}}", utmCookie[utmCookieSettings.UtmCookieContentKey]);
            formFieldsDictionary.Add($"{{{utmCookieSettings.UtmCookieMediumKey.ToUpper()}}}", utmCookie[utmCookieSettings.UtmCookieMediumKey]);
            formFieldsDictionary.Add($"{{{utmCookieSettings.UtmCookieRefUrlKey.ToUpper()}}}", utmCookie[utmCookieSettings.UtmCookieRefUrlKey]);
            formFieldsDictionary.Add($"{{{utmCookieSettings.UtmCookieSourceKey.ToUpper()}}}", utmCookie[utmCookieSettings.UtmCookieSourceKey]);
            formFieldsDictionary.Add($"{{{utmCookieSettings.UtmCookieTermKey.ToUpper()}}}", utmCookie[utmCookieSettings.UtmCookieTermKey]);
            formFieldsDictionary.Add($"{{{utmCookieSettings.UtmAdGroupKey.ToUpper()}}}", utmCookie[utmCookieSettings.UtmAdGroupKey]);

            return formFieldsDictionary;
        }

        private string TransformXML(Dictionary<string, string> dictionary)
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

            return requestXml;
        }
    }
}
