namespace ArtSite.Database.Entities; 

public class BaseEntity {
    public int Id { get; set; }
    public DateTimeOffset CreationTime { get; set; } = DateTime.UtcNow;
    
}