namespace ArtSite.Data.Models; 

public class SetIconModel {
    public int CharacterId { get; set; }
    public int ArtworkId { get; set; }

    public SetIconModel(int characterId, int artworkId) {
        CharacterId = characterId;
        ArtworkId = artworkId;
    }
}