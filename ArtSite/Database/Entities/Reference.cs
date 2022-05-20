namespace ArtSite.Database.Entities; 

public class Reference : BaseNameEntity{
    public virtual Character Character { get; set; }
    public int ArtworkId { get; set; }
    public virtual Artwork Artwork { get; set; }
}