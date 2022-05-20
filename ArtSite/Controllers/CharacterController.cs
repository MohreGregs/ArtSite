using ArtSite.Database;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtSite.Controllers; 

public class CharacterController :BaseController<CharacterController> {
    public CharacterController(ILogger<CharacterController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context) {}

    [HttpGet]
    public int Get()
    {
        return 1;
    }
}