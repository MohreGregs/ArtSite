namespace ArtSite.Data.Models; 

public class PersonalityModel: BaseModel {
    public string PersonalityInfo { get; set; }
    public string Traits { get; set; }
    public string Flaws { get; set; }
    public byte Introverted { get; set; }
    public byte Intuitive { get; set; }
    public byte Thinking { get; set; }
    public byte Judging { get; set; }
    public byte Assertive { get; set; }
}