namespace ArtSite.Data.Models; 

public class GeneralInfoModel : BaseModel {
    public byte[]? Info { get; set; }
    public byte[]? Trivia { get; set; }
    public byte[]? Likes { get; set; }
    public byte[]? Dislikes { get; set; }
}