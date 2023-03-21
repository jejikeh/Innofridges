using Innogotchi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Innogotchi.Persistence.Configurations;

public class InnoUserConfiguration : IEntityTypeConfiguration<InnoUser>
{
    public void Configure(EntityTypeBuilder<InnoUser> builder)
    {
        builder.HasKey(user => user.InnoUserId);
        builder.HasIndex(user => user.InnoUserId).IsUnique();
        builder.HasIndex(user => user.Username).IsUnique();
        builder.Property(user => user.PasswordHash).IsRequired();
    }
}