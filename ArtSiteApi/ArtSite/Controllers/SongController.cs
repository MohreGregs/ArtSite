using ArtSite.Data.Models;
using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;

namespace ArtSite.Controllers; 

public class SongController : BaseEntityController<SongController, Song, SongModel, SongModel> {
    public SongController(ILogger<SongController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context) {
    }
}