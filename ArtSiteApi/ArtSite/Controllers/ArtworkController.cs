using ArtSite.Data.Models;
using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtSite.Controllers;

public class ArtworkController : BaseEntityController<ArtworkController, Artwork, ArtworkModel, AddArtworkModel>
{
    public ArtworkController(ILogger<ArtworkController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context)
    {
    }
    
    [HttpPost]
    [Route("add")]
    public override async Task<ActionResult> Add([FromBody] AddArtworkModel? model) {
        if (model == null)
            return BadRequest();

        var artwork = new Artwork {
            Description = model.Description,
            File = model.FileData,
            Extension = model.FileExtension,
            NsfwRating = model.NsfwRating,
            GoreRating = model.GoreRating
        };

        foreach (var artistId in model.ArtistIds) {
            var artist = await _context.Artists.FirstOrDefaultAsync(x => x.Id == artistId);
            if (artist != default) artwork.Artists.Add(artist);
        }
        
        foreach (var characterId in model.CharacterIds) {
            var character = await _context.Characters.FirstOrDefaultAsync(x => x.Id == characterId);
            if (character != default) artwork.Characters.Add(character);
        }
        
        foreach (var tagId in model.TagIds) {
            var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == tagId);
            if (tag != default) artwork.Tags.Add(tag);
        }

        await _context.AddAsync(artwork);

        try {
            await _context.SaveChangesAsync();
        }
        catch (Exception ex) {
            Console.WriteLine(ex);

            return StatusCode(500, ex.ToString());
        }

        return Ok(artwork);
    }
}