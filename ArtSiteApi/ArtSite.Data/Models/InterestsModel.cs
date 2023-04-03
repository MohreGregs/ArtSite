namespace ArtSite.Data.Models; 

public class InterestsModel: BaseModel {
    public string Hobbies { get; set; }
    public HashSet<SongModel> Music { get; set; }
}