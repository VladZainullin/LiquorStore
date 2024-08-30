using Domain.Entities.Products.Countries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(static c => c.Id);
        builder.Property(static c => c.Id).HasField("_id");
        builder.Property(static c => c.Title).HasField("_title");
    }
}