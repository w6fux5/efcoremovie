using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovie.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCoreMovie.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CinemaController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CinemaController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CinemaDTO>> Get()
    {
        return await _context.Tbl_Cinema
            .ProjectTo<CinemaDTO>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    [HttpGet("closeToMe")]
    public async Task<ActionResult> Get(double latitude, double longitude)
    {
        var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

        var myLocation = geometryFactory.CreatePoint(new Coordinate(longitude, latitude));

        var maxDistanceInMeters = 2000; // 2 kms

        var cinemas = await _context.Tbl_Cinema
            .OrderBy(c => c.Location.Distance(myLocation))
            .Where(c => c.Location.IsWithinDistance(myLocation, maxDistanceInMeters))
            .Select(c => new { Name = c.Name, Distance = Math.Round(c.Location.Distance(myLocation)) })
            .ToListAsync();

        return Ok(cinemas);
    }
}
