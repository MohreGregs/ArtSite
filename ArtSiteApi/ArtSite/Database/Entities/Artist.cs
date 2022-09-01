namespace ArtSite.Database.Entities; 

public class Artist : BaseNameEntity{
    public string? Website { get; set; }
    public string? Furaffinity { get; set; }
    public string? ToyHouse { get; set; }
    public string? Twitter { get; set; }
    public string? ArtFight { get; set; }

    public virtual ISet<Artwork> Artworks { get; set; } = new HashSet<Artwork>();
    public virtual ISet<Character> Characters { get; set; } = new HashSet<Character>();
}