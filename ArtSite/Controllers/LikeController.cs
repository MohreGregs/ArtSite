using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;

namespace ArtSite.Controllers;

public class LikeController : BaseController<LikeController, Like>
{
    public LikeController(ILogger<LikeController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context)
    {
    }
}