using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Vitality.Website.App.Models.FeeMaxima;
using Vitality.Website.App.Services.Interfaces;

namespace Vitality.Website.App.Services
{
    public class CcsdService : ICcsdService 
    {
        public IEnumerable<Chapter> GetChapters(string ccsdChaptersJsonFile)
        {
            //TODO: Read data from Papillion
            return JsonConvert.DeserializeObject<List<Chapter>>(File.ReadAllText(ccsdChaptersJsonFile));
        }
    }
}
