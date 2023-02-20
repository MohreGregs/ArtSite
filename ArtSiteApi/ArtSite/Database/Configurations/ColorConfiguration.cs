using ArtSite.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtSite.Database.Configurations; 

public class ColorConfiguration : IEntityTypeConfiguration<Color> {
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Appearances).WithMany(x => x.Colors);
        builder.HasMany(x => x.Tags).WithOne(x => x.Color);
    }
}