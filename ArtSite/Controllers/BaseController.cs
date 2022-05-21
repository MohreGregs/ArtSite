using ArtSite.Database;
using ArtSite.Database.Entities;
using ArtSite.Database.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtSite.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class BaseController<TController, TEntity> : ControllerBase where TEntity : BaseEntity
{
    protected DatabaseContext _context;
    private ILogger<TController> _logger;
    protected IMapper _mapper;

    public BaseController(ILogger<TController> logger, IMapper mapper, DatabaseContext context)
    {
        _logger = logger;
        _mapper = mapper;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<TEntity>?>> Get()
    {
        var data = await _context.Set<TEntity>().ToListAsync();

        return Ok(data);
    }

    [HttpGet]
    [Route("getById")]
    public async Task<ActionResult<TEntity?>> GetById(int id = 0)
    {
        if (id == default) return BadRequest();

        return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
    }

    [HttpPost]
    [Route("add")]
    public async Task<ActionResult> Add([FromBody] BaseNameModel? model)
    {
        if (model == null)
            return BadRequest();

        var obj = _mapper.Map<TEntity>(model);

        if (obj == null)
            return BadRequest();

        await _context.AddAsync(obj);

        await _context.SaveChangesAsync();

        return Ok(obj);
    }

    [HttpPut]
    [Route("edit")]
    public virtual async Task<ActionResult<TEntity>> Edit([FromBody] TEntity? model)
    {
        if (model == default) return BadRequest();

        var objToEdit = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x == model);

        if (objToEdit == default)
        {
            return BadRequest();
        }

        objToEdit = model;
        
        await _context.SaveChangesAsync();

        return Ok(objToEdit);
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<ActionResult> Delete(int id = 0)
    {
        if (id == default) 
            return BadRequest();

        var objToDelete = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);

        if (objToDelete == default) return NotFound();
        
        _context.Remove(objToDelete);

        await _context.SaveChangesAsync();

        return Ok();
    }
}