using System.Collections.Generic;
using Vitality.Website.App.Ccsd.Models;

namespace Vitality.Website.App.Ccsd.Interfaces
{
    public interface ICcsdService
    {
        IEnumerable<Chapter> GetChapters(string ccsdChaptersJsonFile);
    }
}
