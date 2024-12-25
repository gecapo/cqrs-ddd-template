namespace CqrsDddTemplate.Handlers.ImplementedEntities.Commands;

public static class UpdateImplementedEntity
{
    public sealed record Command(int Id, string Name) : IRequest;

    public sealed class Handler(IHandlerContext handlerContext) : CommandHandler<Command>(handlerContext)
    {
        public override async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = await DbContext.ImplementedEntity.FindAsync(request.Id, cancellationToken);
            ArgumentNullException.ThrowIfNull(entity);

            await DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}