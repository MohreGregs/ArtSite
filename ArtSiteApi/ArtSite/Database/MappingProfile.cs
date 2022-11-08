using ArtSite.Data.Models;
using ArtSite.Database.Entities;
using AutoMapper;

namespace ArtSite.Database; 

public class MappingProfile : Profile{
    public MappingProfile() {
        CreateMap<Character, CharacterModel>();
        CreateMap<GeneralInfo, GeneralInfoModel>();
        CreateMap<Appearance, AppearanceModel>();
        CreateMap<Artist, ArtistModel>();
        CreateMap<Artwork, ArtworkModel>();
        CreateMap<Color, ColorModel>();
        CreateMap<Hobby, BaseNameModel>();
        CreateMap<Interests, InterestsModel>();
        CreateMap<Personality, PersonalityModel>();
        CreateMap<Reference, ReferenceModel>();
        CreateMap<Song, SongModel>();
        CreateMap<Species, SpeciesModel>();
        CreateMap<Tag, TagModel>();
        
        CreateMap<AddCharacterModel, Character>();
        CreateMap<AddCharacterModel, Character>();
        CreateMap<AddArtworkModel, Artwork>();
        CreateMap<BaseNameModel, Species>();
        CreateMap<EditArtworkModel, Artwork>();
        CreateMap<AppearanceModel, Appearance>();
        CreateMap<ArtistModel, Artist>();
        CreateMap<ArtworkModel, Artwork>();
        CreateMap<CharacterModel, Character>();
        CreateMap<ColorModel, Color>();
        CreateMap<GeneralInfoModel, GeneralInfo>();
        CreateMap<BaseNameEntity, Hobby>();
        CreateMap<InterestsModel, Interests>();
        CreateMap<PersonalityModel, Personality>();
        CreateMap<ReferenceModel, Reference>();
        CreateMap<SongModel, Song>();
        CreateMap<SpeciesModel, Species>();
        CreateMap<TagModel, Tag>();
    }
}