using System;
using MediatR;

namespace Vitality.Website.Areas.Presales.Handlers.Quote
{
    public class SaveApplicationRequest : IRequest<string>
    {
        public readonly object Application;
        public string ReferenceId;
        public SaveApplicationRequest(object application, string referenceId)
        {
            Application = application;
            ReferenceId = referenceId;
        }
    }
}
