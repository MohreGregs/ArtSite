namespace ArtSite.Database.Entities; 

public class Appearance : BaseEntity{
    public byte[] AppearanceInfo { get; set; }
    public byte[] DesignNotes { get; set; }

    public virtual ISet<Color> Colors { get; set; } = new HashSet<Color>();
    
    public virtual Character Character { get; set; }
}