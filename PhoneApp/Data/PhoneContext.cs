using Microsoft.EntityFrameworkCore;
using PhoneApp.Models;

namespace PhoneApp.Data
{
    public class PhoneContext : DbContext
    {
        public PhoneContext (DbContextOptions<PhoneContext> options)
            : base(options)
        {
        }

        public DbSet<Call> Calls { get; set; }

        public DbSet<EventType> EventTypes { get; set; }

        public DbSet<Event> Events { get; set; }
    }
}
