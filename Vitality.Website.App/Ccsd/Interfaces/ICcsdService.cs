using System.Collections.Generic;
using Vitality.Website.App.Ccsd.Models;
using Vitality.Website.App.Interfaces;

namespace Vitality.Website.App.Ccsd.Interfaces
{
    public interface ICcsdService
    {
        List<Chapter> GetChapters(IFeedSettings feedSetting);
    }
}
