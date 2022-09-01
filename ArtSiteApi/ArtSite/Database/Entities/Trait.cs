namespace ArtSite.Database.Entities; 

public class Trait : BaseNameEntity{
    public virtual ISet<Personality> Personalities { get; set; } = new HashSet<Personality>();

}