using System.Collections.Generic;
using Vitality.Website.App.Models.Feemaxima;

namespace Vitality.Website.App.Services.Interfaces
{
    public interface ICcsdService
    {
        IEnumerable<Chapter> GetChapters();
    }
}
