namespace ArtSite.Data.Models; 

public class SpeciesModel : BaseNameModel{
    public HashSet<CharacterModel> Characters { get; set; }

    public override string ToString() => Name;
}