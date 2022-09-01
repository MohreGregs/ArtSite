using ArtSite.Data.Models;
using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;

namespace ArtSite.Controllers; 

public class TagController : BaseEntityController<TagController, Tag, TagModel, TagModel> {
    public TagController(ILogger<TagController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context) {
    }
}