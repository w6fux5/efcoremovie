using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovie.Dtos.Cinema;
using EFCoreMovie.Entities;
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

    [HttpPost("withDTO")]
    public async Task<ActionResult> Post(CreateCinemaDTO createCinemaDTO)
    {
        var cinema = _mapper.Map<CinemaEntity>(createCinemaDTO);
        _context.Add(cinema);

        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> Post()
    {
        var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
        var cinemaLocation = geometryFactory.CreatePoint(new Coordinate(-69.913539, 18.476256));

        var newCinema = new CinemaEntity()
        {
            Name = "My cinema",
            Location = cinemaLocation,

            CinemaDetail = new CinemaDetailEntity()
            {
                History = "the history...",
                Missions = "the missions...",
            },

            CinemaOffer = new CinemaOfferEntity()
            {
                DiscountPercentage = 5,
                Begin = DateTime.Today,
                End = DateTime.Today.AddDays(7)
            },

            CinemaHalls = new HashSet<CinemaHallEntity>()
            {
                new CinemaHallEntity()
                {
                    Cost = 200,
                    CinemaHallType = CinemaHallTypeEnum.ThreeDimensions
                },

                 new CinemaHallEntity()
                {
                    Cost = 200,
                    CinemaHallType = CinemaHallTypeEnum.TwoDimensions
                },
            }
        };

        _context.Add(newCinema);

        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var cinema = await _context.Tbl_Cinema.Include(prop => prop.CinemaHalls).FirstOrDefaultAsync(c => c.Id == id);

        if (cinema is null)
        {
            return NotFound();
        }

        _context.Remove(cinema);

        await _context.SaveChangesAsync();

        return Ok();
    }
}
