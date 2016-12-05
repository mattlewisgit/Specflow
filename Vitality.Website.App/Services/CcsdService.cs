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
        private readonly string _ccsdChaptersJsonFile = @"C:\projects\vitality-website\Vitality.Website.App\Data\CcsdChaptersWithProcedures.json";
        public IEnumerable<Chapter> GetChapters()
        {
            //TODO: Read data from Papillion
            return JsonConvert.DeserializeObject<List<Chapter>>(File.ReadAllText(_ccsdChaptersJsonFile));
        }
    }
}
