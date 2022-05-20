using ArtSite.Database;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtSite.Controllers; 
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class BaseController<T> : ControllerBase {
    private ILogger<T> _logger;
    protected IMapper _mapper;
    protected DatabaseContext _context;

    public BaseController(ILogger<T> logger, IMapper mapper, DatabaseContext context)
    {
        _logger = logger;
        _mapper = mapper;
        _context = context;
    }
}