using ArtSite.Data.Models;
using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;

namespace ArtSite.Controllers; 

public class GeneralInfoController : BaseEntityController<GeneralInfoController, GeneralInfo, GeneralInfoModel, GeneralInfoModel> {
    public GeneralInfoController(ILogger<GeneralInfoController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context) {
    }
}