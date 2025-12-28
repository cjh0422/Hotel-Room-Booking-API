using Hotel_Room_Booking_API.Database;
using Hotel_Room_Booking_API.DTO;
using Hotel_Room_Booking_API.Model;
using Hotel_Room_Booking_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//namespace Hotel_Room_Booking_API.Controllers
//{
    [ApiController]
    [Route("api/bookings")]
    public class BookingsController : ControllerBase
    {
        //private readonly AppDbContext _context;

        //public BookingController(AppDbContext context)
        //{
        //    _context = context;
        //}
        private readonly IBookingService _service;
        public BookingsController(IBookingService service) => _service = service;

        //[HttpGet]
        //public async Task<ActionResult<List<Booking>>> GetBookings()
        //{
        //    return await _context.Bookings.ToListAsync();
        //}

        //[HttpPost]
        //public async Task<ActionResult<Booking>> CreateBooking(Booking booking)
        //{
        //    var room = await _context.Rooms.FindAsync(booking.RoomId);
        //    if (room == null) return NotFound("Room not found");
        //    if (!room.IsAvailable) return BadRequest("Room is not available");

        //    room.IsAvailable = false;

        //    _context.Bookings.Add(booking);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetBookings), new { id = booking.Id }, booking);
        //}
        [HttpGet]
        public async Task<ActionResult<List<Booking>>> Get() => await _service.GetAllBookingsAsync();

        [HttpPost]
        public async Task<ActionResult<Booking>> Post(CreateBookingDto dto)
        {
            try
            {
                var booking = await _service.CreateBookingAsync(dto);
                return CreatedAtAction(nameof(Get), new { id = booking.Id }, booking);
            }
            catch (KeyNotFoundException ex) { return NotFound(ex.Message); }
            catch (InvalidOperationException ex) { return BadRequest(ex.Message); }
        }
    }
//}
