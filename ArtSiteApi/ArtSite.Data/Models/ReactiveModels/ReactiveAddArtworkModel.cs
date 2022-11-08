using ArtSite.Data.Enums;
using ReactiveUI;

namespace ArtSite.Data.Models.ReactiveModels; 

public class ReactiveAddArtworkModel: ReactiveObject{
    public int? Id { get; set; }
    private byte[] _fileData;
    public byte[] Description { get; set; }
    public string FileExtension { get; set; }

    public byte[] FileData {
        get => _fileData;
        set =>  this.RaiseAndSetIfChanged(ref _fileData, value);
    }

    public Rating Rating { get; set; }

    public List<ArtistModel> Artists { get; set; } = new List<ArtistModel>();
}