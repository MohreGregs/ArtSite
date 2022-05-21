namespace ArtSite.Database.Entities; 

public class Artwork : BaseEntity{
    public byte[] Description { get; set; }
    public string FilePath { get; set; }

    public virtual ISet<Artist> Artists { get; set; } = new HashSet<Artist>();
    
    public virtual ISet<Character> Characters { get; set; } = new HashSet<Character>();
    public virtual Reference Reference { get; set; }
}