namespace Vitality.Website.UnitTests.TestDoubles
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    public class MediatorAsyncStub<TRequest, TResponse> : IMediator where TRequest : IAsyncRequest<TResponse>
    {
        private readonly IAsyncRequestHandler<TRequest, TResponse> _handler;

        public MediatorAsyncStub(IAsyncRequestHandler<TRequest, TResponse> requestHandler)
        {
            _handler = requestHandler;
        }

        public TResponse1 Send<TResponse1>(IRequest<TResponse1> request)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse1> SendAsync<TResponse1>(IAsyncRequest<TResponse1> request)
        {
            return _handler.Handle((dynamic)request);
        }

        public Task<TResponse1> SendAsync<TResponse1>(ICancellableAsyncRequest<TResponse1> request, CancellationToken cancellationToken)
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
