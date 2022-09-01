using ArtSite.Data.Models;
using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;

namespace ArtSite.Controllers;

public class TraitController : BaseEntityController<TraitController, Trait, BaseNameModel, BaseNameModel>
{
    public TraitController(ILogger<TraitController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context)
    {
    }
}