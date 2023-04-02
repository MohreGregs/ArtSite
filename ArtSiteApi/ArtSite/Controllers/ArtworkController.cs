using ArtSite.Data.Models;
using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkiaSharp;

namespace ArtSite.Controllers;

public class ArtworkController : BaseEntityController<ArtworkController, Artwork, ArtworkModel, AddArtworkModel>
{
    public ArtworkController(ILogger<ArtworkController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context)
    {
    }
    
    [HttpGet]
    [Route("GetFileById")]
    public async Task<ActionResult<byte[]>?> GetFileById(int id) {
        var artwork = await _context.Artworks.FirstOrDefaultAsync(x => x.Id == id);

        if (artwork == default) return NotFound();

        var imageType = artwork.Extension.Substring(1);

        using var bitmap = SKBitmap.Decode(artwork.File);
        if (bitmap == null) return BadRequest();

        var ratio = Math.Max(bitmap.Width / 500d, bitmap.Height / 500d);

        ratio = Math.Max(ratio, 1d);

        using var scaledBitmap =
            bitmap.Resize(new SKImageInfo((int)(bitmap.Width / ratio), (int)(bitmap.Height / ratio)), SKFilterQuality.High);

        using var data = scaledBitmap.Encode(SKEncodedImageFormat.Png, 75);
        
        return File(data.ToArray(), $"image/png");
    }

    [HttpGet]
    [Route("GetByCharacterId")]
    public async Task<ActionResult<List<ArtworkModel>?>> GetByCharacterId(int characterId) {
        var character = await _context.Characters.FirstOrDefaultAsync(x => x.Id == characterId);
        if (character == default) return NotFound();

        var artworks =  _context.Artworks.Where(x => x.Characters.Contains(character)).ToList();

        return Ok(_mapper.Map<List<ArtworkModel>>(artworks));
    }
    
    [HttpGet]
    [Route("GetArtworkIdByCharacter")]
    public async Task<ActionResult<List<int>?>> GetArtworkIdByCharacter(int characterId) {
        var character = await _context.Characters.FirstOrDefaultAsync(x => x.Id == characterId);
        if (character == default) return NotFound();

        var artworks =  _context.Artworks.Where(x => x.Characters.Contains(character)).ToList();

        return Ok(artworks.Select(x => x.Id));
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