using ArtSite.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArtSite.Database; 

public static class ModelBuilderExtensions {
    public static void Seed(this ModelBuilder builder)
    {
        builder.Entity<Color>().HasData(new List<Color>
        {
            new Color
            {
                Id = 1,
                ColorCode = "FFFFFFFF",
                Name = "White"
            }
        });
    }
}