using ArtSite.Data.Models;
using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;
using Castle.Core.Internal;
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
    [Route("search")]
    public async Task<ActionResult> GetSearchedCharacters(SearchObject searchObject) {
        var filteredCharacters = _context.Characters.ToList();
        
        if (searchObject.Gender != null) {
            filteredCharacters = filteredCharacters.Where(x => x.Gender == searchObject.Gender).ToList();
        }

        if (searchObject.Sexuality != null) {
            filteredCharacters = filteredCharacters.Where(x => x.Sexuality == searchObject.Sexuality).ToList();
        }

        if (searchObject.MinAge != null) {
            if (searchObject.MaxAge != null) {
                filteredCharacters = filteredCharacters
                    .Where(x => x.Age >= searchObject.MinAge && x.Age <= searchObject.MaxAge).ToList();
            }
            else {
                filteredCharacters = filteredCharacters
                    .Where(x => x.Age >= searchObject.MinAge).ToList();
            }
        }
        else if (searchObject.MaxAge != null) {
            filteredCharacters = filteredCharacters
                    .Where(x => x.Age <= searchObject.MaxAge).ToList();
        }

        if (searchObject.Species != null) {
            filteredCharacters = filteredCharacters.Where(x => x.Species.Id == searchObject.Species).ToList();
        }

        if (searchObject.Tags != null) {
            foreach (var (key, value) in searchObject.Tags) {
                filteredCharacters = filteredCharacters.Where(x => x.Tags.Any(y => y.Id == key)).ToList();
            }
        }

        if (!searchObject.NameString.IsNullOrEmpty()) {
            filteredCharacters = filteredCharacters.Where(x => x.Name.Contains(searchObject.NameString)).ToList();
        }

        return Ok(_mapper.Map<List<CharacterModel>>(filteredCharacters));
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
            WantedArtwork = model.WantedArtwork,
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
        character.WantedArtwork = model.WantedArtwork;
        if (species != default)
            character.OriginalDesigner = originalDesigner;
        if (species != default) 
            character.Species = species;
        character.IconId = model.IconId;

        await _context.SaveChangesAsync();

        return Ok(character);
    }

    [HttpPost]
    [Route("setIcon")]
    public async Task<ActionResult<CharacterModel>> SetIcon([FromBody] SetIconModel? model) {
        if (model == default) return BadRequest();

        var character = await _context.Characters.FirstOrDefaultAsync(x => x.Id == model.CharacterId);

        if (character == default) return BadRequest();

        character.IconId = model.ArtworkId;
        
        await _context.SaveChangesAsync();

        return Ok();
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