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

        public TResponse Send<TResponse>(IRequest<TResponse> request)
        {
            return this.handler.Handle((dynamic)request);
        }

        public Task<TResponse> SendAsync<TResponse>(IAsyncRequest<TResponse> request)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> SendAsync<TResponse>(ICancellableAsyncRequest<TResponse> request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Publish(INotification notification)
        {
            throw new NotImplementedException();
        }

        public Task PublishAsync(IAsyncNotification notification)
        {
            throw new NotImplementedException();
        }

        public Task PublishAsync(ICancellableAsyncNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
