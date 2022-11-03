using ArtSite.Data.Enums;
using ReactiveUI;

namespace ArtSite.Data.Models; 

public class AddArtworkModel : BaseModel{
    private byte[] _fileData;
    public byte[] Description { get; set; }
    public string FileExtension { get; set; }

    public byte[] FileData {
        get => _fileData;
        set =>  this.RaiseAndSetIfChanged(ref _fileData, value);
    }

    public Rating Rating { get; set; }

    public HashSet<ArtistModel> Artists { get; set; }
}