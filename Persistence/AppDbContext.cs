using System.Reflection;
using Domain.MeasurementUnitPositions;
using Domain.MeasurementUnits;
using Microsoft.EntityFrameworkCore;

// ReSharper disable ReturnTypeCanBeEnumerable.Global

namespace Persistence;

internal sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<MeasurementUnit> MeasurementUnits => Set<MeasurementUnit>();

    public DbSet<MeasurementUnitPosition> MeasurementUnitPositions => Set<MeasurementUnitPosition>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }
}