using ArtSite.Data.Models;
using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;

namespace ArtSite.Controllers; 

public class FlawController : BaseEntityController<FlawController, Flaw, BaseNameModel, BaseNameModel> {
    public FlawController(ILogger<FlawController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context) {
    }
}