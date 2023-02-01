using ArtSite.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtSite.Database.Configurations; 

public class TagConfiguration :IEntityTypeConfiguration<Tag> {
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Color).WithMany(x => x.Tags);
        builder.HasMany(x => x.Characters).WithMany(x => x.Tags);
        builder.HasMany(x => x.Artworks).WithMany(x => x.Tags);
    }
}