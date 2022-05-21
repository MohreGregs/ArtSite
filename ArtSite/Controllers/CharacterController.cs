using ArtSite.Database;
using ArtSite.Database.Entities;
using ArtSite.Database.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtSite.Controllers;

public class CharacterController : BaseController<CharacterController> {
    public CharacterController(ILogger<CharacterController> logger, IMapper mapper, DatabaseContext context) : base(
        logger, mapper, context) {
    }

    [HttpGet]
    public async Task<List<Character>> Get() {
        return await _context.Characters.ToListAsync();
    }

    [HttpGet]
    public async Task<ActionResult<Character>> GetById(int id = 0) {
        if (id == default) {
            return BadRequest();
        }
        
        var character = await _context.Characters.FirstOrDefaultAsync(x => x.Id == id);

        if (character == default) return NotFound();

        return Ok(character); 
    }

    [HttpPost]
    public async Task<ActionResult<Character>> Add([FromBody] AddCharacterModel? newCharacter) {
        if (newCharacter == default) {
            return BadRequest();
        }

        var character = _mapper.Map<Character>(newCharacter);

        await _context.AddAsync(character);

        await _context.SaveChangesAsync();

        return Ok(character);
    }
    
    [HttpPut]
    public async Task<ActionResult<Character>> Edit([FromBody] Character? character) {
        if (character == default) {
            return BadRequest();
        }

        var characterToEdit = await _context.Characters.FirstOrDefaultAsync(x => x == character);

        if (characterToEdit == default) {
            return BadRequest();
        }

        characterToEdit = character;

        await _context.SaveChangesAsync();

        return Ok(characterToEdit);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(int id = 0) {
        if (id == default) {
            return BadRequest();
        }
        
        var characterToDelete = await _context.Characters.FirstOrDefaultAsync(x => x.Id == id);

        if (characterToDelete == default) {
            return BadRequest();
        }
        
        _context.Remove(characterToDelete);

        await _context.SaveChangesAsync();

        return Ok();
    }
}