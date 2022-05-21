using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;

namespace ArtSite.Controllers;

public class CharacterController : BaseController<CharacterController, Character> {
    public CharacterController(ILogger<CharacterController> logger, IMapper mapper, DatabaseContext context) : base(
        logger, mapper, context) {
    }
}