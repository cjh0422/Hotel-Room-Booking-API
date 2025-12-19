using Hotel_Room_Booking_API.DTO;
using Hotel_Room_Booking_API.Model;
using Hotel_Room_Booking_API.Repositories;

namespace Hotel_Room_Booking_API.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IRoomRepository _roomRepo;

        public BookingService(IBookingRepository bookingRepo, IRoomRepository roomRepo)
        {
            _bookingRepo = bookingRepo;
            _roomRepo = roomRepo;
        }

        public async Task<List<Booking>> GetAllBookingsAsync() => await _bookingRepo.GetAllAsync();

        public async Task<Booking> CreateBookingAsync(CreateBookingDto dto)
        {
            var room = await _roomRepo.GetByIdAsync(dto.RoomId);
            if (room == null) throw new KeyNotFoundException("Room not found");
            if (!room.IsAvailable) throw new InvalidOperationException("Room is not available");



            room.IsAvailable = false;
            await _roomRepo.UpdateAsync(room);

            var booking = new Booking
            {
                GuestName = dto.GuestName,
                RoomId = dto.RoomId,
                CheckInDate = dto.CheckInDate,
                CheckOutDate = dto.CheckOutDate
            };

            await _bookingRepo.AddAsync(booking);
            return booking;
        }
    }
}
