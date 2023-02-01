using ArtSite.Data.Enums;

namespace ArtSite.Data.Models;

public class ArtworkModel : BaseModel{
    public byte[] Description { get; set; }
    public byte[] File { get; set; }
    public string Extension { get; set; }
    public NSFWRating NsfwRating { get; set; }
    public GoreRating GoreRating { get; set; }
    public HashSet<ArtistModel> Artists { get; set; }
    public HashSet<CharacterModel> Characters { get; set; }
    public HashSet<TagModel> Tags { get; set; }
};