using ArtSite.Data.Models;
using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;

namespace ArtSite.Controllers;

public class ArtworkController : BaseEntityController<ArtworkController, Artwork, ArtistModel, AddArtworkModel>
{
    public ArtworkController(ILogger<ArtworkController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context)
    {
    }
}