namespace ArtSite.Data.Models.ReactiveModels; 

public class ReactiveReferenceModel: ReactiveBaseModel {
    public ArtworkModel Artwork { get; set; }

    public static ReactiveReferenceModel FromReferenceModel(ReferenceModel reference) {
        var model = new ReactiveReferenceModel();
        model.Id = reference.Id;
        model.Artwork = reference.Artwork;
        return model;
    }
    
    public static ReferenceModel ToReferenceModel(ReactiveReferenceModel reactiveReference) {
        var model = new ReferenceModel();
        model.Id = reactiveReference.Id;
        model.Artwork = reactiveReference.Artwork;
        return model;
    }
}