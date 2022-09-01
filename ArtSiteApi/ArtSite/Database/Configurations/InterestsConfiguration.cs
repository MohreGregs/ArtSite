using ArtSite.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtSite.Database.Configurations; 

public class InterestsConfiguration :IEntityTypeConfiguration<Interests> {
    public void Configure(EntityTypeBuilder<Interests> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Hobbies).WithMany(x => x.InterestsSet);
        builder.HasMany(x => x.Music).WithMany(x => x.InterestsSet);
        builder.HasOne(x => x.Character).WithOne(x => x.Interests).HasForeignKey<Character>(x => x.InterestsId).OnDelete(DeleteBehavior.Cascade);
    }
}