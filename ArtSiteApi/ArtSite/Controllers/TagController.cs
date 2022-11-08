using ArtSite.Data.Models;
using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtSite.Controllers; 

public class TagController : BaseEntityController<TagController, Tag, TagModel, AddTagModel> {
    public TagController(ILogger<TagController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context) {
    }

    [HttpPost]
    [Route("add")]
    public override async Task<ActionResult> Add([FromBody] AddTagModel? model) {
        if (model == null)
            return BadRequest();

        var color = await _context.Colors.FirstOrDefaultAsync(x => x.Id == model.ColorId);

        var tag = new Tag {
            Name = model.Name,
            Color = color
        };

        await _context.AddAsync(tag);

        try {
            await _context.SaveChangesAsync();
        }
        catch (Exception ex) {
            Console.WriteLine(ex);

            return StatusCode(500, ex.ToString());
        }

        return Ok(tag);
    }
}