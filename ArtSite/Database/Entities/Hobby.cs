namespace ArtSite.Database.Entities; 

public class Hobby : BaseNameEntity {
    public virtual ISet<Interests> InterestsSet { get; set; } = new HashSet<Interests>();
}