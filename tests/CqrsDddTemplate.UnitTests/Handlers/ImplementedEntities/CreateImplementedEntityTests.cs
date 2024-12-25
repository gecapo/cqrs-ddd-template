using CqrsDddTemplate.Handlers.ImplementedEntities.Commands;

namespace CqrsDddTemplate.UnitTests.Handlers.ImplementedEntities;

public class CreateImplementedEntityTests
{
    private static CreateImplementedEntity.Handler GetHandler(ApplicationDbContext dbContext) =>
        new(HandlerContextFactory.GetHandlerContext(dbContext));

    private static void SetTestData(ApplicationDbContext dc)
    {
        var products = new List<ImplementedEntity>
        {
            new("One"),
            new("Two"),
            new("Three"),
        };

        dc.ImplementedEntity.AddRange(products);
        dc.SaveChanges();
    }

    [Fact]
    public async Task Create_ImplementedEntity_ReturnProductId()
    {
        var dc = InMemoryDbContextFactory.Create();
        SetTestData(dc);

        var implementedEntityName = "Four";
        var command = new CreateImplementedEntity.Command(implementedEntityName);

        var expectedName = implementedEntityName;
        var expectedCount = 4;

        var id = await GetHandler(dc).Handle(command, default);

        Assert.NotNull(id);

        var result = dc.ImplementedEntity.SingleOrDefault(o => o.Id == id);
        var actualCount = dc.ImplementedEntity.Count();

        Assert.NotNull(result);
        Assert.Equal(expectedName, result.Name);
        Assert.Equal(expectedCount, actualCount);
    }

    [Fact]
    public async Task Create_ImplementedEntity_ThrowArgumentException()
    {
        var dc = InMemoryDbContextFactory.Create();
        SetTestData(dc);

        var command = new CreateImplementedEntity.Command("");

        await Assert.ThrowsAsync<ArgumentException>(async () => await GetHandler(dc).Handle(command, default));
    }
}