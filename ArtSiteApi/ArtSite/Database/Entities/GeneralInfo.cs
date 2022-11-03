namespace ArtSite.Database.Entities; 

public class GeneralInfo : BaseEntity{
    public byte[]? Info { get; set; }
    public byte[]? Trivia { get; set; }
    public byte[]? Likes { get; set; }
    public byte[]? Dislikes { get; set; }
    
    public virtual Character Character { get; set; }
}