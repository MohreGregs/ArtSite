using ArtSite.Data.Enums;

namespace ArtSite.Database.Entities; 

public class Character : BaseNameEntity {
    public byte Age { get; set; }
    public Gender Gender { get; set; }
    public Sexuality Sexuality { get; set; }
    public int? IconId { get; set; }
    public byte[]? WantedArtwork { get; set; }
    
    public virtual Artwork? Icon { get; set; }
    public virtual ISet<Tag>? Tags { get; set; } = new HashSet<Tag>();
    public virtual Species? Species { get; set; }
    public virtual Artist? OriginalDesigner { get; set; }
    public virtual ISet<Reference>? References { get; set; } = new HashSet<Reference>();
    public int? GeneralInfoId { get; set; }
    public virtual GeneralInfo? GeneralInfo { get; set; }
    public int? PersonalityId { get; set; }
    public virtual Personality? Personality { get; set; }
    public int? InterestsId { get; set; }
    public virtual Interests? Interests { get; set; }
    public int? AppearanceId { get; set; }
    public virtual Appearance? Appearance { get; set; }

    public virtual ISet<Artwork> Artworks { get; set; } = new HashSet<Artwork>();
}