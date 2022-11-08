using ArtSite.Data.Models;
using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;

namespace ArtSite.Controllers; 

public class SpeciesController : BaseEntityController<SpeciesController, Species, SpeciesModel, BaseNameModel> {
    public SpeciesController(ILogger<SpeciesController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context) {
    }
}