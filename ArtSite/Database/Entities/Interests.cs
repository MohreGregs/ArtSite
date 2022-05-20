namespace ArtSite.Database.Entities; 

public class Interests : BaseEntity {
    public virtual ISet<Hobby> Hobbies { get; set; } = new HashSet<Hobby>();
    public virtual ISet<Song> Music { get; set; } = new HashSet<Song>();
    
    public virtual Character Character { get; set; }
}