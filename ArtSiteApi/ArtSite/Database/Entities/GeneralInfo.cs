namespace ArtSite.Database.Entities; 

public class GeneralInfo : BaseEntity{
    public byte[] Info { get; set; }
    public byte[] Trivia { get; set; }

    public virtual ISet<Like> Likes { get; set; } = new HashSet<Like>();
    public virtual ISet<Like> Dislikes { get; set; } = new HashSet<Like>();
    
    public virtual Character Character { get; set; }
}