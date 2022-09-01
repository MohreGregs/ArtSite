namespace ArtSite.Database.Entities; 

public class BaseEntity {
    public int Id { get; set; }
    public DateTimeOffset CreationTime { get; set; } = DateTime.UtcNow;

    public static bool operator ==(BaseEntity? left, BaseEntity? right) {
        return left?.Id == right?.Id;
    }

    public static bool operator !=(BaseEntity? left, BaseEntity? right) {
        return left?.Id != right?.Id;
    }
}