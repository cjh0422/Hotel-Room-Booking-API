using Hotel_Room_Booking_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Room_Booking_API.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<Booking> Bookings => Set<Booking>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Name = "101", Type = "Single", IsAvailable = true },
                new Room { Id = 2, Name = "102", Type = "Single", IsAvailable = true },
                new Room { Id = 3, Name = "201", Type = "Double", IsAvailable = true },
                new Room { Id = 4, Name = "301", Type = "Suite", IsAvailable = true }
            );
        }
    }
}
