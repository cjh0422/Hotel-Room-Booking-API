using Hotel_Room_Booking_API.Database;
using Hotel_Room_Booking_API.DTO;
using Hotel_Room_Booking_API.Model;
using Hotel_Room_Booking_API.Repositories;
using Hotel_Room_Booking_API.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Hotel_Room_Booking_API.Test
{
    public class BookingServiceTest
    {
        private readonly AppDbContext _context;
        private readonly BookingService _service;

        public BookingServiceTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("TestDb" + Guid.NewGuid())
                .Options;
            _context = new AppDbContext(options);
            _context.Rooms.Add(new Room { Id = 1, Name = "101", Type = "Single", IsAvailable = true });
            _context.SaveChanges();

            var roomRepo = new RoomRepository(_context);
            var bookingRepo = new BookingRepository(_context);
            _service = new BookingService(bookingRepo, roomRepo);
        }

        [Fact]
        public async Task CreateBooking_ShouldSucceed_WhenRoomAvailable()
        {
            var dto = new CreateBookingDto
            {
                GuestName = "Test",
                RoomId = 1,
                CheckInDate = new DateTime(2025, 12, 20),
                CheckOutDate = new DateTime(2025, 12, 22)
            };

            var booking = await _service.CreateBookingAsync(dto);

            Assert.NotNull(booking);
            Assert.Equal("Test", booking.GuestName);
        }

        [Fact]
        public async Task CreateBooking_ShouldFail_WhenDatesOverlap()
        {
            var dto1 = new CreateBookingDto
            {
                GuestName = "First",
                RoomId = 1,
                CheckInDate = new DateTime(2025, 12, 20),
                CheckOutDate = new DateTime(2025, 12, 25)
            };
            await _service.CreateBookingAsync(dto1);

            var dto2 = new CreateBookingDto
            {
                GuestName = "Second",
                RoomId = 1,
                CheckInDate = new DateTime(2025, 12, 24),
                CheckOutDate = new DateTime(2025, 12, 26)
            };

            await Assert.ThrowsAsync<InvalidOperationException>(() => _service.CreateBookingAsync(dto2));
        }
    }
}
