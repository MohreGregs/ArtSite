using ArtSite.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtSite.Database.Configurations; 

public class HobbyConfiguration :IEntityTypeConfiguration<Hobby> {
    public void Configure(EntityTypeBuilder<Hobby> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.InterestsSet).WithMany(x => x.Hobbies);
    }
}