namespace Vitality.Website.UnitTests.TestDoubles
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    public class MediatorAsyncStub<TRequest, TResponse> : IMediator where TRequest : IRequest<TResponse>
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
        
        public void Publish(INotification notification)
        {
            throw new NotImplementedException();
        }

        public Task PublishAsync(INotification notification)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse1> Send<TResponse1>(IRequest<TResponse1> request, CancellationToken cancellationToken = new CancellationToken())
        {
            return _handler.Handle((dynamic)request);
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
