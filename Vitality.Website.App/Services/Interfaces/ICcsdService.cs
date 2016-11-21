using System.Collections.Generic;
using Vitality.Website.App.Models.CCSD;

namespace Vitality.Website.App.Services.Interfaces
{
    public interface ICcsdService
    {
        IEnumerable<CcsdChapter> GetChapters();
    }
}
