namespace CqrsDddTemplate.Handlers.ImplementedEntities.Commands;

public static class CreateImplementedEntity
{
    public sealed record Command(string Name) : IRequest<int>;

    public sealed class Handler(IHandlerContext handlerContext) : CommandHandler<Command, int>(handlerContext)
    {
        public override async Task<int> Handle(Command request, CancellationToken cancellationToken)
        {
            ImplementedEntity entity = new(request.Name);
            await DbContext.ImplementedEntity.AddAsync(entity, cancellationToken);
            await DbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}