using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovie.Dtos.Actor;
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


        [HttpPost]
        public async Task<ActionResult> Post(CreateActorDTO createActorDTO)
        {
            var actor = _mapper.Map<ActorEntity>(createActorDTO);
            _context.Add(actor);

            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(CreateActorDTO createActorDTO, int id)
        {
            var actorDB = await _context.Tbl_Actor.FirstOrDefaultAsync(prop => prop.Id == id);

            if (actorDB is null)
            {
                return NotFound();
            }

            actorDB = _mapper.Map(createActorDTO, actorDB);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("disconnected/{id:int}")]
        public async Task<ActionResult> PutDisconnect(CreateActorDTO createActorDTO, int id)
        {
            var existsActor = await _context.Tbl_Actor.AnyAsync(prop => prop.Id == id);

            if (!existsActor)
            {
                return NotFound();
            }

            var actor = _mapper.Map<ActorEntity>(createActorDTO);

            actor.Id = id;

            _context.Update(actor);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
