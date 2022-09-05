namespace ArtSite.Data.Models; 

public class PersonalityModel: BaseModel {
    public byte[]? PersonalityInfo { get; set; }
    public byte Introverted { get; set; }
    public byte Intuitiv { get; set; }
    public byte Thinking { get; set; }
    public byte Judging { get; set; }
    public byte Assertive { get; set; }
    public HashSet<BaseNameModel> Traits { get; set; }
    public HashSet<BaseNameModel> Flaws { get; set; }
}