using Domain.Entities.Countries;
using Domain.Entities.Manufacturers;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

internal sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Country> Countries => Set<Country>();

    public DbSet<Manufacturer> Manufacturer => Set<Manufacturer>();
}