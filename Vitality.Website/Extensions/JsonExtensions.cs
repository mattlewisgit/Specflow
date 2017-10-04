using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Extensions
{
    public static class JsonExtensions
    {
        public static string SerializeToCamelCase<T>(this SitecoreItem model)
        {
            return JsonConvert.SerializeObject(Mapper.Map<T>(model),
                new JsonSerializerSettings {ContractResolver = new CamelCasePropertyNamesContractResolver()});
        }
    }
}
