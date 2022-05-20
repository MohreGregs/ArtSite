using ArtSite.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtSite.Database.Configurations; 

public class AppearanceConfiguration :IEntityTypeConfiguration<Appearance> {
    public void Configure(EntityTypeBuilder<Appearance> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Colors).WithMany(x => x.Appearances);
        builder.HasOne(x => x.Character).WithOne(x => x.Appearance).HasForeignKey<Character>(x => x.AppearanceId);
    }
}