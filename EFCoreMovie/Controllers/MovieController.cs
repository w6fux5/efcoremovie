using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovie.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovie.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public MovieController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<MovieDTO>> Get(int id)
    {
        var movie = await _context.Tbl_Movie
            .Include(m => m.Genres.OrderByDescending(g => g.Name))
            .Include(m => m.CinemaHalls.OrderByDescending(ch => ch.Cinema.Name))
                .ThenInclude(ch => ch.Cinema)
            .Include(m => m.MoviesActors)
                .ThenInclude(ma => ma.Actor)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (movie == null)
        {
            return NotFound();
        }

        var movieDTO = _mapper.Map<MovieDTO>(movie);

        movieDTO.Cinemas = movieDTO.Cinemas.DistinctBy(m => m.Id).ToList();

        return movieDTO;
    }


    [HttpGet("autoMapper/{id:int}")]
    public async Task<ActionResult<MovieDTO>> GetWithAutoMapper(int id)
    {
        var movieDTO = await _context.Tbl_Movie
            .ProjectTo<MovieDTO>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (movieDTO is null)
        {
            return NotFound();
        }


        movieDTO.Cinemas = movieDTO.Cinemas.DistinctBy(m => m.Id).ToList();

        return movieDTO;
    }

    [HttpGet("selectLoading/{id:int}")]
    public async Task<ActionResult> GetSelectLoading(int id)
    {
        var movieDTO = await _context.Tbl_Movie.Select(m => new
        {
            Id = m.Id,
            Title = m.Title,
            Genres = m.Genres.Select(g => g.Name).OrderByDescending(n => n).ToList()
        }).FirstOrDefaultAsync(m => m.Id == id);

        if (movieDTO is null)
        {
            return NotFound();
        }

        return Ok(movieDTO);
    }

}
