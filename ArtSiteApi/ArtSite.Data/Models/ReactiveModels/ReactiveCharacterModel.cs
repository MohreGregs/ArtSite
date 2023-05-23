using ArtSite.Data.Enums;
using ReactiveUI;

namespace ArtSite.Data.Models.ReactiveModels; 

public class ReactiveCharacterModel: ReactiveBaseModel {
    public String Name { get; set; }
    public byte Age { get; set; }
    public Gender Gender { get; set; }
    public Sexuality Sexuality { get; set; }
    public int? IconId { get; set; }
    public string? WantedArtwork { get; set; }
    public ArtworkModel? Icon { get; set; }
    public HashSet<TagModel> Tags { get; set; }
    public SpeciesModel Species { get; set; }
    public ArtistModel OriginalDesigner { get; set; }
    public HashSet<ReactiveReferenceModel> References { get; set; }
    public ReactiveGeneralInfoModel GeneralInfo { get; set; }
    public ReactivePersonalityModel Personality { get; set; }
    public ReactiveInterestsModel Interests { get; set; }
    public ReactiveAppearanceModel Appearance { get; set; }
    
    public override string ToString() => Name;

    public static ReactiveCharacterModel FromCharacterModel(CharacterModel character) {
        var references = new HashSet<ReactiveReferenceModel>();
        foreach (var characterReference in character.References) {
            references.Add(ReactiveReferenceModel.FromReferenceModel(characterReference));
        }
        var model = new ReactiveCharacterModel();
        model.Id = character.Id;
        model.Name = character.Name;
        model.Age = character.Age;
        model.Gender = character.Gender;
        model.Sexuality = character.Sexuality;
        model.IconId = character.IconId;
        model.WantedArtwork = character.WantedArtwork;
        model.Tags = character.Tags;
        model.Species = character.Species;
        model.OriginalDesigner = character.OriginalDesigner;
        model.References = references;
        model.GeneralInfo = ReactiveGeneralInfoModel.FromGeneralInfoModel(character.GeneralInfo);
        model.Personality = ReactivePersonalityModel.FromPersonalityModel(character.Personality);
        model.Interests = ReactiveInterestsModel.FromInterestModel(character.Interests);
        model.Appearance = ReactiveAppearanceModel.FromAppearanceModel(character.Appearance);
        return model;
    }
    
    public static CharacterModel ToCharacterModel(ReactiveCharacterModel character) {
        var references = new HashSet<ReferenceModel>();
        foreach (var characterReference in character.References) {
            references.Add(ReactiveReferenceModel.ToReferenceModel(characterReference));
        }
        var model = new CharacterModel();
        model.Id = character.Id;
        model.Name = character.Name;
        model.Age = character.Age;
        model.Gender = character.Gender;
        model.Sexuality = character.Sexuality;
        model.IconId = character.IconId;
        model.WantedArtwork = character.WantedArtwork;
        model.Tags = character.Tags;
        model.Species = character.Species;
        model.OriginalDesigner = character.OriginalDesigner;
        model.References = references;
        model.GeneralInfo = ReactiveGeneralInfoModel.ToGeneralInfoModel(character.GeneralInfo);
        model.Personality = ReactivePersonalityModel.ToPersonalityModel(character.Personality);
        model.Interests = ReactiveInterestsModel.ToInterestModel(character.Interests);
        model.Appearance = ReactiveAppearanceModel.ToAppearanceModel(character.Appearance);
        return model;
    }
}