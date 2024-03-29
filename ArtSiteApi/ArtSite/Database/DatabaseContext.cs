﻿using ArtSite.Database.Configurations;
using ArtSite.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArtSite.Database;

public class DatabaseContext : DbContext {
    public DbSet<Appearance> Appearances { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<GeneralInfo> GeneralInfos { get; set; }
    public DbSet<Interests> InterestsSet { get; set; }
    public DbSet<Personality> Personalities { get; set; }
    public DbSet<Reference> References { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<Species> Species { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public DatabaseContext(bool deleteDb = false)
    {
        if(deleteDb)
            Database.EnsureDeleted();
        
        Database.EnsureCreated();
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=database.db");
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AppearanceConfiguration());
        modelBuilder.ApplyConfiguration(new ArtistConfiguration());
        modelBuilder.ApplyConfiguration(new CharacterConfiguration());
        modelBuilder.ApplyConfiguration(new ColorConfiguration());
        modelBuilder.ApplyConfiguration(new GeneralInfoConfiguration());
        modelBuilder.ApplyConfiguration(new InterestsConfiguration());
        modelBuilder.ApplyConfiguration(new PersonalityConfiguration());
        modelBuilder.ApplyConfiguration(new ReferenceConfiguration());
        modelBuilder.ApplyConfiguration(new SongConfiguration());
        modelBuilder.ApplyConfiguration(new SpeciesConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
    }
}