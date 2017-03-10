using System;
using System.Net;
using RestSharp;

namespace Vitality.Website.App.Handlers
{
    public static class ApiResponseHandler
    {
        public static string StatusCodeKey = "StatusCode";

        public static T Handle<T>(this IRestResponse<T> response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            }
            var exception =new Exception(response.ErrorMessage);
            exception.Data.Add(StatusCodeKey, response.StatusCode);
            exception.Data.Add("MoreInfo" , response.Content);
            throw exception;
        }
    }
}
