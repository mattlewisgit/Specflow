namespace Vitality.Website.UnitTests.TestDoubles
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    public class MediatorStub<TRequest, TResponse> : IMediator where TRequest : IRequest<TResponse>
    {
        private readonly IRequestHandler<TRequest, TResponse> handler;

        public MediatorStub(IRequestHandler<TRequest, TResponse> requestHandler)
        {
            this.handler = requestHandler;
        }

        public Task<TResponse1> Send<TResponse1>(IRequest<TResponse1> request, CancellationToken cancellationToken = new CancellationToken())
        {
            return this.handler.Handle((dynamic)request);
        }

        public Task Send(IRequest request, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = new CancellationToken()) where TNotification : INotification
        {
            throw new NotImplementedException();
        }
    }
}
