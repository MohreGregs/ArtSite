using System.Text;
using ArtSite.Data.Enums;
using ArtSite.Data.Models;
using ArtSite.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArtSite.Database; 

public static class ModelBuilderExtensions {
    public static void Seed(this ModelBuilder builder) {
        var color = new Color {
            Id = 1,
            ColorCode = "FFFFFFFF",
            Name = "White"
        };

        var tag = new Tag {
            Id = 1,
            Name = "Cat",
            // Color = color
        };

        var artist = new Artist {
            Id = 1,
            Name = "mioau",
            Furaffinity = "https://www.furaffinity.net/user/mohregregs/"
        };

        var artwork = new Artwork {
            Id = 1,
            Extension = ".png",
            Description = Encoding.UTF8.GetBytes("An Artwork!"),
            File = File.ReadAllBytes(@"Y:\Zeug\Art\Characters\Teddy\Artwork by others\spicecraig.png")
        };

        var species = new Species {
            Id = 1,
            Name = "Cat"
        };

        var like = new Like {
            Id = 1,
            Name = "Gaming"
        };
        
        var like2 = new Like {
            Id = 2,
            Name = "Reading"
        };

        var generalInfo = new GeneralInfo {
            Id = 1,
            // Likes = { like, like2 },
            // Dislikes = {like, like2},
            Info = Encoding.UTF8.GetBytes("Hello!"),
            Trivia = Encoding.UTF8.GetBytes("Miau")
        };
        
        var trait = new Trait {
            Id = 1,
            Name = "Helpful"
        };

        var flaw = new Flaw {
            Id = 1,
            Name = "Possessive"
        };

        var personality = new Personality {
            Id = 1,
            // Traits = {trait},
            // Flaws = {flaw},
            PersonalityInfo = Encoding.UTF8.GetBytes("Meow"),
            Assertive = 1,
            Introverted = 1,
            Intuitiv = 1,
            Judging = 1,
            Thinking = 1
        };

        var hobby = new Hobby {
            Id = 1,
            Name = "Gaming"
        };

        var song = new Song {
            Id = 1,
            Name = "Meow",
            Interpret = "Cat",
            Link = "https://www.youtube.com/watch?v=cwyTleTL06Y"
        };

        var interests = new Interests {
            Id = 1,
            // Hobbies = {hobby},
            // Music = {song}
        };

        var appearance = new Appearance {
            Id = 1,
            AppearanceInfo = Encoding.UTF8.GetBytes("Appearance such amazing"),
            DesignNotes = Encoding.UTF8.GetBytes("-Meow")
        };

        var reference = new Reference {
            Id = 1,
            ArtworkId = 1,
            Name = "Anthro"
        };
        
        var character = new Character {
            Id = 1,
            Name = "Test",
            Gender = Gender.Female,
            Sexuality = Sexuality.Asexual,
            Age = 1,
            GeneralInfoId = 1,
            PersonalityId = 1,
            InterestsId = 1,
            AppearanceId = 1,
            IconId = 1
        };
        
        
        builder.Entity<Color>().HasData(new List<Color>
        {
            color
        });
        
        builder.Entity<Tag>().HasData(new List<Tag>
        {
            tag
        });

        builder.Entity<Trait>().HasData(new List<Trait>
        {
            trait
        });
        
        builder.Entity<Flaw>().HasData(new List<Flaw>
        {
            flaw
        });
        
        builder.Entity<Like>().HasData(new List<Like>
        {
            like,like2
        });
        
        builder.Entity<Hobby>().HasData(new List<Hobby>
        {
            hobby
        });
        
        builder.Entity<Song>().HasData(new List<Song>
        {
            song
        });
        
        builder.Entity<GeneralInfo>().HasData(new List<GeneralInfo>
        {
            generalInfo
        });

        builder.Entity<Appearance>().HasData(new List<Appearance> {
            appearance
        });
        
        builder.Entity<Personality>().HasData(new List<Personality>
        {
            personality
        });
        
        builder.Entity<Interests>().HasData(new List<Interests>
        {
            interests
        });
        
        builder.Entity<Reference>().HasData(new List<Reference>
        {
            reference
        });
        
        builder.Entity<Artist>().HasData(new List<Artist>
        {
            artist
        });
        
        builder.Entity<Artwork>().HasData(new List<Artwork>
        {
            artwork
        });
        
        builder.Entity<Species>().HasData(new List<Species>
        {
            species
        });

        builder.Entity<Character>().HasData(new List<Character> {
            character
        });
        
        
    }
}