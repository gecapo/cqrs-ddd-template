using CqrsDddTemplate.Infrastructure.Interfaces;
using Serilog;

/// <summary>
/// Abstraction over MediatR
/// </summary>
/// <param name="context"></param>
/// <typeparam name="TCommand"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public abstract class CommandHandler<TCommand, TResponse>(IHandlerContext context)
    : IRequestHandler<TCommand, TResponse> where TCommand : IRequest<TResponse>
{
    protected readonly ILogger Logger = context.Logger;
    protected readonly IDbContext DbContext = context.DbContext;

    public abstract Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken);
}

public abstract class CommandHandler<TCommand>(IHandlerContext context)
    : IRequestHandler<TCommand> where TCommand : IRequest
{
    protected readonly ILogger Logger = context.Logger;
    protected readonly IDbContext DbContext = context.DbContext;

    public abstract Task Handle(TCommand request, CancellationToken cancellationToken);
}