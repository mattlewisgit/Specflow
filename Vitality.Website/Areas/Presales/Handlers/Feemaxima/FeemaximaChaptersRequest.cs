using System;
using MediatR;

namespace Vitality.Website.Areas.Presales.Handlers.FeeMaxima
{
    public class FeeMaximaChaptersRequest : IRequest<FeeMaximaChaptersDto>
    {
        public readonly Guid SettingsId;
        public FeeMaximaChaptersRequest(Guid settingsId)
        {
            SettingsId = settingsId;
        }
    }
}
