using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;

namespace ArtSite.Controllers;

public class TraitController : BaseController<TraitController, Trait>
{
    public TraitController(ILogger<TraitController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context)
    {
    }
}