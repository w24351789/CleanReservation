using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext( DbContextOptions options) : base(options)
        {
        }
        public DbSet<Jaintor> Jaintors { get; set; }
        public DbSet<ReservationPeriod> ReservationPeriods { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        
    }
}
