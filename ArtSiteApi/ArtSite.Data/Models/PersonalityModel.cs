namespace ArtSite.Data.Models; 

public class PersonalityModel: BaseModel {
    public byte[]? PersonalityInfo { get; set; }
    public byte[]? Traits { get; set; }
    public byte[]? Flaws { get; set; }
    public byte Introverted { get; set; }
    public byte Intuitive { get; set; }
    public byte Thinking { get; set; }
    public byte Judging { get; set; }
    public byte Assertive { get; set; }
}