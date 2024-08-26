using Domain.Entities.Manufacturers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
{
    public void Configure(EntityTypeBuilder<Manufacturer> builder)
    {
        builder.HasKey(static m => m.Id);
        builder.Property(static c => c.Id).HasField("_id");
        builder.Property(static c => c.Title).HasField("_title");
    }
}