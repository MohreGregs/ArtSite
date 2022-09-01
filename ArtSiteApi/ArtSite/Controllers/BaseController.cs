using ArtSite.Database;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtSite.Controllers; 

public class BaseController<TController> : ControllerBase {
    protected DatabaseContext _context;
    private ILogger<TController> _logger;
    protected IMapper _mapper;

    public BaseController(ILogger<TController> logger, IMapper mapper, DatabaseContext context)
    {
        _logger = logger;
        _mapper = mapper;
        _context = context;
    }
    
    
}