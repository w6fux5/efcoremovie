using EFCoreMovie.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovie.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PersonController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        return Ok(await _context.Tbl_Person.ToListAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PersonEntity>> Get(int id)
    {
        var person = await _context.Tbl_Person
            .Include(prop => prop.SendMessages)
            .Include(prop => prop.ReceivedMessages)
            .FirstOrDefaultAsync(prop => prop.Id == id);

        if (person is null)
        {
            return NotFound();
        }

        return person;
    }
}
