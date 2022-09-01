using ArtSite.Data.Models;
using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;

namespace ArtSite.Controllers;

public class LikeController : BaseEntityController<LikeController, Like, BaseNameModel, BaseNameModel>
{
    public LikeController(ILogger<LikeController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context)
    {
    }
}