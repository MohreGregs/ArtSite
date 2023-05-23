namespace ArtSite.Data.Models; 

public class EditCharacterModel: BaseModel {
    public GeneralInfoModel GeneralInfo { get; set; }
    public PersonalityModel Personality { get; set; }
    public InterestsModel Interests { get; set; }
    public AppearanceModel Appearance { get; set; }
}