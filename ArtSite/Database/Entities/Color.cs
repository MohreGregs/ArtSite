namespace ArtSite.Database.Entities; 

public class Color : BaseNameEntity{
    public string ColorCode { get; set; }

    public virtual ISet<Appearance> Appearances { get; set; } = new HashSet<Appearance>();
    public virtual ISet<Tag> Tags { get; set; } = new HashSet<Tag>();
}