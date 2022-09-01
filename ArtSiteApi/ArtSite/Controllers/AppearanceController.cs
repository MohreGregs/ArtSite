using ArtSite.Data.Models;
using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;

namespace ArtSite.Controllers; 

public class AppearanceController : BaseEntityController<AppearanceController, Appearance, AppearanceModel, AppearanceModel> {
    public AppearanceController(ILogger<AppearanceController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context) {
    }
}