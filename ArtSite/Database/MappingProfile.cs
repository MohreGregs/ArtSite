using ArtSite.Database.Entities;
using ArtSite.Database.Models;
using AutoMapper;

namespace ArtSite.Database; 

public class MappingProfile : Profile{
    public MappingProfile() {
        CreateMap<AddCharacterNameModel, Character>();
        CreateMap<BaseNameModel, Trait>();
        CreateMap<AddCharacterModel, Character>();
        CreateMap<AddArtworkModel, Artwork>();
        CreateMap<EditArtworkModel, Artwork>();
    }
}