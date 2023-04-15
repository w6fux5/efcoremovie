using AutoMapper;
using EFCoreMovie.Dtos.Genre;
using EFCoreMovie.Entities;
using EFCoreMovie.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovie.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenreController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GenreController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<GenreEntity>> Get(int page = 1, int pageSize = 2)
    {
        _context.Tbl_Log.Add(new LogEntity { Message = "test" });
        await _context.SaveChangesAsync();

        return await _context.Tbl_Genre
            .AsNoTracking()
            .OrderBy(g => g.Name)
            .Paginate(page, pageSize)
            .ToListAsync();
    }

    [HttpGet("first")]
    public async Task<ActionResult<GenreEntity>> GetFirst()
    {
        var genre = await _context.Tbl_Genre.FirstOrDefaultAsync(g => g.Name.Contains("z"));

        if (genre == null)
        {
            return NotFound();
        }

        return genre;
    }

    [HttpGet("filter")]
    public async Task<IEnumerable<GenreEntity>> Filer(string name)
    {
        return await _context.Tbl_Genre.Where(g => g.Name.StartsWith(name)).ToListAsync();
    }


    [HttpPost]
    public async Task<ActionResult> Post(CreateGenresDTO createGenresDTO)
    {
        var genre = _mapper.Map<GenreEntity>(createGenresDTO);
        var status1 = _context.Entry(genre).State;

        _context.Add(genre); // 在記憶體裡面標記將 genre 添加到數據庫

        var status2 = _context.Entry(genre).State;



        await _context.SaveChangesAsync();

        var status3 = _context.Entry(genre).State;


        return Ok();
    }


    // 一次插入多筆數據
    [HttpPost("several")]
    public async Task<ActionResult> Post(CreateGenresDTO[] createGenersDTO)
    {
        var genres = _mapper.Map<GenreEntity[]>(createGenersDTO);

        _context.AddRange(genres);

        await _context.SaveChangesAsync();

        return Ok();
    }


    [HttpPost("add2")]
    public async Task<ActionResult> Add2(int id)
    {
        var genre = await _context.Tbl_Genre.FirstOrDefaultAsync(prop => prop.Id == id);

        if (genre is null)
        {
            return NotFound();
        }

        genre.Name += " 2";

        await _context.SaveChangesAsync();

        return Ok(genre);
    }


    [HttpPost("concurrency_token")]
    public async Task<ActionResult> ConcurrencyToken()
    {
        var genreId = 1;

        // mike reads record from the db
        var genre = await _context.Tbl_Genre.FirstOrDefaultAsync(p => p.Id == genreId);
        genre.Name = "Mike was here";

        // andy update the record in the db
        await _context.Database.ExecuteSqlInterpolatedAsync($@"UPDATE Tbl_Genre SET Name = 'Andy was here' WHERE id = {genreId}");

        // mike update the record
        await _context.SaveChangesAsync();

        return Ok();

    }

}
