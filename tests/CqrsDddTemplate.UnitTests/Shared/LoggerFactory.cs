using Serilog;

namespace CqrsDddTemplate.UnitTests.Shared;

public static class LoggerFactory
{
    public static ILogger Create()
    {
        var logger = new LoggerConfiguration()
            .CreateLogger();

        return logger;
    }
}