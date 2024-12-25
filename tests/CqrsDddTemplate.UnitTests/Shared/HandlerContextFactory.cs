using CqrsDddTemplate.Handlers.Abstractions;

namespace CqrsDddTemplate.UnitTests.Shared;

public static class HandlerContextFactory
{
    public static IHandlerContext GetHandlerContext(ApplicationDbContext dbContext) =>
        new HandlerContext(dbContext, LoggerFactory.Create());
}