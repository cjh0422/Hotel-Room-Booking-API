using Hotel_Room_Booking_API.Database;
using Hotel_Room_Booking_API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Room_Booking_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Booking>>> GetBookings()
        {
            return await _context.Bookings.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking(Booking booking)
        {
            var room = await _context.Rooms.FindAsync(booking.RoomId);
            if (room == null) return NotFound("Room not found");
            if (!room.IsAvailable) return BadRequest("Room is not available");

            room.IsAvailable = false;

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookings), new { id = booking.Id }, booking);
        }
    }
}
