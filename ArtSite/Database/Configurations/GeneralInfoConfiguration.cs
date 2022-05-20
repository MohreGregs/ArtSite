using ArtSite.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtSite.Database.Configurations; 

public class GeneralInfoConfiguration :IEntityTypeConfiguration<GeneralInfo> {
    public void Configure(EntityTypeBuilder<GeneralInfo> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Character).WithOne(x => x.GeneralInfo).HasForeignKey<Character>(x => x.GeneralInfoId);
    }
}