using InnoFridges.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using saja;

namespace InnoFridges.Persistence.Configurations;

public class InnoUserConfiguration : ModelUserBaseConfiguration<InnoUser>
{
    public override void Configure(EntityTypeBuilder<InnoUser> builder)
    {
        base.Configure(builder);
        builder.HasIndex(user => user.Email).IsUnique();
    }
}