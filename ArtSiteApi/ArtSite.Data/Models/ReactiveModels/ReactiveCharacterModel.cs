using ArtSite.Data.Enums;
using ReactiveUI;

namespace ArtSite.Data.Models.ReactiveModels; 

public class ReactiveCharacterModel: ReactiveObject {
    public int? Id { get; set; }
    public String Name { get; set; }
    public byte Age { get; set; }
    public Gender Gender { get; set; }
    public Sexuality Sexuality { get; set; }
    public int? IconId { get; set; }
    public byte[]? WantedArtwork { get; set; }
    public ArtworkModel? Icon { get; set; }
    public HashSet<TagModel> Tags { get; set; }
    public SpeciesModel Species { get; set; }
    public ArtistModel OriginalDesigner { get; set; }
    public HashSet<ReferenceModel> References { get; set; }
    public GeneralInfoModel GeneralInfo { get; set; }
    public PersonalityModel Personality { get; set; }
    public InterestsModel Interests { get; set; }
    public AppearanceModel Appearance { get; set; }
    
    public override string ToString() => Name;

    public static ReactiveCharacterModel fromCharacterModel(CharacterModel character) {
        var model = new ReactiveCharacterModel();
        model.Id = character.Id;
        model.Name = character.Name;
        model.Age = character.Age;
        model.Gender = character.Gender;
        model.Sexuality = character.Sexuality;
        model.IconId = character.IconId;
        model.WantedArtwork = character.WantedArtwork;
        model.Species = character.Species;
        model.OriginalDesigner = character.OriginalDesigner;
        return model;
    }
}