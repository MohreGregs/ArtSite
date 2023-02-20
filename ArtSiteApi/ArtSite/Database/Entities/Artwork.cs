using ArtSite.Data.Enums;

namespace ArtSite.Database.Entities; 

public class Artwork : BaseEntity{
    public byte[] Description { get; set; }
    public byte[] File { get; set; }
    public string Extension { get; set; }
    public NSFWRating NsfwRating { get; set; }
    public GoreRating GoreRating { get; set; }

    public virtual ISet<Tag> Tags { get; set; } = new HashSet<Tag>();
    public virtual ISet<Artist> Artists { get; set; } = new HashSet<Artist>();
    public virtual ISet<Character> Characters { get; set; } = new HashSet<Character>();
    public virtual Reference Reference { get; set; }
    public virtual ISet<Character> IconCharacters { get; set; } = new HashSet<Character>();
}