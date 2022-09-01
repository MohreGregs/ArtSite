namespace ArtSite.Data.Models; 

public class InterestsModel: BaseModel {
    public HashSet<BaseNameModel> Hobbies { get; set; }
    public HashSet<SongModel> Music { get; set; }
}