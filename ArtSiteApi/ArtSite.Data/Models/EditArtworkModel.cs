using ArtSite.Data.Enums;

namespace ArtSite.Data.Models; 

public class EditArtworkModel : BaseModel {
    public byte[] Description { get; set; }
    public byte[] FileData { get; set; }
    public string FileExtension { get; set; }
    public Rating Rating { get; set; }

    public HashSet<ArtistModel> Artists { get; set; }
    public HashSet<CharacterModel> Characters { get; set; }
}