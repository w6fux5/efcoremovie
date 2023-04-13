using EFCoreMovie.Entities;
using EFCoreMovie.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ActorController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ActorEntity>> Get(int page = 1, int pageSize = 2)
        {
            return await _context.Tbl_Actor
                .AsNoTracking()
                .OrderBy(a => a.Name)
                .Paginate(page, pageSize)
                .ToListAsync();
        }
    }
}
