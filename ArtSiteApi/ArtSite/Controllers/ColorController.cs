using ArtSite.Data.Models;
using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;

namespace ArtSite.Controllers; 

public class ColorController : BaseEntityController<ColorController, Color, ColorModel, ColorModel> {
    public ColorController(ILogger<ColorController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context) {
    }
}