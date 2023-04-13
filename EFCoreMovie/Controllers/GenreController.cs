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

    public GenreController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<GenreEntity>> Get(int page = 1, int pageSize = 2)
    {
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

        if(genre == null)
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
}
