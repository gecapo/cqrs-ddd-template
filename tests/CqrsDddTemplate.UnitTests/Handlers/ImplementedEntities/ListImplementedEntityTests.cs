using CqrsDddTemplate.Handlers.ImplementedEntities.Queries;

namespace CqrsDddTemplate.UnitTests.Handlers.ImplementedEntities;

public class ListImplementedEntityTests
{
    private static ListImplementedEntities.Handler GetHandler(ApplicationDbContext dbContext) =>
        new(HandlerContextFactory.GetHandlerContext(dbContext));

    private static List<ImplementedEntity> ImplementedEntities =
    [
        new("One"),
        new("Two"),
        new("Three")
    ];

    private static void SetTestData(ApplicationDbContext dc)
    {
        dc.ImplementedEntity.AddRange(ImplementedEntities);
        dc.SaveChanges();
    }

    [Fact]
    public async Task List_ImplementedEntity_ReturnsCorrectCount()
    {
        var dc = InMemoryDbContextFactory.Create();
        SetTestData(dc);

        var query = new ListImplementedEntities.Query();
        var expectedCount = 3;

        var entities = await GetHandler(dc).Handle(query, default);
        Assert.Equal(expectedCount, entities.Entities.Count());
    }
}