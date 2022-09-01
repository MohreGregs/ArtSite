using ArtSite.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtSite.Database.Configurations; 

public class LikeConfiguration :IEntityTypeConfiguration<Like> {
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.GeneralInfosLike).WithMany(x => x.Likes);
        builder.HasMany(x => x.GeneralInfosDislike).WithMany(x => x.Dislikes);
    }
}