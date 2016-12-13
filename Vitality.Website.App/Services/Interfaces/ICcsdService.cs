using System.Collections.Generic;
using Vitality.Website.App.Models.FeeMaxima;

namespace Vitality.Website.App.Services.Interfaces
{
    public interface ICcsdService
    {
        IEnumerable<Chapter> GetChapters(string ccsdChaptersJsonFile);
    }
}
