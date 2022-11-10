using ArtSite.Data.Enums;

namespace ArtSite.Data.Models; 

public class AddCharacterModel: BaseNameModel {
    public byte Age { get; set; }
    public Sexuality Sexuality { get; set; }
    public Gender Gender { get; set; }
    public int OriginalDesignerId { get; set; }
    public List<int> TagIds { get; set; }
    public int SpeciesId { get; set; }
}