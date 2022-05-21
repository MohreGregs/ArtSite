using ArtSite.Database;
using ArtSite.Database.Entities;
using ArtSite.Database.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtSite.Controllers; 

public class ArtworkController :BaseController<ArtworkController> {
    public ArtworkController(ILogger<ArtworkController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context) {
        if (!Directory.Exists("Artwork")) {
            Directory.CreateDirectory("Artwork");
        }
    }

    [HttpGet]
    public async Task<List<Artwork>> Get() {
        return await _context.Artworks.ToListAsync();
    }
    
    [HttpGet]
    public async Task<ActionResult<Artwork>> GetById(int id = 0) {
        if (id == default) {
            return BadRequest();
        }
        
        var artwork = await _context.Artworks.FirstOrDefaultAsync(x => x.Id == id);

        if (artwork == default) return NotFound();

        return Ok(artwork); 
    }
    
    [HttpPost]
    public async Task<ActionResult<Artwork>> Add([FromBody] AddArtworkModel? newArtwork) {
        if (newArtwork == default) {
            return BadRequest();
        }

        var artwork = _mapper.Map<Artwork>(newArtwork);
        
        await _context.AddAsync(artwork);

        await _context.SaveChangesAsync();

        return Ok(artwork);
    }
    
    [HttpPut]
    public async Task<ActionResult<Artwork>> Edit([FromBody] EditArtworkModel? artwork) {
        if (artwork == default) {
            return BadRequest();
        }

        var artworkToEdit = await _context.Artworks.FirstOrDefaultAsync(x => x.Id == artwork.Id);

        if (artworkToEdit == default) {
            return BadRequest();
        }

        artworkToEdit = _mapper.Map<Artwork>(artwork);

        await _context.SaveChangesAsync();

        return Ok(artworkToEdit);
    }
    
    [HttpDelete]
    public async Task<ActionResult> Delete(int id = 0) {
        if (id == default) {
            return BadRequest();
        }
        
        var artworkToDelete = await _context.Artworks.FirstOrDefaultAsync(x => x.Id == id);

        if (artworkToDelete == default) {
            return BadRequest();
        }
        
        _context.Remove(artworkToDelete);

        await _context.SaveChangesAsync();

        return Ok();
    }
}