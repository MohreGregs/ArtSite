namespace ArtSite.Data.Models; 

public class TagModel : BaseNameModel{
    public ColorModel Color { get; set; }
    public HashSet<CharacterModel> Characters { get; set; }
}