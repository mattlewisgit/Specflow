using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;
using Sitecore.Data;
using Vitality.Core;
using Vitality.Mvc.Models;
using Vitality.Mvc.Utilities;
using Vitality.Website.Areas.Presales.Handlers.CallBack;
using Vitality.Website.Areas.Presales.Models;
using Vitality.Website.SC.CallPro;
using Vitality.Website.SC.WFFM;

namespace Vitality.Website.Areas.Presales.Services
{
    public class CallBackService : ICallBackService
    {
        public async Task<HttpResponseMessage> Post(CallBackPostRequest postData)
        {
            var generatedData = GenerateCallProData(postData);

            return await CallProAgent.Execute(generatedData);
        }

        public static Dictionary<string, string> GenerateCallProData(CallBackPostRequest callBackPostRequest)
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
                {"{TELEPHONENUMBER}", callBackPostRequest.PostData.Telephone},
                {"{TITLE}", callBackPostRequest.PostData.Title},
                {"{FIRSTNAME}", callBackPostRequest.PostData.Firstname},
                {"{LASTNAME}", callBackPostRequest.PostData.Lastname},
                {"{EMAILADDRESS}", callBackPostRequest.PostData.Email},
                {"{CALLBACKTIME}", callBackPostRequest.PostData.CallBackTime}
            };

            var utmCookie = UtmCookieHelper.GetUtmCookie(new HttpRequestWrapper(HttpContext.Current.Request));

            if (utmCookie == null) { return formFieldsDictionary;}

            var utmCookieSettings = UtmCookieSettings.Instance;

            formFieldsDictionary.Add($"{{{utmCookieSettings.UtmCookieCampaignKey.ToUpper()}}}", utmCookie[utmCookieSettings.UtmCookieCampaignKey]);
            formFieldsDictionary.Add($"{{{utmCookieSettings.UtmCookieContentKey.ToUpper()}}}", utmCookie[utmCookieSettings.UtmCookieContentKey]);
            formFieldsDictionary.Add($"{{{utmCookieSettings.UtmCookieMediumKey.ToUpper()}}}", utmCookie[utmCookieSettings.UtmCookieMediumKey]);
            formFieldsDictionary.Add($"{{{utmCookieSettings.UtmCookieRefUrlKey.ToUpper()}}}", utmCookie[utmCookieSettings.UtmCookieRefUrlKey]);
            formFieldsDictionary.Add($"{{{utmCookieSettings.UtmCookieSourceKey.ToUpper()}}}", utmCookie[utmCookieSettings.UtmCookieSourceKey]);
            formFieldsDictionary.Add($"{{{utmCookieSettings.UtmCookieTermKey.ToUpper()}}}", utmCookie[utmCookieSettings.UtmCookieTermKey]);

            return formFieldsDictionary;
        }
    }
}