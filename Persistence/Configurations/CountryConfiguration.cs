using Domain.Entities.Products.Countries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(static c => c.Id);
        
        builder.ComplexProperty(
            static c => c.Title,
            static ct =>
        {
            ct.Property(static c => c.Value).HasColumnName("title");
        });
    }
}