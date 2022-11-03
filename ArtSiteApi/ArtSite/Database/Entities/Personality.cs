namespace ArtSite.Database.Entities; 

public class Personality : BaseEntity {
    public byte[]? PersonalityInfo { get; set; }
    public byte[]? Traits { get; set; }
    public byte[]? Flaws { get; set; }
    public byte Introverted { get; set; }
    public byte Intuitiv { get; set; }
    public byte Thinking { get; set; }
    public byte Judging { get; set; }
    public byte Assertive { get; set; }
    
    public virtual Character Character { get; set; }
}