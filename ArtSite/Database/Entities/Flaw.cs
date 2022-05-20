namespace ArtSite.Database.Entities; 

public class Flaw : BaseNameEntity {
    public virtual ISet<Personality> Personalities { get; set; } = new HashSet<Personality>();
}