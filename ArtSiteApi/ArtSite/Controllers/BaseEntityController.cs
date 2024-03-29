﻿using ArtSite.Data.Models;
using ArtSite.Database;
using ArtSite.Database.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtSite.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class BaseEntityController<TController, TEntity, TModel, TAddModel> : BaseController<TController>
    where TEntity : BaseEntity
    where TModel : BaseModel
    where TAddModel : BaseModel {
    public BaseEntityController(ILogger<TController> logger, IMapper mapper, DatabaseContext context) : base(logger,
        mapper, context) {
    }

    [HttpGet]
    public async Task<ActionResult<List<TEntity>?>> Get() {
        var data = await _context.Set<TEntity>().ToListAsync();
        var x = _mapper.Map<List<TModel>>(data);
        return Ok(x);
    }

    [HttpGet]
    [Route("getById")]
    public async Task<ActionResult<TEntity?>> GetById(int id = 0) {
        if (id == default) return BadRequest();

        var data = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        return Ok(_mapper.Map<TModel>(data));
    }

    [HttpPost]
    [Route("add")]
    public virtual async Task<ActionResult> Add([FromBody] TAddModel? model) {
        if (model == null)
            return BadRequest();

        var obj = _mapper.Map<TEntity>(model);

        if (obj == null)
            return BadRequest();

        await _context.AddAsync(obj);

        try {
            await _context.SaveChangesAsync();
        }
        catch (Exception ex) {
            Console.WriteLine(ex);

            return StatusCode(500, ex.ToString());
        }

        return Ok(obj);
    }

    [HttpPut]
    [Route("edit")]
    public virtual async Task<ActionResult<TModel>> Edit([FromBody] TModel? model) {
        if (model?.Id == default) return BadRequest();

        var objToEdit = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == model.Id);

        if (objToEdit == default) return BadRequest();

        objToEdit = _mapper.Map<TEntity>(model);

        await _context.SaveChangesAsync();

        return Ok(objToEdit);
    }

    [HttpDelete]
    [Route("delete")]
    public virtual async Task<ActionResult> Delete(int id = 0) {
        if (id == default)
            return BadRequest();

        var objToDelete = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);

        if (objToDelete == default) return NotFound();

        _context.Remove(objToDelete);

        await _context.SaveChangesAsync();

        return Ok();
    }
}