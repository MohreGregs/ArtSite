using ArtSite.Database;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtSite.Controllers; 

public class DebugController : BaseController<DebugController> {
    public DebugController(ILogger<DebugController> logger, IMapper mapper, DatabaseContext context) : base(logger, mapper, context) {
    }

    [HttpPost]
    [Route("DBNavigationTabels")]
    public async Task<dynamic> DBNavigationTabels() {
        try {
            var artwork = await _context.Artworks.FirstOrDefaultAsync();
            var artist = await _context.Artists.FirstOrDefaultAsync();
        
            var species = await _context.Species.FirstOrDefaultAsync();
            var character = await _context.Characters.FirstOrDefaultAsync();
            var tag = await _context.Tags.FirstOrDefaultAsync();
            var color = await _context.Colors.FirstOrDefaultAsync();
            var reference = await _context.References.FirstOrDefaultAsync();

            var interests = await _context.InterestsSet.FirstOrDefaultAsync();
            var hobby = await _context.Hobbies.FirstOrDefaultAsync();
            var song = await _context.Songs.FirstOrDefaultAsync();
        
            artwork.Artists.Add(artist);

            color.Tags.Add(tag);

            character.Appearance.Colors.Add(color);
            character.References.Add(reference);

            species.Characters.Add(character);
            character.Tags.Add(tag);

            interests.Hobbies.Add(hobby);
            interests.Music.Add(song);
            
            return await _context.SaveChangesAsync();
        }
        catch (Exception e) {
            return e;
        }
    }
}