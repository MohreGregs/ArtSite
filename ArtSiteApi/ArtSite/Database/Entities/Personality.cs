namespace ArtSite.Database.Entities; 

public class Personality : BaseEntity {
    public string PersonalityInfo { get; set; }= "";
    public string Traits { get; set; }= "";
    public string Flaws { get; set; }= "";
    public byte Introverted { get; set; }
    public byte Intuitiv { get; set; }
    public byte Thinking { get; set; }
    public byte Judging { get; set; }
    public byte Assertive { get; set; }
    
    public virtual Character Character { get; set; }
}