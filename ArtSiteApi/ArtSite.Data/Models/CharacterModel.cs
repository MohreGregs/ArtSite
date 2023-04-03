using ArtSite.Data.Enums;
using ReactiveUI;

namespace ArtSite.Data.Models; 

public class CharacterModel : BaseNameModel {
    public byte Age { get; set; }
    public Gender Gender { get; set; }
    public Sexuality Sexuality { get; set; }
    public int? IconId { get; set; }
    public string WantedArtwork { get; set; }
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
}