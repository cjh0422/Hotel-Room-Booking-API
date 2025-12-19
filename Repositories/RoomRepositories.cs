using Hotel_Room_Booking_API.Database;
using Hotel_Room_Booking_API.Model;

using Microsoft.EntityFrameworkCore;

namespace Hotel_Room_Booking_API.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _context;

        public RoomRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Room>> GetAllAsync() => await _context.Rooms.ToListAsync();

        public async Task<Room?> GetByIdAsync(int id) => await _context.Rooms.FindAsync(id);

        public async Task UpdateAsync(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }
    }
}
