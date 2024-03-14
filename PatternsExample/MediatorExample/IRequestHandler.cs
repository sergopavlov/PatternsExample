using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsExample.MediatorExample;
public interface IRequestHandler<TRequest, TResponse> : IRequestHandler where TRequest : IRequest<TResponse>
{
    Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}
public interface IRequestHandler
{
}

