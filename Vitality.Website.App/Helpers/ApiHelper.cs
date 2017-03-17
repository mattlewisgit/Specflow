using System;
using System.Net;
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
        /// <param name="getMockData"></param>
        /// <returns></returns>
        public static T HandleResponse<T>(this IRestResponse<T> response, Func<T> getMockData = null)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            }
            if (getMockData !=null)
            {
                return getMockData();
            }
            var exception = new Exception(response.ErrorMessage);
            exception.Data.Add(StatusCodeKey, response.StatusCode);
            exception.Data.Add(MoreInfoKey, response.Content);
            throw exception;
        }
    }
}

