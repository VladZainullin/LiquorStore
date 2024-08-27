using System.Reflection;
using Domain.Entities.Countries;
using Domain.Entities.Manufacturers;
using Domain.Entities.Tags;
using Microsoft.EntityFrameworkCore;

// ReSharper disable ReturnTypeCanBeEnumerable.Global

namespace Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Country> Countries => Set<Country>();

    public DbSet<Manufacturer> Manufacturer => Set<Manufacturer>();

    public DbSet<Tag> Tags => Set<Tag>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }
}