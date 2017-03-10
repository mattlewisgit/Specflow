using System;
using System.Net.Http;
using System.Web.Http;
using Glass.Mapper.Sc;
using MediatR;
using Sitecore.Data;
using Vitality.Website.Areas.Presales.Handlers.SocialMedia;
using Vitality.Website.Areas.Presales.SettingsTemplates;

namespace Vitality.Website.Areas.Presales.Controllers
{
    public class SocialMediaController : BaseController
    {
        private readonly ISitecoreContext _sitecoreContext;

        public SocialMediaController(IMediator mediator, ISitecoreContext sitecoreContext)
            : base(mediator)
        {
            _sitecoreContext = sitecoreContext;
        }

        [HttpGet]
        [Route("api/SocialMedia/PopularityCounts")]
        public HttpResponseMessage PopularityCounts(Guid settingsId)
        {
            var socialMediaSettings = _sitecoreContext.GetItem<SocialMediaSettings>(settingsId);
            return this.GetResponse<SocialMediaCountsRequest, SocialMediaCountsDto>(
                new SocialMediaCountsRequest(socialMediaSettings)
                , result => result.Count >= 0);
        }
    }
}
