using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsExample.MediatorExample;
public interface IMediator
{
    void AddHandler(IRequestHandler handler);
    Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest<TResponse>;
}
public class Mediator : IMediator
{
    private List<IRequestHandler> _handlers = [];
    public Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest<TResponse>
    {
        var handler = _handlers.OfType<IRequestHandler<TRequest, TResponse>>().FirstOrDefault();
        if (handler is null)
            throw new ArgumentException("Can't find handler for desired request", nameof(request));
        return handler.Handle(request, cancellationToken);
    }
    public void AddHandler(IRequestHandler handler)
    {
        _handlers.Add(handler);
    }
}
