namespace ArtSite.Data.Models;

public class ColorModel :BaseNameModel{
    public string ColorCode { get; set; }
    
    public override string ToString() => Name;
};