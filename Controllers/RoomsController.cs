using Hotel_Room_Booking_API.Database;
using Hotel_Room_Booking_API.Model;
using Hotel_Room_Booking_API.Services;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

//namespace Hotel_Room_Booking_API.Controllers
//{
    [ApiController]
    [Route("api/rooms")]
    public class RoomsController : ControllerBase
    {
        //private readonly AppDbContext _context;

        //public RoomController(AppDbContext context)
        //{
        //    _context = context;
        //}
        private readonly IRoomService _service;

        public RoomsController(IRoomService service) => _service = service;

        //[HttpGet]
        //public async Task<ActionResult<List<Room>>> GetRooms()
        //{
        //    return await _context.Rooms.ToListAsync();
        //}
        [HttpGet]
        public async Task<ActionResult<List<Room>>> Get() => await _service.GetAllRoomsAsync();

    }
//}
