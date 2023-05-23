using ReactiveUI;

namespace ArtSite.Data.Models.ReactiveModels; 

public class ReactiveBaseModel: ReactiveObject {
    public int? Id { get; set; }
}