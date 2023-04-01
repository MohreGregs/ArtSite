namespace ArtSite.Data.Models;

public class BaseNameModel : BaseModel {
    public string Name { get; set; } = "";

    public BaseNameModel(){}
    
    public BaseNameModel(string name) {
        Name = name;
    }
};