using Domain.MeasurementUnits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

file sealed class MeasurementUnitConfiguration : IEntityTypeConfiguration<MeasurementUnit>
{
    public void Configure(EntityTypeBuilder<MeasurementUnit> builder)
    {
        builder.Property(static mu => mu.Id).HasField("_id");
        builder.Property(static mu => mu.Title).HasField("_title");
        builder.Property(static mu => mu.RemovedAt).HasField("_removedAt");

        builder.HasIndex(static mu => mu.Title);
    }
}