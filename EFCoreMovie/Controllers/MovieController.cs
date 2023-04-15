using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovie.Dtos.Movie;
using EFCoreMovie.Entities;
using EFCoreMovie.Entities.Keyless;
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
            .Include(m => m.MovieActors)
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

    [HttpGet("explicitLoading/{id:int}")]
    public async Task<ActionResult<MovieDTO>> GetExplicit(int id)
    {
        var movie = await _context.Tbl_Movie.FirstOrDefaultAsync(m => m.Id == id);

        if (movie is null)
        {
            return NotFound();
        }

        // await _context.Entry(movie).Collection(p => p.Genres).LoadAsync();  // 一般查詢

        var genresCount = await _context.Entry(movie).Collection(p => p.Genres).Query().CountAsync();

        var movieDTO = _mapper.Map<MovieDTO>(movie);

        return Ok(new
        {
            id = movieDTO.Id,
            Title = movieDTO.Title,
            genresCount = genresCount,
        });

    }

    [HttpGet("groupedByClinema")]
    public async Task<ActionResult> GetGroupedByClinema()
    {
        var groupedMovies = await _context.Tbl_Movie.GroupBy(m => m.InCinemas).Select(g => new
        {
            InCinemas = g.Key,
            Count = g.Count(),
            Movies = g.ToList()
        }).ToListAsync();

        return Ok(groupedMovies);
    }


    [HttpGet("groupedByGenresCount")]
    public async Task<ActionResult> GetGroupedByGenresCount()
    {
        var groupedByGenresCount = await _context.Tbl_Movie.GroupBy(m => m.Genres.Count()).Select(g => new
        {
            Count = g.Key,
            Titles = g.Select(m => m.Title),
            Genres = g.Select(m => m.Genres).SelectMany(a => a).Select(ge => ge.Name).Distinct()
        }).ToListAsync();


        return Ok(groupedByGenresCount);
    }


    [HttpGet("filter")]
    public async Task<ActionResult<IEnumerable<MovieDTO>>> Filter([FromQuery] MovieFilterDTO filter)
    {
        var moviesQueryable = _context.Tbl_Movie.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Title))
        {
            moviesQueryable = moviesQueryable
                .Where(m => m.Title.Contains(filter.Title));
        }

        if (filter.InCinemas)
        {
            moviesQueryable = moviesQueryable
                .Where(m => m.InCinemas == filter.InCinemas);
        }

        if (filter.UpComingReleases)
        {
            var today = DateTime.Today;
            moviesQueryable = moviesQueryable
                .Where(m => m.ReleaseDate >= today);
        }

        if (filter.GenredId != 0)
        {
            moviesQueryable = moviesQueryable
                .Where(m => m.Genres.Select(g => g.Id).Contains(filter.GenredId));
        }

        var movies = await moviesQueryable.Include(m => m.Genres).ToListAsync();

        return _mapper.Map<List<MovieDTO>>(movies);

    }


    [HttpPost]
    public async Task<ActionResult> Post(CreateMovieDTO createMovieDTO)
    {
        var movie = _mapper.Map<MovieEntity>(createMovieDTO);

        movie.Genres.ForEach(g => _context.Entry(g).State = EntityState.Unchanged); // 不要再次建立 Genres

        movie.CinemaHalls.ForEach(ch => _context.Entry(ch).State = EntityState.Unchanged); // 不要再次建立 CinemaHall

        if (movie.MovieActors is not null)
        {
            for (int i = 0; i < movie.MovieActors.Count; i++)
            {
                movie.MovieActors[i].Order = i + 1;
            }
        }


        _context.Add(movie);

        await _context.SaveChangesAsync();

        return Ok();
    }


    [HttpGet("movieWithCountUseView")]
    public async Task<IEnumerable<MovieWithCount>> Get()
    {
        return await _context.Set<MovieWithCount>().ToListAsync();
    }


    [HttpGet("movieCountUseFunc/{id:int}")]
    public async Task<ActionResult<MovieWithCount>> GetCount(int id)
    {
        var result = await _context.MovieWithCountsFunc(id).FirstOrDefaultAsync();

        if (result is null)
        {
            return NotFound();
        }

        return result;
    }


}
