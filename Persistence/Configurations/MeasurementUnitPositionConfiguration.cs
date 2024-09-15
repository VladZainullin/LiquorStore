using Domain.MeasurementUnitPositions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

file sealed class MeasurementUnitPositionConfiguration : 
    IEntityTypeConfiguration<MeasurementUnitPosition>
{
    public void Configure(EntityTypeBuilder<MeasurementUnitPosition> builder)
    {
        builder.Property(static mup => mup.Id).HasField("_id").ValueGeneratedNever();
        builder.Property(static mup => mup.Value).HasField("_value");
        builder
            .HasOne(static mup => mup.MeasurementUnit)
            .WithMany(static mu => mu.MeasurementUnitPositions);
    }
}