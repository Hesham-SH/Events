using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class EventsController : BaseApiController
    {
        private readonly SiteContext _context;
        public EventsController(SiteContext context)
        {
            _context = context;
            
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Event>>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(Guid id)
        {
            return await _context.Events.FindAsync(id);
        }
    }
}