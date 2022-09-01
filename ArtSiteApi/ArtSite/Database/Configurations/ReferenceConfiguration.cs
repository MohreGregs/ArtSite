using ArtSite.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtSite.Database.Configurations; 

public class ReferenceConfiguration :IEntityTypeConfiguration<Reference> {
    public void Configure(EntityTypeBuilder<Reference> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Character).WithMany(x => x.References).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Artwork).WithOne(x => x.Reference);
    }
}