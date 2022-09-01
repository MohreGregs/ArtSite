using ArtSite.Data.Models;
using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;

namespace ArtSite.Controllers; 

public class InterestsController : BaseEntityController<InterestsController, Interests, InterestsModel, InterestsModel> {
    public InterestsController(ILogger<InterestsController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context) {
    }
}