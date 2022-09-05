using ArtSite.Data.Models;
using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtSite.Controllers;

public class CharacterController : BaseEntityController<CharacterController, Character, CharacterModel, AddCharacterModel> {
    public CharacterController(ILogger<CharacterController> logger, IMapper mapper, DatabaseContext context) : base(
        logger, mapper, context) {
    }

    [HttpGet]
    [Route("getIcon")]
    public async Task<ActionResult> GetIcon(int? iconId) {
        if (iconId == null || iconId == 0) {
            return File(System.IO.File.ReadAllBytes("Resources\\placeholderIcon.png"), "image/png");
        }

        var icon = await _context.Artworks.FirstOrDefaultAsync(x => x.Id == iconId);

        return File(icon.File, "image/png");
    }

    [HttpPost]
    [Route("add")]
    public override async Task<ActionResult> Add([FromBody] AddCharacterModel? model) {
        if (model == null)
            return BadRequest();

        var species = await _context.Species.FirstOrDefaultAsync(x => x.Id == model.SpeciesId);

        var originalDesigner = await _context.Artists.FirstOrDefaultAsync(x => x.Id == model.OriginalDesignerId);
        
        var character = new Character {
            Name = model.Name,
            Age = model.Age,
            Sexuality = model.Sexuality,
            Gender = model.Gender,
            Species = species,
            OriginalDesigner = originalDesigner,
            Appearance = new Appearance(),
            GeneralInfo = new GeneralInfo(),
            Personality = new Personality(),
            Interests = new Interests()
        };

        foreach (var tagid in model.TagIds) {
            var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == tagid);
            if (tag != default) character.Tags.Add(tag);
        }

        await _context.AddAsync(character);

        try {
            await _context.SaveChangesAsync();
        }
        catch (Exception ex) {
            Console.WriteLine(ex);

            return StatusCode(500, ex.ToString());
        }

        return Ok(character);
    }
    
    [HttpPut]
    [Route("edit")]
    public override async Task<ActionResult<CharacterModel>> Edit([FromBody] CharacterModel? model) {
        if (model?.Id == default) return BadRequest();

        var character = await _context.Characters.FirstOrDefaultAsync(x => x.Id == model.Id);

        if (character == default) return BadRequest();

        var species = await _context.Species.FirstOrDefaultAsync(x => x.Id == model.Species.Id);

        var originalDesigner = await _context.Artists.FirstOrDefaultAsync(x => x.Id == model.OriginalDesigner.Id);
        
        foreach (var tagModel in model.Tags) {
            var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == tagModel.Id);
            if (tag != default) character.Tags.Add(tag);
        }
        
        character.Name = model.Name;
        character.Age = model.Age;
        character.Gender = model.Gender;
        character.Sexuality = model.Sexuality;
        if (species != default)
            character.OriginalDesigner = originalDesigner;
        if (species != default) 
            character.Species = species;
        character.IconId = model.IconId;

        await _context.SaveChangesAsync();

        return Ok(character);
    }
    
    [HttpDelete]
    [Route("delete")]
    public override async Task<ActionResult> Delete(int id = 0) {
        if (id == default)
            return BadRequest();

        var characterToDelete = await _context.Characters.FindAsync(id);

        if (characterToDelete == default) return NotFound();
        
        foreach (var artwork in characterToDelete.Artworks.ToArray()) {
            characterToDelete.Artworks.Remove(artwork);
            
            await _context.SaveChangesAsync();
        }

        foreach (var tag in characterToDelete.Tags.ToArray()) {
            characterToDelete.Tags.Remove(tag);
            
            await _context.SaveChangesAsync();
        }
        
        foreach (var reference in characterToDelete.References.ToArray()) {
            characterToDelete.References.Remove(reference);
            
            await _context.SaveChangesAsync();
        }

        _context.Remove(characterToDelete);

        await _context.SaveChangesAsync();

        return Ok();
    }
    
}