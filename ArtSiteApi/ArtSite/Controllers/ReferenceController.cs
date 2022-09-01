using ArtSite.Data.Models;
using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;

namespace ArtSite.Controllers; 

public class ReferenceController : BaseEntityController<ReferenceController, Reference, ReferenceModel, ReferenceModel> {
    public ReferenceController(ILogger<ReferenceController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context) {
    }
}