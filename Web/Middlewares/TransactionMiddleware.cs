using Persistence.Contracts;

namespace Web.Middlewares;

internal sealed class TransactionMiddleware(ITransactionContext transactionContext) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var cancellationToken = context.RequestAborted;
        await transactionContext.BeginTransactionAsync(cancellationToken);
        try
        {
            await next(context);
            await transactionContext.CommitTransactionAsync(cancellationToken);
        }
        catch
        {
            await transactionContext.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }
}