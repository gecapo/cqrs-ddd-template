using CqrsDddTemplate.Domain.Abstractions;

namespace CqrsDddTemplate.Domain;

public class ImplementedEntity : Entity<int>
{
    public string Name { get; private set; }

    /// <summary>
    /// EF Core Only
    /// </summary>
    private ImplementedEntity() { }
    
    public ImplementedEntity(string name)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(name);
        Name = name;
    }
}