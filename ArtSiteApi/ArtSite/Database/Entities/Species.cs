namespace ArtSite.Database.Entities; 

public class Species : BaseNameEntity {
    public virtual ISet<Character> Characters { get; set; } = new HashSet<Character>();
}