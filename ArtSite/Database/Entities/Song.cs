namespace ArtSite.Database.Entities; 

public class Song : BaseNameEntity{
    public string Interpret { get; set; }
    public string Link { get; set; }
    
    public virtual ISet<Interests> InterestsSet { get; set; } = new HashSet<Interests>();

}