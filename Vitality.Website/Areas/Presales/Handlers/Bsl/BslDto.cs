using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Vitality.Website.Areas.Presales.Handlers.Bsl
{
    public class BslDto
    {
        public JObject BslResponse { get; set; }

        public static async Task<BslDto> From(Task<string> bslResponse)
        {
            return new BslDto
            {
                BslResponse = JObject.Parse(await bslResponse)
            };
        }
    }
}
