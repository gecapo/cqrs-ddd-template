using CqrsDddTemplate.Infrastructure.Interfaces;
using Serilog;

namespace CqrsDddTemplate.Handlers.Abstractions;

public interface IHandlerContext
{
    IDbContext DbContext { get; }
    ILogger Logger { get; }
}