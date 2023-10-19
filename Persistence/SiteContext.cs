using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class SiteContext : DbContext
    {
        public SiteContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
    }
}