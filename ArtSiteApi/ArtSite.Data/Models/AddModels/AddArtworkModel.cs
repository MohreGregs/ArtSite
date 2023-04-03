using ArtSite.Data.Enums;
using ReactiveUI;

namespace ArtSite.Data.Models; 

public class AddArtworkModel : BaseModel{
    public byte[] FileData { get; set; }
    public string Description { get; set; }
    public string FileExtension { get; set; }

    public NSFWRating NsfwRating { get; set; }
    public GoreRating GoreRating { get; set; }

    public List<int> ArtistIds { get; set; } = new List<int>();
    public List<int> CharacterIds { get; set; } = new List<int>();
    public List<int> TagIds { get; set; } = new List<int>();
}