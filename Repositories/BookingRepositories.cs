using Hotel_Room_Booking_API.Database;
using Hotel_Room_Booking_API.Model;

using Microsoft.EntityFrameworkCore;

namespace Hotel_Room_Booking_API.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetAllAsync() => await _context.Bookings.ToListAsync();

        public async Task AddAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }
    }
}
