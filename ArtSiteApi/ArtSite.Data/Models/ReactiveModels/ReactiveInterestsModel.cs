namespace ArtSite.Data.Models.ReactiveModels; 

public class ReactiveInterestsModel: ReactiveBaseModel {
    public string Hobbies { get; set; }
    public HashSet<SongModel> Music { get; set; }

    public static ReactiveInterestsModel FromInterestModel(InterestsModel interestsModel) {
        var model = new ReactiveInterestsModel();
        model.Id = interestsModel.Id;
        model.Hobbies = interestsModel.Hobbies;
        model.Music = interestsModel.Music;
        return model;
    }
    
    public static InterestsModel ToInterestModel(ReactiveInterestsModel reactiveInterestsModel) {
        var model = new InterestsModel();
        model.Id = reactiveInterestsModel.Id;
        model.Hobbies = reactiveInterestsModel.Hobbies;
        model.Music = reactiveInterestsModel.Music;
        return model;
    }
}