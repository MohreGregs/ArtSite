using ArtSite.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtSite.Database.Configurations; 

public class ArtistConfiguration : IEntityTypeConfiguration<Artist> {
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Artworks).WithMany(x => x.Artists);
        builder.HasMany(x => x.Characters).WithOne(x => x.OriginalDesigner);
    }
}