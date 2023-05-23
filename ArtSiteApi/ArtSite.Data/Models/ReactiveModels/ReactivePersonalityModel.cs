namespace ArtSite.Data.Models.ReactiveModels; 

public class ReactivePersonalityModel: ReactiveBaseModel {
    public string PersonalityInfo { get; set; }
    public string Traits { get; set; }
    public string Flaws { get; set; }
    public byte Introverted { get; set; }
    public byte Intuitive { get; set; }
    public byte Thinking { get; set; }
    public byte Judging { get; set; }
    public byte Assertive { get; set; }

    public static ReactivePersonalityModel FromPersonalityModel(PersonalityModel personalityModel) {
        var model = new ReactivePersonalityModel();
        model.Id = personalityModel.Id;
        model.PersonalityInfo = personalityModel.PersonalityInfo;
        model.Traits = personalityModel.Traits;
        model.Flaws = personalityModel.Flaws;
        model.Introverted = personalityModel.Introverted;
        model.Intuitive = personalityModel.Intuitive;
        model.Thinking = personalityModel.Thinking;
        model.Judging = personalityModel.Judging;
        model.Assertive = personalityModel.Assertive;
        return model;
    }
    
    public static PersonalityModel ToPersonalityModel(ReactivePersonalityModel reactivePersonality) {
        var model = new PersonalityModel();
        model.Id = reactivePersonality.Id;
        model.PersonalityInfo = reactivePersonality.PersonalityInfo;
        model.Traits = reactivePersonality.Traits;
        model.Flaws = reactivePersonality.Flaws;
        model.Introverted = reactivePersonality.Introverted;
        model.Intuitive = reactivePersonality.Intuitive;
        model.Thinking = reactivePersonality.Thinking;
        model.Judging = reactivePersonality.Judging;
        model.Assertive = reactivePersonality.Assertive;
        return model;
    }
}