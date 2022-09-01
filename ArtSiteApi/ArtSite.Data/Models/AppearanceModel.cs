
namespace ArtSite.Data.Models; 

public class AppearanceModel : BaseModel {
    public byte[] AppearanceInfo { get; set; }
    public byte[] DesignNotes { get; set; }
    public HashSet<ColorModel> Colors { get; set; }
}