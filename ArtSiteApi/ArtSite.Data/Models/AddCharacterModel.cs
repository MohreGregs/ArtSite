using ArtSite.Data.Enums;

namespace ArtSite.Data.Models; 

public class AddCharacterModel: BaseNameModel {
    public byte Age { get; set; }
    public Sexuality Sexuality { get; set; }
    public Gender Gender { get; set; }
    public ArtistModel OriginalDesigner { get; set; }
    public ISet<TagModel> Tags { get; set; }
    public SpeciesModel Species { get; set; }
}