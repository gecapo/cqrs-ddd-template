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
            .Property(x => x.Name)
            .HasMaxLength(128);

        modelBuilder.Entity<ImplementedEntity>()
            .HasIndex(x => new { x.Id, x.CreatedAt })
            .IncludeProperties(x => new { x.Id, x.CreatedAt, x.Name })
            .HasDatabaseName("IX_Id_CreatedAt_Descending")
            .IsDescending();

        modelBuilder
            .Entity<ImplementedEntity>()
            .ToTable(b => b.HasCheckConstraint("CK_Name", "[Name] <> 'NULL'"));

        base.OnModelCreating(modelBuilder);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default,
        [CallerMemberName] string? callerFunction = null,
        [CallerFilePath] string? callerFile = null) =>
        await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
}