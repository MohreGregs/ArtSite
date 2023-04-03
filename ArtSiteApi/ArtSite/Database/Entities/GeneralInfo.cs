namespace ArtSite.Database.Entities; 

public class GeneralInfo : BaseEntity {
    public string Info { get; set; } = "";
    public string Trivia { get; set; }= "";
    public string Likes { get; set; }= "";
    public string Dislikes { get; set; }= "";
    
    public virtual Character Character { get; set; }
}