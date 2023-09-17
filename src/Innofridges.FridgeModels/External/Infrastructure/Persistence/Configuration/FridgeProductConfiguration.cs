using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class FridgeProductConfiguration : IEntityTypeConfiguration<FridgeProduct>
{
    public void Configure(EntityTypeBuilder<FridgeProduct> builder)
    {
        builder
            .HasOne(fridgeProduct => fridgeProduct.Product)
            .WithMany(product => product.FridgeProducts);

        builder
            .HasOne(fridgeProduct => fridgeProduct.Fridge)
            .WithMany(fridge => fridge.FridgeProducts);

        builder.HasKey(product => product.Id);
    }
}