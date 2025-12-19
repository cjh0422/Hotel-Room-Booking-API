using Hotel_Room_Booking_API.Database;
using Hotel_Room_Booking_API.Model;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

namespace Hotel_Room_Booking_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoomController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Room>>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }
    }
}
