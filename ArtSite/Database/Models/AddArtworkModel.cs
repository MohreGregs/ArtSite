using ArtSite.Database.Entities;
using ArtSite.Enums;

namespace ArtSite.Database.Models; 

public class AddArtworkModel {
    public byte[] Description { get; set; }
    public string FileExtension { get; set; }
    public byte[] FileData { get; set; }
    public Rating Rating { get; set; }

    public HashSet<Artist> Artists { get; set; }
}