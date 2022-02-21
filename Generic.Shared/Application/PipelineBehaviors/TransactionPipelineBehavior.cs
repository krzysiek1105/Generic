using System.Transactions;
using MediatR;

namespace Generic.Shared.Application.PipelineBehaviors;

internal class TransactionPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        var response = await next();
        transactionScope.Complete();

        return response;
    }
}