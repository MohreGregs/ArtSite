using ArtSite.Data.Models;
using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;

namespace ArtSite.Controllers; 

public class ArtistController : BaseEntityController<ArtistController, Artist, ArtistModel, ArtistModel> {
    public ArtistController(ILogger<ArtistController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context) {
    }
}