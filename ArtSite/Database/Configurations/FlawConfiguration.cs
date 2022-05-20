using ArtSite.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtSite.Database.Configurations; 

public class FlawConfiguration :IEntityTypeConfiguration<Flaw> {
    public void Configure(EntityTypeBuilder<Flaw> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Personalities).WithMany(x => x.Flaws);
    }
}