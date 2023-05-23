using ArtSite.Data.Enums;

namespace ArtSite.Data.Models; 

public class AddCharacterModel: BaseNameModel {
    public byte Age { get; set; }
    public Sexuality Sexuality { get; set; }
    public Gender Gender { get; set; }
    public string? WantedArtwork { get; set; }
    public int OriginalDesignerId { get; set; }
    public List<int> TagIds { get; set; } = new List<int>();
    public int SpeciesId { get; set; }

    public AddCharacterModel(){}
    
    public AddCharacterModel(string name, byte age, Sexuality sexuality, Gender gender, string wantedArtwork, int originalDesignerId, List<int> tagIds, int speciesId): base(name) {
        Age = age;
        Sexuality = sexuality;
        Gender = gender;
        WantedArtwork = wantedArtwork;
        OriginalDesignerId = originalDesignerId;
        TagIds = tagIds;
        SpeciesId = speciesId;
    }
}