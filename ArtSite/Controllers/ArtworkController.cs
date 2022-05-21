using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtSite.Controllers;

public class ArtworkController : BaseController<ArtworkController, Artwork>
{
    public ArtworkController(ILogger<ArtworkController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context)
    {
    }
}