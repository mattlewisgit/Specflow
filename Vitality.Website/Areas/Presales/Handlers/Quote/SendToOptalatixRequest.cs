using System;
using MediatR;

namespace Vitality.Website.Areas.Presales.Handlers.Quote
{
    public class SendToOptalatixRequest : IRequest<string>
    {
        public readonly object Application;
        public string ReferenceId;
        public SendToOptalatixRequest(object application, string referenceId)
        {
            Application = application;
            ReferenceId = referenceId;
        }
    }
}
