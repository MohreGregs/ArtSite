
namespace ArtSite.Data.Models; 

public class AppearanceModel : BaseModel {
    public string AppearanceInfo { get; set; }
    public string DesignNotes { get; set; }
    public HashSet<ColorModel> Colors { get; set; }
}