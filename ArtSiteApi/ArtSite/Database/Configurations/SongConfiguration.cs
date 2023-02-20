using ArtSite.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtSite.Database.Configurations; 

public class SongConfiguration :IEntityTypeConfiguration<Song> {
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.InterestsSet).WithMany(x => x.Music);
    }
}