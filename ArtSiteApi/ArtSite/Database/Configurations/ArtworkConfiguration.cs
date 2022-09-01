using ArtSite.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtSite.Database.Configurations; 

public class ArtworkConfiguration :IEntityTypeConfiguration<Artwork> {
    public void Configure(EntityTypeBuilder<Artwork> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Artists).WithMany(x => x.Artworks);
        builder.HasMany(x => x.Characters).WithMany(x => x.Artworks);
        builder.HasOne(x => x.Reference).WithOne(x => x.Artwork).HasForeignKey<Reference>(x => x.ArtworkId);
    }
}