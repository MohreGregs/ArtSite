using ArtSite.Data.Enums;

namespace ArtSite.Data.Models; 

public class SearchObject {
    public String? NameString { get; set; }
    public int? Species { get; set; }
    public Dictionary<int, bool>? Tags { get; set; }
    public int? MinAge { get; set; }
    public int? MaxAge { get; set; }
    public Gender? Gender { get; set; }
    public Sexuality? Sexuality { get; set; }
}