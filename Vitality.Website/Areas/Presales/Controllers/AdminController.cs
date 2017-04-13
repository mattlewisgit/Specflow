using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Runtime.Caching;
using System.Web.Http;

namespace Vitality.Website.Areas.Presales.Controllers
{
    /// <summary>
    /// Only to be used by DevOps
    /// </summary>
    public class AdminController : ApiController
    {
        private static readonly ObjectCache MemoryCacheStore = MemoryCache.Default;

        /// <summary>
        /// Helper to clear cache object from the memory cache. Keep it as Post as only DevOps use it
        /// </summary>
        /// <param name="cacheKey">Key for the Cache Object to be deleted</param>
        /// <param name="secreteKey">Secrete key to compare with WebConfig value</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/admin/clearcache")]
        public HttpResponseMessage ClearCache(string cacheKey, string secreteKey)
        {
            if (!string.Equals(secreteKey, ConfigurationManager.AppSettings["SecreteKey"]))
            {
                return new HttpResponseMessage(HttpStatusCode.Forbidden);
            }
            MemoryCacheStore.Remove(cacheKey);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
