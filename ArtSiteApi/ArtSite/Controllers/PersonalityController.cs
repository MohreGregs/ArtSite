using ArtSite.Data.Models;
using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;

namespace ArtSite.Controllers; 

public class PersonalityController : BaseEntityController<PersonalityController, Personality, PersonalityModel, PersonalityModel> {
    public PersonalityController(ILogger<PersonalityController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context) {
    }
}