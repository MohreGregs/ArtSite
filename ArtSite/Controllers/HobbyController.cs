using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;

namespace ArtSite.Controllers;

public class HobbyController : BaseController<HobbyController, Hobby>
{
    public HobbyController(ILogger<HobbyController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context)
    {
    }
}