using System.Runtime.CompilerServices;
using CqrsDddTemplate.Domain;
using Microsoft.EntityFrameworkCore;

namespace CqrsDddTemplate.Infrastructure.Interfaces;

public interface IDbContext : IDisposable
{
    public DbSet<ImplementedEntity> ImplementedEntity { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default, 
        [CallerMemberName] string? callerFunction = null, 
        [CallerFilePath] string? callerFile = null);
}