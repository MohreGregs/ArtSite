using ArtSite.Data.Enums;
using ReactiveUI;

namespace ArtSite.Data.Models; 

public class AddArtworkModel : BaseModel{
    private byte[] FileData { get; set; }
    public byte[] Description { get; set; }
    public string FileExtension { get; set; }

    public Rating Rating { get; set; }

    public List<ArtistModel> Artists { get; set; } = new List<ArtistModel>();
}