using ArtSite.Data.Models;
using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;

namespace ArtSite.Controllers;

public class HobbyController : BaseEntityController<HobbyController, Hobby, BaseNameModel, BaseNameModel>
{
    public HobbyController(ILogger<HobbyController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context)
    {
    }
}