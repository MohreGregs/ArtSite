using ArtSite.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtSite.Database.Configurations; 

public class TraitConfiguration :IEntityTypeConfiguration<Trait> {
    public void Configure(EntityTypeBuilder<Trait> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Name).IsUnique();
        builder.HasMany(x => x.Personalities).WithMany(x => x.Traits);
    }
}