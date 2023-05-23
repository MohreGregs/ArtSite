namespace ArtSite.Data.Models.ReactiveModels; 

public class ReactiveGeneralInfoModel: ReactiveBaseModel {
    public string Info { get; set; }
    public string Trivia { get; set; }
    public string Likes { get; set; }
    public string Dislikes { get; set; }

    public static ReactiveGeneralInfoModel FromGeneralInfoModel(GeneralInfoModel generalInfoModel) {
        var model = new ReactiveGeneralInfoModel();
        model.Id = generalInfoModel.Id;
        model.Info = generalInfoModel.Info;
        model.Trivia = generalInfoModel.Trivia;
        model.Likes = generalInfoModel.Likes;
        model.Dislikes = generalInfoModel.Dislikes;
        return model;
    }

    public static GeneralInfoModel ToGeneralInfoModel(ReactiveGeneralInfoModel reactiveGeneralInfoModel) {
        var model = new GeneralInfoModel();
        model.Id = reactiveGeneralInfoModel.Id;
        model.Info = reactiveGeneralInfoModel.Info;
        model.Trivia = reactiveGeneralInfoModel.Trivia;
        model.Likes = reactiveGeneralInfoModel.Likes;
        model.Dislikes = reactiveGeneralInfoModel.Dislikes;
        return model;
    }
}