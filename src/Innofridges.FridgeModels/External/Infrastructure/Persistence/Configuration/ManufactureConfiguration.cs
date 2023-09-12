using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class ManufactureConfiguration : IEntityTypeConfiguration<Manufacture>
{
    public void Configure(EntityTypeBuilder<Manufacture> builder)
    {
        builder
            .HasMany(manufacture => manufacture.FridgeModels)
            .WithOne(fridgeModel => fridgeModel.Manufacture);
    }
}