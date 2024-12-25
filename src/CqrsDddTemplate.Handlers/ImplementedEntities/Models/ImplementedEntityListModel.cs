namespace CqrsDddTemplate.Handlers.ImplementedEntities.Models;

public sealed record ImplementedEntityListModel(ImplementedEntity entity)
{
    public int Id { get; private set; } = entity.Id;
    public string Name { get; private set; } = entity.Name;

    public static ImplementedEntityListModel Create(ImplementedEntity customer) => new(customer);
}