using ArtSite.Data.Models;
using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtSite.Controllers; 

public class GeneralInfoController : BaseEntityController<GeneralInfoController, GeneralInfo, GeneralInfoModel, GeneralInfoModel> {
    public GeneralInfoController(ILogger<GeneralInfoController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context) {
    }
    
    [HttpPut]
    [Route("edit")]
    public override async Task<ActionResult<GeneralInfoModel>> Edit([FromBody] GeneralInfoModel? model) {
        if (model?.Id == default) return BadRequest();

        var objToEdit = await _context.GeneralInfos.FirstOrDefaultAsync(x => x.Id == model.Id);

        if (objToEdit == default) return BadRequest();

        objToEdit.Info = model.Info;
        objToEdit.Likes = model.Likes;
        objToEdit.Dislikes = model.Dislikes;
        objToEdit.Trivia = model.Trivia;

        await _context.SaveChangesAsync();

        return Ok(_mapper.Map<GeneralInfoModel>(objToEdit));
    }
}