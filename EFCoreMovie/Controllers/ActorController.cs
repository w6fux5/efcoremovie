using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovie.Dtos;
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
        private readonly IMapper _mapper;

        public ActorController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ActorDTO>> Get(int page = 1, int pageSize = 2)
        {
            return await _context.Tbl_Actor
                .AsNoTracking()
                .OrderBy(a => a.Name)
                .ProjectTo<ActorDTO>(_mapper.ConfigurationProvider)
                .Paginate(page, pageSize)
                .ToListAsync();
        }

        [HttpGet("ids")]
        public async Task<IEnumerable<int>> GetIds()
        {
            return await _context.Tbl_Actor.Select(a => a.Id).ToListAsync();
        }
    }
}
