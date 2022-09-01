namespace ArtSite.Data.Models; 

public class GeneralInfoModel : BaseModel {
    public byte[] Info { get; set; }
    public byte[] Trivia { get; set; }
    public HashSet<BaseNameModel> Likes { get; set; }
    public HashSet<BaseNameModel> Dislikes { get; set; }
}