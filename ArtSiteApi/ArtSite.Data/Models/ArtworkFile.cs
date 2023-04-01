using Avalonia.Media.Imaging;

namespace ArtSite.Data.Models; 

public class ArtworkFile {
    public int Id { get; set; }
    public Bitmap File { get; set; }

    public ArtworkFile(int id, Bitmap file) {
        Id = id;
        File = file;
    }
}