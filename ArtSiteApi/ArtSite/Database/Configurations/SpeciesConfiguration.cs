using ArtSite.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtSite.Database.Configurations; 

public class SpeciesConfiguration :IEntityTypeConfiguration<Species> {
    public void Configure(EntityTypeBuilder<Species> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Characters).WithOne(x => x.Species);
    }
}