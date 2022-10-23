using InnoGotchi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnoGotchi.Persistence.EntityTypeConfiguration;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.HasKey(pet => pet.Id);
        builder.HasIndex(pet => pet.Id).IsUnique();

        builder.Property(pet => pet.Name).HasMaxLength(250);
    }
}