using CqrsDddTemplate.Handlers.ImplementedEntities.Models;

namespace CqrsDddTemplate.Handlers.ImplementedEntities.Queries;

public static class ListImplementedEntities
{
    public sealed record Query() : IRequest<Response>;

    public sealed class Response(IReadOnlyCollection<ImplementedEntity> entities)
    {
        public IReadOnlyCollection<ImplementedEntityListModel> Customers { get; private set; } =
            entities.Select(ImplementedEntityListModel.Create).ToList();
    }

    public sealed class Handler(IHandlerContext handlerContext) : CommandHandler<Query, Response>(handlerContext)
    {
        public override async Task<Response> Handle(Query request, CancellationToken cancellationToken)
        {
            var entities = await DbContext.ImplementedEntity
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return new Response(entities);
        }
    }
}