namespace ArtSite.Database.Entities; 

public class Appearance : BaseEntity {
    public string AppearanceInfo { get; set; } = "";
    public string DesignNotes { get; set; } = "";

    public virtual ISet<Color> Colors { get; set; } = new HashSet<Color>();
    
    public virtual Character Character { get; set; }
}