using AutoMapper;
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
            .Include(m => m.Genres)
            .Include(m => m.CinemaHalls)
            .ThenInclude(ch => ch.Cinema)
            .Include(m => m.MoviesActors)
            .ThenInclude(ma => ma.Actor)
            .FirstOrDefaultAsync(m => m.Id == id);

        if(movie == null)
        {
            return NotFound();
        }

        var movieDTO = _mapper.Map<MovieDTO>(movie);

        movieDTO.Cinemas = movieDTO.Cinemas.DistinctBy(m => m.Id).ToList();

        return movieDTO;
    }

}
