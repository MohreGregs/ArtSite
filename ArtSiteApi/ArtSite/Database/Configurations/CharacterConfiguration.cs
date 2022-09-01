using ArtSite.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtSite.Database.Configurations; 

public class CharacterConfiguration : IEntityTypeConfiguration<Character> {
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Tags).WithMany(x => x.Characters);
        builder.HasOne(x => x.Species).WithMany(x => x.Characters);
        builder.HasOne(x => x.OriginalDesigner).WithMany(x => x.Characters);
        builder.HasMany(x => x.References).WithOne(x => x.Character);
        builder.HasOne(x => x.GeneralInfo).WithOne(x => x.Character).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Personality).WithOne(x => x.Character).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Interests).WithOne(x => x.Character).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Appearance).WithOne(x => x.Character).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(x => x.Artworks).WithMany(x => x.Characters);
    }
}