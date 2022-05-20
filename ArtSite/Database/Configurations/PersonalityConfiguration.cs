using ArtSite.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtSite.Database.Configurations; 

public class PersonalityConfiguration :IEntityTypeConfiguration<Personality> {
    public void Configure(EntityTypeBuilder<Personality> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Traits).WithMany(x => x.Personalities);
        builder.HasMany(x => x.Flaws).WithMany(x => x.Personalities);
        builder.HasOne(x => x.Character).WithOne(x => x.Personality).HasForeignKey<Character>(x => x.PersonalityId);
    }
}