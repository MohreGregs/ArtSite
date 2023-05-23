using ReactiveUI;

namespace ArtSite.Data.Models.ReactiveModels; 

public class ReactiveAppearanceModel: ReactiveBaseModel {
    public string AppearanceInfo { get; set; }
    public string DesignNotes { get; set; }
    public HashSet<ColorModel> Colors { get; set; }

    public static ReactiveAppearanceModel FromAppearanceModel(AppearanceModel appearanceModel) {
        var model = new ReactiveAppearanceModel();
        model.Id = appearanceModel.Id;
        model.AppearanceInfo = appearanceModel.AppearanceInfo;
        model.DesignNotes = appearanceModel.DesignNotes;
        model.Colors = appearanceModel.Colors;
        return model;
    }
    
    public static AppearanceModel ToAppearanceModel(ReactiveAppearanceModel reactiveAppearance) {
        var model = new AppearanceModel();
        model.Id = reactiveAppearance.Id;
        model.AppearanceInfo = reactiveAppearance.AppearanceInfo;
        model.DesignNotes = reactiveAppearance.DesignNotes;
        model.Colors = reactiveAppearance.Colors;
        return model;
    }
}