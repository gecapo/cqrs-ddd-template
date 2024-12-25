using CqrsDddTemplate.Domain.Abstractions;

namespace CqrsDddTemplate.Domain;

public class ImplementedEntity : Entity<int>
{
    public string Name { get; private set; }

    public ImplementedEntity(string name)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(name);
        Name = name;
    }
}