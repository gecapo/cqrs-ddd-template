using System.Runtime.CompilerServices;
using CqrsDddTemplate.Domain;
using CqrsDddTemplate.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CqrsDddTemplate.Infrastructure;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options), IDbContext
{
    public DbSet<ImplementedEntity> ImplementedEntity { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        if (!builder.IsConfigured)
        {
            builder.UseAzureSql("");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ImplementedEntity>()
            .HasIndex(x => x.CreatedAt);

        base.OnModelCreating(modelBuilder);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default,
        [CallerMemberName] string? callerFunction = null,
        [CallerFilePath] string? callerFile = null) =>
        await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);