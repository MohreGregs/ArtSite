namespace ArtSite.Database.Entities; 

public class Interests : BaseEntity {
    public byte[]? Hobbies { get; set; }
    public virtual ISet<Song> Music { get; set; } = new HashSet<Song>();
    
    public virtual Character Character { get; set; }
}