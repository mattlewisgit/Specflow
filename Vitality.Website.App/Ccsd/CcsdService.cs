using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Vitality.Website.App.Ccsd.Interfaces;
using Vitality.Website.App.Ccsd.Models;

namespace Vitality.Website.App.Ccsd
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
