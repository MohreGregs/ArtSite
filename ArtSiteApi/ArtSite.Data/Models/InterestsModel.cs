namespace ArtSite.Data.Models; 

public class InterestsModel: BaseModel {
    public byte[]? Hobbies { get; set; }
    public HashSet<SongModel> Music { get; set; }
}